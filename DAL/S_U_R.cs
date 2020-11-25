using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// ���ݷ�����:S_U_R
	/// </summary>
	public class S_U_R
	{
		public S_U_R()
		{}
		#region  Method

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string UserID,string RoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_U_R");
			strSql.Append(" where UserID=@UserID and RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = UserID;
			parameters[1].Value = RoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.S_U_R model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_U_R(");
			strSql.Append("UserID,RoleID)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@RoleID)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.RoleID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.S_U_R model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_U_R set ");
#warning ϵͳ����ȱ�ٸ��µ��ֶΣ����ֹ�ȷ����˸����Ƿ���ȷ�� 
			strSql.Append("UserID=@UserID,");
			strSql.Append("RoleID=@RoleID");
			strSql.Append(" where UserID=@UserID and RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.RoleID;

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
		public bool Delete(string UserID,string RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_U_R ");
			strSql.Append(" where UserID=@UserID and RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = UserID;
			parameters[1].Value = RoleID;

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
		public StudentMS.Model.S_U_R GetModel(string UserID,string RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,RoleID from S_U_R ");
			strSql.Append(" where UserID=@UserID and RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = UserID;
			parameters[1].Value = RoleID;

			StudentMS.Model.S_U_R model=new StudentMS.Model.S_U_R();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				model.RoleID=ds.Tables[0].Rows[0]["RoleID"].ToString();
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
			strSql.Append("select UserID,RoleID ");
			strSql.Append(" FROM S_U_R ");
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
			strSql.Append(" UserID,RoleID ");
			strSql.Append(" FROM S_U_R ");
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
			parameters[0].Value = "S_U_R";
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

