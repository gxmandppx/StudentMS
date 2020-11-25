using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// ���ݷ�����:Department
	/// </summary>
	public class Department
	{
		public Department()
		{}
		#region  Method

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string DeptNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Department");
			strSql.Append(" where DeptNO=@DeptNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50)};
			parameters[0].Value = DeptNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Department(");
			strSql.Append("DeptNO,DeptName)");
			strSql.Append(" values (");
			strSql.Append("@DeptNO,@DeptName)");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50),
					new SqlParameter("@DeptName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.DeptNO;
			parameters[1].Value = model.DeptName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Department set ");
			strSql.Append("DeptName=@DeptName");
			strSql.Append(" where DeptNO=@DeptNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50),
					new SqlParameter("@DeptName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.DeptNO;
			parameters[1].Value = model.DeptName;

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
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string DeptNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where DeptNO=@DeptNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50)};
			parameters[0].Value = DeptNO;

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
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string DeptNOlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where DeptNO in ("+DeptNOlist + ")  ");
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
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.Department GetModel(string DeptNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DeptNO,DeptName from Department ");
			strSql.Append(" where DeptNO=@DeptNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptNO", SqlDbType.VarChar,50)};
			parameters[0].Value = DeptNO;

			StudentMS.Model.Department model=new StudentMS.Model.Department();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.DeptNO=ds.Tables[0].Rows[0]["DeptNO"].ToString();
				model.DeptName=ds.Tables[0].Rows[0]["DeptName"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DeptNO,DeptName ");
			strSql.Append(" FROM Department ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" DeptNO,DeptName ");
			strSql.Append(" FROM Department ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "Department";
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

