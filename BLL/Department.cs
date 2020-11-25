using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// Department
	/// </summary>
	public class Department
	{
		private readonly StudentMS.DAL.Department dal=new StudentMS.DAL.Department();
		public Department()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string DeptNO)
		{
			return dal.Exists(DeptNO);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.Department model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.Department model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string DeptNO)
		{
			
			return dal.Delete(DeptNO);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string DeptNOlist )
		{
			return dal.DeleteList(DeptNOlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.Department GetModel(string DeptNO)
		{
			
			return dal.GetModel(DeptNO);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public StudentMS.Model.Department GetModelByCache(string DeptNO)
		{
			
			string CacheKey = "DepartmentModel-" + DeptNO;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DeptNO);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.Department)objModel;
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
		public List<StudentMS.Model.Department> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<StudentMS.Model.Department> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.Department> modelList = new List<StudentMS.Model.Department>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.Department model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.Department();
					model.DeptNO=dt.Rows[n]["DeptNO"].ToString();
					model.DeptName=dt.Rows[n]["DeptName"].ToString();
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

