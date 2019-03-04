using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IRestClient _restClient;
        private string baseUrl;
        public MemberRepository(IRestClient restClient, IConfiguration configuration)
        {
            _restClient = restClient;
            baseUrl = configuration.GetSection("ApiUrl").Value + "/members/";

        }
        string method = "/members/";

        public Task<Member> AddMember(Member member)
        {
            return _restClient.PostAsync<Member>($"{baseUrl}", member);
        }

        public Task<Member> DeleteMember(int id)
        {
            return _restClient.DeleteAsync<Member>($"{baseUrl}{id}");
        }

        public Task EditMember(Member member)
        {
            return _restClient.PutAsync<bool>($"{baseUrl}", member);
        }

        public Task<List<Member>> GetAllMembers()
        {
            return _restClient.GetAsync<List<Member>>($"{baseUrl}");
        }

        public Task<Member> GetMemberById(int id)
        {
            return _restClient.GetAsync<Member>($"{baseUrl}{id}");
        }

        public Task<List<Member>> SearchMembers(Member member)
        {
            //TODO: Check this!
            return _restClient.GetAsync<List<Member>>($"{baseUrl}", member);
        }
    }
}
