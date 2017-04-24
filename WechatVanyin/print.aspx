<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="WechatVanyin.print" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/print.css" />
    <link href="/css/weChatStyle.css" rel="stylesheet" />
</head>

<body>
    <form id="myForm" runat="server" method="post" action="/Tools/AddPrintOrder.ashx" enctype="multipart/form-data">


        <!--印刷 Begin-->
        <div class="print">
            <div class="printtop">
                <img src="img/footer/footerico3.png" />
                <p>我要印刷</p>
            </div>

            <div class="printform">
                <div class="input_group">
                    <label class="input_lable">印刷类别</label>
                    <select id="ddlTypelist" name="ddlTypelist" onchange="typechange()">
                        <option value="">请选择印刷类别</option>
                        <asp:Repeater runat="server" ID="RepList">
                            <ItemTemplate>
                                <option value="<%# Eval("Id") %>"><%# Eval("Title") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>


                </div>
                <div class="input_group">
                    <label class="input_lable">印刷数量</label>
                    <input type="text" class="inputtext inputprintnum" name="txtNum" id="txtNum" placeholder="请输入印刷数量" datatype="*" nullmsg="请输入印刷数量！" errormsg="印刷数量为整数！" /><span class="unit"></span>
                </div>
                <div class="input_group input_remark">
                    <span class="input_span">
                        <label class="input_lable">印刷要求</label></span>
                    <textarea name="txtRemark" id="txtRemark" class="inputremark"></textarea>
                </div>

                <div class="contact">
                    <div class="contactform">
                        <span>
                            <img src="img/ico/nameico.png" /></span>
                        <span></span>
                        <input type="text" id="txtName" name="txtName" placeholder="请输入您的姓名" datatype="*" nullmsg="请输入您的姓名！" errormsg="请输入您的姓名！" />
                    </div>
                    <div class="contactform">
                        <span>
                            <img src="img/ico/telico.png" /></span>
                        <span></span>
                        <input type="tel" id="txtPhone" name="txtPhone" placeholder="请输入您的手机号码" datatype="m" nullmsg="请输入您的手机号码！" errormsg="请输入正确的手机号码！" />
                    </div>
                    <div class="contactform">
                        <span>
                            <img src="img/ico/emailico.png" /></span>
                        <span></span>

                        <input type="email" id="txtEmail" name="txtEmail" placeholder="请输入您的邮箱" ignore="ignore" datatype="e" errormsg="请输入正确的邮箱！" />
                    </div>
                </div>

            </div>
        </div>
        <!--印刷 End-->

        <div class="printbtn">
            <input type="submit" id="btnOk" class="btnprint" value="核对无误，确认提交" />
        </div>
    </form>

    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="/js/weChatMsg.js"></script>
    <script src="/js/Validform_v5.3.2.js"></script>
    <script src="js/urlParams.js"></script>
    <script>
        $(function () {
            $("#myForm").Validform({
                ajaxPost: true,
                tiptype: function (msg, o, cssctl) {

                    if (o.type == 3) {
                        wechatMsg("错误信息提示", msg);
                    }
                },
                postonce: true,

                callback: function (data) {
                    if (data.state == "success") {
                        $("#txtNum").val("");
                        $("#txtRemark").val("");
                        $("#txtName").val("");
                        $("#txtPhone").val("");
                        $("#txtEmail").val("");
                        
                        location.href = "OrderSuccess.aspx?orderid=" + data.orderId + "&type=print";
                    }
                    else {
                        wechatMsg("订单消息", data.msg);
                    }

                }

            });


            if ($.request.queryString["type"]!="")
            {
                $("#ddlTypelist").val($.request.queryString["type"]);
            }


            

        })


        function typechange() {

            $.ajax({
                type: "POST",//传输类型get/post
                url: "/Tools/GetPrintTypeUnit.ashx",//请求路径
                data: { id: $("#ddlTypelist").val() },
                dataType: "json",//返回格式有json
                success: function (data) { //成功返时返回回来的data数据

                    $(".unit").text(data.unit);
                    
                },
                error: function (err) {//错误是弹出报错框
                    //alert("shibai");
                }
            })
        }


    </script>

</body>

</html>
