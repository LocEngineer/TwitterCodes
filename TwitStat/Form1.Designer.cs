namespace MyLocalTwitterStats
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.bwQueryTwit = new System.ComponentModel.BackgroundWorker();
			this.grpFollow = new System.Windows.Forms.GroupBox();
			this.grpFriends = new System.Windows.Forms.GroupBox();
			this.grpLost = new System.Windows.Forms.GroupBox();
			this.grpDitched = new System.Windows.Forms.GroupBox();
			this.lblWait = new System.Windows.Forms.Label();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.lblFollowers = new System.Windows.Forms.Label();
			this.lblFriends = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bwQueryTwit
			// 
			this.bwQueryTwit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwQueryTwit_DoWork);
			this.bwQueryTwit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwQueryTwit_RunWorkerCompleted);
			// 
			// grpFollow
			// 
			this.grpFollow.Location = new System.Drawing.Point(12, 24);
			this.grpFollow.Name = "grpFollow";
			this.grpFollow.Size = new System.Drawing.Size(321, 307);
			this.grpFollow.TabIndex = 0;
			this.grpFollow.TabStop = false;
			this.grpFollow.Text = "Neue Follower";
			// 
			// grpFriends
			// 
			this.grpFriends.Location = new System.Drawing.Point(12, 351);
			this.grpFriends.Name = "grpFriends";
			this.grpFriends.Size = new System.Drawing.Size(321, 307);
			this.grpFriends.TabIndex = 0;
			this.grpFriends.TabStop = false;
			this.grpFriends.Text = "Neue Friends";
			// 
			// grpLost
			// 
			this.grpLost.Location = new System.Drawing.Point(476, 24);
			this.grpLost.Name = "grpLost";
			this.grpLost.Size = new System.Drawing.Size(321, 307);
			this.grpLost.TabIndex = 0;
			this.grpLost.TabStop = false;
			this.grpLost.Text = "Follower verloren";
			// 
			// grpDitched
			// 
			this.grpDitched.Location = new System.Drawing.Point(477, 351);
			this.grpDitched.Name = "grpDitched";
			this.grpDitched.Size = new System.Drawing.Size(321, 307);
			this.grpDitched.TabIndex = 0;
			this.grpDitched.TabStop = false;
			this.grpDitched.Text = "Bin ich entfolgt";
			// 
			// lblWait
			// 
			this.lblWait.BackColor = System.Drawing.SystemColors.Info;
			this.lblWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWait.Location = new System.Drawing.Point(283, 288);
			this.lblWait.Name = "lblWait";
			this.lblWait.Size = new System.Drawing.Size(229, 106);
			this.lblWait.TabIndex = 1;
			this.lblWait.Text = "Bitte warten...";
			this.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(339, 321);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(131, 41);
			this.btnUpdate.TabIndex = 2;
			this.btnUpdate.Text = "Abgleichen";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// lblFollowers
			// 
			this.lblFollowers.AutoSize = true;
			this.lblFollowers.Location = new System.Drawing.Point(375, 68);
			this.lblFollowers.Name = "lblFollowers";
			this.lblFollowers.Size = new System.Drawing.Size(35, 13);
			this.lblFollowers.TabIndex = 3;
			this.lblFollowers.Text = "label1";
			// 
			// lblFriends
			// 
			this.lblFriends.AutoSize = true;
			this.lblFriends.Location = new System.Drawing.Point(375, 462);
			this.lblFriends.Name = "lblFriends";
			this.lblFriends.Size = new System.Drawing.Size(35, 13);
			this.lblFriends.TabIndex = 3;
			this.lblFriends.Text = "label1";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(352, 245);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(101, 29);
			this.btnRefresh.TabIndex = 4;
			this.btnRefresh.Text = "Aktualisieren";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(810, 688);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.lblWait);
			this.Controls.Add(this.lblFriends);
			this.Controls.Add(this.lblFollowers);
			this.Controls.Add(this.grpLost);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.grpDitched);
			this.Controls.Add(this.grpFollow);
			this.Controls.Add(this.grpFriends);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker bwQueryTwit;
		private System.Windows.Forms.GroupBox grpFollow;
		private System.Windows.Forms.GroupBox grpFriends;
		private System.Windows.Forms.GroupBox grpLost;
		private System.Windows.Forms.GroupBox grpDitched;
		private System.Windows.Forms.Label lblWait;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Label lblFollowers;
		private System.Windows.Forms.Label lblFriends;
		private System.Windows.Forms.Button btnRefresh;
	}
}

