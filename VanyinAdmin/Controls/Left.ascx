﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="VanyinAdmin.Controls.Left" %>
<div class="pageleft boxsizing">

    <div class="lefttop">
        <img src="/img/left/leftico.png" /><span>控制台</span>
    </div>

    <div class="leftlistbox">
        <ul class="leftlist">
            <li class="title">
                <a href="Index.aspx"><span><i class=" icon-home"></i></span><span>首页</span></a>
            </li>
        </ul>
        <ul class="leftlist">
            <li class="title">
                <a><span><i class=" icon-inbox"></i></span><span>类别管理</span></a>
            </li>
            <li class="leftlink">
                <a href="/Category/index.aspx" draggable="false"><span></span><i class=" icon-caret-right"></i><span>类别管理</span></a>
            </li>
        </ul>
        <ul class="leftlist">
            <li class="title">
                <a  draggable="false"><span><i class=" icon-inbox"></i></span><span>设计模版</span></a>
            </li>
            <li class="leftlink">
                <a href="/Template/index.aspx" draggable="false"><span></span><i class=" icon-caret-right"></i><span>模版管理</span></a>
                <a href="/Template/Edit.aspx" draggable="false"><span></span><i class=" icon-caret-right"></i><span>添加模版</span></a>
            </li>
        </ul>
    </div>

</div>
