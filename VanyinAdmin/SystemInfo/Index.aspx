<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VanyinAdmin.SystemInfo.Index" %>

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
                        <a href="/SystemInfo/index.aspx">系统管理</a>
                        <span>></span>
                        <span>系统设置</span>
                    </div>


                    <ul class="operation boxsizing">
                        <li><a href="Edit.aspx">添加</a></li>

                    </ul>


                    <div class="listbody boxsizing">
                        <ul class="title">
                            <li style="width: 40px;">
                                <input type="checkbox" name="" id="" value="" /></li>

                            <li style="width: 250px;">配置名称</li>
                            <li style="width: 200px;">网站名称</li>
                            <li style="width: 200px;">网站地址</li>
                            <li style="width: 200px;">文件服务器</li>
                            <li style="width: 150px;">备案号</li>
                            <li style="width: 200px;">版权</li>
                            <li style="width: 300px;">关键字</li>
                            <li style="width: 400px;">描述</li>

                        </ul>
                        <asp:Repeater runat="server" ID="repList">
                            <ItemTemplate>
                                <ul>
                                    <li style="width: 40px;">
                                        <input type="checkbox" name="" id="" value="" /></li>
                                    <li style="width: 250px;"><%# Eval("Title") %>
                                        <asp:HiddenField runat="server" ID="lbId" Value='<%# Eval("Id") %>' />
                                    </li>

                                    <li style="width: 200px;">
                                        <%# Eval("WebName") %>
                                    </li>
                                    <li style="width: 200px;">
                                        <%# Eval("WebUrl") %>
                                    </li>
                                    <li style="width: 200px;">
                                        <%# Eval("FileServer") %>
                                    </li>                              
                                    <li style="width: 150px;">
                                        <%# Eval("WebICP") %>
                                    </li>                                   
                                    <li style="width: 200px;">
                                        <%# Eval("WebCopyright") %>
                                    </li>
                                    <li style="width: 300px;">
                                        <%# Eval("WebKey") %>
                                    </li>
                                    <li style="width: 400px;">
                                        <%# Eval("WebDescribe") %>
                                    </li>
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
                <!--左侧导航 Begin-->
            </div>

            <script src="/js/jquery-1.11.1.min.js" type="text/javascript" charset="utf-8"></script>
            <script src="/js/jquery.public.js" type="text/javascript" charset="utf-8"></script>
            <script src="/js/jquery.pagination.js"></script>
            <script type="text/javascript">
                $(function () {

                    SetLeftMenu("系统管理", "系统设置");
                    $(".page").pagination(<%= pcount %>, {
                        
                        prev_text: "上一页",
                        next_text: "下一页",
                        items_per_page:<%= pagesize%>,
                        num_display_entries:3,
                        current_page:<%= page%>,
                num_edge_entries:3,
                link_to:"?page=__id__"
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

