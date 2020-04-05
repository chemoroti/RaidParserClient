using DamageParser.ClientApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamageParser
{
    public partial class FightOverlay : Form
    {
        public string PlayerName;
        private const int MaxNumberOfPlayersOutput = 20;
        private Dictionary<string, CombatantFightInfo> Combatants { get; set; }
        private BattleWatcher Watcher;
        public FightOverlay(string playerName)
        {
            InitializeComponent();
            PlayerName = playerName;
            TopMost = true;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Opacity = 0.7;

            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
        }

        public void AddBattleWatcher(BattleWatcher watcher)
        {
            Watcher = watcher;
            Combatants = new Dictionary<string, CombatantFightInfo>();
            Watcher.OnBattleEndEvent += OnBattleEndEvent;
            Watcher.OnBattleUpdateEvent += OnBattleUpdateEvent;
            overlayFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
        }

        private void OnBattleUpdateEvent(CombatantFightInfo fightInfo)
        {
            string combatantName = fightInfo.GetCombatantName();
            if (!Combatants.ContainsKey(combatantName))
            {
                Combatants.Add(combatantName, fightInfo);
            }
            else
            {
                Combatants[combatantName] = fightInfo;
            }

            UpdateGrid(GetGridInfo());
        }

        public GridInfo GetGridInfo()
        {
            GridInfo gridInfo = new GridInfo();
            gridInfo.Header = GetOutputRow(Watcher.GetBattleHeaderInfo(), true);

            List<Label> combatantOutputs = new List<Label>();
            List<CombatantFightInfo> orderedCombatants = Combatants.Values.Where(c => c.OpponentName == Watcher.GetOpponentName()).OrderByDescending(v => v.GetTotalDamage()).ToList();

            int counter = 1;
            foreach (CombatantFightInfo combatant in orderedCombatants)
            {
                if(combatant.GetCombatantName() == PlayerName)
                {
                    if(counter >= MaxNumberOfPlayersOutput)
                    {
                        combatantOutputs[MaxNumberOfPlayersOutput - 1] = GetOutputRow($"{counter}. {combatant.GetDamageStats()}", false, true);
                    }
                    else
                    {
                        combatantOutputs.Add(GetOutputRow($"{counter}. {combatant.GetDamageStats()}", false, true));
                    }
                }
                else if (counter >= MaxNumberOfPlayersOutput)
                {
                    counter++;
                    continue;
                }
                else
                {
                    combatantOutputs.Add(GetOutputRow($"{counter}. {combatant.GetDamageStats()}"));
                }

                counter++;
            }

            gridInfo.CombatantOutputs = combatantOutputs;
            return gridInfo;
        }

        private void OnBattleEndEvent(CombatantFightInfo fightInfo)
        {
            Clear();
        }

        public void UpdateGrid(GridInfo gridInfo)
        {
            if (gridInfo.CombatantOutputs.Count == 0)
                return;

            Invoke(new MethodInvoker(delegate ()
            {
                overlayFlowLayoutPanel.Controls.Clear();
                overlayFlowLayoutPanel.Controls.Add(gridInfo.Header);
                foreach (Label combatantOutputRow in gridInfo.CombatantOutputs)
                {
                    overlayFlowLayoutPanel.Controls.Add(combatantOutputRow);
                }
            }));
        }

        private Label GetOutputRow(string text, bool isHeader = false, bool isSelf = false)
        {
            Label label = new Label();
            if (isHeader)
            {
                label.BackColor = Color.Green;
            }
            else if (isSelf)
            {
                label.BackColor = Color.Red;
            }
            else
            {
                label.BackColor = Color.Blue;
            }

            label.TextAlign = ContentAlignment.MiddleLeft;
            label.ForeColor = Color.Yellow;
            label.Text = text;
            label.Font = new Font("Arial", 10, FontStyle.Bold);
            label.Width = this.Width;
            label.AutoSize = false;
            label.Margin = new Padding(0, 0, 0, 2);
            label.Padding = new Padding(5, 0, 0, 0);

            return label;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Set the form click-through
                cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
                return cp;
            }
        }

        private void Overlay_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            Combatants = new Dictionary<string, CombatantFightInfo>();
            this.Invoke(new MethodInvoker(delegate ()
            {
                overlayFlowLayoutPanel.Controls.Clear();
            }));
        }

        public class GridInfo
        {
            public Label Header;
            public List<Label> CombatantOutputs;
        }

        private void OverlayFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
