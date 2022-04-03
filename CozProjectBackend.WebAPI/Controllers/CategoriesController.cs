using CozProjectBackend.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryReadService _categoryReadService;
        private readonly ICategoryWriteService _categoryWriteService;

        public CategoriesController(ICategoryWriteService categoryWriteService, ICategoryReadService categoryReadService)
        {
            _categoryWriteService = categoryWriteService;
            _categoryReadService = categoryReadService;
        }
    }
}
