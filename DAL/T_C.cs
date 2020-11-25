using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// ���ݷ�����:T_C
	/// </summary>
	public class T_C
	{
		public T_C()
		{}
		#region  Method

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string TNO,string CNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_C");
			strSql.Append(" where TNO=@TNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;
			parameters[1].Value = CNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.T_C model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_C(");
			strSql.Append("TNO,CNO,TeachAddress,TeachTime)");
			strSql.Append(" values (");
			strSql.Append("@TNO,@CNO,@TeachAddress,@TeachTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50),
					new SqlParameter("@TeachAddress", SqlDbType.VarChar,50),
					new SqlParameter("@TeachTime", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TNO;
			parameters[1].Value = model.CNO;
			parameters[2].Value = model.TeachAddress;
			parameters[3].Value = model.TeachTime;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.T_C model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_C set ");
			strSql.Append("TeachAddress=@TeachAddress,");
			strSql.Append("TeachTime=@TeachTime");
			strSql.Append(" where TNO=@TNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50),
					new SqlParameter("@TeachAddress", SqlDbType.VarChar,50),
					new SqlParameter("@TeachTime", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TNO;
			parameters[1].Value = model.CNO;
			parameters[2].Value = model.TeachAddress;
			parameters[3].Value = model.TeachTime;

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
		public bool Delete(string TNO,string CNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_C ");
			strSql.Append(" where TNO=@TNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;
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
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.T_C GetModel(string TNO,string CNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TNO,CNO,TeachAddress,TeachTime from T_C ");
			strSql.Append(" where TNO=@TNO and CNO=@CNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TNO", SqlDbType.VarChar,50),
					new SqlParameter("@CNO", SqlDbType.VarChar,50)};
			parameters[0].Value = TNO;
			parameters[1].Value = CNO;

			StudentMS.Model.T_C model=new StudentMS.Model.T_C();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.TNO=ds.Tables[0].Rows[0]["TNO"].ToString();
				model.CNO=ds.Tables[0].Rows[0]["CNO"].ToString();
				model.TeachAddress=ds.Tables[0].Rows[0]["TeachAddress"].ToString();
				model.TeachTime=ds.Tables[0].Rows[0]["TeachTime"].ToString();
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
			strSql.Append("select TNO,CNO,TeachAddress,TeachTime ");
			strSql.Append(" FROM T_C ");
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
			strSql.Append(" TNO,CNO,TeachAddress,TeachTime ");
			strSql.Append(" FROM T_C ");
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
			parameters[0].Value = "T_C";
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

