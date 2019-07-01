namespace NrxRelayController
{
    partial class mainForm
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
            this.toggleSwitch1 = new NrxRelayController.ToggleSwitch();
            this.toggleSwitch2 = new NrxRelayController.ToggleSwitch();
            this.relayLabel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.ActiveColor = System.Drawing.Color.DarkRed;
            this.toggleSwitch1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toggleSwitch1.ButtonColor = System.Drawing.Color.Silver;
            this.toggleSwitch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toggleSwitch1.Location = new System.Drawing.Point(61, 52);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.PassiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleSwitch1.Size = new System.Drawing.Size(28, 44);
            this.toggleSwitch1.SwitchLabel = null;
            this.toggleSwitch1.TabIndex = 0;
            // 
            // toggleSwitch2
            // 
            this.toggleSwitch2.ActiveColor = System.Drawing.Color.DarkRed;
            this.toggleSwitch2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toggleSwitch2.ButtonColor = System.Drawing.Color.Silver;
            this.toggleSwitch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toggleSwitch2.Location = new System.Drawing.Point(182, 52);
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.PassiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleSwitch2.Size = new System.Drawing.Size(28, 44);
            this.toggleSwitch2.SwitchLabel = null;
            this.toggleSwitch2.TabIndex = 1;
            // 
            // relayLabel1
            // 
            this.relayLabel1.AutoSize = true;
            this.relayLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.relayLabel1.ForeColor = System.Drawing.Color.DarkRed;
            this.relayLabel1.Location = new System.Drawing.Point(47, 99);
            this.relayLabel1.Name = "relayLabel1";
            this.relayLabel1.Size = new System.Drawing.Size(69, 20);
            this.relayLabel1.TabIndex = 2;
            this.relayLabel1.Text = "Relay 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(166, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Relay 2";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(277, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.relayLabel1);
            this.Controls.Add(this.toggleSwitch2);
            this.Controls.Add(this.toggleSwitch1);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Nrx Relay Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToggleSwitch toggleSwitch1;
        private ToggleSwitch toggleSwitch2;
        private System.Windows.Forms.Label relayLabel1;
        private System.Windows.Forms.Label label1;
    }
}

