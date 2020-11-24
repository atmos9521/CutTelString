namespace StringHandle
{
    partial class CompareTelString
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
            this.CompareTelString_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CompareTelString_txt
            // 
            this.CompareTelString_txt.AllowDrop = true;
            this.CompareTelString_txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompareTelString_txt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CompareTelString_txt.Location = new System.Drawing.Point(0, 0);
            this.CompareTelString_txt.Multiline = true;
            this.CompareTelString_txt.Name = "CompareTelString_txt";
            this.CompareTelString_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CompareTelString_txt.Size = new System.Drawing.Size(982, 453);
            this.CompareTelString_txt.TabIndex = 0;
            this.CompareTelString_txt.TextChanged += new System.EventHandler(this.CompareTelString_txt_TextChanged);
            this.CompareTelString_txt.DragOver += new System.Windows.Forms.DragEventHandler(this.CompareTelString_txt_DragOver);
            // 
            // CompareTelString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.CompareTelString_txt);
            this.Name = "CompareTelString";
            this.Text = "CompareTelString";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompareTelString_FormClosed);
            this.Load += new System.EventHandler(this.CompareTelString_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompareTelString_txt;
    }
}