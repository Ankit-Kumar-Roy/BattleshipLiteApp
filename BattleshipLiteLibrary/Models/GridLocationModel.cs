using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
    public class GridLocationModel
    {
        public string Letter { get; set; }
        public int Number { get; set; }
        public GridLocationStatus Status { get; set; }
    }
}
