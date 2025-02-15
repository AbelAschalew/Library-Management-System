
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniProjectApp;

public partial class DashboardPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private BookmanagementPage BookmanagementForm;
	private MembermanagementPage MembermanagementForm;
	private BorrowPage BorrowForm;
	private ReturnPage ReturnForm;
	private ReportsPage ReportsForm;
	private UsersettingPage UsersettingForm;
	private SearchPage SearchForm;
	private HomePage HomeForm;

    public DashboardPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	dsbrdLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");

	this.Icon = EmbeddedFormIconLoader.LoadFormIcon("MiniProjectApp.Resources.cruiseFavicon.ico");
	this.BackgroundImage = EmbeddedBackgroundImageLoader.backgroundImageLoader("MiniProjectApp.Resources.formbackgroundImage.jpg");


	this.FormClosed += (sender,e) => Application.Exit();

	this.Resize += AdjustSizePosition;


    }

	private TForm NavigateTo<TForm>(TForm formInstance) where TForm : Form, new() {
		if (formInstance == null || formInstance.IsDisposed) {
        		formInstance = new TForm();
        		formInstance.FormClosed += (s, e) => formInstance = null; // Reset reference
    		}

    		this.Hide();
    		formInstance.Show();

    		return formInstance; // Return the updated instance
	}

	private void dsbrdSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void dsbrdSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void dsbrdSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void dsbrdSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void dsbrdSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void dsbrdSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void dsbrdSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}



	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		dataGridView1.KeyDown += dataGridView1_KeyDown;

		onloadMainContent();
		hideSomeControls();

		dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

		BorrowPage.manageOverdue();


		dsbrdHeader.Width = (int)(screenWidth*1);
		dsbrdHeader.Height = (int)(screenHeight*0.1488);
		dsbrdHeader.Left = (int)(screenWidth*0);
		dsbrdHeader.Top = (int)(screenHeight*0);

		dsbrdMainTitle.Width = (int)(screenWidth*0.625);
		dsbrdMainTitle.Height = (int)(screenHeight*0.0793);
		dsbrdMainTitle.Left = (int)(dsbrdHeader.Width*0.1302);
		dsbrdMainTitle.Top = (int)(dsbrdHeader.Height*0);
		int dsbrdMainTitleFont = (int)(screenWidth*0.0166);
		dsbrdMainTitle.Font = new Font("roboto",dsbrdMainTitleFont, FontStyle.Bold);

		dsbrdPgeTitle.Width = (int)(screenWidth*0.625);
		dsbrdPgeTitle.Height = (int)(screenHeight*0.0595);
		dsbrdPgeTitle.Left = (int)(dsbrdHeader.Width*0.1302);
		dsbrdPgeTitle.Top = (int)(dsbrdHeader.Height*0.5666);
		int dsbrdPgeTitleFont = (int)(screenWidth*0.0104);
		dsbrdPgeTitle.Font = new Font("broadway",dsbrdPgeTitleFont);

		dsbrdLogo.Width = (int)(screenWidth*0.0781);
		dsbrdLogo.Height = (int)(screenHeight*0.0892);
		dsbrdLogo.Left = (int)(dsbrdHeader.Width*0.0260);
		dsbrdLogo.Top = (int)(dsbrdHeader.Height*0.2);

		logoutBtn.Width = (int)(screenWidth*0.1302);
		logoutBtn.Height = (int)(screenHeight*0.0793);
		logoutBtn.Left = (int)(dsbrdHeader.Width*0.8333);
		logoutBtn.Top = (int)(dsbrdHeader.Height*0.2333);
		int logoutBtnFont = (int)(screenWidth*0.0083);
		logoutBtn.Font = new Font("arial",logoutBtnFont,FontStyle.Bold);

		dsbrdSideNav.Width = (int)(screenWidth*0.2604);
		dsbrdSideNav.Height = (int)(screenHeight*0.744);
		dsbrdSideNav.Left = (int)(screenWidth*0.0156);
		dsbrdSideNav.Top = (int)(screenHeight*0.1984);

		dsbrdSnvTitle.Width = (int)(screenWidth*0.2604);
		dsbrdSnvTitle.Height = (int)(screenHeight*0.0892);
		dsbrdSnvTitle.Left = (int)(dsbrdSideNav.Width*0);
		dsbrdSnvTitle.Top = (int)(dsbrdSideNav.Height*0);
		int dsbrdSnvTitleFont = (int)(screenWidth*0.0130);
		dsbrdSnvTitle.Font = new Font("arial",dsbrdSnvTitleFont,FontStyle.Bold);

		dsbrdSnvBkMgt.Width = (int)(screenWidth*0.2083);
		dsbrdSnvBkMgt.Height = (int)(screenHeight*0.0595);
		dsbrdSnvBkMgt.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvBkMgt.Top = (int)(dsbrdSideNav.Height*0.16);
		int dsbrdSnvBkMgtFont = (int)(screenWidth*0.0088);
		dsbrdSnvBkMgt.Font = new Font("Verdana",dsbrdSnvBkMgtFont,FontStyle.Underline);

		dsbrdSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		dsbrdSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		dsbrdSnvMbrMgt.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvMbrMgt.Top = (int)(dsbrdSideNav.Height*0.2666);
		int dsbrdSnvMbrMgtFont = (int)(screenWidth*0.0088);
		dsbrdSnvMbrMgt.Font = new Font("Verdana",dsbrdSnvMbrMgtFont,FontStyle.Underline);

		dsbrdSnvBrw.Width = (int)(screenWidth*0.2083);
		dsbrdSnvBrw.Height = (int)(screenHeight*0.0595);
		dsbrdSnvBrw.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvBrw.Top = (int)(dsbrdSideNav.Height*0.3733);
		int dsbrdSnvBrwFont = (int)(screenWidth*0.0088);
		dsbrdSnvBrw.Font = new Font("Verdana",dsbrdSnvBrwFont,FontStyle.Underline);

		dsbrdSnvRtn.Width = (int)(screenWidth*0.2083);
		dsbrdSnvRtn.Height = (int)(screenHeight*0.0595);
		dsbrdSnvRtn.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvRtn.Top = (int)(dsbrdSideNav.Height*0.48);
		int dsbrdSnvRtnFont = (int)(screenWidth*0.0088);
		dsbrdSnvRtn.Font = new Font("Verdana",dsbrdSnvRtnFont,FontStyle.Underline);

		dsbrdSnvRpt.Width = (int)(screenWidth*0.2083);
		dsbrdSnvRpt.Height = (int)(screenHeight*0.0595);
		dsbrdSnvRpt.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvRpt.Top = (int)(dsbrdSideNav.Height*0.5866);
		int dsbrdSnvRptFont = (int)(screenWidth*0.0088);
		dsbrdSnvRpt.Font = new Font("Verdana",dsbrdSnvRptFont,FontStyle.Underline);

		dsbrdSnvUsrStg.Width = (int)(screenWidth*0.2083);
		dsbrdSnvUsrStg.Height = (int)(screenHeight*0.0595);
		dsbrdSnvUsrStg.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvUsrStg.Top = (int)(dsbrdSideNav.Height*0.6933);
		int dsbrdSnvUsrStgFont = (int)(screenWidth*0.0088);
		dsbrdSnvUsrStg.Font = new Font("Verdana",dsbrdSnvUsrStgFont,FontStyle.Underline);

		dsbrdSnvSrch.Width = (int)(screenWidth*0.2083);
		dsbrdSnvSrch.Height = (int)(screenHeight*0.0595);
		dsbrdSnvSrch.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvSrch.Top = (int)(dsbrdSideNav.Height*0.8);
		int dsbrdSnvSrchFont = (int)(screenWidth*0.0088);
		dsbrdSnvSrch.Font = new Font("Verdana",dsbrdSnvSrchFont,FontStyle.Underline);

		dsbrdMainCont.Width = (int)(screenWidth*0.6666);
		dsbrdMainCont.Height = (int)(screenHeight*0.7936);
		dsbrdMainCont.Left = (int)(screenWidth*0.3281);
		dsbrdMainCont.Top = (int)(screenHeight*0.1587);

		mainCntGreet.Left = (int)(dsbrdMainCont.Width*0.0390);
		mainCntGreet.Top = (int)(dsbrdMainCont.Height*0.0625);
		int mainCntGreetFont = (int)(screenWidth*0.0083);
		mainCntGreet.Font = new Font("verdana",mainCntGreetFont,FontStyle.Bold);

		mainSttTitle.Left = (int)(dsbrdMainCont.Width*0.390625);
		mainSttTitle.Top = (int)(dsbrdMainCont.Height*0.225);
		int mainSttTitleFont = (int)(screenWidth*0.013020);
		mainSttTitle.Font = new Font("times new roman",mainSttTitleFont,FontStyle.Bold|FontStyle.Underline);

		mainSttNmBkLbl.Width = (int)(screenWidth*0.234375);
		mainSttNmBkLbl.Height = (int)(screenHeight*0.07936508);
		mainSttNmBkLbl.Left = (int)(dsbrdMainCont.Width*0.3125);
		mainSttNmBkLbl.Top = (int)(dsbrdMainCont.Height*0.375);
		int mainSttNmBkLblFont = (int)(screenWidth*0.009375);
		mainSttNmBkLbl.Font = new Font("times new roman",mainSttNmBkLblFont);

		mainSttNmBkVal.Width = (int)(screenWidth*0.05208333);
		mainSttNmBkVal.Height = (int)(screenHeight*0.07936508);
		mainSttNmBkVal.Left = (int)(dsbrdMainCont.Width*0.703125);
		mainSttNmBkVal.Top = (int)(dsbrdMainCont.Height*0.375);
		int mainSttNmBkValFont = (int)(screenWidth*0.009375);
		mainSttNmBkVal.Font = new Font("times new roman",mainSttNmBkValFont,FontStyle.Bold);

		mainSttNmMbrLbl.Width = (int)(screenWidth*0.234375);
		mainSttNmMbrLbl.Height = (int)(screenHeight*0.07936508);
		mainSttNmMbrLbl.Left = (int)(dsbrdMainCont.Width*0.3125);
		mainSttNmMbrLbl.Top = (int)(dsbrdMainCont.Height*0.5);
		int mainSttNmMbrLblFont = (int)(screenWidth*0.009375);
		mainSttNmMbrLbl.Font = new Font("times new roman",mainSttNmMbrLblFont);

		mainSttNmMbrVal.Width = (int)(screenWidth*0.05208333);
		mainSttNmMbrVal.Height = (int)(screenHeight*0.07936508);
		mainSttNmMbrVal.Left = (int)(dsbrdMainCont.Width*0.703125);
		mainSttNmMbrVal.Top = (int)(dsbrdMainCont.Height*0.5);
		int mainSttNmMbrValFont = (int)(screenWidth*0.009375);
		mainSttNmMbrVal.Font = new Font("times new roman",mainSttNmMbrValFont,FontStyle.Bold);

		mainSttOvrBkLbl.Width = (int)(screenWidth*0.234375);
		mainSttOvrBkLbl.Height = (int)(screenHeight*0.07936508);
		mainSttOvrBkLbl.Left = (int)(dsbrdMainCont.Width*0.3125);
		mainSttOvrBkLbl.Top = (int)(dsbrdMainCont.Height*0.625);
		int mainSttOvrBkLblFont = (int)(screenWidth*0.009375);
		mainSttOvrBkLbl.Font = new Font("times new roman",mainSttOvrBkLblFont);

		mainSttOvrBkVal.Width = (int)(screenWidth*0.05208333);
		mainSttOvrBkVal.Height = (int)(screenHeight*0.07936508);
		mainSttOvrBkVal.Left = (int)(dsbrdMainCont.Width*0.703125);
		mainSttOvrBkVal.Top = (int)(dsbrdMainCont.Height*0.625);
		int mainSttOvrBkValFont = (int)(screenWidth*0.009375);
		mainSttOvrBkVal.Font = new Font("times new roman",mainSttOvrBkValFont,FontStyle.Bold);

		adminMngUsrBtn.Width = (int)(screenWidth*0.26041667);
		adminMngUsrBtn.Height = (int)(screenHeight*0.09920635);
		adminMngUsrBtn.Left = (int)(dsbrdMainCont.Width*0.15625);
		adminMngUsrBtn.Top = (int)(dsbrdMainCont.Height*0.8125);
		int adminMngUsrBtnFont = (int)(screenWidth*0.009375);
		adminMngUsrBtn.Font = new Font("arial",adminMngUsrBtnFont,FontStyle.Bold);

		mngUsrChseCont.Width = (int)(screenWidth*0.72916667);
		mngUsrChseCont.Height = (int)(screenHeight*0.89285714);
		mngUsrChseCont.Left = (int)(screenWidth*0.13020833);
		mngUsrChseCont.Top = (int)(screenHeight*0.04960317);

		mngUsrTitle.Width = (int)(screenWidth*0.15625);
		mngUsrTitle.Height = (int)(screenHeight*0.07936508);
		mngUsrTitle.Left = (int)(mngUsrChseCont.Width*0.39285714);
		mngUsrTitle.Top = (int)(mngUsrChseCont.Height*0.05555556);
		int mngUsrTitleFont = (int)(screenWidth*0.00885417);
		mngUsrTitle.Font = new Font("times new roman",mngUsrTitleFont,FontStyle.Bold|FontStyle.Underline);

		mngUsrContClose.Width = (int)(screenWidth*0.03645833);
		mngUsrContClose.Height = (int)(screenHeight*0.06944444);
		mngUsrContClose.Left = (int)(mngUsrChseCont.Width*0.92857143);
		mngUsrContClose.Top = (int)(mngUsrChseCont.Height*0.01111111);
		int mngUsrContCloseFont = (int)(screenWidth*0.01197917);
		mngUsrContClose.Font = new Font("arial",mngUsrContCloseFont,FontStyle.Bold);

		mngUsrNmUsrLbl.Width = (int)(screenWidth*0.18229167);
		mngUsrNmUsrLbl.Height = (int)(screenHeight*0.07936508);
		mngUsrNmUsrLbl.Left = (int)(mngUsrChseCont.Width*0.21428571);
		mngUsrNmUsrLbl.Top = (int)(mngUsrChseCont.Height*0.14544444);
		int mngUsrNmUsrLblFont = (int)(screenWidth*0.00853333);
		mngUsrNmUsrLbl.Font = new Font("times new roman",mngUsrNmUsrLblFont,FontStyle.Bold);

		mngUsrNmUsrVal.Width = (int)(screenWidth*0.05208333);
		mngUsrNmUsrVal.Height = (int)(screenHeight*0.07936508);
		mngUsrNmUsrVal.Left = (int)(mngUsrChseCont.Width*0.47857143);
		mngUsrNmUsrVal.Top = (int)(mngUsrChseCont.Height*0.12222222);
		int mngUsrNmUsrValFont = (int)(screenWidth*0.009575);
		mngUsrNmUsrVal.Font = new Font("times new roman",mngUsrNmUsrValFont,FontStyle.Bold);

		mngUsrActivateMng.Width = (int)(screenWidth*0.10416667);
		mngUsrActivateMng.Height = (int)(screenHeight*0.07936508);
		mngUsrActivateMng.Left = (int)(mngUsrChseCont.Width*0.28571429);
		mngUsrActivateMng.Top = (int)(mngUsrChseCont.Height*0.25555556);
		int mngUsrActivateMngFont = (int)(screenWidth*0.00729167);
		mngUsrActivateMng.Font = new Font("arial",mngUsrActivateMngFont,FontStyle.Bold);

		mngUsrActivateLbl.Width = (int)(screenWidth*0.20833333);
		mngUsrActivateLbl.Height = (int)(screenHeight*0.05952381);
		mngUsrActivateLbl.Left = (int)(mngUsrChseCont.Width*0.25);
		mngUsrActivateLbl.Top = (int)(mngUsrChseCont.Height*0.35555556);
		int mngUsrActivateLblFont = (int)(screenWidth*0.00625);
		mngUsrActivateLbl.Font = new Font("arial",mngUsrActivateLblFont,FontStyle.Bold);

		mngUsrAddBtn.Width = (int)(screenWidth*0.10416667);
		mngUsrAddBtn.Height = (int)(screenHeight*0.07936508);
		mngUsrAddBtn.Left = (int)(mngUsrChseCont.Width*0.57142857);
		mngUsrAddBtn.Top = (int)(mngUsrChseCont.Height*0.25555556);
		int mngUsrAddBtnFont = (int)(screenWidth*0.00729167);
		mngUsrAddBtn.Font = new Font("arial",mngUsrAddBtnFont,FontStyle.Bold);

		dataGridView1.Width = (int)(screenWidth*0.41666667);
		dataGridView1.Height = (int)(screenHeight*0.14880952);
		dataGridView1.Left = (int)(mngUsrChseCont.Width*0.21428571);
		dataGridView1.Top = (int)(mngUsrChseCont.Height*0.44444444);
		int dataGridView1Font = (int)(screenWidth*0.00520833);
		dataGridView1.Font = new Font("arial",dataGridView1Font);

		mngUsrAddCont.Width = (int)(screenWidth*0.52083333);
		mngUsrAddCont.Height = (int)(screenHeight*0.84325397);
		mngUsrAddCont.Left = (int)(screenWidth*0.20833333);
		mngUsrAddCont.Top = (int)(screenHeight*0.08928571);

		mngUsrAddTitle.Width = (int)(screenWidth*0.18229167);
		mngUsrAddTitle.Height = (int)(screenHeight*0.05952381);
		mngUsrAddTitle.Left = (int)(mngUsrAddCont.Width*0.35);
		mngUsrAddTitle.Top = (int)(mngUsrAddCont.Height*0.03529412);
		int mngUsrAddTitleFont = (int)(screenWidth*0.01197917);
		mngUsrAddTitle.Font = new Font("arial",mngUsrAddTitleFont,FontStyle.Bold|FontStyle.Underline);

		mngUsrAddCloseBtn.Width = (int)(screenWidth*0.02604167);
		mngUsrAddCloseBtn.Height = (int)(screenHeight*0.04960317);
		mngUsrAddCloseBtn.Left = (int)(mngUsrAddCont.Width*0.93);
		mngUsrAddCloseBtn.Top = (int)(mngUsrAddCont.Height*0.01176471);
		int mngUsrAddCloseBtnFont = (int)(screenWidth*0.00833333);
		mngUsrAddCloseBtn.Font = new Font("arial",mngUsrAddCloseBtnFont,FontStyle.Bold);

		addUsrnmLbl.Width = (int)(screenWidth*0.13020833);
		addUsrnmLbl.Height = (int)(screenHeight*0.04960317);
		addUsrnmLbl.Left = (int)(mngUsrAddCont.Width*0.08);
		addUsrnmLbl.Top = (int)(mngUsrAddCont.Height*0.27058824);
		int addUsrnmLblFont = (int)(screenWidth*0.01041667);
		addUsrnmLbl.Font = new Font("times new roman",addUsrnmLblFont,FontStyle.Bold);

		addUsrnmVal.Width = (int)(screenWidth*0.20833333);
		addUsrnmVal.Left = (int)(mngUsrAddCont.Width*0.4);
		addUsrnmVal.Top = (int)(mngUsrAddCont.Height*0.27058824);
		int addUsrnmValFont = (int)(screenWidth*0.01041667);
		addUsrnmVal.Font = new Font("arial",addUsrnmValFont);

		addPswdLbl.Width = (int)(screenWidth*0.13020833);
		addPswdLbl.Height = (int)(screenHeight*0.04960317);
		addPswdLbl.Left = (int)(mngUsrAddCont.Width*0.08);
		addPswdLbl.Top = (int)(mngUsrAddCont.Height*0.42352941);
		int addPswdLblFont = (int)(screenWidth*0.01041667);
		addPswdLbl.Font = new Font("times new roman",addPswdLblFont,FontStyle.Bold);

		addPswdVal.Width = (int)(screenWidth*0.20833333);
		addPswdVal.Left = (int)(mngUsrAddCont.Width*0.4);
		addPswdVal.Top = (int)(mngUsrAddCont.Height*0.42352941);
		int addPswdValFont = (int)(screenWidth*0.01041667);
		addPswdVal.Font = new Font("arial",addPswdValFont);

		addRoleLbl.Width = (int)(screenWidth*0.13020833);
		addRoleLbl.Height = (int)(screenHeight*0.04960317);
		addRoleLbl.Left = (int)(mngUsrAddCont.Width*0.08);
		addRoleLbl.Top = (int)(mngUsrAddCont.Height*0.57647059);
		int addRoleLblFont = (int)(screenWidth*0.01041667);
		addRoleLbl.Font = new Font("times new roman",addRoleLblFont,FontStyle.Bold);

		addRoleVal.Width = (int)(screenWidth*0.20833333);
		addRoleVal.Left = (int)(mngUsrAddCont.Width*0.4);
		addRoleVal.Top = (int)(mngUsrAddCont.Height*0.57647059);
		int addRoleValFont = (int)(screenWidth*0.01041667);
		addRoleVal.Font = new Font("arial",addRoleValFont);

		addUsrBtn.Width = (int)(screenWidth*0.20833333);
		addUsrBtn.Height = (int)(screenHeight*0.09920635);
		addUsrBtn.Left = (int)(mngUsrAddCont.Width*0.3);
		addUsrBtn.Top = (int)(mngUsrAddCont.Height*0.76470588);
		int addUsrBtnFont = (int)(screenWidth*0.01041667);
		addUsrBtn.Font = new Font("arial",addUsrBtnFont,FontStyle.Bold);

		nonAdminMsg.Width = (int)(screenWidth*0.26041667);
		nonAdminMsg.Height = (int)(screenHeight*0.09920635);
		nonAdminMsg.Left = (int)(mngUsrAddCont.Width*0.15625);
		nonAdminMsg.Top = (int)(mngUsrAddCont.Height*0.81);
		int nonAdminMsgFont = (int)(screenWidth*0.009375);
		nonAdminMsg.Font = new Font("arial",nonAdminMsgFont,FontStyle.Bold);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		dsbrdHeader.Width = (int)(formWidth*1);
		dsbrdHeader.Height = (int)(formHeight*0.1488);
		dsbrdHeader.Left = (int)(formWidth*0);
		dsbrdHeader.Top = (int)(formHeight*0);

		dsbrdMainTitle.Width = (int)(formWidth*0.625);
		dsbrdMainTitle.Height = (int)(formHeight*0.0793);
		dsbrdMainTitle.Left = (int)(dsbrdHeader.Width*0.1302);
		dsbrdMainTitle.Top = (int)(dsbrdHeader.Height*0);
		int dsbrdMainTitleFont = (int)(formWidth*0.0166);
		dsbrdMainTitle.Font = new Font("roboto",dsbrdMainTitleFont, FontStyle.Bold);

		dsbrdPgeTitle.Width = (int)(formWidth*0.625);
		dsbrdPgeTitle.Height = (int)(formHeight*0.0595);
		dsbrdPgeTitle.Left = (int)(dsbrdHeader.Width*0.1302);
		dsbrdPgeTitle.Top = (int)(dsbrdHeader.Height*0.5666);
		int dsbrdPgeTitleFont = (int)(formWidth*0.0104);
		dsbrdPgeTitle.Font = new Font("broadway",dsbrdPgeTitleFont);

		dsbrdLogo.Width = (int)(formWidth*0.0781);
		dsbrdLogo.Height = (int)(formHeight*0.0892);
		dsbrdLogo.Left = (int)(dsbrdHeader.Width*0.0260);
		dsbrdLogo.Top = (int)(dsbrdHeader.Height*0.2);

		logoutBtn.Width = (int)(formWidth*0.1302);
		logoutBtn.Height = (int)(formHeight*0.0793);
		logoutBtn.Left = (int)(dsbrdHeader.Width*0.8333);
		logoutBtn.Top = (int)(dsbrdHeader.Height*0.2333);
		int logoutBtnFont = (int)(formWidth*0.0083);
		logoutBtn.Font = new Font("arial",logoutBtnFont,FontStyle.Bold);

		dsbrdSideNav.Width = (int)(formWidth*0.2604);
		dsbrdSideNav.Height = (int)(formHeight*0.744);
		dsbrdSideNav.Left = (int)(formWidth*0.0156);
		dsbrdSideNav.Top = (int)(formHeight*0.1984);

		dsbrdSnvTitle.Width = (int)(formWidth*0.2604);
		dsbrdSnvTitle.Height = (int)(formHeight*0.0892);
		dsbrdSnvTitle.Left = (int)(dsbrdSideNav.Width*0);
		dsbrdSnvTitle.Top = (int)(dsbrdSideNav.Height*0);
		int dsbrdSnvTitleFont = (int)(formWidth*0.0130);
		dsbrdSnvTitle.Font = new Font("arial",dsbrdSnvTitleFont,FontStyle.Bold);

		dsbrdSnvBkMgt.Width = (int)(formWidth*0.2083);
		dsbrdSnvBkMgt.Height = (int)(formHeight*0.0595);
		dsbrdSnvBkMgt.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvBkMgt.Top = (int)(dsbrdSideNav.Height*0.16);
		int dsbrdSnvBkMgtFont = (int)(formWidth*0.0088);
		dsbrdSnvBkMgt.Font = new Font("Verdana",dsbrdSnvBkMgtFont,FontStyle.Underline);

		dsbrdSnvMbrMgt.Width = (int)(formWidth*0.2083);
		dsbrdSnvMbrMgt.Height = (int)(formHeight*0.0595);
		dsbrdSnvMbrMgt.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvMbrMgt.Top = (int)(dsbrdSideNav.Height*0.2666);
		int dsbrdSnvMbrMgtFont = (int)(formWidth*0.0088);
		dsbrdSnvMbrMgt.Font = new Font("Verdana",dsbrdSnvMbrMgtFont,FontStyle.Underline);

		dsbrdSnvBrw.Width = (int)(formWidth*0.2083);
		dsbrdSnvBrw.Height = (int)(formHeight*0.0595);
		dsbrdSnvBrw.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvBrw.Top = (int)(dsbrdSideNav.Height*0.3733);
		int dsbrdSnvBrwFont = (int)(formWidth*0.0088);
		dsbrdSnvBrw.Font = new Font("Verdana",dsbrdSnvBrwFont,FontStyle.Underline);

		dsbrdSnvRtn.Width = (int)(formWidth*0.2083);
		dsbrdSnvRtn.Height = (int)(formHeight*0.0595);
		dsbrdSnvRtn.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvRtn.Top = (int)(dsbrdSideNav.Height*0.48);
		int dsbrdSnvRtnFont = (int)(formWidth*0.0088);
		dsbrdSnvRtn.Font = new Font("Verdana",dsbrdSnvRtnFont,FontStyle.Underline);

		dsbrdSnvRpt.Width = (int)(formWidth*0.2083);
		dsbrdSnvRpt.Height = (int)(formHeight*0.0595);
		dsbrdSnvRpt.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvRpt.Top = (int)(dsbrdSideNav.Height*0.5866);
		int dsbrdSnvRptFont = (int)(formWidth*0.0088);
		dsbrdSnvRpt.Font = new Font("Verdana",dsbrdSnvRptFont,FontStyle.Underline);

		dsbrdSnvUsrStg.Width = (int)(formWidth*0.2083);
		dsbrdSnvUsrStg.Height = (int)(formHeight*0.0595);
		dsbrdSnvUsrStg.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvUsrStg.Top = (int)(dsbrdSideNav.Height*0.6933);
		int dsbrdSnvUsrStgFont = (int)(formWidth*0.0088);
		dsbrdSnvUsrStg.Font = new Font("Verdana",dsbrdSnvUsrStgFont,FontStyle.Underline);

		dsbrdSnvSrch.Width = (int)(formWidth*0.2083);
		dsbrdSnvSrch.Height = (int)(formHeight*0.0595);
		dsbrdSnvSrch.Left = (int)(dsbrdSideNav.Width*0.1);
		dsbrdSnvSrch.Top = (int)(dsbrdSideNav.Height*0.8);
		int dsbrdSnvSrchFont = (int)(formWidth*0.0088);
		dsbrdSnvSrch.Font = new Font("Verdana",dsbrdSnvSrchFont,FontStyle.Underline);

		dsbrdMainCont.Width = (int)(formWidth*0.6666);
		dsbrdMainCont.Height = (int)(formHeight*0.7936);
		dsbrdMainCont.Left = (int)(formWidth*0.3281);
		dsbrdMainCont.Top = (int)(formHeight*0.1587);

		mainCntGreet.Left = (int)(dsbrdMainCont.Width*0.0390);
		mainCntGreet.Top = (int)(dsbrdMainCont.Height*0.0625);
		int mainCntGreetFont = (int)(formWidth*0.0083);
		mainCntGreet.Font = new Font("verdana",mainCntGreetFont,FontStyle.Bold);

		mainSttTitle.Left = (int)(dsbrdMainCont.Width*0.390625);
		mainSttTitle.Top = (int)(dsbrdMainCont.Height*0.225);
		int mainSttTitleFont = (int)(formWidth*0.013020);
		mainSttTitle.Font = new Font("times new roman",mainSttTitleFont,FontStyle.Bold|FontStyle.Underline);

		mainSttNmBkLbl.Width = (int)(formWidth*0.234375);
		mainSttNmBkLbl.Height = (int)(formHeight*0.07936508);
		mainSttNmBkLbl.Left = (int)(dsbrdMainCont.Width*0.3125);
		mainSttNmBkLbl.Top = (int)(dsbrdMainCont.Height*0.375);
		int mainSttNmBkLblFont = (int)(formWidth*0.009375);
		mainSttNmBkLbl.Font = new Font("times new roman",mainSttNmBkLblFont);

		mainSttNmBkVal.Width = (int)(formWidth*0.05208333);
		mainSttNmBkVal.Height = (int)(formHeight*0.07936508);
		mainSttNmBkVal.Left = (int)(dsbrdMainCont.Width*0.703125);
		mainSttNmBkVal.Top = (int)(dsbrdMainCont.Height*0.375);
		int mainSttNmBkValFont = (int)(formWidth*0.009375);
		mainSttNmBkVal.Font = new Font("times new roman",mainSttNmBkValFont,FontStyle.Bold);

		mainSttNmMbrLbl.Width = (int)(formWidth*0.234375);
		mainSttNmMbrLbl.Height = (int)(formHeight*0.07936508);
		mainSttNmMbrLbl.Left = (int)(dsbrdMainCont.Width*0.3125);
		mainSttNmMbrLbl.Top = (int)(dsbrdMainCont.Height*0.5);
		int mainSttNmMbrLblFont = (int)(formWidth*0.009375);
		mainSttNmMbrLbl.Font = new Font("times new roman",mainSttNmMbrLblFont);

		mainSttNmMbrVal.Width = (int)(formWidth*0.05208333);
		mainSttNmMbrVal.Height = (int)(formHeight*0.07936508);
		mainSttNmMbrVal.Left = (int)(dsbrdMainCont.Width*0.703125);
		mainSttNmMbrVal.Top = (int)(dsbrdMainCont.Height*0.5);
		int mainSttNmMbrValFont = (int)(formWidth*0.009375);
		mainSttNmMbrVal.Font = new Font("times new roman",mainSttNmMbrValFont,FontStyle.Bold);

		mainSttOvrBkLbl.Width = (int)(formWidth*0.234375);
		mainSttOvrBkLbl.Height = (int)(formHeight*0.07936508);
		mainSttOvrBkLbl.Left = (int)(dsbrdMainCont.Width*0.3125);
		mainSttOvrBkLbl.Top = (int)(dsbrdMainCont.Height*0.625);
		int mainSttOvrBkLblFont = (int)(formWidth*0.009375);
		mainSttOvrBkLbl.Font = new Font("times new roman",mainSttOvrBkLblFont);

		mainSttOvrBkVal.Width = (int)(formWidth*0.05208333);
		mainSttOvrBkVal.Height = (int)(formHeight*0.07936508);
		mainSttOvrBkVal.Left = (int)(dsbrdMainCont.Width*0.703125);
		mainSttOvrBkVal.Top = (int)(dsbrdMainCont.Height*0.625);
		int mainSttOvrBkValFont = (int)(formWidth*0.009375);
		mainSttOvrBkVal.Font = new Font("times new roman",mainSttOvrBkValFont,FontStyle.Bold);

		adminMngUsrBtn.Width = (int)(formWidth*0.26041667);
		adminMngUsrBtn.Height = (int)(formHeight*0.09920635);
		adminMngUsrBtn.Left = (int)(dsbrdMainCont.Width*0.15625);
		adminMngUsrBtn.Top = (int)(dsbrdMainCont.Height*0.8125);
		int adminMngUsrBtnFont = (int)(formWidth*0.009375);
		adminMngUsrBtn.Font = new Font("arial",adminMngUsrBtnFont,FontStyle.Bold);

		mngUsrChseCont.Width = (int)(formWidth*0.72916667);
		mngUsrChseCont.Height = (int)(formHeight*0.89285714);
		mngUsrChseCont.Left = (int)(formWidth*0.13020833);
		mngUsrChseCont.Top = (int)(formHeight*0.04960317);

		mngUsrTitle.Width = (int)(formWidth*0.15625);
		mngUsrTitle.Height = (int)(formHeight*0.07936508);
		mngUsrTitle.Left = (int)(mngUsrChseCont.Width*0.39285714);
		mngUsrTitle.Top = (int)(mngUsrChseCont.Height*0.05555556);
		int mngUsrTitleFont = (int)(formWidth*0.00885417);
		mngUsrTitle.Font = new Font("times new roman",mngUsrTitleFont,FontStyle.Bold|FontStyle.Underline);

		mngUsrContClose.Width = (int)(formWidth*0.03645833);
		mngUsrContClose.Height = (int)(formHeight*0.06944444);
		mngUsrContClose.Left = (int)(mngUsrChseCont.Width*0.92857143);
		mngUsrContClose.Top = (int)(mngUsrChseCont.Height*0.01111111);
		int mngUsrContCloseFont = (int)(formWidth*0.01197917);
		mngUsrContClose.Font = new Font("arial",mngUsrContCloseFont,FontStyle.Bold);

		mngUsrNmUsrLbl.Width = (int)(formWidth*0.18229167);
		mngUsrNmUsrLbl.Height = (int)(formHeight*0.07936508);
		mngUsrNmUsrLbl.Left = (int)(mngUsrChseCont.Width*0.21428571);
		mngUsrNmUsrLbl.Top = (int)(mngUsrChseCont.Height*0.14544444);
		int mngUsrNmUsrLblFont = (int)(formWidth*0.00853333);
		mngUsrNmUsrLbl.Font = new Font("times new roman",mngUsrNmUsrLblFont,FontStyle.Bold);

		mngUsrNmUsrVal.Width = (int)(formWidth*0.05208333);
		mngUsrNmUsrVal.Height = (int)(formHeight*0.07936508);
		mngUsrNmUsrVal.Left = (int)(mngUsrChseCont.Width*0.47857143);
		mngUsrNmUsrVal.Top = (int)(mngUsrChseCont.Height*0.12222222);
		int mngUsrNmUsrValFont = (int)(formWidth*0.009575);
		mngUsrNmUsrVal.Font = new Font("times new roman",mngUsrNmUsrValFont,FontStyle.Bold);

		mngUsrActivateMng.Width = (int)(formWidth*0.10416667);
		mngUsrActivateMng.Height = (int)(formHeight*0.07936508);
		mngUsrActivateMng.Left = (int)(mngUsrChseCont.Width*0.28571429);
		mngUsrActivateMng.Top = (int)(mngUsrChseCont.Height*0.25555556);
		int mngUsrActivateMngFont = (int)(formWidth*0.00729167);
		mngUsrActivateMng.Font = new Font("arial",mngUsrActivateMngFont,FontStyle.Bold);

		mngUsrActivateLbl.Width = (int)(formWidth*0.20833333);
		mngUsrActivateLbl.Height = (int)(formHeight*0.05952381);
		mngUsrActivateLbl.Left = (int)(mngUsrChseCont.Width*0.25);
		mngUsrActivateLbl.Top = (int)(mngUsrChseCont.Height*0.35555556);
		int mngUsrActivateLblFont = (int)(formWidth*0.00625);
		mngUsrActivateLbl.Font = new Font("arial",mngUsrActivateLblFont,FontStyle.Bold);

		mngUsrAddBtn.Width = (int)(formWidth*0.10416667);
		mngUsrAddBtn.Height = (int)(formHeight*0.07936508);
		mngUsrAddBtn.Left = (int)(mngUsrChseCont.Width*0.57142857);
		mngUsrAddBtn.Top = (int)(mngUsrChseCont.Height*0.25555556);
		int mngUsrAddBtnFont = (int)(formWidth*0.00729167);
		mngUsrAddBtn.Font = new Font("arial",mngUsrAddBtnFont,FontStyle.Bold);

		dataGridView1.Width = (int)(formWidth*0.41666667);
		dataGridView1.Height = (int)(formHeight*0.14880952);
		dataGridView1.Left = (int)(mngUsrChseCont.Width*0.21428571);
		dataGridView1.Top = (int)(mngUsrChseCont.Height*0.44444444);
		int dataGridView1Font = (int)(formWidth*0.00520833);
		dataGridView1.Font = new Font("arial",dataGridView1Font);

		mngUsrAddCont.Width = (int)(formWidth*0.52083333);
		mngUsrAddCont.Height = (int)(formHeight*0.84325397);
		mngUsrAddCont.Left = (int)(formWidth*0.20833333);
		mngUsrAddCont.Top = (int)(formHeight*0.08928571);

		mngUsrAddTitle.Width = (int)(formWidth*0.18229167);
		mngUsrAddTitle.Height = (int)(formHeight*0.05952381);
		mngUsrAddTitle.Left = (int)(mngUsrAddCont.Width*0.35);
		mngUsrAddTitle.Top = (int)(mngUsrAddCont.Height*0.03529412);
		int mngUsrAddTitleFont = (int)(formWidth*0.01197917);
		mngUsrAddTitle.Font = new Font("arial",mngUsrAddTitleFont,FontStyle.Bold|FontStyle.Underline);

		mngUsrAddCloseBtn.Width = (int)(formWidth*0.02604167);
		mngUsrAddCloseBtn.Height = (int)(formHeight*0.04960317);
		mngUsrAddCloseBtn.Left = (int)(mngUsrAddCont.Width*0.93);
		mngUsrAddCloseBtn.Top = (int)(mngUsrAddCont.Height*0.01176471);
		int mngUsrAddCloseBtnFont = (int)(formWidth*0.00833333);
		mngUsrAddCloseBtn.Font = new Font("arial",mngUsrAddCloseBtnFont,FontStyle.Bold);

		addUsrnmLbl.Width = (int)(formWidth*0.13020833);
		addUsrnmLbl.Height = (int)(formHeight*0.04960317);
		addUsrnmLbl.Left = (int)(mngUsrAddCont.Width*0.08);
		addUsrnmLbl.Top = (int)(mngUsrAddCont.Height*0.27058824);
		int addUsrnmLblFont = (int)(formWidth*0.01041667);
		addUsrnmLbl.Font = new Font("times new roman",addUsrnmLblFont,FontStyle.Bold);

		addUsrnmVal.Width = (int)(formWidth*0.20833333);
		addUsrnmVal.Left = (int)(mngUsrAddCont.Width*0.4);
		addUsrnmVal.Top = (int)(mngUsrAddCont.Height*0.27058824);
		int addUsrnmValFont = (int)(formWidth*0.01041667);
		addUsrnmVal.Font = new Font("arial",addUsrnmValFont);

		addPswdLbl.Width = (int)(formWidth*0.13020833);
		addPswdLbl.Height = (int)(formHeight*0.04960317);
		addPswdLbl.Left = (int)(mngUsrAddCont.Width*0.08);
		addPswdLbl.Top = (int)(mngUsrAddCont.Height*0.42352941);
		int addPswdLblFont = (int)(formWidth*0.01041667);
		addPswdLbl.Font = new Font("times new roman",addPswdLblFont,FontStyle.Bold);

		addPswdVal.Width = (int)(formWidth*0.20833333);
		addPswdVal.Left = (int)(mngUsrAddCont.Width*0.4);
		addPswdVal.Top = (int)(mngUsrAddCont.Height*0.42352941);
		int addPswdValFont = (int)(formWidth*0.01041667);
		addPswdVal.Font = new Font("arial",addPswdValFont);

		addRoleLbl.Width = (int)(formWidth*0.13020833);
		addRoleLbl.Height = (int)(formHeight*0.04960317);
		addRoleLbl.Left = (int)(mngUsrAddCont.Width*0.08);
		addRoleLbl.Top = (int)(mngUsrAddCont.Height*0.57647059);
		int addRoleLblFont = (int)(formWidth*0.01041667);
		addRoleLbl.Font = new Font("times new roman",addRoleLblFont,FontStyle.Bold);

		addRoleVal.Width = (int)(formWidth*0.20833333);
		addRoleVal.Left = (int)(mngUsrAddCont.Width*0.4);
		addRoleVal.Top = (int)(mngUsrAddCont.Height*0.57647059);
		int addRoleValFont = (int)(formWidth*0.01041667);
		addRoleVal.Font = new Font("arial",addRoleValFont);

		addUsrBtn.Width = (int)(formWidth*0.20833333);
		addUsrBtn.Height = (int)(formHeight*0.09920635);
		addUsrBtn.Left = (int)(mngUsrAddCont.Width*0.3);
		addUsrBtn.Top = (int)(mngUsrAddCont.Height*0.76470588);
		int addUsrBtnFont = (int)(formWidth*0.01041667);
		addUsrBtn.Font = new Font("arial",addUsrBtnFont,FontStyle.Bold);

		nonAdminMsg.Width = (int)(formWidth*0.26041667);
		nonAdminMsg.Height = (int)(formHeight*0.09920635);
		nonAdminMsg.Left = (int)(mngUsrAddCont.Width*0.15625);
		nonAdminMsg.Top = (int)(mngUsrAddCont.Height*0.81);
		int nonAdminMsgFont = (int)(formWidth*0.009375);
		nonAdminMsg.Font = new Font("arial",nonAdminMsgFont,FontStyle.Bold);

	}

	private void logoutBtn_Clicked (object sender, EventArgs e) {
		HomeForm = NavigateTo(HomeForm);
	}

	private void onloadMainContent() {
		string dbusrnm = LoginPage.DBusername;
		string dbrole = LoginPage.DBuserrole;
		mainCntGreet.Text = $"Welcome, {dbusrnm} ({dbrole})";

		totalBooks_database();
		totalmembers_database ();
		totaloverduebooks_database ();
		
	}

	private void dsbrdSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvBkMgt.ForeColor = Color.Green;
	}
	private void dsbrdSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvBkMgt.ForeColor = Color.Blue;
	}

	private void dsbrdSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvMbrMgt.ForeColor = Color.Green;
	}
	private void dsbrdSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void dsbrdSnvBrw_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvBrw.ForeColor = Color.Green;
	}
	private void dsbrdSnvBrw_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvBrw.ForeColor = Color.Blue;
	}

	private void dsbrdSnvRtn_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvRtn.ForeColor = Color.Green;
	}
	private void dsbrdSnvRtn_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvRtn.ForeColor = Color.Blue;
	}

	private void dsbrdSnvRpt_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvRpt.ForeColor = Color.Green;
	}
	private void dsbrdSnvRpt_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvRpt.ForeColor = Color.Blue;
	}

	private void dsbrdSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvUsrStg.ForeColor = Color.Green;
	}
	private void dsbrdSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvUsrStg.ForeColor = Color.Blue;
	}

	private void dsbrdSnvSrch_MouseEnter (object sender, EventArgs e) {
		dsbrdSnvSrch.ForeColor = Color.Green;
	}
	private void dsbrdSnvSrch_MouseLeave (object sender, EventArgs e) {
		dsbrdSnvSrch.ForeColor = Color.Blue;
	}

	private void hideSomeControls () {
		if (LoginPage.DBuserrole == "Admin") {
			adminMngUsrBtn.Show();
			nonAdminMsg.Hide();
		}else {
			adminMngUsrBtn.Hide();
			nonAdminMsg.Show();
		}
		mngUsrChseCont.Hide();
		mngUsrAddCont.Hide();
	}

	private void LoadData() {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT * FROM users";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter(query,connection);
				DataTable table = new DataTable();
				adapter.Fill(table);
				dataGridView1.DataSource = table;
			}
		} catch (Exception ex) {
			MessageBox.Show("Error: " + ex.Message);
		}
	}

	private void adminMngUsrBtn_Clicked(object sender, EventArgs e) {
		mngUsrChseCont.Show();
		LoadData();
		InitializeGridView();
		totalusers_database ();
		dataGridView1.ReadOnly = true;
		mngUsrActivateLbl.Hide();
	}
	
	private void mngUsrContClose_Clicked (object sender, EventArgs e) {
		mngUsrChseCont.Hide();
	}

	private void totalBooks_database () {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT COUNT(book_id) FROM books";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				MySqlCommand command = new MySqlCommand(query, connection);
				int numOfBooks = Convert.ToInt32(command.ExecuteScalar());
				mainSttNmBkVal.Text = numOfBooks.ToString();
			}

		} catch (Exception ex) {
			MessageBox.Show("Error: " + ex.Message);
		}
	}

	private void totalmembers_database () {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT COUNT(member_id) FROM members";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				MySqlCommand command = new MySqlCommand(query, connection);
				int numOfMembers = Convert.ToInt32(command.ExecuteScalar());
				mainSttNmMbrVal.Text = numOfMembers.ToString();
			}
		} catch (Exception ex) {
			MessageBox.Show("Error: "+ ex.Message);
		}
	}	

	private void totaloverduebooks_database () {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT COUNT(book_id) FROM transactions WHERE status='overdue'";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				MySqlCommand command = new MySqlCommand(query, connection);
				int numOfOverdue = Convert.ToInt32(command.ExecuteScalar());
				mainSttOvrBkVal.Text = numOfOverdue.ToString();
			}
		} catch (Exception ex) {
			MessageBox.Show("Error: "+ ex.Message);
		}
	}

	private void InitializeGridView() {
		dataGridView1.ReadOnly = false;
		dataGridView1.Columns[0].ReadOnly = true;
		dataGridView1.Columns[4].ReadOnly = true;
	}

	private void dataGridView1_KeyDown (object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count > 0) {
			foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
				DeleteRecord(Convert.ToInt32(row.Cells["user_id"].Value));
				dataGridView1.Rows.Remove(row);
			}
		}
	}

	private void DeleteRecord (int userId) {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		string query = "DELETE FROM users WHERE user_id=@user_id";
                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                MySqlCommand command = new MySqlCommand(query, connection);
		command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();
                command.ExecuteNonQuery();
		MessageBox.Show("User(Record) Successfully Deleted!");
		}
	}


	private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
{
    try
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

        int userId = Convert.ToInt32(row.Cells["user_id"].Value); // Primary key
        string username = row.Cells["username"].Value?.ToString();
        string password_hash = row.Cells["password_hash"].Value?.ToString();
        string role = row.Cells["role"].Value?.ToString();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password_hash) || string.IsNullOrEmpty(role))
        {
            MessageBox.Show("All fields must have valid values.");
            return;
        }

        string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
        string query = "UPDATE users SET username=@username, password_hash=@password_hash, role=@role WHERE user_id=@user_id";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password_hash", password_hash);
            command.Parameters.AddWithValue("@role", role);
            command.Parameters.AddWithValue("@user_id", userId);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Database updated successfully.");
            }
            else
            {
                MessageBox.Show("No record was updated. Please verify the data.");
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error updating database: {ex.Message}");
    }
}

