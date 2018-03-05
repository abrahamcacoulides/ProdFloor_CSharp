using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProdFloor.Models
{
    public class Job
    {
        public int JobID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Job Type")]
        public string JobType { get; set; }

        [Display(Name = "Job #")]
        [Required(ErrorMessage = "Please enter a Job Num")]
        public int JobNum { get; set; }

        [Display(Name = "PO #")]
        [Range(3000000, 4000000, ErrorMessage = "Job number is out of range")]
        [Required(ErrorMessage = "Please enter a PO")]
        public int PO { get; set; }

        [Display(Name = "Shipping Date")]
        [Required(ErrorMessage = "Please enter a Shipping Date")]
        public DateTime ShipDate { get; set; }

        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Please enter a Customer Number")]
        public string Cust { get; set; }

        [Display(Name = "Contractor Name")]
        [Required(ErrorMessage = "Please enter a Contractor")]
        public string Contractor { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please enter a State")]
        public string JobState { get; set; }

        [Display(Name = "Safety Code")]
        [Required(ErrorMessage = "Please enter a Safety Code")]
        public string SafetyCode { get; set; }
    }

    public class JobExtension
    {
        public int JobExtensionID { get; set; }
        public int JobID { get; set; }

        [Display(Name = "Number of Stops")]
        [Range(1,32, ErrorMessage = "Stops are out of range")]
        public int NumOfStops { get; set; }

        [Display(Name = "Type of operation")]
        public string JobTypeMain { get; set; }

        [Display(Name = "Type of operation(additional)")]
        public string JobTypeAdd { get; set; }

        [Display(Name = "Input Voltage")]
        public int InputVoltage { get; set; }

        [Display(Name = "Input Phase")]
        public int InputPhase { get; set; }

        [Display(Name = "Input Frequency")]
        public int InputFrecuency { get; set; }

        [Display(Name = "Car Gate")]
        public string DoorGate { get; set; }

        [Display(Name = "Hoistway Doors")]
        public string DoorHoist { get; set; }

        [Display(Name = "Infrared detector/photo eye")]
        public bool InfDetector { get; set; }

        [Display(Name = "Mechanical Safety Edge")]
        public bool MechSafEdge { get; set; }

        [Display(Name = "Heavy Doors")]
        public bool HeavyDoors { get; set; }

        [Display(Name = "Cartop Door Open/Close Buttons")]
        public bool CartopDoorButtons { get; set; }

        [Display(Name = "Door Hold Operation")]
        public bool DoorHold { get; set; }

        [Display(Name = "Nudging")]
        public bool Nudging { get; set; }

        //not needed
        public string DoorStyle { get; set; }

        [Display(Name = "Door Operator Brand")]
        public string DoorBrand { get; set; }

        [Display(Name = "Door Operator Model")]
        public string DoorModel { get; set; }

        [Display(Name = "Serial COP")]
        public bool SCOP { get; set; }

        [Display(Name = "Serial Hall Calls")]
        public bool SHC { get; set; }

        [Display(Name = "SHC Risers #")]
        public int SHCRisers { get; set; }

        [Display(Name = "Auxiliary COP")]
        public bool AUXCOP { get; set; }
    }

    public class HydroSpecific
    {
        public int HydroSpecificID { get; set; }
        public int JobID { get; set; }

        public string Starter { get; set; }
        public int HP { get; set; }
        public int FLA { get; set; }
        public int SPH { get; set; }
        public int MotorsNum { get; set; }
        public string ValveBrand { get; set; }
        public string ValveModel { get; set; }
        public int ValveCoils { get; set; }
        public int ValveNum { get; set; }
        public int ValveVoltage { get; set; }
        
        public bool Battery { get; set; }
        public string BatteryBrand { get; set; }
        public bool LifeJacket { get; set; }
        public bool LOS { get; set; }
        public bool OilCool { get; set; }
        public bool OilTank { get; set; }
        public bool PSS { get; set; }
        public bool Resync { get; set; }
        public bool Roped { get; set; }
        public bool VCI { get; set; }
    }

    public class GenericFeatures
    {
        public int GenericFeaturesID { get; set; }
        public int JobID { get; set; }

        public bool FRON2 { get; set; }
        public bool Attendant { get; set; }
        public bool CarToLobby { get; set; }
        public bool EQ { get; set; }
        public bool EMT { get; set; }
        public bool EP { get; set; }
        public bool FLO { get; set; }
        public bool Hosp { get; set; }
        public bool Ind { get; set; }
        public bool INA { get; set; }
        public bool INCP { get; set; }
        public bool LoadWeigher { get; set; }
        public string SwitchStyle { get; set; }

        public bool MView { get; set; }
        public bool IMon { get; set; }
        public bool IDS { get; set; }
        public bool CallEnable { get; set; }
        public string CarCallCodeSecurity { get; set; }
        public string SpecialInstructions { get; set; }
    }

    public class Indicators
    {
        public int IndicatorsID { get; set; }
        public int JobID { get; set; }

        // if SCOP is true these are 24 dc led
        public int CarCallsVoltage { get; set; } //24,48,120
        public string CarCallsVoltageType { get; set; } //AC, DC
        public string CarCallsType { get; set; } //LED, Incandescent

        // if SHC is true these are 24 dc led
        public int HallCallsVoltage { get; set; } //24,48,120
        public string HallCallsVoltageType { get; set; } //AC, DC
        public string HallCallsType { get; set; } //LED, Incandescent

        public bool CarPI { get; set; } // check if required
        public string CarPIType { get; set; } // CE, Emotive, Discrete
        public string CarPIDiscreteVoltage { get; set; } //24,48,120
        public string CarPIDiscreteVoltageType { get; set; } //AC, DC
        public string CarPIDiscreteType { get; set; } //Multi-light, One line, binary 00, binary 01

        public bool HallPI { get; set; } // check if required
        public string HallPIType { get; set; } // CE, Emotive, Discrete
        public string HallPIDiscreteVoltage { get; set; } //24,48,120
        public string HallPIDiscreteVoltageType { get; set; } //AC, DC
        public string HallPIDiscreteType { get; set; } //Multi-light, One line, binary 00, binary 01

        public bool VoiceAnnunciationPI { get; set; } // check if required
        public string VoiceAnnunciationPIType { get; set; } // CE, Emotive, Other

        public bool CarLanterns { get; set; } //check if required
        public int CarLanternsVoltage { get; set; } //24,48,120
        public string CarLanternsVoltageType { get; set; } //AC, DC
        public string CarLanternsType { get; set; } //Chime, Gong

        public bool HallLanterns { get; set; } //check if required
        public int HallLanternsVoltage { get; set; } //24,48,120
        public string HallLanternsVoltageType { get; set; } //AC, DC
        public string HallLanternsType { get; set; } //Chime, Gong

        public bool PassingFloor { get; set; } // check if required
        public string PassingFloorType { get; set; } // CE, Emotive, Discrete
        public string PassingFloorDiscreteVoltage { get; set; } //24,48,120
        public string PassingFloorDiscreteVoltageType { get; set; } //AC, DC
        public string PassingFloorDiscreteType { get; set; } //Chime, Gong
        public bool PassingFloorEnable { get; set; } // check if required

        public StatusIndicator StatusIndicatorsList { get; set; }
    }

    public class HoistWayData
    {
        public int HoistWayDataID { get; set; }
        public int JobID { get; set; }

        public bool FrontFirstServed { get; set; }
        public bool RearFirstServed { get; set; }
        public bool FrontSecondServed { get; set; }
        public bool RearSecondServed { get; set; }
        public bool FrontThirdServed { get; set; }
        public bool RearThirdServed { get; set; }
        public bool FrontFourthServed { get; set; }
        public bool RearFourthServed { get; set; }
        public bool FrontFifthServed { get; set; }
        public bool RearFifthServed { get; set; }
        public bool FrontSexthServed { get; set; }
        public bool RearSexthServed { get; set; }
        public bool FrontSeventhServed { get; set; }
        public bool RearSeventhServed { get; set; }
        public bool FrontEightServed { get; set; }
        public bool RearEightServed { get; set; }
        public bool FrontNinthServed { get; set; }
        public bool RearNinthServed { get; set; }
        public bool FrontTenthServed { get; set; }
        public bool RearTenthServed { get; set; }
        public bool FrontEleventhServed { get; set; }
        public bool RearEleventhServed { get; set; }
        public bool FrontTwelvethServed { get; set; }
        public bool RearTwelvethServed { get; set; }
        public bool FrontThirteenthServed { get; set; }
        public bool RearThirteenthServed { get; set; }
        public bool FrontFourteenthServed { get; set; }
        public bool RearFourteenthServed { get; set; }
        public bool FrontFifteenthServed { get; set; }
        public bool RearFifteenthServed { get; set; }
        public bool FrontSixteenthServed { get; set; }
        public bool RearSixteenthServed { get; set; }

        public int Capacity { get; set; }
        public int UpSpeed { get; set; }
        public int DownSpeed { get; set; }
        public int TotalTravel { get; set; }
        public string LandingSystem { get; set; }
    }
}
