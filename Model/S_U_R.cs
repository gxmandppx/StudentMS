using System;
namespace StudentMS.Model
{
	/// <summary>
	/// S_U_R:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class S_U_R
	{
		public S_U_R()
		{}
		#region Model
		private string _userid;
		private string _roleid;
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
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

