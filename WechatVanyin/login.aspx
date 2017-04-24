<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WechatVanyin.login" %>

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
    <form id="myForm" runat="server" method="post" action="/Tools/Login.ashx" enctype="multipart/form-data">
        <!--登录窗口 Begin-->
        <div class="loginbox">
            <p class="title">登录</p>

            <div class="input_group">
                <div class="inputico">
                    <img src="img/login/phoneico.png" />
                </div>
                <span class="inputline"></span>
                <input type="text" name="txtAccount" class="inputtext" id="txtAccount" placeholder="用户名/手机号" datatype="*" nullmsg="请输入用户名或手机号！" errormsg="帐号不能为空！" />
            </div>
            <div class="input_group">
                <div class="inputico">
                    <img src="img/login/phoneico.png" />
                </div>
                <span class="inputline"></span>
                <input type="password" name="txtPassword" class="inputtext" id="txtPassword" placeholder="请输入密码" datatype="*" nullmsg="请输入用户名或手机号！" errormsg="密码不能为空！" />
            </div>
            <%--<div class="input_group">
				<div class="inputico">
					<img src="img/login/phoneico.png" />
				</div>
				<span class="inputline"></span>
				<input type="text" name="txtname" class="inputyzm" id="txtname" placeholder="请输入手机号" />
				<a class="bthyzm">获取验证码</a>
			</div>--%>

            <input type="submit" id="btnLogin" class="btnsubmit" value="登录" />
            <div class="registerbtn">
                <a href="register.aspx">免费注册</a>
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
                $(".loginbox").css("margin-top", ($(window).height() - $(".loginbox").height()-60) / 2 + "px");


                $("#myForm").Validform({
                    ajaxPost: true,
                    tiptype: function (msg, o, cssctl) {

                        if (o.type == 3) {
                            wechatMsg("错误信息提示", msg);
                        }
                    },
                    postonce: true,

                    callback: function (data) {
                        if (data.state == "error") {
                            wechatMsg("登录提示信息", data.msg);
                        }
                        else {
                            wechatMsg("登录提示信息", "登录成功");
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
