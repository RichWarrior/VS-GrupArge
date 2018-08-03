namespace PerformanceMonitorApp_V2.View
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCards5 = new Bunifu.Framework.UI.BunifuCards();
            this.cpu_label = new System.Windows.Forms.Label();
            this.cpu_progress = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCards4 = new Bunifu.Framework.UI.BunifuCards();
            this.ram_label = new System.Windows.Forms.Label();
            this.ram_progress = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCards3 = new Bunifu.Framework.UI.BunifuCards();
            this.total_cpu_label = new System.Windows.Forms.Label();
            this.total_cpu_progress = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.total_ram_label = new System.Windows.Forms.Label();
            this.total_ram_progress = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.bunifuCards5.SuspendLayout();
            this.bunifuCards4.SuspendLayout();
            this.bunifuCards3.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(712, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 607);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(214, 600);
            this.treeView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.bunifuCards5);
            this.panel2.Controls.Add(this.bunifuCards4);
            this.panel2.Controls.Add(this.bunifuCards3);
            this.panel2.Controls.Add(this.bunifuCards1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 607);
            this.panel2.TabIndex = 1;
            // 
            // bunifuCards5
            // 
            this.bunifuCards5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards5.BackColor = System.Drawing.Color.White;
            this.bunifuCards5.BorderRadius = 5;
            this.bunifuCards5.BottomSahddow = true;
            this.bunifuCards5.color = System.Drawing.Color.Tomato;
            this.bunifuCards5.Controls.Add(this.cpu_label);
            this.bunifuCards5.Controls.Add(this.cpu_progress);
            this.bunifuCards5.LeftSahddow = false;
            this.bunifuCards5.Location = new System.Drawing.Point(3, 666);
            this.bunifuCards5.Name = "bunifuCards5";
            this.bunifuCards5.RightSahddow = true;
            this.bunifuCards5.ShadowDepth = 20;
            this.bunifuCards5.Size = new System.Drawing.Size(641, 212);
            this.bunifuCards5.TabIndex = 4;
            // 
            // cpu_label
            // 
            this.cpu_label.AutoSize = true;
            this.cpu_label.Location = new System.Drawing.Point(14, 18);
            this.cpu_label.Name = "cpu_label";
            this.cpu_label.Size = new System.Drawing.Size(180, 17);
            this.cpu_label.TabIndex = 2;
            this.cpu_label.Text = "Seçili İşlemin CPU Kullanımı";
            // 
            // cpu_progress
            // 
            this.cpu_progress.animated = false;
            this.cpu_progress.animationIterval = 5;
            this.cpu_progress.animationSpeed = 300;
            this.cpu_progress.BackColor = System.Drawing.Color.White;
            this.cpu_progress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cpu_progress.BackgroundImage")));
            this.cpu_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.cpu_progress.ForeColor = System.Drawing.Color.SeaGreen;
            this.cpu_progress.LabelVisible = true;
            this.cpu_progress.LineProgressThickness = 8;
            this.cpu_progress.LineThickness = 5;
            this.cpu_progress.Location = new System.Drawing.Point(33, 44);
            this.cpu_progress.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.cpu_progress.MaxValue = 100;
            this.cpu_progress.Name = "cpu_progress";
            this.cpu_progress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.cpu_progress.ProgressColor = System.Drawing.Color.SeaGreen;
            this.cpu_progress.Size = new System.Drawing.Size(145, 145);
            this.cpu_progress.TabIndex = 1;
            this.cpu_progress.Value = 0;
            // 
            // bunifuCards4
            // 
            this.bunifuCards4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards4.BackColor = System.Drawing.Color.White;
            this.bunifuCards4.BorderRadius = 5;
            this.bunifuCards4.BottomSahddow = true;
            this.bunifuCards4.color = System.Drawing.Color.Tomato;
            this.bunifuCards4.Controls.Add(this.ram_label);
            this.bunifuCards4.Controls.Add(this.ram_progress);
            this.bunifuCards4.LeftSahddow = false;
            this.bunifuCards4.Location = new System.Drawing.Point(3, 448);
            this.bunifuCards4.Name = "bunifuCards4";
            this.bunifuCards4.RightSahddow = true;
            this.bunifuCards4.ShadowDepth = 20;
            this.bunifuCards4.Size = new System.Drawing.Size(641, 212);
            this.bunifuCards4.TabIndex = 3;
            // 
            // ram_label
            // 
            this.ram_label.AutoSize = true;
            this.ram_label.Location = new System.Drawing.Point(14, 18);
            this.ram_label.Name = "ram_label";
            this.ram_label.Size = new System.Drawing.Size(190, 17);
            this.ram_label.TabIndex = 2;
            this.ram_label.Text = "Seçili İşlemin Bellek Kullanımı";
            // 
            // ram_progress
            // 
            this.ram_progress.animated = false;
            this.ram_progress.animationIterval = 5;
            this.ram_progress.animationSpeed = 300;
            this.ram_progress.BackColor = System.Drawing.Color.White;
            this.ram_progress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ram_progress.BackgroundImage")));
            this.ram_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.ram_progress.ForeColor = System.Drawing.Color.SeaGreen;
            this.ram_progress.LabelVisible = true;
            this.ram_progress.LineProgressThickness = 8;
            this.ram_progress.LineThickness = 5;
            this.ram_progress.Location = new System.Drawing.Point(33, 44);
            this.ram_progress.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.ram_progress.MaxValue = 100;
            this.ram_progress.Name = "ram_progress";
            this.ram_progress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.ram_progress.ProgressColor = System.Drawing.Color.SeaGreen;
            this.ram_progress.Size = new System.Drawing.Size(145, 145);
            this.ram_progress.TabIndex = 1;
            this.ram_progress.Value = 0;
            // 
            // bunifuCards3
            // 
            this.bunifuCards3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards3.BackColor = System.Drawing.Color.White;
            this.bunifuCards3.BorderRadius = 5;
            this.bunifuCards3.BottomSahddow = true;
            this.bunifuCards3.color = System.Drawing.Color.Tomato;
            this.bunifuCards3.Controls.Add(this.total_cpu_label);
            this.bunifuCards3.Controls.Add(this.total_cpu_progress);
            this.bunifuCards3.LeftSahddow = false;
            this.bunifuCards3.Location = new System.Drawing.Point(3, 230);
            this.bunifuCards3.Name = "bunifuCards3";
            this.bunifuCards3.RightSahddow = true;
            this.bunifuCards3.ShadowDepth = 20;
            this.bunifuCards3.Size = new System.Drawing.Size(641, 212);
            this.bunifuCards3.TabIndex = 2;
            // 
            // total_cpu_label
            // 
            this.total_cpu_label.AutoSize = true;
            this.total_cpu_label.Location = new System.Drawing.Point(14, 18);
            this.total_cpu_label.Name = "total_cpu_label";
            this.total_cpu_label.Size = new System.Drawing.Size(138, 17);
            this.total_cpu_label.TabIndex = 2;
            this.total_cpu_label.Text = "Genel CPU Kullanımı";
            // 
            // total_cpu_progress
            // 
            this.total_cpu_progress.animated = false;
            this.total_cpu_progress.animationIterval = 5;
            this.total_cpu_progress.animationSpeed = 300;
            this.total_cpu_progress.BackColor = System.Drawing.Color.White;
            this.total_cpu_progress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("total_cpu_progress.BackgroundImage")));
            this.total_cpu_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.total_cpu_progress.ForeColor = System.Drawing.Color.SeaGreen;
            this.total_cpu_progress.LabelVisible = true;
            this.total_cpu_progress.LineProgressThickness = 8;
            this.total_cpu_progress.LineThickness = 5;
            this.total_cpu_progress.Location = new System.Drawing.Point(17, 44);
            this.total_cpu_progress.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.total_cpu_progress.MaxValue = 100;
            this.total_cpu_progress.Name = "total_cpu_progress";
            this.total_cpu_progress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.total_cpu_progress.ProgressColor = System.Drawing.Color.SeaGreen;
            this.total_cpu_progress.Size = new System.Drawing.Size(145, 145);
            this.total_cpu_progress.TabIndex = 1;
            this.total_cpu_progress.Value = 0;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.total_ram_label);
            this.bunifuCards1.Controls.Add(this.total_ram_progress);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(3, 12);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(641, 212);
            this.bunifuCards1.TabIndex = 0;
            // 
            // total_ram_label
            // 
            this.total_ram_label.AutoSize = true;
            this.total_ram_label.Location = new System.Drawing.Point(12, 12);
            this.total_ram_label.Name = "total_ram_label";
            this.total_ram_label.Size = new System.Drawing.Size(148, 17);
            this.total_ram_label.TabIndex = 2;
            this.total_ram_label.Text = "Genel Bellek Kullanımı";
            // 
            // total_ram_progress
            // 
            this.total_ram_progress.animated = false;
            this.total_ram_progress.animationIterval = 5;
            this.total_ram_progress.animationSpeed = 300;
            this.total_ram_progress.BackColor = System.Drawing.Color.White;
            this.total_ram_progress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("total_ram_progress.BackgroundImage")));
            this.total_ram_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.total_ram_progress.ForeColor = System.Drawing.Color.SeaGreen;
            this.total_ram_progress.LabelVisible = true;
            this.total_ram_progress.LineProgressThickness = 8;
            this.total_ram_progress.LineThickness = 5;
            this.total_ram_progress.Location = new System.Drawing.Point(15, 38);
            this.total_ram_progress.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.total_ram_progress.MaxValue = 100;
            this.total_ram_progress.Name = "total_ram_progress";
            this.total_ram_progress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.total_ram_progress.ProgressColor = System.Drawing.Color.SeaGreen;
            this.total_ram_progress.Size = new System.Drawing.Size(164, 164);
            this.total_ram_progress.TabIndex = 1;
            this.total_ram_progress.Value = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance Monitor V2";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.bunifuCards5.ResumeLayout(false);
            this.bunifuCards5.PerformLayout();
            this.bunifuCards4.ResumeLayout(false);
            this.bunifuCards4.PerformLayout();
            this.bunifuCards3.ResumeLayout(false);
            this.bunifuCards3.PerformLayout();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label total_ram_label;
        private Bunifu.Framework.UI.BunifuCircleProgressbar total_ram_progress;
        private Bunifu.Framework.UI.BunifuCards bunifuCards3;
        private System.Windows.Forms.Label total_cpu_label;
        private Bunifu.Framework.UI.BunifuCircleProgressbar total_cpu_progress;
        private Bunifu.Framework.UI.BunifuCards bunifuCards5;
        private System.Windows.Forms.Label cpu_label;
        private Bunifu.Framework.UI.BunifuCircleProgressbar cpu_progress;
        private Bunifu.Framework.UI.BunifuCards bunifuCards4;
        private System.Windows.Forms.Label ram_label;
        private Bunifu.Framework.UI.BunifuCircleProgressbar ram_progress;
    }
}