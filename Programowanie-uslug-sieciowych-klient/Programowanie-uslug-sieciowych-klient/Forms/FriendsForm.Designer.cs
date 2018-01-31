namespace Programowanie_uslug_sieciowych_klient.Forms
{
    partial class FriendsForm
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
            this.friendsGrid = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FriendLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnreadedMessages = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Aktywny = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddFriend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.friendsGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // friendsGrid
            // 
            this.friendsGrid.AllowUserToAddRows = false;
            this.friendsGrid.AllowUserToDeleteRows = false;
            this.friendsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.friendsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.FriendLogin,
            this.UnreadedMessages,
            this.Aktywny});
            this.friendsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsGrid.Location = new System.Drawing.Point(3, 3);
            this.friendsGrid.MultiSelect = false;
            this.friendsGrid.Name = "friendsGrid";
            this.friendsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.friendsGrid.Size = new System.Drawing.Size(674, 362);
            this.friendsGrid.TabIndex = 0;
            this.friendsGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.friendsGrid_DataBindingComplete);
            // 
            // UserId
            // 
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = false;
            // 
            // FriendLogin
            // 
            this.FriendLogin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FriendLogin.HeaderText = "Login";
            this.FriendLogin.Name = "FriendLogin";
            // 
            // UnreadedMessages
            // 
            this.UnreadedMessages.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnreadedMessages.HeaderText = "Nieprzeczytane wiadomości";
            this.UnreadedMessages.Name = "UnreadedMessages";
            // 
            // Aktywny
            // 
            this.Aktywny.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Aktywny.HeaderText = "Aktywny";
            this.Aktywny.Name = "Aktywny";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.friendsGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddFriend, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 433);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Location = new System.Drawing.Point(3, 371);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(157, 59);
            this.btnAddFriend.TabIndex = 1;
            this.btnAddFriend.Text = "Dodaj znajomego";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // FriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FriendsForm";
            this.Text = "FriendsForm";
            ((System.ComponentModel.ISupportInitialize)(this.friendsGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView friendsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FriendLogin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnreadedMessages;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktywny;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddFriend;
    }
}