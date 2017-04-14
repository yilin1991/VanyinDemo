<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" CodeBehind="Edit.aspx.cs" Inherits="VanyinAdmin.MallProduct.Edit" %>

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
                        <a href="/MallProduct/index.aspx">兑换商品</a>
                        <span>></span>
                        <span>兑换商品管理</span>
                    </div>

                    <div class="edittop boxsizing">
                        <ul>
                            <li class="boxsizing">
                                <p>基本信息</p>
                            </li>
                            <li><a href="/MallProduct/index.aspx">返回列表</a></li>
                        </ul>
                    </div>

                    <div class="editbody boxsizing">
                        <div class="edit_group">
                            <label class="label_title">商品名称</label>

                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtTitle" CssClass="inputtext400" datatype="*" nullmsg="请输入商品名称！" errormsg="商品名称不能为空！"></asp:TextBox>
                                <span class="formmsg">请输入商品名称</span>
                            </div>

                        </div>

                        <div class="edit_group">
                            <label class="label_title">所属类别</label>

                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlType" CssClass="inputtext200" datatype="*" nullmsg="请选择所属类别！" errormsg="请选择所属类别！">
                                    <asp:ListItem Value="">请选择所属类别</asp:ListItem>
                                </asp:DropDownList>
                                <span class="formmsg">请选择所属类别</span>
                            </div>
                        </div>

                        <div class="edit_group">
                            <label class="label_title">所需积分</label>

                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtIntegral" CssClass="inputtext400"  Text="100" datatype="n" nullmsg="所需积分不能为空！" errormsg="积分为大于0的正整数！"></asp:TextBox>
                                <span class="formmsg">请输入所需积分</span>
                            </div>

                        </div>
                        <div class="edit_group">
                            <label class="label_title">实际价格</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="inputtext400" Text="5,000 RMB" datatype="*" nullmsg="请输入商品实际价格！" errormsg="商品实际价格不能为空！"></asp:TextBox>
                                <span class="formmsg">请输入商品实际价格</span>
                            </div>

                        </div>
                        <div class="edit_group">
                            <label class="label_title">商品库存</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtStock" CssClass="inputtext400" Text="100" datatype="n" nullmsg="请输入商品库存数量！" errormsg="商品库存数量为大于0的正整数！"></asp:TextBox>
                                <span class="formmsg">请输入商品库存数量</span>
                            </div>

                        </div>
                        <div class="edit_group">
                            <label class="label_title">商品图片</label>

                            <div class="controls ">
                                <ul class="filebox">
                                    <li class="txtfilename">
                                        <asp:TextBox runat="server" ID="txtImg" ReadOnly="false" CssClass="inputWidth2 inputtext400 "></asp:TextBox></li>
                                    <li class="btnfilea"><a href="javascript:void(0)" onclick="btnfileaclick($(this))" class="btnfilebtn">上传图片</a></li>
                                    <li class="fileinput">
                                        <input type="file" name="fileuploadico" id="fileuploadico" onchange="fileonchange($(this),'myfrom')" /></li>
                                </ul>
                            </div>
                        </div>
                        <div class="edit_group">
                            <label class="label_title">商品详情</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtMallDetail" TextMode="MultiLine" Height="500" CssClass="inputtext800" ></asp:TextBox>
                            </div>
                        </div>

                       
                         <div class="edit_group">
                            <label class="label_title">排序</label>

                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtSortNum" Text="1000" datatype="n" nullmsg="请输入顺序,数字越小越靠前！" errormsg="请输入正确的顺序（整数）！" CssClass="inputtext100"></asp:TextBox>
                                <span class="formmsg">请输入排序，类别按找正序排列</span>
                            </div>

                        </div>
                       
                        <div class="edit_group">
                            <label class="label_title">商品状态</label>

                            <div class="controls">
                                <label class="checbox">
                                    <asp:CheckBox runat="server" ID="ckState" Checked="true" />
                                    <span>上架</span></label>
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

                    SetLeftMenu("兑换商品", "添加商品");


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

