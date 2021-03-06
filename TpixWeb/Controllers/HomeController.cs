﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpixWeb.Models;
using TpixWeb.Models.ViewModels;
using TpixWeb.Services;

namespace TpixWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITopicRepository _topicRepository;

        public HomeController(IMemberRepository memberRepository,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITopicRepository topicRepository)
        {
            _memberRepository = memberRepository;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _topicRepository = topicRepository;
        }


        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel();

            vm.Categories = await _categoryRepository.GetAllCategories();

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
