namespace TaskManagetV2
{
    partial class Form1
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnEditAtricle = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.button1);
            this.pnlMain.Controls.Add(this.btnAddUser);
            this.pnlMain.Controls.Add(this.btnEditAtricle);
            this.pnlMain.Controls.Add(this.btnEditUser);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(886, 505);
            this.pnlMain.TabIndex = 0;
            // 
            // btnEditAtricle
            // 
            this.btnEditAtricle.Location = new System.Drawing.Point(3, 32);
            this.btnEditAtricle.Name = "btnEditAtricle";
            this.btnEditAtricle.Size = new System.Drawing.Size(880, 23);
            this.btnEditAtricle.TabIndex = 1;
            this.btnEditAtricle.Text = "Создание/Редактирование Заметок";
            this.btnEditAtricle.UseVisualStyleBackColor = true;
            this.btnEditAtricle.Click += new System.EventHandler(this.btnEditAtricle_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(3, 3);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(880, 23);
            this.btnEditUser.TabIndex = 0;
            this.btnEditUser.Text = "Редактирование пользователя";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(3, 61);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(880, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Создание пользователя";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnEditAtricle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 529);
            this.Controls.Add(this.pnlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnEditAtricle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddUser;
    }
}

