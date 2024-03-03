﻿using BusinessLayerr.Concrete;
using BusinessLayerr.ValidationRules;
using DataAccesssLayer.Abstract;
using DataAccesssLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator= new MessageValidator();

        public ActionResult Inbox() //contactcontroller indexinde gelen mesajlar inboxla tutulduğu için
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox() 
        { 
            var messageList= mm.GetListSendbox();
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p) 
        {

            ValidationResult results = messagevalidator.Validate(p); //fluentvalidation ile kullanılacak
            if (results.IsValid)
            {
                p.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

    }
}