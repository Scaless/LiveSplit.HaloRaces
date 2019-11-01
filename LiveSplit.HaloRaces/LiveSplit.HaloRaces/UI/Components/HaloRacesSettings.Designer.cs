namespace LiveSplit.HaloRaces.UI.Components
{
    partial class HaloRacesSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.linkHaloRunsRaceKey = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbRaceActive = new System.Windows.Forms.CheckBox();
            this.lblRaceActive = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.42857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.57143F));
            this.tableLayoutPanel1.Controls.Add(this.linkHaloRunsRaceKey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbRaceActive, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRaceActive, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 138);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // linkHaloRunsRaceKey
            // 
            this.linkHaloRunsRaceKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkHaloRunsRaceKey.AutoSize = true;
            this.linkHaloRunsRaceKey.Location = new System.Drawing.Point(3, 6);
            this.linkHaloRunsRaceKey.Name = "linkHaloRunsRaceKey";
            this.linkHaloRunsRaceKey.Size = new System.Drawing.Size(110, 13);
            this.linkHaloRunsRaceKey.TabIndex = 0;
            this.linkHaloRunsRaceKey.TabStop = true;
            this.linkHaloRunsRaceKey.Text = "HaloRuns Race Key";
            this.linkHaloRunsRaceKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHaloRunsRaceKey_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(119, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // cbRaceActive
            // 
            this.cbRaceActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRaceActive.AutoSize = true;
            this.cbRaceActive.Location = new System.Drawing.Point(119, 29);
            this.cbRaceActive.Name = "cbRaceActive";
            this.cbRaceActive.Size = new System.Drawing.Size(228, 14);
            this.cbRaceActive.TabIndex = 2;
            this.cbRaceActive.UseVisualStyleBackColor = true;
            // 
            // lblRaceActive
            // 
            this.lblRaceActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRaceActive.AutoSize = true;
            this.lblRaceActive.Location = new System.Drawing.Point(3, 29);
            this.lblRaceActive.Name = "lblRaceActive";
            this.lblRaceActive.Size = new System.Drawing.Size(110, 13);
            this.lblRaceActive.TabIndex = 3;
            this.lblRaceActive.Text = "Race Active";
            // 
            // HaloRacesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HaloRacesSettings";
            this.Size = new System.Drawing.Size(357, 145);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkHaloRunsRaceKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbRaceActive;
        private System.Windows.Forms.Label lblRaceActive;
    }
}
