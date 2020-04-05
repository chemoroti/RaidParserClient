using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class MeleeInteraction : Interaction
    {
        public HitType HitType;

        public MeleeInteraction(string damageRecord)
        {
            Match match = Regex.Match(damageRecord, EnumsAndConstants.MeleeRegex);
            if (!match.Success)
                return;

            ParseRecord(match);
        }

        private void ParseRecord(Match match)
        {
            Time = DateTime.ParseExact(match.Groups[1].Value, @"ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
            HitType = GetMeleeHitType(match.Groups[2].Value);
            OpponentName = match.Groups[3].Value;
            HitAmount = int.Parse(match.Groups[4].Value);
        }

        private HitType GetMeleeHitType(string hitTypeString)
        {
            switch (hitTypeString.ToLower())
            {
                case "hit":
                    return HitType.Hit;
                case "slash":
                    return HitType.Slash;
                case "crush":
                    return HitType.Crush;
                case "pierce":
                    return HitType.Pierce;
                case "kick":
                    return HitType.Kick;
                case "bash":
                    return HitType.Bash;
                case "strike":
                    return HitType.Strike;
                default:
                    return HitType.Hit;

            }
        }
    }
}
