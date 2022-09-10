using MyServer.Data;
using System.Threading.Tasks;

namespace MyServer.Seeder
{
    public interface ISeeder
    {
        void Seed(ApplicationDbContext dbContext);
    }
}
