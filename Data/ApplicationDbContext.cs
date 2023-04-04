using Microsoft.EntityFrameworkCore;
using users;
   // dotnet new webapi -n AliFoum -f net6.0
namespace Repo.Data{
    public class ApplicationDbContext : DbContext{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        public DbSet<UserLogin> userLogins { get; set; }
        public DbSet<UserInfo> userInfos { get; set; }

    }
}