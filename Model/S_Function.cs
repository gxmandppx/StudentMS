using System;
namespace StudentMS.Model
{
	/// <summary>
	/// S_Function:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class S_Function
	{
		public S_Function()
		{}
		#region Model
		private string _functionid;
		private string _functionname;
		/// <summary>
		/// 
		/// </summary>
		public string FunctionID
		{
			set{ _functionid=value;}
			get{return _functionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FunctionName
		{
			set{ _functionname=value;}
			get{return _functionname;}
		}
		#endregion Model

	}
}

