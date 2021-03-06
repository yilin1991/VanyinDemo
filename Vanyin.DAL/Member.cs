﻿/**  版本信息模板在安装目录下，可自行修改。
* Member.cs
*
* 功 能： N/A
* 类 名： Member
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/10 17:01:38   N/A    初版
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
	/// 数据访问类:Member
	/// </summary>
	public partial class Member
	{
		public Member()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_Member"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Member");
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
		public int Add(Vanyin.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Member(");
			strSql.Append("NumId,Account,NameInfo,Pwd,Nickname,Phone,Email,Sex,AddressInfo,Explain,OpenId,HeaderImg,TypeId,StateInfo,AddTime,Remark)");
			strSql.Append(" values (");
			strSql.Append("@NumId,@Account,@NameInfo,@Pwd,@Nickname,@Phone,@Email,@Sex,@AddressInfo,@Explain,@OpenId,@HeaderImg,@TypeId,@StateInfo,@AddTime,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NumId", SqlDbType.NVarChar,100),
					new SqlParameter("@Account", SqlDbType.NVarChar,200),
					new SqlParameter("@NameInfo", SqlDbType.NVarChar,200),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,200),
					new SqlParameter("@Phone", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@AddressInfo", SqlDbType.NVarChar,500),
					new SqlParameter("@Explain", SqlDbType.NText),
					new SqlParameter("@OpenId", SqlDbType.NVarChar,200),
					new SqlParameter("@HeaderImg", SqlDbType.NVarChar,500),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NText)};
			parameters[0].Value = model.NumId;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.NameInfo;
			parameters[3].Value = model.Pwd;
			parameters[4].Value = model.Nickname;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Sex;
			parameters[8].Value = model.AddressInfo;
			parameters[9].Value = model.Explain;
			parameters[10].Value = model.OpenId;
			parameters[11].Value = model.HeaderImg;
			parameters[12].Value = model.TypeId;
			parameters[13].Value = model.StateInfo;
			parameters[14].Value = model.AddTime;
			parameters[15].Value = model.Remark;

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
		public bool Update(Vanyin.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Member set ");
			strSql.Append("NumId=@NumId,");
			strSql.Append("Account=@Account,");
			strSql.Append("NameInfo=@NameInfo,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("Nickname=@Nickname,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("AddressInfo=@AddressInfo,");
			strSql.Append("Explain=@Explain,");
			strSql.Append("OpenId=@OpenId,");
			strSql.Append("HeaderImg=@HeaderImg,");
			strSql.Append("TypeId=@TypeId,");
			strSql.Append("StateInfo=@StateInfo,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@NumId", SqlDbType.NVarChar,100),
					new SqlParameter("@Account", SqlDbType.NVarChar,200),
					new SqlParameter("@NameInfo", SqlDbType.NVarChar,200),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,200),
					new SqlParameter("@Phone", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@AddressInfo", SqlDbType.NVarChar,500),
					new SqlParameter("@Explain", SqlDbType.NText),
					new SqlParameter("@OpenId", SqlDbType.NVarChar,200),
					new SqlParameter("@HeaderImg", SqlDbType.NVarChar,500),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.NumId;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.NameInfo;
			parameters[3].Value = model.Pwd;
			parameters[4].Value = model.Nickname;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Sex;
			parameters[8].Value = model.AddressInfo;
			parameters[9].Value = model.Explain;
			parameters[10].Value = model.OpenId;
			parameters[11].Value = model.HeaderImg;
			parameters[12].Value = model.TypeId;
			parameters[13].Value = model.StateInfo;
			parameters[14].Value = model.AddTime;
			parameters[15].Value = model.Remark;
			parameters[16].Value = model.Id;

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
			strSql.Append("delete from tb_Member ");
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
			strSql.Append("delete from tb_Member ");
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
		public Vanyin.Model.Member GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,NumId,Account,NameInfo,Pwd,Nickname,Phone,Email,Sex,AddressInfo,Explain,OpenId,HeaderImg,TypeId,StateInfo,AddTime,Remark from tb_Member ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Vanyin.Model.Member model=new Vanyin.Model.Member();
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
		public Vanyin.Model.Member DataRowToModel(DataRow row)
		{
			Vanyin.Model.Member model=new Vanyin.Model.Member();
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
				if(row["Account"]!=null)
				{
					model.Account=row["Account"].ToString();
				}
				if(row["NameInfo"]!=null)
				{
					model.NameInfo=row["NameInfo"].ToString();
				}
				if(row["Pwd"]!=null)
				{
					model.Pwd=row["Pwd"].ToString();
				}
				if(row["Nickname"]!=null)
				{
					model.Nickname=row["Nickname"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["AddressInfo"]!=null)
				{
					model.AddressInfo=row["AddressInfo"].ToString();
				}
				if(row["Explain"]!=null)
				{
					model.Explain=row["Explain"].ToString();
				}
				if(row["OpenId"]!=null)
				{
					model.OpenId=row["OpenId"].ToString();
				}
				if(row["HeaderImg"]!=null)
				{
					model.HeaderImg=row["HeaderImg"].ToString();
				}
				if(row["TypeId"]!=null && row["TypeId"].ToString()!="")
				{
					model.TypeId=int.Parse(row["TypeId"].ToString());
				}
				if(row["StateInfo"]!=null && row["StateInfo"].ToString()!="")
				{
					model.StateInfo=int.Parse(row["StateInfo"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select Id,NumId,Account,NameInfo,Pwd,Nickname,Phone,Email,Sex,AddressInfo,Explain,OpenId,HeaderImg,TypeId,StateInfo,AddTime,Remark ");
			strSql.Append(" FROM tb_Member ");
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
			strSql.Append(" Id,NumId,Account,NameInfo,Pwd,Nickname,Phone,Email,Sex,AddressInfo,Explain,OpenId,HeaderImg,TypeId,StateInfo,AddTime,Remark ");
			strSql.Append(" FROM tb_Member ");
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
			strSql.Append("select count(1) FROM tb_Member ");
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
			strSql.Append(")AS Row, T.*  from tb_Member T ");
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
			parameters[0].Value = "tb_Member";
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

