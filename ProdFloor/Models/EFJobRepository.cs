using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProdFloor.Models
{
    public class EFJobRepository : IJobRepository
    {
        private ApplicationDbContext context;

        public EFJobRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Job> Jobs => context.Jobs;

        public IQueryable<JobExtension> JobsExtensions => context.JobsExtensions;

        public void SaveJob(Job job)
        {
            if (job.JobID == 0)
            {
                context.Jobs.Add(job);
            }
            else
            {
                Job dbEntry = context.Jobs
                .FirstOrDefault(p => p.JobID == job.JobID);
                if (dbEntry != null)
                {
                    dbEntry.Name = job.Name;
                    dbEntry.JobNum = job.JobNum;
                    dbEntry.JobType = job.JobType;
                    dbEntry.PO = job.PO;
                    dbEntry.ShipDate = job.ShipDate;
                    dbEntry.Cust = job.Cust;
                    dbEntry.Contractor = job.Contractor;
                    dbEntry.JobState = job.JobState;
                    dbEntry.SafetyCode = job.SafetyCode;
                }
            }
            context.SaveChanges();
        }
        public void SaveJobExtension(JobExtension jobExtension)
        {
            if (jobExtension.JobExtensionID == 0)
            {
                context.JobsExtensions.Add(jobExtension);
            }
            else
            {
                JobExtension dbEntry = context.JobsExtensions
                .FirstOrDefault(p => p.JobExtensionID == jobExtension.JobExtensionID);
                if (dbEntry != null)
                {
                    dbEntry.JobID = jobExtension.JobID;
                    dbEntry.NumOfStops = jobExtension.NumOfStops;
                    dbEntry.JobTypeMain = jobExtension.JobTypeMain;
                    dbEntry.JobTypeAdd = jobExtension.JobTypeAdd;
                    dbEntry.InputVoltage = jobExtension.InputVoltage;
                    dbEntry.InputPhase = jobExtension.InputPhase;
                    dbEntry.InputFrecuency = jobExtension.InputFrecuency;
                    dbEntry.DoorGate = jobExtension.DoorGate;
                    dbEntry.DoorHoist = jobExtension.DoorHoist;
                    dbEntry.InfDetector = jobExtension.InfDetector;
                    dbEntry.MechSafEdge = jobExtension.MechSafEdge;
                    dbEntry.HeavyDoors = jobExtension.HeavyDoors;
                    dbEntry.CartopDoorButtons = jobExtension.CartopDoorButtons;
                    dbEntry.DoorHold = jobExtension.DoorHold;
                    dbEntry.Nudging = jobExtension.Nudging;
                    dbEntry.DoorStyle = jobExtension.DoorStyle;
                    dbEntry.DoorBrand = jobExtension.DoorBrand;
                    dbEntry.DoorModel = jobExtension.DoorModel;
                    dbEntry.SCOP = jobExtension.SCOP;
                    dbEntry.SHC = jobExtension.SHC;
                    dbEntry.SHCRisers = jobExtension.SHCRisers;
                    dbEntry.AUXCOP = jobExtension.AUXCOP;
                }
            }
            context.SaveChanges();
        }

        public Job DeleteJob(int JobID)
        {
            Job dbEntry = context.Jobs
                .FirstOrDefault(p => p.JobID == JobID);
            if (dbEntry != null)
            {
                context.Jobs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public JobExtension DeleteJobExtension(int jobExtensionID)
        {
            JobExtension dbEntry = context.JobsExtensions
                .FirstOrDefault(p => p.JobExtensionID == jobExtensionID);
            if (dbEntry != null)
            {
                context.JobsExtensions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
