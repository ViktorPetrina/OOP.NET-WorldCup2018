namespace ViktorPetrina
{
    partial class MainForm
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
            lblChooseTeam = new Label();
            cbTeams = new ComboBox();
            lbPlayers = new ListBox();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            btnConfirm = new Button();
            lblFavTeam = new Label();
            lbFavPlayers = new ListBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblChooseTeam
            // 
            lblChooseTeam.AutoSize = true;
            lblChooseTeam.Location = new Point(38, 101);
            lblChooseTeam.Margin = new Padding(2, 0, 2, 0);
            lblChooseTeam.Name = "lblChooseTeam";
            lblChooseTeam.Size = new Size(194, 25);
            lblChooseTeam.TabIndex = 0;
            lblChooseTeam.Text = "Odaberi reprezentaciju:";
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(251, 98);
            cbTeams.Margin = new Padding(2);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(199, 33);
            cbTeams.TabIndex = 1;
            cbTeams.SelectedValueChanged += cbTeams_SelectedValueChanged;
            // 
            // lbPlayers
            // 
            lbPlayers.FormattingEnabled = true;
            lbPlayers.ItemHeight = 25;
            lbPlayers.Location = new Point(500, 63);
            lbPlayers.Margin = new Padding(2);
            lbPlayers.Name = "lbPlayers";
            lbPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbPlayers.Size = new Size(272, 279);
            lbPlayers.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(819, 36);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 226);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(42, 155);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(408, 34);
            progressBar1.TabIndex = 4;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(42, 210);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(190, 52);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Potvrdi";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblFavTeam
            // 
            lblFavTeam.AutoSize = true;
            lblFavTeam.Location = new Point(38, 32);
            lblFavTeam.Name = "lblFavTeam";
            lblFavTeam.Size = new Size(204, 25);
            lblFavTeam.TabIndex = 6;
            lblFavTeam.Text = "Omiljena reprezentacija: ";
            // 
            // lbFavPlayers
            // 
            lbFavPlayers.FormattingEnabled = true;
            lbFavPlayers.ItemHeight = 25;
            lbFavPlayers.Location = new Point(500, 443);
            lbFavPlayers.Name = "lbFavPlayers";
            lbFavPlayers.Size = new Size(272, 129);
            lbFavPlayers.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(500, 404);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 8;
            label1.Text = "Omiljeni igrači:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(500, 32);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 9;
            label2.Text = "Igrači reprezentacije:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 925);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbFavPlayers);
            Controls.Add(lblFavTeam);
            Controls.Add(btnConfirm);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(lbPlayers);
            Controls.Add(cbTeams);
            Controls.Add(lblChooseTeam);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChooseTeam;
        private ComboBox cbTeams;
        private ListBox lbPlayers;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private Button btnConfirm;
        private Label lblFavTeam;
        private ListBox lbFavPlayers;
        private Label label1;
        private Label label2;
    }
}