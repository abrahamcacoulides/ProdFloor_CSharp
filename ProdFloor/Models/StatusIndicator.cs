using System.Collections.Generic;
using System.Linq;

namespace ProdFloor.Models
{
    public class StatusIndicator
    {
        public List<IndicatorLine> indicatorCollection = new List<IndicatorLine>();

        public virtual void AddItem(string name, int voltage, string voltageType)
        {
            IndicatorLine line = indicatorCollection
                .Where(p => p.Name == name)
                .FirstOrDefault();

            if (line == null)
            {
                indicatorCollection.Add(new IndicatorLine
                {
                    Name = name,
                    Voltage = voltage,
                    VoltageType = voltageType
                });
            }
        }

        public class IndicatorLine
        {
            public int StatusLineID { get; set; }
            public string Name { get; set; }
            public int Voltage { get; set; }
            public string VoltageType { get; set; }
        }
    }
}
