using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMonitoringSystem.Models
{
    public class IssueFeatureValue
    {
        public int Id { get; set; }

        public int IssueId { get; set; }
        public virtual Issue Issue { get; set; }

        public int FeatureValueId { get; set; }
        public virtual FeatureValue FeatureValue { get; set; }
    }
}
