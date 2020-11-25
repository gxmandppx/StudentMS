using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// 数据访问类:S_Function
	/// </summary>
	public class S_Function
	{
		public S_Function()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FunctionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_Function");
			strSql.Append(" where FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = FunctionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.S_Function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_Function(");
			strSql.Append("FunctionID,FunctionName)");
			strSql.Append(" values (");
			strSql.Append("@FunctionID,@FunctionName)");
			SqlParameter[] parameters = {
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FunctionID;
			parameters[1].Value = model.FunctionName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.S_Function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_Function set ");
			strSql.Append("FunctionName=@FunctionName");
			strSql.Append(" where FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FunctionID;
			parameters[1].Value = model.FunctionName;

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
		public bool Delete(string FunctionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Function ");
			strSql.Append(" where FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = FunctionID;

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
		public bool DeleteList(string FunctionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Function ");
			strSql.Append(" where FunctionID in ("+FunctionIDlist + ")  ");
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
		public StudentMS.Model.S_Function GetModel(string FunctionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FunctionID,FunctionName from S_Function ");
			strSql.Append(" where FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = FunctionID;

			StudentMS.Model.S_Function model=new StudentMS.Model.S_Function();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.FunctionID=ds.Tables[0].Rows[0]["FunctionID"].ToString();
				model.FunctionName=ds.Tables[0].Rows[0]["FunctionName"].ToString();
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
			strSql.Append("select FunctionID,FunctionName ");
			strSql.Append(" FROM S_Function ");
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
			strSql.Append(" FunctionID,FunctionName ");
			strSql.Append(" FROM S_Function ");
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
			parameters[0].Value = "S_Function";
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

