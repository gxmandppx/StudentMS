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
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FunctionID)
		{
			return dal.Exists(FunctionID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.S_Function model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.S_Function model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string FunctionID)
		{
			
			return dal.Delete(FunctionID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string FunctionIDlist )
		{
			return dal.DeleteList(FunctionIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudentMS.Model.S_Function GetModel(string FunctionID)
		{
			
			return dal.GetModel(FunctionID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
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
		public List<StudentMS.Model.S_Function> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

