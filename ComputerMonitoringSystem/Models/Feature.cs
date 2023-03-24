using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMonitoringSystem.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FeatureValue> FeatureValues { get; set; }
        public List<NormalFeatureValue> NormalFeatureValues { get; set; }
    }
}
