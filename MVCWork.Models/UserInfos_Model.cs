using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWork.Models
{
    public class UserInfos_Model
    {
        public int UserId { get; set; }
        public int IDCardTypeID { get; set; }
        public string Password { get; set; }
        public int UserIDCard { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // 不包含Password属性以确保安全
        // CreateTime属性可选
        public TimeSpan? CreateTime { get; set; }

        // 如果需要显示关联的IDCardType信息，可以包含以下属性
        public IDCardType_Model IDCardType { get; set; }

        // 如果需要显示关联的Orders、ProductLists等信息，可以包含以下属性
   }
    
}
