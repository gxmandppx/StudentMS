using System;
namespace StudentMS.Model
{
	/// <summary>
	/// S_R_F:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class S_R_F
	{
		public S_R_F()
		{}
		#region Model
		private string _roleid;
		private string _functionid;
		/// <summary>
		/// 
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FunctionID
		{
			set{ _functionid=value;}
			get{return _functionid;}
		}
		#endregion Model

	}
}

