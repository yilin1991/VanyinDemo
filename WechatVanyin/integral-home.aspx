<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integral-home.aspx.cs" Inherits="WechatVanyin.integral_home" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<!DOCTYPE html>
<html>

	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
		<title>万印网首页</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
		<link rel="stylesheet" type="text/css" href="css/integral.css" />
	</head>

	<body>


		<!--积分商城 Begin-->
		<div class="integralhome">
			
			<!--积分商城顶部 Begin-->
			<div class="integraltop">
				<div class="integraltop_detail">
					<img src="img/integral/home/headerimg.jpg"/>
					<span>xiaoxiang</span>
					<a href="#">积分明细</a>
				</div>
				<div class="integraltop_num">
					<p>当前积分<span>1000</span></p>
					<p>即将过期<span>500</span></p>
				</div>
				
			</div>
			<!--积分商城顶部 End-->
			
			<!--积分兑换列表 Begin-->
			<div class="integrashop">
				<div class="integrashop_top">
					<span>积分范围</span>
					<select>
						<option value="0">0-1000</option>
					</select>
				</div>
				
				<div class="integrashop_box">
					
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000 积分</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000 积分</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000 积分</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000 积分</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000 积分</span>
							<a href="#">兑换</a>
						</div>
					</div>
					<div class="integrashop_list">
						<div class="integrashop_img">
							<img src="img/integral/home/integralshopimg.png"/>
						</div>
						<p class="shopname">Iphone 6 plus 128G</p>
						<div class="shopnumbtn">
							<span>1000 积分</span>
							<a href="#">兑换</a>
						</div>
					</div>
					
				</div>
				
				
			</div>
			<!--积分兑换列表 End-->
			
			
		</div>
		<!--积分商城 End-->		
		
		<!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />
		<!--底部导航 End-->
	</body>

</html>