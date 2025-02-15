namespace MiniProjectApp;

partial class BookmanagementPage
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


	private Panel bkMgtHeader;
	private Label bkMgtMainTitle;
	private PictureBox bkMgtLogo;
	private Label bkMgtPgeTitle;

	private Panel bkMgtSideNav;
	private Label bkMgtSnvTitle;
	private Panel bkMgtMainCont;
	private Label bkMgtSnvDshBrd;
	private Label bkMgtSnvMbrMgt;
	private Label bkMgtSnvBrw;
	private Label bkMgtSnvRtn;
	private Label bkMgtSnvRpt;
	private Label bkMgtSnvUsrStg;
	private Label bkMgtSnvSrch;

	private Label bkMgtMainCntTitle;
	private DataGridView bkMgtGridView;
	private Button bkMgtAddBtn;
	private Panel addBkCont;
	private Label addBkTitle;
	private Button addBkCloseBtn;
	private Label addBkBkTitle;
	private TextBox addBkBkTitleVal;
	private Label addBkBkAuthor;
	private TextBox addBkBkAuthorVal;
	private Label addBkBkIsbn;
	private TextBox addBkBkIsbnVal;
	private Label addBkBkPubYr;
	private TextBox addBkBkPubYrVal;
	private Label addBkBkCatgry;
	private TextBox addBkBkCatgryVal;
	private Label addBkBkStatus;
	private ComboBox addBkBkStatusVal;
	private Button addBkAddBtn;


    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "Book Management Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;



	bkMgtHeader = new Panel();
	bkMgtHeader.BackColor = Color.YellowGreen;
	bkMgtHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(bkMgtHeader);

	bkMgtMainTitle = new Label();
	bkMgtMainTitle.Text = "Cruise Library Management System";
	bkMgtMainTitle.ForeColor = Color.White;
	bkMgtMainTitle.BackColor = Color.Transparent;
	bkMgtMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtHeader.Controls.Add(bkMgtMainTitle);

	bkMgtPgeTitle = new Label();
	bkMgtPgeTitle.Text = "BOOK MANAGEMENT";
	bkMgtPgeTitle.ForeColor = Color.Brown;
	bkMgtPgeTitle.BackColor = Color.Transparent;
	bkMgtPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtHeader.Controls.Add(bkMgtPgeTitle);

	bkMgtLogo = new PictureBox();
	bkMgtLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	bkMgtHeader.Controls.Add(bkMgtLogo);
	
	bkMgtSideNav = new Panel();
	bkMgtSideNav.BackColor = Color.White;
	bkMgtSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(bkMgtSideNav);

	bkMgtSnvTitle = new Label();
	bkMgtSnvTitle.Text = "Navigation";
	bkMgtSnvTitle.BackColor = Color.CornflowerBlue;
	bkMgtSnvTitle.ForeColor = Color.White;
	bkMgtSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSideNav.Controls.Add(bkMgtSnvTitle);

	bkMgtSnvDshBrd =  new Label();
	bkMgtSnvDshBrd.Text = "Dashboard";
	bkMgtSnvDshBrd.ForeColor = Color.Blue;
	bkMgtSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvDshBrd.Click += new EventHandler(bkMgtSnvDshBrd_Clicked);
	bkMgtSnvDshBrd.Cursor = Cursors.Hand;
	bkMgtSnvDshBrd.MouseEnter += new EventHandler(bkMgtSnvDshBrd_MouseEnter);
	bkMgtSnvDshBrd.MouseLeave += new EventHandler(bkMgtSnvDshBrd_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvDshBrd);

	bkMgtSnvMbrMgt =  new Label();
	bkMgtSnvMbrMgt.Text = "Member Management";
	bkMgtSnvMbrMgt.ForeColor = Color.Blue;
	bkMgtSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvMbrMgt.Click += new EventHandler(bkMgtSnvMbrMgt_Clicked);
	bkMgtSnvMbrMgt.Cursor = Cursors.Hand;
	bkMgtSnvMbrMgt.MouseEnter += new EventHandler(bkMgtSnvMbrMgt_MouseEnter);
	bkMgtSnvMbrMgt.MouseLeave += new EventHandler(bkMgtSnvMbrMgt_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvMbrMgt);

	bkMgtSnvBrw =  new Label();
	bkMgtSnvBrw.Text = "Borrow Book";
	bkMgtSnvBrw.ForeColor = Color.Blue;
	bkMgtSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvBrw.Click += new EventHandler(bkMgtSnvBrw_Clicked);
	bkMgtSnvBrw.Cursor = Cursors.Hand;
	bkMgtSnvBrw.MouseEnter += new EventHandler(bkMgtSnvBrw_MouseEnter);
	bkMgtSnvBrw.MouseLeave += new EventHandler(bkMgtSnvBrw_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvBrw);

	bkMgtSnvRtn =  new Label();
	bkMgtSnvRtn.Text = "Return Book";
	bkMgtSnvRtn.ForeColor = Color.Blue;
	bkMgtSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvRtn.Click += new EventHandler(bkMgtSnvRtn_Clicked);
	bkMgtSnvRtn.Cursor = Cursors.Hand;
	bkMgtSnvRtn.MouseEnter += new EventHandler(bkMgtSnvRtn_MouseEnter);
	bkMgtSnvRtn.MouseLeave += new EventHandler(bkMgtSnvRtn_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvRtn);

	bkMgtSnvRpt =  new Label();
	bkMgtSnvRpt.Text = "Reports";
	bkMgtSnvRpt.ForeColor = Color.Blue;
	bkMgtSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvRpt.Click += new EventHandler(bkMgtSnvRpt_Clicked);
	bkMgtSnvRpt.Cursor = Cursors.Hand;
	bkMgtSnvRpt.MouseEnter += new EventHandler(bkMgtSnvRpt_MouseEnter);
	bkMgtSnvRpt.MouseLeave += new EventHandler(bkMgtSnvRpt_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvRpt);

	bkMgtSnvUsrStg =  new Label();
	bkMgtSnvUsrStg.Text = "User Setting";
	bkMgtSnvUsrStg.ForeColor = Color.Blue;
	bkMgtSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvUsrStg.Click += new EventHandler(bkMgtSnvUsrStg_Clicked);
	bkMgtSnvUsrStg.Cursor = Cursors.Hand;
	bkMgtSnvUsrStg.MouseEnter += new EventHandler(bkMgtSnvUsrStg_MouseEnter);
	bkMgtSnvUsrStg.MouseLeave += new EventHandler(bkMgtSnvUsrStg_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvUsrStg);

	bkMgtSnvSrch =  new Label();
	bkMgtSnvSrch.Text = "Search";
	bkMgtSnvSrch.ForeColor = Color.Blue;
	bkMgtSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	bkMgtSnvSrch.Click += new EventHandler(bkMgtSnvSrch_Clicked);
	bkMgtSnvSrch.Cursor = Cursors.Hand;
	bkMgtSnvSrch.MouseEnter += new EventHandler(bkMgtSnvSrch_MouseEnter);
	bkMgtSnvSrch.MouseLeave += new EventHandler(bkMgtSnvSrch_MouseLeave);
	bkMgtSideNav.Controls.Add(bkMgtSnvSrch);

	bkMgtMainCont = new Panel();
	bkMgtMainCont.BackColor = Color.White;
	this.Controls.Add(bkMgtMainCont);

	bkMgtMainCntTitle = new Label();
	bkMgtMainCntTitle.Text = "MANAGE BOOKS";
	bkMgtMainCntTitle.ForeColor = Color.Brown;
	bkMgtMainCont.Controls.Add(bkMgtMainCntTitle);

	bkMgtGridView = new DataGridView();
	bkMgtMainCont.Controls.Add(bkMgtGridView);

	bkMgtAddBtn = new Button();
	bkMgtAddBtn.Text = "ADD BOOK";
	bkMgtAddBtn.BackColor = Color.Yellow;
	bkMgtAddBtn.Click += new EventHandler(bkMgtAddBtn_Clicked);
	bkMgtMainCont.Controls.Add(bkMgtAddBtn);

	addBkCont = new Panel();
	addBkCont.BackColor = Color.Aquamarine;
	addBkCont.BorderStyle = BorderStyle.FixedSingle;
	this.Controls.Add(addBkCont);
	this.Controls.SetChildIndex(addBkCont,0);

	addBkTitle = new Label();
	addBkTitle.Text = "Add New Book";
	addBkCont.Controls.Add(addBkTitle);

	addBkCloseBtn = new Button();
	addBkCloseBtn.Text = "X";
	addBkCloseBtn.ForeColor = Color.Red;
	addBkCloseBtn.Click += new EventHandler(addBkCloseBtn_Clicked);
	addBkCont.Controls.Add(addBkCloseBtn);

	addBkBkTitle = new Label();
	addBkBkTitle.Text = "Title:";
	addBkBkTitle.ForeColor = Color.DarkSlateGray;
	addBkCont.Controls.Add(addBkBkTitle);

	addBkBkTitleVal = new TextBox();
	addBkCont.Controls.Add(addBkBkTitleVal);

	addBkBkAuthor = new Label();
	addBkBkAuthor.Text = "Author:";
	addBkBkAuthor.ForeColor = Color.DarkSlateGray;
	addBkCont.Controls.Add(addBkBkAuthor);

	addBkBkAuthorVal = new TextBox();
	addBkCont.Controls.Add(addBkBkAuthorVal);

	addBkBkIsbn = new Label();
	addBkBkIsbn.Text = "Isbn:";
	addBkBkIsbn.ForeColor = Color.DarkSlateGray;
	addBkCont.Controls.Add(addBkBkIsbn);

	addBkBkIsbnVal = new TextBox();
	addBkCont.Controls.Add(addBkBkIsbnVal);

	addBkBkPubYr = new Label();
	addBkBkPubYr.Text = "Publication Year:";
	addBkBkPubYr.ForeColor = Color.DarkSlateGray;
	addBkCont.Controls.Add(addBkBkPubYr);

	addBkBkPubYrVal = new TextBox();
	addBkCont.Controls.Add(addBkBkPubYrVal);

	addBkBkCatgry = new Label();
	addBkBkCatgry.Text = "Category:";
	addBkBkCatgry.ForeColor = Color.DarkSlateGray;
	addBkCont.Controls.Add(addBkBkCatgry);

	addBkBkCatgryVal = new TextBox();
	addBkCont.Controls.Add(addBkBkCatgryVal);

	addBkBkStatus = new Label();
	addBkBkStatus.Text = "Status:";
	addBkBkStatus.ForeColor = Color.DarkSlateGray;
	addBkCont.Controls.Add(addBkBkStatus);

	addBkBkStatusVal = new ComboBox();
	addBkBkStatusVal.Items.Add("available");
	addBkBkStatusVal.Items.Add("borrowed");
	addBkBkStatusVal.Items.Add("reserved");
	addBkCont.Controls.Add(addBkBkStatusVal);

	addBkAddBtn = new Button();
	addBkAddBtn.Text = "ADD BOOK";
	addBkAddBtn.BackColor = Color.Green;
	addBkAddBtn.Click += new EventHandler(addBkAddBtn_Clicked);
	addBkCont.Controls.Add(addBkAddBtn);

    }

    #endregion
}
