<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="opinion.aspx.cs" Inherits="WechatVanyin.opinion" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html>

	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
		<title>万印网-投诉及建议</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
		<link rel="stylesheet" type="text/css" href="css/opinion.css" />
	</head>

	<body>
		
		<!--投诉及意见 Begin-->

		<div class="opinionbody">

			<div class="opiniontop">
				<p>投诉及意见</p>
			</div>

			<div class="opinionform">
				
				<div class="opinionselect">
					<select>
						<option value="">请选择投诉及建议类型</option>
					</select>
				</div>
				
				<textarea class="txtremark" placeholder="详细内容"></textarea>
				
				<input type="tel" name="txttel" class="txttel" id="txttel" value="" placeholder="手机号码" />
				
				<div class="opinionbtn">
					<input type="submit" name="btnOK" id="btnOk" value="确认提交" />
				</div>
				
			</div>

		</div>

		<!--投诉及意见 End-->
        
		<!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />
		<!--底部导航 End-->

	</body>

</html>
