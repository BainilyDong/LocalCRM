using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Bainily.Plugin.SalesOrder
{
    public class SalesOrderBtn : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                IOrganizationService serviceAdmin = serviceFactory.CreateOrganizationService(null);
                string id = context.InputParameters["id"] as string;
                string name = context.InputParameters["name"] as string;
                string userid = context.UserId.ToString();
                context.OutputParameters["Result"] = "id:" + id + ",name:" + name + "userid:" + userid;
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
