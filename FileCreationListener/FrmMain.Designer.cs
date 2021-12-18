
namespace FileCreationListener
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.LinkLabel();
            this.lblDestination = new System.Windows.Forms.LinkLabel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.chkDeleteSource = new System.Windows.Forms.CheckBox();
            this.txtExcludeKeyWords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Directory:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Directory:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(257, 33);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(69, 20);
            this.lblSource.TabIndex = 2;
            this.lblSource.TabStop = true;
            this.lblSource.Text = "Source";
            this.lblSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSource_LinkClicked);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(257, 70);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(119, 20);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.TabStop = true;
            this.lblDestination.Text = "Destination";
            this.lblDestination.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDestination_LinkClicked);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(16, 197);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1021, 38);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Listening...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Image = global::FileCreationListener.Properties.Resources.icon32;
            this.btnStop.Location = new System.Drawing.Point(988, 11);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 57);
            this.btnStop.TabIndex = 6;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Image = global::FileCreationListener.Properties.Resources.Arrow_Forward;
            this.btnStart.Location = new System.Drawing.Point(919, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(63, 57);
            this.btnStart.TabIndex = 5;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Filter:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(260, 108);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(119, 27);
            this.txtFilter.TabIndex = 8;
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lbLog.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 20;
            this.lbLog.Location = new System.Drawing.Point(12, 242);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(1039, 704);
            this.lbLog.TabIndex = 9;
            // 
            // chkDeleteSource
            // 
            this.chkDeleteSource.AutoSize = true;
            this.chkDeleteSource.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteSource.Location = new System.Drawing.Point(418, 111);
            this.chkDeleteSource.Name = "chkDeleteSource";
            this.chkDeleteSource.Size = new System.Drawing.Size(211, 24);
            this.chkDeleteSource.TabIndex = 10;
            this.chkDeleteSource.Text = "Delete Source File";
            this.chkDeleteSource.UseVisualStyleBackColor = true;
            // 
            // txtExcludeKeyWords
            // 
            this.txtExcludeKeyWords.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExcludeKeyWords.Location = new System.Drawing.Point(260, 155);
            this.txtExcludeKeyWords.Name = "txtExcludeKeyWords";
            this.txtExcludeKeyWords.Size = new System.Drawing.Size(369, 27);
            this.txtExcludeKeyWords.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtExcludeKeyWords, "Multiple keywords can be added for exlusion.  Use a comma to separate multiple ke" +
        "y words.\r\n");
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Exclusion Key Words:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 961);
            this.Controls.Add(this.txtExcludeKeyWords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkDeleteSource);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Directory Listener";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblSource;
        private System.Windows.Forms.LinkLabel lblDestination;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.CheckBox chkDeleteSource;
        private System.Windows.Forms.TextBox txtExcludeKeyWords;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
    }
}

