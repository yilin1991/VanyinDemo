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
                    <asp:DropDownList runat="server" ID="ddlTypelist" datatype="*" nullmsg="请选择印刷类别！" errormsg="请选择印刷类别！">
                        <asp:ListItem Value="">请选择印刷类别</asp:ListItem>
                    </asp:DropDownList>
				</div>
				<div class="input_group">
					<label class="input_lable">印刷数量</label>
                    <%--<asp:TextBox runat="server" ID="txtNum" CssClass="inputtext"  placeholder="请输入印刷数量" datatype="n" nullmsg="请输入印刷数量！" errormsg="印刷数量为整数！"></asp:TextBox>--%>
                    <input type="text" class="inputtext" name="txtNum" id="txtNum" placeholder="请输入印刷数量" datatype="n" nullmsg="请输入印刷数量！" errormsg="印刷数量为整数！" />

				</div>		
				<div class="input_group input_remark">
					<span class="input_span"><label class="input_lable">印刷要求</label></span>
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" CssClass="inputremark"></asp:TextBox>
				</div>
			</div>

			<div class="contact">
				<div class="contactform">
					<span><img src="img/ico/nameico.png"/></span>
					<span></span>
                    <asp:TextBox runat="server" ID="txtName" placeholder="请输入您的姓名" datatype="*" nullmsg="请输入您的姓名！" errormsg="请输入您的姓名！"></asp:TextBox>
				</div>
				<div class="contactform">
					<span><img src="img/ico/telico.png"/></span>
					<span></span>
                    <asp:TextBox runat="server" ID="txtPhone" placeholder="请输入您的手机号码" datatype="m" nullmsg="请输入您的手机号码！" errormsg="请输入正确的手机号码！"></asp:TextBox>
				</div>
				<div class="contactform">
					<span><img src="img/ico/emailico.png"/></span>
					<span></span>
                    <asp:TextBox runat="server" ID="txtEmail" placeholder="请输入您的邮箱" ignore="ignore" datatype="e" errormsg="请输入正确的邮箱！"></asp:TextBox>
				</div>
			</div>

		</div>
		<!--印刷 End-->

		<div class="printbtn">
            <input type="submit" id="btnOk" class="btnprint" value="核对无误，确认提交" />
            </div>
        </form>

        <script src="/js/jquery-1.11.1.min.js"></script>
        <script src="/js/weChatMsg.js"></script>
        <script src="/js/Validform_v5.3.2.js"></script>
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

                        wechatMsg("错误信息提示", data.num);

                    }

                });


            })
        </script>

	</body>

</html>
