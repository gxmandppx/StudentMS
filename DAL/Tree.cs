using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// 数据访问类:Tree
	/// </summary>
	public class Tree
	{
		public Tree()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tree");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.Tree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tree(");
			strSql.Append("TNO,TName,TNOParent)");
			strSql.Append(" values (");
			strSql.Append("@TNO,@TName,@TNOParent)");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,10),
					new SqlParameter("@TName", SqlDbType.VarChar,50),
					new SqlParameter("@TNOParent", SqlDbType.VarChar,10)};
			parameters[0].Value = model.TNO;
			parameters[1].Value = model.TName;
			parameters[2].Value = model.TNOParent;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.Tree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tree set ");
			strSql.Append("TName=@TName,");
			strSql.Append("TNOParent=@TNOParent");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,10),
					new SqlParameter("@TName", SqlDbType.VarChar,50),
					new SqlParameter("@TNOParent", SqlDbType.VarChar,10)};
			parameters[0].Value = model.TNO;
			parameters[1].Value = model.TName;
			parameters[2].Value = model.TNOParent;

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
		public bool Delete(string TNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tree ");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;

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
		public bool DeleteList(string TNOlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tree ");
			strSql.Append(" where TNO in ("+TNOlist + ")  ");
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
		public StudentMS.Model.Tree GetModel(string TNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TNO,TName,TNOParent from Tree ");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;

			StudentMS.Model.Tree model=new StudentMS.Model.Tree();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.TNO=ds.Tables[0].Rows[0]["TNO"].ToString();
				model.TName=ds.Tables[0].Rows[0]["TName"].ToString();
				model.TNOParent=ds.Tables[0].Rows[0]["TNOParent"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TNO,TName,TNOParent ");
			strSql.Append(" FROM Tree ");
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
			strSql.Append(" TNO,TName,TNOParent ");
			strSql.Append(" FROM Tree ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "Tree";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

