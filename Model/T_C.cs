using System;
namespace StudentMS.Model
{
	/// <summary>
	/// T_C:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_C
	{
		public T_C()
		{}
		#region Model
		private string _tno;
		private string _cno;
		private string _teachaddress;
		private string _teachtime;
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
		public string CNO
		{
			set{ _cno=value;}
			get{return _cno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeachAddress
		{
			set{ _teachaddress=value;}
			get{return _teachaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeachTime
		{
			set{ _teachtime=value;}
			get{return _teachtime;}
		}
		#endregion Model

	}
}

