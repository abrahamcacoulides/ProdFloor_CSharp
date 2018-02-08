using System.Collections.Generic;
using System;
using ProdFloor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProdFloor.Models.ViewModels
{
    public class JobViewModel
    {
        public Job CurrentJob { get; set; }
        public JobExtension CurrentJobExtension { get; set; }
        public HydroSpecifics CurrentHydroSpecifics { get; set; }
        public string CurrentTab { get; set; }
        public string CurrentSeparator { get; set; }
    }
}
