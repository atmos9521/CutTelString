namespace StringHandle
{
    partial class TestPage
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Transfer16to2 = new System.Windows.Forms.Button();
            this.Transfer2to16 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(32, 52);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(627, 125);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(32, 258);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(627, 125);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(305, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "↓";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(32, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "16toString";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Transfer16to2
            // 
            this.Transfer16to2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Transfer16to2.Location = new System.Drawing.Point(263, 418);
            this.Transfer16to2.Name = "Transfer16to2";
            this.Transfer16to2.Size = new System.Drawing.Size(161, 54);
            this.Transfer16to2.TabIndex = 4;
            this.Transfer16to2.Text = "16to2";
            this.Transfer16to2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Transfer16to2.UseVisualStyleBackColor = true;
            this.Transfer16to2.Click += new System.EventHandler(this.Transfer16to2_Click);
            // 
            // Transfer2to16
            // 
            this.Transfer2to16.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Transfer2to16.Location = new System.Drawing.Point(498, 418);
            this.Transfer2to16.Name = "Transfer2to16";
            this.Transfer2to16.Size = new System.Drawing.Size(161, 54);
            this.Transfer2to16.TabIndex = 5;
            this.Transfer2to16.Text = "2to16";
            this.Transfer2to16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Transfer2to16.UseVisualStyleBackColor = true;
            this.Transfer2to16.Click += new System.EventHandler(this.Transfer2to16_Click);
            // 
            // TestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 498);
            this.Controls.Add(this.Transfer2to16);
            this.Controls.Add(this.Transfer16to2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "TestPage";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Transfer16to2;
        private System.Windows.Forms.Button Transfer2to16;
    }
}