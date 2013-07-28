namespace AdobeCS6CrackAssistant
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnCrack = new System.Windows.Forms.Button();
            this.btnUncrack = new System.Windows.Forms.Button();
            this.chkAcrobat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSpeedGrade = new System.Windows.Forms.CheckBox();
            this.chkPremiere = new System.Windows.Forms.CheckBox();
            this.chkPrelude = new System.Windows.Forms.CheckBox();
            this.chkPhotoshop = new System.Windows.Forms.CheckBox();
            this.chkMediaEncoder = new System.Windows.Forms.CheckBox();
            this.chkInDesign = new System.Windows.Forms.CheckBox();
            this.chkIllustrator = new System.Windows.Forms.CheckBox();
            this.chkFlashBuilder = new System.Windows.Forms.CheckBox();
            this.chkFlash = new System.Windows.Forms.CheckBox();
            this.chkFireworks = new System.Windows.Forms.CheckBox();
            this.chkEncore = new System.Windows.Forms.CheckBox();
            this.chkDreamweaver = new System.Windows.Forms.CheckBox();
            this.chkBridge = new System.Windows.Forms.CheckBox();
            this.chkAudition = new System.Windows.Forms.CheckBox();
            this.chkAfterEffects = new System.Windows.Forms.CheckBox();
            this.pbMain = new Telerik.WinControls.UI.RadProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrack
            // 
            this.btnCrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrack.Location = new System.Drawing.Point(12, 203);
            this.btnCrack.Name = "btnCrack";
            this.btnCrack.Size = new System.Drawing.Size(132, 30);
            this.btnCrack.TabIndex = 0;
            this.btnCrack.Text = "Crack";
            this.btnCrack.UseVisualStyleBackColor = true;
            this.btnCrack.Click += new System.EventHandler(this.btnCrack_Click);
            // 
            // btnUncrack
            // 
            this.btnUncrack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUncrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncrack.Location = new System.Drawing.Point(150, 203);
            this.btnUncrack.Name = "btnUncrack";
            this.btnUncrack.Size = new System.Drawing.Size(132, 30);
            this.btnUncrack.TabIndex = 1;
            this.btnUncrack.Text = "Uncrack";
            this.btnUncrack.UseVisualStyleBackColor = true;
            // 
            // chkAcrobat
            // 
            this.chkAcrobat.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAcrobat.AutoSize = true;
            this.chkAcrobat.Checked = true;
            this.chkAcrobat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcrobat.Image = global::AdobeCS6CrackAssistant.Properties.Resources.acrobat;
            this.chkAcrobat.Location = new System.Drawing.Point(6, 19);
            this.chkAcrobat.Name = "chkAcrobat";
            this.chkAcrobat.Size = new System.Drawing.Size(38, 38);
            this.chkAcrobat.TabIndex = 2;
            this.chkAcrobat.UseVisualStyleBackColor = true;

            // Checkboxes
            this.chkAcrobat.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkAfterEffects.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkAudition.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkBridge.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkDreamweaver.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkEncore.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkFireworks.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkFlash.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkFlashBuilder.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkIllustrator.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkInDesign.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkMediaEncoder.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkPhotoshop.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkPrelude.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkPremiere.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.chkSpeedGrade.CheckedChanged += new System.EventHandler(this.CheckedChanged);

            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkSpeedGrade);
            this.groupBox1.Controls.Add(this.chkPremiere);
            this.groupBox1.Controls.Add(this.chkPrelude);
            this.groupBox1.Controls.Add(this.chkPhotoshop);
            this.groupBox1.Controls.Add(this.chkMediaEncoder);
            this.groupBox1.Controls.Add(this.chkInDesign);
            this.groupBox1.Controls.Add(this.chkIllustrator);
            this.groupBox1.Controls.Add(this.chkFlashBuilder);
            this.groupBox1.Controls.Add(this.chkFlash);
            this.groupBox1.Controls.Add(this.chkFireworks);
            this.groupBox1.Controls.Add(this.chkEncore);
            this.groupBox1.Controls.Add(this.chkDreamweaver);
            this.groupBox1.Controls.Add(this.chkBridge);
            this.groupBox1.Controls.Add(this.chkAudition);
            this.groupBox1.Controls.Add(this.chkAfterEffects);
            this.groupBox1.Controls.Add(this.chkAcrobat);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 154);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programs";
            // 
            // chkSpeedGrade
            // 
            this.chkSpeedGrade.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSpeedGrade.AutoSize = true;
            this.chkSpeedGrade.Checked = true;
            this.chkSpeedGrade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpeedGrade.Image = global::AdobeCS6CrackAssistant.Properties.Resources.speedgrade;
            this.chkSpeedGrade.Location = new System.Drawing.Point(138, 107);
            this.chkSpeedGrade.Name = "chkSpeedGrade";
            this.chkSpeedGrade.Size = new System.Drawing.Size(38, 38);
            this.chkSpeedGrade.TabIndex = 17;
            this.chkSpeedGrade.UseVisualStyleBackColor = true;
            // 
            // chkPremiere
            // 
            this.chkPremiere.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPremiere.AutoSize = true;
            this.chkPremiere.Checked = true;
            this.chkPremiere.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPremiere.Image = global::AdobeCS6CrackAssistant.Properties.Resources.premiere;
            this.chkPremiere.Location = new System.Drawing.Point(94, 107);
            this.chkPremiere.Name = "chkPremiere";
            this.chkPremiere.Size = new System.Drawing.Size(38, 38);
            this.chkPremiere.TabIndex = 16;
            this.chkPremiere.UseVisualStyleBackColor = true;
            // 
            // chkPrelude
            // 
            this.chkPrelude.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPrelude.AutoSize = true;
            this.chkPrelude.Checked = true;
            this.chkPrelude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrelude.Image = global::AdobeCS6CrackAssistant.Properties.Resources.prelude;
            this.chkPrelude.Location = new System.Drawing.Point(50, 107);
            this.chkPrelude.Name = "chkPrelude";
            this.chkPrelude.Size = new System.Drawing.Size(38, 38);
            this.chkPrelude.TabIndex = 15;
            this.chkPrelude.UseVisualStyleBackColor = true;
            // 
            // chkPhotoshop
            // 
            this.chkPhotoshop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPhotoshop.AutoSize = true;
            this.chkPhotoshop.Checked = true;
            this.chkPhotoshop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhotoshop.Image = global::AdobeCS6CrackAssistant.Properties.Resources.photoshop;
            this.chkPhotoshop.Location = new System.Drawing.Point(6, 107);
            this.chkPhotoshop.Name = "chkPhotoshop";
            this.chkPhotoshop.Size = new System.Drawing.Size(38, 38);
            this.chkPhotoshop.TabIndex = 14;
            this.chkPhotoshop.UseVisualStyleBackColor = true;
            // 
            // chkMediaEncoder
            // 
            this.chkMediaEncoder.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMediaEncoder.AutoSize = true;
            this.chkMediaEncoder.Checked = true;
            this.chkMediaEncoder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMediaEncoder.Image = global::AdobeCS6CrackAssistant.Properties.Resources.mediaencoder;
            this.chkMediaEncoder.Location = new System.Drawing.Point(226, 63);
            this.chkMediaEncoder.Name = "chkMediaEncoder";
            this.chkMediaEncoder.Size = new System.Drawing.Size(38, 38);
            this.chkMediaEncoder.TabIndex = 13;
            this.chkMediaEncoder.UseVisualStyleBackColor = true;
            // 
            // chkInDesign
            // 
            this.chkInDesign.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInDesign.AutoSize = true;
            this.chkInDesign.Checked = true;
            this.chkInDesign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInDesign.Image = global::AdobeCS6CrackAssistant.Properties.Resources.indesign;
            this.chkInDesign.Location = new System.Drawing.Point(182, 63);
            this.chkInDesign.Name = "chkInDesign";
            this.chkInDesign.Size = new System.Drawing.Size(38, 38);
            this.chkInDesign.TabIndex = 12;
            this.chkInDesign.UseVisualStyleBackColor = true;
            // 
            // chkIllustrator
            // 
            this.chkIllustrator.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIllustrator.AutoSize = true;
            this.chkIllustrator.Checked = true;
            this.chkIllustrator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIllustrator.Image = global::AdobeCS6CrackAssistant.Properties.Resources.illustrator;
            this.chkIllustrator.Location = new System.Drawing.Point(138, 63);
            this.chkIllustrator.Name = "chkIllustrator";
            this.chkIllustrator.Size = new System.Drawing.Size(38, 38);
            this.chkIllustrator.TabIndex = 11;
            this.chkIllustrator.UseVisualStyleBackColor = true;
            // 
            // chkFlashBuilder
            // 
            this.chkFlashBuilder.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFlashBuilder.AutoSize = true;
            this.chkFlashBuilder.Checked = true;
            this.chkFlashBuilder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFlashBuilder.Image = global::AdobeCS6CrackAssistant.Properties.Resources.flashbuilder;
            this.chkFlashBuilder.Location = new System.Drawing.Point(94, 63);
            this.chkFlashBuilder.Name = "chkFlashBuilder";
            this.chkFlashBuilder.Size = new System.Drawing.Size(38, 38);
            this.chkFlashBuilder.TabIndex = 10;
            this.chkFlashBuilder.UseVisualStyleBackColor = true;
            // 
            // chkFlash
            // 
            this.chkFlash.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFlash.AutoSize = true;
            this.chkFlash.Checked = true;
            this.chkFlash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFlash.Image = global::AdobeCS6CrackAssistant.Properties.Resources.flash;
            this.chkFlash.Location = new System.Drawing.Point(50, 63);
            this.chkFlash.Name = "chkFlash";
            this.chkFlash.Size = new System.Drawing.Size(38, 38);
            this.chkFlash.TabIndex = 9;
            this.chkFlash.UseVisualStyleBackColor = true;
            // 
            // chkFireworks
            // 
            this.chkFireworks.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFireworks.AutoSize = true;
            this.chkFireworks.Checked = true;
            this.chkFireworks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFireworks.Image = global::AdobeCS6CrackAssistant.Properties.Resources.fireworks;
            this.chkFireworks.Location = new System.Drawing.Point(6, 63);
            this.chkFireworks.Name = "chkFireworks";
            this.chkFireworks.Size = new System.Drawing.Size(38, 38);
            this.chkFireworks.TabIndex = 8;
            this.chkFireworks.UseVisualStyleBackColor = true;
            // 
            // chkEncore
            // 
            this.chkEncore.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEncore.AutoSize = true;
            this.chkEncore.Checked = true;
            this.chkEncore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncore.Image = global::AdobeCS6CrackAssistant.Properties.Resources.encore;
            this.chkEncore.Location = new System.Drawing.Point(226, 19);
            this.chkEncore.Name = "chkEncore";
            this.chkEncore.Size = new System.Drawing.Size(38, 38);
            this.chkEncore.TabIndex = 7;
            this.chkEncore.UseVisualStyleBackColor = true;
            // 
            // chkDreamweaver
            // 
            this.chkDreamweaver.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDreamweaver.AutoSize = true;
            this.chkDreamweaver.Checked = true;
            this.chkDreamweaver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDreamweaver.Image = global::AdobeCS6CrackAssistant.Properties.Resources.dreamweaver;
            this.chkDreamweaver.Location = new System.Drawing.Point(182, 19);
            this.chkDreamweaver.Name = "chkDreamweaver";
            this.chkDreamweaver.Size = new System.Drawing.Size(38, 38);
            this.chkDreamweaver.TabIndex = 6;
            this.chkDreamweaver.UseVisualStyleBackColor = true;
            // 
            // chkBridge
            // 
            this.chkBridge.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBridge.AutoSize = true;
            this.chkBridge.Checked = true;
            this.chkBridge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBridge.Image = global::AdobeCS6CrackAssistant.Properties.Resources.bridge;
            this.chkBridge.Location = new System.Drawing.Point(138, 19);
            this.chkBridge.Name = "chkBridge";
            this.chkBridge.Size = new System.Drawing.Size(38, 38);
            this.chkBridge.TabIndex = 5;
            this.chkBridge.UseVisualStyleBackColor = true;
            // 
            // chkAudition
            // 
            this.chkAudition.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAudition.AutoSize = true;
            this.chkAudition.Checked = true;
            this.chkAudition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAudition.Image = global::AdobeCS6CrackAssistant.Properties.Resources.audition;
            this.chkAudition.Location = new System.Drawing.Point(94, 19);
            this.chkAudition.Name = "chkAudition";
            this.chkAudition.Size = new System.Drawing.Size(38, 38);
            this.chkAudition.TabIndex = 4;
            this.chkAudition.UseVisualStyleBackColor = true;
            // 
            // chkAfterEffects
            // 
            this.chkAfterEffects.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAfterEffects.AutoSize = true;
            this.chkAfterEffects.Checked = true;
            this.chkAfterEffects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAfterEffects.Image = global::AdobeCS6CrackAssistant.Properties.Resources.aftereffects;
            this.chkAfterEffects.Location = new System.Drawing.Point(50, 19);
            this.chkAfterEffects.Name = "chkAfterEffects";
            this.chkAfterEffects.Size = new System.Drawing.Size(38, 38);
            this.chkAfterEffects.TabIndex = 3;
            this.chkAfterEffects.UseVisualStyleBackColor = true;
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(18, 173);
            this.pbMain.Name = "pbMain";
            this.pbMain.ShowProgressIndicators = true;
            this.pbMain.Size = new System.Drawing.Size(258, 24);
            this.pbMain.TabIndex = 5;
            this.pbMain.Text = "0 %";
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCrack;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 244);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUncrack);
            this.Controls.Add(this.btnCrack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrack;
        private System.Windows.Forms.Button btnUncrack;
        private System.Windows.Forms.CheckBox chkAcrobat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSpeedGrade;
        private System.Windows.Forms.CheckBox chkPremiere;
        private System.Windows.Forms.CheckBox chkPrelude;
        private System.Windows.Forms.CheckBox chkPhotoshop;
        private System.Windows.Forms.CheckBox chkMediaEncoder;
        private System.Windows.Forms.CheckBox chkInDesign;
        private System.Windows.Forms.CheckBox chkIllustrator;
        private System.Windows.Forms.CheckBox chkFlashBuilder;
        private System.Windows.Forms.CheckBox chkFlash;
        private System.Windows.Forms.CheckBox chkFireworks;
        private System.Windows.Forms.CheckBox chkEncore;
        private System.Windows.Forms.CheckBox chkDreamweaver;
        private System.Windows.Forms.CheckBox chkBridge;
        private System.Windows.Forms.CheckBox chkAudition;
        private System.Windows.Forms.CheckBox chkAfterEffects;
        private Telerik.WinControls.UI.RadProgressBar pbMain;
        private System.Windows.Forms.Timer timer;

    }
}