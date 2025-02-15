namespace MiniProjectApp;

partial class ReportsPage
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


	private Panel rptsHeader;
	private Label rptsMainTitle;

	private Panel rptsSideNav;
	private Label rptsSnvTitle;
	private Panel rptsMainCont;
	private Label rptsSnvBkMgt;
	private Label rptsSnvMbrMgt;
	private Label rptsSnvBrw;
	private Label rptsSnvRtn;
	private Label rptsSnvDshBrd;
	private Label rptsSnvUsrStg;
	private Label rptsSnvSrch;
	private Label rptsPgeTitle;
	private PictureBox rptsLogo;

	private Label rptsMainContTitle;
	private Label chseRptTypeLbl;
	private ListBox chseRptTypeInp;
	private Button chseRptTypeBtn;
	private Label chseRptFilterLbl;
	private ListBox chseRptFilterInp;
	private Button chseRptFilterBtn;
	private Button generateRptBtn;

	private Panel rptResultCont;
	private Button rptResultCloseBtn;
	private Label rptResultMainTitle;
	private Label rptResultCountLbl;
	private Label rptResultCountVal;
	private Label rptResultCatTitle;
	private DataGridView rptResultGridview;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "Reports Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;

	

	rptsHeader = new Panel();
	rptsHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(rptsHeader);

	rptsMainTitle = new Label();
	rptsMainTitle.Text = "Cruise Library Management System";
	rptsMainTitle.ForeColor = Color.White;
	rptsMainTitle.BackColor = Color.Transparent;
	rptsMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	rptsHeader.Controls.Add(rptsMainTitle);

	rptsPgeTitle = new Label();
	rptsPgeTitle.Text = "REPORTS PAGE";
	rptsPgeTitle.ForeColor = Color.Brown;
	rptsPgeTitle.BackColor = Color.Transparent;
	rptsPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	rptsHeader.Controls.Add(rptsPgeTitle);

	rptsLogo = new PictureBox();
	rptsLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	rptsHeader.Controls.Add(rptsLogo);

	rptsSideNav = new Panel();
	rptsSideNav.BackColor = Color.White;
	rptsSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(rptsSideNav);

	rptsSnvTitle = new Label();
	rptsSnvTitle.Text = "Navigation";
	rptsSnvTitle.BackColor = Color.CornflowerBlue;
	rptsSnvTitle.ForeColor = Color.White;
	rptsSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	rptsSideNav.Controls.Add(rptsSnvTitle);

	rptsSnvBkMgt =  new Label();
	rptsSnvBkMgt.Text = "Book Management";
	rptsSnvBkMgt.ForeColor = Color.Blue;
	rptsSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvBkMgt.Click += new EventHandler(rptsSnvBkMgt_Clicked);
	rptsSnvBkMgt.Cursor = Cursors.Hand;
	rptsSnvBkMgt.MouseEnter += new EventHandler(rptsSnvBkMgt_MouseEnter);
	rptsSnvBkMgt.MouseLeave += new EventHandler(rptsSnvBkMgt_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvBkMgt);

	rptsSnvMbrMgt =  new Label();
	rptsSnvMbrMgt.Text = "Member Management";
	rptsSnvMbrMgt.ForeColor = Color.Blue;
	rptsSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvMbrMgt.Click += new EventHandler(rptsSnvMbrMgt_Clicked);
	rptsSnvMbrMgt.Cursor = Cursors.Hand;
	rptsSnvMbrMgt.MouseEnter += new EventHandler(rptsSnvMbrMgt_MouseEnter);
	rptsSnvMbrMgt.MouseLeave += new EventHandler(rptsSnvMbrMgt_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvMbrMgt);

	rptsSnvBrw =  new Label();
	rptsSnvBrw.Text = "Borrow Book";
	rptsSnvBrw.ForeColor = Color.Blue;
	rptsSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvBrw.Click += new EventHandler(rptsSnvBrw_Clicked);
	rptsSnvBrw.Cursor = Cursors.Hand;
	rptsSnvBrw.MouseEnter += new EventHandler(rptsSnvBrw_MouseEnter);
	rptsSnvBrw.MouseLeave += new EventHandler(rptsSnvBrw_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvBrw);

	rptsSnvRtn =  new Label();
	rptsSnvRtn.Text = "Return Book";
	rptsSnvRtn.ForeColor = Color.Blue;
	rptsSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvRtn.Click += new EventHandler(rptsSnvRtn_Clicked);
	rptsSnvRtn.Cursor = Cursors.Hand;
	rptsSnvRtn.MouseEnter += new EventHandler(rptsSnvRtn_MouseEnter);
	rptsSnvRtn.MouseLeave += new EventHandler(rptsSnvRtn_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvRtn);

	rptsSnvDshBrd =  new Label();
	rptsSnvDshBrd.Text = "Dashboard";
	rptsSnvDshBrd.ForeColor = Color.Blue;
	rptsSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvDshBrd.Click += new EventHandler(rptsSnvDshBrd_Clicked);
	rptsSnvDshBrd.Cursor = Cursors.Hand;
	rptsSnvDshBrd.MouseEnter += new EventHandler(rptsSnvDshBrd_MouseEnter);
	rptsSnvDshBrd.MouseLeave += new EventHandler(rptsSnvDshBrd_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvDshBrd);

	rptsSnvUsrStg =  new Label();
	rptsSnvUsrStg.Text = "User Setting";
	rptsSnvUsrStg.ForeColor = Color.Blue;
	rptsSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvUsrStg.Click += new EventHandler(rptsSnvUsrStg_Clicked);
	rptsSnvUsrStg.Cursor = Cursors.Hand;
	rptsSnvUsrStg.MouseEnter += new EventHandler(rptsSnvUsrStg_MouseEnter);
	rptsSnvUsrStg.MouseLeave += new EventHandler(rptsSnvUsrStg_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvUsrStg);

	rptsSnvSrch =  new Label();
	rptsSnvSrch.Text = "Search";
	rptsSnvSrch.ForeColor = Color.Blue;
	rptsSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	rptsSnvSrch.Click += new EventHandler(rptsSnvSrch_Clicked);
	rptsSnvSrch.Cursor = Cursors.Hand;
	rptsSnvSrch.MouseEnter += new EventHandler(rptsSnvSrch_MouseEnter);
	rptsSnvSrch.MouseLeave += new EventHandler(rptsSnvSrch_MouseLeave);
	rptsSideNav.Controls.Add(rptsSnvSrch);

	rptsMainCont = new Panel();
	rptsMainCont.BackColor = Color.White;
	this.Controls.Add(rptsMainCont);

	rptsMainContTitle = new Label();
	rptsMainContTitle.Text = "GENERATE REPORTS";
	rptsMainContTitle.ForeColor = Color.Brown;
	rptsMainCont.Controls.Add(rptsMainContTitle);

	chseRptTypeLbl = new Label();
	chseRptTypeLbl.Text = "Select Report Type:";
	chseRptTypeLbl.ForeColor = Color.DarkSlateGray;
	rptsMainCont.Controls.Add(chseRptTypeLbl);

	chseRptTypeInp = new ListBox();
	chseRptTypeInp.Items.Add("Member Report");
	chseRptTypeInp.Items.Add("Book Report");
	chseRptTypeInp.Items.Add("Transaction Report");
	chseRptTypeInp.Items.Add("Special Report");
	rptsMainCont.Controls.Add(chseRptTypeInp);

	chseRptTypeBtn = new Button();
	chseRptTypeBtn.Text = "SELECT";
	chseRptTypeBtn.BackColor = Color.LightGreen;
	chseRptTypeBtn.Click += new EventHandler(chseRptTypeBtn_Clicked);
	rptsMainCont.Controls.Add(chseRptTypeBtn);

	chseRptFilterLbl = new Label();
	chseRptFilterLbl.Text = "Select Filter:";
	chseRptFilterLbl.ForeColor = Color.DarkSlateGray;
	chseRptFilterLbl.Hide();
	rptsMainCont.Controls.Add(chseRptFilterLbl);

	chseRptFilterInp = new ListBox();
	chseRptFilterInp.Hide();
	rptsMainCont.Controls.Add(chseRptFilterInp);

	chseRptFilterBtn = new Button();
	chseRptFilterBtn.Text = "SELECT";
	chseRptFilterBtn.BackColor = Color.LightGreen;
	chseRptFilterBtn.Click += new EventHandler(chseRptFilterBtn_Clicked);
	chseRptFilterBtn.Hide();
	rptsMainCont.Controls.Add(chseRptFilterBtn);

	generateRptBtn = new Button();
	generateRptBtn.Text = "GENERATE REPORT";
	generateRptBtn.BackColor = Color.Green;
	generateRptBtn.ForeColor = Color.White;
	generateRptBtn.Cursor = Cursors.Hand;
	generateRptBtn.Hide();
	generateRptBtn.Click += new EventHandler(generateRptBtn_Clicked);
	rptsMainCont.Controls.Add(generateRptBtn);

	rptResultCont = new Panel();
	rptResultCont.BackColor = Color.Aquamarine;
	rptResultCont.BorderStyle = BorderStyle.FixedSingle;
	rptResultCont.Hide();
	this.Controls.Add(rptResultCont);
	this.Controls.SetChildIndex(rptResultCont,0);

	rptResultCloseBtn = new Button();
	rptResultCloseBtn.Text = "X";
	rptResultCloseBtn.ForeColor = Color.Red;
	rptResultCloseBtn.Cursor = Cursors.Hand;
	rptResultCloseBtn.Click += new EventHandler(rptResultCloseBtn_Clicked);
	rptResultCont.Controls.Add(rptResultCloseBtn);

	rptResultMainTitle = new Label();
	rptResultMainTitle.Text = "REPORT RESULTS";
	rptResultCont.Controls.Add(rptResultMainTitle);

	rptResultCountLbl = new Label();
	rptResultCountLbl.Text = "Total Count: ";
	rptResultCont.Controls.Add(rptResultCountLbl);

	rptResultCountVal = new Label();
	rptResultCountVal.ForeColor = Color.CornflowerBlue;
	rptResultCont.Controls.Add(rptResultCountVal);

	rptResultCatTitle = new Label();
	rptResultCatTitle.ForeColor = Color.Blue;
	rptResultCont.Controls.Add(rptResultCatTitle);

	rptResultGridview = new DataGridView();
	rptResultGridview.ReadOnly = true;
	rptResultCont.Controls.Add(rptResultGridview);

    }

    #endregion
}
