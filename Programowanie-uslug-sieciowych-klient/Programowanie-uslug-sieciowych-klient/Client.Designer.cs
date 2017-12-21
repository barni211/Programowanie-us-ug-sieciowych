namespace Programowanie_uslug_sieciowych_klient
{
    partial class Client
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.msgTextBox = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 490);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.msgTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 490);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(758, 102);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.20844F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.79156F));
            this.tableLayoutPanel2.Controls.Add(this.btnSendMessage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.consoleBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 328);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(758, 102);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendMessage.Location = new System.Drawing.Point(3, 3);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(366, 96);
            this.btnSendMessage.TabIndex = 0;
            this.btnSendMessage.Text = "Wyślij wiadomość";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.Location = new System.Drawing.Point(375, 3);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(380, 96);
            this.consoleBox.TabIndex = 1;
            this.consoleBox.Text = "";
            // 
            // msgTextBox
            // 
            this.msgTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgTextBox.Location = new System.Drawing.Point(3, 3);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(758, 211);
            this.msgTextBox.TabIndex = 2;
            this.msgTextBox.Text = "";
            this.msgTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.msgTextBox_KeyPress);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSendFile);
            this.flowLayoutPanel1.Controls.Add(this.btnDownloadFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 436);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 51);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(3, 3);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(119, 51);
            this.btnSendFile.TabIndex = 4;
            this.btnSendFile.Text = "Prześlij plik";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(128, 3);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(112, 48);
            this.btnDownloadFile.TabIndex = 5;
            this.btnDownloadFile.Text = "Pobierz plik";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 490);
            this.Controls.Add(this.panel1);
            this.Name = "Client";
            this.Text = "Client";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.RichTextBox msgTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnDownloadFile;
    }
}

