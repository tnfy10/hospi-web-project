﻿using hospi_web_project.Models;
using hospi_web_project.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospi_web_project.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Windows()
        {
            return View();
        }

        public IActionResult Android()
        {
            return View();
        }

        public IActionResult Download()
        {
            return View();
        }

        public IActionResult Purchase()
        {
            DBService dbService = HttpContext.RequestServices.GetService(typeof(DBService)) as DBService;
            ProductService context = new(dbService);

            return View(context.GetProductList());
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult PaymentProcess(PaymentViewModel model)
        {
            DBService dbService = HttpContext.RequestServices.GetService(typeof(DBService)) as DBService;
            PaymentService context = new(dbService);

            context.PaymentProcess(model);

            return RedirectToAction("PaymentSuccess", "Product");
        }

        public ActionResult DownloadFile(string filePath)
        {
            string fullName = @"C:\hospi\files\" + filePath;

            byte[] fileBytes = GetFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
    }
}
