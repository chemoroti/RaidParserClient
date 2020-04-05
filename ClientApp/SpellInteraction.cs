using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class SpellInteraction : Interaction
    {
        public SpellInteraction(string damageRecord)
        {
            Match match = Regex.Match(damageRecord, EnumsAndConstants.SpellRegex);
            if (!match.Success)
                return;

            ParseRecord(match);
        }

        private void ParseRecord(Match match)
        {
            Time = DateTime.ParseExact(match.Groups[1].Value, @"ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
            OpponentName = match.Groups[2].Value;
            HitAmount = int.Parse(match.Groups[3].Value);
        }
    }
}
