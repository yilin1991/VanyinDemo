﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integral-order.aspx.cs" Inherits="WechatVanyin.integral_order" %>


<!DOCTYPE html>
<html>

	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
		<title>万印网-积分明细</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
		<link rel="stylesheet" type="text/css" href="css/integral.css" />
	</head>

	<body>
		<!--积分订单确认 Begin-->
		<div class="integralorder">
			
			<div class="product">
				<div class="productbox">
					<p class="title">兑换商品</p>
					
					<ul class="productdetail">
						<li class="img"><img src="img/integral/home/integralshopimg.png"/></li>
						<li class="remark">
							<p>Iphone 6 plus 128G</p>
							<p>所需积分：<span>20000</span></p>
							<p>市场价值： ￥5000.00 RMB</p>
						</li>
					</ul>
					
				</div>

			</div>
			
			<div class="orderaddress">
				<div class="oadetail">
					<p><span>小向</span><span>18653588681</span></p>
					<p>上海市浦东新区北张家浜路88号左岸88创意园B417</p>
				</div>
				<a href="#"><img src="img/integral/home/addressmore.png"/></a>
			</div>
			
			<div class="orderremark">
				<p class="title">兑换备注</p>
				<textarea placeholder="请输入内容"></textarea>
			</div>
			
		</div>
		<!--积分订单确认 End-->
		
			
		<a href="#" class="btnorderok">确认兑换</a>
		
	</body>

</html>