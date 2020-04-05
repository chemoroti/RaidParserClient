using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public enum HitType
    {
        Hit = 1,
        Slash = 2,
        Crush = 3,
        Pierce = 4,
        Kick = 5,
        Bash = 6,
        Strike = 7,
        DamageShield = 8,
        Spell = 9
    }
    public static class EnumsAndConstants
    {
        public const string MeleeRegex = @"\[(.*)\] You (\S+) (.+) for (\d+) points of damage.";
        public const string SpellRegex = @"\[(.*)\] (.+) was hit by non-melee for (\d+) points of damage.";
        public const string LogFileCharNameRegex = @"eqlog_([a-zA-Z]+)(.*)";
        public const string MyKillshotRegex = @"\[.*\] You have slain (.*)!";
        public const string OtherKillshotRegex = @"\[.*\] (.*) has been slain by .*!";
        public const string DiedRegex = @"\[.*\] (.*) died.";
        public const string PetLeaderRegex = @"\[(.*)\] (.+) says 'My leader is (\w+).'";
        public static string PetAttackRegex = @"";
    }
}
