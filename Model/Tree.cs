using System;
namespace StudentMS.Model
{
	/// <summary>
	/// Tree:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tree
	{
		public Tree()
		{}
		#region Model
		private string _tno;
		private string _tname;
		private string _tnoparent;
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
		public string TNOParent
		{
			set{ _tnoparent=value;}
			get{return _tnoparent;}
		}
		#endregion Model

	}
}

