﻿/**  版本信息模板在安装目录下，可自行修改。
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Vanyin.DAL
{
	/// <summary>
	/// 数据访问类:DesignTemplate
	/// </summary>
	public partial class DesignTemplate
	{
		public DesignTemplate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_DesignTemplate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_DesignTemplate");
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
		public int Add(Vanyin.Model.DesignTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_DesignTemplate(");
			strSql.Append("Num,Title,SubTitle,TypeId,StrKey,Price,Cycle,DesignRemark,PrintRemark,DetailRemark,ImgUrl,Tools,SortNum,StateInfo,IsHot,IsIndex,IsRec,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@Num,@Title,@SubTitle,@TypeId,@StrKey,@Price,@Cycle,@DesignRemark,@PrintRemark,@DetailRemark,@ImgUrl,@Tools,@SortNum,@StateInfo,@IsHot,@IsIndex,@IsRec,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Num", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@StrKey", SqlDbType.NVarChar,500),
					new SqlParameter("@Price", SqlDbType.NVarChar,100),
					new SqlParameter("@Cycle", SqlDbType.NVarChar,100),
					new SqlParameter("@DesignRemark", SqlDbType.NText),
					new SqlParameter("@PrintRemark", SqlDbType.NText),
					new SqlParameter("@DetailRemark", SqlDbType.NText),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Tools", SqlDbType.NVarChar,100),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsIndex", SqlDbType.Int,4),
					new SqlParameter("@IsRec", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Num;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.SubTitle;
			parameters[3].Value = model.TypeId;
			parameters[4].Value = model.StrKey;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.Cycle;
			parameters[7].Value = model.DesignRemark;
			parameters[8].Value = model.PrintRemark;
			parameters[9].Value = model.DetailRemark;
			parameters[10].Value = model.ImgUrl;
			parameters[11].Value = model.Tools;
			parameters[12].Value = model.SortNum;
			parameters[13].Value = model.StateInfo;
			parameters[14].Value = model.IsHot;
			parameters[15].Value = model.IsIndex;
			parameters[16].Value = model.IsRec;
			parameters[17].Value = model.AddTime;

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
		public bool Update(Vanyin.Model.DesignTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_DesignTemplate set ");
			strSql.Append("Num=@Num,");
			strSql.Append("Title=@Title,");
			strSql.Append("SubTitle=@SubTitle,");
			strSql.Append("TypeId=@TypeId,");
			strSql.Append("StrKey=@StrKey,");
			strSql.Append("Price=@Price,");
			strSql.Append("Cycle=@Cycle,");
			strSql.Append("DesignRemark=@DesignRemark,");
			strSql.Append("PrintRemark=@PrintRemark,");
			strSql.Append("DetailRemark=@DetailRemark,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("Tools=@Tools,");
			strSql.Append("SortNum=@SortNum,");
			strSql.Append("StateInfo=@StateInfo,");
			strSql.Append("IsHot=@IsHot,");
			strSql.Append("IsIndex=@IsIndex,");
			strSql.Append("IsRec=@IsRec,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Num", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@StrKey", SqlDbType.NVarChar,500),
					new SqlParameter("@Price", SqlDbType.NVarChar,100),
					new SqlParameter("@Cycle", SqlDbType.NVarChar,100),
					new SqlParameter("@DesignRemark", SqlDbType.NText),
					new SqlParameter("@PrintRemark", SqlDbType.NText),
					new SqlParameter("@DetailRemark", SqlDbType.NText),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Tools", SqlDbType.NVarChar,100),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsIndex", SqlDbType.Int,4),
					new SqlParameter("@IsRec", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Num;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.SubTitle;
			parameters[3].Value = model.TypeId;
			parameters[4].Value = model.StrKey;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.Cycle;
			parameters[7].Value = model.DesignRemark;
			parameters[8].Value = model.PrintRemark;
			parameters[9].Value = model.DetailRemark;
			parameters[10].Value = model.ImgUrl;
			parameters[11].Value = model.Tools;
			parameters[12].Value = model.SortNum;
			parameters[13].Value = model.StateInfo;
			parameters[14].Value = model.IsHot;
			parameters[15].Value = model.IsIndex;
			parameters[16].Value = model.IsRec;
			parameters[17].Value = model.AddTime;
			parameters[18].Value = model.Id;

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
			strSql.Append("delete from tb_DesignTemplate ");
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
			strSql.Append("delete from tb_DesignTemplate ");
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
		public Vanyin.Model.DesignTemplate GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Num,Title,SubTitle,TypeId,StrKey,Price,Cycle,DesignRemark,PrintRemark,DetailRemark,ImgUrl,Tools,SortNum,StateInfo,IsHot,IsIndex,IsRec,AddTime from tb_DesignTemplate ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Vanyin.Model.DesignTemplate model=new Vanyin.Model.DesignTemplate();
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
		public Vanyin.Model.DesignTemplate DataRowToModel(DataRow row)
		{
			Vanyin.Model.DesignTemplate model=new Vanyin.Model.DesignTemplate();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Num"]!=null)
				{
					model.Num=row["Num"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["SubTitle"]!=null)
				{
					model.SubTitle=row["SubTitle"].ToString();
				}
				if(row["TypeId"]!=null && row["TypeId"].ToString()!="")
				{
					model.TypeId=int.Parse(row["TypeId"].ToString());
				}
				if(row["StrKey"]!=null)
				{
					model.StrKey=row["StrKey"].ToString();
				}
				if(row["Price"]!=null)
				{
					model.Price=row["Price"].ToString();
				}
				if(row["Cycle"]!=null)
				{
					model.Cycle=row["Cycle"].ToString();
				}
				if(row["DesignRemark"]!=null)
				{
					model.DesignRemark=row["DesignRemark"].ToString();
				}
				if(row["PrintRemark"]!=null)
				{
					model.PrintRemark=row["PrintRemark"].ToString();
				}
				if(row["DetailRemark"]!=null)
				{
					model.DetailRemark=row["DetailRemark"].ToString();
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["Tools"]!=null)
				{
					model.Tools=row["Tools"].ToString();
				}
				if(row["SortNum"]!=null && row["SortNum"].ToString()!="")
				{
					model.SortNum=int.Parse(row["SortNum"].ToString());
				}
				if(row["StateInfo"]!=null && row["StateInfo"].ToString()!="")
				{
					model.StateInfo=int.Parse(row["StateInfo"].ToString());
				}
				if(row["IsHot"]!=null && row["IsHot"].ToString()!="")
				{
					model.IsHot=int.Parse(row["IsHot"].ToString());
				}
				if(row["IsIndex"]!=null && row["IsIndex"].ToString()!="")
				{
					model.IsIndex=int.Parse(row["IsIndex"].ToString());
				}
				if(row["IsRec"]!=null && row["IsRec"].ToString()!="")
				{
					model.IsRec=int.Parse(row["IsRec"].ToString());
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
			strSql.Append("select Id,Num,Title,SubTitle,TypeId,StrKey,Price,Cycle,DesignRemark,PrintRemark,DetailRemark,ImgUrl,Tools,SortNum,StateInfo,IsHot,IsIndex,IsRec,AddTime ");
			strSql.Append(" FROM tb_DesignTemplate ");
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
			strSql.Append(" Id,Num,Title,SubTitle,TypeId,StrKey,Price,Cycle,DesignRemark,PrintRemark,DetailRemark,ImgUrl,Tools,SortNum,StateInfo,IsHot,IsIndex,IsRec,AddTime ");
			strSql.Append(" FROM tb_DesignTemplate ");
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
			strSql.Append("select count(1) FROM tb_DesignTemplate ");
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
			strSql.Append(")AS Row, T.*  from tb_DesignTemplate T ");
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
			parameters[0].Value = "tb_DesignTemplate";
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

