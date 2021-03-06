﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Apstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Abc.Northwind.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
         //   _productService.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            HttpContext.Session.SetString("Hazırlayan","Ahmet");
            HttpContext.Session.SetInt32("Deger",3);

            HttpContext.Session.GetInt32("Deger");
            HttpContext.Session.GetString("Hazırlayan");

            return View();
        }
    }
}
