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
      <form id="myForm" runat="server" method="post" action="/Tools/EditAddress.ashx" enctype="multipart/form-data">
        <div class="editaddress">

            <div class="addresstop">
                <p>编辑收货地址</p>
            </div>

            <div class="addressform">

                <div class="input-group input-width1">
                    <input type="text" name="txtName" id="txtName" placeholder="收货人姓名" datatype="*" nullmsg="请输入收货人姓名！" errormsg="请输入收货人姓名！"/>
                </div>
                <div class="input-group input-width1">
                    <input type="text" name="txtPhone" id="txtPhone" placeholder="联系人手机" datatype="m" nullmsg="请输入联系人手机号！" errormsg="请输入正确的手机号码！"/>
                </div>
                <div class="input-group input-width2">
                    <select id="ddlProvince" name="ddlProvince" onchange="ProvinceChange()">
                        <option value="">请选择省份</option>
                        <asp:Repeater runat="server" ID="RepProvince">
                            <ItemTemplate>
                                <option value="<%# Eval("ProvinceID") %>"><%# Eval("ProvinceName") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </div>
                <div class="input-group input-width2" style="float: right;">
                    <select id="ddlCity" name="ddlCity"  onchange="CityChange()">
                        <option value="">请选择城市</option>
                        <asp:Repeater runat="server" ID="RepCity">
                            <ItemTemplate>
                                <option value="<%# Eval("CityId") %>"><%# Eval("CityName") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </div>

                <div class="input-group input-width1">
                    <select id="ddlDistrict" name="ddlDistrict" datatype="*" nullmsg="请选择收货地址城市！" errormsg="请选择收货地址城市！">
                        <option value="">请选择区县</option>
                         <asp:Repeater runat="server" ID="RepDistrict">
                            <ItemTemplate>
                                <option value="<%# Eval("DistrictId") %>"><%# Eval("DistrictName") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </div>
                <div class="input-group input-width1">
                    <input type="text" name="txtAddress" id="txtAddress" placeholder="详细地址" datatype="*" nullmsg="请填写详细地址！" errormsg="请填写详细地址！"/>
                </div>
                <div class="defaultaddress">
                    <div class="demandtext">
                        <p>默认地址</p>
                    </div>

                    <div class="demandbtn">
                        <input class='tgl tgl-light' id='ckdefault'name="ckdefault" type='checkbox'>
                        <label class='tgl-btn' for='ckdefault'></label>
                    </div>
                </div>
            </div>



        </div>

        <div class="printbtn">
            <input type="submit" id="btnPrint" class="btnprint" name="" value="确认保存" />
            <input type="hidden" id="hidAid" name="hidAid"  value=""/>
        </div>


          <script src="js/jquery-1.11.1.min.js"></script>
         <script src="js/weChatMsg.js"></script>
        <script src="js/Validform_v5.3.2.js"></script>
        <script src="js/urlParams.js"></script>


        <script>

            $(function () {

                if ($.request.queryString["id"] != "")
                {
                    var strList = "<%= model.City%>".split('-');
                    $("#ddlProvince").val(strList[0]);
                    $("#ddlCity").val(strList[1]);
                    $("#ddlDistrict").val(strList[2]);
                    $("#txtName").val("<%= model.Name%>");
                    $("#txtPhone").val("<%= model.Phone%>");
                    $("#txtAddress").val("<%= model.AddressInfo%>");

                    if ("<%= model.IsDefault%>" == "1") {
                        $("#ckdefault").prop("checked", "true");
                    }
                    else {
                        $("#ckdefault").prop("checked", "false");
                    }
                    $("#hidAid").val($.request.queryString["id"]);

                }


                $("#myForm").Validform({
                    ajaxPost: true,
                    tiptype: function (msg, o, cssctl) {
                        if (o.type == 3) {
                            wechatMsg("错误信息提示", msg);
                        }
                    },
                    postonce: true,
                    callback: function (data) {
                        if (data.state == "success") {
                            if ($.request.queryString["pmid"] != "")
                            {
                                location.href = "integral-order.aspx?pmid=" + $.request.queryString["pmid"] + "&aid=" + data.id;
                            }
                            else
                                {
                            location.href = "Address.aspx";
                            }
                        }
                        else {
                            wechatMsg("提示信息", data.msg);
                        }

                    }

                });
            })


            function ProvinceChange() {
                var provinceId = $("#ddlProvince").val();
                if (provinceId != "")
                {
                  
                    $.ajax({
                        type: "POST",//传输类型get/post
                        url: "/Tools/GetCity.ashx",//请求路径
                        data: { provinceId: provinceId },
                        dataType: "json",//返回格式有json
                        success: function (data) { //成功返时返回回来的data数据

                            $("#ddlCity").html(data.cityList);
                        },
                        error: function (err) {//错误是弹出报错框
                            //alert("shibai");
                        }
                    })

                }


            }
            function CityChange() {
                var cityId = $("#ddlCity").val();
               
                if (cityId != "") {
                    $.ajax({
                        type: "POST",//传输类型get/post
                        url: "/Tools/GetDistrict.ashx",//请求路径
                        data: { cityId: cityId },
                        dataType: "json",//返回格式有json
                        success: function (data) { //成功返时返回回来的data数据

                         
                            $("#ddlDistrict").html(data.districtList);
                        },
                        error: function (err) {//错误是弹出报错框
                            //alert("shibai");
                           
                        }
                    })
                }
            }
        </script>



    </form>
</body>

</html>

