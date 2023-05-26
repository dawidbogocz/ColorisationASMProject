
namespace APLGrayscale
{
    partial class Form1
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
            this.grayscale = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PINK = new System.Windows.Forms.RadioButton();
            this.PURPLE = new System.Windows.Forms.RadioButton();
            this.BLUE = new System.Windows.Forms.RadioButton();
            this.GREEN = new System.Windows.Forms.RadioButton();
            this.YELLOW = new System.Windows.Forms.RadioButton();
            this.ORANGE = new System.Windows.Forms.RadioButton();
            this.RED = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayscale
            // 
            this.grayscale.Location = new System.Drawing.Point(100, 30);
            this.grayscale.Name = "grayscale";
            this.grayscale.Size = new System.Drawing.Size(75, 23);
            this.grayscale.TabIndex = 21;
            this.grayscale.Text = "Grayscale";
            this.grayscale.UseVisualStyleBackColor = true;
            this.grayscale.Click += new System.EventHandler(this.grayscale_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.PINK);
            this.groupBox2.Controls.Add(this.PURPLE);
            this.groupBox2.Controls.Add(this.BLUE);
            this.groupBox2.Controls.Add(this.GREEN);
            this.groupBox2.Controls.Add(this.YELLOW);
            this.groupBox2.Controls.Add(this.ORANGE);
            this.groupBox2.Controls.Add(this.RED);
            this.groupBox2.Location = new System.Drawing.Point(104, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 197);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chose Color";
            // 
            // PINK
            // 
            this.PINK.AutoSize = true;
            this.PINK.Location = new System.Drawing.Point(27, 164);
            this.PINK.Name = "PINK";
            this.PINK.Size = new System.Drawing.Size(50, 17);
            this.PINK.TabIndex = 12;
            this.PINK.TabStop = true;
            this.PINK.Text = "PINK";
            this.PINK.UseVisualStyleBackColor = true;
            this.PINK.CheckedChanged += new System.EventHandler(this.PINK_CheckedChanged);
            // 
            // PURPLE
            // 
            this.PURPLE.AutoSize = true;
            this.PURPLE.Location = new System.Drawing.Point(27, 141);
            this.PURPLE.Name = "PURPLE";
            this.PURPLE.Size = new System.Drawing.Size(68, 17);
            this.PURPLE.TabIndex = 11;
            this.PURPLE.TabStop = true;
            this.PURPLE.Text = "PURPLE";
            this.PURPLE.UseVisualStyleBackColor = true;
            this.PURPLE.CheckedChanged += new System.EventHandler(this.PURPLE_CheckedChanged);
            // 
            // BLUE
            // 
            this.BLUE.AutoSize = true;
            this.BLUE.Location = new System.Drawing.Point(27, 118);
            this.BLUE.Name = "BLUE";
            this.BLUE.Size = new System.Drawing.Size(53, 17);
            this.BLUE.TabIndex = 10;
            this.BLUE.TabStop = true;
            this.BLUE.Text = "BLUE";
            this.BLUE.UseVisualStyleBackColor = true;
            this.BLUE.CheckedChanged += new System.EventHandler(this.BLUE_CheckedChanged);
            // 
            // GREEN
            // 
            this.GREEN.AutoSize = true;
            this.GREEN.Location = new System.Drawing.Point(27, 95);
            this.GREEN.Name = "GREEN";
            this.GREEN.Size = new System.Drawing.Size(63, 17);
            this.GREEN.TabIndex = 9;
            this.GREEN.TabStop = true;
            this.GREEN.Text = "GREEN";
            this.GREEN.UseVisualStyleBackColor = true;
            this.GREEN.CheckedChanged += new System.EventHandler(this.GREEN_CheckedChanged);
            // 
            // YELLOW
            // 
            this.YELLOW.AutoSize = true;
            this.YELLOW.Location = new System.Drawing.Point(27, 72);
            this.YELLOW.Name = "YELLOW";
            this.YELLOW.Size = new System.Drawing.Size(70, 17);
            this.YELLOW.TabIndex = 8;
            this.YELLOW.TabStop = true;
            this.YELLOW.Text = "YELLOW";
            this.YELLOW.UseVisualStyleBackColor = true;
            this.YELLOW.CheckedChanged += new System.EventHandler(this.YELLOW_CheckedChanged);
            // 
            // ORANGE
            // 
            this.ORANGE.AutoSize = true;
            this.ORANGE.Location = new System.Drawing.Point(27, 49);
            this.ORANGE.Name = "ORANGE";
            this.ORANGE.Size = new System.Drawing.Size(71, 17);
            this.ORANGE.TabIndex = 7;
            this.ORANGE.TabStop = true;
            this.ORANGE.Text = "ORANGE";
            this.ORANGE.UseVisualStyleBackColor = true;
            this.ORANGE.CheckedChanged += new System.EventHandler(this.ORANGE_CheckedChanged);
            // 
            // RED
            // 
            this.RED.AutoSize = true;
            this.RED.Location = new System.Drawing.Point(27, 26);
            this.RED.Name = "RED";
            this.RED.Size = new System.Drawing.Size(48, 17);
            this.RED.TabIndex = 6;
            this.RED.TabStop = true;
            this.RED.Text = "RED";
            this.RED.UseVisualStyleBackColor = true;
            this.RED.CheckedChanged += new System.EventHandler(this.RED_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(417, 268);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(331, 237);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(417, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(254, 30);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(104, 30);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 16;
            this.open.Text = "Open File";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(104, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 126);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ASM";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "C#";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.grayscale);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(104, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 74);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 511);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 542);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Color Isolation";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button grayscale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton PINK;
        private System.Windows.Forms.RadioButton PURPLE;
        private System.Windows.Forms.RadioButton BLUE;
        private System.Windows.Forms.RadioButton GREEN;
        private System.Windows.Forms.RadioButton YELLOW;
        private System.Windows.Forms.RadioButton ORANGE;
        private System.Windows.Forms.RadioButton RED;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

