using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 *协议规则:
 * 查询学生请求:#query_stu#[StuInfo.type]#param
 * 登录验证请求:#login#adminName#pw
 * 查询所有学生:#query_stu_all#
 * 查询所有管理员:#query_admin_all#
 * 插入学生信息:#insert_stu#[sno]#[sname]#[ssex]#[sclass]
 * 插入管理员信息:#insert_admin#[name]#[pwMD5]
 * 删除学生:#delete_stu#[sno]
 * 删除管理员:#delete_admin#[name]
 * 更新管理员密码:#update_admin_pw#[name]#[oldpwMD5]#[newpwMD5]
 * 有新的登录，所以当前登录被迫下线:#new_login#
 * 请求下线:#request_offline#[name]

 * 特殊符号的转换：
 * / -> \00
 * # -> \01
 * , -> \02
 */
namespace FateServer
{
    class MyProtocol
    {
        public static string head_queryStu = "#query_stu#";
        public static string head_login = "#login#";
        public static string head_queryStuAll = "#query_stu_all#";
        public static string head_queryAdminAll = "#query_admin_all#";
        public static string head_insertStu = "#insert_stu#";
        public static string head_insertAdmin = "#insert_admin#";
        public static string head_deleteStu = "#delete_stu#";
        public static string head_deleteAdmin = "#delete_admin#";
        public static string head_updateAdminPw = "#update_admin_pw#";
        public static string head_unlogin = "#unlogin#";
        public static string head_new_login = "#new_login#";
        public static string head_request_offline = "#request_offline#";

        public static string body_true = "true";
        public static string body_false = "false";
        public static string body_success = "success";
        public static string body_denied = "denied";
        public static string body_exists = "exists";
        public static string body_notExists = "notExists";
    }
}
