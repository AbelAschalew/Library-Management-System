namespace MiniProjectApp;

partial class BorrowPage
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


	private Panel brwHeader;
	private Label brwMainTitle;

	private Panel brwSideNav;
	private Label brwSnvTitle;
	private Panel brwMainCont;
	private Label brwSnvBkMgt;
	private Label brwSnvMbrMgt;
	private Label brwSnvDshBrd;
	private Label brwSnvRtn;
	private Label brwSnvRpt;
	private Label brwSnvUsrStg;
	private Label brwSnvSrch;
	private PictureBox brwLogo;
	private Label brwPgeTitle;

	private Label brwMainContTitle;
	private Label brwMainMbrNmLbl;
	private TextBox brwMainMbrNmInp;
	private Label brwMainBkrNmLbl;
	private TextBox brwMainBkrNmInp;
	private Button brwMainBkMbrCheckBtn;

	private Panel borrowBkCont;
	private Label borrowBkTitle;
	private Button borrowBkCloseBtn;
	private Label borrowBkMbrIdLbl;
	private TextBox borrowBkMbrIdInp;
	private Label borrowBkBkIdLbl;
	private TextBox borrowBkBkIdInp;
	private Label borrowBkBrwDateLbl;
	private DateTimePicker borrowBkBrwDateInp;
	private Label borrowBkRtnDateLbl;
	private DateTimePicker borrowBkRtnDateInp;
	private Label borrowBkDueDateLbl;
	private DateTimePicker borrowBkDueDateInp;
	private Label borrowBkBkStatusLbl;
	private TextBox borrowBkBkStatusInp;
	private Button borrowBkBrwBtn;

	private DataGridView borrowBkGridView;
	private Label borrowBkGridTitle;


    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "Borrow Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;



	brwHeader = new Panel();
	brwHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(brwHeader);

	brwMainTitle = new Label();
	brwMainTitle.Text = "Cruise Library Management System";
	brwMainTitle.ForeColor = Color.White;
	brwMainTitle.BackColor = Color.Transparent;
	brwMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	brwHeader.Controls.Add(brwMainTitle);

	brwPgeTitle = new Label();
	brwPgeTitle.Text = "BORROW PAGE";
	brwPgeTitle.ForeColor = Color.Brown;
	brwPgeTitle.BackColor = Color.Transparent;
	brwPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	brwHeader.Controls.Add(brwPgeTitle);

	brwLogo = new PictureBox();
	brwLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	brwHeader.Controls.Add(brwLogo);

	brwSideNav = new Panel();
	brwSideNav.BackColor = Color.White;
	brwSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(brwSideNav);

	brwSnvTitle = new Label();
	brwSnvTitle.Text = "Navigation";
	brwSnvTitle.BackColor = Color.CornflowerBlue;
	brwSnvTitle.ForeColor = Color.White;
	brwSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	brwSideNav.Controls.Add(brwSnvTitle);

	brwSnvBkMgt =  new Label();
	brwSnvBkMgt.Text = "Book Management";
	brwSnvBkMgt.ForeColor = Color.Blue;
	brwSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvBkMgt.Click += new EventHandler(brwSnvBkMgt_Clicked);
	brwSnvBkMgt.Cursor = Cursors.Hand;
	brwSnvBkMgt.MouseEnter += new EventHandler(brwSnvBkMgt_MouseEnter);
	brwSnvBkMgt.MouseLeave += new EventHandler(brwSnvBkMgt_MouseLeave);
	brwSideNav.Controls.Add(brwSnvBkMgt);

	brwSnvMbrMgt =  new Label();
	brwSnvMbrMgt.Text = "Member Management";
	brwSnvMbrMgt.ForeColor = Color.Blue;
	brwSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvMbrMgt.Click += new EventHandler(brwSnvMbrMgt_Clicked);
	brwSnvMbrMgt.Cursor = Cursors.Hand;
	brwSnvMbrMgt.MouseEnter += new EventHandler(brwSnvMbrMgt_MouseEnter);
	brwSnvMbrMgt.MouseLeave += new EventHandler(brwSnvMbrMgt_MouseLeave);
	brwSideNav.Controls.Add(brwSnvMbrMgt);

	brwSnvDshBrd =  new Label();
	brwSnvDshBrd.Text = "Dashboard";
	brwSnvDshBrd.ForeColor = Color.Blue;
	brwSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvDshBrd.Click += new EventHandler(brwSnvDshBrd_Clicked);
	brwSnvDshBrd.Cursor = Cursors.Hand;
	brwSnvDshBrd.MouseEnter += new EventHandler(brwSnvDshBrd_MouseEnter);
	brwSnvDshBrd.MouseLeave += new EventHandler(brwSnvDshBrd_MouseLeave);
	brwSideNav.Controls.Add(brwSnvDshBrd);

	brwSnvRtn =  new Label();
	brwSnvRtn.Text = "Return Book";
	brwSnvRtn.ForeColor = Color.Blue;
	brwSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvRtn.Click += new EventHandler(brwSnvRtn_Clicked);
	brwSnvRtn.Cursor = Cursors.Hand;
	brwSnvRtn.MouseEnter += new EventHandler(brwSnvRtn_MouseEnter);
	brwSnvRtn.MouseLeave += new EventHandler(brwSnvRtn_MouseLeave);
	brwSideNav.Controls.Add(brwSnvRtn);

	brwSnvRpt =  new Label();
	brwSnvRpt.Text = "Reports";
	brwSnvRpt.ForeColor = Color.Blue;
	brwSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvRpt.Click += new EventHandler(brwSnvRpt_Clicked);
	brwSnvRpt.Cursor = Cursors.Hand;
	brwSnvRpt.MouseEnter += new EventHandler(brwSnvRpt_MouseEnter);
	brwSnvRpt.MouseLeave += new EventHandler(brwSnvRpt_MouseLeave);
	brwSideNav.Controls.Add(brwSnvRpt);

	brwSnvUsrStg =  new Label();
	brwSnvUsrStg.Text = "User Setting";
	brwSnvUsrStg.ForeColor = Color.Blue;
	brwSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvUsrStg.Click += new EventHandler(brwSnvUsrStg_Clicked);
	brwSnvUsrStg.Cursor = Cursors.Hand;
	brwSnvUsrStg.MouseEnter += new EventHandler(brwSnvUsrStg_MouseEnter);
	brwSnvUsrStg.MouseLeave += new EventHandler(brwSnvUsrStg_MouseLeave);
	brwSideNav.Controls.Add(brwSnvUsrStg);

	brwSnvSrch =  new Label();
	brwSnvSrch.Text = "Search";
	brwSnvSrch.ForeColor = Color.Blue;
	brwSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	brwSnvSrch.Click += new EventHandler(brwSnvSrch_Clicked);
	brwSnvSrch.Cursor = Cursors.Hand;
	brwSnvSrch.MouseEnter += new EventHandler(brwSnvSrch_MouseEnter);
	brwSnvSrch.MouseLeave += new EventHandler(brwSnvSrch_MouseLeave);
	brwSideNav.Controls.Add(brwSnvSrch);

	brwMainCont = new Panel();
	brwMainCont.BackColor = Color.White;
	this.Controls.Add(brwMainCont);

	brwMainContTitle = new Label();
	brwMainContTitle.Text = "BORROW BOOKS";
	brwMainContTitle.ForeColor = Color.Brown;
	brwMainCont.Controls.Add(brwMainContTitle);
	
	brwMainMbrNmLbl = new Label();
	brwMainMbrNmLbl.Text = "Member Name:";
	brwMainMbrNmLbl.ForeColor = Color.DarkSlateGray;
	brwMainCont.Controls.Add(brwMainMbrNmLbl);

	brwMainMbrNmInp = new TextBox();
	brwMainMbrNmInp.BackColor = Color.LightGray;
	brwMainCont.Controls.Add(brwMainMbrNmInp);

	brwMainBkrNmLbl = new Label();
	brwMainBkrNmLbl.Text = "Book Name:";
	brwMainBkrNmLbl.ForeColor = Color.DarkSlateGray;
	brwMainCont.Controls.Add(brwMainBkrNmLbl);

	brwMainBkrNmInp = new TextBox();
	brwMainBkrNmInp.BackColor = Color.LightGray;
	brwMainCont.Controls.Add(brwMainBkrNmInp);

	brwMainBkMbrCheckBtn = new Button();
	brwMainBkMbrCheckBtn.Text = "CHECK";
	brwMainBkMbrCheckBtn.BackColor = Color.LightGreen;
	brwMainBkMbrCheckBtn.Click += new EventHandler(brwMainBkMbrCheckBtn_Clicked);
	brwMainCont.Controls.Add(brwMainBkMbrCheckBtn);

	borrowBkCont = new Panel();
	borrowBkCont.BackColor = Color.Aquamarine;
	borrowBkCont.BorderStyle = BorderStyle.FixedSingle;
	this.Controls.Add(borrowBkCont);
	this.Controls.SetChildIndex(borrowBkCont,0);

	borrowBkTitle = new Label();
	borrowBkTitle.Text = "Complete Borrowing";
	borrowBkCont.Controls.Add(borrowBkTitle);

	borrowBkCloseBtn = new Button();
	borrowBkCloseBtn.Text = "X";
	borrowBkCloseBtn.ForeColor = Color.Red;
	borrowBkCloseBtn.Click += new EventHandler(borrowBkCloseBtn_Clicked);
	borrowBkCont.Controls.Add(borrowBkCloseBtn);

	borrowBkMbrIdLbl = new Label();
	borrowBkMbrIdLbl.Text = "Member ID:";
	borrowBkMbrIdLbl.ForeColor = Color.DarkSlateGray;
	borrowBkCont.Controls.Add(borrowBkMbrIdLbl);

	borrowBkMbrIdInp = new TextBox();
	borrowBkMbrIdInp.ReadOnly = true;
	borrowBkMbrIdInp.BackColor = Color.LightGray;
	borrowBkMbrIdInp.ForeColor = Color.Gray;
	borrowBkCont.Controls.Add(borrowBkMbrIdInp);

	borrowBkBkIdLbl = new Label();
	borrowBkBkIdLbl.Text = "Book ID:";
	borrowBkBkIdLbl.ForeColor = Color.DarkSlateGray;
	borrowBkCont.Controls.Add(borrowBkBkIdLbl);

	borrowBkBkIdInp = new TextBox();
	borrowBkBkIdInp.ReadOnly = true;
	borrowBkBkIdInp.BackColor = Color.LightGray;
	borrowBkBkIdInp.ForeColor = Color.Gray;
	borrowBkCont.Controls.Add(borrowBkBkIdInp);

	borrowBkBrwDateLbl = new Label();
	borrowBkBrwDateLbl.Text = "Borrow Date:";
	borrowBkBrwDateLbl.ForeColor = Color.DarkSlateGray;
	borrowBkCont.Controls.Add(borrowBkBrwDateLbl);

	borrowBkBrwDateInp = new DateTimePicker();
	borrowBkBrwDateInp.Format = DateTimePickerFormat.Short;
	borrowBkCont.Controls.Add(borrowBkBrwDateInp);

	borrowBkRtnDateLbl = new Label();
	borrowBkRtnDateLbl.Text = "Return Date:";
	borrowBkRtnDateLbl.ForeColor = Color.DarkSlateGray;
	borrowBkCont.Controls.Add(borrowBkRtnDateLbl);

	borrowBkRtnDateInp = new DateTimePicker();
	borrowBkRtnDateInp.Format = DateTimePickerFormat.Short;
	borrowBkCont.Controls.Add(borrowBkRtnDateInp);

	borrowBkDueDateLbl = new Label();
	borrowBkDueDateLbl.Text = "Due Date:";
	borrowBkDueDateLbl.ForeColor = Color.DarkSlateGray;
	borrowBkCont.Controls.Add(borrowBkDueDateLbl);

	borrowBkDueDateInp = new DateTimePicker();
	borrowBkDueDateInp.Format = DateTimePickerFormat.Short;
	borrowBkCont.Controls.Add(borrowBkDueDateInp);

	borrowBkBkStatusLbl = new Label();
	borrowBkBkStatusLbl.Text = "Status:";
	borrowBkBkStatusLbl.ForeColor = Color.DarkSlateGray;
	borrowBkCont.Controls.Add(borrowBkBkStatusLbl);

	borrowBkBkStatusInp = new TextBox();
	borrowBkBkStatusInp.ReadOnly = true;
	borrowBkBkStatusInp.BackColor = Color.LightGray;
	borrowBkBkStatusInp.ForeColor = Color.Gray;
	borrowBkBkStatusInp.Text = "active";
	borrowBkCont.Controls.Add(borrowBkBkStatusInp);	

	borrowBkBrwBtn = new Button();
	borrowBkBrwBtn.Text = "BORROW";
	borrowBkBrwBtn.BackColor = Color.Green;
	borrowBkBrwBtn.Click += new EventHandler(borrowBkBrwBtn_Clicked);
	borrowBkCont.Controls.Add(borrowBkBrwBtn);

	borrowBkGridTitle = new Label();
	borrowBkGridTitle.Text = "Transaction Records";
	borrowBkGridTitle.ForeColor = Color.Blue;
	brwMainCont.Controls.Add(borrowBkGridTitle);

	borrowBkGridView = new DataGridView();
	borrowBkGridView.ReadOnly = true;
	brwMainCont.Controls.Add(borrowBkGridView);

    }

    #endregion
}
