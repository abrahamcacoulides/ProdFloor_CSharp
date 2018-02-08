using System.Linq;

namespace ProdFloor.Models
{
    public interface IJobRepository
    {
        IQueryable<Job> Jobs { get; }
        IQueryable<JobExtension> JobsExtensions { get; }

        void SaveJob(Job job);
        void SaveJobExtension(JobExtension jobExtension);

        Job DeleteJob(int jobID);
        JobExtension DeleteJobExtension(int jobExtensionID);
    }
}
