using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcf_dockerize_example
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public DemoObject Test()
        {
            // try to get environment variable DEMO_ENV
            var env = Environment.GetEnvironmentVariable("PATH");
            if (env == null)
            {
                env = "undefined";
            }


            // try to get service key from web.config
            var serviceKey = System.Configuration.ConfigurationManager.AppSettings["ServiceKey"];
            if (serviceKey == null)
            {
                serviceKey = "undefined";
            }

            return new DemoObject
            {
                ServiceKey = serviceKey,
                WebConfigEnv = env
            };
        }
    }
}