private void totalusers_database () {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT COUNT(user_id) FROM users";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				MySqlCommand command = new MySqlCommand(query, connection);
				int numOfUsers = Convert.ToInt32(command.ExecuteScalar());
				mngUsrNmUsrVal.Text = numOfUsers.ToString();
			}
		} catch (Exception ex) {
			MessageBox.Show("Error: "+ ex.Message);
		}
	}

	private void mngUsrActivateMng_Clicked(object sender, EventArgs e) {
		mngUsrActivateLbl.Show();
		dataGridView1.ReadOnly = false;
	}

	private void mngUsrAddBtn_Clicked (object sender, EventArgs e) {
		mngUsrAddCont.Show();
	}

	private void mngUsrAddCloseBtn_Clicked (object sender, EventArgs e) {
		mngUsrAddCont.Hide();
		LoadData();
		InitializeGridView();
		totalusers_database ();
		dataGridView1.ReadOnly = true;
		mngUsrActivateLbl.Hide();
	}

	private void addUsrBtn_Clicked (object sender, EventArgs e) {
		try {
			string username = addUsrnmVal.Text;
		string password = addPswdVal.Text;
		string role = addRoleVal.SelectedItem.ToString();
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
        {
            MessageBox.Show("All fields must have valid values.");
            return;
        }
	        	string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "INSERT INTO users(username,password_hash,role) VALUES(@username, @password, @role)";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
            			MySqlCommand command = new MySqlCommand(query, connection);
				command.Parameters.AddWithValue("@username",username);
				command.Parameters.AddWithValue("@password",password);
				command.Parameters.AddWithValue("@role",role);
				connection.Open();
            			int rowsAffected = command.ExecuteNonQuery();
            			if (rowsAffected > 0) {
               				MessageBox.Show("User Added successfully.");
           			}
            			else {
                			MessageBox.Show("User Not Added");
            			}
			}

		} catch (Exception ex) {
			MessageBox.Show($"Add User Error: {ex.Message}");
		}
	}

}
