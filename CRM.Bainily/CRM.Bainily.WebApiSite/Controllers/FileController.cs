using CRM.Core;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CRM.Bainily.WebApiSite.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        [HttpPost, Route("FileUpload")]
        public string FileUpload(string id, string name)
        {
            return id + "---" + name + "---" + HttpContext.Current.Request.Files.Count.ToString();
            IOrganizationService service = CrmOrganization.GetService("BainilyDEV");
            var ent = service.Retrieve("new_test", new Guid("{BE227DA9-F77A-ED11-8D9D-000C294CFB6D}"), new Microsoft.Xrm.Sdk.Query.ColumnSet("new_name"));
            return ent.GetAttributeValue<string>("new_name");
        }
    }
}