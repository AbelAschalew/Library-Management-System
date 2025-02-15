namespace MiniProjectApp;

partial class MembermanagementPage
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


	private Panel mbrMgtHeader;
	private Label mbrMgtMainTitle;

	private Panel mbrMgtSideNav;
	private Label mbrMgtSnvTitle;
	private Panel mbrMgtMainCont;
	private Label mbrMgtSnvBkMgt;
	private Label mbrMgtSnvDshBrd;
	private Label mbrMgtSnvBrw;
	private Label mbrMgtSnvRtn;
	private Label mbrMgtSnvRpt;
	private Label mbrMgtSnvUsrStg;
	private Label mbrMgtSnvSrch;
	private Label mbrMgtPgeTitle;
	private PictureBox mbrMgtLogo;

	private Label MbrMgtMainCntTitle;
	private DataGridView MbrMgtGridView;
	private Button MbrMgtAddBtn;
	private Panel addMbrCont;
	private Label addMbrTitle;
	private Button addMbrCloseBtn;

	private Label addMbrNameLbl;
	private TextBox addMbrNameInp;
	private Label addMbrEmailLbl;
	private TextBox addMbrEmailInp;
	private Label addMbrPhoneLbl;
	private TextBox addMbrPhoneInp;
	private Label addMbrRegdateLbl;
	private DateTimePicker addMbrRegdateInp;
	private Label addMbrStatusLbl;
	private ComboBox addMbrStatusInp;
	private Button addMbrAddBtn;
	private Button activateEditBtn;
	private Label actvateEditMessage;


    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "Member Management Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;



	mbrMgtHeader = new Panel();
	mbrMgtHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(mbrMgtHeader);

	mbrMgtMainTitle = new Label();
	mbrMgtMainTitle.Text = "Cruise Library Management System";
	mbrMgtMainTitle.ForeColor = Color.White;
	mbrMgtMainTitle.BackColor = Color.Transparent;
	mbrMgtMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtHeader.Controls.Add(mbrMgtMainTitle);

	mbrMgtPgeTitle = new Label();
	mbrMgtPgeTitle.Text = "MEMBER MANAGEMENT";
	mbrMgtPgeTitle.ForeColor = Color.Brown;
	mbrMgtPgeTitle.BackColor = Color.Transparent;
	mbrMgtPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtHeader.Controls.Add(mbrMgtPgeTitle);

	mbrMgtLogo = new PictureBox();
	mbrMgtLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	mbrMgtHeader.Controls.Add(mbrMgtLogo);

	mbrMgtSideNav = new Panel();
	mbrMgtSideNav.BackColor = Color.White;
	mbrMgtSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(mbrMgtSideNav);

	mbrMgtSnvTitle = new Label();
	mbrMgtSnvTitle.Text = "Navigation";
	mbrMgtSnvTitle.BackColor = Color.CornflowerBlue;
	mbrMgtSnvTitle.ForeColor = Color.White;
	mbrMgtSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSideNav.Controls.Add(mbrMgtSnvTitle);

	mbrMgtSnvBkMgt =  new Label();
	mbrMgtSnvBkMgt.Text = "Book Management";
	mbrMgtSnvBkMgt.ForeColor = Color.Blue;
	mbrMgtSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvBkMgt.Click += new EventHandler(mbrMgtSnvBkMgt_Clicked);
	mbrMgtSnvBkMgt.Cursor = Cursors.Hand;
	mbrMgtSnvBkMgt.MouseEnter += new EventHandler(mbrMgtSnvBkMgt_MouseEnter);
	mbrMgtSnvBkMgt.MouseLeave += new EventHandler(mbrMgtSnvBkMgt_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvBkMgt);

	mbrMgtSnvDshBrd =  new Label();
	mbrMgtSnvDshBrd.Text = "Dashboard";
	mbrMgtSnvDshBrd.ForeColor = Color.Blue;
	mbrMgtSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvDshBrd.Click += new EventHandler(mbrMgtSnvDshBrd_Clicked);
	mbrMgtSnvDshBrd.Cursor = Cursors.Hand;
	mbrMgtSnvDshBrd.MouseEnter += new EventHandler(mbrMgtSnvDshBrd_MouseEnter);
	mbrMgtSnvDshBrd.MouseLeave += new EventHandler(mbrMgtSnvDshBrd_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvDshBrd);

	mbrMgtSnvBrw =  new Label();
	mbrMgtSnvBrw.Text = "Borrow Book";
	mbrMgtSnvBrw.ForeColor = Color.Blue;
	mbrMgtSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvBrw.Click += new EventHandler(mbrMgtSnvBrw_Clicked);
	mbrMgtSnvBrw.Cursor = Cursors.Hand;
	mbrMgtSnvBrw.MouseEnter += new EventHandler(mbrMgtSnvBrw_MouseEnter);
	mbrMgtSnvBrw.MouseLeave += new EventHandler(mbrMgtSnvBrw_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvBrw);

	mbrMgtSnvRtn =  new Label();
	mbrMgtSnvRtn.Text = "Return Book";
	mbrMgtSnvRtn.ForeColor = Color.Blue;
	mbrMgtSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvRtn.Click += new EventHandler(mbrMgtSnvRtn_Clicked);
	mbrMgtSnvRtn.Cursor = Cursors.Hand;
	mbrMgtSnvRtn.MouseEnter += new EventHandler(mbrMgtSnvRtn_MouseEnter);
	mbrMgtSnvRtn.MouseLeave += new EventHandler(mbrMgtSnvRtn_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvRtn);

	mbrMgtSnvRpt =  new Label();
	mbrMgtSnvRpt.Text = "Reports";
	mbrMgtSnvRpt.ForeColor = Color.Blue;
	mbrMgtSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvRpt.Click += new EventHandler(mbrMgtSnvRpt_Clicked);
	mbrMgtSnvRpt.Cursor = Cursors.Hand;
	mbrMgtSnvRpt.MouseEnter += new EventHandler(mbrMgtSnvRpt_MouseEnter);
	mbrMgtSnvRpt.MouseLeave += new EventHandler(mbrMgtSnvRpt_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvRpt);

	mbrMgtSnvUsrStg =  new Label();
	mbrMgtSnvUsrStg.Text = "User Setting";
	mbrMgtSnvUsrStg.ForeColor = Color.Blue;
	mbrMgtSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvUsrStg.Click += new EventHandler(mbrMgtSnvUsrStg_Clicked);
	mbrMgtSnvUsrStg.Cursor = Cursors.Hand;
	mbrMgtSnvUsrStg.MouseEnter += new EventHandler(mbrMgtSnvUsrStg_MouseEnter);
	mbrMgtSnvUsrStg.MouseLeave += new EventHandler(mbrMgtSnvUsrStg_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvUsrStg);

	mbrMgtSnvSrch =  new Label();
	mbrMgtSnvSrch.Text = "Search";
	mbrMgtSnvSrch.ForeColor = Color.Blue;
	mbrMgtSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	mbrMgtSnvSrch.Click += new EventHandler(mbrMgtSnvSrch_Clicked);
	mbrMgtSnvSrch.Cursor = Cursors.Hand;
	mbrMgtSnvSrch.MouseEnter += new EventHandler(mbrMgtSnvSrch_MouseEnter);
	mbrMgtSnvSrch.MouseLeave += new EventHandler(mbrMgtSnvSrch_MouseLeave);
	mbrMgtSideNav.Controls.Add(mbrMgtSnvSrch);

	mbrMgtMainCont = new Panel();
	mbrMgtMainCont.BackColor = Color.White;
	this.Controls.Add(mbrMgtMainCont);

	MbrMgtMainCntTitle = new Label();
	MbrMgtMainCntTitle.Text = "MANAGE MEMBERS";
	MbrMgtMainCntTitle.ForeColor = Color.Brown;
	mbrMgtMainCont.Controls.Add(MbrMgtMainCntTitle);

	activateEditBtn = new Button();
	activateEditBtn.Text = "Activate Edit";
	activateEditBtn.BackColor = Color.Yellow;
	activateEditBtn.Click += new EventHandler(activateEditBtn_Clicked);
	mbrMgtMainCont.Controls.Add(activateEditBtn);

	actvateEditMessage = new Label();
	actvateEditMessage.Text = "Now You Can Edit the Table! To Update, Edit Cells.\n To Delete a Record, Select Rows and Hit 'Delete' Key.";
	actvateEditMessage.ForeColor = Color.Red;
	mbrMgtMainCont.Controls.Add(actvateEditMessage);

	MbrMgtGridView = new DataGridView();
	MbrMgtGridView.ReadOnly = true;
	mbrMgtMainCont.Controls.Add(MbrMgtGridView);

	MbrMgtAddBtn = new Button();
	MbrMgtAddBtn.Text = "ADD MEMBER";
	MbrMgtAddBtn.BackColor = Color.Yellow;
	MbrMgtAddBtn.Click += new EventHandler(MbrMgtAddBtn_Clicked);
	mbrMgtMainCont.Controls.Add(MbrMgtAddBtn);

	addMbrCont = new Panel();
	addMbrCont.BackColor = Color.Aquamarine;
	addMbrCont.BorderStyle = BorderStyle.FixedSingle;
	this.Controls.Add(addMbrCont);
	this.Controls.SetChildIndex(addMbrCont,0);

	addMbrTitle = new Label();
	addMbrTitle.Text = "Add New Member";
	addMbrCont.Controls.Add(addMbrTitle);

	addMbrCloseBtn = new Button();
	addMbrCloseBtn.Text = "X";
	addMbrCloseBtn.ForeColor = Color.Red;
	addMbrCloseBtn.Click += new EventHandler(addMbrCloseBtn_Clicked);
	addMbrCont.Controls.Add(addMbrCloseBtn);

	addMbrNameLbl = new Label();
	addMbrNameLbl.Text = "Name:";
	addMbrNameLbl.ForeColor = Color.DarkSlateGray;
	addMbrCont.Controls.Add(addMbrNameLbl);

	addMbrNameInp = new TextBox();
	addMbrCont.Controls.Add(addMbrNameInp);

	addMbrEmailLbl = new Label();
	addMbrEmailLbl.Text = "Email:";
	addMbrEmailLbl.ForeColor = Color.DarkSlateGray;
	addMbrCont.Controls.Add(addMbrEmailLbl);

	addMbrEmailInp = new TextBox();
	addMbrCont.Controls.Add(addMbrEmailInp);

	addMbrPhoneLbl = new Label();
	addMbrPhoneLbl.Text = "Phone Number:";
	addMbrPhoneLbl.ForeColor = Color.DarkSlateGray;
	addMbrCont.Controls.Add(addMbrPhoneLbl);

	addMbrPhoneInp = new TextBox();
	addMbrCont.Controls.Add(addMbrPhoneInp);

	addMbrRegdateLbl = new Label();
	addMbrRegdateLbl.Text = "Registration Date:";
	addMbrRegdateLbl.ForeColor = Color.DarkSlateGray;
	addMbrCont.Controls.Add(addMbrRegdateLbl);

	addMbrRegdateInp = new DateTimePicker();
	addMbrRegdateInp.Format = DateTimePickerFormat.Short;
	addMbrCont.Controls.Add(addMbrRegdateInp);
	
	addMbrStatusLbl = new Label();
	addMbrStatusLbl.Text = "Status:";
	addMbrStatusLbl.ForeColor = Color.DarkSlateGray;
	addMbrCont.Controls.Add(addMbrStatusLbl);

	addMbrStatusInp = new ComboBox();
	addMbrStatusInp.Items.Add("active");
	addMbrStatusInp.Items.Add("inactive");
	addMbrCont.Controls.Add(addMbrStatusInp);

	addMbrAddBtn = new Button();
	addMbrAddBtn.Text = "ADD MEMBER";
	addMbrAddBtn.BackColor = Color.Green;
	addMbrAddBtn.Click += new EventHandler(addMbrAddBtn_Clicked);
	addMbrCont.Controls.Add(addMbrAddBtn);

    }

    #endregion
}
