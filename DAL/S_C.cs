using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// 数据访问类:S_C
	/// </summary>
	public class S_C
	{
		public S_C()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SNO,string CNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_C");
			strSql.Append(" where SNO=@SNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = SNO;
			parameters[1].Value = CNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.S_C model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_C(");
			strSql.Append("SNO,CNO,Score)");
			strSql.Append(" values (");
			strSql.Append("@SNO,@CNO,@Score)");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50),
					new SqlParameter("@Score", SqlDbType.Float,8)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.CNO;
			parameters[2].Value = model.Score;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.S_C model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_C set ");
			strSql.Append("Score=@Score");
			strSql.Append(" where SNO=@SNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50),
					new SqlParameter("@Score", SqlDbType.Float,8)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.CNO;
			parameters[2].Value = model.Score;

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
		public bool Delete(string SNO,string CNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_C ");
			strSql.Append(" where SNO=@SNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = SNO;
			parameters[1].Value = CNO;

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
		/// 得到一个对象实体
		/// </summary>
		public StudentMS.Model.S_C GetModel(string SNO,string CNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SNO,CNO,Score from S_C ");
			strSql.Append(" where SNO=@SNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = SNO;
			parameters[1].Value = CNO;

			StudentMS.Model.S_C model=new StudentMS.Model.S_C();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.SNO=ds.Tables[0].Rows[0]["SNO"].ToString();
				model.CNO=ds.Tables[0].Rows[0]["CNO"].ToString();
				if(ds.Tables[0].Rows[0]["Score"].ToString()!="")
				{
					model.Score=decimal.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
				}
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
			strSql.Append("select SNO,CNO,Score ");
			strSql.Append(" FROM S_C ");
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
			strSql.Append(" SNO,CNO,Score ");
			strSql.Append(" FROM S_C ");
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
			parameters[0].Value = "S_C";
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

