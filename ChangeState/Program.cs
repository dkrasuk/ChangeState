using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CollateralService.ApiClient.Client;
using CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral;
using System.Globalization;
using System.Collections.Concurrent;
using Microsoft.Rest;
using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using System.Web.Http;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using ChangeState.Models;
using Oracle.ManagedDataAccess.Client;
using CsvHelper.Configuration;
using Microsoft.Win32;
using System.Windows;
using ChangeState.CsvModel;
using CsvHelper;

namespace ChangeState
{
    public static class Program
    {
        public static CollateralServiceWebAPI _service;
        public static Models.Evaluation evaluation = null;      

        public static List<string> collateralIdList = new List<string>();
        public static OracleConnection connection = null;

        static void Main(string[] args)
        {
            AutoMapperConfig.RegisterMappings();

            var credentials = new BasicAuthenticationCredentials();
            credentials.UserName = ConfigurationManager.AppSettings["CollateralServiceApiLogin"];
            credentials.Password = ConfigurationManager.AppSettings["CollateralServiceApiPassword"];
            _service = new CollateralServiceWebAPI(new Uri(ConfigurationManager.AppSettings["CollateralServiceApi"]), credentials);
            //Проверка сертификата отключена, на уровне ServerCertificateValidationCallback
            //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            // ConnectToOracle();
            // GetAllCollateralIdFromDB();
            // PostEvaluationToCollateral("eec40b58-e30f-4b0f-b852-5fadfb22b843"); 
            // UpdateCollateralState();

            Console.WriteLine(
@"SELECT '1' - UpdateEvaluationToCollateral from CSV file ({0})
SELECT '2' - UpdateCollateralState from CSV file ({1})
SELECT '0' - EXIT
", ConfigurationManager.AppSettings["PathUpdateEvaluation"], ConfigurationManager.AppSettings["PathUpdateStateCollateral"]);

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        UpdateEvaluationToCollateral();
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    {
                        UpdateCollateralState();
                        Console.ReadKey();
                    }
                    break;
                case 0:
                    {
                        Environment.Exit(0);
                    }
                    break;
                default: { Console.WriteLine("ERROR: Choose 1 or 2"); Console.ReadKey(); } break;
            }
            Console.ReadLine();



        }
        /// <summary>
        /// UPDATE Evaluation в Collateral - из EvaluationHistory берем последнее значение и пишем в поле Evaluation из БД
        /// </summary>
        /// <param name="collateralId"></param>
        /// <returns></returns> 
        public static string PostEvaluationToCollateral(string collateralId)
        {
            var collateral = _service.Collateral.GetCollateralByCollateralId(collateralId);
            var answer = Mapper.Map<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Collateral, Models.Collateral>(collateral);
            string evalId = string.Empty;

            if (answer.EvaluationHistory.Count() > 0)
            {
                evaluation = answer.EvaluationHistory.ToList().OrderByDescending(x => x.Date).FirstOrDefault();
                var evaluationItem = Mapper.Map<Models.Evaluation, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Evaluation>(evaluation);

                evalId = _service.Collateral.PostEvaluation(answer.Id, evaluationItem);
            }
            Console.WriteLine(evalId);
            return evalId;
        }


