using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories.CourseParts
{
    public class TargetAudienceService : IRepositoryService<TargetAudience>
    {
        private readonly IMapper mapper;
        private readonly IDboRepository<TargetAudienceDbo> targetAudienceDboRepository;

        public TargetAudienceService(IMapper mapper, IDboRepository<TargetAudienceDbo> targetAudienceDboRepository)
        {
            this.mapper = mapper;
            this.targetAudienceDboRepository = targetAudienceDboRepository;
        }

        public int Create(TargetAudience dataInstance)
        {
            return targetAudienceDboRepository.Create(mapper.Map<TargetAudienceDbo>(dataInstance));
        }

        public TargetAudience Read(int id)
        {
            return mapper.Map<TargetAudience>(targetAudienceDboRepository.Read(id));
        }

        public List<TargetAudience> ReadAll()
        {
            IEnumerable<TargetAudience> targetAudienceDbos = targetAudienceDboRepository.ReadAll().Select(x => mapper.Map<TargetAudience>(x));
            List<TargetAudience> targetAudienceDbosList = new List<TargetAudience>();

            foreach (TargetAudience targetAudienceDbo in targetAudienceDbos)
            {
                targetAudienceDbosList.Add(targetAudienceDbo);
            }

            return targetAudienceDbosList;
        }

        public int Update(int id, TargetAudience dataInstance)
        {
            return targetAudienceDboRepository.Update(id, mapper.Map<TargetAudienceDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return targetAudienceDboRepository.Delete(id);
        }
    }
}