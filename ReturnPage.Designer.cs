namespace MiniProjectApp;

partial class ReturnPage
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


	private Panel rtnHeader;
	private Label rtnMainTitle;

	private Panel rtnSideNav;
	private Label rtnSnvTitle;
	private Panel rtnMainCont;
	private Label rtnSnvBkMgt;
	private Label rtnSnvMbrMgt;
	private Label rtnSnvBrw;
	private Label rtnSnvDshBrd;
	private Label rtnSnvRpt;
	private Label rtnSnvUsrStg;
	private Label rtnSnvSrch;
	private Label rtnPgeTitle;
	private PictureBox rtnLogo;

	private Label rtnMainContTitle;
	private Label rtnBkMbrNmLbl;
	private TextBox rtnBkMbrNmInp;
	private Button rtnBkListBtn;
	private Label mbrBorrowedBksListTitle;
	private Label mbrBorrowListMsg;
	private DataGridView rtnBookGridView;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "Return Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;

	

	rtnHeader = new Panel();
	rtnHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(rtnHeader);

	rtnMainTitle = new Label();
	rtnMainTitle.Text = "Cruise Library Management System";
	rtnMainTitle.ForeColor = Color.White;
	rtnMainTitle.BackColor = Color.Transparent;
	rtnMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	rtnHeader.Controls.Add(rtnMainTitle);

	rtnPgeTitle = new Label();
	rtnPgeTitle.Text = "RETURN PAGE";
	rtnPgeTitle.ForeColor = Color.Brown;
	rtnPgeTitle.BackColor = Color.Transparent;
	rtnPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	rtnHeader.Controls.Add(rtnPgeTitle);

	rtnLogo = new PictureBox();
	rtnLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	rtnHeader.Controls.Add(rtnLogo);

	rtnSideNav = new Panel();
	rtnSideNav.BackColor = Color.White;
	rtnSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(rtnSideNav);

	rtnSnvTitle = new Label();
	rtnSnvTitle.Text = "Navigation";
	rtnSnvTitle.BackColor = Color.CornflowerBlue;
	rtnSnvTitle.ForeColor = Color.White;
	rtnSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	rtnSideNav.Controls.Add(rtnSnvTitle);

	rtnSnvBkMgt =  new Label();
	rtnSnvBkMgt.Text = "Book Management";
	rtnSnvBkMgt.ForeColor = Color.Blue;
	rtnSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvBkMgt.Click += new EventHandler(rtnSnvBkMgt_Clicked);
	rtnSnvBkMgt.Cursor = Cursors.Hand;
	rtnSnvBkMgt.MouseEnter += new EventHandler(rtnSnvBkMgt_MouseEnter);
	rtnSnvBkMgt.MouseLeave += new EventHandler(rtnSnvBkMgt_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvBkMgt);

	rtnSnvMbrMgt =  new Label();
	rtnSnvMbrMgt.Text = "Member Management";
	rtnSnvMbrMgt.ForeColor = Color.Blue;
	rtnSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvMbrMgt.Click += new EventHandler(rtnSnvMbrMgt_Clicked);
	rtnSnvMbrMgt.Cursor = Cursors.Hand;
	rtnSnvMbrMgt.MouseEnter += new EventHandler(rtnSnvMbrMgt_MouseEnter);
	rtnSnvMbrMgt.MouseLeave += new EventHandler(rtnSnvMbrMgt_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvMbrMgt);

	rtnSnvBrw =  new Label();
	rtnSnvBrw.Text = "Borrow Book";
	rtnSnvBrw.ForeColor = Color.Blue;
	rtnSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvBrw.Click += new EventHandler(rtnSnvBrw_Clicked);
	rtnSnvBrw.Cursor = Cursors.Hand;
	rtnSnvBrw.MouseEnter += new EventHandler(rtnSnvBrw_MouseEnter);
	rtnSnvBrw.MouseLeave += new EventHandler(rtnSnvBrw_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvBrw);

	rtnSnvDshBrd =  new Label();
	rtnSnvDshBrd.Text = "Dashboard";
	rtnSnvDshBrd.ForeColor = Color.Blue;
	rtnSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvDshBrd.Click += new EventHandler(rtnSnvDshBrd_Clicked);
	rtnSnvDshBrd.Cursor = Cursors.Hand;
	rtnSnvDshBrd.MouseEnter += new EventHandler(rtnSnvDshBrd_MouseEnter);
	rtnSnvDshBrd.MouseLeave += new EventHandler(rtnSnvDshBrd_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvDshBrd);

	rtnSnvRpt =  new Label();
	rtnSnvRpt.Text = "Reports";
	rtnSnvRpt.ForeColor = Color.Blue;
	rtnSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvRpt.Click += new EventHandler(rtnSnvRpt_Clicked);
	rtnSnvRpt.Cursor = Cursors.Hand;
	rtnSnvRpt.MouseEnter += new EventHandler(rtnSnvRpt_MouseEnter);
	rtnSnvRpt.MouseLeave += new EventHandler(rtnSnvRpt_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvRpt);

	rtnSnvUsrStg =  new Label();
	rtnSnvUsrStg.Text = "User Setting";
	rtnSnvUsrStg.ForeColor = Color.Blue;
	rtnSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvUsrStg.Click += new EventHandler(rtnSnvUsrStg_Clicked);
	rtnSnvUsrStg.Cursor = Cursors.Hand;
	rtnSnvUsrStg.MouseEnter += new EventHandler(rtnSnvUsrStg_MouseEnter);
	rtnSnvUsrStg.MouseLeave += new EventHandler(rtnSnvUsrStg_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvUsrStg);

	rtnSnvSrch =  new Label();
	rtnSnvSrch.Text = "Search";
	rtnSnvSrch.ForeColor = Color.Blue;
	rtnSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	rtnSnvSrch.Click += new EventHandler(rtnSnvSrch_Clicked);
	rtnSnvSrch.Cursor = Cursors.Hand;
	rtnSnvSrch.MouseEnter += new EventHandler(rtnSnvSrch_MouseEnter);
	rtnSnvSrch.MouseLeave += new EventHandler(rtnSnvSrch_MouseLeave);
	rtnSideNav.Controls.Add(rtnSnvSrch);

	rtnMainCont = new Panel();
	rtnMainCont.BackColor = Color.White;
	this.Controls.Add(rtnMainCont);

	rtnMainContTitle = new Label();
	rtnMainContTitle.Text = "RETURN BOOKS";
	rtnMainContTitle.ForeColor = Color.Brown;
	rtnMainCont.Controls.Add(rtnMainContTitle);

	rtnBkMbrNmLbl = new Label();
	rtnBkMbrNmLbl.Text = "Member Name:";
	rtnBkMbrNmLbl.ForeColor = Color.DarkSlateGray;
	rtnMainCont.Controls.Add(rtnBkMbrNmLbl);

	rtnBkMbrNmInp = new TextBox();
	rtnBkMbrNmInp.BackColor = Color.LightGray;
	rtnMainCont.Controls.Add(rtnBkMbrNmInp);
	
	rtnBkListBtn = new Button();
	rtnBkListBtn.Text = "LIST";
	rtnBkListBtn.BackColor = Color.LightGreen;
	rtnBkListBtn.Click += new EventHandler(rtnBkListBtn_Clicked);
	rtnMainCont.Controls.Add(rtnBkListBtn);

	mbrBorrowedBksListTitle = new Label();
	mbrBorrowedBksListTitle.ForeColor = Color.Blue;
	mbrBorrowedBksListTitle.Hide();
	rtnMainCont.Controls.Add(mbrBorrowedBksListTitle);

	mbrBorrowListMsg = new Label();
	mbrBorrowListMsg.Text = "To return book select row and press 'r' key";
	mbrBorrowListMsg.ForeColor = Color.Red;
	mbrBorrowListMsg.Hide();
	rtnMainCont.Controls.Add(mbrBorrowListMsg);

	rtnBookGridView = new DataGridView();
	rtnBookGridView.Hide();
	rtnBookGridView.ReadOnly = true;
	rtnMainCont.Controls.Add(rtnBookGridView);

    }

    #endregion
}
