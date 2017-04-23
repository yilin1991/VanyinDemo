﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VanyinAdmin.Member.Index" %>

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
    <link href="../css/pagination.css" rel="stylesheet" />
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
                        <a href="/Member/index.aspx">会员管理</a>
                        <span>></span>
                        <span>会员管理</span>
                    </div>
                    <ul class="searchbox boxsizing">
                        <li>
                            <p>
                                检索条件：<p>
                        </li>
                        <li>
                            <asp:DropDownList runat="server" ID="ddlType">
                                <asp:ListItem Value="0">请选择类别</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:DropDownList runat="server" ID="ddlState">
                                <asp:ListItem Value="0">请选择状态</asp:ListItem>
                                <asp:ListItem Value="1">启用</asp:ListItem>
                                <asp:ListItem Value="2">禁用</asp:ListItem>
                               
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:TextBox runat="server" ID="txtkey"></asp:TextBox>
                        </li>
                        <li>
                            <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
                        </li>
                        <li>
                            <asp:Button runat="server" ID="btnSelectAll" Text="显示全部" OnClick="btnSelectAll_Click" />
                        </li>
                    </ul>

                    <ul class="operation boxsizing">
                        <li><a href="Edit.aspx">添加</a></li>
                        <li><a href="#">删除</a></li>
                    </ul>


                    <div class="listbody boxsizing">
                        <ul class="title">
                            <li style="width: 40px;">
                                <input type="checkbox" name="" id="" value="" /></li>

                            <li style="width: 150px;">会员编号</li>
                            <li style="width: 250px;">帐号</li>
                            <li style="width: 100px;">所属类别</li>
                              <li style="width: 100px;">头像</li>
                            <li style="width: 100px;">昵称</li>
                            <li style="width: 150px;">手机号</li>
                            <li style="width: 150px;">邮箱</li>
                            <li style="width: 60px;">状态</li>
                            <li style="width: 100px;">是否绑定微信</li>
                            <li style="width: 150px;">注定时间</li>
                        </ul>
                        <asp:Repeater runat="server" ID="repList" OnItemCommand="repList_ItemCommand">
                            <ItemTemplate>
                                <ul>
                                    <li style="width: 40px;">
                                        <input type="checkbox" name="" id="" value="" /></li>
                                    <li style="width: 150px;"><%# Eval("NumId") %>
                                        <asp:HiddenField runat="server" ID="lbId" Value='<%# Eval("Id") %>' />
                                    </li>
                                    <li style="width: 250px;" class="headline">
                                        <a href="Edit.aspx?id=<%# Eval("Id")+strUrl.ToString()+"&page="+page %>"><%# Eval("Account") %></a></li>
                                    <li style="width: 100px;"><%# GetCategoryName(int.Parse(Eval("TypeId").ToString())) %></li>
                                    <li style="width: 100px;" class="img"><%# string.IsNullOrEmpty(Eval("HeaderImg").ToString())?"—":"<img src=\""+Eval("HeaderImg").ToString()+"\" />" %> </li>
                                     <li style="width: 100px;">
                                       <%# string.IsNullOrEmpty(Eval("Nickname").ToString())?"—":Eval("Nickname") %>
                                    </li>
                                     <li style="width: 150px;">
                                       <%# Eval("Phone") %>
                                    </li>
                                     <li style="width: 150px;">
                                       <%# string.IsNullOrEmpty(Eval("Email").ToString())?"—":Eval("Email") %>
                                    </li>
                                    <li style="width: 60px;" class="state">
                                        <asp:LinkButton runat="server" CommandName="lbtnState" ID="lbtnState"><i class="<%# Vanyin.Common.Utils.GetStateClass(int.Parse(Eval("StateInfo").ToString()))  %>"></i></asp:LinkButton></a></li>
                                 
                                   
                                    <li style="width: 100px;">
                                       <%# string.IsNullOrEmpty(Eval("OpenId").ToString())?"未绑定":"已绑定" %>
                                    </li>
                                    <li style="width: 150px;"><%# Vanyin.Common.Utils.GetDate(Eval("AddTime").ToString())  %></li>

                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="pagelistbody boxsizing">
                        <div class="pagebox">
                            <div class="page flickr">
                            </div>
                        </div>
                        <div class="pagemsg">
                            <p>共<span><%= pcount %></span>条数据，共<span><%=Math.Ceiling(decimal.Parse(pcount.ToString())/pagesize) %></span>页，当前第<span><%= page+1 %></span>页</p>
                        </div>

                    </div>

                </div>
                <!--正文 End-->
                <!--左侧导航 Begin-->
                <uc1:Left runat="server" ID="Left" />
                <!--左侧导航 Begin-->u
            </div>

            <script src="/js/jquery-1.11.1.min.js" type="text/javascript" charset="utf-8"></script>
            <script src="/js/jquery.public.js" type="text/javascript" charset="utf-8"></script>
            <script src="/js/jquery.pagination.js"></script>
            <script type="text/javascript">
                $(function () {

                    SetLeftMenu("会员管理", "会员管理");
                    $(".page").pagination(<%= pcount %>, {
                        
                        prev_text: "上一页",
                        next_text: "下一页",
                        items_per_page:<%= pagesize%>,
                num_display_entries:3,
                current_page:<%= page%>,
                num_edge_entries:3,
                link_to:"?page=__id__<%= strUrl.ToString()%>"
                     });
                    $("#ckAll").click(function(){               
                        var check= $(this).prop("checked");
                        $("input[type=checkbox]").each(function(){
                            $(this).prop("checked",check);
                        })              
                    })
                })
            </script>

        </div>
    </form>
</body>

</html>


