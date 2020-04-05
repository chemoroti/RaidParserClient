using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public abstract class Interaction
    {
        public int HitAmount;
        public string OpponentName;
        public DateTime Time;
    }
}
