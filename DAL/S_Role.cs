using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// ���ݷ�����:S_Role
	/// </summary>
	public class S_Role
	{
		public S_Role()
		{}
		#region  Method

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string RoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_Role");
			strSql.Append(" where RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = RoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.S_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_Role(");
			strSql.Append("RoleID,RoleName)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@RoleName)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.RoleName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.S_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_Role set ");
			strSql.Append("RoleName=@RoleName");
			strSql.Append(" where RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.RoleName;

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
		public bool Delete(string RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Role ");
			strSql.Append(" where RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = RoleID;

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
		public bool DeleteList(string RoleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_Role ");
			strSql.Append(" where RoleID in ("+RoleIDlist + ")  ");
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
		public StudentMS.Model.S_Role GetModel(string RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,RoleName from S_Role ");
			strSql.Append(" where RoleID=@RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50)};
			parameters[0].Value = RoleID;

			StudentMS.Model.S_Role model=new StudentMS.Model.S_Role();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.RoleID=ds.Tables[0].Rows[0]["RoleID"].ToString();
				model.RoleName=ds.Tables[0].Rows[0]["RoleName"].ToString();
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
			strSql.Append("select RoleID,RoleName ");
			strSql.Append(" FROM S_Role ");
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
			strSql.Append(" RoleID,RoleName ");
			strSql.Append(" FROM S_Role ");
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
			parameters[0].Value = "S_Role";
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

