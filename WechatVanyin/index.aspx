﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatVanyin.index" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/css/index.css" />
    <link href="/css/swiper.min.css" rel="stylesheet" />
</head>

<body>

    <!--Banner Begin-->
    <div class="bannerbox">
        <%--<img src="img/index/indexbanner.jpg" />--%>

        <div class="swiper-container swiperbanner">
            <div class="swiper-wrapper">

                <asp:Repeater runat="server" ID="repIndexBanner">
                    <ItemTemplate>
                        <div class="swiper-slide">
                            <a <%# string.IsNullOrEmpty(Eval("LinkUrl").ToString())?"":"href='"+Eval("LinkUrl")+"'" %>>
                                <img src="<%# GetFileServer(10000)+ Eval("ImgUrl") %>" /></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
            <div class="pagination"></div>
        </div>


    </div>
    <!--Banner End-->
    <!--印刷类别 Begin-->
    <div class="printtype">
        <ul class="maintop">
            <li>
                <img src="img/index/printico.png" /></li>
            <li>
                <p>我要印刷</p>
            </li>
            <li>
                <a href="print.aspx">去印刷</a>
            </li>
        </ul>

        <div class="printlist">
            <asp:Repeater runat="server" ID="repTypeList">
                <ItemTemplate>
                    <a href="print.aspx?type=<%# Eval("Id") %>">
                        <img src="<%#GetFileServer(10000)+Eval("ImgUrl") %>" />
                        <p>印<%#Eval("Title") %></p>
                    </a>
                </ItemTemplate>
            </asp:Repeater>


            <a href="print.aspx">
                <p>
                    更多<br />
                    印刷
                </p>
            </a>
        </div>

    </div>
    <!--印刷类别 End-->
    <!--设计模版 Begin-->
    <div class="designbox">
        <ul class="maintop">
            <li>
                <img src="img/index/designico.png" /></li>
            <li>
                <p>我要设计</p>
            </li>
            <li>
                <a href="design.aspx">去设计</a>
            </li>
        </ul>

        <div class="designlist">
            <div class="designtem1">
                <a href="design.aspx?type=<%= modelTemplate[0].TypeId %>&temid=<%# modelTemplate[0].Id %>">
                    <img src="<%= GetFileServer(10000)+modelTemplate[0].IndexImg %>" />
                    <div class="name">
                        <p><%= modelTemplate[0].Title %></p>
                        <p><%= modelTemplate[0].Price %></p>
                    </div>
                </a>

            </div>
            <div class="designtem2">

                <div class="designtem2left">
                    <a href="design.aspx?type=<%= modelTemplate[1].TypeId %>&temid=<%# modelTemplate[1].Id %>">
                        <img src="<%= GetFileServer(10000)+modelTemplate[1].IndexImg %>" />
                        <div class="name">
                            <p><%= modelTemplate[1].Title %></p>
                            <p><%= modelTemplate[1].Price %></p>
                        </div>
                    </a>
                    <a href="design.aspx?type=<%= modelTemplate[2].TypeId %>&temid=<%# modelTemplate[2].Id %>">
                        <img src="<%= GetFileServer(10000)+modelTemplate[2].IndexImg %>" />
                        <div class="name">
                            <p><%= modelTemplate[2].Title %></p>
                            <p><%= modelTemplate[2].Price %></p>
                        </div>
                    </a>
                </div>
                <div class="designtem2right">
                    <a href="design.aspx?type=<%= modelTemplate[3].TypeId %>&temid=<%# modelTemplate[3].Id %>" class="rightbox">
                        <img src="<%= GetFileServer(10000)+modelTemplate[3].IndexImg %>" />
                        <p><%= modelTemplate[3].Title %></p>
                        <p><%= modelTemplate[3].Price %></p>
                    </a>

                </div>
            </div>
        </div>
    </div>
    <!--设计模版 End-->
    <!--印刷工艺 Begin-->
    <div class="technology">
        <asp:Repeater runat="server" ID="RepTechnology">
            <ItemTemplate>
                <a class="technologylist">
                    <span class="img">
                        <img src="<%# GetFileServer(10000)+Eval("ImgUrl") %>" /></span>
                    <p>
                        <span><%# Eval("Title") %></span>
                        <span></span>
                        <span><%# Eval("Describe") %></span>
                    </p>
                </a>
            </ItemTemplate>
        </asp:Repeater>


    </div>
    <!--印刷工艺 End-->
    <!--底部导航 Begin-->
    <uc1:Footer runat="server" ID="Footer" />
    <!--底部导航 End-->
    <script src="/js/swiper.min.js"></script>

    <script>
        var myBanner = new Swiper('.swiperbanner', {
            loop: true,
            autoplay: 3000,
            speed: 1000,
            pagination: ".pagination",
            autoplayDisableOnInteraction: false,
            paginationType: 'custom',
            paginationClickable: true,
        });
    </script>

</body>

</html>
