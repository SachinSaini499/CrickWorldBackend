using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrickWorldBackend.Models
{
    public class TeamDetails
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string TeamLogo { get; set; }

        public int TeamMemberCount { get; set; }

      
    }
}