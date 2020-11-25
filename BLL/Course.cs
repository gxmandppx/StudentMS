using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// Course
	/// </summary>
	public class Course
	{
		private readonly StudentMS.DAL.Course dal=new StudentMS.DAL.Course();
		public Course()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string CNO)
		{
			return dal.Exists(CNO);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.Course model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.Course model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string CNO)
		{
			
			return dal.Delete(CNO);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string CNOlist )
		{
			return dal.DeleteList(CNOlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.Course GetModel(string CNO)
		{
			
			return dal.GetModel(CNO);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public StudentMS.Model.Course GetModelByCache(string CNO)
		{
			
			string CacheKey = "CourseModel-" + CNO;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CNO);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.Course)objModel;
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
		public List<StudentMS.Model.Course> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<StudentMS.Model.Course> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.Course> modelList = new List<StudentMS.Model.Course>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.Course model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.Course();
					model.CNO=dt.Rows[n]["CNO"].ToString();
					model.CName=dt.Rows[n]["CName"].ToString();
					if(dt.Rows[n]["Credit"].ToString()!="")
					{
						model.Credit=decimal.Parse(dt.Rows[n]["Credit"].ToString());
					}
					model.CFirst=dt.Rows[n]["CFirst"].ToString();
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

