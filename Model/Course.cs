using System;
namespace StudentMS.Model
{
	/// <summary>
	/// Course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Course
	{
		public Course()
		{}
		#region Model
		private string _cno;
		private string _cname;
		private decimal? _credit;
		private string _cfirst;
		/// <summary>
		/// 
		/// </summary>
		public string CNO
		{
			set{ _cno=value;}
			get{return _cno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CFirst
		{
			set{ _cfirst=value;}
			get{return _cfirst;}
		}
		#endregion Model

	}
}

