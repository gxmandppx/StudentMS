using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// S_R_F
	/// </summary>
	public class S_R_F
	{
		private readonly StudentMS.DAL.S_R_F dal=new StudentMS.DAL.S_R_F();
		public S_R_F()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string RoleID,string FunctionID)
		{
			return dal.Exists(RoleID,FunctionID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.S_R_F model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.S_R_F model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string RoleID,string FunctionID)
		{
			
			return dal.Delete(RoleID,FunctionID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.S_R_F GetModel(string RoleID,string FunctionID)
		{
			
			return dal.GetModel(RoleID,FunctionID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public StudentMS.Model.S_R_F GetModelByCache(string RoleID,string FunctionID)
		{
			
			string CacheKey = "S_R_FModel-" + RoleID+FunctionID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleID,FunctionID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.S_R_F)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<StudentMS.Model.S_R_F> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<StudentMS.Model.S_R_F> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.S_R_F> modelList = new List<StudentMS.Model.S_R_F>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.S_R_F model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.S_R_F();
					model.RoleID=dt.Rows[n]["RoleID"].ToString();
					model.FunctionID=dt.Rows[n]["FunctionID"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

