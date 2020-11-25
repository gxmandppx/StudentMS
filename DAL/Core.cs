using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace StudentMS.DAL
{
    public class Core
    {
        public Core()
        {
            ///<summary>
            ///功能：依据学号和姓名获取学生档案数据列表
            ///参数
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public void getConnectionString()
        {
            DbHelperSQL.connectionString = "Data Source=localhost;Initial Catalog=sms;"
            + "User ID=gxmandppx;Password=258014;Persist Security Info=True;";
        }

        public DataSet GetListStudent(string SNO,string SName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.SNO,a.SName,a.SSex,a.SAge,b.DeptName, ");
            strSql.Append("convert(varchar(20),a.SBirthday,23) as SBirthday ");
            strSql.Append("from Student a,Department b where a.DeptNO=b.DeptNO");
            if (SNO != "")
                strSql.Append(" and SNO like '%"+SNO + "%'");
            if (SName != "")
                strSql.Append(" and SNO like '%"+SName + "%'");
            
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListTeacher(string TNO, string TName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TNO, TName, TSex, TAge, TAddress from Teacher where 1=1 ");
            
            if (TNO != "")
                strSql.Append("  and TNO like '%" + TNO + "%'");
            if (TName != "")
                strSql.Append("  and TName like '%" + TName + "%'");

            return DbHelperSQL.Query(strSql.ToString());
        }
        ///<summary>
        ///功能：依据学号获取该学生已选课程表
        ///参数:SNO学号
        ///版本：2020-10-15 by 李旭
        public DataSet GetListSC(string SNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CNO,CName,Credit ");
            strSql.Append("from Course where CNO in");
            strSql.Append("(select CNO from S_C where SNO='" + SNO + "')");
            return DbHelperSQL.Query(strSql.ToString());
        }
        ///功能：依据学号获取该学生未选课程表
        ///参数:SNO学号
        ///版本：2020-10-15 by 李旭
        public DataSet GetListSCNot(string SNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CNO,CName,Credit ");
            strSql.Append("from Course where CNO not in");
            strSql.Append("(select CNO from S_C where SNO='" + SNO + "')");
            return DbHelperSQL.Query(strSql.ToString());
        }
        ///<summary>
        ///功能：依据工号获取该教师已开课程
        ///参数:TNO工号
        ///版本：2020-10-15 by 李旭
        public DataSet GetListTC(string TNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CNO,CName,Credit ");
            strSql.Append("from Course where CNO in");
            strSql.Append("(select CNO from T_C where TNO='" + TNO + "')");
            return DbHelperSQL.Query(strSql.ToString());
        }
        ///功能：依据工号获取该教师可开课程
        ///参数:TNO工号
        ///版本：2020-10-15 by 李旭
        public DataSet GetListTCNot(string TNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CNO,CName,Credit ");
            strSql.Append("from Course where CNO not in");
            strSql.Append("(select CNO from T_C where TNO='" + TNO + "')");
            return DbHelperSQL.Query(strSql.ToString());
        }
        ///参数传值，防止SQL注入
        ///功能：依据UserID和PassWord校验用户是否存在
        ///参数: UserID - 用户名  PassWord - 密码
        ///版本：2020-10-21 by 李旭
        public bool ExistsUser(string UserID,string UPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_User");
            strSql.Append(" where UserID=@UserID and UPassWord=@UPassword");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
                    new SqlParameter("@UPassword", SqlDbType.VarChar,10)};
            parameters[0].Value = UserID;
            parameters[1].Value = UPassword;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        ///功能：依据UserID模糊查询用户信息
        ///参数: UserID - 用户名
        ///版本：2020-10-21 by 李旭
        public DataSet GetListUser(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID, UPassWord,SNO,TNO from S_User ");
            if(UserID !="")
                strSql.Append(" where UserID like '%" + UserID + "%'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据UserID获取该用户角色
        ///参数: UserID - 用户名
        ///版本：2020-10-21 by 李旭
        public DataSet GetListU_R(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID from S_U_R ");
            if (UserID != "")
                strSql.Append(" where UserID = '" + UserID + "';");
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据UserID删除该用户所有角色
        ///参数: UserID - 用户名
        ///版本：2020-10-21 by 李旭
        public int DeleteRoleByUser(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_U_R where UserID = '" + UserID + "'");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        ///功能：依据RoleID获取所有权限和该角色权限
        ///参数: RoleID - 角色编号
        ///版本：2020-10-28 by 李旭
        public DataSet GetListRoleRight(string RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.FunctionID,a.FunctionName,b.FunctionID as IfHave from S_Function a ");
            strSql.Append("left join S_R_F b on a.FunctionID = b.FunctionID and b.RoleID = '"+ RoleID + "';");
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据UserID获取该用户权限
        ///参数: UserID - 用户名
        ///版本：2020-10-29 by 李旭
        public DataSet GetListUserRight(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FunctionID from S_R_F where RoleID in  ");
            strSql.Append("(select RoleID from S_U_R where UserID = '" + UserID + "');");
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据RoleID获取该权限信息
        ///参数: RoleID - 权限编号
        ///版本：2020-10-29 by 李旭
        public DataSet GetListRole()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select RoleID,RoleName from S_Role ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据RoleID获取该权限信息
        ///参数: RoleID - 权限编号
        ///版本：2020-10-29 by 李旭
        public DataSet GetListCourse(string CNO, string CName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CNO,CName,Credit,Cfirst ");
            strSql.Append(" from Course where 1=1  ");
            if (CNO != "")
                strSql.Append(" and CNO like '%" + CNO + "%'");
            if (CName != "")
                strSql.Append(" and CName like '%" + CName + "%'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据CNO获取该权限信息
        ///参数: CNO - 课程编号
        ///版本：2020-11-19 by 李旭
        public DataSet GetListS_C(string CNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SNO,CNO,score ");
            strSql.Append(" from S_C ");
            if (CNO != "")
                strSql.Append(" where CNO = '" + CNO + "'");

            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据SNO获取该权限信息
        ///参数: SNO - 学号
        ///版本：2020-11-19 by 李旭
        public DataSet GetListSS(string SNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.CNO,b.CName,a.score  ");
            strSql.Append(" from S_C a,(select CNO,CName from Course) b ");
            strSql.Append(" where a.SNO = '" + SNO + "' and a.CNO = b.CNO;");

            return DbHelperSQL.Query(strSql.ToString());
        }

        ///功能：依据CNO获取该课程统计信息
        ///参数: CNO - 课程号
        ///版本：2020-11-19 by 李旭
        public DataSet GetListTJ()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CName,count(1)member, max(score)max1,avg(score)avg1,min(score)min1 ");
            strSql.Append(" from S_C , Course where S_C.CNO = Course.CNO group by CName ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
