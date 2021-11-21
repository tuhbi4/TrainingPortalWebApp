using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.BLL.Mocks
{
    public class MockTargetAudiences
    {
        public List<TargetAudience> TargetAudiencesList { get; set; } = new List<TargetAudience>()
        {
            new TargetAudience(1, "Beginners"),
            new TargetAudience(2, "Advanced"),
            new TargetAudience(3, "Professionals"),
        };
    }
}