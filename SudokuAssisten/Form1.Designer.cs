
namespace sudoku_assistent_002
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSpeichern = new System.Windows.Forms.Button();
            this.buttonLaden = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.buttonVorlageSpeichern = new System.Windows.Forms.Button();
            this.buttonVorlageLaden = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Muster setzen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 4;
            this.label1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 25);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 34);
            this.button3.TabIndex = 7;
            this.button3.Text = "Neues Spiel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonSpeichern
            // 
            this.buttonSpeichern.Location = new System.Drawing.Point(15, 68);
            this.buttonSpeichern.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSpeichern.Name = "buttonSpeichern";
            this.buttonSpeichern.Size = new System.Drawing.Size(173, 34);
            this.buttonSpeichern.TabIndex = 8;
            this.buttonSpeichern.Text = "Spiel Speichern";
            this.buttonSpeichern.UseVisualStyleBackColor = true;
            this.buttonSpeichern.Click += new System.EventHandler(this.buttonSpeichern_Click_1);
            // 
            // buttonLaden
            // 
            this.buttonLaden.Location = new System.Drawing.Point(15, 106);
            this.buttonLaden.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLaden.Name = "buttonLaden";
            this.buttonLaden.Size = new System.Drawing.Size(173, 34);
            this.buttonLaden.TabIndex = 9;
            this.buttonLaden.Text = "Spiel Laden";
            this.buttonLaden.UseVisualStyleBackColor = true;
            this.buttonLaden.Click += new System.EventHandler(this.buttonLaden_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.buttonSpeichern);
            this.groupBox1.Controls.Add(this.buttonLaden);
            this.groupBox1.Location = new System.Drawing.Point(0, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 153);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spielstand laden/speichern";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(748, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 525);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.buttonVorlageSpeichern);
            this.groupBox6.Controls.Add(this.buttonVorlageLaden);
            this.groupBox6.Location = new System.Drawing.Point(748, 275);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 120);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Vorlage laden/speichern";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.button7);
            this.groupBox7.Controls.Add(this.button8);
            this.groupBox7.Location = new System.Drawing.Point(0, 126);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 120);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Spielstand laden/speichern";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(15, 35);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(173, 34);
            this.button7.TabIndex = 8;
            this.button7.Text = "Spiel Speichern";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(15, 73);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(173, 34);
            this.button8.TabIndex = 9;
            this.button8.Text = "Spiel Laden";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // buttonVorlageSpeichern
            // 
            this.buttonVorlageSpeichern.Location = new System.Drawing.Point(15, 35);
            this.buttonVorlageSpeichern.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVorlageSpeichern.Name = "buttonVorlageSpeichern";
            this.buttonVorlageSpeichern.Size = new System.Drawing.Size(173, 34);
            this.buttonVorlageSpeichern.TabIndex = 8;
            this.buttonVorlageSpeichern.Text = "Vorlage Speichern";
            this.buttonVorlageSpeichern.UseVisualStyleBackColor = true;
            this.buttonVorlageSpeichern.Click += new System.EventHandler(this.buttonVorlageSpeichern_Click);
            // 
            // buttonVorlageLaden
            // 
            this.buttonVorlageLaden.Location = new System.Drawing.Point(15, 73);
            this.buttonVorlageLaden.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVorlageLaden.Name = "buttonVorlageLaden";
            this.buttonVorlageLaden.Size = new System.Drawing.Size(173, 34);
            this.buttonVorlageLaden.TabIndex = 9;
            this.buttonVorlageLaden.Text = "Vorlage Laden";
            this.buttonVorlageLaden.UseVisualStyleBackColor = true;
            this.buttonVorlageLaden.Click += new System.EventHandler(this.buttonVorlageLaden_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Location = new System.Drawing.Point(0, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Neues Spiel";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(0, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 80);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Muster setzen";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 34);
            this.button2.TabIndex = 10;
            this.button2.Text = "Schnell Speichern";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 509);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSpeichern;
        private System.Windows.Forms.Button buttonLaden;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button buttonVorlageSpeichern;
        private System.Windows.Forms.Button buttonVorlageLaden;
        private System.Windows.Forms.Button button2;
    }
}

