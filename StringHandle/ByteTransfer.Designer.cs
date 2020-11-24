namespace StringHandle
{
    partial class ByteTransfer
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
            this.HEXTransfer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AfterTransfer = new System.Windows.Forms.TextBox();
            this.BeforeTransfer = new System.Windows.Forms.TextBox();
            this.StringToUTF8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HEXTransfer
            // 
            this.HEXTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HEXTransfer.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HEXTransfer.Location = new System.Drawing.Point(251, 483);
            this.HEXTransfer.Name = "HEXTransfer";
            this.HEXTransfer.Size = new System.Drawing.Size(234, 54);
            this.HEXTransfer.TabIndex = 7;
            this.HEXTransfer.Text = "HEX to String";
            this.HEXTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HEXTransfer.UseVisualStyleBackColor = true;
            this.HEXTransfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(346, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 48);
            this.label1.TabIndex = 6;
            this.label1.Text = "↓";
            // 
            // AfterTransfer
            // 
            this.AfterTransfer.AllowDrop = true;
            this.AfterTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AfterTransfer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AfterTransfer.Location = new System.Drawing.Point(21, 260);
            this.AfterTransfer.Multiline = true;
            this.AfterTransfer.Name = "AfterTransfer";
            this.AfterTransfer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.AfterTransfer.Size = new System.Drawing.Size(737, 168);
            this.AfterTransfer.TabIndex = 5;
            // 
            // BeforeTransfer
            // 
            this.BeforeTransfer.AllowDrop = true;
            this.BeforeTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BeforeTransfer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BeforeTransfer.Location = new System.Drawing.Point(21, 29);
            this.BeforeTransfer.Multiline = true;
            this.BeforeTransfer.Name = "BeforeTransfer";
            this.BeforeTransfer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.BeforeTransfer.Size = new System.Drawing.Size(737, 168);
            this.BeforeTransfer.TabIndex = 4;
            // 
            // StringToUTF8
            // 
            this.StringToUTF8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StringToUTF8.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StringToUTF8.Location = new System.Drawing.Point(524, 483);
            this.StringToUTF8.Name = "StringToUTF8";
            this.StringToUTF8.Size = new System.Drawing.Size(234, 54);
            this.StringToUTF8.TabIndex = 8;
            this.StringToUTF8.Text = "String to UTF-8";
            this.StringToUTF8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StringToUTF8.UseVisualStyleBackColor = true;
            this.StringToUTF8.Click += new System.EventHandler(this.StringToUTF8_Click);
            // 
            // ByteTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 549);
            this.Controls.Add(this.StringToUTF8);
            this.Controls.Add(this.HEXTransfer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AfterTransfer);
            this.Controls.Add(this.BeforeTransfer);
            this.Name = "ByteTransfer";
            this.Text = "ByteTransfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HEXTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AfterTransfer;
        private System.Windows.Forms.TextBox BeforeTransfer;
        private System.Windows.Forms.Button StringToUTF8;
    }
}