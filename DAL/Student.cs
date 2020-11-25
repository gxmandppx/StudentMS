using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// 数据访问类:Student
	/// </summary>
	public class Student
	{
		public Student()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Student");
			strSql.Append(" where SNO=@SNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50)};
			parameters[0].Value = SNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Student(");
			strSql.Append("SNO,SName,SSex,SBirthday,DeptNO,SAge)");
			strSql.Append(" values (");
			strSql.Append("@SNO,@SName,@SSex,@SBirthday,@DeptNO,@SAge)");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SName", SqlDbType.VarChar,50),
					new SqlParameter("@SSex", SqlDbType.VarChar,2),
					new SqlParameter("@SBirthday", SqlDbType.DateTime),
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50),
					new SqlParameter("@SAge", SqlDbType.Int,4)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.SName;
			parameters[2].Value = model.SSex;
			parameters[3].Value = model.SBirthday;
			parameters[4].Value = model.DeptNO;
			parameters[5].Value = model.SAge;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Student set ");
			strSql.Append("SName=@SName,");
			strSql.Append("SSex=@SSex,");
			strSql.Append("SBirthday=@SBirthday,");
			strSql.Append("DeptNO=@DeptNO,");
			strSql.Append("SAge=@SAge");
			strSql.Append(" where SNO=@SNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SName", SqlDbType.VarChar,50),
					new SqlParameter("@SSex", SqlDbType.VarChar,2),
					new SqlParameter("@SBirthday", SqlDbType.DateTime),
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50),
					new SqlParameter("@SAge", SqlDbType.Int,4)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.SName;
			parameters[2].Value = model.SSex;
			parameters[3].Value = model.SBirthday;
			parameters[4].Value = model.DeptNO;
			parameters[5].Value = model.SAge;

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
		public bool Delete(string SNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student ");
			strSql.Append(" where SNO=@SNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50)};
			parameters[0].Value = SNO;

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
		public bool DeleteList(string SNOlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student ");
			strSql.Append(" where SNO in ("+SNOlist + ")  ");
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
		public StudentMS.Model.Student GetModel(string SNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SNO,SName,SSex,SBirthday,DeptNO,SAge from Student ");
			strSql.Append(" where SNO=@SNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50)};
			parameters[0].Value = SNO;

			StudentMS.Model.Student model=new StudentMS.Model.Student();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.SNO=ds.Tables[0].Rows[0]["SNO"].ToString();
				model.SName=ds.Tables[0].Rows[0]["SName"].ToString();
				model.SSex=ds.Tables[0].Rows[0]["SSex"].ToString();
				if(ds.Tables[0].Rows[0]["SBirthday"].ToString()!="")
				{
					model.SBirthday=DateTime.Parse(ds.Tables[0].Rows[0]["SBirthday"].ToString());
				}
				model.DeptNO=ds.Tables[0].Rows[0]["DeptNO"].ToString();
				if(ds.Tables[0].Rows[0]["SAge"].ToString()!="")
				{
					model.SAge=int.Parse(ds.Tables[0].Rows[0]["SAge"].ToString());
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
			strSql.Append("select SNO,SName,SSex,SBirthday,DeptNO,SAge ");
			strSql.Append(" FROM Student ");
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
			strSql.Append(" SNO,SName,SSex,SBirthday,DeptNO,SAge ");
			strSql.Append(" FROM Student ");
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
			parameters[0].Value = "Student";
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

