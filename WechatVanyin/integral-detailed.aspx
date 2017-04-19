<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integral-detailed.aspx.cs" Inherits="WechatVanyin.integral_detailed" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


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
		
		<!--积分明细 Begin-->
		<div class="integraldetailed">
			<ul class="detailedtop">
				<li>
					<p>1000</p>
					<p>当前积分</p>
				</li>
				<li>
					<p>100</p>
					<p>即将过期</p>
				</li>
			</ul>
			<p class="detailedtitle">收支明细</p>
			
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
			<div class="detailedlist">
				<p><span>订单号 558764536475</span><span>56</span></p>
				<p><span>订单完成</span><span>2015/02/10</span></p>                                    
			</div>
		</div>
		<!--积分明细 End-->
		<!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />

		<!--底部导航 End-->
	</body>

</html>