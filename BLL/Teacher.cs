using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// Teacher
	/// </summary>
	public class Teacher
	{
		private readonly StudentMS.DAL.Teacher dal=new StudentMS.DAL.Teacher();
		public Teacher()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TNO)
		{
			return dal.Exists(TNO);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.Teacher model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.Teacher model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string TNO)
		{
			
			return dal.Delete(TNO);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TNOlist )
		{
			return dal.DeleteList(TNOlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudentMS.Model.Teacher GetModel(string TNO)
		{
			
			return dal.GetModel(TNO);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public StudentMS.Model.Teacher GetModelByCache(string TNO)
		{
			
			string CacheKey = "TeacherModel-" + TNO;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TNO);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.Teacher)objModel;
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
		public List<StudentMS.Model.Teacher> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudentMS.Model.Teacher> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.Teacher> modelList = new List<StudentMS.Model.Teacher>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.Teacher model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.Teacher();
					model.TNO=dt.Rows[n]["TNO"].ToString();
					model.TName=dt.Rows[n]["TName"].ToString();
					model.TSex=dt.Rows[n]["TSex"].ToString();
					if(dt.Rows[n]["TAge"].ToString()!="")
					{
						model.TAge=int.Parse(dt.Rows[n]["TAge"].ToString());
					}
					model.TAddress=dt.Rows[n]["TAddress"].ToString();
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

