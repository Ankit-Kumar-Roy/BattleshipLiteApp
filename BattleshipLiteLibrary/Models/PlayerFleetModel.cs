using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
    public class PlayerFleetModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get => $"{FirstName} {LastName}"; }

        public List<GridLocationModel> Ships { get; set; } = new List<GridLocationModel>();

        public List<GridLocationModel> Shots { get; set; } = new List<GridLocationModel>();
    }
}
