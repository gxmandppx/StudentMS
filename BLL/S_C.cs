using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// S_C
	/// </summary>
	public class S_C
	{
		private readonly StudentMS.DAL.S_C dal=new StudentMS.DAL.S_C();
		public S_C()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string SNO,string CNO)
		{
			return dal.Exists(SNO,CNO);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(StudentMS.Model.S_C model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(StudentMS.Model.S_C model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string SNO,string CNO)
		{
			
			return dal.Delete(SNO,CNO);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public StudentMS.Model.S_C GetModel(string SNO,string CNO)
		{
			
			return dal.GetModel(SNO,CNO);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public StudentMS.Model.S_C GetModelByCache(string SNO,string CNO)
		{
			
			string CacheKey = "S_CModel-" + SNO+CNO;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SNO,CNO);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.S_C)objModel;
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
		public List<StudentMS.Model.S_C> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<StudentMS.Model.S_C> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.S_C> modelList = new List<StudentMS.Model.S_C>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.S_C model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.S_C();
					model.SNO=dt.Rows[n]["SNO"].ToString();
					model.CNO=dt.Rows[n]["CNO"].ToString();
					if(dt.Rows[n]["Score"].ToString()!="")
					{
						model.Score=decimal.Parse(dt.Rows[n]["Score"].ToString());
					}
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

