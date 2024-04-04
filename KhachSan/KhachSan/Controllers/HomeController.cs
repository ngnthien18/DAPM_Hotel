using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using KhachSan.Models.DB;

namespace HotelManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult sendmail()
        {
           
            
            return View();
        }
        [HttpPost]
        public ActionResult sendmail(KhachSan.Models.MailModel _objModelMail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(_objModelMail.To);
                    //mail.From = new MailAddress(_objModelMail.From);
                    mail.From = new MailAddress("hotelservcies@gmail.com", "hotel");
                    mail.Subject = _objModelMail.Subject;
                    string Body = _objModelMail.Body;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;

                    smtp.Credentials = new NetworkCredential("hotelservcies@gmail.com", "hotelservcies007");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    return View("sendmail");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View("sendmail");
            }
          
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_user objuser)
        {
            KhachSanEntities db = new KhachSanEntities();

            var user = db.tbl_user.Where(x => x.email == objuser.email && x.user_password == objuser.user_password).FirstOrDefault();
            ViewBag.u = user;
            try
            {
            ViewBag.email = user.email;
            ViewBag.password = user.user_password;
                Session["Name"] = user.username;
            }
            catch (Exception)
            {

                
            }
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LoginCus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCus(tbl_customer objcus)
        {
            KhachSanEntities db = new KhachSanEntities();

            var cus = db.tbl_customer.Where(x => x.emailcus == objcus.emailcus && x.cus_password == objcus.cus_password).FirstOrDefault();
            ViewBag.u = cus;
            try
            {
                ViewBag.email = cus.emailcus;
                ViewBag.password = cus.cus_password;
                Session["Id"] = cus.cus_id;
                Session["CusName"] = cus.cusname;
            }
            catch (Exception)
            {


            }
            if (cus != null)
            {
                return RedirectToAction("Home", "View");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(tbl_customer cus, string rePass)
        {
            KhachSanEntities db = new KhachSanEntities();
            if (ModelState.IsValid)
            {
                var checkEmail = db.tbl_customer.FirstOrDefault(c => c.emailcus == cus.emailcus);
                if (checkEmail != null)
                {
                    ViewBag.ThongBaoEmail = "Đã có tài khoản đăng nhập bằng Email này";
                    return View();
                }
                if (cus.cus_password == rePass)
                {
                    db.tbl_customer.Add(cus);
                    db.SaveChanges();
                    return RedirectToAction("Home", "View");
                }
                else
                {
                    ViewBag.ThongBao = "Mật khẩu xác nhận không chính xác";
                    return View();
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["CusName"] = null;
            Session["Id"] = null;

            return RedirectToAction("Home", "View");
        }

    }
}
