using System;
namespace StudentMS.Model
{
	/// <summary>
	/// Student:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Student
	{
		public Student()
		{}
		#region Model
		private string _sno;
		private string _sname;
		private string _ssex="��";
		private DateTime? _sbirthday;
		private string _deptno;
		private int? _sage;
		/// <summary>
		/// 
		/// </summary>
		public string SNO
		{
			set{ _sno=value;}
			get{return _sno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SSex
		{
			set{ _ssex=value;}
			get{return _ssex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SBirthday
		{
			set{ _sbirthday=value;}
			get{return _sbirthday;}
		}
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
		public int? SAge
		{
			set{ _sage=value;}
			get{return _sage;}
		}
		#endregion Model

	}
}

