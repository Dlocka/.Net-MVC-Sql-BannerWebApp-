using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWork.DAL;
using MVCWork.DAL.Users;
using MVCWork.Models;
namespace MVCWork.BLL
{
    public class IDCardTypeManager
    {
        public List<IDCardType_Model> GetIDCardTypeList()
        {
            UserInfoService userInfoService = new UserInfoService();
            List<IDCardType> list = userInfoService.GetIDCardTypes();
            List<IDCardType_Model> iDCardType_Models = new List<IDCardType_Model>();
            foreach (var item in list)
            {
                IDCardType_Model idCardType_Model = new IDCardType_Model();
                idCardType_Model.IDCardTypeID = item.IDCardTypeID;
                idCardType_Model.CardType = item.CardType;
                iDCardType_Models.Add(idCardType_Model);
            }
            return iDCardType_Models;
        }
    }
}
