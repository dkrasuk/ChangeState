using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeState
{
   public static class Bootstraper
    {
        public static void Register(IUnityContainer container)
        {           
            CollateralServiceApiClient.Bootstraper.Register(container);            
        }

    }
}
