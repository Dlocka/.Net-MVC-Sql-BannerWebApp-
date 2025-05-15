using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWork.Models;
namespace MVCWork.DAL.Users
{
    public class UserInfoService
    {
        public List<IDCardType> GetIDCardTypes()
        {
            List<IDCardType> iDCardTypes = new List<IDCardType>();
            using (ElectronicMarketEntities electronicMarketEntities = new ElectronicMarketEntities())
            {
                var list = electronicMarketEntities.IDCardType.ToList();
                foreach (var item in list)
                {
                    IDCardType cardType = new IDCardType();
                    cardType.IDCardTypeID = item.IDCardTypeID;
                    cardType.CardType = item.CardType;
                    iDCardTypes.Add(cardType);
                }
            }
            return iDCardTypes;
        }
        public bool Register(UserInfos_Model userInfos_BLL)
        {
            using (ElectronicMarketEntities electronicMarketEntities = new ElectronicMarketEntities())
            {
                UserInfos userInfo = new UserInfos()
                {
                    UserIDCard = userInfos_BLL.UserIDCard,
                    Email = userInfos_BLL.Email,
                    UserName = userInfos_BLL.UserName,
                    Password = userInfos_BLL.Password,
                    PhoneNumber = userInfos_BLL.PhoneNumber,
                    IDCardTypeID = userInfos_BLL.IDCardTypeID
                };
                electronicMarketEntities.UserInfos.Add(userInfo);
                if(electronicMarketEntities.SaveChanges()>0)
                {
                    return true;
                }
                else { return false; }
            }
            
        }
        public bool Login(UserInfos userInfosFromBLL)
        {
            using (ElectronicMarketEntities electronicMarketEntities = new ElectronicMarketEntities())
            {
                try { 
                UserInfos userInfos = electronicMarketEntities.UserInfos.Single(m => m.UserName == userInfosFromBLL.UserName);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
  
        }
    }
}
