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
            lblPlayerName = new Label();
            lblPlayerNumber = new Label();
            lblPlayerIsCaptain = new Label();
            lblPlayerIsFavourite = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblChooseTeam
            // 
            lblChooseTeam.AutoSize = true;
            lblChooseTeam.Location = new Point(30, 81);
            lblChooseTeam.Margin = new Padding(2, 0, 2, 0);
            lblChooseTeam.Name = "lblChooseTeam";
            lblChooseTeam.Size = new Size(164, 20);
            lblChooseTeam.TabIndex = 0;
            lblChooseTeam.Text = "Odaberi reprezentaciju:";
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(201, 78);
            cbTeams.Margin = new Padding(2);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(160, 28);
            cbTeams.TabIndex = 1;
            cbTeams.SelectedValueChanged += cbTeams_SelectedValueChanged;
            // 
            // lbPlayers
            // 
            lbPlayers.FormattingEnabled = true;
            lbPlayers.ItemHeight = 20;
            lbPlayers.Location = new Point(400, 48);
            lbPlayers.Margin = new Padding(2);
            lbPlayers.Name = "lbPlayers";
            lbPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbPlayers.Size = new Size(218, 224);
            lbPlayers.TabIndex = 2;
            lbPlayers.SelectedValueChanged += lbPlayers_SelectedValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(655, 29);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 181);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(34, 124);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(326, 27);
            progressBar1.TabIndex = 4;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(702, 664);
            btnConfirm.Margin = new Padding(2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(152, 42);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Potvrdi";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblFavTeam
            // 
            lblFavTeam.AutoSize = true;
            lblFavTeam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFavTeam.Location = new Point(11, 18);
            lblFavTeam.Margin = new Padding(2, 0, 2, 0);
            lblFavTeam.Name = "lblFavTeam";
            lblFavTeam.Size = new Size(226, 28);
            lblFavTeam.TabIndex = 6;
            lblFavTeam.Text = "Omiljena reprezentacija: ";
            // 
            // lbFavPlayers
            // 
            lbFavPlayers.FormattingEnabled = true;
            lbFavPlayers.ItemHeight = 20;
            lbFavPlayers.Location = new Point(400, 354);
            lbFavPlayers.Margin = new Padding(2);
            lbFavPlayers.Name = "lbFavPlayers";
            lbFavPlayers.Size = new Size(218, 104);
            lbFavPlayers.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(400, 332);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 8;
            label1.Text = "Omiljeni igrači:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(400, 26);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 9;
            label2.Text = "Igrači reprezentacije:";
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Location = new Point(655, 223);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(37, 20);
            lblPlayerName.TabIndex = 10;
            lblPlayerName.Text = "Ime:";
            // 
            // lblPlayerNumber
            // 
            lblPlayerNumber.AutoSize = true;
            lblPlayerNumber.Location = new Point(655, 269);
            lblPlayerNumber.Name = "lblPlayerNumber";
            lblPlayerNumber.Size = new Size(39, 20);
            lblPlayerNumber.TabIndex = 11;
            lblPlayerNumber.Text = "Broj:";
            // 
            // lblPlayerIsCaptain
            // 
            lblPlayerIsCaptain.AutoSize = true;
            lblPlayerIsCaptain.Location = new Point(655, 312);
            lblPlayerIsCaptain.Name = "lblPlayerIsCaptain";
            lblPlayerIsCaptain.Size = new Size(67, 20);
            lblPlayerIsCaptain.TabIndex = 12;
            lblPlayerIsCaptain.Text = "Kapetan:";
            // 
            // lblPlayerIsFavourite
            // 
            lblPlayerIsFavourite.AutoSize = true;
            lblPlayerIsFavourite.Location = new Point(655, 354);
            lblPlayerIsFavourite.Name = "lblPlayerIsFavourite";
            lblPlayerIsFavourite.Size = new Size(56, 20);
            lblPlayerIsFavourite.TabIndex = 13;
            lblPlayerIsFavourite.Text = "Favorit:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 740);
            Controls.Add(lblPlayerIsFavourite);
            Controls.Add(lblPlayerIsCaptain);
            Controls.Add(lblPlayerNumber);
            Controls.Add(lblPlayerName);
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
        private Label lblPlayerName;
        private Label lblPlayerNumber;
        private Label lblPlayerIsCaptain;
        private Label lblPlayerIsFavourite;
    }
}