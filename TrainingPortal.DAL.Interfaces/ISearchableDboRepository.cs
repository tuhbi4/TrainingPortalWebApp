﻿using System.Collections.Generic;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ISearchableDboRepository<T> where T : class
    {
        public List<T> Search(string courseName, string categoryName, string targetAudiencyName);
    }
}