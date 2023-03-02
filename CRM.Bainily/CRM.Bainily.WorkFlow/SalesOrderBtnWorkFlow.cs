using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Bainily.WorkFlow
{
    public class SalesOrderBtnWorkFlow : CodeActivity
    {
        [Input("id")]
        public InArgument<string> id { get; set; }
        //实体名称
        [Input("name")]
        public InArgument<string> name { get; set; }
        //返回结果
        [Output("Result")]
        public OutArgument<string> Result { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string id = context.GetValue<string>("id");
            string name = context.GetValue<string>("name");
            Result.Set(context, "id:" + id + ",name:" + name);
        }
    }
}
