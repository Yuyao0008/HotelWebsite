using System;
using FIT5032_Assign1_v6.Models;
using FIT5032_Assign1_v6.Email;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.ComponentModel.DataAnnotations;


namespace FIT5032_Assign1_v6.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            return View(new SendEmail());
        }


        [HttpPost]
        public ActionResult Contact(SendEmail mailSender)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var message = new MailMessage();
                    message.From = new MailAddress("ihotelnotification@gmail.com");
                    message.To.Add(new MailAddress(mailSender.ToEmail));
                    message.Subject = mailSender.Subject;
                    message.Body = mailSender.Contents;
                    message.IsBodyHtml = true;

                    if (mailSender.fileUploader != null)
                    {
                        string fileName = Path.GetFileName(mailSender.fileUploader.FileName);
                        message.Attachments.Add(new Attachment(mailSender.fileUploader.InputStream, fileName));
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    NetworkCredential net = new NetworkCredential("ihotelnotification@gmail.com", "iHotel321");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = net;

                    smtp.Send(message);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();
                    return View(new SendEmail());
                }

                catch
                {
                    return View();
                }
            }
            return View();
        }

    }
    }