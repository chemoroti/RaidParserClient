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
        public static string MeleeRegex = @"\[(.*)\] You (\S+) (.+) for (\d+) points of damage.";
        public static string SpellRegex = @"\[(.*)\] (.+) was hit by non-melee for (\d+) points of damage.";
        public static string LogFileCharNameRegex = $"eqlog_([a-zA-Z]+)(.*)";
        public static string MyKillshotRegex = @"\[.*\] You have slain (.*)!";
        public static string OtherKillshotRegex = @"\[.*\] (.*) has been slain by .*!";
        public static string DiedRegex = @"\[.*\] (.*) died.";
    }
}
