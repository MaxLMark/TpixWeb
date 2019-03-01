using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixWeb.Models;

namespace TpixWeb.Services
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberById(int id);
        Task<List<Member>> SearchMembers(Member member);
        Task<List<Member>> GetAllMembers();
        Task EditMember(Member member);
        Task<Member> AddMember(Member member);
        Task<Member> DeleteMember(int Id);
    }
}
