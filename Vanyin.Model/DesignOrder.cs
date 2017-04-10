﻿/**  版本信息模板在安装目录下，可自行修改。
* DesignOrder.cs
*
* 功 能： N/A
* 类 名： DesignOrder
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/10 17:01:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Vanyin.Model
{
	/// <summary>
	/// DesignOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DesignOrder
	{
		public DesignOrder()
		{}
		#region Model
		private int _id;
		private string _numid;
		private int _typeid;
		private int _templateid;
		private int _memberid;
		private string _designrequire;
		private int _ifprint=1;
		private string _nameinfo;
		private string _phone;
		private string _email;
		private string _explain;
		private string _remark;
		private int _stateinfo=1;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NumId
		{
			set{ _numid=value;}
			get{return _numid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TemplateId
		{
			set{ _templateid=value;}
			get{return _templateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DesignRequire
		{
			set{ _designrequire=value;}
			get{return _designrequire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IfPrint
		{
			set{ _ifprint=value;}
			get{return _ifprint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NameInfo
		{
			set{ _nameinfo=value;}
			get{return _nameinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Explain
		{
			set{ _explain=value;}
			get{return _explain;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StateInfo
		{
			set{ _stateinfo=value;}
			get{return _stateinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

