/**  版本信息模板在安装目录下，可自行修改。
* Category.cs
*
* 功 能： N/A
* 类 名： Category
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/10 17:01:35   N/A    初版
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
    /// 数据访问类:Category
    /// </summary>
    public partial class Category
    {
        public Category()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "tb_Category");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Vanyin.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Category(");
            strSql.Append("NumId,Title,SubTitle,ParentId,LevelNum,ImgUrl,DefaultImgUrl,SortNum,StateInfo,Explain,Remark)");
            strSql.Append(" values (");
            strSql.Append("@NumId,@Title,@SubTitle,@ParentId,@LevelNum,@ImgUrl,@DefaultImgUrl,@SortNum,@StateInfo,@Explain,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@NumId", SqlDbType.NVarChar,100),
                    new SqlParameter("@Title", SqlDbType.NVarChar,200),
                    new SqlParameter("@SubTitle", SqlDbType.NVarChar,500),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@LevelNum", SqlDbType.Int,4),
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@DefaultImgUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@SortNum", SqlDbType.Int,4),
                    new SqlParameter("@StateInfo", SqlDbType.Int,4),
                    new SqlParameter("@Explain", SqlDbType.NText),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.NumId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.LevelNum;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.DefaultImgUrl;
            parameters[7].Value = model.SortNum;
            parameters[8].Value = model.StateInfo;
            parameters[9].Value = model.Explain;
            parameters[10].Value = model.Remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Vanyin.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Category set ");
            strSql.Append("NumId=@NumId,");
            strSql.Append("Title=@Title,");
            strSql.Append("SubTitle=@SubTitle,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("LevelNum=@LevelNum,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("DefaultImgUrl=@DefaultImgUrl,");
            strSql.Append("SortNum=@SortNum,");
            strSql.Append("StateInfo=@StateInfo,");
            strSql.Append("Explain=@Explain,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@NumId", SqlDbType.NVarChar,100),
                    new SqlParameter("@Title", SqlDbType.NVarChar,200),
                    new SqlParameter("@SubTitle", SqlDbType.NVarChar,500),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@LevelNum", SqlDbType.Int,4),
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@DefaultImgUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@SortNum", SqlDbType.Int,4),
                    new SqlParameter("@StateInfo", SqlDbType.Int,4),
                    new SqlParameter("@Explain", SqlDbType.NText),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.NumId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.LevelNum;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.DefaultImgUrl;
            parameters[7].Value = model.SortNum;
            parameters[8].Value = model.StateInfo;
            parameters[9].Value = model.Explain;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Category ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Category ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Vanyin.Model.Category GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,NumId,Title,SubTitle,ParentId,LevelNum,ImgUrl,DefaultImgUrl,SortNum,StateInfo,Explain,Remark from tb_Category ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Vanyin.Model.Category model = new Vanyin.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Vanyin.Model.Category DataRowToModel(DataRow row)
        {
            Vanyin.Model.Category model = new Vanyin.Model.Category();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["NumId"] != null)
                {
                    model.NumId = row["NumId"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["SubTitle"] != null)
                {
                    model.SubTitle = row["SubTitle"].ToString();
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["LevelNum"] != null && row["LevelNum"].ToString() != "")
                {
                    model.LevelNum = int.Parse(row["LevelNum"].ToString());
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
                }
                if (row["DefaultImgUrl"] != null)
                {
                    model.DefaultImgUrl = row["DefaultImgUrl"].ToString();
                }
                if (row["SortNum"] != null && row["SortNum"].ToString() != "")
                {
                    model.SortNum = int.Parse(row["SortNum"].ToString());
                }
                if (row["StateInfo"] != null && row["StateInfo"].ToString() != "")
                {
                    model.StateInfo = int.Parse(row["StateInfo"].ToString());
                }
                if (row["Explain"] != null)
                {
                    model.Explain = row["Explain"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,NumId,Title,SubTitle,ParentId,LevelNum,ImgUrl,DefaultImgUrl,SortNum,StateInfo,Explain,Remark ");
            strSql.Append(" FROM tb_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 取得所有栏目列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetListChild(int PId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,NumId,Title,SubTitle,ParentId,LevelNum,ImgUrl,DefaultImgUrl,SortNum,StateInfo,Explain,Remark");
            strSql.Append(" FROM tb_Category ");
            strSql.Append(" order by SortNum asc,Id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }

            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChannelChild(oldData, newData, PId);
            return newData;
        }

        /// <summary>
        /// 获取子类别
        /// </summary>
        /// <param name="parentId">父编号</param>
        /// <param name="stateInfo">状态</param>
        /// <returns></returns>
        private void GetChannelChild(DataTable oldData, DataTable newData, int PId)
        {

            DataRow[] dr = oldData.Select("ParentId=" + PId);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                 row["Id"] = int.Parse(dr[i]["Id"].ToString());
                row["NumId"] = dr[i]["NumId"].ToString();
                row["Title"] = dr[i]["Title"].ToString();
                row["SubTitle"] = dr[i]["SubTitle"].ToString();
                row["ParentId"] = int.Parse(dr[i]["ParentId"].ToString());
                row["LevelNum"] = int.Parse(dr[i]["LevelNum"].ToString());
                row["SortNum"] = int.Parse(dr[i]["SortNum"].ToString());
                row["ImgUrl"] = dr[i]["ImgUrl"].ToString();
                row["DefaultImgUrl"] = dr[i]["DefaultImgUrl"].ToString();
                row["StateInfo"] = int.Parse(dr[i]["StateInfo"].ToString());
                row["Explain"] = dr[i]["Explain"].ToString();
                row["Remark"] = dr[i]["Remark"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChannelChild(oldData, newData, int.Parse(dr[i]["Id"].ToString()));
            }


         

        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,NumId,Title,SubTitle,ParentId,LevelNum,ImgUrl,DefaultImgUrl,SortNum,StateInfo,Explain,Remark ");
            strSql.Append(" FROM tb_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Category T ");
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
			parameters[0].Value = "tb_Category";
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

