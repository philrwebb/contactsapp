using System.Threading.Tasks;
using Sustain.Entities;
namespace Sustain.Services
{

    public interface ISchoolRepository
    {
        Task<bool> SaveChangesAsync();

        Task<School> CreateSchoolAsync(School school);
        
    }
}