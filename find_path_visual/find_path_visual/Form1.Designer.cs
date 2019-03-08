namespace find_path_visual
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
            this.pb = new System.Windows.Forms.PictureBox();
            this.btn_generate_map = new System.Windows.Forms.Button();
            this.btn_find_path = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_width = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_path = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.Location = new System.Drawing.Point(441, 11);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(640, 640);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // btn_generate_map
            // 
            this.btn_generate_map.Location = new System.Drawing.Point(6, 72);
            this.btn_generate_map.Name = "btn_generate_map";
            this.btn_generate_map.Size = new System.Drawing.Size(149, 46);
            this.btn_generate_map.TabIndex = 1;
            this.btn_generate_map.Text = "Generate Map";
            this.btn_generate_map.UseVisualStyleBackColor = true;
            this.btn_generate_map.Click += new System.EventHandler(this.btn_generate_map_Click);
            // 
            // btn_find_path
            // 
            this.btn_find_path.Enabled = false;
            this.btn_find_path.Location = new System.Drawing.Point(34, 160);
            this.btn_find_path.Name = "btn_find_path";
            this.btn_find_path.Size = new System.Drawing.Size(112, 46);
            this.btn_find_path.TabIndex = 2;
            this.btn_find_path.Text = "Find Path";
            this.btn_find_path.UseVisualStyleBackColor = true;
            this.btn_find_path.Click += new System.EventHandler(this.btn_find_path_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_height);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_generate_map);
            this.groupBox1.Controls.Add(this.txt_width);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 127);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Map";
            // 
            // txt_height
            // 
            this.txt_height.Enabled = false;
            this.txt_height.Location = new System.Drawing.Point(55, 46);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(100, 20);
            this.txt_height.TabIndex = 3;
            this.txt_height.Text = "64";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            // 
            // txt_width
            // 
            this.txt_width.Location = new System.Drawing.Point(55, 20);
            this.txt_width.Name = "txt_width";
            this.txt_width.Size = new System.Drawing.Size(100, 20);
            this.txt_width.TabIndex = 1;
            this.txt_width.Text = "64";
            this.txt_width.TextChanged += new System.EventHandler(this.txt_width_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // lst_path
            // 
            this.lst_path.FormattingEnabled = true;
            this.lst_path.Location = new System.Drawing.Point(188, 28);
            this.lst_path.Name = "lst_path";
            this.lst_path.Size = new System.Drawing.Size(247, 628);
            this.lst_path.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path Found";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 663);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lst_path);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_find_path);
            this.Controls.Add(this.pb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Find Path";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Button btn_generate_map;
        private System.Windows.Forms.Button btn_find_path;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_path;
        private System.Windows.Forms.Label label3;
    }
}

