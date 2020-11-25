using System;
namespace StudentMS.Model
{
	/// <summary>
	/// Teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Teacher
	{
		public Teacher()
		{}
		#region Model
		private string _tno;
		private string _tname;
		private string _tsex;
		private int? _tage;
		private string _taddress;
		/// <summary>
		/// 
		/// </summary>
		public string TNO
		{
			set{ _tno=value;}
			get{return _tno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TSex
		{
			set{ _tsex=value;}
			get{return _tsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TAge
		{
			set{ _tage=value;}
			get{return _tage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TAddress
		{
			set{ _taddress=value;}
			get{return _taddress;}
		}
		#endregion Model

	}
}

