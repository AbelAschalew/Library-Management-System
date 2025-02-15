
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniProjectApp;

public partial class BookmanagementPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private DashboardPage DashboardForm;
	private MembermanagementPage MembermanagementForm;
	private BorrowPage BorrowForm;
	private ReturnPage ReturnForm;
	private ReportsPage ReportsForm;
	private UsersettingPage UsersettingForm;
	private SearchPage SearchForm;


    public BookmanagementPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;


	bkMgtLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


	this.Icon = EmbeddedFormIconLoader.LoadFormIcon("MiniProjectApp.Resources.cruiseFavicon.ico");
	this.BackgroundImage = EmbeddedBackgroundImageLoader.backgroundImageLoader("MiniProjectApp.Resources.formbackgroundImage.jpg");


	this.FormClosed += (sender,e) => Application.Exit();


	this.Resize += AdjustSizePosition;



    }

	private TForm NavigateTo<TForm>(TForm formInstance) where TForm : Form, new() {
		if (formInstance == null || formInstance.IsDisposed) {
        		formInstance = new TForm();
        		formInstance.FormClosed += (s, e) => formInstance = null;
    		}

    		this.Hide();
    		formInstance.Show();

    		return formInstance;
	}


	private void bkMgtSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}

	private void bkMgtSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void bkMgtSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void bkMgtSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void bkMgtSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void bkMgtSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void bkMgtSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}


	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		LoadData();
		addBkCont.Hide();
		bkMgtGridView.KeyDown += bkMgtGridView_KeyDown;
		bkMgtGridView.CellValueChanged += bkMgtGridView_CellValueChanged;
		
		bkMgtHeader.Width = (int)(screenWidth*1);
		bkMgtHeader.Height = (int)(screenHeight*0.1488);
		bkMgtHeader.Left = (int)(screenWidth*0);
		bkMgtHeader.Top = (int)(screenHeight*0);

		bkMgtMainTitle.Width = (int)(screenWidth*0.625);
		bkMgtMainTitle.Height = (int)(screenHeight*0.0793);
		bkMgtMainTitle.Left = (int)(bkMgtHeader.Width*0.1302);
		bkMgtMainTitle.Top = (int)(bkMgtHeader.Height*0);
		int bkMgtMainTitleFont = (int)(screenWidth*0.0166);
		bkMgtMainTitle.Font = new Font("roboto",bkMgtMainTitleFont, FontStyle.Bold);

		bkMgtPgeTitle.Width = (int)(screenWidth*0.625);
		bkMgtPgeTitle.Height = (int)(screenHeight*0.0595);
		bkMgtPgeTitle.Left = (int)(bkMgtHeader.Width*0.1302);
		bkMgtPgeTitle.Top = (int)(bkMgtHeader.Height*0.5666);
		int bkMgtPgeTitleFont = (int)(screenWidth*0.0104);
		bkMgtPgeTitle.Font = new Font("broadway",bkMgtPgeTitleFont);

		bkMgtLogo.Width = (int)(screenWidth*0.0781);
		bkMgtLogo.Height = (int)(screenHeight*0.0892);
		bkMgtLogo.Left = (int)(bkMgtHeader.Width*0.0260);
		bkMgtLogo.Top = (int)(bkMgtHeader.Height*0.2);

		bkMgtSideNav.Width = (int)(screenWidth*0.2604);
		bkMgtSideNav.Height = (int)(screenHeight*0.744);
		bkMgtSideNav.Left = (int)(screenWidth*0.0156);
		bkMgtSideNav.Top = (int)(screenHeight*0.1984);

		bkMgtSnvTitle.Width = (int)(screenWidth*0.2604);
		bkMgtSnvTitle.Height = (int)(screenHeight*0.0892);
		bkMgtSnvTitle.Left = (int)(bkMgtSideNav.Width*0);
		bkMgtSnvTitle.Top = (int)(bkMgtSideNav.Height*0);
		int bkMgtSnvTitleFont = (int)(screenWidth*0.0130);
		bkMgtSnvTitle.Font = new Font("arial",bkMgtSnvTitleFont,FontStyle.Bold);

		bkMgtSnvDshBrd.Width = (int)(screenWidth*0.2083);
		bkMgtSnvDshBrd.Height = (int)(screenHeight*0.0595);
		bkMgtSnvDshBrd.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvDshBrd.Top = (int)(bkMgtSideNav.Height*0.16);
		int bkMgtSnvDshBrdFont = (int)(screenWidth*0.0088);
		bkMgtSnvDshBrd.Font = new Font("Verdana",bkMgtSnvDshBrdFont,FontStyle.Underline);

		bkMgtSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		bkMgtSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		bkMgtSnvMbrMgt.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvMbrMgt.Top = (int)(bkMgtSideNav.Height*0.2666);
		int bkMgtSnvMbrMgtFont = (int)(screenWidth*0.0088);
		bkMgtSnvMbrMgt.Font = new Font("Verdana",bkMgtSnvMbrMgtFont,FontStyle.Underline);

		bkMgtSnvBrw.Width = (int)(screenWidth*0.2083);
		bkMgtSnvBrw.Height = (int)(screenHeight*0.0595);
		bkMgtSnvBrw.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvBrw.Top = (int)(bkMgtSideNav.Height*0.3733);
		int bkMgtSnvBrwFont = (int)(screenWidth*0.0088);
		bkMgtSnvBrw.Font = new Font("Verdana",bkMgtSnvBrwFont,FontStyle.Underline);

		bkMgtSnvRtn.Width = (int)(screenWidth*0.2083);
		bkMgtSnvRtn.Height = (int)(screenHeight*0.0595);
		bkMgtSnvRtn.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvRtn.Top = (int)(bkMgtSideNav.Height*0.48);
		int bkMgtSnvRtnFont = (int)(screenWidth*0.0088);
		bkMgtSnvRtn.Font = new Font("Verdana",bkMgtSnvRtnFont,FontStyle.Underline);

		bkMgtSnvRpt.Width = (int)(screenWidth*0.2083);
		bkMgtSnvRpt.Height = (int)(screenHeight*0.0595);
		bkMgtSnvRpt.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvRpt.Top = (int)(bkMgtSideNav.Height*0.5866);
		int bkMgtSnvRptFont = (int)(screenWidth*0.0088);
		bkMgtSnvRpt.Font = new Font("Verdana",bkMgtSnvRptFont,FontStyle.Underline);

		bkMgtSnvUsrStg.Width = (int)(screenWidth*0.2083);
		bkMgtSnvUsrStg.Height = (int)(screenHeight*0.0595);
		bkMgtSnvUsrStg.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvUsrStg.Top = (int)(bkMgtSideNav.Height*0.6933);
		int bkMgtSnvUsrStgFont = (int)(screenWidth*0.0088);
		bkMgtSnvUsrStg.Font = new Font("Verdana",bkMgtSnvUsrStgFont,FontStyle.Underline);

		bkMgtSnvSrch.Width = (int)(screenWidth*0.2083);
		bkMgtSnvSrch.Height = (int)(screenHeight*0.0595);
		bkMgtSnvSrch.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvSrch.Top = (int)(bkMgtSideNav.Height*0.8);
		int bkMgtSnvSrchFont = (int)(screenWidth*0.0088);
		bkMgtSnvSrch.Font = new Font("Verdana",bkMgtSnvSrchFont,FontStyle.Underline);

		bkMgtMainCont.Width = (int)(screenWidth*0.6666);
		bkMgtMainCont.Height = (int)(screenHeight*0.7936);
		bkMgtMainCont.Left = (int)(screenWidth*0.3281);
		bkMgtMainCont.Top = (int)(screenHeight*0.1587);

		bkMgtMainCntTitle.Width = (int)(screenWidth*0.18229167);
		bkMgtMainCntTitle.Height = (int)(screenHeight*0.04960317);
		bkMgtMainCntTitle.Left = (int)(bkMgtMainCont.Width*0.390625);
		bkMgtMainCntTitle.Top = (int)(bkMgtMainCont.Height*0.0375);
		int bkMgtMainCntTitleFont = (int)(screenWidth*0.009375);
		bkMgtMainCntTitle.Font = new Font ("Verdana",bkMgtMainCntTitleFont,FontStyle.Bold|FontStyle.Underline);

		bkMgtGridView.Width = (int)(screenWidth*0.58333333);
		bkMgtGridView.Height = (int)(screenHeight*0.14880952);
		bkMgtGridView.Left = (int)(bkMgtMainCont.Width*0.039065);
		bkMgtGridView.Top = (int)(bkMgtMainCont.Height*0.625);
		int bkMgtGridViewFont = (int)(screenWidth*0.00520833);
		bkMgtGridView.Font = new Font("arial",bkMgtGridViewFont);

		bkMgtAddBtn.Width = (int)(screenWidth*0.15625);
		bkMgtAddBtn.Height = (int)(screenHeight*0.07936508);
		bkMgtAddBtn.Left = (int)(bkMgtMainCont.Width*0.3828125);
		bkMgtAddBtn.Top = (int)(bkMgtMainCont.Height*0.125);
		int bkMgtAddBtnFont = (int)(screenWidth*0.00833333);
		bkMgtAddBtn.Font = new Font("arial",bkMgtAddBtnFont,FontStyle.Bold);

		addBkCont.Width = (int)(screenWidth*0.52083333);
		addBkCont.Height = (int)(screenHeight*0.84325397);
		addBkCont.Left = (int)(screenWidth*0.23958333);
		addBkCont.Top = (int)(screenHeight*0.08928571);

		addBkTitle.Width = (int)(screenWidth*0.18229167);
		addBkTitle.Height = (int)(screenHeight*0.05952381);
		addBkTitle.Left = (int)(addBkCont.Width*0.35);
		addBkTitle.Top = (int)(addBkCont.Height*0.03529412);
		int addBkTitleFont = (int)(screenWidth*0.01197917);
		addBkTitle.Font = new Font("arial",addBkTitleFont,FontStyle.Bold|FontStyle.Underline);

		addBkCloseBtn.Width = (int)(screenWidth*0.03125);
		addBkCloseBtn.Height = (int)(screenHeight*0.05952381);
		addBkCloseBtn.Left = (int)(addBkCont.Width*0.9);
		addBkCloseBtn.Top = (int)(addBkCont.Height*0.01176471);
		int addBkCloseBtnFont = (int)(screenWidth*0.00833333);
		addBkCloseBtn.Font = new Font("arial",addBkCloseBtnFont,FontStyle.Bold);

		addBkBkTitle.Width = (int)(screenWidth*0.05208333);
		addBkBkTitle.Height = (int)(screenHeight*0.04960317);
		addBkBkTitle.Left = (int)(addBkCont.Width*0.08);
		addBkBkTitle.Top = (int)(addBkCont.Height*0.15294118);
		int addBkBkTitleFont = (int)(screenWidth*0.00885417);
		addBkBkTitle.Font = new Font("times new roman",addBkBkTitleFont,FontStyle.Bold);

		addBkBkTitleVal.Width = (int)(screenWidth*0.20833333);
		addBkBkTitleVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkTitleVal.Top = (int)(addBkCont.Height*0.15294118);
		int addBkBkTitleValFont = (int)(screenWidth*0.00885417);
		addBkBkTitleVal.Font = new Font("arial",addBkBkTitleValFont);

		addBkBkAuthor.Width = (int)(screenWidth*0.078125);
		addBkBkAuthor.Height = (int)(screenHeight*0.04960317);
		addBkBkAuthor.Left = (int)(addBkCont.Width*0.08);
		addBkBkAuthor.Top = (int)(addBkCont.Height*0.27058824);
		int addBkBkAuthorFont = (int)(screenWidth*0.00885417);
		addBkBkAuthor.Font = new Font("times new roman",addBkBkAuthorFont,FontStyle.Bold);

		addBkBkAuthorVal.Width = (int)(screenWidth*0.20833333);
		addBkBkAuthorVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkAuthorVal.Top = (int)(addBkCont.Height*0.27058824);
		int addBkBkAuthorValFont = (int)(screenWidth*0.00885417);
		addBkBkAuthorVal.Font = new Font("arial",addBkBkAuthorValFont);

		addBkBkIsbn.Width = (int)(screenWidth*0.078125);
		addBkBkIsbn.Height = (int)(screenHeight*0.04960317);
		addBkBkIsbn.Left = (int)(addBkCont.Width*0.08);
		addBkBkIsbn.Top = (int)(addBkCont.Height*0.38823529);
		int addBkBkIsbnFont = (int)(screenWidth*0.00885417);
		addBkBkIsbn.Font = new Font("times new roman",addBkBkAuthorFont,FontStyle.Bold);

		addBkBkIsbnVal.Width = (int)(screenWidth*0.20833333);
		addBkBkIsbnVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkIsbnVal.Top = (int)(addBkCont.Height*0.38823529);
		int addBkBkIsbnValFont = (int)(screenWidth*0.00885417);
		addBkBkIsbnVal.Font = new Font("arial",addBkBkIsbnValFont);

		addBkBkPubYr.Width = (int)(screenWidth*0.15625);
		addBkBkPubYr.Height = (int)(screenHeight*0.04960317);
		addBkBkPubYr.Left = (int)(addBkCont.Width*0.08);
		addBkBkPubYr.Top = (int)(addBkCont.Height*0.50588235);
		int addBkBkPubYrFont = (int)(screenWidth*0.00885417);
		addBkBkPubYr.Font = new Font("times new roman",addBkBkPubYrFont,FontStyle.Bold);

		addBkBkPubYrVal.Width = (int)(screenWidth*0.20833333);
		addBkBkPubYrVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkPubYrVal.Top = (int)(addBkCont.Height*0.50588235);
		int addBkBkPubYrValFont = (int)(screenWidth*0.00885417);
		addBkBkPubYrVal.Font = new Font("arial",addBkBkPubYrValFont);

		addBkBkCatgry.Width = (int)(screenWidth*0.15625);
		addBkBkCatgry.Height = (int)(screenHeight*0.04960317);
		addBkBkCatgry.Left = (int)(addBkCont.Width*0.08);
		addBkBkCatgry.Top = (int)(addBkCont.Height*0.62352941);
		int addBkBkCatgryFont = (int)(screenWidth*0.00885417);
		addBkBkCatgry.Font = new Font("times new roman",addBkBkCatgryFont,FontStyle.Bold);

		addBkBkCatgryVal.Width = (int)(screenWidth*0.20833333);
		addBkBkCatgryVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkCatgryVal.Top = (int)(addBkCont.Height*0.62352941);
		int addBkBkCatgryValFont = (int)(screenWidth*0.00885417);
		addBkBkCatgryVal.Font = new Font("arial",addBkBkCatgryValFont);

		addBkBkStatus.Width = (int)(screenWidth*0.15625);
		addBkBkStatus.Height = (int)(screenHeight*0.04960317);
		addBkBkStatus.Left = (int)(addBkCont.Width*0.08);
		addBkBkStatus.Top = (int)(addBkCont.Height*0.74117647);
		int addBkBkStatusFont = (int)(screenWidth*0.00885417);
		addBkBkStatus.Font = new Font("times new roman",addBkBkStatusFont,FontStyle.Bold);

		addBkBkStatusVal.Width = (int)(screenWidth*0.20833333);
		addBkBkStatusVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkStatusVal.Top = (int)(addBkCont.Height*0.74117647);
		int addBkBkStatusValFont = (int)(screenWidth*0.00885417);
		addBkBkStatusVal.Font = new Font("arial",addBkBkStatusValFont);

		addBkAddBtn.Width = (int)(screenWidth*0.20833333);
		addBkAddBtn.Height = (int)(screenHeight*0.09920635);
		addBkAddBtn.Left = (int)(addBkCont.Width*0.3);
		addBkAddBtn.Top = (int)(addBkCont.Height*0.82352941);
		int addBkAddBtnFont = (int)(screenWidth*0.01041667);
		addBkAddBtn.Font = new Font("arial",addBkAddBtnFont,FontStyle.Bold);
		
	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		bkMgtHeader.Width = (int)(formWidth*1);
		bkMgtHeader.Height = (int)(formHeight*0.1488);
		bkMgtHeader.Left = (int)(formWidth*0);
		bkMgtHeader.Top = (int)(formHeight*0);

		bkMgtMainTitle.Width = (int)(formWidth*0.625);
		bkMgtMainTitle.Height = (int)(formHeight*0.0793);
		bkMgtMainTitle.Left = (int)(bkMgtHeader.Width*0.1302);
		bkMgtMainTitle.Top = (int)(bkMgtHeader.Height*0);
		int bkMgtMainTitleFont = (int)(formWidth*0.0166);
		bkMgtMainTitle.Font = new Font("roboto",bkMgtMainTitleFont, FontStyle.Bold);

		bkMgtPgeTitle.Width = (int)(formWidth*0.625);
		bkMgtPgeTitle.Height = (int)(formHeight*0.0595);
		bkMgtPgeTitle.Left = (int)(bkMgtHeader.Width*0.1302);
		bkMgtPgeTitle.Top = (int)(bkMgtHeader.Height*0.5666);
		int bkMgtPgeTitleFont = (int)(formWidth*0.0104);
		bkMgtPgeTitle.Font = new Font("broadway",bkMgtPgeTitleFont);

		bkMgtLogo.Width = (int)(formWidth*0.0781);
		bkMgtLogo.Height = (int)(formHeight*0.0892);
		bkMgtLogo.Left = (int)(bkMgtHeader.Width*0.0260);
		bkMgtLogo.Top = (int)(bkMgtHeader.Height*0.2);

		bkMgtSideNav.Width = (int)(formWidth*0.2604);
		bkMgtSideNav.Height = (int)(formHeight*0.744);
		bkMgtSideNav.Left = (int)(formWidth*0.0156);
		bkMgtSideNav.Top = (int)(formHeight*0.1984);

		bkMgtSnvTitle.Width = (int)(formWidth*0.2604);
		bkMgtSnvTitle.Height = (int)(formHeight*0.0892);
		bkMgtSnvTitle.Left = (int)(bkMgtSideNav.Width*0);
		bkMgtSnvTitle.Top = (int)(bkMgtSideNav.Height*0);
		int bkMgtSnvTitleFont = (int)(formWidth*0.0130);
		bkMgtSnvTitle.Font = new Font("arial",bkMgtSnvTitleFont,FontStyle.Bold);

		bkMgtSnvDshBrd.Width = (int)(formWidth*0.2083);
		bkMgtSnvDshBrd.Height = (int)(formHeight*0.0595);
		bkMgtSnvDshBrd.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvDshBrd.Top = (int)(bkMgtSideNav.Height*0.16);
		int bkMgtSnvDshBrdFont = (int)(formWidth*0.0088);
		bkMgtSnvDshBrd.Font = new Font("Verdana",bkMgtSnvDshBrdFont,FontStyle.Underline);

		bkMgtSnvMbrMgt.Width = (int)(formWidth*0.2083);
		bkMgtSnvMbrMgt.Height = (int)(formHeight*0.0595);
		bkMgtSnvMbrMgt.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvMbrMgt.Top = (int)(bkMgtSideNav.Height*0.2666);
		int bkMgtSnvMbrMgtFont = (int)(formWidth*0.0088);
		bkMgtSnvMbrMgt.Font = new Font("Verdana",bkMgtSnvMbrMgtFont,FontStyle.Underline);

		bkMgtSnvBrw.Width = (int)(formWidth*0.2083);
		bkMgtSnvBrw.Height = (int)(formHeight*0.0595);
		bkMgtSnvBrw.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvBrw.Top = (int)(bkMgtSideNav.Height*0.3733);
		int bkMgtSnvBrwFont = (int)(formWidth*0.0088);
		bkMgtSnvBrw.Font = new Font("Verdana",bkMgtSnvBrwFont,FontStyle.Underline);

		bkMgtSnvRtn.Width = (int)(formWidth*0.2083);
		bkMgtSnvRtn.Height = (int)(formHeight*0.0595);
		bkMgtSnvRtn.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvRtn.Top = (int)(bkMgtSideNav.Height*0.48);
		int bkMgtSnvRtnFont = (int)(formWidth*0.0088);
		bkMgtSnvRtn.Font = new Font("Verdana",bkMgtSnvRtnFont,FontStyle.Underline);

		bkMgtSnvRpt.Width = (int)(formWidth*0.2083);
		bkMgtSnvRpt.Height = (int)(formHeight*0.0595);
		bkMgtSnvRpt.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvRpt.Top = (int)(bkMgtSideNav.Height*0.5866);
		int bkMgtSnvRptFont = (int)(formWidth*0.0088);
		bkMgtSnvRpt.Font = new Font("Verdana",bkMgtSnvRptFont,FontStyle.Underline);

		bkMgtSnvUsrStg.Width = (int)(formWidth*0.2083);
		bkMgtSnvUsrStg.Height = (int)(formHeight*0.0595);
		bkMgtSnvUsrStg.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvUsrStg.Top = (int)(bkMgtSideNav.Height*0.6933);
		int bkMgtSnvUsrStgFont = (int)(formWidth*0.0088);
		bkMgtSnvUsrStg.Font = new Font("Verdana",bkMgtSnvUsrStgFont,FontStyle.Underline);

		bkMgtSnvSrch.Width = (int)(formWidth*0.2083);
		bkMgtSnvSrch.Height = (int)(formHeight*0.0595);
		bkMgtSnvSrch.Left = (int)(bkMgtSideNav.Width*0.1);
		bkMgtSnvSrch.Top = (int)(bkMgtSideNav.Height*0.8);
		int bkMgtSnvSrchFont = (int)(formWidth*0.0088);
		bkMgtSnvSrch.Font = new Font("Verdana",bkMgtSnvSrchFont,FontStyle.Underline);

		bkMgtMainCont.Width = (int)(formWidth*0.6666);
		bkMgtMainCont.Height = (int)(formHeight*0.7936);
		bkMgtMainCont.Left = (int)(formWidth*0.3281);
		bkMgtMainCont.Top = (int)(formHeight*0.1587);

		bkMgtMainCntTitle.Width = (int)(formWidth*0.18229167);
		bkMgtMainCntTitle.Height = (int)(formHeight*0.04960317);
		bkMgtMainCntTitle.Left = (int)(bkMgtMainCont.Width*0.390625);
		bkMgtMainCntTitle.Top = (int)(bkMgtMainCont.Height*0.0375);
		int bkMgtMainCntTitleFont = (int)(formWidth*0.009375);
		bkMgtMainCntTitle.Font = new Font ("Verdana",bkMgtMainCntTitleFont,FontStyle.Bold|FontStyle.Underline);

		bkMgtGridView.Width = (int)(formWidth*0.58333333);
		bkMgtGridView.Height = (int)(formHeight*0.14880952);
		bkMgtGridView.Left = (int)(bkMgtMainCont.Width*0.039065);
		bkMgtGridView.Top = (int)(bkMgtMainCont.Height*0.625);
		int bkMgtGridViewFont = (int)(formWidth*0.00520833);
		bkMgtGridView.Font = new Font("arial",bkMgtGridViewFont);

		bkMgtAddBtn.Width = (int)(formWidth*0.15625);
		bkMgtAddBtn.Height = (int)(formHeight*0.07936508);
		bkMgtAddBtn.Left = (int)(bkMgtMainCont.Width*0.3828125);
		bkMgtAddBtn.Top = (int)(bkMgtMainCont.Height*0.125);
		int bkMgtAddBtnFont = (int)(formWidth*0.00833333);
		bkMgtAddBtn.Font = new Font("arial",bkMgtAddBtnFont,FontStyle.Bold);

		addBkCont.Width = (int)(formWidth*0.52083333);
		addBkCont.Height = (int)(formHeight*0.84325397);
		addBkCont.Left = (int)(formWidth*0.23958333);
		addBkCont.Top = (int)(formHeight*0.08928571);

		addBkTitle.Width = (int)(formWidth*0.18229167);
		addBkTitle.Height = (int)(formHeight*0.05952381);
		addBkTitle.Left = (int)(addBkCont.Width*0.35);
		addBkTitle.Top = (int)(addBkCont.Height*0.03529412);
		int addBkTitleFont = (int)(formWidth*0.01197917);
		addBkTitle.Font = new Font("arial",addBkTitleFont,FontStyle.Bold|FontStyle.Underline);

		addBkCloseBtn.Width = (int)(formWidth*0.03125);
		addBkCloseBtn.Height = (int)(formHeight*0.05952381);
		addBkCloseBtn.Left = (int)(addBkCont.Width*0.9);
		addBkCloseBtn.Top = (int)(addBkCont.Height*0.01176471);
		int addBkCloseBtnFont = (int)(formWidth*0.00833333);
		addBkCloseBtn.Font = new Font("arial",addBkCloseBtnFont,FontStyle.Bold);

		addBkBkTitle.Width = (int)(formWidth*0.05208333);
		addBkBkTitle.Height = (int)(formHeight*0.04960317);
		addBkBkTitle.Left = (int)(addBkCont.Width*0.08);
		addBkBkTitle.Top = (int)(addBkCont.Height*0.15294118);
		int addBkBkTitleFont = (int)(formWidth*0.00885417);
		addBkBkTitle.Font = new Font("times new roman",addBkBkTitleFont,FontStyle.Bold);

		addBkBkTitleVal.Width = (int)(formWidth*0.20833333);
		addBkBkTitleVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkTitleVal.Top = (int)(addBkCont.Height*0.15294118);
		int addBkBkTitleValFont = (int)(formWidth*0.00885417);
		addBkBkTitleVal.Font = new Font("arial",addBkBkTitleValFont);

		addBkBkAuthor.Width = (int)(formWidth*0.078125);
		addBkBkAuthor.Height = (int)(formHeight*0.04960317);
		addBkBkAuthor.Left = (int)(addBkCont.Width*0.08);
		addBkBkAuthor.Top = (int)(addBkCont.Height*0.27058824);
		int addBkBkAuthorFont = (int)(formWidth*0.00885417);
		addBkBkAuthor.Font = new Font("times new roman",addBkBkAuthorFont,FontStyle.Bold);

		addBkBkAuthorVal.Width = (int)(formWidth*0.20833333);
		addBkBkAuthorVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkAuthorVal.Top = (int)(addBkCont.Height*0.27058824);
		int addBkBkAuthorValFont = (int)(formWidth*0.00885417);
		addBkBkAuthorVal.Font = new Font("arial",addBkBkAuthorValFont);

		addBkBkIsbn.Width = (int)(formWidth*0.078125);
		addBkBkIsbn.Height = (int)(formHeight*0.04960317);
		addBkBkIsbn.Left = (int)(addBkCont.Width*0.08);
		addBkBkIsbn.Top = (int)(addBkCont.Height*0.38823529);
		int addBkBkIsbnFont = (int)(formWidth*0.00885417);
		addBkBkIsbn.Font = new Font("times new roman",addBkBkAuthorFont,FontStyle.Bold);

		addBkBkIsbnVal.Width = (int)(formWidth*0.20833333);
		addBkBkIsbnVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkIsbnVal.Top = (int)(addBkCont.Height*0.38823529);
		int addBkBkIsbnValFont = (int)(formWidth*0.00885417);
		addBkBkIsbnVal.Font = new Font("arial",addBkBkIsbnValFont);

		addBkBkPubYr.Width = (int)(formWidth*0.15625);
		addBkBkPubYr.Height = (int)(formHeight*0.04960317);
		addBkBkPubYr.Left = (int)(addBkCont.Width*0.08);
		addBkBkPubYr.Top = (int)(addBkCont.Height*0.50588235);
		int addBkBkPubYrFont = (int)(formWidth*0.00885417);
		addBkBkPubYr.Font = new Font("times new roman",addBkBkPubYrFont,FontStyle.Bold);

		addBkBkPubYrVal.Width = (int)(formWidth*0.20833333);
		addBkBkPubYrVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkPubYrVal.Top = (int)(addBkCont.Height*0.50588235);
		int addBkBkPubYrValFont = (int)(formWidth*0.00885417);
		addBkBkPubYrVal.Font = new Font("arial",addBkBkPubYrValFont);

		addBkBkCatgry.Width = (int)(formWidth*0.15625);
		addBkBkCatgry.Height = (int)(screenHeight*0.04960317);
		addBkBkCatgry.Left = (int)(addBkCont.Width*0.08);
		addBkBkCatgry.Top = (int)(addBkCont.Height*0.62352941);
		int addBkBkCatgryFont = (int)(formWidth*0.00885417);
		addBkBkCatgry.Font = new Font("times new roman",addBkBkCatgryFont,FontStyle.Bold);

		addBkBkCatgryVal.Width = (int)(formWidth*0.20833333);
		addBkBkCatgryVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkCatgryVal.Top = (int)(addBkCont.Height*0.62352941);
		int addBkBkCatgryValFont = (int)(formWidth*0.00885417);
		addBkBkCatgryVal.Font = new Font("arial",addBkBkCatgryValFont);

		addBkBkStatus.Width = (int)(formWidth*0.15625);
		addBkBkStatus.Height = (int)(formHeight*0.04960317);
		addBkBkStatus.Left = (int)(addBkCont.Width*0.08);
		addBkBkStatus.Top = (int)(addBkCont.Height*0.74117647);
		int addBkBkStatusFont = (int)(formWidth*0.00885417);
		addBkBkStatus.Font = new Font("times new roman",addBkBkStatusFont,FontStyle.Bold);

		addBkBkStatusVal.Width = (int)(formWidth*0.20833333);
		addBkBkStatusVal.Left = (int)(addBkCont.Width*0.4);
		addBkBkStatusVal.Top = (int)(addBkCont.Height*0.74117647);
		int addBkBkStatusValFont = (int)(formWidth*0.00885417);
		addBkBkStatusVal.Font = new Font("arial",addBkBkStatusValFont);

		addBkAddBtn.Width = (int)(formWidth*0.20833333);
		addBkAddBtn.Height = (int)(formHeight*0.09920635);
		addBkAddBtn.Left = (int)(addBkCont.Width*0.3);
		addBkAddBtn.Top = (int)(addBkCont.Height*0.82352941);
		int addBkAddBtnFont = (int)(formWidth*0.01041667);
		addBkAddBtn.Font = new Font("arial",addBkAddBtnFont,FontStyle.Bold);

	}

	private void bkMgtSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvDshBrd.ForeColor = Color.Green;
	}
	private void bkMgtSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvDshBrd.ForeColor = Color.Blue;
	}

	private void bkMgtSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvMbrMgt.ForeColor = Color.Green;
	}
	private void bkMgtSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void bkMgtSnvBrw_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvBrw.ForeColor = Color.Green;
	}
	private void bkMgtSnvBrw_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvBrw.ForeColor = Color.Blue;
	}

	private void bkMgtSnvRtn_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvRtn.ForeColor = Color.Green;
	}
	private void bkMgtSnvRtn_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvRtn.ForeColor = Color.Blue;
	}

	private void bkMgtSnvRpt_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvRpt.ForeColor = Color.Green;
	}
	private void bkMgtSnvRpt_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvRpt.ForeColor = Color.Blue;
	}

	private void bkMgtSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvUsrStg.ForeColor = Color.Green;
	}
	private void bkMgtSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvUsrStg.ForeColor = Color.Blue;
	}

	private void bkMgtSnvSrch_MouseEnter (object sender, EventArgs e) {
		bkMgtSnvSrch.ForeColor = Color.Green;
	}
	private void bkMgtSnvSrch_MouseLeave (object sender, EventArgs e) {
		bkMgtSnvSrch.ForeColor = Color.Blue;
	}

	private void LoadData () {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT * FROM books";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter(query,connection);
				DataTable table = new DataTable();
				adapter.Fill(table);
				bkMgtGridView.DataSource = table;
			}
		} catch (Exception ex) {
			MessageBox.Show($"Book Records Error: {ex.Message}");
		}
	}

	private void bkMgtGridView_KeyDown (object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Delete && bkMgtGridView.SelectedRows.Count > 0) {
			foreach (DataGridViewRow row in bkMgtGridView.SelectedRows) {
				DeleteRecord(Convert.ToInt32(row.Cells["book_id"].Value));
				bkMgtGridView.Rows.Remove(row);
			}
		}
	}

	private void DeleteRecord (int bookId) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "DELETE FROM books WHERE book_id=@bookId";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@bookId",bookId);
				connection.Open();
				command.ExecuteNonQuery();
				MessageBox.Show("Book Record Deleted Successfully!");
			}
		} catch (Exception ex) {
			MessageBox.Show($"Delete Book Error: {ex.Message}");
		}
	}

	private void addBkCloseBtn_Clicked (object sender, EventArgs e) {
		addBkCont.Hide();
		LoadData();
	}

	private void bkMgtAddBtn_Clicked (object sender, EventArgs e) {
		addBkCont.Show();
	}

	private void addBkAddBtn_Clicked (object sender, EventArgs e) {
		try {
			string title = addBkBkTitleVal.Text;
			string author = addBkBkAuthorVal.Text;
			string isbn = addBkBkIsbnVal.Text;
			int publication_year = Convert.ToInt32(addBkBkPubYrVal.Text);
			string category = addBkBkCatgryVal.Text;
			string status = addBkBkStatusVal.SelectedItem.ToString();
			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn) || publication_year==null || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(status)) {
            			MessageBox.Show("All fields must have valid values.");
            			return;
        		}
	        	string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "INSERT INTO books (title,author,isbn,publication_year,category,status) VALUES (@title,@author,@isbn,@publication_year,@category,@status)";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@title",title);
				command.Parameters.AddWithValue("@author",author);
				command.Parameters.AddWithValue("@isbn",isbn);
				command.Parameters.AddWithValue("@publication_year",publication_year);
				command.Parameters.AddWithValue("@category",category);
				command.Parameters.AddWithValue("@status",status);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
               				MessageBox.Show("Book Added successfully.");
           			}
            			else {
                			MessageBox.Show("Book Not Added");
            			}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Add Book Error: {ex.Message}");
		}
	}

	private void bkMgtGridView_CellValueChanged (object sender, DataGridViewCellEventArgs e) {
		try {
			if (e.RowIndex < 0 || e.ColumnIndex < 0) {
            			return;
			}
			DataGridViewRow row = bkMgtGridView.Rows[e.RowIndex];
			int book_id = Convert.ToInt32(row.Cells["book_id"].Value);
			string title = row.Cells["title"].Value?.ToString();
			string author = row.Cells["author"].Value?.ToString();
			string isbn = row.Cells["isbn"].Value?.ToString();
			int publication_year = Convert.ToInt32(row.Cells["publication_year"].Value);
			string category = row.Cells["category"].Value?.ToString();
			string status = row.Cells["status"].Value?.ToString();
			 if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn) || publication_year==null || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(status)) {
            			MessageBox.Show("All fields must have valid values.");
            			return;
        		}
        		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "UPDATE books SET title=@title, author=@author, isbn=@isbn, publication_year=@publication_year, category=@category, status=@status WHERE book_id=@book_id";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@book_id",book_id);
				command.Parameters.AddWithValue("@title",title);
				command.Parameters.AddWithValue("@author",author);
				command.Parameters.AddWithValue("@isbn",isbn);
				command.Parameters.AddWithValue("@publication_year",publication_year);
				command.Parameters.AddWithValue("@category",category);
				command.Parameters.AddWithValue("@status",status);
				connection.Open();
            			int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
                			MessageBox.Show("Database updated successfully.");
            			} else {
                			MessageBox.Show("No record was updated. Please verify the data.");
            			}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Update Book Error: {ex.Message}");
		}
	}

}
