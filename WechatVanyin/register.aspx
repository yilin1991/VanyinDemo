<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WechatVanyin.register" %>


<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/login.css" />
    <link href="css/weChatStyle.css" rel="stylesheet" />
</head>

<body>
    <form id="myForm" runat="server" method="post" action="/Tools/Register.ashx" enctype="multipart/form-data">
        <!--登录窗口 Begin-->
        <div class="loginbox">
            <p class="title">注册</p>

            <div class="input_group">
                <div class="inputico">
                    <img src="img/login/phoneico.png" />
                </div>
                <span class="inputline"></span>
                <input type="text" name="txtAccount" class="inputtext" id="txtAccount" placeholder="手机号" ajaxurl="/Tools/CheckPhone.ashx" datatype="m" nullmsg="请输入手机号！" errormsg="请输入正确的手机号码 ！" />
            </div>
           <%-- <div class="input_group">
				<div class="inputico">
					<img src="img/login/phoneico.png" />
				</div>
				<span class="inputline"></span>
				<input type="text" name="txtname" class="inputyzm" id="txtname" placeholder="请输入手机号" />
				<a class="bthyzm">获取验证码</a>
			</div>--%>
            <div class="input_group">
                <div class="inputico">
                    <img src="img/login/phoneico.png" />
                </div>
                <span class="inputline"></span>
                <input type="password" name="txtPassword" class="inputtext" id="txtPassword" placeholder="请输入密码" datatype="password" nullmsg="密码不能为空！" errormsg="请输入正确的密码，密码最少包含字母、数字和特殊符号中的两种6-16字符！" />
            </div>
            <div class="input_group">
                <div class="inputico">
                    <img src="img/login/phoneico.png" />
                </div>
                <span class="inputline"></span>
                <input type="password" name="txtRePassword" class="inputtext" id="txtRePassword" placeholder="请确认您的密码" datatype="*" recheck="txtPassword" nullmsg="请确认您的密码！" errormsg="两次密码输入不一致！" />
            </div>

            <input type="submit" id="btnLogin" class="btnsubmit" value="注册" />
            <div class="registerbtn">
                <a href="login.aspx">已有帐号？去登录</a>
            </div>
        </div>
        <!--登录窗口 End-->

        <!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />
        <!--底部导航 End-->
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
                    datatype: {
                       
                        "password": /^((?=.*[a-z])(?=.*\d)|(?=[a-z])(?=.*[#@!~%^&*])|(?=.*\d)(?=.*[#@!~%^&*]))[a-z\d#@!~%^&*]{6,16}$/

                    },
                    callback: function (data) {
                        if (data.state == "error") {
                            wechatMsg("注册提示信息", data.msg);
                        }
                        else {                         
                            if (data.backurl != "") {
                                location.href = data.backurl;
                            }
                            else {
                                location.href = "personal-home.aspx";
                            }
                        }
                    }

                });


            })
        </script>
    </form>
</body>

</html>

