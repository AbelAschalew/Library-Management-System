namespace MiniProjectApp;

partial class UsersettingPage
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


	private Panel usrStgHeader;
	private Label usrStgMainTitle;

	private Panel usrStgSideNav;
	private Label usrStgSnvTitle;
	private Panel usrStgMainCont;
	private Label usrStgSnvBkMgt;
	private Label usrStgSnvMbrMgt;
	private Label usrStgSnvBrw;
	private Label usrStgSnvRtn;
	private Label usrStgSnvRpt;
	private Label usrStgSnvDshBrd;
	private Label usrStgSnvSrch;
	private Label usrStgPgeTitle;
	private PictureBox usrStgLogo;

	private Label usrStgMainContTitle;
	private Label usrStgMainUsrIdLbl;
	private TextBox usrStgMainUsrIdInp;
	private Label usrStgMainUsrRoleLbl;
	private TextBox usrStgMainUsrRoleInp;
	private Label usrStgMainUsrNameLbl;
	private TextBox usrStgMainUsrNameInp;
	private Label usrStgMainUsrPasswordLbl;
	private TextBox usrStgMainUsrPasswordInp;
	private Button saveChangesBtn;


    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "User Setting Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;

	

	usrStgHeader = new Panel();
	usrStgHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(usrStgHeader);

	usrStgMainTitle = new Label();
	usrStgMainTitle.Text = "Cruise Library Management System";
	usrStgMainTitle.ForeColor = Color.White;
	usrStgMainTitle.BackColor = Color.Transparent;
	usrStgMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	usrStgHeader.Controls.Add(usrStgMainTitle);

	usrStgPgeTitle = new Label();
	usrStgPgeTitle.Text = "USER SETTING";
	usrStgPgeTitle.ForeColor = Color.Brown;
	usrStgPgeTitle.BackColor = Color.Transparent;
	usrStgPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	usrStgHeader.Controls.Add(usrStgPgeTitle);

	usrStgLogo = new PictureBox();
	usrStgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	usrStgHeader.Controls.Add(usrStgLogo);

	usrStgSideNav = new Panel();
	usrStgSideNav.BackColor = Color.White;
	usrStgSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(usrStgSideNav);

	usrStgSnvTitle = new Label();
	usrStgSnvTitle.Text = "Navigation";
	usrStgSnvTitle.BackColor = Color.CornflowerBlue;
	usrStgSnvTitle.ForeColor = Color.White;
	usrStgSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSideNav.Controls.Add(usrStgSnvTitle);

	usrStgSnvBkMgt =  new Label();
	usrStgSnvBkMgt.Text = "Book Management";
	usrStgSnvBkMgt.ForeColor = Color.Blue;
	usrStgSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvBkMgt.Click += new EventHandler(usrStgSnvBkMgt_Clicked);
	usrStgSnvBkMgt.Cursor = Cursors.Hand;
	usrStgSnvBkMgt.MouseEnter += new EventHandler(usrStgSnvBkMgt_MouseEnter);
	usrStgSnvBkMgt.MouseLeave += new EventHandler(usrStgSnvBkMgt_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvBkMgt);

	usrStgSnvMbrMgt =  new Label();
	usrStgSnvMbrMgt.Text = "Member Management";
	usrStgSnvMbrMgt.ForeColor = Color.Blue;
	usrStgSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvMbrMgt.Click += new EventHandler(usrStgSnvMbrMgt_Clicked);
	usrStgSnvMbrMgt.Cursor = Cursors.Hand;
	usrStgSnvMbrMgt.MouseEnter += new EventHandler(usrStgSnvMbrMgt_MouseEnter);
	usrStgSnvMbrMgt.MouseLeave += new EventHandler(usrStgSnvMbrMgt_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvMbrMgt);

	usrStgSnvBrw =  new Label();
	usrStgSnvBrw.Text = "Borrow Book";
	usrStgSnvBrw.ForeColor = Color.Blue;
	usrStgSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvBrw.Click += new EventHandler(usrStgSnvBrw_Clicked);
	usrStgSnvBrw.Cursor = Cursors.Hand;
	usrStgSnvBrw.MouseEnter += new EventHandler(usrStgSnvBrw_MouseEnter);
	usrStgSnvBrw.MouseLeave += new EventHandler(usrStgSnvBrw_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvBrw);

	usrStgSnvRtn =  new Label();
	usrStgSnvRtn.Text = "Return Book";
	usrStgSnvRtn.ForeColor = Color.Blue;
	usrStgSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvRtn.Click += new EventHandler(usrStgSnvRtn_Clicked);
	usrStgSnvRtn.Cursor = Cursors.Hand;
	usrStgSnvRtn.MouseEnter += new EventHandler(usrStgSnvRtn_MouseEnter);
	usrStgSnvRtn.MouseLeave += new EventHandler(usrStgSnvRtn_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvRtn);

	usrStgSnvRpt =  new Label();
	usrStgSnvRpt.Text = "Reports";
	usrStgSnvRpt.ForeColor = Color.Blue;
	usrStgSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvRpt.Click += new EventHandler(usrStgSnvRpt_Clicked);
	usrStgSnvRpt.Cursor = Cursors.Hand;
	usrStgSnvRpt.MouseEnter += new EventHandler(usrStgSnvRpt_MouseEnter);
	usrStgSnvRpt.MouseLeave += new EventHandler(usrStgSnvRpt_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvRpt);

	usrStgSnvDshBrd =  new Label();
	usrStgSnvDshBrd.Text = "Dashboard";
	usrStgSnvDshBrd.ForeColor = Color.Blue;
	usrStgSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvDshBrd.Click += new EventHandler(usrStgSnvDshBrd_Clicked);
	usrStgSnvDshBrd.Cursor = Cursors.Hand;
	usrStgSnvDshBrd.MouseEnter += new EventHandler(usrStgSnvDshBrd_MouseEnter);
	usrStgSnvDshBrd.MouseLeave += new EventHandler(usrStgSnvDshBrd_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvDshBrd);

	usrStgSnvSrch =  new Label();
	usrStgSnvSrch.Text = "Search";
	usrStgSnvSrch.ForeColor = Color.Blue;
	usrStgSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	usrStgSnvSrch.Click += new EventHandler(usrStgSnvSrch_Clicked);
	usrStgSnvSrch.Cursor = Cursors.Hand;
	usrStgSnvSrch.MouseEnter += new EventHandler(usrStgSnvSrch_MouseEnter);
	usrStgSnvSrch.MouseLeave += new EventHandler(usrStgSnvSrch_MouseLeave);
	usrStgSideNav.Controls.Add(usrStgSnvSrch);

	usrStgMainCont = new Panel();
	usrStgMainCont.BackColor = Color.White;
	this.Controls.Add(usrStgMainCont);

	usrStgMainContTitle = new Label();
	usrStgMainContTitle.Text = "CONFIGURE SETTINGS";
	usrStgMainContTitle.ForeColor = Color.Brown;
	usrStgMainCont.Controls.Add(usrStgMainContTitle);

	usrStgMainUsrIdLbl = new Label();
	usrStgMainUsrIdLbl.Text = "User ID:";
	usrStgMainUsrIdLbl.ForeColor = Color.DarkSlateGray;
	usrStgMainCont.Controls.Add(usrStgMainUsrIdLbl);

	usrStgMainUsrIdInp = new TextBox();
	usrStgMainUsrIdInp.BackColor = Color.LightGray;
	usrStgMainUsrIdInp.ForeColor = Color.Gray;
	usrStgMainUsrIdInp.ReadOnly = true;
	usrStgMainCont.Controls.Add(usrStgMainUsrIdInp);

	usrStgMainUsrRoleLbl = new Label();
	usrStgMainUsrRoleLbl.Text = "User Role:";
	usrStgMainUsrRoleLbl.ForeColor = Color.DarkSlateGray;
	usrStgMainCont.Controls.Add(usrStgMainUsrRoleLbl);

	usrStgMainUsrRoleInp = new TextBox();
	usrStgMainUsrRoleInp.BackColor = Color.LightGray;
	usrStgMainUsrRoleInp.ForeColor = Color.Gray;
	usrStgMainUsrRoleInp.ReadOnly = true;
	usrStgMainCont.Controls.Add(usrStgMainUsrRoleInp);

	usrStgMainUsrNameLbl = new Label();
	usrStgMainUsrNameLbl.Text = "New Username:";
	usrStgMainUsrNameLbl.ForeColor = Color.DarkSlateGray;
	usrStgMainCont.Controls.Add(usrStgMainUsrNameLbl);

	usrStgMainUsrNameInp = new TextBox();
	usrStgMainUsrNameInp.BorderStyle = BorderStyle.FixedSingle;
	usrStgMainCont.Controls.Add(usrStgMainUsrNameInp);

	usrStgMainUsrPasswordLbl = new Label();
	usrStgMainUsrPasswordLbl.Text = "New Password:";
	usrStgMainUsrPasswordLbl.ForeColor = Color.DarkSlateGray;
	usrStgMainCont.Controls.Add(usrStgMainUsrPasswordLbl);

	usrStgMainUsrPasswordInp = new TextBox();
	usrStgMainUsrPasswordInp.BorderStyle = BorderStyle.FixedSingle;
	usrStgMainCont.Controls.Add(usrStgMainUsrPasswordInp);

	saveChangesBtn = new Button();
	saveChangesBtn.Text = "SAVE CHANGES";
	saveChangesBtn.BackColor = Color.Green;
	saveChangesBtn.Click += new EventHandler(saveChangesBtn_Clicked);
	usrStgMainCont.Controls.Add(saveChangesBtn);

    }

    #endregion
}
