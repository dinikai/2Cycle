namespace TwoCycleDrive
{
    partial class COMForm
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
            this.comPortsCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectPortBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comPortsCombo
            // 
            this.comPortsCombo.FormattingEnabled = true;
            this.comPortsCombo.Items.AddRange(new object[] {
            "COM1",
            "COM2"});
            this.comPortsCombo.Location = new System.Drawing.Point(41, 29);
            this.comPortsCombo.Name = "comPortsCombo";
            this.comPortsCombo.Size = new System.Drawing.Size(157, 21);
            this.comPortsCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите COM-порт:";
            // 
            // selectPortBtn
            // 
            this.selectPortBtn.Location = new System.Drawing.Point(12, 56);
            this.selectPortBtn.Name = "selectPortBtn";
            this.selectPortBtn.Size = new System.Drawing.Size(186, 23);
            this.selectPortBtn.TabIndex = 2;
            this.selectPortBtn.Text = "Открыть";
            this.selectPortBtn.UseVisualStyleBackColor = true;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(13, 29);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(22, 21);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "R";
            this.refreshBtn.UseVisualStyleBackColor = true;
            // 
            // COMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 91);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.selectPortBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPortsCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "COMForm";
            this.Text = "Выберите COM-порт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comPortsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectPortBtn;
        private System.Windows.Forms.Button refreshBtn;
    }
}