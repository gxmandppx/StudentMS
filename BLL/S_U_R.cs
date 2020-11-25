using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// S_U_R
	/// </summary>
	public class S_U_R
	{
		private readonly StudentMS.DAL.S_U_R dal=new StudentMS.DAL.S_U_R();
		public S_U_R()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID,string RoleID)
		{
			return dal.Exists(UserID,RoleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.S_U_R model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.S_U_R model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string UserID,string RoleID)
		{
			
			return dal.Delete(UserID,RoleID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudentMS.Model.S_U_R GetModel(string UserID,string RoleID)
		{
			
			return dal.GetModel(UserID,RoleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public StudentMS.Model.S_U_R GetModelByCache(string UserID,string RoleID)
		{
			
			string CacheKey = "S_U_RModel-" + UserID+RoleID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID,RoleID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.S_U_R)objModel;
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
		public List<StudentMS.Model.S_U_R> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudentMS.Model.S_U_R> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.S_U_R> modelList = new List<StudentMS.Model.S_U_R>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.S_U_R model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.S_U_R();
					model.UserID=dt.Rows[n]["UserID"].ToString();
					model.RoleID=dt.Rows[n]["RoleID"].ToString();
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

