<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="VanyinAdmin.Controls.Header" %>
<div class="pageheader boxsizing">
    <a href="#" class="logo">
        <img src="/img/header/headerlogo.png" /></a>

    <ul class="toolbox">
        <li class="msgbox">
            <a href="#"><i class="icon-bell-alt"></i><span>12</span></a>
        </li>
        <li class="msgbox">
            <a href="#"><i class="icon-envelope"></i><span>12</span></a>
        </li>
        <li class="msgbox">
            <a href="#"><i class="icon-user"></i><span>12</span></a>
        </li>
        <li class="userbox">
            <a class="usermsg">
                <img src="/img/header/user.jpg" />
                <span><small>欢迎您：</small>admin</span>
                <i class="icon-caret-down"></i>
            </a>
            <ul class="usersetbox boxsizing">
                <li>
                    <a href="#"><i class="icon-cog"></i><span>修改密码</span></a>
                </li>
                <li>
                    <a href="#"><i class="icon-user"></i><span>个人资料</span></a>
                </li>
                <li>
                    <a href="#"><i class="icon-off"></i><span>退出登录</span></a>
                </li>
            </ul>

        </li>

    </ul>

</div>
