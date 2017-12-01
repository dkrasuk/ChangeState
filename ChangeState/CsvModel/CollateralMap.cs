using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace ChangeState.CsvModel
{
    public class CollateralMap : CsvClassMap<CollateralAgreementId>
    {
        public CollateralMap()
        {
            try
            {
                Map(m => m.CollateralId).Name("CollateralAgreementId");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }   
}
