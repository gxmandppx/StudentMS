using System;
namespace StudentMS.Model
{
	/// <summary>
	/// S_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class S_User
	{
		public S_User()
		{}
		#region Model
		private string _userid;
		private string _upassword;
		private string _sno;
		private string _tno;
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UPassWord
		{
			set{ _upassword=value;}
			get{return _upassword;}
		}
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
		public string TNO
		{
			set{ _tno=value;}
			get{return _tno;}
		}
		#endregion Model

	}
}

