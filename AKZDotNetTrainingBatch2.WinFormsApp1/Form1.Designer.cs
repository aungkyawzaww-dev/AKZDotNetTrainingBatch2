namespace AKZDotNetTrainingBatch2.WinFormsApp1
{
    partial class Form1
    {
        private const string V = "Form1";

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
            btnClick = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            Name = new Label();
            Phone = new Label();
            SuspendLayout();
            // 
            // btnClick
            // 
            btnClick.Location = new Point(649, 391);
            btnClick.Name = "btnClick";
            btnClick.Size = new Size(112, 34);
            btnClick.TabIndex = 0;
            btnClick.Text = " Click";
            btnClick.UseVisualStyleBackColor = true;
            btnClick.Click += btnClick_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 23);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 1;
            label1.Text = "Staff Code:";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(307, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(307, 31);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(29, 366);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(307, 31);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(29, 285);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(307, 31);
            textBox4.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 248);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 5;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 175);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 9;
            label5.Text = "Position:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "---SelectOne---", "Admin", "Staff" });
            comboBox1.Location = new Point(29, 203);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(307, 33);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(29, 104);
            Name.Name = "Name";
            Name.Size = new Size(104, 25);
            Name.TabIndex = 12;
            Name.Text = "Staff Name:";
            // 
            // Phone
            // 
            Phone.AutoSize = true;
            Phone.Location = new Point(29, 338);
            Phone.Name = "Phone";
            Phone.Size = new Size(62, 25);
            Phone.TabIndex = 14;
            Phone.Text = "Phone";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Phone);
            Controls.Add(Name);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(btnClick);
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClick;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private Label Name;
        private Label Phone;
    }
}
