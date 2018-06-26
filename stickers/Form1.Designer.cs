namespace stickers
{
    partial class FormSelect
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelect));
            this.buttonAddServer = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.maskedTextBoxID = new System.Windows.Forms.MaskedTextBox();
            this.labelInputID = new System.Windows.Forms.Label();
            this.listBoxSelect = new System.Windows.Forms.ListBox();
            this.labelSelect = new System.Windows.Forms.Label();
            this.errorIncorrect = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorIncorrect)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddServer
            // 
            this.buttonAddServer.Location = new System.Drawing.Point(12, 51);
            this.buttonAddServer.Name = "buttonAddServer";
            this.buttonAddServer.Size = new System.Drawing.Size(83, 33);
            this.buttonAddServer.TabIndex = 1;
            this.buttonAddServer.Text = "Add Server";
            this.buttonAddServer.UseVisualStyleBackColor = true;
            this.buttonAddServer.Click += new System.EventHandler(this.ButtonAddServer_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(189, 51);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(83, 33);
            this.buttonAddUser.TabIndex = 2;
            this.buttonAddUser.Text = "Add User";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.ButtonAddUser_Click);
            // 
            // maskedTextBoxID
            // 
            this.maskedTextBoxID.Location = new System.Drawing.Point(12, 25);
            this.maskedTextBoxID.Mask = "000000000000000000";
            this.maskedTextBoxID.Name = "maskedTextBoxID";
            this.maskedTextBoxID.PromptChar = '-';
            this.maskedTextBoxID.Size = new System.Drawing.Size(260, 20);
            this.maskedTextBoxID.TabIndex = 0;
            // 
            // labelInputID
            // 
            this.labelInputID.AutoSize = true;
            this.labelInputID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelInputID.Location = new System.Drawing.Point(12, 9);
            this.labelInputID.Name = "labelInputID";
            this.labelInputID.Size = new System.Drawing.Size(106, 13);
            this.labelInputID.TabIndex = 5;
            this.labelInputID.Text = "Server/User ID here:";
            // 
            // listBoxSelect
            // 
            this.listBoxSelect.FormattingEnabled = true;
            this.listBoxSelect.Location = new System.Drawing.Point(12, 103);
            this.listBoxSelect.Name = "listBoxSelect";
            this.listBoxSelect.Size = new System.Drawing.Size(260, 69);
            this.listBoxSelect.Sorted = true;
            this.listBoxSelect.TabIndex = 6;
            this.listBoxSelect.DoubleClick += new System.EventHandler(this.listBoxSelect_SelectedIndexChanged);
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSelect.Location = new System.Drawing.Point(12, 87);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(125, 13);
            this.labelSelect.TabIndex = 7;
            this.labelSelect.Text = "Choose the Server/User:";
            // 
            // errorIncorrect
            // 
            this.errorIncorrect.ContainerControl = this;
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(101, 51);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(82, 33);
            this.buttonReload.TabIndex = 8;
            this.buttonReload.Text = "Reload Cfgs";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(217, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "LOADING";
            this.label1.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Server/User selection";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // FormSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(284, 184);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.labelSelect);
            this.Controls.Add(this.listBoxSelect);
            this.Controls.Add(this.labelInputID);
            this.Controls.Add(this.maskedTextBoxID);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonAddServer);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSelect";
            this.Text = "Stickers for Discord app";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.errorIncorrect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddServer;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxID;
        private System.Windows.Forms.Label labelInputID;
        private System.Windows.Forms.ListBox listBoxSelect;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.ErrorProvider errorIncorrect;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

