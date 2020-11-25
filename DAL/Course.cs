using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// 数据访问类:Course
	/// </summary>
	public class Course
	{
		public Course()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Course");
			strSql.Append(" where CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = CNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.Course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Course(");
			strSql.Append("CNO,CName,Credit,CFirst)");
			strSql.Append(" values (");
			strSql.Append("@CNO,@CName,@Credit,@CFirst)");
			SqlParameter[] parameters = {
					new SqlParameter("@CNO", SqlDbType.VarChar,50),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@CFirst", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CNO;
			parameters[1].Value = model.CName;
			parameters[2].Value = model.Credit;
			parameters[3].Value = model.CFirst;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.Course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Course set ");
			strSql.Append("CName=@CName,");
			strSql.Append("Credit=@Credit,");
			strSql.Append("CFirst=@CFirst");
			strSql.Append(" where CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@CNO", SqlDbType.VarChar,50),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@CFirst", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CNO;
			parameters[1].Value = model.CName;
			parameters[2].Value = model.Credit;
			parameters[3].Value = model.CFirst;

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
		public bool Delete(string CNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course ");
			strSql.Append(" where CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = CNO;

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
		public bool DeleteList(string CNOlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course ");
			strSql.Append(" where CNO in ("+CNOlist + ")  ");
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
		public StudentMS.Model.Course GetModel(string CNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CNO,CName,Credit,CFirst from Course ");
			strSql.Append(" where CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = CNO;

			StudentMS.Model.Course model=new StudentMS.Model.Course();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CNO=ds.Tables[0].Rows[0]["CNO"].ToString();
				model.CName=ds.Tables[0].Rows[0]["CName"].ToString();
				if(ds.Tables[0].Rows[0]["Credit"].ToString()!="")
				{
					model.Credit=decimal.Parse(ds.Tables[0].Rows[0]["Credit"].ToString());
				}
				model.CFirst=ds.Tables[0].Rows[0]["CFirst"].ToString();
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
			strSql.Append("select CNO,CName,Credit,CFirst ");
			strSql.Append(" FROM Course ");
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
			strSql.Append(" CNO,CName,Credit,CFirst ");
			strSql.Append(" FROM Course ");
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
			parameters[0].Value = "Course";
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

