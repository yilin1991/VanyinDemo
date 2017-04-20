/**  版本信息模板在安装目录下，可自行修改。
* SystemInfo.cs
*
* 功 能： N/A
* 类 名： SystemInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/20 17:30:31   N/A    初版
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
	/// SystemInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SystemInfo
	{
		public SystemInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _webname;
		private string _weburl;
		private string _fileserver;
		private string _webkey;
		private string _webdescribe;
		private string _webicp;
		private string _webcopyright;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebName
		{
			set{ _webname=value;}
			get{return _webname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebUrl
		{
			set{ _weburl=value;}
			get{return _weburl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileServer
		{
			set{ _fileserver=value;}
			get{return _fileserver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebKey
		{
			set{ _webkey=value;}
			get{return _webkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebDescribe
		{
			set{ _webdescribe=value;}
			get{return _webdescribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebICP
		{
			set{ _webicp=value;}
			get{return _webicp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebCopyright
		{
			set{ _webcopyright=value;}
			get{return _webcopyright;}
		}
		#endregion Model

	}
}

