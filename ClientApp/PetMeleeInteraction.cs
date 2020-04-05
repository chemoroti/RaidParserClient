using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class PetMeleeInteraction : Interaction
    {
        public PetMeleeInteraction(string damageRecord)
        {
            Match match = Regex.Match(damageRecord, EnumsAndConstants.PetAttackRegex);
            if (!match.Success)
                return;

            ParseRecord(match);
        }

        private void ParseRecord(Match match)
        {
            Time = DateTime.ParseExact(match.Groups[1].Value, @"ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
            OpponentName = match.Groups[3].Value;
            HitAmount = int.Parse(match.Groups[4].Value);
        }
    }
}
