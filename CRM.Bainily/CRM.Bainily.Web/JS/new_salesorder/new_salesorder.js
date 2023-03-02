//#region 文件描述
/******************************************************************
 ** Copyright @ 广州赛意信息科技股份有限公司 All rights reserved.
 ** 创建人   :   bainily dong
 ** 创建时间 :   2022-12-06
 ** 说明     :   订单 salesorder
 ******************************************************************/
//#endregion
//测试按钮
function SalesOrderBtn() {
    var obj = {};
    obj.id = sie.getEntityId();
    obj.name = Xrm.Page.getAttribute("name").getValue();
    var result = sie.invokeAction("new_SalesOrderBtn", obj);
    if (result != null && result.Result) {
        alert(result.Result);
    }
}
//测试按钮显示逻辑
function SalesOrderBtnShow() {
    var paymenttermscode = Xrm.Page.getAttribute("paymenttermscode").getValue();
    if (paymenttermscode == 1) {
        return true;
    }
    return false;
}
//测试导入
function SalesOrderInfoImport() {
    var windowOptions = {};
    windowOptions.width = 800;//screen.width;
    windowOptions.height = 800;//screen.height;
    var data = {};
    Xrm.Navigation.openWebResource("new_/html/EntityImport.html", windowOptions, data);
}
//测试导入
function SalesOrderInfoImportRule() {
    return true;
}
