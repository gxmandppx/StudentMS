using System;
namespace StudentMS.Model
{
	/// <summary>
	/// T_C:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

