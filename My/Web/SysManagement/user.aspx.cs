using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysManagement
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentMS.BLL.S_User bll = new StudentMS.BLL.S_User();
                this.GridView1.DataSource = bll.GetAllList().Tables[0];//数据源
                this.GridView1.DataBind();//数据绑定
            }
        }
    }
}