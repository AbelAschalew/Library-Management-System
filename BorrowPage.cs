
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MiniProjectApp;

public partial class BorrowPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private DashboardPage DashboardForm;
	private MembermanagementPage MembermanagementForm;
	private BookmanagementPage BookmanagementForm;
	private ReturnPage ReturnForm;
	private ReportsPage ReportsForm;
	private UsersettingPage UsersettingForm;
	private SearchPage SearchForm;

	private string member_id;
	private string book_id;


    public BorrowPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	brwLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


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

	private void brwSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void brwSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void brwSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}

	private void brwSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void brwSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void brwSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void brwSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}


	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		borrowBkCont.Hide();
		manageOverdue();
		LoadData();		
		
		brwHeader.Width = (int)(screenWidth*1);
		brwHeader.Height = (int)(screenHeight*0.1488);
		brwHeader.Left = (int)(screenWidth*0);
		brwHeader.Top = (int)(screenHeight*0);

		brwMainTitle.Width = (int)(screenWidth*0.625);
		brwMainTitle.Height = (int)(screenHeight*0.0793);
		brwMainTitle.Left = (int)(brwHeader.Width*0.1302);
		brwMainTitle.Top = (int)(brwHeader.Height*0);
		int brwMainTitleFont = (int)(screenWidth*0.0166);
		brwMainTitle.Font = new Font("roboto",brwMainTitleFont, FontStyle.Bold);

		brwPgeTitle.Width = (int)(screenWidth*0.625);
		brwPgeTitle.Height = (int)(screenHeight*0.0595);
		brwPgeTitle.Left = (int)(brwHeader.Width*0.1302);
		brwPgeTitle.Top = (int)(brwHeader.Height*0.5666);
		int brwPgeTitleFont = (int)(screenWidth*0.0104);
		brwPgeTitle.Font = new Font("broadway",brwPgeTitleFont);

		brwLogo.Width = (int)(screenWidth*0.0781);
		brwLogo.Height = (int)(screenHeight*0.0892);
		brwLogo.Left = (int)(brwHeader.Width*0.0260);
		brwLogo.Top = (int)(brwHeader.Height*0.2);

		brwSideNav.Width = (int)(screenWidth*0.2604);
		brwSideNav.Height = (int)(screenHeight*0.744);
		brwSideNav.Left = (int)(screenWidth*0.0156);
		brwSideNav.Top = (int)(screenHeight*0.1984);

		brwSnvTitle.Width = (int)(screenWidth*0.2604);
		brwSnvTitle.Height = (int)(screenHeight*0.0892);
		brwSnvTitle.Left = (int)(brwSideNav.Width*0);
		brwSnvTitle.Top = (int)(brwSideNav.Height*0);
		int brwSnvTitleFont = (int)(screenWidth*0.0130);
		brwSnvTitle.Font = new Font("arial",brwSnvTitleFont,FontStyle.Bold);

		brwSnvBkMgt.Width = (int)(screenWidth*0.2083);
		brwSnvBkMgt.Height = (int)(screenHeight*0.0595);
		brwSnvBkMgt.Left = (int)(brwSideNav.Width*0.1);
		brwSnvBkMgt.Top = (int)(brwSideNav.Height*0.16);
		int brwSnvBkMgtFont = (int)(screenWidth*0.0088);
		brwSnvBkMgt.Font = new Font("Verdana",brwSnvBkMgtFont,FontStyle.Underline);

		brwSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		brwSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		brwSnvMbrMgt.Left = (int)(brwSideNav.Width*0.1);
		brwSnvMbrMgt.Top = (int)(brwSideNav.Height*0.2666);
		int brwSnvMbrMgtFont = (int)(screenWidth*0.0088);
		brwSnvMbrMgt.Font = new Font("Verdana",brwSnvMbrMgtFont,FontStyle.Underline);

		brwSnvDshBrd.Width = (int)(screenWidth*0.2083);
		brwSnvDshBrd.Height = (int)(screenHeight*0.0595);
		brwSnvDshBrd.Left = (int)(brwSideNav.Width*0.1);
		brwSnvDshBrd.Top = (int)(brwSideNav.Height*0.3733);
		int brwSnvDshBrdFont = (int)(screenWidth*0.0088);
		brwSnvDshBrd.Font = new Font("Verdana",brwSnvDshBrdFont,FontStyle.Underline);

		brwSnvRtn.Width = (int)(screenWidth*0.2083);
		brwSnvRtn.Height = (int)(screenHeight*0.0595);
		brwSnvRtn.Left = (int)(brwSideNav.Width*0.1);
		brwSnvRtn.Top = (int)(brwSideNav.Height*0.48);
		int brwSnvRtnFont = (int)(screenWidth*0.0088);
		brwSnvRtn.Font = new Font("Verdana",brwSnvRtnFont,FontStyle.Underline);

		brwSnvRpt.Width = (int)(screenWidth*0.2083);
		brwSnvRpt.Height = (int)(screenHeight*0.0595);
		brwSnvRpt.Left = (int)(brwSideNav.Width*0.1);
		brwSnvRpt.Top = (int)(brwSideNav.Height*0.5866);
		int brwSnvRptFont = (int)(screenWidth*0.0088);
		brwSnvRpt.Font = new Font("Verdana",brwSnvRptFont,FontStyle.Underline);

		brwSnvUsrStg.Width = (int)(screenWidth*0.2083);
		brwSnvUsrStg.Height = (int)(screenHeight*0.0595);
		brwSnvUsrStg.Left = (int)(brwSideNav.Width*0.1);
		brwSnvUsrStg.Top = (int)(brwSideNav.Height*0.6933);
		int brwSnvUsrStgFont = (int)(screenWidth*0.0088);
		brwSnvUsrStg.Font = new Font("Verdana",brwSnvUsrStgFont,FontStyle.Underline);

		brwSnvSrch.Width = (int)(screenWidth*0.2083);
		brwSnvSrch.Height = (int)(screenHeight*0.0595);
		brwSnvSrch.Left = (int)(brwSideNav.Width*0.1);
		brwSnvSrch.Top = (int)(brwSideNav.Height*0.8);
		int brwSnvSrchFont = (int)(screenWidth*0.0088);
		brwSnvSrch.Font = new Font("Verdana",brwSnvSrchFont,FontStyle.Underline);

		brwMainCont.Width = (int)(screenWidth*0.6666);
		brwMainCont.Height = (int)(screenHeight*0.7936);
		brwMainCont.Left = (int)(screenWidth*0.3281);
		brwMainCont.Top = (int)(screenHeight*0.1587);

		brwMainContTitle.Width = (int)(screenWidth*0.19270833);
		brwMainContTitle.Height = (int)(screenHeight*0.05952381);
		brwMainContTitle.Left = (int)(brwMainCont.Width*0.390625);
		brwMainContTitle.Top = (int)(brwMainCont.Height*0.0375);
		int brwMainContTitleFont = (int)(screenWidth*0.009375);
		brwMainContTitle.Font = new Font("Verdana",brwMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		brwMainMbrNmLbl.Width = (int)(screenWidth*0.13020833);
		brwMainMbrNmLbl.Height = (int)(screenHeight*0.04960317);
		brwMainMbrNmLbl.Left = (int)(brwMainCont.Width*0.15625);
		brwMainMbrNmLbl.Top = (int)(brwMainCont.Height*0.1875);
		int brwMainMbrNmLblFont = (int)(screenWidth*0.00885417);
		brwMainMbrNmLbl.Font = new Font("times new roman",brwMainMbrNmLblFont,FontStyle.Bold);

		brwMainMbrNmInp.Width = (int)(screenWidth*0.20833333);
		brwMainMbrNmInp.Left = (int)(brwMainCont.Width*0.390625);
		brwMainMbrNmInp.Top = (int)(brwMainCont.Height*0.1875);
		int brwMainMbrNmInpFont = (int)(screenWidth*0.00885417);
		brwMainMbrNmInp.Font = new Font("arial",brwMainMbrNmInpFont);

		brwMainBkrNmLbl.Width = (int)(screenWidth*0.13020833);
		brwMainBkrNmLbl.Height = (int)(screenHeight*0.04960317);
		brwMainBkrNmLbl.Left = (int)(brwMainCont.Width*0.15625);
		brwMainBkrNmLbl.Top = (int)(brwMainCont.Height*0.2875);
		int brwMainBkrNmLblFont = (int)(screenWidth*0.00885417);
		brwMainBkrNmLbl.Font = new Font("times new roman",brwMainBkrNmLblFont,FontStyle.Bold);

		brwMainBkrNmInp.Width = (int)(screenWidth*0.20833333);
		brwMainBkrNmInp.Left = (int)(brwMainCont.Width*0.390625);
		brwMainBkrNmInp.Top = (int)(brwMainCont.Height*0.2875);
		int brwMainBkrNmInpFont = (int)(screenWidth*0.00885417);
		brwMainBkrNmInp.Font = new Font("arial",brwMainBkrNmInpFont);

		brwMainBkMbrCheckBtn.Width = (int)(screenWidth*0.078125);
		brwMainBkMbrCheckBtn.Height = (int)(screenHeight*0.04960317);
		brwMainBkMbrCheckBtn.Left = (int)(brwMainCont.Width*0.7421875);
		brwMainBkMbrCheckBtn.Top = (int)(brwMainCont.Height*0.2875);
		int brwMainBkMbrCheckBtnFont = (int)(screenWidth*0.00885417);
		brwMainBkMbrCheckBtn.Font = new Font("arial",brwMainBkMbrCheckBtnFont,FontStyle.Bold);

		borrowBkCont.Width = (int)(screenWidth*0.52083333);
		borrowBkCont.Height = (int)(screenHeight*0.84325397);
		borrowBkCont.Left = (int)(screenWidth*0.23958333);
		borrowBkCont.Top = (int)(screenHeight*0.08928571);

		borrowBkTitle.Width = (int)(screenWidth*0.26041667);
		borrowBkTitle.Height = (int)(screenHeight*0.05952381);
		borrowBkTitle.Left = (int)(borrowBkCont.Width*0.3);
		borrowBkTitle.Top = (int)(borrowBkCont.Height*0.03529412);
		int borrowBkTitleFont = (int)(screenWidth*0.01197917);
		borrowBkTitle.Font = new Font("arial",borrowBkTitleFont,FontStyle.Bold|FontStyle.Underline);

		borrowBkCloseBtn.Width = (int)(screenWidth*0.03125);
		borrowBkCloseBtn.Height = (int)(screenHeight*0.05952381);
		borrowBkCloseBtn.Left = (int)(borrowBkCont.Width*0.9);
		borrowBkCloseBtn.Top = (int)(borrowBkCont.Height*0.01176471);
		int borrowBkCloseBtnFont = (int)(screenWidth*0.00833333);
		borrowBkCloseBtn.Font = new Font("arial",borrowBkCloseBtnFont,FontStyle.Bold);

		borrowBkMbrIdLbl.Width = (int)(screenWidth*0.13020833);
		borrowBkMbrIdLbl.Height = (int)(screenHeight*0.04960317);
		borrowBkMbrIdLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkMbrIdLbl.Top = (int)(borrowBkCont.Height*0.15294118);
		int borrowBkMbrIdLblFont = (int)(screenWidth*0.00885417);
		borrowBkMbrIdLbl.Font = new Font("times new roman",borrowBkMbrIdLblFont,FontStyle.Bold);

		borrowBkMbrIdInp.Width = (int)(screenWidth*0.20833333);
		borrowBkMbrIdInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkMbrIdInp.Top = (int)(borrowBkCont.Height*0.15294118);
		int borrowBkMbrIdInpFont = (int)(screenWidth*0.00885417);
		borrowBkMbrIdInp.Font = new Font("arial",borrowBkMbrIdInpFont);

		borrowBkBkIdLbl.Width = (int)(screenWidth*0.13020833);
		borrowBkBkIdLbl.Height = (int)(screenHeight*0.04960317);
		borrowBkBkIdLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkBkIdLbl.Top = (int)(borrowBkCont.Height*0.27058824);
		int borrowBkBkIdLblFont = (int)(screenWidth*0.00885417);
		borrowBkBkIdLbl.Font = new Font("times new roman",borrowBkBkIdLblFont,FontStyle.Bold);

		borrowBkBkIdInp.Width = (int)(screenWidth*0.20833333);
		borrowBkBkIdInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkBkIdInp.Top = (int)(borrowBkCont.Height*0.27058824);
		int borrowBkBkIdInpFont = (int)(screenWidth*0.00885417);
		borrowBkBkIdInp.Font = new Font("arial",borrowBkBkIdInpFont);

		borrowBkBrwDateLbl.Width = (int)(screenWidth*0.13020833);
		borrowBkBrwDateLbl.Height = (int)(screenHeight*0.04960317);
		borrowBkBrwDateLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkBrwDateLbl.Top = (int)(borrowBkCont.Height*0.38823529);
		int borrowBkBrwDateLblFont = (int)(screenWidth*0.00885417);
		borrowBkBrwDateLbl.Font = new Font("times new roman",borrowBkBrwDateLblFont,FontStyle.Bold);

		borrowBkBrwDateInp.Width = (int)(screenWidth*0.20833333);
		borrowBkBrwDateInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkBrwDateInp.Top = (int)(borrowBkCont.Height*0.38823529);
		int borrowBkBrwDateInpFont = (int)(screenWidth*0.00885417);
		borrowBkBrwDateInp.Font = new Font("arial",borrowBkBrwDateInpFont);

		borrowBkRtnDateLbl.Width = (int)(screenWidth*0.13020833);
		borrowBkRtnDateLbl.Height = (int)(screenHeight*0.04960317);
		borrowBkRtnDateLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkRtnDateLbl.Top = (int)(borrowBkCont.Height*0.50588235);
		int borrowBkRtnDateLblFont = (int)(screenWidth*0.00885417);
		borrowBkRtnDateLbl.Font = new Font("times new roman",borrowBkRtnDateLblFont,FontStyle.Bold);

		borrowBkRtnDateInp.Width = (int)(screenWidth*0.20833333);
		borrowBkRtnDateInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkRtnDateInp.Top = (int)(borrowBkCont.Height*0.50588235);
		int borrowBkRtnDateInpFont = (int)(screenWidth*0.00885417);
		borrowBkRtnDateInp.Font = new Font("arial",borrowBkRtnDateInpFont);

		borrowBkDueDateLbl.Width = (int)(screenWidth*0.13020833);
		borrowBkDueDateLbl.Height = (int)(screenHeight*0.04960317);
		borrowBkDueDateLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkDueDateLbl.Top = (int)(borrowBkCont.Height*0.62352941);
		int borrowBkDueDateLblFont = (int)(screenWidth*0.00885417);
		borrowBkDueDateLbl.Font = new Font("times new roman",borrowBkDueDateLblFont,FontStyle.Bold);

		borrowBkDueDateInp.Width = (int)(screenWidth*0.20833333);
		borrowBkDueDateInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkDueDateInp.Top = (int)(borrowBkCont.Height*0.62352941);
		int borrowBkDueDateInpFont = (int)(screenWidth*0.00885417);
		borrowBkDueDateInp.Font = new Font("arial",borrowBkDueDateInpFont);

		borrowBkBkStatusLbl.Width = (int)(screenWidth*0.13020833);
		borrowBkBkStatusLbl.Height = (int)(screenHeight*0.04960317);
		borrowBkBkStatusLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkBkStatusLbl.Top = (int)(borrowBkCont.Height*0.74117647);
		int borrowBkBkStatusLblFont = (int)(screenWidth*0.00885417);
		borrowBkBkStatusLbl.Font = new Font("times new roman",borrowBkBkStatusLblFont,FontStyle.Bold);

		borrowBkBkStatusInp.Width = (int)(screenWidth*0.20833333);
		borrowBkBkStatusInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkBkStatusInp.Top = (int)(borrowBkCont.Height*0.74117647);
		int borrowBkBkStatusInpFont = (int)(screenWidth*0.00885417);
		borrowBkBkStatusInp.Font = new Font("arial",borrowBkBkStatusInpFont);

		borrowBkBrwBtn.Width = (int)(screenWidth*0.20833333);
		borrowBkBrwBtn.Height = (int)(screenHeight*0.09920635);
		borrowBkBrwBtn.Left = (int)(borrowBkCont.Width*0.3);
		borrowBkBrwBtn.Top = (int)(borrowBkCont.Height*0.82352941);
		int borrowBkBrwBtnFont = (int)(screenWidth*0.01041667);
		borrowBkBrwBtn.Font = new Font("arial",borrowBkBrwBtnFont,FontStyle.Bold);

		borrowBkGridTitle.Width = (int)(screenWidth*0.234375);
		borrowBkGridTitle.Height = (int)(screenHeight*0.03968254);
		borrowBkGridTitle.Left = (int)(brwMainCont.Width*0.3125);
		borrowBkGridTitle.Top = (int)(brwMainCont.Height*0.5);
		int borrowBkGridTitleFont = (int)(screenWidth*0.00885417);
		borrowBkGridTitle.Font = new Font("arial",borrowBkGridTitleFont,FontStyle.Bold|FontStyle.Underline);

		borrowBkGridView.Width = (int)(screenWidth*0.59895833);
		borrowBkGridView.Height = (int)(screenHeight*0.14880952);
		borrowBkGridView.Left = (int)(brwMainCont.Width*0.0390625);
		borrowBkGridView.Top = (int)(brwMainCont.Height*0.625);
		int borrowBkGridViewFont = (int)(screenWidth*0.00520833);
		borrowBkGridView.Font = new Font("arial",borrowBkGridViewFont);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		brwHeader.Width = (int)(formWidth*1);
		brwHeader.Height = (int)(formHeight*0.1488);
		brwHeader.Left = (int)(formWidth*0);
		brwHeader.Top = (int)(formHeight*0);

		brwMainTitle.Width = (int)(formWidth*0.625);
		brwMainTitle.Height = (int)(formHeight*0.0793);
		brwMainTitle.Left = (int)(brwHeader.Width*0.1302);
		brwMainTitle.Top = (int)(brwHeader.Height*0);
		int brwMainTitleFont = (int)(formWidth*0.0166);
		brwMainTitle.Font = new Font("roboto",brwMainTitleFont, FontStyle.Bold);

		brwPgeTitle.Width = (int)(formWidth*0.625);
		brwPgeTitle.Height = (int)(formHeight*0.0595);
		brwPgeTitle.Left = (int)(brwHeader.Width*0.1302);
		brwPgeTitle.Top = (int)(brwHeader.Height*0.5666);
		int brwPgeTitleFont = (int)(formWidth*0.0104);
		brwPgeTitle.Font = new Font("broadway",brwPgeTitleFont);

		brwLogo.Width = (int)(formWidth*0.0781);
		brwLogo.Height = (int)(formHeight*0.0892);
		brwLogo.Left = (int)(brwHeader.Width*0.0260);
		brwLogo.Top = (int)(brwHeader.Height*0.2);

		brwSideNav.Width = (int)(formWidth*0.2604);
		brwSideNav.Height = (int)(formHeight*0.744);
		brwSideNav.Left = (int)(formWidth*0.0156);
		brwSideNav.Top = (int)(formHeight*0.1984);

		brwSnvTitle.Width = (int)(formWidth*0.2604);
		brwSnvTitle.Height = (int)(formHeight*0.0892);
		brwSnvTitle.Left = (int)(brwSideNav.Width*0);
		brwSnvTitle.Top = (int)(brwSideNav.Height*0);
		int brwSnvTitleFont = (int)(formWidth*0.0130);
		brwSnvTitle.Font = new Font("arial",brwSnvTitleFont,FontStyle.Bold);

		brwSnvBkMgt.Width = (int)(formWidth*0.2083);
		brwSnvBkMgt.Height = (int)(formHeight*0.0595);
		brwSnvBkMgt.Left = (int)(brwSideNav.Width*0.1);
		brwSnvBkMgt.Top = (int)(brwSideNav.Height*0.16);
		int brwSnvBkMgtFont = (int)(formWidth*0.0088);
		brwSnvBkMgt.Font = new Font("Verdana",brwSnvBkMgtFont,FontStyle.Underline);

		brwSnvMbrMgt.Width = (int)(formWidth*0.2083);
		brwSnvMbrMgt.Height = (int)(formHeight*0.0595);
		brwSnvMbrMgt.Left = (int)(brwSideNav.Width*0.1);
		brwSnvMbrMgt.Top = (int)(brwSideNav.Height*0.2666);
		int brwSnvMbrMgtFont = (int)(formWidth*0.0088);
		brwSnvMbrMgt.Font = new Font("Verdana",brwSnvMbrMgtFont,FontStyle.Underline);

		brwSnvDshBrd.Width = (int)(formWidth*0.2083);
		brwSnvDshBrd.Height = (int)(formHeight*0.0595);
		brwSnvDshBrd.Left = (int)(brwSideNav.Width*0.1);
		brwSnvDshBrd.Top = (int)(brwSideNav.Height*0.3733);
		int brwSnvDshBrdFont = (int)(formWidth*0.0088);
		brwSnvDshBrd.Font = new Font("Verdana",brwSnvDshBrdFont,FontStyle.Underline);

		brwSnvRtn.Width = (int)(formWidth*0.2083);
		brwSnvRtn.Height = (int)(formHeight*0.0595);
		brwSnvRtn.Left = (int)(brwSideNav.Width*0.1);
		brwSnvRtn.Top = (int)(brwSideNav.Height*0.48);
		int brwSnvRtnFont = (int)(formWidth*0.0088);
		brwSnvRtn.Font = new Font("Verdana",brwSnvRtnFont,FontStyle.Underline);

		brwSnvRpt.Width = (int)(formWidth*0.2083);
		brwSnvRpt.Height = (int)(formHeight*0.0595);
		brwSnvRpt.Left = (int)(brwSideNav.Width*0.1);
		brwSnvRpt.Top = (int)(brwSideNav.Height*0.5866);
		int brwSnvRptFont = (int)(formWidth*0.0088);
		brwSnvRpt.Font = new Font("Verdana",brwSnvRptFont,FontStyle.Underline);

		brwSnvUsrStg.Width = (int)(formWidth*0.2083);
		brwSnvUsrStg.Height = (int)(formHeight*0.0595);
		brwSnvUsrStg.Left = (int)(brwSideNav.Width*0.1);
		brwSnvUsrStg.Top = (int)(brwSideNav.Height*0.6933);
		int brwSnvUsrStgFont = (int)(formWidth*0.0088);
		brwSnvUsrStg.Font = new Font("Verdana",brwSnvUsrStgFont,FontStyle.Underline);

		brwSnvSrch.Width = (int)(formWidth*0.2083);
		brwSnvSrch.Height = (int)(formHeight*0.0595);
		brwSnvSrch.Left = (int)(brwSideNav.Width*0.1);
		brwSnvSrch.Top = (int)(brwSideNav.Height*0.8);
		int brwSnvSrchFont = (int)(formWidth*0.0088);
		brwSnvSrch.Font = new Font("Verdana",brwSnvSrchFont,FontStyle.Underline);

		brwMainCont.Width = (int)(formWidth*0.6666);
		brwMainCont.Height = (int)(formHeight*0.7936);
		brwMainCont.Left = (int)(formWidth*0.3281);
		brwMainCont.Top = (int)(formHeight*0.1587);

		brwMainMbrNmLbl.Width = (int)(formWidth*0.13020833);
		brwMainMbrNmLbl.Height = (int)(formHeight*0.04960317);
		brwMainMbrNmLbl.Left = (int)(brwMainCont.Width*0.15625);
		brwMainMbrNmLbl.Top = (int)(brwMainCont.Height*0.1875);
		int brwMainMbrNmLblFont = (int)(formWidth*0.00885417);
		brwMainMbrNmLbl.Font = new Font("times new roman",brwMainMbrNmLblFont,FontStyle.Bold);

		brwMainMbrNmInp.Width = (int)(formWidth*0.20833333);
		brwMainMbrNmInp.Left = (int)(brwMainCont.Width*0.390625);
		brwMainMbrNmInp.Top = (int)(brwMainCont.Height*0.1875);
		int brwMainMbrNmInpFont = (int)(formWidth*0.00885417);
		brwMainMbrNmInp.Font = new Font("arial",brwMainMbrNmInpFont);

		brwMainBkrNmLbl.Width = (int)(formWidth*0.13020833);
		brwMainBkrNmLbl.Height = (int)(formHeight*0.04960317);
		brwMainBkrNmLbl.Left = (int)(brwMainCont.Width*0.15625);
		brwMainBkrNmLbl.Top = (int)(brwMainCont.Height*0.2875);
		int brwMainBkrNmLblFont = (int)(formWidth*0.00885417);
		brwMainBkrNmLbl.Font = new Font("times new roman",brwMainBkrNmLblFont,FontStyle.Bold);

		brwMainBkrNmInp.Width = (int)(formWidth*0.20833333);
		brwMainBkrNmInp.Left = (int)(brwMainCont.Width*0.390625);
		brwMainBkrNmInp.Top = (int)(brwMainCont.Height*0.2875);
		int brwMainBkrNmInpFont = (int)(formWidth*0.00885417);
		brwMainBkrNmInp.Font = new Font("arial",brwMainBkrNmInpFont);

		brwMainBkMbrCheckBtn.Width = (int)(formWidth*0.078125);
		brwMainBkMbrCheckBtn.Height = (int)(formHeight*0.04960317);
		brwMainBkMbrCheckBtn.Left = (int)(brwMainCont.Width*0.7421875);
		brwMainBkMbrCheckBtn.Top = (int)(brwMainCont.Height*0.2875);
		int brwMainBkMbrCheckBtnFont = (int)(formWidth*0.00885417);
		brwMainBkMbrCheckBtn.Font = new Font("arial",brwMainBkMbrCheckBtnFont,FontStyle.Bold);

		borrowBkCont.Width = (int)(formWidth*0.52083333);
		borrowBkCont.Height = (int)(formHeight*0.84325397);
		borrowBkCont.Left = (int)(formWidth*0.23958333);
		borrowBkCont.Top = (int)(formHeight*0.08928571);

		borrowBkTitle.Width = (int)(formWidth*0.26041667);
		borrowBkTitle.Height = (int)(formHeight*0.05952381);
		borrowBkTitle.Left = (int)(borrowBkCont.Width*0.3);
		borrowBkTitle.Top = (int)(borrowBkCont.Height*0.03529412);
		int borrowBkTitleFont = (int)(formWidth*0.01197917);
		borrowBkTitle.Font = new Font("arial",borrowBkTitleFont,FontStyle.Bold|FontStyle.Underline);

		borrowBkCloseBtn.Width = (int)(formWidth*0.03125);
		borrowBkCloseBtn.Height = (int)(formHeight*0.05952381);
		borrowBkCloseBtn.Left = (int)(borrowBkCont.Width*0.9);
		borrowBkCloseBtn.Top = (int)(borrowBkCont.Height*0.01176471);
		int borrowBkCloseBtnFont = (int)(formWidth*0.00833333);
		borrowBkCloseBtn.Font = new Font("arial",borrowBkCloseBtnFont,FontStyle.Bold);

		borrowBkMbrIdLbl.Width = (int)(formWidth*0.13020833);
		borrowBkMbrIdLbl.Height = (int)(formHeight*0.04960317);
		borrowBkMbrIdLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkMbrIdLbl.Top = (int)(borrowBkCont.Height*0.15294118);
		int borrowBkMbrIdLblFont = (int)(formWidth*0.00885417);
		borrowBkMbrIdLbl.Font = new Font("times new roman",borrowBkMbrIdLblFont,FontStyle.Bold);

		borrowBkMbrIdInp.Width = (int)(formWidth*0.20833333);
		borrowBkMbrIdInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkMbrIdInp.Top = (int)(borrowBkCont.Height*0.15294118);
		int borrowBkMbrIdInpFont = (int)(formWidth*0.00885417);
		borrowBkMbrIdInp.Font = new Font("arial",borrowBkMbrIdInpFont);

		borrowBkBkIdLbl.Width = (int)(formWidth*0.13020833);
		borrowBkBkIdLbl.Height = (int)(formHeight*0.04960317);
		borrowBkBkIdLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkBkIdLbl.Top = (int)(borrowBkCont.Height*0.27058824);
		int borrowBkBkIdLblFont = (int)(formWidth*0.00885417);
		borrowBkBkIdLbl.Font = new Font("times new roman",borrowBkBkIdLblFont,FontStyle.Bold);

		borrowBkBkIdInp.Width = (int)(formWidth*0.20833333);
		borrowBkBkIdInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkBkIdInp.Top = (int)(borrowBkCont.Height*0.27058824);
		int borrowBkBkIdInpFont = (int)(formWidth*0.00885417);
		borrowBkBkIdInp.Font = new Font("arial",borrowBkBkIdInpFont);

		borrowBkBrwDateLbl.Width = (int)(formWidth*0.13020833);
		borrowBkBrwDateLbl.Height = (int)(formHeight*0.04960317);
		borrowBkBrwDateLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkBrwDateLbl.Top = (int)(borrowBkCont.Height*0.38823529);
		int borrowBkBrwDateLblFont = (int)(formWidth*0.00885417);
		borrowBkBrwDateLbl.Font = new Font("times new roman",borrowBkBrwDateLblFont,FontStyle.Bold);

		borrowBkBrwDateInp.Width = (int)(formWidth*0.20833333);
		borrowBkBrwDateInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkBrwDateInp.Top = (int)(borrowBkCont.Height*0.38823529);
		int borrowBkBrwDateInpFont = (int)(formWidth*0.00885417);
		borrowBkBrwDateInp.Font = new Font("arial",borrowBkBrwDateInpFont);

		borrowBkRtnDateLbl.Width = (int)(formWidth*0.13020833);
		borrowBkRtnDateLbl.Height = (int)(formHeight*0.04960317);
		borrowBkRtnDateLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkRtnDateLbl.Top = (int)(borrowBkCont.Height*0.50588235);
		int borrowBkRtnDateLblFont = (int)(formWidth*0.00885417);
		borrowBkRtnDateLbl.Font = new Font("times new roman",borrowBkRtnDateLblFont,FontStyle.Bold);

		borrowBkRtnDateInp.Width = (int)(formWidth*0.20833333);
		borrowBkRtnDateInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkRtnDateInp.Top = (int)(borrowBkCont.Height*0.50588235);
		int borrowBkRtnDateInpFont = (int)(formWidth*0.00885417);
		borrowBkRtnDateInp.Font = new Font("arial",borrowBkRtnDateInpFont);

		borrowBkDueDateLbl.Width = (int)(formWidth*0.13020833);
		borrowBkDueDateLbl.Height = (int)(formHeight*0.04960317);
		borrowBkDueDateLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkDueDateLbl.Top = (int)(borrowBkCont.Height*0.62352941);
		int borrowBkDueDateLblFont = (int)(formWidth*0.00885417);
		borrowBkDueDateLbl.Font = new Font("times new roman",borrowBkDueDateLblFont,FontStyle.Bold);

		borrowBkDueDateInp.Width = (int)(formWidth*0.20833333);
		borrowBkDueDateInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkDueDateInp.Top = (int)(borrowBkCont.Height*0.62352941);
		int borrowBkDueDateInpFont = (int)(formWidth*0.00885417);
		borrowBkDueDateInp.Font = new Font("arial",borrowBkDueDateInpFont);

		borrowBkBkStatusLbl.Width = (int)(formWidth*0.13020833);
		borrowBkBkStatusLbl.Height = (int)(formHeight*0.04960317);
		borrowBkBkStatusLbl.Left = (int)(borrowBkCont.Width*0.08);
		borrowBkBkStatusLbl.Top = (int)(borrowBkCont.Height*0.74117647);
		int borrowBkBkStatusLblFont = (int)(formWidth*0.00885417);
		borrowBkBkStatusLbl.Font = new Font("times new roman",borrowBkBkStatusLblFont,FontStyle.Bold);

		borrowBkBkStatusInp.Width = (int)(formWidth*0.20833333);
		borrowBkBkStatusInp.Left = (int)(borrowBkCont.Width*0.4);
		borrowBkBkStatusInp.Top = (int)(borrowBkCont.Height*0.74117647);
		int borrowBkBkStatusInpFont = (int)(formWidth*0.00885417);
		borrowBkBkStatusInp.Font = new Font("arial",borrowBkBkStatusInpFont);

		borrowBkBrwBtn.Width = (int)(formWidth*0.20833333);
		borrowBkBrwBtn.Height = (int)(formHeight*0.09920635);
		borrowBkBrwBtn.Left = (int)(borrowBkCont.Width*0.3);
		borrowBkBrwBtn.Top = (int)(borrowBkCont.Height*0.82352941);
		int borrowBkBrwBtnFont = (int)(formWidth*0.01041667);
		borrowBkBrwBtn.Font = new Font("arial",borrowBkBrwBtnFont,FontStyle.Bold);

		borrowBkGridTitle.Width = (int)(formWidth*0.234375);
		borrowBkGridTitle.Height = (int)(formHeight*0.03968254);
		borrowBkGridTitle.Left = (int)(brwMainCont.Width*0.3125);
		borrowBkGridTitle.Top = (int)(brwMainCont.Height*0.5);
		int borrowBkGridTitleFont = (int)(formWidth*0.00885417);
		borrowBkGridTitle.Font = new Font("arial",borrowBkGridTitleFont,FontStyle.Bold|FontStyle.Underline);

		borrowBkGridView.Width = (int)(formWidth*0.59895833);
		borrowBkGridView.Height = (int)(formHeight*0.14880952);
		borrowBkGridView.Left = (int)(brwMainCont.Width*0.0390625);
		borrowBkGridView.Top = (int)(brwMainCont.Height*0.625);
		int borrowBkGridViewFont = (int)(formWidth*0.00520833);
		borrowBkGridView.Font = new Font("arial",borrowBkGridViewFont);

	}

	private void brwSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		brwSnvBkMgt.ForeColor = Color.Green;
	}
	private void brwSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		brwSnvBkMgt.ForeColor = Color.Blue;
	}

	private void brwSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		brwSnvMbrMgt.ForeColor = Color.Green;
	}
	private void brwSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		brwSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void brwSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		brwSnvDshBrd.ForeColor = Color.Green;
	}
	private void brwSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		brwSnvDshBrd.ForeColor = Color.Blue;
	}

	private void brwSnvRtn_MouseEnter (object sender, EventArgs e) {
		brwSnvRtn.ForeColor = Color.Green;
	}
	private void brwSnvRtn_MouseLeave (object sender, EventArgs e) {
		brwSnvRtn.ForeColor = Color.Blue;
	}

	private void brwSnvRpt_MouseEnter (object sender, EventArgs e) {
		brwSnvRpt.ForeColor = Color.Green;
	}
	private void brwSnvRpt_MouseLeave (object sender, EventArgs e) {
		brwSnvRpt.ForeColor = Color.Blue;
	}

	private void brwSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		brwSnvUsrStg.ForeColor = Color.Green;
	}
	private void brwSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		brwSnvUsrStg.ForeColor = Color.Blue;
	}

	private void brwSnvSrch_MouseEnter (object sender, EventArgs e) {
		brwSnvSrch.ForeColor = Color.Green;
	}
	private void brwSnvSrch_MouseLeave (object sender, EventArgs e) {
		brwSnvSrch.ForeColor = Color.Blue;
	}

	private void brwMainBkMbrCheckBtn_Clicked (object sender, EventArgs e) {
		try {
			string memberName = brwMainMbrNmInp.Text;
			string bookName = brwMainBkrNmInp.Text;
			if (string.IsNullOrEmpty(memberName) || string.IsNullOrEmpty(bookName)) {
				MessageBox.Show("All Fields Must Be Filled!");
				return;
			}
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string mbrQuery = "SELECT member_Id FROM members WHERE name=@memberName;";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand mbrCommand = new MySqlCommand(mbrQuery,connection);
				mbrCommand.Parameters.AddWithValue("@memberName",memberName);
				connection.Open();
				using (MySqlDataReader mbrReader = mbrCommand.ExecuteReader()) {
					if (mbrReader.Read()) {
						member_id = mbrReader["member_id"].ToString();
						checkBookNameGetId(bookName);
					} else {
						MessageBox.Show("Member Name Invalid!");
					}
				}				
			}
		} catch (Exception ex) {
			MessageBox.Show($"MemberName Check Error: {ex.Message}");
		}
	}

	private void checkBookNameGetId (string bookName) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string bkQuery = "SELECT book_id,status FROM books WHERE title=@bookName";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand bkCommand = new MySqlCommand(bkQuery,connection);
				bkCommand.Parameters.AddWithValue("@bookName",bookName);
				connection.Open();
				using (MySqlDataReader bkReader = bkCommand.ExecuteReader()) {
					if (bkReader.Read()) {
						if (bkReader["status"].ToString() == "borrowed") {
							MessageBox.Show("Book Not Available/Borrowed!");
							return;
						}
						book_id = bkReader["book_id"].ToString();
						borrowBkCont.Show();
						borrowBkMbrIdInp.Text = member_id;
						borrowBkBkIdInp.Text = book_id;
					} else {
						MessageBox.Show("Book Name Invalid!");
					}
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"BookName Check Error: {ex.Message}");
		}
	}

	private void borrowBkCloseBtn_Clicked (object sender, EventArgs e) {
		borrowBkCont.Hide();
		LoadData();
	}

	private void borrowBkBrwBtn_Clicked (object sender, EventArgs e) {
		try {
			DateTime borrow_date = borrowBkBrwDateInp.Value;
			DateTime return_date = borrowBkRtnDateInp.Value;
			DateTime due_date = borrowBkDueDateInp.Value;
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string query = "INSERT INTO transactions(member_id, book_id, borrow_date, return_date, due_date, status) VALUES(@member_id,@book_id,@borrow_date,@return_date,@due_date,'active');";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@member_id",member_id);
				command.Parameters.AddWithValue("@book_id",book_id);
				command.Parameters.AddWithValue("@borrow_date",borrow_date);
				command.Parameters.AddWithValue("@return_date",return_date);
				command.Parameters.AddWithValue("@due_date",due_date);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
					changeBookStatus(book_id);
               				MessageBox.Show("Book Borrowed successfully!");
           			}
            			else {
                			MessageBox.Show("Book Not Borrowed!");
            			}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Borrow Book Error: {ex.Message}");
		}
	}

	private void changeBookStatus (string book_id) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string query = "UPDATE books SET status='borrowed' WHERE book_id=@book_id";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@book_id",book_id);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
					MessageBox.Show("Book Status Updated Successfully!");
				} else {
					MessageBox.Show("Book Status Not Updated!");
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Book Status Update Error: {ex.Message}");
		}
	}

	private void LoadData () {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string query = "SELECT * FROM transactions";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter(query,connection);
				DataTable table = new DataTable();
				adapter.Fill(table);
				borrowBkGridView.DataSource = table;
			}
		} catch (Exception ex) {
			MessageBox.Show($"Load Borrow Data Error: {ex.Message}");
		}
	}

	public static void manageOverdue () {
		try{
			DateTime nowDate = DateTime.Now.Date;
			string currentDate = nowDate.ToString("yyyy-MM-dd");
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string query = "UPDATE transactions SET status='overdue' WHERE due_date > @currentDate AND status != 'overdue'";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@currentDate",currentDate);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				//MessageBox.Show("Status Updated of: "+rowsAffected);
			}
		}catch (Exception ex) {
			MessageBox.Show($"Manage Overdue Error: {ex.Message}");
		}
	}

}
