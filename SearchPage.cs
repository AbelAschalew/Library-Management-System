
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniProjectApp;

public partial class SearchPage : Form
{
	
	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private DashboardPage DashboardForm;
	private MembermanagementPage MembermanagementForm;
	private BorrowPage BorrowForm;
	private ReturnPage ReturnForm;
	private ReportsPage ReportsForm;
	private UsersettingPage UsersettingForm;
	private BookmanagementPage BookmanagementForm;

	private string resourceType;
	private string criteriaType;


    public SearchPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	srchLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


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


	private void srchSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void srchSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void srchSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void srchSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void srchSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void srchSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void srchSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}


	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);
		
		srchHeader.Width = (int)(screenWidth*1);
		srchHeader.Height = (int)(screenHeight*0.1488);
		srchHeader.Left = (int)(screenWidth*0);
		srchHeader.Top = (int)(screenHeight*0);

		srchMainTitle.Width = (int)(screenWidth*0.625);
		srchMainTitle.Height = (int)(screenHeight*0.0793);
		srchMainTitle.Left = (int)(srchHeader.Width*0.1302);
		srchMainTitle.Top = (int)(srchHeader.Height*0);
		int srchMainTitleFont = (int)(screenWidth*0.0166);
		srchMainTitle.Font = new Font("roboto",srchMainTitleFont, FontStyle.Bold);

		srchPgeTitle.Width = (int)(screenWidth*0.625);
		srchPgeTitle.Height = (int)(screenHeight*0.0595);
		srchPgeTitle.Left = (int)(srchHeader.Width*0.1302);
		srchPgeTitle.Top = (int)(srchHeader.Height*0.5666);
		int srchPgeTitleFont = (int)(screenWidth*0.0104);
		srchPgeTitle.Font = new Font("broadway",srchPgeTitleFont);

		srchLogo.Width = (int)(screenWidth*0.0781);
		srchLogo.Height = (int)(screenHeight*0.0892);
		srchLogo.Left = (int)(srchHeader.Width*0.0260);
		srchLogo.Top = (int)(srchHeader.Height*0.2);

		srchSideNav.Width = (int)(screenWidth*0.2604);
		srchSideNav.Height = (int)(screenHeight*0.744);
		srchSideNav.Left = (int)(screenWidth*0.0156);
		srchSideNav.Top = (int)(screenHeight*0.1984);

		srchSnvTitle.Width = (int)(screenWidth*0.2604);
		srchSnvTitle.Height = (int)(screenHeight*0.0892);
		srchSnvTitle.Left = (int)(srchSideNav.Width*0);
		srchSnvTitle.Top = (int)(srchSideNav.Height*0);
		int srchSnvTitleFont = (int)(screenWidth*0.0130);
		srchSnvTitle.Font = new Font("arial",srchSnvTitleFont,FontStyle.Bold);

		srchSnvBkMgt.Width = (int)(screenWidth*0.2083);
		srchSnvBkMgt.Height = (int)(screenHeight*0.0595);
		srchSnvBkMgt.Left = (int)(srchSideNav.Width*0.1);
		srchSnvBkMgt.Top = (int)(srchSideNav.Height*0.16);
		int srchSnvBkMgtFont = (int)(screenWidth*0.0088);
		srchSnvBkMgt.Font = new Font("Verdana",srchSnvBkMgtFont,FontStyle.Underline);

		srchSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		srchSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		srchSnvMbrMgt.Left = (int)(srchSideNav.Width*0.1);
		srchSnvMbrMgt.Top = (int)(srchSideNav.Height*0.2666);
		int srchSnvMbrMgtFont = (int)(screenWidth*0.0088);
		srchSnvMbrMgt.Font = new Font("Verdana",srchSnvMbrMgtFont,FontStyle.Underline);

		srchSnvBrw.Width = (int)(screenWidth*0.2083);
		srchSnvBrw.Height = (int)(screenHeight*0.0595);
		srchSnvBrw.Left = (int)(srchSideNav.Width*0.1);
		srchSnvBrw.Top = (int)(srchSideNav.Height*0.3733);
		int srchSnvBrwFont = (int)(screenWidth*0.0088);
		srchSnvBrw.Font = new Font("Verdana",srchSnvBrwFont,FontStyle.Underline);

		srchSnvRtn.Width = (int)(screenWidth*0.2083);
		srchSnvRtn.Height = (int)(screenHeight*0.0595);
		srchSnvRtn.Left = (int)(srchSideNav.Width*0.1);
		srchSnvRtn.Top = (int)(srchSideNav.Height*0.48);
		int srchSnvRtnFont = (int)(screenWidth*0.0088);
		srchSnvRtn.Font = new Font("Verdana",srchSnvRtnFont,FontStyle.Underline);

		srchSnvRpt.Width = (int)(screenWidth*0.2083);
		srchSnvRpt.Height = (int)(screenHeight*0.0595);
		srchSnvRpt.Left = (int)(srchSideNav.Width*0.1);
		srchSnvRpt.Top = (int)(srchSideNav.Height*0.5866);
		int srchSnvRptFont = (int)(screenWidth*0.0088);
		srchSnvRpt.Font = new Font("Verdana",srchSnvRptFont,FontStyle.Underline);

		srchSnvUsrStg.Width = (int)(screenWidth*0.2083);
		srchSnvUsrStg.Height = (int)(screenHeight*0.0595);
		srchSnvUsrStg.Left = (int)(srchSideNav.Width*0.1);
		srchSnvUsrStg.Top = (int)(srchSideNav.Height*0.6933);
		int srchSnvUsrStgFont = (int)(screenWidth*0.0088);
		srchSnvUsrStg.Font = new Font("Verdana",srchSnvUsrStgFont,FontStyle.Underline);

		srchSnvDshBrd.Width = (int)(screenWidth*0.2083);
		srchSnvDshBrd.Height = (int)(screenHeight*0.0595);
		srchSnvDshBrd.Left = (int)(srchSideNav.Width*0.1);
		srchSnvDshBrd.Top = (int)(srchSideNav.Height*0.8);
		int srchSnvDshBrdFont = (int)(screenWidth*0.0088);
		srchSnvDshBrd.Font = new Font("Verdana",srchSnvDshBrdFont,FontStyle.Underline);

		srchMainCont.Width = (int)(screenWidth*0.6666);
		srchMainCont.Height = (int)(screenHeight*0.7936);
		srchMainCont.Left = (int)(screenWidth*0.3281);
		srchMainCont.Top = (int)(screenHeight*0.1587);

		srchMainCntTitle.Width = (int)(screenWidth*0.234375);
		srchMainCntTitle.Height = (int)(screenHeight*0.05952381);
		srchMainCntTitle.Left = (int)(srchMainCont.Width*0.3515625);
		srchMainCntTitle.Top = (int)(srchMainCont.Height*0.0375);
		int srchMainCntTitleFont = (int)(screenWidth*0.009375);
		srchMainCntTitle.Font = new Font("Verdana",srchMainCntTitleFont,FontStyle.Underline|FontStyle.Bold);

		chseSrchResourceLbl.Width = (int)(screenWidth*0.15625);
		chseSrchResourceLbl.Height = (int)(screenHeight*0.04960317);
		chseSrchResourceLbl.Left = (int)(srchMainCont.Width*0.1171875);
		chseSrchResourceLbl.Top = (int)(srchMainCont.Height*0.1875);
		int chseSrchResourceLblFont = (int)(screenWidth*0.009375);
		chseSrchResourceLbl.Font = new Font("times new roman",chseSrchResourceLblFont,FontStyle.Bold);

		chseSrchResourceInp.Width = (int)(screenWidth*0.11979167);
		chseSrchResourceInp.Height = (int)(screenHeight*0.12896825);
		chseSrchResourceInp.Left = (int)(srchMainCont.Width*0.390625);
		chseSrchResourceInp.Top = (int)(srchMainCont.Height*0.125);
		int chseSrchResourceInpFont = (int)(screenWidth*0.00833333);
		chseSrchResourceInp.Font = new Font("",chseSrchResourceInpFont);

		chseSrchResourceBtn.Width = (int)(screenWidth*0.08854167);
		chseSrchResourceBtn.Height = (int)(screenHeight*0.04960317);
		chseSrchResourceBtn.Left = (int)(srchMainCont.Width*0.6640625);
		chseSrchResourceBtn.Top = (int)(srchMainCont.Height*0.1875);
		int chseSrchResourceBtnFont = (int)(screenWidth*0.00885417);
		chseSrchResourceBtn.Font = new Font("arial",chseSrchResourceBtnFont,FontStyle.Bold);

		chseCriteriaMbrLbl.Width = (int)(screenWidth*0.13020833);
		chseCriteriaMbrLbl.Height = (int)(screenHeight*0.03968254);
		chseCriteriaMbrLbl.Left = (int)(srchMainCont.Width*0.1171875);
		chseCriteriaMbrLbl.Top = (int)(srchMainCont.Height*0.3125);
		int chseCriteriaMbrLblFont = (int)(screenWidth*0.00833333);
		chseCriteriaMbrLbl.Font = new Font("times new roman",chseCriteriaMbrLblFont,FontStyle.Bold);

		chseCriteriaMbrInp.Width = (int)(screenWidth*0.15625);
		chseCriteriaMbrInp.Height = (int)(screenHeight*0.12896825);
		chseCriteriaMbrInp.Left = (int)(srchMainCont.Width*0.390625);
		chseCriteriaMbrInp.Top = (int)(srchMainCont.Height*0.3125);
		int chseCriteriaMbrInpFont = (int)(screenWidth*0.00833333);
		chseCriteriaMbrInp.Font = new Font("",chseCriteriaMbrInpFont);

		chseCriteriaMbrBtn.Width = (int)(screenWidth*0.0859375);
		chseCriteriaMbrBtn.Height = (int)(screenHeight*0.04960317);
		chseCriteriaMbrBtn.Left = (int)(srchMainCont.Width*0.6640625);
		chseCriteriaMbrBtn.Top = (int)(srchMainCont.Height*0.3125);
		int chseCriteriaMbrBtnFont = (int)(screenWidth*0.00885417);
		chseCriteriaMbrBtn.Font = new Font("arial",chseCriteriaMbrBtnFont,FontStyle.Bold);

		searchPhraseLbl.Width = (int)(screenWidth*0.20833333);
		searchPhraseLbl.Height = (int)(screenHeight*0.04960317);
		searchPhraseLbl.Left = (int)(srchMainCont.Width*0.1171875);
		searchPhraseLbl.Top = (int)(srchMainCont.Height*0.5625);
		int searchPhraseLblFont = (int)(screenWidth*0.01041667);
		searchPhraseLbl.Font = new Font("times new roman",searchPhraseLblFont,FontStyle.Bold);

		searchPhraseInp.Width = (int)(screenWidth*0.3125);
		searchPhraseInp.Left = (int)(srchMainCont.Width*0.46875);
		searchPhraseInp.Top = (int)(srchMainCont.Height*0.5625);
		int searchPhraseInpFont = (int)(screenWidth*0.01041667);
		searchPhraseInp.Font = new Font("",searchPhraseInpFont);

		searchBtn.Width = (int)(screenWidth*0.20833333);
		searchBtn.Height = (int)(screenHeight*0.09920635);
		searchBtn.Left = (int)(srchMainCont.Width*0.390625);
		searchBtn.Top = (int)(srchMainCont.Height*0.75);
		int searchBtnFont = (int)(screenWidth*0.01041667);
		searchBtn.Font = new Font("arial",searchBtnFont,FontStyle.Bold);

		srchResultCont.Width = (int)(screenWidth*0.52083333);
		srchResultCont.Height = (int)(screenHeight*0.84325397);
		srchResultCont.Left = (int)(screenWidth*0.23958333);
		srchResultCont.Top = (int)(screenHeight*0.08928571);

		srchResultTitle.Width = (int)(screenWidth*0.26041667);
		srchResultTitle.Height = (int)(screenHeight*0.05952381);
		srchResultTitle.Left = (int)(srchResultCont.Width*0.32);
		srchResultTitle.Top = (int)(srchResultCont.Height*0.03529412);
		int srchResultTitleFont = (int)(screenWidth*0.01197917);
		srchResultTitle.Font = new Font("arial",srchResultTitleFont,FontStyle.Bold|FontStyle.Underline);

		srchResultCloseBtn.Width = (int)(screenWidth*0.03125);
		srchResultCloseBtn.Height = (int)(screenHeight*0.05952381);
		srchResultCloseBtn.Left = (int)(srchResultCont.Width*0.9);
		srchResultCloseBtn.Top = (int)(srchResultCont.Height*0.01176471);
		int srchResultCloseBtnFont = (int)(screenWidth*0.00833333);
		srchResultCloseBtn.Font = new Font("arial",srchResultCloseBtnFont,FontStyle.Bold);

		srchResultCatTitle.Width = (int)(screenWidth*0.15625);
		srchResultCatTitle.Height = (int)(screenHeight*0.03968254);
		srchResultCatTitle.Left = (int)(srchResultCont.Width*0.35);
		srchResultCatTitle.Top = (int)(srchResultCont.Height*0.29411765);
		int srchResultCatTitleFont = (int)(screenWidth*0.0078125);
		srchResultCatTitle.Font = new Font("arial",srchResultCatTitleFont,FontStyle.Bold|FontStyle.Underline);

		srchResultGridView.Width = (int)(screenWidth*0.46875);
		srchResultGridView.Height = (int)(screenHeight*0.14880952);
		srchResultGridView.Left = (int)(srchResultCont.Width*0.05);
		srchResultGridView.Top = (int)(srchResultCont.Height*0.47058824);
		int srchResultGridViewFont = (int)(screenWidth*0.00520833);
		srchResultGridView.Font = new Font("arial",srchResultGridViewFont);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		srchHeader.Width = (int)(formWidth*1);
		srchHeader.Height = (int)(formHeight*0.1488);
		srchHeader.Left = (int)(formWidth*0);
		srchHeader.Top = (int)(formHeight*0);

		srchMainTitle.Width = (int)(formWidth*0.625);
		srchMainTitle.Height = (int)(formHeight*0.0793);
		srchMainTitle.Left = (int)(srchHeader.Width*0.1302);
		srchMainTitle.Top = (int)(srchHeader.Height*0);
		int srchMainTitleFont = (int)(formWidth*0.0166);
		srchMainTitle.Font = new Font("roboto",srchMainTitleFont, FontStyle.Bold);

		srchPgeTitle.Width = (int)(formWidth*0.625);
		srchPgeTitle.Height = (int)(formHeight*0.0595);
		srchPgeTitle.Left = (int)(srchHeader.Width*0.1302);
		srchPgeTitle.Top = (int)(srchHeader.Height*0.5666);
		int srchPgeTitleFont = (int)(formWidth*0.0104);
		srchPgeTitle.Font = new Font("broadway",srchPgeTitleFont);

		srchLogo.Width = (int)(formWidth*0.0781);
		srchLogo.Height = (int)(formHeight*0.0892);
		srchLogo.Left = (int)(srchHeader.Width*0.0260);
		srchLogo.Top = (int)(srchHeader.Height*0.2);

		srchSideNav.Width = (int)(formWidth*0.2604);
		srchSideNav.Height = (int)(formHeight*0.744);
		srchSideNav.Left = (int)(formWidth*0.0156);
		srchSideNav.Top = (int)(formHeight*0.1984);

		srchSnvTitle.Width = (int)(formWidth*0.2604);
		srchSnvTitle.Height = (int)(formHeight*0.0892);
		srchSnvTitle.Left = (int)(srchSideNav.Width*0);
		srchSnvTitle.Top = (int)(srchSideNav.Height*0);
		int srchSnvTitleFont = (int)(formWidth*0.0130);
		srchSnvTitle.Font = new Font("arial",srchSnvTitleFont,FontStyle.Bold);

		srchSnvBkMgt.Width = (int)(formWidth*0.2083);
		srchSnvBkMgt.Height = (int)(formHeight*0.0595);
		srchSnvBkMgt.Left = (int)(srchSideNav.Width*0.1);
		srchSnvBkMgt.Top = (int)(srchSideNav.Height*0.16);
		int srchSnvBkMgtFont = (int)(formWidth*0.0088);
		srchSnvBkMgt.Font = new Font("Verdana",srchSnvBkMgtFont,FontStyle.Underline);

		srchSnvMbrMgt.Width = (int)(formWidth*0.2083);
		srchSnvMbrMgt.Height = (int)(formHeight*0.0595);
		srchSnvMbrMgt.Left = (int)(srchSideNav.Width*0.1);
		srchSnvMbrMgt.Top = (int)(srchSideNav.Height*0.2666);
		int srchSnvMbrMgtFont = (int)(formWidth*0.0088);
		srchSnvMbrMgt.Font = new Font("Verdana",srchSnvMbrMgtFont,FontStyle.Underline);

		srchSnvBrw.Width = (int)(formWidth*0.2083);
		srchSnvBrw.Height = (int)(formHeight*0.0595);
		srchSnvBrw.Left = (int)(srchSideNav.Width*0.1);
		srchSnvBrw.Top = (int)(srchSideNav.Height*0.3733);
		int srchSnvBrwFont = (int)(formWidth*0.0088);
		srchSnvBrw.Font = new Font("Verdana",srchSnvBrwFont,FontStyle.Underline);

		srchSnvRtn.Width = (int)(formWidth*0.2083);
		srchSnvRtn.Height = (int)(formHeight*0.0595);
		srchSnvRtn.Left = (int)(srchSideNav.Width*0.1);
		srchSnvRtn.Top = (int)(srchSideNav.Height*0.48);
		int srchSnvRtnFont = (int)(formWidth*0.0088);
		srchSnvRtn.Font = new Font("Verdana",srchSnvRtnFont,FontStyle.Underline);

		srchSnvRpt.Width = (int)(formWidth*0.2083);
		srchSnvRpt.Height = (int)(formHeight*0.0595);
		srchSnvRpt.Left = (int)(srchSideNav.Width*0.1);
		srchSnvRpt.Top = (int)(srchSideNav.Height*0.5866);
		int srchSnvRptFont = (int)(formWidth*0.0088);
		srchSnvRpt.Font = new Font("Verdana",srchSnvRptFont,FontStyle.Underline);

		srchSnvUsrStg.Width = (int)(formWidth*0.2083);
		srchSnvUsrStg.Height = (int)(formHeight*0.0595);
		srchSnvUsrStg.Left = (int)(srchSideNav.Width*0.1);
		srchSnvUsrStg.Top = (int)(srchSideNav.Height*0.6933);
		int srchSnvUsrStgFont = (int)(formWidth*0.0088);
		srchSnvUsrStg.Font = new Font("Verdana",srchSnvUsrStgFont,FontStyle.Underline);

		srchSnvDshBrd.Width = (int)(formWidth*0.2083);
		srchSnvDshBrd.Height = (int)(formHeight*0.0595);
		srchSnvDshBrd.Left = (int)(srchSideNav.Width*0.1);
		srchSnvDshBrd.Top = (int)(srchSideNav.Height*0.8);
		int srchSnvDshBrdFont = (int)(formWidth*0.0088);
		srchSnvDshBrd.Font = new Font("Verdana",srchSnvDshBrdFont,FontStyle.Underline);

		srchMainCont.Width = (int)(formWidth*0.6666);
		srchMainCont.Height = (int)(formHeight*0.7936);
		srchMainCont.Left = (int)(formWidth*0.3281);
		srchMainCont.Top = (int)(formHeight*0.1587);

		srchMainCntTitle.Width = (int)(formWidth*0.234375);
		srchMainCntTitle.Height = (int)(formHeight*0.05952381);
		srchMainCntTitle.Left = (int)(srchMainCont.Width*0.3515625);
		srchMainCntTitle.Top = (int)(srchMainCont.Height*0.0375);
		int srchMainCntTitleFont = (int)(formWidth*0.009375);
		srchMainCntTitle.Font = new Font("Verdana",srchMainCntTitleFont,FontStyle.Underline|FontStyle.Bold);

		chseSrchResourceLbl.Width = (int)(formWidth*0.15625);
		chseSrchResourceLbl.Height = (int)(formHeight*0.04960317);
		chseSrchResourceLbl.Left = (int)(srchMainCont.Width*0.1171875);
		chseSrchResourceLbl.Top = (int)(srchMainCont.Height*0.1875);
		int chseSrchResourceLblFont = (int)(formWidth*0.009375);
		chseSrchResourceLbl.Font = new Font("times new roman",chseSrchResourceLblFont,FontStyle.Bold);

		chseSrchResourceInp.Width = (int)(formWidth*0.11979167);
		chseSrchResourceInp.Height = (int)(formHeight*0.12896825);
		chseSrchResourceInp.Left = (int)(srchMainCont.Width*0.390625);
		chseSrchResourceInp.Top = (int)(srchMainCont.Height*0.125);
		int chseSrchResourceInpFont = (int)(formWidth*0.00833333);
		chseSrchResourceInp.Font = new Font("",chseSrchResourceInpFont);

		chseSrchResourceBtn.Width = (int)(formWidth*0.08854167);
		chseSrchResourceBtn.Height = (int)(formHeight*0.04960317);
		chseSrchResourceBtn.Left = (int)(srchMainCont.Width*0.6640625);
		chseSrchResourceBtn.Top = (int)(srchMainCont.Height*0.1875);
		int chseSrchResourceBtnFont = (int)(formWidth*0.00885417);
		chseSrchResourceBtn.Font = new Font("arial",chseSrchResourceBtnFont,FontStyle.Bold);

		chseCriteriaMbrLbl.Width = (int)(formWidth*0.13020833);
		chseCriteriaMbrLbl.Height = (int)(formHeight*0.03968254);
		chseCriteriaMbrLbl.Left = (int)(srchMainCont.Width*0.1171875);
		chseCriteriaMbrLbl.Top = (int)(srchMainCont.Height*0.3125);
		int chseCriteriaMbrLblFont = (int)(formWidth*0.00833333);
		chseCriteriaMbrLbl.Font = new Font("times new roman",chseCriteriaMbrLblFont,FontStyle.Bold);

		chseCriteriaMbrInp.Width = (int)(formWidth*0.15625);
		chseCriteriaMbrInp.Height = (int)(formHeight*0.12896825);
		chseCriteriaMbrInp.Left = (int)(srchMainCont.Width*0.390625);
		chseCriteriaMbrInp.Top = (int)(srchMainCont.Height*0.3125);
		int chseCriteriaMbrInpFont = (int)(formWidth*0.00833333);
		chseCriteriaMbrInp.Font = new Font("",chseCriteriaMbrInpFont);

		chseCriteriaMbrBtn.Width = (int)(formWidth*0.0859375);
		chseCriteriaMbrBtn.Height = (int)(formHeight*0.04960317);
		chseCriteriaMbrBtn.Left = (int)(srchMainCont.Width*0.6640625);
		chseCriteriaMbrBtn.Top = (int)(srchMainCont.Height*0.3125);
		int chseCriteriaMbrBtnFont = (int)(formWidth*0.00885417);
		chseCriteriaMbrBtn.Font = new Font("arial",chseCriteriaMbrBtnFont,FontStyle.Bold);

		searchPhraseLbl.Width = (int)(formWidth*0.20833333);
		searchPhraseLbl.Height = (int)(formHeight*0.04960317);
		searchPhraseLbl.Left = (int)(srchMainCont.Width*0.1171875);
		searchPhraseLbl.Top = (int)(srchMainCont.Height*0.5625);
		int searchPhraseLblFont = (int)(formWidth*0.01041667);
		searchPhraseLbl.Font = new Font("times new roman",searchPhraseLblFont,FontStyle.Bold);

		searchPhraseInp.Width = (int)(formWidth*0.3125);
		searchPhraseInp.Left = (int)(srchMainCont.Width*0.46875);
		searchPhraseInp.Top = (int)(srchMainCont.Height*0.5625);
		int searchPhraseInpFont = (int)(formWidth*0.01041667);
		searchPhraseInp.Font = new Font("",searchPhraseInpFont);

		searchBtn.Width = (int)(formWidth*0.20833333);
		searchBtn.Height = (int)(formHeight*0.09920635);
		searchBtn.Left = (int)(srchMainCont.Width*0.390625);
		searchBtn.Top = (int)(srchMainCont.Height*0.75);
		int searchBtnFont = (int)(formWidth*0.01041667);
		searchBtn.Font = new Font("arial",searchBtnFont,FontStyle.Bold);

		srchResultCont.Width = (int)(formWidth*0.52083333);
		srchResultCont.Height = (int)(formHeight*0.84325397);
		srchResultCont.Left = (int)(formWidth*0.23958333);
		srchResultCont.Top = (int)(formHeight*0.08928571);

		srchResultTitle.Width = (int)(formWidth*0.26041667);
		srchResultTitle.Height = (int)(formHeight*0.05952381);
		srchResultTitle.Left = (int)(srchResultCont.Width*0.32);
		srchResultTitle.Top = (int)(srchResultCont.Height*0.0375);
		int srchResultTitleFont = (int)(formWidth*0.01197917);
		srchResultTitle.Font = new Font("arial",srchResultTitleFont,FontStyle.Bold|FontStyle.Underline);

		srchResultCloseBtn.Width = (int)(formWidth*0.03125);
		srchResultCloseBtn.Height = (int)(formHeight*0.05952381);
		srchResultCloseBtn.Left = (int)(srchResultCont.Width*0.9);
		srchResultCloseBtn.Top = (int)(srchResultCont.Height*0.01176471);
		int srchResultCloseBtnFont = (int)(formWidth*0.00833333);
		srchResultCloseBtn.Font = new Font("arial",srchResultCloseBtnFont,FontStyle.Bold);

		srchResultCatTitle.Width = (int)(formWidth*0.15625);
		srchResultCatTitle.Height = (int)(formHeight*0.03968254);
		srchResultCatTitle.Left = (int)(srchResultCont.Width*0.35);
		srchResultCatTitle.Top = (int)(srchResultCont.Height*0.29411765);
		int srchResultCatTitleFont = (int)(formWidth*0.0078125);
		srchResultCatTitle.Font = new Font("arial",srchResultCatTitleFont,FontStyle.Bold|FontStyle.Underline);

		srchResultGridView.Width = (int)(formWidth*0.46875);
		srchResultGridView.Height = (int)(formHeight*0.14880952);
		srchResultGridView.Left = (int)(srchResultCont.Width*0.05);
		srchResultGridView.Top = (int)(srchResultCont.Height*0.47058824);
		int srchResultGridViewFont = (int)(formWidth*0.00520833);
		srchResultGridView.Font = new Font("arial",srchResultGridViewFont);

	}

	private void srchSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		srchSnvBkMgt.ForeColor = Color.Green;
	}
	private void srchSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		srchSnvBkMgt.ForeColor = Color.Blue;
	}

	private void srchSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		srchSnvMbrMgt.ForeColor = Color.Green;
	}
	private void srchSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		srchSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void srchSnvBrw_MouseEnter (object sender, EventArgs e) {
		srchSnvBrw.ForeColor = Color.Green;
	}
	private void srchSnvBrw_MouseLeave (object sender, EventArgs e) {
		srchSnvBrw.ForeColor = Color.Blue;
	}

	private void srchSnvRtn_MouseEnter (object sender, EventArgs e) {
		srchSnvRtn.ForeColor = Color.Green;
	}
	private void srchSnvRtn_MouseLeave (object sender, EventArgs e) {
		srchSnvRtn.ForeColor = Color.Blue;
	}

	private void srchSnvRpt_MouseEnter (object sender, EventArgs e) {
		srchSnvRpt.ForeColor = Color.Green;
	}
	private void srchSnvRpt_MouseLeave (object sender, EventArgs e) {
		srchSnvRpt.ForeColor = Color.Blue;
	}

	private void srchSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		srchSnvUsrStg.ForeColor = Color.Green;
	}
	private void srchSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		srchSnvUsrStg.ForeColor = Color.Blue;
	}

	private void srchSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		srchSnvDshBrd.ForeColor = Color.Green;
	}
	private void srchSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		srchSnvDshBrd.ForeColor = Color.Blue;
	}

	private void chseSrchResourceBtn_Clicked (object sender, EventArgs e) {
		chseCriteriaMbrInp.Items.Clear();
		if (chseSrchResourceInp.SelectedItem.ToString() == "Member") {
			chseCriteriaMbrInp.Items.Add("By Member ID");
			chseCriteriaMbrInp.Items.Add("By Name");
			chseCriteriaMbrInp.Items.Add("By Phone Number");
			resourceType = "Member";
			chseCriteriaMbrLbl.Show();
			chseCriteriaMbrInp.Show();
			chseCriteriaMbrBtn.Show();
		} else if (chseSrchResourceInp.SelectedItem.ToString() == "Book") {
			chseCriteriaMbrInp.Items.Add("By Title");
			chseCriteriaMbrInp.Items.Add("By Author");
			chseCriteriaMbrInp.Items.Add("By ISBN");
			resourceType = "Book";
			chseCriteriaMbrLbl.Show();
			chseCriteriaMbrInp.Show();
			chseCriteriaMbrBtn.Show();
		} else {
			chseCriteriaMbrInp.Items.Add("By Transaction ID");
			chseCriteriaMbrInp.Items.Add("By Member ID");
			chseCriteriaMbrInp.Items.Add("By Book ID");
			resourceType = "Transaction";
			chseCriteriaMbrLbl.Show();
			chseCriteriaMbrInp.Show();
			chseCriteriaMbrBtn.Show();
		}
	}

	private void chseCriteriaMbrBtn_Clicked (object sender, EventArgs e) {
		criteriaType = chseCriteriaMbrInp.SelectedItem.ToString();
		searchPhraseLbl.Show();
		searchPhraseInp.Show();
		searchBtn.Show();
	}

	private void srchResultCloseBtn_Clicked (object sender, EventArgs e) {
		srchResultCont.Hide();
	}

	private void searchBtn_Clicked (object sender, EventArgs e) {
		string query;
		srchResultCatTitle.Text = resourceType+" Data";
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string searchPhrase = searchPhraseInp.Text;
			if (string.IsNullOrEmpty(searchPhrase)) {
				MessageBox.Show("Search Field Must Not Be Empty!");
				return;
			}
			if (resourceType == "Member") {
				if (criteriaType == "By Member ID") {
					query = "SELECT * FROM members WHERE member_id=@searchPhrase";
				} else if (criteriaType == "By Name") {
					query = "SELECT * FROM members where name=@searchPhrase";
				} else {
					query = "SELECT * FROM members where phone_number=@searchPhrase";
				}
			} else if (resourceType == "Book") {
				if (criteriaType == "By Title") {
					query = "SELECT * FROM books where title=@searchPhrase";
				} else if (criteriaType == "By Author") {
					query = "SELECT * FROM books where author=@searchPhrase";
				} else {
					query = "SELECT * FROM books where isbn=@searchPhrase";
				}
			} else {
				if (criteriaType == "By Transaction ID") {
					query = "SELECT * FROM transactions where transaction_id=@searchPhrase";
				} else if (criteriaType == "By Member ID") {
					query = "SELECT * FROM transactions where member_id=@searchPhrase";
				} else {
					query = "SELECT * FROM transactions where book_id=@searchPhrase";
				}
			}
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter();
				adapter.SelectCommand = new MySqlCommand(query,connection);
				adapter.SelectCommand.Parameters.AddWithValue("@searchPhrase",searchPhrase);
				DataTable table = new DataTable();
				adapter.Fill(table);
				if (table.Rows.Count == 0) {
					MessageBox.Show("No Record Found With This Search Phrase!");
				} else {
					srchResultGridView.DataSource = table;
					srchResultCont.Show();
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Search Record Error: {ex.Message}");
		}
	}

}
