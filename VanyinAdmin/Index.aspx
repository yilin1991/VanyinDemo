<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VanyinAdmin.Index" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Left.ascx" TagPrefix="uc1" TagName="Left" %>



<!DOCTYPE html>
<html>

<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9,chrome=1">
    <meta charset="utf-8" />
    <title>领意品牌网站后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" href="/css/font-awesome.min.css">
    <!--[if IE 7]>
		<link rel="stylesheet" href="css/font-awesome-ie7.min.css">
		<![endif]-->
</head>

<body>

    <div class="pagebody">

        <%-- 头部 Begin --%>
        <uc1:Header runat="server" ID="Header" />
        <%-- 头部 End --%>
        <div class="pagecontent boxsizing">
            <!--正文 Begin-->
            <div class="pagemain boxsizing">
                <div class="maptop">
                    <span>位置：</span>
                    <a href="index.aspx">首页</a>
                </div>
                <div class="contentBox">

                    <div class="indexUser">
                        <ul>
                            <li>
                                <img src="/img/sun.png" /></li>
                            <li>admin</li>
                            <li>早上好</li>
                            <li>，欢迎使用后台管理系统</li>
                            <li>（admin@leaderee.com）</li>
                            <li><a href="#">帐号设置</a></li>
                        </ul>
                    </div>

                    <div class="loginTime">
                        <ul>
                            <li>
                                <img src="/img/time.png" /></li>
                            <li>您上次登录的时间：</li>
                            <li>2013-10-09 15:22</li>
                            <li>（不是您登录的？</li>
                            <li><a href="#">请点这里</a></li>
                            <li>）</li>
                        </ul>
                    </div>

                    <div class="indexLine">
                    </div>

                </div>


            </div>
            <!--正文 End-->
            <!--左侧导航 Begin-->
            <uc1:Left runat="server" ID="Left" />
            <!--左侧导航 Begin-->
        </div>

        <script src="/js/jquery-1.11.1.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="/js/jquery.public.js" type="text/javascript" charset="utf-8"></script>
        <script type="text/javascript">
            $(function () {

                SetLeftMenu("首页", "");

            })
        </script>

    </div>

</body>

</html>
