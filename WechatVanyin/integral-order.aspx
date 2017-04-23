<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integral-order.aspx.cs" Inherits="WechatVanyin.integral_order" %>


<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网-积分明细</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/integral.css" />
    <link href="css/weChatStyle.css" rel="stylesheet" />
</head>

<body>
    <form id="myForm" runat="server" method="post" action="/Tools/AddMallOrder.ashx" enctype="multipart/form-data">

        <!--积分订单确认 Begin-->
        <div class="integralorder">

            <div class="product">
                <div class="productbox">
                    <p class="title">兑换商品</p>

                    <ul class="productdetail">
                        <li class="img">
                            <img src="<%= GetFileServer(10000)+ modelMall.ImgUrl %>" /></li>
                        <li class="remark">
                            <p><%= modelMall.NameInfo %></p>
                            <p>所需积分：<span><%= modelMall.Integral %></span></p>
                            <p>市场价值：<%=modelMall.Price %></p>
                            <input type="hidden" id="hidpmid" name="hidpmid" value="<%= modelMall.Id %>" />
                        </li>
                    </ul>

                </div>

            </div>

            <div class="orderaddress">
                <div class="oadetail">
                    <p><span><%= modelAddress.Name %></span><span><%=modelAddress.Phone %></span></p>
                    <p><%=GetCityName(modelAddress.City)+ modelAddress.AddressInfo %></p>
                </div>
                <a href="Address.aspx?pid=<%=modelMall.Id %>">
                    <img src="img/integral/home/addressmore.png" /></a>
                <input type="hidden" id="hidaid" name="hidaid" value="<%=modelAddress.Id %>" datatype="*" nullmsg="请选择收货地址！" errormsg="请选择收货地址！"/>
            </div>

            <div class="orderremark">
                <p class="title">兑换备注</p>
                <textarea placeholder="请输入内容" id="txtRemark" name="txtRemark"></textarea>
            </div>

        </div>
        <!--积分订单确认 End-->


        <%--<a href="#" class="btnorderok">确认兑换</a>--%>
        <input type="submit" id="btnorderok" value="确认兑换" class="btnorderok" />

                  <script src="js/jquery-1.11.1.min.js"></script>
         <script src="js/weChatMsg.js"></script>
        <script src="js/Validform_v5.3.2.js"></script>
        <script src="js/urlParams.js"></script>


        <script>

            $(function () {

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

                            location.href = "OrderSuccess.aspx?orderid=" + data.orderId + "&type=mall";
                         
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
