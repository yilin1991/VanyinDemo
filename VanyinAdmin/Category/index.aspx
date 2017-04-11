<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="VanyinAdmin.Category.index" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Left.ascx" TagPrefix="uc1" TagName="Left" %>



<!DOCTYPE html>
<html>

<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9,chrome=1">
    <meta charset="utf-8" />
    <title>领意品牌网站后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link href="../css/list.css" rel="stylesheet" />
    <link rel="stylesheet" href="/css/font-awesome.min.css">
    <!--[if IE 7]>
		<link rel="stylesheet" href="css/font-awesome-ie7.min.css">
		<![endif]-->
</head>

<body>
    <form runat="server" style="height: 100%;">
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
                        <span>></span>
                        <a href="/Category/index.aspx">类别管理</a>
                    </div>
                    <ul class="searchbox boxsizing">
                        <li>
                            <p>
                                检索条件：<p>
                        </li>
                        <li>
                            <select name="">
                                <option value="">选择类别</option>
                            </select></li>
                        <li>
                            <select name="">
                                <option value="">选择类别</option>
                            </select></li>
                        <li>
                            <input type="text" name="" id="" value="" placeholder="关键字" /></li>
                        <li>
                            <input type="text" name="" id="" value="" placeholder="开始时间" /></li>
                        <li>
                            <input type="text" name="" id="" value="" placeholder="关键字" /></li>
                        <li>
                            <input type="button" name="" id="" value="搜索" /></li>
                        <li>
                            <input type="button" name="" id="" value="显示全部" /></li>
                        <li>
                            <input type="button" name="" id="" value="导出" /></li>
                    </ul>

                    <ul class="operation boxsizing">
                        <li><a href="#">添加</a></li>
                        <li><a href="#">删除</a></li>
                    </ul>


                    <div class="listbody boxsizing">
                        <ul class="title">
                            <li style="width: 40px;">
                                <input type="checkbox" name="" id="" value="" /></li>

                            <li style="width: 150px; padding: 10px 20px;">标题</li>
                            <li style="width: 200px;">副标题</li>
                            <li style="width: 100px;">编号</li>
                            <li style="width: 100px;">状态</li>
                            <li style="width: 100px;">排序</li>
                            <li style="width: 100px;">类别图片</li>
                            <li style="width: 100px;">默认图片</li>
                            <li style="width: 80px;">操作</li>
                        </ul>
                        <asp:Repeater runat="server" ID="repList" OnItemDataBound="repList_ItemDataBound">
                            <ItemTemplate>
                                <ul>
                                    <li style="width: 40px;">
                                        <input type="checkbox" name="" id="" value="" /></li>
                                    <li style="width: 150px;" class="headline textleft">
                                         <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                                         <asp:HiddenField ID="txtClassLayer" runat="server" Value='<%#Eval("LevelNum") %>' />
                                        <a href="#"><%# namenull+ Eval("Title") %></a></li>
                                    <li style="width: 200px;"><%#Eval("SubTitle") %></li>
                                    <li style="width: 100px;"><%# Eval("Id") %></li>
                                    <li style="width: 100px;" class="state"><a href="#"><i class="icon-warning-sign"></i></a></li>
                                    <li style="width: 100px;"><%# Eval("SortNum") %></li>
                                    <li style="width: 100px;" class="img">
                                        <img src="../img/typography.jpg" /></li>
                                    <li style="width: 100px;" class="img">
                                        <img src="../img/typography.jpg" /></li>
                                    <li style="width: 80px;"><a href="#">添加子类别</a></li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>

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

                    SetLeftMenu("类别管理", "类别管理");

                })
            </script>

        </div>
    </form>
</body>

</html>
