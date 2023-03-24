using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMonitoringSystem.Models
{
    public class FeatureValue
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
        public string Value { get; set; }
    }
}
