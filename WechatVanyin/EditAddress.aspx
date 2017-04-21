<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAddress.aspx.cs" Inherits="WechatVanyin.EditAddress" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/address.css" />
    <link href="css/weChatStyle.css" rel="stylesheet" />
</head>

<body>

    <div class="editaddress">

        <div class="addresstop">
            <p>编辑收货地址</p>
        </div>

        <div class="addressform">

            <div class="input-group input-width1">
                <input type="text" name="txtName" id="txtName" placeholder="收货人姓名" />
            </div>
            <div class="input-group input-width1">
                <input type="text" name="txtPhone" id="txtPhone" placeholder="联系人手机" />
            </div>
            <div class="input-group input-width2">
                <select>
                    <option value="">请选择省份</option>
                </select>
            </div>
            <div class="input-group input-width2" style="float: right;">
                <select>
                    <option value="">请选择城市</option>
                </select>
            </div>

            <div class="input-group input-width1">
                <select>
                    <option value="">请选择区县</option>
                </select>
            </div>
            <div class="input-group input-width1">
                <input type="text" name="txtName" id="txtAddress" placeholder="详细地址" />
            </div>
            <div class="defaultaddress">
                <div class="demandtext">
                    <p>默认地址</p>
                </div>

                <div class="demandbtn">
                    <input class='tgl tgl-light' id='ckprint' name="ckprint" type='checkbox'>
                    <label class='tgl-btn' for='ckprint'></label>
                </div>
            </div>
        </div>



    </div>

    <div class="printbtn">
        <input type="submit" id="btnPrint" class="btnprint" name="" value="确认保存" />
    </div>
</body>

</html>