        /// <summary>
        /// Получаем List<string> из CollateralId
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllCollateralIdFromDB()
        {
            try
            {
                connection = ConnectToOracle();
                connection.Open();
                var startTime = DateTime.Now;
                Console.WriteLine(connection.State + " " + startTime);

                OracleCommand command = connection.CreateCommand();
                string query = ConfigurationManager.AppSettings["GetAllCollateralId"];
                command.CommandText = query;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    collateralIdList.Add((string)reader["ID"]);
                }

                connection.Close();
                Console.WriteLine(connection.State + " {0} " + "COUNT COLLATERAL + {1}", DateTime.Now - startTime, collateralIdList.Count());
                return collateralIdList;
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Возвращаем connection to DataBase
        /// </summary>
        /// <returns></returns>
        public static OracleConnection ConnectToOracle()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CollateralServiceDB"].ConnectionString;
            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                return connection;
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Update Evaluation to Collateral из *.csv файла
        /// </summary>
        /// <param name="collateralId"></param>
        /// <returns></returns>
        public static void UpdateEvaluationToCollateral()
        {
            string pathUpdateEvaluation = ConfigurationManager.AppSettings["PathUpdateEvaluation"];
            int count = 0;
            try
            {
                using (StreamReader reader = File.OpenText(pathUpdateEvaluation))
                {
                    var csv = new CsvReader(reader);
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.Encoding = Encoding.UTF8;
                    csv.Configuration.RegisterClassMap(new CollateralMap());
                    var collateral = csv.GetRecords<CollateralAgreementId>().Where(i => !string.IsNullOrEmpty(i.CollateralId)).ToList();

                    Parallel.ForEach(collateral, new ParallelOptions { MaxDegreeOfParallelism = 10 }, item =>
                     {
                         var baseCollateral = _service.Collateral.GetCollateralByCollateralId(item.CollateralId);
                         var answer = Mapper.Map<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Collateral, Models.Collateral>(baseCollateral);

                         if (answer.EvaluationHistory.Count() > 0)
                         {
                             evaluation = answer.EvaluationHistory.ToList().OrderByDescending(x => x.Date).OrderByDescending(x => x.DateEntry).FirstOrDefault();
                             var evaluationItem = Mapper.Map<Models.Evaluation, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Evaluation>(evaluation);

                             var response = _service.Collateral.PostEvaluation(answer.Id, evaluationItem);
                             count++;
                             Console.WriteLine("Id: {0} | Update Evaluation Successful | current: {1} ", answer.Id, count);
                         }
                     }
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("{0} Evaluation Collateral have been updated", count);
        }


        /// <summary>
        /// Проставляет State в 7 (продан) по залогам из *.csv
        /// </summary>
        public static void UpdateCollateralState()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            StreamWriter file = new StreamWriter(path + "\\ErrorCollateral.txt", false);
            string pathUpdateStateCollateral = ConfigurationManager.AppSettings["PathUpdateStateCollateral"];
            int count = 0;
            try
            {
                using (StreamReader reader = File.OpenText(pathUpdateStateCollateral))
                {
                    var csv = new CsvReader(reader);
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.Encoding = Encoding.UTF8;
                    csv.Configuration.RegisterClassMap(new CollateralMap());

                    var collateral = csv.GetRecords<CollateralAgreementId>().Where(i => !string.IsNullOrEmpty(i.CollateralId)).ToList();


                    Parallel.ForEach(collateral, new ParallelOptions { MaxDegreeOfParallelism = 10 }, item =>
                    {


                        var baseCollateral = _service.Collateral.GetCollateralByCollateralId(item.CollateralId);
                        if (baseCollateral == null)
                        {
                            file.WriteLine("Type: {0} | Id: {1} | Update Successful", item.CollateralId);
                        }
                        var answer = Mapper.Map<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Collateral, Models.Collateral>(baseCollateral);

                        switch (answer.Type.Name)
                        {
                            case "AUTO":
                                {
                                    var carCollateral = _service.Collateral.GetCarDetails(answer.Id);
                                    Car car = Mapper.Map<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.Car, Car>(carCollateral);
                                    car.Status = new Models.Status { Id = "7", Name = "Продан" };
                                    var newCar = Mapper.Map<Models.Car, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Car>(car);
                                    newCar.ModifyUser = "system";
                                    var responseCar = _service.Collateral.PutCar(newCar);
                                    count++;
                                    Console.WriteLine("Type: {0} | Id: {1} | Update Successful", newCar.Type.Name, newCar.Id);
                                }
                                break;
                            case "OTHER":
                                {
                                    var otherCollateral = _service.Collateral.GeOtherCollateralDetails(answer.Id);
                                    Other other = Mapper.Map<CollateralService.ApiClient.Client.Models.Presentation.Responses.OtherCollateral.OtherCollateral, Other>(otherCollateral);
                                    other.Status = new Models.Status { Id = "7", Name = "Продан" };
                                    var newOther = Mapper.Map<Models.Other, CollateralService.ApiClient.Client.Models.Presentation.Requests.OtherCollateral.OtherCollateral>(other);
                                    newOther.ModifyUser = "system";
                                    var responseOther = _service.Collateral.PutOtherCollateral(newOther);
                                    count++;
                                    Console.WriteLine("Type: {0} | Id: {1} | Update Successful", newOther.Type.Name, newOther.Id);
                                }
                                break;
                            case "HOME":
                            case "FLAT":
                            case "COMMERCIAL":
                            case "LAND":
                                {
                                    var mortageCollateral = _service.Collateral.GetMortgageDetails(answer.Id);// _service.Collateral.GetMortgageDetails(answer.Id);
                                    Mortgage mortage = Mapper.Map<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.Mortgage, Mortgage>(mortageCollateral);
                                    mortage.Status = new Models.Status { Id = "7", Name = "Продан" };
                                    var newMortage = Mapper.Map<Models.Mortgage, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Mortgage>(mortage);
                                    newMortage.ModifyUser = "system";
                                    var responseMortage = _service.Collateral.PutMortgage(newMortage);
                                    count++;
                                    Console.WriteLine("Type: {0} | Id: {1} | Update Successful", newMortage.Type.Name, newMortage.Id);
                                }
                                break;
                            default:
                                {
                                    Console.WriteLine("Type: {0} | Id: {1} | Update Successful", answer.Type.Name, answer.Id);
                                    file.WriteLine("Type: {0} | Id: {1} | Update Successful", answer.Type.Name, answer.Id);
                                    count++;
                                }
                                break;
                        }

                    }
                    );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("{0} Collateral State have been updated", count);
        }

    }
}