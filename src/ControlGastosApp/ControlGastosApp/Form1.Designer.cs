namespace ControlGastosApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbPeriod = new ComboBox();
            SuspendLayout();
            // 
            // cmbPeriod
            // 
            cmbPeriod.AccessibleName = "";
            cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriod.FormattingEnabled = true;
            cmbPeriod.Location = new Point(5, 5);
            cmbPeriod.Name = "cmbPeriod";
            cmbPeriod.Size = new Size(121, 23);
            cmbPeriod.TabIndex = 0;
            cmbPeriod.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbPeriod);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbPeriod;
    }
}
