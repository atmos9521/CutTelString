namespace StringHandle
{
    partial class TelString
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
            this.telStrings_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // telStrings_txt
            // 
            this.telStrings_txt.AllowDrop = true;
            this.telStrings_txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telStrings_txt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.telStrings_txt.Location = new System.Drawing.Point(0, 0);
            this.telStrings_txt.Multiline = true;
            this.telStrings_txt.Name = "telStrings_txt";
            this.telStrings_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.telStrings_txt.Size = new System.Drawing.Size(982, 453);
            this.telStrings_txt.TabIndex = 0;
            this.telStrings_txt.TextChanged += new System.EventHandler(this.telStrings_txt_TextChanged);
            this.telStrings_txt.DragOver += new System.Windows.Forms.DragEventHandler(this.telStrings_txt_DragOver);
            // 
            // TelString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.telStrings_txt);
            this.Name = "TelString";
            this.Text = "電文字串";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelString_FormClosed);
            this.Load += new System.EventHandler(this.TelString_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TelString_DragDrop);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox telStrings_txt;
    }
}