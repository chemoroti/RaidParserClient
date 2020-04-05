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
    public partial class FightOverlayPosition : Form
    {
        public FightOverlayPosition()
        {
            InitializeComponent();
            label1.MaximumSize = new Size(200, 0);
            label1.AutoSize = true;
        }

        public void UpdateDimensions(FightOverlay overlay)
        {
            this.Width = overlay.Width;
            this.Height = overlay.Height;
            this.Location = new Point(overlay.Location.X, overlay.Location.Y);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void FightOverlayPosition_Load(object sender, EventArgs e)
        {

        }

        private void FightOverlayPosition_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("closing form: " + this.Width);
        }
    }
}
