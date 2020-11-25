using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;
namespace StudentMS.BLL
{
	/// <summary>
	/// Student
	/// </summary>
	public class Student
	{
		private readonly StudentMS.DAL.Student dal=new StudentMS.DAL.Student();
		public Student()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SNO)
		{
			return dal.Exists(SNO);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudentMS.Model.Student model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(StudentMS.Model.Student model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SNO)
		{
			
			return dal.Delete(SNO);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SNOlist )
		{
			return dal.DeleteList(SNOlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudentMS.Model.Student GetModel(string SNO)
		{
			
			return dal.GetModel(SNO);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public StudentMS.Model.Student GetModelByCache(string SNO)
		{
			
			string CacheKey = "StudentModel-" + SNO;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SNO);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (StudentMS.Model.Student)objModel;
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
		public List<StudentMS.Model.Student> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudentMS.Model.Student> DataTableToList(DataTable dt)
		{
			List<StudentMS.Model.Student> modelList = new List<StudentMS.Model.Student>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudentMS.Model.Student model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudentMS.Model.Student();
					model.SNO=dt.Rows[n]["SNO"].ToString();
					model.SName=dt.Rows[n]["SName"].ToString();
					model.SSex=dt.Rows[n]["SSex"].ToString();
					if(dt.Rows[n]["SBirthday"].ToString()!="")
					{
						model.SBirthday=DateTime.Parse(dt.Rows[n]["SBirthday"].ToString());
					}
					model.DeptNO=dt.Rows[n]["DeptNO"].ToString();
					if(dt.Rows[n]["SAge"].ToString()!="")
					{
						model.SAge=int.Parse(dt.Rows[n]["SAge"].ToString());
					}
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

