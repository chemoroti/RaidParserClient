using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class CombatantFightInfo
    {
        private string CombatantName { get; set; }
        private DateTime StartTime { get; set; }
        private int TotalDamage { get; set; }
        private int DPS { get; set; }
        public CombatantFightInfo(Interaction interaction, string combatantName)
        {
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
