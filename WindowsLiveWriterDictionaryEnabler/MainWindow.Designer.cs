namespace WindowsLiveWriterDictionaryEnabler
{
    partial class MainWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbAvailableLanguages = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btEnableLanguages = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 208);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbAvailableLanguages);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 155);
            this.panel3.TabIndex = 1;
            // 
            // lbAvailableLanguages
            // 
            this.lbAvailableLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAvailableLanguages.FormattingEnabled = true;
            this.lbAvailableLanguages.Location = new System.Drawing.Point(0, 0);
            this.lbAvailableLanguages.Name = "lbAvailableLanguages";
            this.lbAvailableLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbAvailableLanguages.Size = new System.Drawing.Size(462, 155);
            this.lbAvailableLanguages.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btEnableLanguages);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 53);
            this.panel2.TabIndex = 0;
            // 
            // btEnableLanguages
            // 
            this.btEnableLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btEnableLanguages.Enabled = false;
            this.btEnableLanguages.Location = new System.Drawing.Point(0, 0);
            this.btEnableLanguages.Name = "btEnableLanguages";
            this.btEnableLanguages.Size = new System.Drawing.Size(462, 53);
            this.btEnableLanguages.TabIndex = 0;
            this.btEnableLanguages.Text = "Enable selected languages";
            this.btEnableLanguages.UseVisualStyleBackColor = true;
            this.btEnableLanguages.Click += new System.EventHandler(this.btEnableLanguages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 208);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Windows Live Writer Dictionary Enabler";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lbAvailableLanguages;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btEnableLanguages;
    }
}

