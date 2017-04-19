<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="design.aspx.cs" Inherits="WechatVanyin.design" %>

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
    <form id="myForm" runat="server" method="post" action="/Tools/AddDesignOrder.ashx" enctype="multipart/form-data">
        <!--印刷 Begin-->
        <div class="print">

            <div class="printtop">
                <img src="img/footer/footerico2.png" />
                <p class="designtopp">我要设计</p>
            </div>

            <div class="printform">
                <div class="input_group">
                    <label class="input_lable">设计类别</label>
                    <select id="ddlType" name="ddlType" onchange="change()" datatype="*" nullmsg="请选择设计类别！" errormsg="请选择设计类别！">
                        <option value="">请选择设计类别</option>
                        <asp:Repeater runat="server" ID="RepDesignType">
                            <ItemTemplate>
                                <option value="<%# Eval("Id") %>"><%#Eval("Title") %></option>
                            </ItemTemplate>
                        </asp:Repeater>

                    </select>
                </div>
                <div class="input_group designdemo">
                    <a class="selectTem"><span>请选择设计模板</span><span></span></a>
                    <input type="hidden" name="hidTemId" id="hidTemId" value="" datatype="*" nullmsg="请选择设计模板！" errormsg="请选择设计模板！" />
                </div>
                <%--<div class="input_group">
					<label class="input_lable">印刷数量</label>
					<input type="text" name="txtnum" class="inputtext" id="txtnum" value="" placeholder="请输入您的印刷数量" />
				</div>--%>

                <div class="input_group input_remark">
                    <span class="input_span">
                        <label class="input_lable">设计要求</label></span>
                    <textarea name="txtremark" id="txtremark" class="inputremark"></textarea>
                </div>
            </div>


            <div class="printdemand">
                <div class="demandtext">
                    <p>是否需要印刷</p>
                </div>

                <div class="demandbtn">
                    <input class='tgl tgl-light' id='ckprint' name="ckprint" type='checkbox'>
                    <label class='tgl-btn' for='ckprint'></label>
                </div>

            </div>


            <div class="contact">
                <div class="contactform">
                    <span>
                        <img src="img/ico/nameico.png" /></span>
                    <span></span>
                    <input type="text" name="txtname" id="txtname" value="" placeholder="请输入您的姓名" datatype="*" nullmsg="请输入您的姓名！" errormsg="请输入您的姓名！" />
                </div>
                <div class="contactform">
                    <span>
                        <img src="img/ico/telico.png" /></span>
                    <span></span>
                    <input type="tel" name="txttel" id="txttel" value="" placeholder="请输入您的手机号码" datatype="m" nullmsg="请输入您的手机号码！" errormsg="请输入正确的手机号码！" />
                </div>
                <div class="contactform">
                    <span>
                        <img src="img/ico/emailico.png" /></span>
                    <span></span>
                    <input type="email" name="txtemail" id="txtemail" value="" placeholder="请输入您的邮箱" ignore="ignore" datatype="e" errormsg="请输入正确的邮箱！" />
                </div>
            </div>

        </div>
        <!--印刷 End-->

        <div class="printbtn">
            <input type="submit" id="btnPrint" class="btnprint" name="" value="核对无误，确认提交" />
        </div>

        <script src="../js/jquery-1.11.1.min.js"></script>
        <script src="/js/weChatMsg.js"></script>
        <script src="/js/Validform_v5.3.2.js"></script>

        <script src="../js/urlParams.js"></script>
        <script>
            $(function () {

                if ($.request.queryString["type"] != "")
                {
                    $("#ddlType").val($.request.queryString["type"]);
                }
                if ($.request.queryString["print"] != "") {
                    $("#ckprint").prop("checked", function () {
                        if ($.request.queryString["print"] == "true") {
                            return true;
                        }
                        else {
                            return false;
                        }

                    });

                }
                if ($.request.queryString["remark"] != "") {
                    $("#txtremark").val($.request.queryString["remark"]);
                }
                if ($.request.queryString["name"] != "") {
                    $("#txtname").val($.request.queryString["name"]);
                }
                if ($.request.queryString["phone"] != "") {
                    $("#txttel").val($.request.queryString["phone"]);
                }
                if ($.request.queryString["email"] != "") {
                    $("#txtemail").val($.request.queryString["email"]);
                }
                if ($.request.queryString["temid"] != "") {
                    $("#hidTemId").val($.request.queryString["temid"]);
                    $.ajax({
                        type: "POST",
                        url: "/Tools/GetTemplateDetail.ashx",
                        data: { temId: $.request.queryString["temid"] },
                        dataType: "json",
                        success: function (data) {

                            $(".selectTem span").eq(0).text(data.title);

                        }
                    });
                }

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


                            location.href = "OrderSuccess.aspx?orderid=" + data.orderId + "&type=design";
                        }
                        else {
                            wechatMsg("订单消息", data.msg);
                        }

                    }

                });

                $(".selectTem").click(function () {

                    if ($("#ddlType").val() == "" || $("#ddlType").val() == null) {
                        wechatMsg("提示消息", "请先选择类别");
                    }
                    else {
                        
                        var strHref = "design-template.aspx?type=" + $("#ddlType").val() + "&print=" + $("#ckprint").is(":checked");
                        if ($("#txtremark").val() != "")
                        {
                            strHref += "&remark=" + $("#txtremark").val();
                        }
                        if ($("#txtname").val() != "") {
                            strHref += "&name=" + $("#txtname").val();
                        }
                        if ($("#txttel").val() != "") {
                            strHref += "&phone=" + $("#txttel").val();
                        }
                        if ($("#txtemail").val() != "") {
                            strHref += "&email=" + $("#txtemail").val();
                        }


                        location.href = strHref;
                    }
                })


            })

            function change() {

            }


        </script>
    </form>
</body>

</html>
