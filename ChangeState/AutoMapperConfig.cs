using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeState
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            //BaseCollateral
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Collateral, Models.Collateral>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Evaluation, Models.Evaluation>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Amount, Models.Amount>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Status, Models.Status>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Type, Models.Type>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Subtype, Models.Subtype>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Currency, Models.Currency>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.SaleType, Models.SaleType>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.EvalutionType, Models.EvalutionType>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Source, Models.Source>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.State, Models.State>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Collateral.Moratorium, Models.Moratorium>();

            Mapper.CreateMap<Models.Collateral, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Collateral>();
            Mapper.CreateMap<Models.Status, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Status>();
            Mapper.CreateMap<Models.Type, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Type>();
            Mapper.CreateMap<Models.Subtype, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Subtype>();
            Mapper.CreateMap<Models.SaleType, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.SaleType>();
            Mapper.CreateMap<Models.State, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.State>();
            Mapper.CreateMap<Models.Moratorium, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Moratorium>();


            //Evaluation
            Mapper.CreateMap<Models.Evaluation, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Evaluation>();
            Mapper.CreateMap<Models.Source, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Source>();
            Mapper.CreateMap<Models.EvalutionType, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.EvalutionType>();
            Mapper.CreateMap<Models.Amount, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Amount>();
            Mapper.CreateMap<Models.Currency, CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Currency>();

            //Car
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.Car, Models.Car>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.BodyType, Models.BodyType>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.Brand, Models.Brand>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.Model, Models.Model>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.Color, Models.Color>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.GearBox, Models.GearBox>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Car.Region, Models.Region>();


            Mapper.CreateMap<Models.Car, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Car>();
            Mapper.CreateMap<Models.BodyType, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.BodyType>();
            Mapper.CreateMap<Models.Brand, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Brand>();
            Mapper.CreateMap<Models.Model, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Model>();
            Mapper.CreateMap<Models.Color, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Color>();
            Mapper.CreateMap<Models.GearBox, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.GearBox>();
            Mapper.CreateMap<Models.Region, CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Region>();

            //Other
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.OtherCollateral.OtherCollateral, Models.Other>();
            Mapper.CreateMap<Models.Other, CollateralService.ApiClient.Client.Models.Presentation.Requests.OtherCollateral.OtherCollateral>();


            //Mortage
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.Mortgage, Models.Mortgage>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.District, Models.District>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.Settlement, Models.Settlement>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.StreetType, Models.StreetType>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.Appointment, Models.Appointment>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.SettlementType, Models.SettlementType>();

            Mapper.CreateMap<Models.Mortgage, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Mortgage>();
            Mapper.CreateMap<Models.District, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.District>();
            Mapper.CreateMap<Models.Settlement, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Settlement>();
            Mapper.CreateMap<Models.StreetType, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.StreetType>();
            Mapper.CreateMap<Models.Appointment, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Appointment>();
            Mapper.CreateMap<Models.SettlementType, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.SettlementType>();

            Mapper.CreateMap<Models.Region, CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Region>();
            Mapper.CreateMap<CollateralService.ApiClient.Client.Models.Presentation.Responses.Mortgage.Region, Models.Region>();


        }
    }
}
