using System.Linq;

namespace ProdFloor.Models
{
    public interface IJobRepository
    {
        IQueryable<Job> Jobs { get; }

        void SaveJob(Job job);

        Job DeleteJob(int jobID);
    }
}
