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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Vanyin.DAL
{
	/// <summary>
	/// 数据访问类:SystemInfo
	/// </summary>
	public partial class SystemInfo
	{
		public SystemInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_SystemInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_SystemInfo");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Vanyin.Model.SystemInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_SystemInfo(");
			strSql.Append("Title,WebName,WebUrl,FileServer,WebKey,WebDescribe,WebICP,WebCopyright)");
			strSql.Append(" values (");
			strSql.Append("@Title,@WebName,@WebUrl,@FileServer,@WebKey,@WebDescribe,@WebICP,@WebCopyright)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@WebName", SqlDbType.NVarChar,200),
					new SqlParameter("@WebUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@FileServer", SqlDbType.NVarChar,200),
					new SqlParameter("@WebKey", SqlDbType.NVarChar,500),
					new SqlParameter("@WebDescribe", SqlDbType.NVarChar,500),
					new SqlParameter("@WebICP", SqlDbType.NVarChar,200),
					new SqlParameter("@WebCopyright", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.WebName;
			parameters[2].Value = model.WebUrl;
			parameters[3].Value = model.FileServer;
			parameters[4].Value = model.WebKey;
			parameters[5].Value = model.WebDescribe;
			parameters[6].Value = model.WebICP;
			parameters[7].Value = model.WebCopyright;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Vanyin.Model.SystemInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_SystemInfo set ");
			strSql.Append("Title=@Title,");
			strSql.Append("WebName=@WebName,");
			strSql.Append("WebUrl=@WebUrl,");
			strSql.Append("FileServer=@FileServer,");
			strSql.Append("WebKey=@WebKey,");
			strSql.Append("WebDescribe=@WebDescribe,");
			strSql.Append("WebICP=@WebICP,");
			strSql.Append("WebCopyright=@WebCopyright");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@WebName", SqlDbType.NVarChar,200),
					new SqlParameter("@WebUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@FileServer", SqlDbType.NVarChar,200),
					new SqlParameter("@WebKey", SqlDbType.NVarChar,500),
					new SqlParameter("@WebDescribe", SqlDbType.NVarChar,500),
					new SqlParameter("@WebICP", SqlDbType.NVarChar,200),
					new SqlParameter("@WebCopyright", SqlDbType.NVarChar,200),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.WebName;
			parameters[2].Value = model.WebUrl;
			parameters[3].Value = model.FileServer;
			parameters[4].Value = model.WebKey;
			parameters[5].Value = model.WebDescribe;
			parameters[6].Value = model.WebICP;
			parameters[7].Value = model.WebCopyright;
			parameters[8].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_SystemInfo ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_SystemInfo ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Vanyin.Model.SystemInfo GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,WebName,WebUrl,FileServer,WebKey,WebDescribe,WebICP,WebCopyright from tb_SystemInfo ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Vanyin.Model.SystemInfo model=new Vanyin.Model.SystemInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Vanyin.Model.SystemInfo DataRowToModel(DataRow row)
		{
			Vanyin.Model.SystemInfo model=new Vanyin.Model.SystemInfo();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["WebName"]!=null)
				{
					model.WebName=row["WebName"].ToString();
				}
				if(row["WebUrl"]!=null)
				{
					model.WebUrl=row["WebUrl"].ToString();
				}
				if(row["FileServer"]!=null)
				{
					model.FileServer=row["FileServer"].ToString();
				}
				if(row["WebKey"]!=null)
				{
					model.WebKey=row["WebKey"].ToString();
				}
				if(row["WebDescribe"]!=null)
				{
					model.WebDescribe=row["WebDescribe"].ToString();
				}
				if(row["WebICP"]!=null)
				{
					model.WebICP=row["WebICP"].ToString();
				}
				if(row["WebCopyright"]!=null)
				{
					model.WebCopyright=row["WebCopyright"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Title,WebName,WebUrl,FileServer,WebKey,WebDescribe,WebICP,WebCopyright ");
			strSql.Append(" FROM tb_SystemInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Title,WebName,WebUrl,FileServer,WebKey,WebDescribe,WebICP,WebCopyright ");
			strSql.Append(" FROM tb_SystemInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_SystemInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_SystemInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_SystemInfo";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

