using System;
namespace StudentMS.Model
{
	/// <summary>
	/// S_C:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class S_C
	{
		public S_C()
		{}
		#region Model
		private string _sno;
		private string _cno;
		private decimal? _score;
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
		public string CNO
		{
			set{ _cno=value;}
			get{return _cno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

