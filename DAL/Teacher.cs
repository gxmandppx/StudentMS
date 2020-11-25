using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// 数据访问类:Teacher
	/// </summary>
	public class Teacher
	{
		public Teacher()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Teacher");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Teacher(");
			strSql.Append("TNO,TName,TSex,TAge,TAddress)");
			strSql.Append(" values (");
			strSql.Append("@TNO,@TName,@TSex,@TAge,@TAddress)");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@TName", SqlDbType.VarChar,50),
					new SqlParameter("@TSex", SqlDbType.VarChar,4),
					new SqlParameter("@TAge", SqlDbType.Int,4),
					new SqlParameter("@TAddress", SqlDbType.VarChar,150)};
			parameters[0].Value = model.TNO;
			parameters[1].Value = model.TName;
			parameters[2].Value = model.TSex;
			parameters[3].Value = model.TAge;
			parameters[4].Value = model.TAddress;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Teacher set ");
			strSql.Append("TName=@TName,");
			strSql.Append("TSex=@TSex,");
			strSql.Append("TAge=@TAge,");
			strSql.Append("TAddress=@TAddress");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@TName", SqlDbType.VarChar,50),
					new SqlParameter("@TSex", SqlDbType.VarChar,4),
					new SqlParameter("@TAge", SqlDbType.Int,4),
					new SqlParameter("@TAddress", SqlDbType.VarChar,150)};
			parameters[0].Value = model.TNO;
			parameters[1].Value = model.TName;
			parameters[2].Value = model.TSex;
			parameters[3].Value = model.TAge;
			parameters[4].Value = model.TAddress;

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
			strSql.Append("delete from Teacher ");
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
			strSql.Append("delete from Teacher ");
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
		public StudentMS.Model.Teacher GetModel(string TNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TNO,TName,TSex,TAge,TAddress from Teacher ");
			strSql.Append(" where TNO=@TNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;

			StudentMS.Model.Teacher model=new StudentMS.Model.Teacher();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.TNO=ds.Tables[0].Rows[0]["TNO"].ToString();
				model.TName=ds.Tables[0].Rows[0]["TName"].ToString();
				model.TSex=ds.Tables[0].Rows[0]["TSex"].ToString();
				if(ds.Tables[0].Rows[0]["TAge"].ToString()!="")
				{
					model.TAge=int.Parse(ds.Tables[0].Rows[0]["TAge"].ToString());
				}
				model.TAddress=ds.Tables[0].Rows[0]["TAddress"].ToString();
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
			strSql.Append("select TNO,TName,TSex,TAge,TAddress ");
			strSql.Append(" FROM Teacher ");
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
			strSql.Append(" TNO,TName,TSex,TAge,TAddress ");
			strSql.Append(" FROM Teacher ");
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
			parameters[0].Value = "Teacher";
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

