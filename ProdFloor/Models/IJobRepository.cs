using System.Linq;

namespace ProdFloor.Models
{
    public interface IJobRepository
    {
        IQueryable<Job> Jobs { get; }
        IQueryable<JobExtension> JobsExtensions { get; }
        IQueryable<HydroSpecific> HydroSpecifics { get; }
        IQueryable<GenericFeatures> GenericFeaturesList { get; }


        void SaveJob(Job job);
        void SaveJobExtension(JobExtension jobExtension);
        void SaveHydroSpecific(HydroSpecific hydroSpecific);
        void SaveGenericFeatures(GenericFeatures genericFeatures);

        Job DeleteJob(int jobID);
        JobExtension DeleteJobExtension(int jobExtensionID);
        HydroSpecific DeleteHydroSpecific(int hydroSpecificID);
        GenericFeatures DeleteGenericFeatures(int genericFeaturesID);
    }
}
