namespace Exercise_1
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdb_모의계좌 = new System.Windows.Forms.RadioButton();
            this.rdb_실계좌 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.계좌번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비밀번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.확인 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.계좌명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상품 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "4uraz";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(48, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "101010";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pass";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(48, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cert";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdb_모의계좌);
            this.panel1.Controls.Add(this.rdb_실계좌);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 128);
            this.panel1.TabIndex = 6;
            // 
            // rdb_모의계좌
            // 
            this.rdb_모의계좌.AutoSize = true;
            this.rdb_모의계좌.Checked = true;
            this.rdb_모의계좌.Location = new System.Drawing.Point(154, 58);
            this.rdb_모의계좌.Name = "rdb_모의계좌";
            this.rdb_모의계좌.Size = new System.Drawing.Size(71, 16);
            this.rdb_모의계좌.TabIndex = 8;
            this.rdb_모의계좌.TabStop = true;
            this.rdb_모의계좌.Text = "모의투자";
            this.rdb_모의계좌.UseVisualStyleBackColor = true;
            this.rdb_모의계좌.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdb_실계좌
            // 
            this.rdb_실계좌.AutoSize = true;
            this.rdb_실계좌.Location = new System.Drawing.Point(155, 35);
            this.rdb_실계좌.Name = "rdb_실계좌";
            this.rdb_실계좌.Size = new System.Drawing.Size(59, 16);
            this.rdb_실계좌.TabIndex = 7;
            this.rdb_실계좌.Text = "실계좌";
            this.rdb_실계좌.UseVisualStyleBackColor = true;
            this.rdb_실계좌.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.계좌번호,
            this.비밀번호,
            this.확인,
            this.계좌명,
            this.상품});
            this.dataGridView1.Location = new System.Drawing.Point(3, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(423, 196);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // 계좌번호
            // 
            this.계좌번호.HeaderText = "계좌번호";
            this.계좌번호.Name = "계좌번호";
            this.계좌번호.ReadOnly = true;
            // 
            // 비밀번호
            // 
            this.비밀번호.HeaderText = "비밀번호";
            this.비밀번호.Name = "비밀번호";
            // 
            // 확인
            // 
            this.확인.HeaderText = "확인";
            this.확인.Name = "확인";
            // 
            // 계좌명
            // 
            this.계좌명.HeaderText = "계좌명";
            this.계좌명.Name = "계좌명";
            this.계좌명.ReadOnly = true;
            this.계좌명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.계좌명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 상품
            // 
            this.상품.HeaderText = "상품";
            this.상품.Name = "상품";
            this.상품.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(238, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 280);
            this.panel2.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(287, 209);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "확인";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "일괄등록";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(3, 209);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "0000";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 291);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdb_모의계좌;
        private System.Windows.Forms.RadioButton rdb_실계좌;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 계좌번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비밀번호;
        private System.Windows.Forms.DataGridViewButtonColumn 확인;
        private System.Windows.Forms.DataGridViewTextBoxColumn 계좌명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상품;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
    }
}