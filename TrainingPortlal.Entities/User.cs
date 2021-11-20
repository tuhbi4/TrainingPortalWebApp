﻿using TrainingPortal.Enums;

namespace TrainingPortal.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Roles Role { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Patronymic { get; set; }
    }
}