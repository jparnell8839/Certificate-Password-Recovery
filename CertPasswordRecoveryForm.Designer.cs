namespace CertificatePasswordRecovery
{
    partial class CertPasswordRecoveryForm
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
            this.maxGenLbl = new System.Windows.Forms.Label();
            this.maxGenBx = new System.Windows.Forms.NumericUpDown();
            this.prefixLbl = new System.Windows.Forms.Label();
            this.suffixLbl = new System.Windows.Forms.Label();
            this.helpAboutLinkLbl = new System.Windows.Forms.LinkLabel();
            this.prefixBx = new System.Windows.Forms.TextBox();
            this.suffixBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.symbolSequenceBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startStringLbl = new System.Windows.Forms.Label();
            this.startStringBx = new System.Windows.Forms.TextBox();
            this.recoverPasswordBtn = new System.Windows.Forms.Button();
            this.logPathLbl = new System.Windows.Forms.Label();
            this.logPathBx = new System.Windows.Forms.TextBox();
            this.logLevelLbl = new System.Windows.Forms.Label();
            this.logLevelBx = new System.Windows.Forms.ComboBox();
            this.pathToCertLbl = new System.Windows.Forms.Label();
            this.pathToCertBx = new System.Windows.Forms.TextBox();
            this.certBrowseBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.maxGenBx)).BeginInit();
            this.SuspendLayout();
            // 
            // maxGenLbl
            // 
            this.maxGenLbl.AutoSize = true;
            this.maxGenLbl.Location = new System.Drawing.Point(12, 13);
            this.maxGenLbl.Name = "maxGenLbl";
            this.maxGenLbl.Size = new System.Drawing.Size(137, 13);
            this.maxGenLbl.TabIndex = 0;
            this.maxGenLbl.Text = "Max Generated Characters:";
            // 
            // maxGenBx
            // 
            this.maxGenBx.Location = new System.Drawing.Point(305, 11);
            this.maxGenBx.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.maxGenBx.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxGenBx.Name = "maxGenBx";
            this.maxGenBx.Size = new System.Drawing.Size(70, 20);
            this.maxGenBx.TabIndex = 1;
            this.maxGenBx.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.maxGenBx.ValueChanged += new System.EventHandler(this.maxGenBx_ValueChanged);
            // 
            // prefixLbl
            // 
            this.prefixLbl.AutoSize = true;
            this.prefixLbl.Location = new System.Drawing.Point(12, 62);
            this.prefixLbl.Name = "prefixLbl";
            this.prefixLbl.Size = new System.Drawing.Size(66, 13);
            this.prefixLbl.TabIndex = 2;
            this.prefixLbl.Text = "Prefix String:";
            // 
            // suffixLbl
            // 
            this.suffixLbl.AutoSize = true;
            this.suffixLbl.Location = new System.Drawing.Point(12, 88);
            this.suffixLbl.Name = "suffixLbl";
            this.suffixLbl.Size = new System.Drawing.Size(66, 13);
            this.suffixLbl.TabIndex = 3;
            this.suffixLbl.Text = "Suffix String:";
            // 
            // helpAboutLinkLbl
            // 
            this.helpAboutLinkLbl.AutoSize = true;
            this.helpAboutLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.helpAboutLinkLbl.Location = new System.Drawing.Point(12, 303);
            this.helpAboutLinkLbl.Name = "helpAboutLinkLbl";
            this.helpAboutLinkLbl.Size = new System.Drawing.Size(85, 17);
            this.helpAboutLinkLbl.TabIndex = 4;
            this.helpAboutLinkLbl.TabStop = true;
            this.helpAboutLinkLbl.Text = "Help / about";
            this.helpAboutLinkLbl.Click += new System.EventHandler(this.helpAboutLinkLbl_Click);
            // 
            // prefixBx
            // 
            this.prefixBx.Location = new System.Drawing.Point(243, 59);
            this.prefixBx.Name = "prefixBx";
            this.prefixBx.Size = new System.Drawing.Size(132, 20);
            this.prefixBx.TabIndex = 2;
            // 
            // suffixBx
            // 
            this.suffixBx.Location = new System.Drawing.Point(243, 85);
            this.suffixBx.Name = "suffixBx";
            this.suffixBx.Size = new System.Drawing.Size(132, 20);
            this.suffixBx.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Symbol Sequence (Comma-separated):";
            // 
            // symbolSequenceBx
            // 
            this.symbolSequenceBx.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbolSequenceBx.Location = new System.Drawing.Point(15, 129);
            this.symbolSequenceBx.Multiline = true;
            this.symbolSequenceBx.Name = "symbolSequenceBx";
            this.symbolSequenceBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.symbolSequenceBx.Size = new System.Drawing.Size(360, 68);
            this.symbolSequenceBx.TabIndex = 4;
            this.symbolSequenceBx.Text = " ,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N" +
    ",O,P,Q,R,S,T,U,V,W,X,Y,Z,0,1,2,3,4,5,6,7,8,9,!,@,#,$,%,^,&,*,(,),_,-,+,=,~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 10;
            // 
            // startStringLbl
            // 
            this.startStringLbl.AutoSize = true;
            this.startStringLbl.Location = new System.Drawing.Point(12, 36);
            this.startStringLbl.Name = "startStringLbl";
            this.startStringLbl.Size = new System.Drawing.Size(76, 13);
            this.startStringLbl.TabIndex = 11;
            this.startStringLbl.Text = "Starting String:";
            // 
            // startStringBx
            // 
            this.startStringBx.Location = new System.Drawing.Point(243, 36);
            this.startStringBx.Name = "startStringBx";
            this.startStringBx.Size = new System.Drawing.Size(132, 20);
            this.startStringBx.TabIndex = 12;
            // 
            // recoverPasswordBtn
            // 
            this.recoverPasswordBtn.Location = new System.Drawing.Point(259, 300);
            this.recoverPasswordBtn.Name = "recoverPasswordBtn";
            this.recoverPasswordBtn.Size = new System.Drawing.Size(116, 23);
            this.recoverPasswordBtn.TabIndex = 13;
            this.recoverPasswordBtn.Text = "Recover Password";
            this.recoverPasswordBtn.UseVisualStyleBackColor = true;
            this.recoverPasswordBtn.Click += new System.EventHandler(this.recoverPasswordBtn_Click);
            // 
            // logPathLbl
            // 
            this.logPathLbl.AutoSize = true;
            this.logPathLbl.Location = new System.Drawing.Point(12, 238);
            this.logPathLbl.Name = "logPathLbl";
            this.logPathLbl.Size = new System.Drawing.Size(84, 13);
            this.logPathLbl.TabIndex = 14;
            this.logPathLbl.Text = "Path to Log File:";
            // 
            // logPathBx
            // 
            this.logPathBx.Location = new System.Drawing.Point(102, 235);
            this.logPathBx.Name = "logPathBx";
            this.logPathBx.Size = new System.Drawing.Size(273, 20);
            this.logPathBx.TabIndex = 15;
            this.logPathBx.Text = "c:\\temp\\CertificatePasswordRecoveryLog.txt";
            // 
            // logLevelLbl
            // 
            this.logLevelLbl.AutoSize = true;
            this.logLevelLbl.Location = new System.Drawing.Point(12, 264);
            this.logLevelLbl.Name = "logLevelLbl";
            this.logLevelLbl.Size = new System.Drawing.Size(57, 13);
            this.logLevelLbl.TabIndex = 16;
            this.logLevelLbl.Text = "Log Level:";
            // 
            // logLevelBx
            // 
            this.logLevelBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logLevelBx.FormattingEnabled = true;
            this.logLevelBx.Items.AddRange(new object[] {
            "Off",
            "Success Only (Default)",
            "Every 10,000 + Success",
            "Everything"});
            this.logLevelBx.Location = new System.Drawing.Point(102, 261);
            this.logLevelBx.Name = "logLevelBx";
            this.logLevelBx.Size = new System.Drawing.Size(162, 21);
            this.logLevelBx.TabIndex = 18;
            this.logLevelBx.SelectedIndexChanged += new System.EventHandler(this.logLevelBx_SelectedIndexChanged);
            // 
            // pathToCertLbl
            // 
            this.pathToCertLbl.AutoSize = true;
            this.pathToCertLbl.Location = new System.Drawing.Point(12, 209);
            this.pathToCertLbl.Name = "pathToCertLbl";
            this.pathToCertLbl.Size = new System.Drawing.Size(70, 13);
            this.pathToCertLbl.TabIndex = 19;
            this.pathToCertLbl.Text = "Path To Cert:";
            // 
            // pathToCertBx
            // 
            this.pathToCertBx.Location = new System.Drawing.Point(102, 206);
            this.pathToCertBx.Name = "pathToCertBx";
            this.pathToCertBx.Size = new System.Drawing.Size(206, 20);
            this.pathToCertBx.TabIndex = 20;
            // 
            // certBrowseBtn
            // 
            this.certBrowseBtn.Location = new System.Drawing.Point(314, 204);
            this.certBrowseBtn.Name = "certBrowseBtn";
            this.certBrowseBtn.Size = new System.Drawing.Size(61, 23);
            this.certBrowseBtn.TabIndex = 21;
            this.certBrowseBtn.Text = "Browse...";
            this.certBrowseBtn.UseVisualStyleBackColor = true;
            this.certBrowseBtn.Click += new System.EventHandler(this.certBrowseBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 329);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(360, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 22;
            this.progressBar.Visible = false;
            // 
            // CertPasswordRecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 360);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.certBrowseBtn);
            this.Controls.Add(this.pathToCertBx);
            this.Controls.Add(this.pathToCertLbl);
            this.Controls.Add(this.logLevelBx);
            this.Controls.Add(this.logLevelLbl);
            this.Controls.Add(this.logPathBx);
            this.Controls.Add(this.logPathLbl);
            this.Controls.Add(this.recoverPasswordBtn);
            this.Controls.Add(this.startStringBx);
            this.Controls.Add(this.startStringLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.symbolSequenceBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.suffixBx);
            this.Controls.Add(this.prefixBx);
            this.Controls.Add(this.helpAboutLinkLbl);
            this.Controls.Add(this.suffixLbl);
            this.Controls.Add(this.prefixLbl);
            this.Controls.Add(this.maxGenBx);
            this.Controls.Add(this.maxGenLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 385);
            this.Name = "CertPasswordRecoveryForm";
            this.Text = "Certificate Password Recovery Tool";
            ((System.ComponentModel.ISupportInitialize)(this.maxGenBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label maxGenLbl;
        private System.Windows.Forms.NumericUpDown maxGenBx;
        private System.Windows.Forms.Label prefixLbl;
        private System.Windows.Forms.Label suffixLbl;
        private System.Windows.Forms.LinkLabel helpAboutLinkLbl;
        private System.Windows.Forms.TextBox prefixBx;
        private System.Windows.Forms.TextBox suffixBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolSequenceBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label startStringLbl;
        private System.Windows.Forms.TextBox startStringBx;
        private System.Windows.Forms.Button recoverPasswordBtn;
        private System.Windows.Forms.Label logPathLbl;
        private System.Windows.Forms.TextBox logPathBx;
        private System.Windows.Forms.Label logLevelLbl;
        private System.Windows.Forms.ComboBox logLevelBx;
        private System.Windows.Forms.Label pathToCertLbl;
        private System.Windows.Forms.TextBox pathToCertBx;
        private System.Windows.Forms.Button certBrowseBtn;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

