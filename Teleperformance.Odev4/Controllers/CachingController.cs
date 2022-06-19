using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Teleperformance.Odev4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachingController : ControllerBase
    {
        private readonly TlpDbContext _context;

        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public CachingController(IMemoryCache memoryCache, IDistributedCache distributedCache,TlpDbContext context)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
            _context = context;
        }

        //Id'ye göre grup üyeleri cache de tutan metot
        [HttpGet("CacheGetGroupMember")]
        [ResponseCache(Duration = 1800, VaryByHeader = "GroupMember", VaryByQueryKeys = new string[] { "MemberID" })]
        public IEnumerable<GroupMember> GetMembers(Guid MemberId)
        {
            GroupMember[] members = _context.GroupMember.Where(x => x.MemberID == MemberId).ToArray();

            if (_memoryCache.TryGetValue("GroupMember", out members))
            {
                return members;
            }

            var groupMemberByts = _distributedCache.Get("GroupMember");
            var groupMemberJson = Encoding.UTF8.GetString(groupMemberByts);
            var groupMemberArr = JsonSerializer.Deserialize<GroupMember[]>(groupMemberJson);

            MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions();
            memoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(3);
            memoryCacheEntryOptions.SlidingExpiration = TimeSpan.FromHours(1);
            memoryCacheEntryOptions.Priority = CacheItemPriority.Normal;

            _memoryCache.Set("Member", members, memoryCacheEntryOptions);

            var dstGroupMemberArr = JsonSerializer.Serialize(members);

            _distributedCache.Set("Member", Encoding.UTF8.GetBytes(dstGroupMemberArr));

            return members;
        }

       

    }
}




