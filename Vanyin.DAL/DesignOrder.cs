/**  版本信息模板在安装目录下，可自行修改。
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Vanyin.DAL
{
	/// <summary>
	/// 数据访问类:DesignOrder
	/// </summary>
	public partial class DesignOrder
	{
		public DesignOrder()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_DesignOrder"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_DesignOrder");
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
		public int Add(Vanyin.Model.DesignOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_DesignOrder(");
			strSql.Append("NumId,TypeId,TemplateId,MemberId,DesignRequire,IfPrint,NameInfo,Phone,Email,Explain,Remark,StateInfo,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@NumId,@TypeId,@TemplateId,@MemberId,@DesignRequire,@IfPrint,@NameInfo,@Phone,@Email,@Explain,@Remark,@StateInfo,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NumId", SqlDbType.NVarChar,100),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@TemplateId", SqlDbType.Int,4),
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@DesignRequire", SqlDbType.NText),
					new SqlParameter("@IfPrint", SqlDbType.Int,4),
					new SqlParameter("@NameInfo", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Explain", SqlDbType.NText),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.NumId;
			parameters[1].Value = model.TypeId;
			parameters[2].Value = model.TemplateId;
			parameters[3].Value = model.MemberId;
			parameters[4].Value = model.DesignRequire;
			parameters[5].Value = model.IfPrint;
			parameters[6].Value = model.NameInfo;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Explain;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.StateInfo;
			parameters[12].Value = model.AddTime;

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
		public bool Update(Vanyin.Model.DesignOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_DesignOrder set ");
			strSql.Append("NumId=@NumId,");
			strSql.Append("TypeId=@TypeId,");
			strSql.Append("TemplateId=@TemplateId,");
			strSql.Append("MemberId=@MemberId,");
			strSql.Append("DesignRequire=@DesignRequire,");
			strSql.Append("IfPrint=@IfPrint,");
			strSql.Append("NameInfo=@NameInfo,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Explain=@Explain,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("StateInfo=@StateInfo,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@NumId", SqlDbType.NVarChar,100),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@TemplateId", SqlDbType.Int,4),
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@DesignRequire", SqlDbType.NText),
					new SqlParameter("@IfPrint", SqlDbType.Int,4),
					new SqlParameter("@NameInfo", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Explain", SqlDbType.NText),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.NumId;
			parameters[1].Value = model.TypeId;
			parameters[2].Value = model.TemplateId;
			parameters[3].Value = model.MemberId;
			parameters[4].Value = model.DesignRequire;
			parameters[5].Value = model.IfPrint;
			parameters[6].Value = model.NameInfo;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Explain;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.StateInfo;
			parameters[12].Value = model.AddTime;
			parameters[13].Value = model.Id;

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
			strSql.Append("delete from tb_DesignOrder ");
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
			strSql.Append("delete from tb_DesignOrder ");
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
		public Vanyin.Model.DesignOrder GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,NumId,TypeId,TemplateId,MemberId,DesignRequire,IfPrint,NameInfo,Phone,Email,Explain,Remark,StateInfo,AddTime from tb_DesignOrder ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Vanyin.Model.DesignOrder model=new Vanyin.Model.DesignOrder();
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
		public Vanyin.Model.DesignOrder DataRowToModel(DataRow row)
		{
			Vanyin.Model.DesignOrder model=new Vanyin.Model.DesignOrder();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["NumId"]!=null)
				{
					model.NumId=row["NumId"].ToString();
				}
				if(row["TypeId"]!=null && row["TypeId"].ToString()!="")
				{
					model.TypeId=int.Parse(row["TypeId"].ToString());
				}
				if(row["TemplateId"]!=null && row["TemplateId"].ToString()!="")
				{
					model.TemplateId=int.Parse(row["TemplateId"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["DesignRequire"]!=null)
				{
					model.DesignRequire=row["DesignRequire"].ToString();
				}
				if(row["IfPrint"]!=null && row["IfPrint"].ToString()!="")
				{
					model.IfPrint=int.Parse(row["IfPrint"].ToString());
				}
				if(row["NameInfo"]!=null)
				{
					model.NameInfo=row["NameInfo"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Explain"]!=null)
				{
					model.Explain=row["Explain"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["StateInfo"]!=null && row["StateInfo"].ToString()!="")
				{
					model.StateInfo=int.Parse(row["StateInfo"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
			strSql.Append("select Id,NumId,TypeId,TemplateId,MemberId,DesignRequire,IfPrint,NameInfo,Phone,Email,Explain,Remark,StateInfo,AddTime ");
			strSql.Append(" FROM tb_DesignOrder ");
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
			strSql.Append(" Id,NumId,TypeId,TemplateId,MemberId,DesignRequire,IfPrint,NameInfo,Phone,Email,Explain,Remark,StateInfo,AddTime ");
			strSql.Append(" FROM tb_DesignOrder ");
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
			strSql.Append("select count(1) FROM tb_DesignOrder ");
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
			strSql.Append(")AS Row, T.*  from tb_DesignOrder T ");
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
			parameters[0].Value = "tb_DesignOrder";
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

