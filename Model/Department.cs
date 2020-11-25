using System;
namespace StudentMS.Model
{
	/// <summary>
	/// Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Department
	{
		public Department()
		{}
		#region Model
		private string _deptno;
		private string _deptname;
		/// <summary>
		/// 
		/// </summary>
		public string DeptNO
		{
			set{ _deptno=value;}
			get{return _deptno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		#endregion Model

	}
}

