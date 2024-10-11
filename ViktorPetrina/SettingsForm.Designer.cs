namespace ViktorPetrina
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConfirm = new Button();
            gbGender = new GroupBox();
            rbtnFemale = new RadioButton();
            rbtnMale = new RadioButton();
            label1 = new Label();
            gbLanguage = new GroupBox();
            rbtnEnglish = new RadioButton();
            rbtnCroatian = new RadioButton();
            label2 = new Label();
            gbSource = new GroupBox();
            rbtnJson = new RadioButton();
            rbtnApi = new RadioButton();
            label3 = new Label();
            btnCancel = new Button();
            gbGender.SuspendLayout();
            gbLanguage.SuspendLayout();
            gbSource.SuspendLayout();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(12, 411);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(158, 50);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Potvrdi";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbtnFemale);
            gbGender.Controls.Add(rbtnMale);
            gbGender.Controls.Add(label1);
            gbGender.Location = new Point(12, 12);
            gbGender.Name = "gbGender";
            gbGender.Size = new Size(366, 117);
            gbGender.TabIndex = 11;
            gbGender.TabStop = false;
            // 
            // rbtnFemale
            // 
            rbtnFemale.AutoSize = true;
            rbtnFemale.Location = new Point(227, 67);
            rbtnFemale.Name = "rbtnFemale";
            rbtnFemale.Size = new Size(94, 29);
            rbtnFemale.TabIndex = 5;
            rbtnFemale.TabStop = true;
            rbtnFemale.Text = "Žensko";
            rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            rbtnMale.AutoSize = true;
            rbtnMale.Location = new Point(32, 67);
            rbtnMale.Name = "rbtnMale";
            rbtnMale.Size = new Size(91, 29);
            rbtnMale.TabIndex = 4;
            rbtnMale.TabStop = true;
            rbtnMale.Text = "Muško";
            rbtnMale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 29);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 3;
            label1.Text = "Prvenstvo:";
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbtnEnglish);
            gbLanguage.Controls.Add(rbtnCroatian);
            gbLanguage.Controls.Add(label2);
            gbLanguage.Location = new Point(12, 142);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Size = new Size(366, 117);
            gbLanguage.TabIndex = 12;
            gbLanguage.TabStop = false;
            // 
            // rbtnEnglish
            // 
            rbtnEnglish.AutoSize = true;
            rbtnEnglish.Location = new Point(227, 67);
            rbtnEnglish.Name = "rbtnEnglish";
            rbtnEnglish.Size = new Size(101, 29);
            rbtnEnglish.TabIndex = 8;
            rbtnEnglish.TabStop = true;
            rbtnEnglish.Text = "Engleski";
            rbtnEnglish.UseVisualStyleBackColor = true;
            // 
            // rbtnCroatian
            // 
            rbtnCroatian.AutoSize = true;
            rbtnCroatian.Location = new Point(32, 67);
            rbtnCroatian.Name = "rbtnCroatian";
            rbtnCroatian.Size = new Size(101, 29);
            rbtnCroatian.TabIndex = 7;
            rbtnCroatian.TabStop = true;
            rbtnCroatian.Text = "Hrvatski";
            rbtnCroatian.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 26);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 6;
            label2.Text = "Jezik:";
            // 
            // gbSource
            // 
            gbSource.Controls.Add(rbtnJson);
            gbSource.Controls.Add(rbtnApi);
            gbSource.Controls.Add(label3);
            gbSource.Location = new Point(12, 277);
            gbSource.Name = "gbSource";
            gbSource.Size = new Size(366, 117);
            gbSource.TabIndex = 13;
            gbSource.TabStop = false;
            // 
            // rbtnJson
            // 
            rbtnJson.AutoSize = true;
            rbtnJson.Location = new Point(227, 65);
            rbtnJson.Name = "rbtnJson";
            rbtnJson.Size = new Size(80, 29);
            rbtnJson.TabIndex = 11;
            rbtnJson.TabStop = true;
            rbtnJson.Text = "JSON";
            rbtnJson.UseVisualStyleBackColor = true;
            // 
            // rbtnApi
            // 
            rbtnApi.AutoSize = true;
            rbtnApi.Location = new Point(32, 65);
            rbtnApi.Name = "rbtnApi";
            rbtnApi.Size = new Size(64, 29);
            rbtnApi.TabIndex = 10;
            rbtnApi.TabStop = true;
            rbtnApi.Text = "API";
            rbtnApi.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 24);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 9;
            label3.Text = "Izvor:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(220, 411);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(158, 50);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Odustani";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 479);
            Controls.Add(btnCancel);
            Controls.Add(gbSource);
            Controls.Add(gbLanguage);
            Controls.Add(gbGender);
            Controls.Add(btnConfirm);
            Name = "SettingsForm";
            Text = "Settings";
            FormClosing += SettingsForm_FormClosing;
            Load += SettingsForm_Load;
            gbGender.ResumeLayout(false);
            gbGender.PerformLayout();
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            gbSource.ResumeLayout(false);
            gbSource.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnConfirm;
        private GroupBox gbGender;
        private RadioButton rbtnFemale;
        private RadioButton rbtnMale;
        private Label label1;
        private GroupBox gbLanguage;
        private RadioButton rbtnEnglish;
        private RadioButton rbtnCroatian;
        private Label label2;
        private GroupBox gbSource;
        private RadioButton rbtnJson;
        private RadioButton rbtnApi;
        private Label label3;
        private Button btnCancel;
    }
}
