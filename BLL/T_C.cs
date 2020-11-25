using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// T_C
	/// </summary>
	public class T_C
	{
		private readonly StudentMS.DAL.T_C dal=new StudentMS.DAL.T_C();
		public T_C()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TNO,string CNO)
		{
			return dal.Exists(TNO,CNO);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.T_C model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.T_C model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string TNO,string CNO)
		{
			
			return dal.Delete(TNO,CNO);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudentMS.Model.T_C GetModel(string TNO,string CNO)
		{
			
			return dal.GetModel(TNO,CNO);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public StudentMS.Model.T_C GetModelByCache(string TNO,string CNO)
		{
			
			string CacheKey = "T_CModel-" + TNO+CNO;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TNO,CNO);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.T_C)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudentMS.Model.T_C> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudentMS.Model.T_C> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.T_C> modelList = new List<StudentMS.Model.T_C>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.T_C model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.T_C();
					model.TNO=dt.Rows[n]["TNO"].ToString();
					model.CNO=dt.Rows[n]["CNO"].ToString();
					model.TeachAddress=dt.Rows[n]["TeachAddress"].ToString();
					model.TeachTime=dt.Rows[n]["TeachTime"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

