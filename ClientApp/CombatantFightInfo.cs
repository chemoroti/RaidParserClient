using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    [Serializable]
    public class CombatantFightInfo
    {
        public string OpponentName { get; set; }
        public string CombatantName { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalDamage { get; set; }
        public int DPS { get; set; }
        public string RaidId = "123";
        public CombatantFightInfo() { }
        public CombatantFightInfo(Interaction interaction, string combatantName)
        {
            OpponentName = interaction.OpponentName;
            CombatantName = combatantName;
            StartTime = interaction.Time;
            UpdateDamageStats(interaction.HitAmount);
        }

        public void UpdateDamageStats(int hitAmount)
        {
            TotalDamage += hitAmount;
            int elapsedSeconds = (int)Math.Max(1, DateTime.Now.Subtract(StartTime).TotalSeconds);
            DPS = (TotalDamage / elapsedSeconds);
        }

        public string GetDamageStats()
        {
            return $"{CombatantName}:      {TotalDamage} @ {DPS} DPS";
        }

        public string GetCombatantName()
        {
            return CombatantName;
        }

        public int GetTotalDamage()
        {
            return TotalDamage;
        }
    }
}
