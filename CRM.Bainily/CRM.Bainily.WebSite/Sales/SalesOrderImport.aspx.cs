using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales_SalesOrderImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //不涉及到客户端页面的代码，放在这里可以保证不会重复执行
        }
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        Response.Write("123<br/>123");
    }
}