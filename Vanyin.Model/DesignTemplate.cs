/**  版本信息模板在安装目录下，可自行修改。
* DesignTemplate.cs
*
* 功 能： N/A
* 类 名： DesignTemplate
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
	/// DesignTemplate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DesignTemplate
	{
		public DesignTemplate()
		{}
		#region Model
		private int _id;
		private string _num;
		private string _title;
		private string _subtitle;
		private int? _typeid;
		private string _strkey;
		private string _price;
		private string _cycle;
		private string _designremark;
		private string _printremark;
		private string _detailremark;
		private string _imgurl;
		private string _tools;
		private int _sortnum=1;
		private int _stateinfo=1;
		private int _ishot=0;
		private int _isindex=0;
		private int _isrec=0;
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
		public string Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubTitle
		{
			set{ _subtitle=value;}
			get{return _subtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StrKey
		{
			set{ _strkey=value;}
			get{return _strkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cycle
		{
			set{ _cycle=value;}
			get{return _cycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DesignRemark
		{
			set{ _designremark=value;}
			get{return _designremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrintRemark
		{
			set{ _printremark=value;}
			get{return _printremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DetailRemark
		{
			set{ _detailremark=value;}
			get{return _detailremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tools
		{
			set{ _tools=value;}
			get{return _tools;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SortNum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
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
		public int IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsIndex
		{
			set{ _isindex=value;}
			get{return _isindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsRec
		{
			set{ _isrec=value;}
			get{return _isrec;}
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

