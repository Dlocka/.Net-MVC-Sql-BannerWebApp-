using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWork.Models;
using MVCWork.DAL;
using MVCWork.DAL.Users;
namespace MVCWork.BLL
{
    public class UserInfoManager
    {
        public bool Register(UserInfos_Model userInfos)
        {
            UserInfoService userInfoService = new UserInfoService();
           bool IsChanged= userInfoService.Register(userInfos);
            return IsChanged;
        }
        public bool Login(UserInfos_Model userLogin)
        {
            UserInfos userInfos= new UserInfos() { UserName = userLogin.UserName, Password=userLogin.Password};
            UserInfoService userInfoService = new UserInfoService();
            bool IsLoginSuccess=userInfoService.Login(userInfos);
            return IsLoginSuccess;
            
        }
    }
}
