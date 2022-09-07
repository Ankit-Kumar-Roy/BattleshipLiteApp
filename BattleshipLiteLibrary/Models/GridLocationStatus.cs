using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
    public enum GridLocationStatus
    {
        /// <summary>
        /// No ship placed or sunk, neither hit or missed by opponent
        /// </summary>
        None,

        /// <summary>
        /// Player has placed ship
        /// </summary>
        Ship,

        /// <summary>
        /// Opponent has sunk the placed ship
        /// </summary>
        Sunk,

        /// <summary>
        /// player took shot on opponent and it was a hit
        /// </summary>
        Hit,

        /// <summary>
        /// player took shot on opponent but missed
        /// </summary>
        Miss
    }
}
