﻿using Microsoft.EntityFrameworkCore;
using ProdFloor.Models.ViewModels;
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
        public IQueryable<Indicator> Indicators => context.Indicators;
        public IQueryable<HoistWayData> HoistWayDatas => context.HoistWayDatas;

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
                    dbEntry.LatestFinishDate = job.LatestFinishDate;
                    dbEntry.Cust = job.Cust;
                    dbEntry.Contractor = job.Contractor;
                    dbEntry.JobCountry = job.JobCountry;
                    dbEntry.JobState = job.JobState;
                    dbEntry.JobCity = job.JobCity;
                    dbEntry.SafetyCode = job.SafetyCode;
                    dbEntry.Status = job.Status;
                    dbEntry.EngID = job.EngID;
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
                    dbEntry.EPVoltage = dbEntry.EPVoltage;
                    dbEntry.EPOtherCars = dbEntry.EPOtherCars;
                    dbEntry.EPCarsNumber = dbEntry.EPCarsNumber;
                    dbEntry.EPContact = dbEntry.EPContact;
                    dbEntry.PTI = dbEntry.PTI;
                    dbEntry.EPSelect = dbEntry.EPSelect;
                    dbEntry.FLO = dbEntry.FLO;
                    dbEntry.Hosp = dbEntry.Hosp;
                    dbEntry.Ind = dbEntry.Ind;
                    dbEntry.INA = dbEntry.INA;
                    dbEntry.TopAccess = dbEntry.TopAccess;
                    dbEntry.TopAccessLocation = dbEntry.TopAccessLocation;
                    dbEntry.BottomAccess = dbEntry.BottomAccess;
                    dbEntry.BottomAccessLocation = dbEntry.BottomAccessLocation;
                    dbEntry.INCP = dbEntry.INCP;
                    dbEntry.INCPButtons = dbEntry.INCPButtons;
                    dbEntry.CTINSPST = dbEntry.CTINSPST;
                    dbEntry.Roped = dbEntry.Roped;
                    dbEntry.GovModel = dbEntry.GovModel;
                    dbEntry.LoadWeigher = dbEntry.LoadWeigher;
                    dbEntry.SwitchStyle = dbEntry.SwitchStyle;
                    dbEntry.Monitoring = dbEntry.Monitoring;
                    dbEntry.CallEnable = dbEntry.CallEnable;
                    dbEntry.CarCallCodeSecurity = dbEntry.CarCallCodeSecurity;
                    dbEntry.SpecialInstructions = dbEntry.SpecialInstructions;
                }
                else
                {
                    context.GenericFeaturesList.Add(genericFeatures);
                }
            }
            context.SaveChanges();
        }
        public void SaveIndicator(Indicator indicator)
        {
            if (indicator.IndicatorID == 0)
            {
                context.Indicators.Add(indicator);
            }
            else
            {
                Indicator dbEntry = context.Indicators
                .FirstOrDefault(p => p.IndicatorID == indicator.IndicatorID);
                if (dbEntry != null)
                {
                    dbEntry.CarCallsVoltage = indicator.CarCallsVoltage;
                    dbEntry.CarCallsVoltageType = indicator.CarCallsVoltageType;
                    dbEntry.CarCallsType = indicator.CarCallsType;
                    dbEntry.HallCallsVoltage = indicator.HallCallsVoltage;
                    dbEntry.HallCallsVoltageType = indicator.HallCallsVoltageType;
                    dbEntry.HallCallsType = indicator.HallCallsType;
                    dbEntry.CarPI = indicator.CarPI;
                    dbEntry.CarPIType = indicator.CarPIType;
                    dbEntry.CarPIDiscreteType = indicator.CarPIDiscreteType;
                    dbEntry.HallPI = indicator.HallPI;
                    dbEntry.HallPIType = indicator.HallPIType;
                    dbEntry.HallPIDiscreteType = indicator.HallPIDiscreteType;
                    dbEntry.VoiceAnnunciationPI = indicator.VoiceAnnunciationPI;
                    dbEntry.VoiceAnnunciationPIType = indicator.VoiceAnnunciationPIType;
                    dbEntry.CarLanterns = indicator.CarLanterns;
                    dbEntry.CarLanternsStyle = indicator.CarLanternsStyle;
                    dbEntry.CarLanternsType = indicator.CarLanternsType;
                    dbEntry.HallLanterns = indicator.HallLanterns;
                    dbEntry.HallLanternsStyle = indicator.HallLanternsStyle;
                    dbEntry.HallLanternsType = indicator.HallLanternsType;
                    dbEntry.PassingFloor = indicator.PassingFloor;
                    dbEntry.PassingFloorType = indicator.PassingFloorType;
                    dbEntry.PassingFloorDiscreteType = indicator.PassingFloorDiscreteType;
                    dbEntry.PassingFloorEnable = indicator.PassingFloorEnable;
                    dbEntry.IndicatorsVoltage = indicator.IndicatorsVoltage;
                    dbEntry.IndicatorsVoltageType = indicator.IndicatorsVoltageType;
                    dbEntry.JobID = indicator.JobID;
                }
            }
            context.SaveChanges();
        }
        public void SaveHoistWayData(HoistWayData hoistWayData)
        {
            if (hoistWayData.HoistWayDataID == 0)
            {
                context.HoistWayDatas.Add(hoistWayData);
            }
            else
            {
                HoistWayData dbEntry = context.HoistWayDatas
                .FirstOrDefault(p => p.HoistWayDataID == hoistWayData.HoistWayDataID);
                if (dbEntry != null)
                {
                    dbEntry.JobID = hoistWayData.JobID;
                    dbEntry.FrontFirstServed = hoistWayData.FrontFirstServed;
                    dbEntry.RearFirstServed = hoistWayData.RearFirstServed;
                    dbEntry.FrontSecondServed = hoistWayData.FrontSecondServed;
                    dbEntry.RearSecondServed = hoistWayData.RearSecondServed;
                    dbEntry.FrontThirdServed = hoistWayData.FrontThirdServed;
                    dbEntry.RearThirdServed = hoistWayData.RearThirdServed;
                    dbEntry.FrontFourthServed = hoistWayData.FrontFourthServed;
                    dbEntry.RearFourthServed = hoistWayData.RearFourthServed;
                    dbEntry.FrontFifthServed = hoistWayData.FrontFifthServed;
                    dbEntry.RearFifthServed = hoistWayData.RearFifthServed;
                    dbEntry.FrontSexthServed = hoistWayData.FrontSexthServed;
                    dbEntry.RearSexthServed = hoistWayData.RearSexthServed;
                    dbEntry.FrontSeventhServed = hoistWayData.FrontSeventhServed;
                    dbEntry.RearSeventhServed = hoistWayData.RearSeventhServed;
                    dbEntry.FrontEightServed = hoistWayData.FrontEightServed;
                    dbEntry.RearEightServed = hoistWayData.RearEightServed;
                    dbEntry.FrontNinthServed = hoistWayData.FrontNinthServed;
                    dbEntry.RearNinthServed = hoistWayData.RearNinthServed;
                    dbEntry.FrontTenthServed = hoistWayData.FrontTenthServed;
                    dbEntry.RearTenthServed = hoistWayData.RearTenthServed;
                    dbEntry.FrontEleventhServed = hoistWayData.FrontEleventhServed;
                    dbEntry.RearEleventhServed = hoistWayData.RearEleventhServed;
                    dbEntry.FrontTwelvethServed = hoistWayData.FrontTwelvethServed;
                    dbEntry.RearTwelvethServed = hoistWayData.RearTwelvethServed;
                    dbEntry.FrontThirteenthServed = hoistWayData.FrontThirteenthServed;
                    dbEntry.RearThirteenthServed = hoistWayData.RearThirteenthServed;
                    dbEntry.FrontFourteenthServed = hoistWayData.FrontFourteenthServed;
                    dbEntry.RearFourteenthServed = hoistWayData.RearFourteenthServed;
                    dbEntry.FrontFifteenthServed = hoistWayData.FrontFifteenthServed;
                    dbEntry.RearFifteenthServed = hoistWayData.RearFifteenthServed;
                    dbEntry.FrontSixteenthServed = hoistWayData.FrontSixteenthServed;
                    dbEntry.RearSixteenthServed = hoistWayData.RearSixteenthServed;
                    dbEntry.Capacity = hoistWayData.Capacity;
                    dbEntry.UpSpeed = hoistWayData.UpSpeed;
                    dbEntry.DownSpeed = hoistWayData.DownSpeed;
                    dbEntry.TotalTravel = hoistWayData.TotalTravel;
                    dbEntry.LandingSystem = hoistWayData.LandingSystem;
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
        public Job DeleteEngJob(int JobID)
        {
            Job dbEntry = context.Jobs
                .FirstOrDefault(p => p.JobID == JobID);
            JobExtension jobExtension = context.JobsExtensions
                .FirstOrDefault(p => p.JobID == JobID);
            HydroSpecific hydroSpecific = context.HydroSpecifics
                .FirstOrDefault(p => p.JobID == JobID);
            GenericFeatures genericFeatures = context.GenericFeaturesList
                .FirstOrDefault(p => p.JobID == JobID);
            Indicator indicator = context.Indicators
                .FirstOrDefault(p => p.JobID == JobID);
            HoistWayData hoistWayData = context.HoistWayDatas
                .FirstOrDefault(p => p.JobID == JobID);
            if (dbEntry != null)
            {
                context.Jobs.Remove(dbEntry);
                context.SaveChanges();
            }
            if (jobExtension != null)
            {
                context.JobsExtensions.Remove(jobExtension);
                context.SaveChanges();
            }
            if (hydroSpecific != null)
            {
                context.HydroSpecifics.Remove(hydroSpecific);
                context.SaveChanges();
            }
            if (genericFeatures != null)
            {
                context.GenericFeaturesList.Remove(genericFeatures);
                context.SaveChanges();
            }
            if (indicator != null)
            {
                context.Indicators.Remove(indicator);
                context.SaveChanges();
            }
            if (hoistWayData != null)
            {
                context.HoistWayDatas.Remove(hoistWayData);
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
        public Indicator DeleteIndicator(int indicatorID)
        {
            Indicator dbEntry = context.Indicators
                .FirstOrDefault(p => p.IndicatorID == indicatorID);
            if (dbEntry != null)
            {
                context.Indicators.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public HoistWayData DeleteHoistWayData(int hoistWayDataID)
        {
            HoistWayData dbEntry = context.HoistWayDatas
                .FirstOrDefault(p => p.HoistWayDataID == hoistWayDataID);
            if (dbEntry != null)
            {
                context.HoistWayDatas.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveEngJobView(JobViewModel viewModelToSave)
        {
            SaveJob(viewModelToSave.CurrentJob);
            if (viewModelToSave.CurrentJobExtension != null)
            {
                if (viewModelToSave.CurrentJobExtension.JobID != 0)
                {
                    JobExtension jobExtension = JobsExtensions.FirstOrDefault(j => j.JobID == viewModelToSave.CurrentJobExtension.JobID);
                    if (jobExtension == null)
                    {
                        SaveJobExtension(viewModelToSave.CurrentJobExtension);
                    }
                    else
                    {
                        viewModelToSave.CurrentJobExtension.JobExtensionID = jobExtension.JobExtensionID;
                        SaveJobExtension(viewModelToSave.CurrentJobExtension);
                    }
                }
            }
            if (viewModelToSave.CurrentHydroSpecific != null)
            {
                if (viewModelToSave.CurrentHydroSpecific.JobID != 0)
                {
                    HydroSpecific hydroSpecific = HydroSpecifics.FirstOrDefault(j => j.JobID == viewModelToSave.CurrentHydroSpecific.JobID);
                    if (hydroSpecific == null)
                    {
                        SaveHydroSpecific(viewModelToSave.CurrentHydroSpecific);
                    }
                    else
                    {
                        viewModelToSave.CurrentHydroSpecific.HydroSpecificID = hydroSpecific.HydroSpecificID;
                        SaveHydroSpecific(viewModelToSave.CurrentHydroSpecific);
                    }
                }
            }
            if (viewModelToSave.CurrentGenericFeatures != null)
            {
                if (viewModelToSave.CurrentGenericFeatures.JobID != 0)
                {
                    GenericFeatures genericFeatures = GenericFeaturesList.FirstOrDefault(j => j.JobID == viewModelToSave.CurrentGenericFeatures.JobID);
                    if (genericFeatures == null)
                    {
                        SaveGenericFeatures(viewModelToSave.CurrentGenericFeatures);
                    }
                    else
                    {
                        viewModelToSave.CurrentGenericFeatures.GenericFeaturesID = genericFeatures.GenericFeaturesID;
                        SaveGenericFeatures(viewModelToSave.CurrentGenericFeatures);
                    }
                }
            }
            if (viewModelToSave.CurrentIndicator != null)
            {
                if (viewModelToSave.CurrentIndicator.JobID != 0)
                {
                    Indicator indicator = Indicators.FirstOrDefault(j => j.JobID == viewModelToSave.CurrentIndicator.JobID);
                    if (indicator == null)
                    {
                        SaveIndicator(viewModelToSave.CurrentIndicator);
                    }
                    else
                    {
                        viewModelToSave.CurrentIndicator.IndicatorID = indicator.IndicatorID;
                        SaveIndicator(viewModelToSave.CurrentIndicator);
                    }
                }
            }
            if (viewModelToSave.CurrentHoistWayData != null)
            {
                if (viewModelToSave.CurrentHoistWayData.JobID != 0)
                {
                    HoistWayData hoistway = HoistWayDatas.FirstOrDefault(j => j.JobID == viewModelToSave.CurrentHoistWayData.JobID);
                    if (hoistway == null)
                    {
                        SaveHoistWayData(viewModelToSave.CurrentHoistWayData);
                    }
                    else
                    {
                        viewModelToSave.CurrentHoistWayData.HoistWayDataID = hoistway.HoistWayDataID;
                        SaveHoistWayData(viewModelToSave.CurrentHoistWayData);
                    }
                }
            }
        }
    }
}
