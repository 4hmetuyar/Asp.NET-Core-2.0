using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Apstract;
using Abc.Northwind.WebUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Abc.Northwind.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent //View Component olabilmesi için ViewComponentden türüyor olması gerekmektedir.
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke(str)
        {
            var model = new CategoryListViewModel
            {
                Categories =_categoryService.GetAll()
            };
            return View(model);
        }
    }
}
