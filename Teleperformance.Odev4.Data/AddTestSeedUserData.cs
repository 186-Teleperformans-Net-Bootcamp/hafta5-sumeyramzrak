using Teleperformance.Odev4.Data.Context;
using Teleperformance.Odev4.Entity;

namespace Teleperformance.Odev4.Data
{
    public class AddTestSeedUserData
    {
        public void AddSeedUserData(TlpDbContext dbContext)
        {
            dbContext.Set<User>().AddRange(
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
            dbContext.SaveChanges();
                
        }


    }

}
