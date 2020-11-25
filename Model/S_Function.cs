using System;
namespace StudentMS.Model
{
	/// <summary>
	/// S_Function:实体类(属性说明自动提取数据库字段的描述信息)
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

