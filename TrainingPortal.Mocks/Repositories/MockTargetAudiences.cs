using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockTargetAudiences : MockRepository<TargetAudience>
    {
        public List<TargetAudience> List
        {
            get => new()
            {
                new TargetAudience(1, "Beginners"),
                new TargetAudience(2, "Advanced"),
                new TargetAudience(3, "Professionals"),
            };
            set => throw new System.NotImplementedException();
        }
    }
}