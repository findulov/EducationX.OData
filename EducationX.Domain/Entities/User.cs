using System;

namespace EducationX.Domain.Entities
{
    public class User
    {
        public User()
        {
        }

        public User(int id, string firstName, string lastName, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public int Id { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
