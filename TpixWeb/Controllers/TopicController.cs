using System;
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
    public class TopicController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITopicRepository _topicRepository;

        public TopicController(IMemberRepository memberRepository,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITopicRepository topicRepository)
        {
            _memberRepository = memberRepository;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _topicRepository = topicRepository;
        }

        [Route("t/{topicId}")]
        public async Task<IActionResult> Index(int topicId)
        {
            var vm = new TopicViewModel();

            vm.CurrentTopic = await _topicRepository.GetTopic(topicId);
            vm.Posts = await _postRepository.GetPostsByTopicId(topicId);

            return View(vm);
        }
    }
}
