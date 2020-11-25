using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using StudentMS.Model;

namespace StudentMS.BLL
{
    public class Core
    {

        public static string strUserRight = ",";//保存用户的所有权限
        private StudentMS.DAL.Core dal = new DAL.Core();//实例化DAL层的Core

        public Core()
        {
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public void getConnectionString()
        {
            dal.getConnectionString();
        }

        ///<summary>
        ///功能：依据学号和姓名获取学生档案数据列表
        ///参数:SNO-学号，SName-姓名
        ///版本：2020-10-15 by 李旭
        public DataSet GetListStudent(string SNO, string SName)
        {
            return dal.GetListStudent(SNO, SName);
        }

        public DataSet GetListTeacher(string TNO, string TName)
        {
            return dal.GetListTeacher(TNO, TName);
        }

        ///<summary>
        ///功能：依据学号获取该学生已选或未选课程表
        ///参数:SNO学号，flag  1表示已选  2表示未选
        ///版本：2020-10-15 by 李旭
        public DataSet GetListSC(string SNO,int flag)
        {
            if (flag == 1)
                return dal.GetListSC(SNO);
            else
                return dal.GetListSCNot(SNO);
        }
        ///<summary>
        ///功能：依据工号获取该教师已开或未开课程表
        ///参数:TNO工号，flag  1表示已开  2表示未开
        ///版本：2020-10-15 by 李旭
        public DataSet GetListTC(string TNO, int flag)
        {
            if (flag == 1)
                return dal.GetListTC(TNO);
            else
                return dal.GetListTCNot(TNO);
        }

        
        ///功能：依据UserID和PassWord校验用户是否存在
        ///参数: UserID - 用户名  PassWord - 密码
        ///版本：2020-10-21 by 李旭
        public bool ExistsUser(string UserID, string UPassword)
        {
            return dal.ExistsUser(UserID, UPassword);
        }

        ///功能：依据UserID模糊查询用户信息
        ///参数: UserID - 用户名
        ///版本：2020-10-21 by 李旭
        public DataSet GetListUser(string UserID)
        {
            return dal.GetListUser(UserID);
        }

        ///功能：依据UserID获取该用户角色
        ///参数: UserID - 用户名
        ///版本：2020-10-21 by 李旭
        public DataSet GetListU_R(string UserID)
        {
            return dal.GetListU_R(UserID);
        }

        ///功能：依据UserID删除该用户所有角色
        ///参数: UserID - 用户名
        ///版本：2020-10-21 by 李旭
        public int DeleteRoleByUser(string UserID)
        {
            return dal.DeleteRoleByUser(UserID);
        }

        ///功能：依据RoleID获取所有权限和该角色权限
        ///参数: RoleID - 角色编号
        ///版本：2020-10-28 by 李旭
        public DataSet GetListRoleRight(string RoleID)
        {
            return dal.GetListRoleRight(RoleID);
        }

        ///功能：依据UserID获取该用户权限
        ///参数: UserID - 用户名
        ///版本：2020-10-29 by 李旭
        public void GetListUserRight(string UserID)
        {
            strUserRight = ",";//初始化
            DataTable tableRight = dal.GetListUserRight(UserID).Tables[0];
            //遍历所有行把用户UserID的所有权限存放到全局静态变量strUserRight中
            foreach (DataRow row in tableRight.Rows)
            {
                strUserRight += row["FunctionID"].ToString() + ",";
            }
        }

        ///功能：依据UserID判断登陆的用户是否拥有该权限
        ///参数: FunctionID - 权限编号
        ///版本：2020-10-29 by 李旭
        public static bool IsHaveRight(string FunctionID)
        {
            return strUserRight.Contains("," + FunctionID + ",");
        }

        ///功能：依据RoleID获取该权限信息
        ///参数: RoleID - 权限编号
        ///版本：2020-10-29 by 李旭
        public DataSet GetListRole()
        {
            return dal.GetListRole();
        }

        ///功能：依据RoleID获取该权限信息
        ///参数: RoleID - 权限编号
        ///版本：2020-10-29 by 李旭
        public DataSet GetListCourse(String CNO,String CName)
        {
            return dal.GetListCourse(CNO,CName);
        }

        ///功能：依据CNO获取该权限信息
        ///参数: CNO - 课程编号
        ///版本：2020-11-19 by 李旭
        public DataSet GetListS_C(string CNO)
        {
            return dal.GetListS_C(CNO);
        }


        ///功能：依据SNO获取该权限信息
        ///参数: SNO - 学号
        ///版本：2020-11-19 by 李旭
        public DataSet GetListSS(string SNO)
        {
            return dal.GetListSS(SNO);
        }

        ///功能：依据CNO获取该课程统计信息
        ///参数: CNO - 课程号
        ///版本：2020-11-19 by 李旭
        public DataSet GetListTJ()
        {
            return dal.GetListTJ();
        }
    }
}
