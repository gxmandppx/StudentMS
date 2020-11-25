using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace StudentMS.DAL
{
	/// <summary>
	/// ���ݷ�����:S_R_F
	/// </summary>
	public class S_R_F
	{
		public S_R_F()
		{}
		#region  Method

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string RoleID,string FunctionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_R_F");
			strSql.Append(" where RoleID=@RoleID and FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = RoleID;
			parameters[1].Value = FunctionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.S_R_F model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_R_F(");
			strSql.Append("RoleID,FunctionID)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@FunctionID)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.FunctionID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.S_R_F model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_R_F set ");
#warning ϵͳ����ȱ�ٸ��µ��ֶΣ����ֹ�ȷ����˸����Ƿ���ȷ�� 
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("FunctionID=@FunctionID");
			strSql.Append(" where RoleID=@RoleID and FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.FunctionID;

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
		public bool Delete(string RoleID,string FunctionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_R_F ");
			strSql.Append(" where RoleID=@RoleID and FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = RoleID;
			parameters[1].Value = FunctionID;

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
		public StudentMS.Model.S_R_F GetModel(string RoleID,string FunctionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,FunctionID from S_R_F ");
			strSql.Append(" where RoleID=@RoleID and FunctionID=@FunctionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionID", SqlDbType.VarChar,50)};
			parameters[0].Value = RoleID;
			parameters[1].Value = FunctionID;

			StudentMS.Model.S_R_F model=new StudentMS.Model.S_R_F();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.RoleID=ds.Tables[0].Rows[0]["RoleID"].ToString();
				model.FunctionID=ds.Tables[0].Rows[0]["FunctionID"].ToString();
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
			strSql.Append("select RoleID,FunctionID ");
			strSql.Append(" FROM S_R_F ");
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
			strSql.Append(" RoleID,FunctionID ");
			strSql.Append(" FROM S_R_F ");
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
			parameters[0].Value = "S_R_F";
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

