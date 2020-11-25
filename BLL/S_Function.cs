using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// S_Function
	/// </summary>
	public class S_Function
	{
		private readonly StudentMS.DAL.S_Function dal=new StudentMS.DAL.S_Function();
		public S_Function()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string FunctionID)
		{
			return dal.Exists(FunctionID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.S_Function model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.S_Function model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string FunctionID)
		{
			
			return dal.Delete(FunctionID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string FunctionIDlist )
		{
			return dal.DeleteList(FunctionIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.S_Function GetModel(string FunctionID)
		{
			
			return dal.GetModel(FunctionID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public StudentMS.Model.S_Function GetModelByCache(string FunctionID)
		{
			
			string CacheKey = "S_FunctionModel-" + FunctionID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FunctionID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.S_Function)objModel;
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
		public List<StudentMS.Model.S_Function> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<StudentMS.Model.S_Function> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.S_Function> modelList = new List<StudentMS.Model.S_Function>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.S_Function model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.S_Function();
					model.FunctionID=dt.Rows[n]["FunctionID"].ToString();
					model.FunctionName=dt.Rows[n]["FunctionName"].ToString();
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

