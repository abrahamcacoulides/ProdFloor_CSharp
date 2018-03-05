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
        public IQueryable<HydroSpecific> HydroSpecifics => context.HydroSpecifics;
        public IQueryable<GenericFeatures> GenericFeaturesList => context.GenericFeaturesList;

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
        public void SaveHydroSpecific(HydroSpecific hydroSpecific)
        {
            if (hydroSpecific.HydroSpecificID == 0)
            {
                context.HydroSpecifics.Add(hydroSpecific);
            }
            else
            {
                HydroSpecific dbEntry = context.HydroSpecifics
                .FirstOrDefault(p => p.HydroSpecificID == hydroSpecific.HydroSpecificID);
                if (dbEntry != null)
                {
                    dbEntry.JobID = hydroSpecific.JobID;
                    dbEntry.Starter = hydroSpecific.Starter;
                    dbEntry.HP = hydroSpecific.HP;
                    dbEntry.FLA = hydroSpecific.FLA;
                    dbEntry.SPH = hydroSpecific.SPH;
                    dbEntry.MotorsNum = hydroSpecific.MotorsNum;
                    dbEntry.ValveBrand = hydroSpecific.ValveBrand;
                    dbEntry.ValveModel = hydroSpecific.ValveModel;
                    dbEntry.ValveCoils = hydroSpecific.ValveCoils;
                    dbEntry.ValveNum = hydroSpecific.ValveNum;
                    dbEntry.ValveVoltage = hydroSpecific.ValveVoltage;
                    dbEntry.Battery = hydroSpecific.Battery;
                    dbEntry.BatteryBrand = hydroSpecific.BatteryBrand;
                    dbEntry.LifeJacket = hydroSpecific.LifeJacket;
                    dbEntry.LOS = hydroSpecific.LOS;
                    dbEntry.OilCool = hydroSpecific.OilCool;
                    dbEntry.OilTank = hydroSpecific.OilTank;
                    dbEntry.PSS = hydroSpecific.PSS;
                    dbEntry.Resync = hydroSpecific.Resync;
                    dbEntry.Roped = hydroSpecific.Roped;
                    dbEntry.VCI = hydroSpecific.VCI;
                }
            }
            context.SaveChanges();
        }
        public void SaveGenericFeatures(GenericFeatures genericFeatures)
        {
            if (genericFeatures.GenericFeaturesID == 0)
            {
                context.GenericFeaturesList.Add(genericFeatures);
            }
            else
            {
                GenericFeatures dbEntry = context.GenericFeaturesList
                .FirstOrDefault(p => p.GenericFeaturesID == genericFeatures.GenericFeaturesID);
                if (dbEntry != null)
                {
                    dbEntry.GenericFeaturesID = dbEntry.GenericFeaturesID;
                    dbEntry.JobID = dbEntry.JobID;
                    dbEntry.FRON2 = dbEntry.FRON2;
                    dbEntry.Attendant = dbEntry.Attendant;
                    dbEntry.CarToLobby = dbEntry.CarToLobby;
                    dbEntry.EQ = dbEntry.EQ;
                    dbEntry.EMT = dbEntry.EMT;
                    dbEntry.EP = dbEntry.EP;
                    dbEntry.FLO = dbEntry.FLO;
                    dbEntry.Hosp = dbEntry.Hosp;
                    dbEntry.Ind = dbEntry.Ind;
                    dbEntry.INA = dbEntry.INA;
                    dbEntry.INCP = dbEntry.INCP;
                    dbEntry.LoadWeigher = dbEntry.LoadWeigher;
                    dbEntry.SwitchStyle = dbEntry.SwitchStyle;
                    dbEntry.MView = dbEntry.MView;
                    dbEntry.IMon = dbEntry.IMon;
                    dbEntry.IDS = dbEntry.IDS;
                    dbEntry.CallEnable = dbEntry.CallEnable;
                    dbEntry.CarCallCodeSecurity = dbEntry.CarCallCodeSecurity;
                    dbEntry.SpecialInstructions = dbEntry.SpecialInstructions;
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
        public HydroSpecific DeleteHydroSpecific(int hydroSpecificID)
        {
            HydroSpecific dbEntry = context.HydroSpecifics
                .FirstOrDefault(p => p.HydroSpecificID == hydroSpecificID);
            if (dbEntry != null)
            {
                context.HydroSpecifics.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public GenericFeatures DeleteGenericFeatures(int genericFeaturesID)
        {
            GenericFeatures dbEntry = context.GenericFeaturesList
                .FirstOrDefault(p => p.GenericFeaturesID == genericFeaturesID);
            if (dbEntry != null)
            {
                context.GenericFeaturesList.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
