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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
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
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbtnFemale);
            gbGender.Controls.Add(rbtnMale);
            gbGender.Controls.Add(label1);
            resources.ApplyResources(gbGender, "gbGender");
            gbGender.Name = "gbGender";
            gbGender.TabStop = false;
            // 
            // rbtnFemale
            // 
            resources.ApplyResources(rbtnFemale, "rbtnFemale");
            rbtnFemale.Name = "rbtnFemale";
            rbtnFemale.TabStop = true;
            rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            resources.ApplyResources(rbtnMale, "rbtnMale");
            rbtnMale.Name = "rbtnMale";
            rbtnMale.TabStop = true;
            rbtnMale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbtnEnglish);
            gbLanguage.Controls.Add(rbtnCroatian);
            gbLanguage.Controls.Add(label2);
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // rbtnEnglish
            // 
            resources.ApplyResources(rbtnEnglish, "rbtnEnglish");
            rbtnEnglish.Name = "rbtnEnglish";
            rbtnEnglish.TabStop = true;
            rbtnEnglish.UseVisualStyleBackColor = true;
            // 
            // rbtnCroatian
            // 
            resources.ApplyResources(rbtnCroatian, "rbtnCroatian");
            rbtnCroatian.Name = "rbtnCroatian";
            rbtnCroatian.TabStop = true;
            rbtnCroatian.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // gbSource
            // 
            gbSource.Controls.Add(rbtnJson);
            gbSource.Controls.Add(rbtnApi);
            gbSource.Controls.Add(label3);
            resources.ApplyResources(gbSource, "gbSource");
            gbSource.Name = "gbSource";
            gbSource.TabStop = false;
            // 
            // rbtnJson
            // 
            resources.ApplyResources(rbtnJson, "rbtnJson");
            rbtnJson.Name = "rbtnJson";
            rbtnJson.TabStop = true;
            rbtnJson.UseVisualStyleBackColor = true;
            // 
            // rbtnApi
            // 
            resources.ApplyResources(rbtnApi, "rbtnApi");
            rbtnApi.Name = "rbtnApi";
            rbtnApi.TabStop = true;
            rbtnApi.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCancel);
            Controls.Add(gbSource);
            Controls.Add(gbLanguage);
            Controls.Add(gbGender);
            Controls.Add(btnConfirm);
            KeyPreview = true;
            Name = "SettingsForm";
            Load += SettingsForm_Load;
            KeyDown += SettingsForm_KeyDown;
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
