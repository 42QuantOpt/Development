namespace XingAPICSharp
{
    partial class XingAPIForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.현재가 = new System.Windows.Forms.Label();
            this.매수1호가 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.매수2호가 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.매수3호가 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.매수4호가 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.매수5호가 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(108, 105);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 29);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "종료";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(44, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(58, 29);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(90, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(97, 21);
            this.textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(97, 21);
            this.textBox2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "공인인증";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "비밀번호";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(97, 21);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "아이디";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "현재가";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "매수1호가";
            // 
            // 현재가
            // 
            this.현재가.AutoSize = true;
            this.현재가.Location = new System.Drawing.Point(88, 222);
            this.현재가.Name = "현재가";
            this.현재가.Size = new System.Drawing.Size(41, 12);
            this.현재가.TabIndex = 18;
            this.현재가.Text = "현재가";
            // 
            // 매수1호가
            // 
            this.매수1호가.AutoSize = true;
            this.매수1호가.Location = new System.Drawing.Point(88, 245);
            this.매수1호가.Name = "매수1호가";
            this.매수1호가.Size = new System.Drawing.Size(59, 12);
            this.매수1호가.TabIndex = 19;
            this.매수1호가.Text = "매수1호가";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 186);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(113, 21);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "000660";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 19);
            this.button1.TabIndex = 21;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(19, 381);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(41, 12);
            this.lblMessage.TabIndex = 22;
            this.lblMessage.Text = "메세지";
            // 
            // 매수2호가
            // 
            this.매수2호가.AutoSize = true;
            this.매수2호가.Location = new System.Drawing.Point(88, 268);
            this.매수2호가.Name = "매수2호가";
            this.매수2호가.Size = new System.Drawing.Size(59, 12);
            this.매수2호가.TabIndex = 24;
            this.매수2호가.Text = "매수2호가";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "매수2호가";
            // 
            // 매수3호가
            // 
            this.매수3호가.AutoSize = true;
            this.매수3호가.Location = new System.Drawing.Point(88, 290);
            this.매수3호가.Name = "매수3호가";
            this.매수3호가.Size = new System.Drawing.Size(59, 12);
            this.매수3호가.TabIndex = 26;
            this.매수3호가.Text = "매수3호가";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "매수3호가";
            // 
            // 매수4호가
            // 
            this.매수4호가.AutoSize = true;
            this.매수4호가.Location = new System.Drawing.Point(88, 311);
            this.매수4호가.Name = "매수4호가";
            this.매수4호가.Size = new System.Drawing.Size(59, 12);
            this.매수4호가.TabIndex = 28;
            this.매수4호가.Text = "매수4호가";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "매수4호가";
            // 
            // 매수5호가
            // 
            this.매수5호가.AutoSize = true;
            this.매수5호가.Location = new System.Drawing.Point(88, 332);
            this.매수5호가.Name = "매수5호가";
            this.매수5호가.Size = new System.Drawing.Size(59, 12);
            this.매수5호가.TabIndex = 30;
            this.매수5호가.Text = "매수5호가";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 332);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "매수5호가";
            // 
            // XingAPIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 413);
            this.Controls.Add(this.매수5호가);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.매수4호가);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.매수3호가);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.매수2호가);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.매수1호가);
            this.Controls.Add(this.현재가);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "XingAPIForm";
            this.Text = "XingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label 현재가;
        public System.Windows.Forms.Label 매수1호가;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.Label 매수2호가;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label 매수3호가;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label 매수4호가;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label 매수5호가;
        public System.Windows.Forms.Label label13;
    }
}

