using System.Net.NetworkInformation;
using Domain.Enums;

namespace Domain.Entities
{
    public class Volunteering
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } // Data de criação do voluntariado
        public TimeSpan Duration { get; set; } // Duraçao
  
        public IList<Benefit> Benefits { get; set; }
        public IList<Responsibility> Responsibility { get; set; } // List Responsability
        public IList<User> UsersParticipants { get; set; } // User subscriber
        public TypeVolunteering TypeVolunteering { get; set; } 

        public Institute Institute { get; set; } // Institute belonged

    }
 }