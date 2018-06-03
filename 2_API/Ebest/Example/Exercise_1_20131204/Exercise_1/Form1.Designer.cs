namespace Exercise_1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선물계좌현황ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주식계좌현황ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.선옵주문ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주식주문ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.선물계좌현황ToolStripMenuItem,
            this.주식계좌현황ToolStripMenuItem,
            this.선옵주문ToolStripMenuItem,
            this.주식주문ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // 선물계좌현황ToolStripMenuItem
            // 
            this.선물계좌현황ToolStripMenuItem.Name = "선물계좌현황ToolStripMenuItem";
            this.선물계좌현황ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.선물계좌현황ToolStripMenuItem.Text = "선물계좌현황";
            this.선물계좌현황ToolStripMenuItem.Click += new System.EventHandler(this.선물계좌현황ToolStripMenuItem_Click);
            // 
            // 주식계좌현황ToolStripMenuItem
            // 
            this.주식계좌현황ToolStripMenuItem.Name = "주식계좌현황ToolStripMenuItem";
            this.주식계좌현황ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.주식계좌현황ToolStripMenuItem.Text = "주식계좌현황";
            this.주식계좌현황ToolStripMenuItem.Click += new System.EventHandler(this.주식계좌현황ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 116);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // 선옵주문ToolStripMenuItem
            // 
            this.선옵주문ToolStripMenuItem.Name = "선옵주문ToolStripMenuItem";
            this.선옵주문ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.선옵주문ToolStripMenuItem.Text = "선옵주문";
            this.선옵주문ToolStripMenuItem.Click += new System.EventHandler(this.선옵주문ToolStripMenuItem_Click);
            // 
            // 주식주문ToolStripMenuItem
            // 
            this.주식주문ToolStripMenuItem.Name = "주식주문ToolStripMenuItem";
            this.주식주문ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.주식주문ToolStripMenuItem.Text = "주식주문";
            this.주식주문ToolStripMenuItem.Click += new System.EventHandler(this.주식주문ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 138);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 선물계좌현황ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주식계좌현황ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 선옵주문ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주식주문ToolStripMenuItem;
    }
}

