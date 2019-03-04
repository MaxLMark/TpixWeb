using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models.ViewModels;
using TpixWeb.Services;

namespace TpixWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITopicRepository _topicRepository;

        public CategoryController(IMemberRepository memberRepository,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITopicRepository topicRepository)
        {
            _memberRepository = memberRepository;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _topicRepository = topicRepository;
        }


        [Route("c/{categoryName}")]
        public async Task<IActionResult> Index(string categoryName, int catId)
        {
            var vm = new CategoryViewModel();
            vm.Topics = await _topicRepository.GetTopicsByCategoryId(catId);

            return View(vm);
        }

    }
}
