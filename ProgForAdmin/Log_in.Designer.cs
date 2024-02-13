namespace ProgForAdmin
{
    partial class Log_in
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log_in));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login_TextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.log_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.login_TextBox);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.Password_TextBox);
            this.panel1.Controls.Add(this.log_button);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 376);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(130, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // login_TextBox
            // 
            this.login_TextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_TextBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.login_TextBox.Location = new System.Drawing.Point(44, 191);
            this.login_TextBox.Margin = new System.Windows.Forms.Padding(20);
            this.login_TextBox.Multiline = true;
            this.login_TextBox.Name = "login_TextBox";
            this.login_TextBox.Size = new System.Drawing.Size(300, 30);
            this.login_TextBox.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkBox1.Location = new System.Drawing.Point(214, 284);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Показать пароль";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password_TextBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Password_TextBox.Location = new System.Drawing.Point(44, 251);
            this.Password_TextBox.Margin = new System.Windows.Forms.Padding(20);
            this.Password_TextBox.Multiline = true;
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(300, 30);
            this.Password_TextBox.TabIndex = 1;
            // 
            // log_button
            // 
            this.log_button.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.log_button.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.log_button.Location = new System.Drawing.Point(44, 311);
            this.log_button.Name = "log_button";
            this.log_button.Size = new System.Drawing.Size(300, 30);
            this.log_button.TabIndex = 2;
            this.log_button.Text = "Войти";
            this.log_button.UseVisualStyleBackColor = true;
            this.log_button.Click += new System.EventHandler(this.log_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(44, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите ваш пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(44, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите ваш логин";
            // 
            // Log_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 418);
            this.Controls.Add(this.panel1);
            this.Name = "Log_in";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox login_TextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.Button log_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

