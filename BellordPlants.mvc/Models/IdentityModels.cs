using Microsoft.AspNet.Identity.EntityFramework;

namespace BellordPlants.mvc.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public System.Data.Entity.DbSet<BellordPlants.mvc.Models.TaskList> TaskLists { get; set; }

        public System.Data.Entity.DbSet<BellordPlants.mvc.Models.TaskListItem> TaskListItems { get; set; }

        public System.Data.Entity.DbSet<BellordPlants.mvc.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<BellordPlants.mvc.Models.Answer> Answers { get; set; }
    }
}