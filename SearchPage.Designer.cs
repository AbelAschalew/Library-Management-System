namespace MiniProjectApp;

partial class SearchPage
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


	private Panel srchHeader;
	private Label srchMainTitle;

	private Panel srchSideNav;
	private Label srchSnvTitle;
	private Panel srchMainCont;
	private Label srchSnvBkMgt;
	private Label srchSnvMbrMgt;
	private Label srchSnvBrw;
	private Label srchSnvRtn;
	private Label srchSnvRpt;
	private Label srchSnvUsrStg;
	private Label srchSnvDshBrd;
	private Label srchPgeTitle;
	private PictureBox srchLogo;

	private Label srchMainCntTitle;
	private Label chseSrchResourceLbl;
	private ListBox chseSrchResourceInp;
	private Button chseSrchResourceBtn;
	private Label chseCriteriaMbrLbl;
	private ListBox chseCriteriaMbrInp;
	private Button chseCriteriaMbrBtn;
	private Label searchPhraseLbl;
	private TextBox searchPhraseInp;
	private Button searchBtn;

	private Panel srchResultCont;
	private Label srchResultTitle;
	private Button srchResultCloseBtn;
	private Label srchResultCatTitle;
	private DataGridView srchResultGridView;


    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "Search Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;

	

	srchHeader = new Panel();
	srchHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(srchHeader);

	srchMainTitle = new Label();
	srchMainTitle.Text = "Cruise Library Management System";
	srchMainTitle.ForeColor = Color.White;
	srchMainTitle.BackColor = Color.Transparent;
	srchMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	srchHeader.Controls.Add(srchMainTitle);

	srchPgeTitle = new Label();
	srchPgeTitle.Text = "SEARCH PAGE";
	srchPgeTitle.ForeColor = Color.Brown;
	srchPgeTitle.BackColor = Color.Transparent;
	srchPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	srchHeader.Controls.Add(srchPgeTitle);

	srchLogo = new PictureBox();
	srchLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	srchHeader.Controls.Add(srchLogo);

	srchSideNav = new Panel();
	srchSideNav.BackColor = Color.White;
	srchSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(srchSideNav);

	srchSnvTitle = new Label();
	srchSnvTitle.Text = "Navigation";
	srchSnvTitle.BackColor = Color.CornflowerBlue;
	srchSnvTitle.ForeColor = Color.White;
	srchSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	srchSideNav.Controls.Add(srchSnvTitle);

	srchSnvBkMgt =  new Label();
	srchSnvBkMgt.Text = "Book Management";
	srchSnvBkMgt.ForeColor = Color.Blue;
	srchSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvBkMgt.Click += new EventHandler(srchSnvBkMgt_Clicked);
	srchSnvBkMgt.Cursor = Cursors.Hand;
	srchSnvBkMgt.MouseEnter += new EventHandler(srchSnvBkMgt_MouseEnter);
	srchSnvBkMgt.MouseLeave += new EventHandler(srchSnvBkMgt_MouseLeave);
	srchSideNav.Controls.Add(srchSnvBkMgt);

	srchSnvMbrMgt =  new Label();
	srchSnvMbrMgt.Text = "Member Management";
	srchSnvMbrMgt.ForeColor = Color.Blue;
	srchSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvMbrMgt.Click += new EventHandler(srchSnvMbrMgt_Clicked);
	srchSnvMbrMgt.Cursor = Cursors.Hand;
	srchSnvMbrMgt.MouseEnter += new EventHandler(srchSnvMbrMgt_MouseEnter);
	srchSnvMbrMgt.MouseLeave += new EventHandler(srchSnvMbrMgt_MouseLeave);
	srchSideNav.Controls.Add(srchSnvMbrMgt);

	srchSnvBrw =  new Label();
	srchSnvBrw.Text = "Borrow Book";
	srchSnvBrw.ForeColor = Color.Blue;
	srchSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvBrw.Click += new EventHandler(srchSnvBrw_Clicked);
	srchSnvBrw.Cursor = Cursors.Hand;
	srchSnvBrw.MouseEnter += new EventHandler(srchSnvBrw_MouseEnter);
	srchSnvBrw.MouseLeave += new EventHandler(srchSnvBrw_MouseLeave);
	srchSideNav.Controls.Add(srchSnvBrw);

	srchSnvRtn =  new Label();
	srchSnvRtn.Text = "Return Book";
	srchSnvRtn.ForeColor = Color.Blue;
	srchSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvRtn.Click += new EventHandler(srchSnvRtn_Clicked);
	srchSnvRtn.Cursor = Cursors.Hand;
	srchSnvRtn.MouseEnter += new EventHandler(srchSnvRtn_MouseEnter);
	srchSnvRtn.MouseLeave += new EventHandler(srchSnvRtn_MouseLeave);
	srchSideNav.Controls.Add(srchSnvRtn);

	srchSnvRpt =  new Label();
	srchSnvRpt.Text = "Reports";
	srchSnvRpt.ForeColor = Color.Blue;
	srchSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvRpt.Click += new EventHandler(srchSnvRpt_Clicked);
	srchSnvRpt.Cursor = Cursors.Hand;
	srchSnvRpt.MouseEnter += new EventHandler(srchSnvRpt_MouseEnter);
	srchSnvRpt.MouseLeave += new EventHandler(srchSnvRpt_MouseLeave);
	srchSideNav.Controls.Add(srchSnvRpt);

	srchSnvUsrStg =  new Label();
	srchSnvUsrStg.Text = "User Setting";
	srchSnvUsrStg.ForeColor = Color.Blue;
	srchSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvUsrStg.Click += new EventHandler(srchSnvUsrStg_Clicked);
	srchSnvUsrStg.Cursor = Cursors.Hand;
	srchSnvUsrStg.MouseEnter += new EventHandler(srchSnvUsrStg_MouseEnter);
	srchSnvUsrStg.MouseLeave += new EventHandler(srchSnvUsrStg_MouseLeave);
	srchSideNav.Controls.Add(srchSnvUsrStg);

	srchSnvDshBrd =  new Label();
	srchSnvDshBrd.Text = "Dashboard";
	srchSnvDshBrd.ForeColor = Color.Blue;
	srchSnvDshBrd.TextAlign = ContentAlignment.MiddleCenter;
	srchSnvDshBrd.Click += new EventHandler(srchSnvDshBrd_Clicked);
	srchSnvDshBrd.Cursor = Cursors.Hand;
	srchSnvDshBrd.MouseEnter += new EventHandler(srchSnvDshBrd_MouseEnter);
	srchSnvDshBrd.MouseLeave += new EventHandler(srchSnvDshBrd_MouseLeave);
	srchSideNav.Controls.Add(srchSnvDshBrd);

	srchMainCont = new Panel();
	srchMainCont.BackColor = Color.White;
	this.Controls.Add(srchMainCont);

	srchMainCntTitle = new Label();
	srchMainCntTitle.Text = "SEARCH RESOURCES";
	srchMainCntTitle.ForeColor = Color.Brown;
	srchMainCont.Controls.Add(srchMainCntTitle);

	chseSrchResourceLbl = new Label();
	chseSrchResourceLbl.Text = "Select Category:";
	chseSrchResourceLbl.ForeColor = Color.DarkSlateGray;
	srchMainCont.Controls.Add(chseSrchResourceLbl);

	chseSrchResourceInp = new ListBox();
	chseSrchResourceInp.Items.Add("Member");
	chseSrchResourceInp.Items.Add("Book");
	chseSrchResourceInp.Items.Add("Transaction");
	srchMainCont.Controls.Add(chseSrchResourceInp);

	chseSrchResourceBtn = new Button();
	chseSrchResourceBtn.Text = "SELECT";
	chseSrchResourceBtn.BackColor = Color.LightGreen;
	chseSrchResourceBtn.Click += new EventHandler(chseSrchResourceBtn_Clicked);
	srchMainCont.Controls.Add(chseSrchResourceBtn);

	chseCriteriaMbrLbl = new Label();
	chseCriteriaMbrLbl.Text = "Select Criteria:";
	chseCriteriaMbrLbl.ForeColor = Color.DarkSlateGray;
	chseCriteriaMbrLbl.Hide();
	srchMainCont.Controls.Add(chseCriteriaMbrLbl);

	chseCriteriaMbrInp = new ListBox();
	chseCriteriaMbrInp.Hide();
	srchMainCont.Controls.Add(chseCriteriaMbrInp);
	
	chseCriteriaMbrBtn = new Button();
	chseCriteriaMbrBtn.Text = "SELECT";
	chseCriteriaMbrBtn.BackColor = Color.LightGreen;
	chseCriteriaMbrBtn.Click += new EventHandler(chseCriteriaMbrBtn_Clicked);
	chseCriteriaMbrBtn.Hide();
	srchMainCont.Controls.Add(chseCriteriaMbrBtn);

	searchPhraseLbl = new Label();
	searchPhraseLbl.Text = "Enter Search Phrase:";
	searchPhraseLbl.ForeColor = Color.DarkSlateGray;
	searchPhraseLbl.Hide();
	srchMainCont.Controls.Add(searchPhraseLbl);

	searchPhraseInp = new TextBox();
	searchPhraseInp.BackColor = Color.LightGray;
	searchPhraseInp.Hide();
	srchMainCont.Controls.Add(searchPhraseInp);

	searchBtn = new Button();
	searchBtn.Text = "SEARCH";
	searchBtn.BackColor = Color.Green;
	searchBtn.Hide();
	searchBtn.Click += new EventHandler(searchBtn_Clicked);
	srchMainCont.Controls.Add(searchBtn);

	srchResultCont = new Panel();
	srchResultCont.BackColor = Color.Aquamarine;
	srchResultCont.BorderStyle = BorderStyle.FixedSingle;
	srchResultCont.Hide();
	this.Controls.Add(srchResultCont);
	this.Controls.SetChildIndex(srchResultCont,0);

	srchResultTitle = new Label();
	srchResultTitle.Text = "SEARCH RESULTS";
	srchResultTitle.Location = new Point(320,30);
	srchResultCont.Controls.Add(srchResultTitle);

	srchResultCloseBtn = new Button();
	srchResultCloseBtn.Text = "X";
	srchResultCloseBtn.ForeColor = Color.Red;
	srchResultCloseBtn.Click += new EventHandler(srchResultCloseBtn_Clicked);
	srchResultCont.Controls.Add(srchResultCloseBtn);

	srchResultCatTitle = new Label();
	srchResultCatTitle.ForeColor = Color.Blue;
	srchResultCont.Controls.Add(srchResultCatTitle);

	srchResultGridView = new DataGridView();
	srchResultGridView.ReadOnly = true;
	srchResultCont.Controls.Add(srchResultGridView);

    }

    #endregion
}
