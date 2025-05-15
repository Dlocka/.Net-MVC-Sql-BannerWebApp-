using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWork.Web.Filters;
using MVCWork.Web.Models;
using MVCWork.BLL;
using MVCWork.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace MVCWork.Web.Controllers
{
    [UserLoginFilter]
    public class UsersController : Controller
    {
        
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public static List<SelectListItem> GetKindList<Model, TText, TValue>(List<Model> list,Expression<Func<Model, TText>> textProperty, Expression<Func<Model, TValue>> valueProperty)
        {
            var textProp = GetPropertyInfo(textProperty);
            var valueProp = GetPropertyInfo(valueProperty);

            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var item in list)
            {
                string text = textProp.GetValue(item)?.ToString();
                string value = valueProp.GetValue(item)?.ToString();

                selectList.Add(new SelectListItem { Text = text, Value = value });
            }

            return selectList;
        }

        private static PropertyInfo GetPropertyInfo<Model, T>(Expression<Func<Model, T>> propertyExpression)
        {
            MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression is not a member access", nameof(propertyExpression));
            }

            PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("Member access is not a property", nameof(propertyExpression));
            }

            return propertyInfo;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            // Store the previous URL in TempData to redirect back after registration
            TempData["ReturnUrl"] = Request.UrlReferrer?.ToString();
            IDCardTypeManager iDCardTypeManager = new IDCardTypeManager();
            List<IDCardType_Model> iDCardTypes = new List<IDCardType_Model>();
            iDCardTypes = iDCardTypeManager.GetIDCardTypeList();
            List<SelectListItem> selectList = GetKindList(iDCardTypes, m => m.CardType, m => m.IDCardTypeID);
            ViewData["IDCardTypeList"] = selectList;
            return View(new UserModel_Web());
        }

        [AllowAnonymous]
        public ActionResult RegisterCheck(UserModel_Web UserInfos_Model)
        {
            string returnUrl = TempData["ReturnUrl"] as string;
            if (ModelState.IsValid)
            {
                
                UserInfoManager userInfoManager= new UserInfoManager();
                UserInfos_Model userInfo_BLL = new UserInfos_Model()
                {
                    Email = UserInfos_Model.Email,
                    PhoneNumber = UserInfos_Model.PhoneNumber,
                    UserIDCard = UserInfos_Model.UserIDCard,
                    IDCardTypeID =UserInfos_Model.IDCardTypeID,
                    UserName = UserInfos_Model.UserName,
                    Password = UserInfos_Model.Password_ConfirmInput,
                };
                bool IsSuecess=userInfoManager.Register(userInfo_BLL);
                if(IsSuecess)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        // Redirect to a default page if no ReturnUrl is stored
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                else { return View("Register"); }
            }
            else
            {
                //数据验证不成功，停留在注册页面
                return RedirectToAction("Register", "Users");
            }
            
        }

        [AllowAnonymous]
        public ActionResult LoginSubmit(UserLogin userLogin)
        {

            UserInfos_Model userInfos_Model= new UserInfos_Model() { UserName = userLogin.UserName, Password = userLogin.Password };
            UserInfoManager userInfoManager = new UserInfoManager();
            
            bool IsLoginSucess= userInfoManager.Login(userInfos_Model);
            if(IsLoginSucess)
            {
                Session["users"] = userInfos_Model;
                string FromUrl = Request.UrlReferrer.ToString();
                return Redirect(Request.UrlReferrer.ToString());
            }
            return View("~Home/Index");
        }
    }
}