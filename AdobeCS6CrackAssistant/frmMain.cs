using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;*/
//using System.Text;
using System.Text.RegularExpressions;
//using System.Threading;
using System.Windows.Forms;

using Utilities;

namespace AdobeCS6CrackAssistant
{
    public partial class frmMain : Form
    {
        int ticks = 0;

        ToolTip tt = new ToolTip();

        public frmMain()
        {
            InitializeComponent();

            //pbMain.Style = ProgressBarStyle.Marquee;
            //pbMain.Visible = false;
            
            tt.AutoPopDelay = 5000;
            tt.InitialDelay = 1000;
            tt.ReshowDelay = 500;
            tt.ShowAlways = true;

            // Set tooltips for all the checkboxes.
            tt.SetToolTip(chkAcrobat, "Acrobat");
            tt.SetToolTip(chkAfterEffects, "After Effects");
            tt.SetToolTip(chkAudition, "Audition");
            tt.SetToolTip(chkBridge, "Bridge");
            tt.SetToolTip(chkDreamweaver, "Dreamweaver");
            tt.SetToolTip(chkEncore, "Encore");
            tt.SetToolTip(chkFireworks, "Fireworks");
            tt.SetToolTip(chkFlash, "Flash");
            tt.SetToolTip(chkFlashBuilder, "Flash Builder");
            tt.SetToolTip(chkIllustrator, "Illustrator");
            tt.SetToolTip(chkInDesign, "InDesign");
            tt.SetToolTip(chkMediaEncoder, "Media Encoder");
            tt.SetToolTip(chkPhotoshop, "Photoshop");
            tt.SetToolTip(chkPrelude, "Prelude");
            tt.SetToolTip(chkPremiere, "Premiere");
            tt.SetToolTip(chkSpeedGrade, "SpeedGrade");
            
            this.Text = ApplicationInfo.Title + " v" + ApplicationInfo.Version.ToString();
        }

        private void btnCrack_Click(object s, EventArgs ev)
        {
            //MessageBox.Show("Cracking...");
            timer.Enabled = true;
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            ticks++;

            pbMain.Value1 = ticks;
            
            if (ticks == 100)
            {
                timer.Enabled = false;
                ticks = 0;
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            bool bChecked = cb.Checked;

            tt.SetToolTip(cb, Regex.Replace(tt.GetToolTip(cb), @"(Include|Exclude) \:", "") + ((bChecked) ? ": Include" : ": Exclude"));
        }
    }
}
