<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Edit.aspx.cs" Inherits="VanyinAdmin.SystemInfo.Edit" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Left.ascx" TagPrefix="uc1" TagName="Left" %>

<!DOCTYPE html>
<html>

<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9,chrome=1">
    <meta charset="utf-8" />
    <title>领意品牌网站后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link href="/css/edit.css" rel="stylesheet" />
    <link rel="stylesheet" href="/css/font-awesome.min.css">
    <link href="/css/message.css" rel="stylesheet" />
    <!--[if IE 7]>
		<link rel="stylesheet" href="css/font-awesome-ie7.min.css">
		<![endif]-->
    <script src="/js/jquery-1.11.1.min.js"></script>
    <script src="/js/jquery.message.js"></script>
</head>

<body>
    <form runat="server" id="myfrom" class="form-horizontal" style="height: 100%;">
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
                        <a href="/SystemInfo/index.aspx">系统设置</a>
                        <span>></span>
                        <span>系统设置</span>
                    </div>

                    <div class="edittop boxsizing">
                        <ul>
                            <li class="boxsizing">
                                <p>基本信息</p>
                            </li>
                            <li><a href="/SystemInfo/index.aspx">返回列表</a></li>
                        </ul>
                    </div>

                    <div class="editbody boxsizing">
                        <div class="edit_group">
                            <label class="label_title">名称</label>

                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtTitle" CssClass="inputtext400"></asp:TextBox>
                            </div>

                        </div>

                        <div class="edit_group">
                            <label class="label_title">网站名称</label>

                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtWebName" CssClass="inputtext400"></asp:TextBox>
                            </div>

                        </div>
                        <div class="edit_group">
                            <label class="label_title">网址</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtWebUrl" CssClass="inputtext400"></asp:TextBox>
                            </div>

                        </div>
                        <div class="edit_group">
                            <label class="label_title">文件服务器</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtFileServer" CssClass="inputtext400"></asp:TextBox>
                            </div>

                        </div>

                        <div class="edit_group">
                            <label class="label_title">关键字</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtWebtKey" TextMode="MultiLine" CssClass="inputtext500" Height="100"></asp:TextBox>
                            </div>
                        </div>

                        <div class="edit_group">
                            <label class="label_title">描述</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtWebDescribe" TextMode="MultiLine" CssClass="inputtext500" Height="100"></asp:TextBox>
                            </div>
                        </div>

                        <div class="edit_group">
                            <label class="label_title">备案号</label>

                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtIcp" CssClass="inputtext400"></asp:TextBox>
                            </div>

                        </div>
                        <div class="edit_group">
                            <label class="label_title">版权</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtCopyright" CssClass="inputtext400"></asp:TextBox>
                            </div>

                        </div>


                        <div class="editbtn">
                            <asp:Button runat="server" ID="btnOk" Text="确认提交" OnClick="btnOk_Click" />
                        </div>

                    </div>


                </div>
                <!--正文 End-->
                <!--左侧导航 Begin-->
                <uc1:Left runat="server" ID="Left" />
                <!--左侧导航 Begin-->
            </div>

            <%--<script src="/js/jquery-1.11.1.min.js" type="text/javascript" charset="utf-8"></script>--%>
            <script src="/js/jquery.public.js" type="text/javascript" charset="utf-8"></script>
            <script src="/js/Validform_v5.3.2.js"></script>
            <script src="/js/jquery.form.min.js"></script>
            <script src="/js/jquery.leadinupload.js"></script>
            <script src="/kindeditor-4.1.10/kindeditor.js"></script>
            <script src="/kindeditor-4.1.10/lang/zh_CN.js"></script>


            <script type="text/javascript">
                $(function () {

                    $(".form-horizontal").Validform({
                        tiptype: function (msg, o, cssctl) {
                            //msg：提示信息;
                            //o:{obj:*,type:*,curform:*}, obj指向的是当前验证的表单元素（或表单对象），type指示提示的状态，值为1、2、3、4， 1：正在检测/提交数据，2：通过验证，3：验证失败，4：提示ignore状态, curform为当前form对象;
                            //cssctl:内置的提示信息样式控制函数，该函数需传入两个参数：显示提示信息的对象 和 当前提示的状态（既形参o中的type）;
                            if (!o.obj.is("form")) {//验证表单元素时o.obj为该表单元素，全部验证通过提交表单时o.obj为该表单对象;
                                var objtip = o.obj.siblings(".formmsg");
                                if (o.type == 2) {

                                    objtip.removeClass("error").addClass("success");
                                }
                                else if (o.type == 3) {
                                    objtip.removeClass("success").addClass("error");
                                }
                                cssctl(objtip, o.type);
                                objtip.text(msg);
                            }
                        }


                    });

                    SetLeftMenu("系统设置", "添加配置");


                    KindEditor.ready(function (K) {
                        var editor1 = K.create('#txtMallDetail', {
                            cssPath: '/kindeditor-4.1.10/plugins/code/prettify.css',
                            uploadJson: '/Tools/upload_json.ashx',
                            fileManagerJson: '/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                            allowFileManager: true
                        });
                    });

                })
            </script>

        </div>
    </form>
</body>

</html>


