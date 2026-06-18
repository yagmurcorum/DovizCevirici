namespace DovizCevirici
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
            lblSourceCurrency = new Label();
            cmbSourceCurrency = new ComboBox();
            lblTargetCurrency = new Label();
            cmbTargetCurrency = new ComboBox();
            lblAmount = new Label();
            lblResult = new Label();
            txtAmount = new TextBox();
            btnConvert = new Button();
            SuspendLayout();
            // 
            // lblSourceCurrency
            // 
            lblSourceCurrency.AutoSize = true;
            lblSourceCurrency.Location = new Point(23, 35);
            lblSourceCurrency.Name = "lblSourceCurrency";
            lblSourceCurrency.Size = new Size(131, 20);
            lblSourceCurrency.TabIndex = 0;
            lblSourceCurrency.Text = "Kaynak Para Birimi";
            // 
            // cmbSourceCurrency
            // 
            cmbSourceCurrency.FormattingEnabled = true;
            cmbSourceCurrency.Location = new Point(12, 59);
            cmbSourceCurrency.Name = "cmbSourceCurrency";
            cmbSourceCurrency.Size = new Size(151, 28);
            cmbSourceCurrency.TabIndex = 1;
            // 
            // lblTargetCurrency
            // 
            lblTargetCurrency.AutoSize = true;
            lblTargetCurrency.Location = new Point(193, 35);
            lblTargetCurrency.Name = "lblTargetCurrency";
            lblTargetCurrency.Size = new Size(125, 20);
            lblTargetCurrency.TabIndex = 2;
            lblTargetCurrency.Text = "Hedef Para Birimi";
            // 
            // cmbTargetCurrency
            // 
            cmbTargetCurrency.FormattingEnabled = true;
            cmbTargetCurrency.Location = new Point(184, 59);
            cmbTargetCurrency.Name = "cmbTargetCurrency";
            cmbTargetCurrency.Size = new Size(151, 28);
            cmbTargetCurrency.TabIndex = 3;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(387, 35);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(43, 20);
            lblAmount.TabIndex = 4;
            lblAmount.Text = "Tutar";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(540, 59);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(187, 20);
            lblResult.TabIndex = 5;
            lblResult.Text = "Sonuç burada gösterilecek.";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(356, 59);
            txtAmount.Multiline = true;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 33);
            txtAmount.TabIndex = 6;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(612, 101);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(94, 29);
            btnConvert.TabIndex = 7;
            btnConvert.Text = "Çevir";
            btnConvert.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConvert);
            Controls.Add(txtAmount);
            Controls.Add(lblResult);
            Controls.Add(lblAmount);
            Controls.Add(cmbTargetCurrency);
            Controls.Add(lblTargetCurrency);
            Controls.Add(cmbSourceCurrency);
            Controls.Add(lblSourceCurrency);
            Name = "Form1";
            Text = "Döviz Çevirici";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSourceCurrency;
        private ComboBox cmbSourceCurrency;
        private Label lblTargetCurrency;
        private ComboBox cmbTargetCurrency;
        private Label lblAmount;
        private Label lblResult;
        private TextBox txtAmount;
        private Button btnConvert;
    }
}
