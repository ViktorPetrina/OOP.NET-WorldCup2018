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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblChooseTeam = new Label();
            cbTeams = new ComboBox();
            lbPlayers = new ListBox();
            pbPlayerImage = new PictureBox();
            progressBar = new ProgressBar();
            btnConfirm = new Button();
            lblFavTeamLbl = new Label();
            lbFavPlayers = new ListBox();
            cmsFavPlayers = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            lblPlayerNameLabel = new Label();
            lblPlayerNumberLabel = new Label();
            lblPlayerIsCaptainLabel = new Label();
            lblPlayerIsFavouriteLabel = new Label();
            lblFavTeam = new Label();
            lblPlayerName = new Label();
            lblPlayerNumber = new Label();
            lblPlayerIsCaptain = new Label();
            lblPlayerIsFavourite = new Label();
            btnChoosePlayerImage = new Button();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            savePreferencesToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).BeginInit();
            cmsFavPlayers.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblChooseTeam
            // 
            resources.ApplyResources(lblChooseTeam, "lblChooseTeam");
            lblChooseTeam.Name = "lblChooseTeam";
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.Name = "cbTeams";
            cbTeams.SelectedValueChanged += cbTeams_SelectedValueChanged;
            // 
            // lbPlayers
            // 
            lbPlayers.FormattingEnabled = true;
            resources.ApplyResources(lbPlayers, "lbPlayers");
            lbPlayers.Name = "lbPlayers";
            lbPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbPlayers.SelectedValueChanged += lbPlayers_SelectedValueChanged;
            lbPlayers.MouseDown += lbPlayers_MouseDown;
            // 
            // pbPlayerImage
            // 
            resources.ApplyResources(pbPlayerImage, "pbPlayerImage");
            pbPlayerImage.Name = "pbPlayerImage";
            pbPlayerImage.TabStop = false;
            // 
            // progressBar
            // 
            resources.ApplyResources(progressBar, "progressBar");
            progressBar.Name = "progressBar";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblFavTeamLbl
            // 
            resources.ApplyResources(lblFavTeamLbl, "lblFavTeamLbl");
            lblFavTeamLbl.Name = "lblFavTeamLbl";
            // 
            // lbFavPlayers
            // 
            lbFavPlayers.AllowDrop = true;
            lbFavPlayers.ContextMenuStrip = cmsFavPlayers;
            lbFavPlayers.FormattingEnabled = true;
            resources.ApplyResources(lbFavPlayers, "lbFavPlayers");
            lbFavPlayers.Name = "lbFavPlayers";
            lbFavPlayers.MouseClick += lbFavPlayers_MouseClick;
            lbFavPlayers.DragDrop += lbFavPlayers_DragDrop;
            lbFavPlayers.DragEnter += lbFavPlayers_DragEnter;
            // 
            // cmsFavPlayers
            // 
            cmsFavPlayers.ImageScalingSize = new Size(20, 20);
            cmsFavPlayers.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem });
            cmsFavPlayers.Name = "cmsFavPlayers";
            resources.ApplyResources(cmsFavPlayers, "cmsFavPlayers");
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(removeToolStripMenuItem, "removeToolStripMenuItem");
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // lblPlayerNameLabel
            // 
            resources.ApplyResources(lblPlayerNameLabel, "lblPlayerNameLabel");
            lblPlayerNameLabel.Name = "lblPlayerNameLabel";
            // 
            // lblPlayerNumberLabel
            // 
            resources.ApplyResources(lblPlayerNumberLabel, "lblPlayerNumberLabel");
            lblPlayerNumberLabel.Name = "lblPlayerNumberLabel";
            // 
            // lblPlayerIsCaptainLabel
            // 
            resources.ApplyResources(lblPlayerIsCaptainLabel, "lblPlayerIsCaptainLabel");
            lblPlayerIsCaptainLabel.Name = "lblPlayerIsCaptainLabel";
            // 
            // lblPlayerIsFavouriteLabel
            // 
            resources.ApplyResources(lblPlayerIsFavouriteLabel, "lblPlayerIsFavouriteLabel");
            lblPlayerIsFavouriteLabel.Name = "lblPlayerIsFavouriteLabel";
            // 
            // lblFavTeam
            // 
            resources.ApplyResources(lblFavTeam, "lblFavTeam");
            lblFavTeam.Name = "lblFavTeam";
            // 
            // lblPlayerName
            // 
            resources.ApplyResources(lblPlayerName, "lblPlayerName");
            lblPlayerName.Name = "lblPlayerName";
            // 
            // lblPlayerNumber
            // 
            resources.ApplyResources(lblPlayerNumber, "lblPlayerNumber");
            lblPlayerNumber.Name = "lblPlayerNumber";
            // 
            // lblPlayerIsCaptain
            // 
            resources.ApplyResources(lblPlayerIsCaptain, "lblPlayerIsCaptain");
            lblPlayerIsCaptain.Name = "lblPlayerIsCaptain";
            // 
            // lblPlayerIsFavourite
            // 
            resources.ApplyResources(lblPlayerIsFavourite, "lblPlayerIsFavourite");
            lblPlayerIsFavourite.Name = "lblPlayerIsFavourite";
            // 
            // btnChoosePlayerImage
            // 
            resources.ApplyResources(btnChoosePlayerImage, "btnChoosePlayerImage");
            btnChoosePlayerImage.Name = "btnChoosePlayerImage";
            btnChoosePlayerImage.UseVisualStyleBackColor = true;
            btnChoosePlayerImage.Click += btnChoosePlayerImage_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { savePreferencesToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // savePreferencesToolStripMenuItem
            // 
            savePreferencesToolStripMenuItem.Name = "savePreferencesToolStripMenuItem";
            resources.ApplyResources(savePreferencesToolStripMenuItem, "savePreferencesToolStripMenuItem");
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // openSettingsToolStripMenuItem
            // 
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            resources.ApplyResources(openSettingsToolStripMenuItem, "openSettingsToolStripMenuItem");
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(menuStrip);
            Controls.Add(btnChoosePlayerImage);
            Controls.Add(lblPlayerIsFavourite);
            Controls.Add(lblPlayerIsCaptain);
            Controls.Add(lblPlayerNumber);
            Controls.Add(lblPlayerName);
            Controls.Add(lblFavTeam);
            Controls.Add(lblPlayerIsFavouriteLabel);
            Controls.Add(lblPlayerIsCaptainLabel);
            Controls.Add(lblPlayerNumberLabel);
            Controls.Add(lblPlayerNameLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbFavPlayers);
            Controls.Add(lblFavTeamLbl);
            Controls.Add(btnConfirm);
            Controls.Add(progressBar);
            Controls.Add(pbPlayerImage);
            Controls.Add(lbPlayers);
            Controls.Add(cbTeams);
            Controls.Add(lblChooseTeam);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).EndInit();
            cmsFavPlayers.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChooseTeam;
        private ComboBox cbTeams;
        private ListBox lbPlayers;
        private PictureBox pbPlayerImage;
        private ProgressBar progressBar;
        private Button btnConfirm;
        private Label lblFavTeamLbl;
        private ListBox lbFavPlayers;
        private Label label1;
        private Label label2;
        private Label lblPlayerNameLabel;
        private Label lblPlayerNumberLabel;
        private Label lblPlayerIsCaptainLabel;
        private Label lblPlayerIsFavouriteLabel;
        private Label lblFavTeam;
        private Label lblPlayerName;
        private Label lblPlayerNumber;
        private Label lblPlayerIsCaptain;
        private Label lblPlayerIsFavourite;
        private Button btnChoosePlayerImage;
        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem savePreferencesToolStripMenuItem;
        private ToolStripMenuItem openSettingsToolStripMenuItem;
        private ContextMenuStrip cmsFavPlayers;
        private ToolStripMenuItem removeToolStripMenuItem;
    }
}