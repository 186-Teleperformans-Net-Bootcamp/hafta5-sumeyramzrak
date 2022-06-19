using Teleperformance.Odev4.Data.Context;
using Teleperformance.Odev4.Data.Dto;
using Teleperformance.Odev4.Entity;
using Teleperformance.Odev4.Services.Abstractions;

namespace Teleperformance.Odev4.Services.Concretes
{
    internal class UserService : IUserService
    {
        private readonly TlpDbContext _context;

        public void AddSeedUserData()
        {
            ICollection<User> userData = new List<User>();
            _context.Set<User>().AddRange(
                    new User
                    {
                        UserName = "Monica",
                        Email = "m123@gmail.com",
                        Password = "1234",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        IsActive = true
                    },
                    new User
                    {
                        UserName = "Ross",
                        Email = "r123@gmail.com",
                        Password = "1234",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        IsActive = true
                    },
                    new User
                    {
                        UserName = "Rachel",
                        Email = "r456@gmail.com",
                        Password = "1234",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        IsActive = true
                    },
                    new User
                    {
                        UserName = "Chandler",
                        Email = "c123@gmail.com",
                        Password = "1234",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        IsActive = true
                    });

            _context.Users.AddRange(userData);

            _context.SaveChanges();

        }

        public UserService(TlpDbContext context)
        {
            _context = context;
        }

        public List<GetAllUserDto> GetAllUsers()
        {
            var data = _context.Users.Select(x => new GetAllUserDto
            {
                UserName = x.UserName,
                Email = x.Email,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted
            }).ToList();

            return data;
        }

        public List<PagedListUserDto> PagedListUsers(int page, int count)
        {
            AddSeedUserData();
            var data = _context.Users.Skip((page - 1) * count)
                                      .Take(count)
                                      .Select(x => new PagedListUserDto
                                      {
                                          UserName = x.UserName,
                                          Email = x.Email,
                                          IsActive = x.IsActive
                                      }).ToList();

            var totalCount = _context.Users.Skip(page * count).Count();

            var total = data.Count();
            var totalPage = (int)Math.Ceiling(total / (double)count);

            if (page < 1 && page > totalPage)
            {
                return null;
            }
            return data;
        }

        public List<FilterUserDto> FilterUsers(string key)
        {
            var data = _context.Users.Where(x=>x.UserName.StartsWith(key))
                                      .Select(x => new FilterUserDto
                                      {
                                          UserName = x.UserName,
                                          Email = x.Email
                                      }).ToList();
            return data;
        }
    }
}
