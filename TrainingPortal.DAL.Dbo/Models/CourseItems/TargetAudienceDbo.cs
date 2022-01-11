﻿namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class TargetAudienceDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TargetAudienceDbo()
        { }

        public TargetAudienceDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}