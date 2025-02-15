
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniProjectApp;

public partial class MembermanagementPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

	private DashboardPage DashboardForm;
	private BookmanagementPage BookmanagementForm;
	private BorrowPage BorrowForm;
	private ReturnPage ReturnForm;
	private ReportsPage ReportsForm;
	private UsersettingPage UsersettingForm;
	private SearchPage SearchForm;

    public MembermanagementPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	mbrMgtLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


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

	private void mbrMgtSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void mbrMgtSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}

	private void mbrMgtSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void mbrMgtSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void mbrMgtSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void mbrMgtSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void mbrMgtSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}

	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		addMbrCont.Hide();
		LoadData();
		MbrMgtGridView.CellValueChanged += MbrMgtGridView_CellValueChanged;
		MbrMgtGridView.KeyDown += MbrMgtGridView_KeyDown;
		actvateEditMessage.Hide();
		
		mbrMgtHeader.Width = (int)(screenWidth*1);
		mbrMgtHeader.Height = (int)(screenHeight*0.1488);
		mbrMgtHeader.Left = (int)(screenWidth*0);
		mbrMgtHeader.Top = (int)(screenHeight*0);

		mbrMgtMainTitle.Width = (int)(screenWidth*0.625);
		mbrMgtMainTitle.Height = (int)(screenHeight*0.0793);
		mbrMgtMainTitle.Left = (int)(mbrMgtHeader.Width*0.1302);
		mbrMgtMainTitle.Top = (int)(mbrMgtHeader.Height*0);
		int mbrMgtMainTitleFont = (int)(screenWidth*0.0166);
		mbrMgtMainTitle.Font = new Font("roboto",mbrMgtMainTitleFont, FontStyle.Bold);

		mbrMgtPgeTitle.Width = (int)(screenWidth*0.625);
		mbrMgtPgeTitle.Height = (int)(screenHeight*0.0595);
		mbrMgtPgeTitle.Left = (int)(mbrMgtHeader.Width*0.1302);
		mbrMgtPgeTitle.Top = (int)(mbrMgtHeader.Height*0.5666);
		int mbrMgtPgeTitleFont = (int)(screenWidth*0.0104);
		mbrMgtPgeTitle.Font = new Font("broadway",mbrMgtPgeTitleFont);

		mbrMgtLogo.Width = (int)(screenWidth*0.0781);
		mbrMgtLogo.Height = (int)(screenHeight*0.0892);
		mbrMgtLogo.Left = (int)(mbrMgtHeader.Width*0.0260);
		mbrMgtLogo.Top = (int)(mbrMgtHeader.Height*0.2);

		mbrMgtSideNav.Width = (int)(screenWidth*0.2604);
		mbrMgtSideNav.Height = (int)(screenHeight*0.744);
		mbrMgtSideNav.Left = (int)(screenWidth*0.0156);
		mbrMgtSideNav.Top = (int)(screenHeight*0.1984);

		mbrMgtSnvTitle.Width = (int)(screenWidth*0.2604);
		mbrMgtSnvTitle.Height = (int)(screenHeight*0.0892);
		mbrMgtSnvTitle.Left = (int)(mbrMgtSideNav.Width*0);
		mbrMgtSnvTitle.Top = (int)(mbrMgtSideNav.Height*0);
		int mbrMgtSnvTitleFont = (int)(screenWidth*0.0130);
		mbrMgtSnvTitle.Font = new Font("arial",mbrMgtSnvTitleFont,FontStyle.Bold);

		mbrMgtSnvBkMgt.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvBkMgt.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvBkMgt.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvBkMgt.Top = (int)(mbrMgtSideNav.Height*0.16);
		int mbrMgtSnvBkMgtFont = (int)(screenWidth*0.0088);
		mbrMgtSnvBkMgt.Font = new Font("Verdana",mbrMgtSnvBkMgtFont,FontStyle.Underline);

		mbrMgtSnvDshBrd.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvDshBrd.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvDshBrd.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvDshBrd.Top = (int)(mbrMgtSideNav.Height*0.2666);
		int mbrMgtSnvDshBrdFont = (int)(screenWidth*0.0088);
		mbrMgtSnvDshBrd.Font = new Font("Verdana",mbrMgtSnvDshBrdFont,FontStyle.Underline);

		mbrMgtSnvBrw.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvBrw.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvBrw.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvBrw.Top = (int)(mbrMgtSideNav.Height*0.3733);
		int mbrMgtSnvBrwFont = (int)(screenWidth*0.0088);
		mbrMgtSnvBrw.Font = new Font("Verdana",mbrMgtSnvBrwFont,FontStyle.Underline);

		mbrMgtSnvRtn.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvRtn.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvRtn.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvRtn.Top = (int)(mbrMgtSideNav.Height*0.48);
		int mbrMgtSnvRtnFont = (int)(screenWidth*0.0088);
		mbrMgtSnvRtn.Font = new Font("Verdana",mbrMgtSnvRtnFont,FontStyle.Underline);

		mbrMgtSnvRpt.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvRpt.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvRpt.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvRpt.Top = (int)(mbrMgtSideNav.Height*0.5866);
		int mbrMgtSnvRptFont = (int)(screenWidth*0.0088);
		mbrMgtSnvRpt.Font = new Font("Verdana",mbrMgtSnvRptFont,FontStyle.Underline);

		mbrMgtSnvUsrStg.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvUsrStg.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvUsrStg.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvUsrStg.Top = (int)(mbrMgtSideNav.Height*0.6933);
		int mbrMgtSnvUsrStgFont = (int)(screenWidth*0.0088);
		mbrMgtSnvUsrStg.Font = new Font("Verdana",mbrMgtSnvUsrStgFont,FontStyle.Underline);

		mbrMgtSnvSrch.Width = (int)(screenWidth*0.2083);
		mbrMgtSnvSrch.Height = (int)(screenHeight*0.0595);
		mbrMgtSnvSrch.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvSrch.Top = (int)(mbrMgtSideNav.Height*0.8);
		int mbrMgtSnvSrchFont = (int)(screenWidth*0.0088);
		mbrMgtSnvSrch.Font = new Font("Verdana",mbrMgtSnvSrchFont,FontStyle.Underline);

		mbrMgtMainCont.Width = (int)(screenWidth*0.6666);
		mbrMgtMainCont.Height = (int)(screenHeight*0.7936);
		mbrMgtMainCont.Left = (int)(screenWidth*0.3281);
		mbrMgtMainCont.Top = (int)(screenHeight*0.1587);

		MbrMgtMainCntTitle.Width = (int)(screenWidth*0.234375);
		MbrMgtMainCntTitle.Height = (int)(screenHeight*0.05952381);
		MbrMgtMainCntTitle.Left = (int)(mbrMgtMainCont.Width*0.390625);
		MbrMgtMainCntTitle.Top = (int)(mbrMgtMainCont.Height*0.0375);
		int MbrMgtMainCntTitleFont = (int)(screenWidth*0.009375);
		MbrMgtMainCntTitle.Font = new Font("Verdana",MbrMgtMainCntTitleFont,FontStyle.Underline|FontStyle.Bold);

		activateEditBtn.Width = (int)(screenWidth*0.13020833);
		activateEditBtn.Height = (int)(screenHeight*0.05952381);
		activateEditBtn.Left = (int)(mbrMgtMainCont.Width*0.15625);
		activateEditBtn.Top = (int)(mbrMgtMainCont.Height*0.4375);
		int activateEditBtnFont = (int)(screenWidth*0.00833333);
		activateEditBtn.Font = new Font("arial",activateEditBtnFont,FontStyle.Bold);

		actvateEditMessage.Width = (int)(screenWidth*0.36458333);
		actvateEditMessage.Height = (int)(screenHeight*0.06944444);
		actvateEditMessage.Left = (int)(mbrMgtMainCont.Width*0.1171875);
		actvateEditMessage.Top = (int)(mbrMgtMainCont.Height*0.5125);
		int actvateEditMessageFont = (int)(screenWidth*0.00729167);
		actvateEditMessage.Font = new Font("arial",actvateEditMessageFont);

		MbrMgtGridView.Width = (int)(screenWidth*0.50260417);
		MbrMgtGridView.Height = (int)(screenHeight*0.14880952);
		MbrMgtGridView.Left = (int)(mbrMgtMainCont.Width*0.1171875);
		MbrMgtGridView.Top = (int)(mbrMgtMainCont.Height*0.625);
		int MbrMgtGridViewFont = (int)(screenWidth*0.00520833);
		MbrMgtGridView.Font = new Font("arial",MbrMgtGridViewFont);

		MbrMgtAddBtn.Width = (int)(screenWidth*0.15625);
		MbrMgtAddBtn.Height = (int)(screenHeight*0.07936508);
		MbrMgtAddBtn.Left = (int)(mbrMgtMainCont.Width*0.3828125);
		MbrMgtAddBtn.Top = (int)(mbrMgtMainCont.Height*0.125);
		int MbrMgtAddBtnFont = (int)(screenWidth*0.00833333);
		MbrMgtAddBtn.Font = new Font("arial",MbrMgtAddBtnFont,FontStyle.Bold);

		addMbrCont.Width = (int)(screenWidth*0.52083333);
		addMbrCont.Height = (int)(screenHeight*0.84325397);
		addMbrCont.Left = (int)(screenWidth*0.23958333);
		addMbrCont.Top = (int)(screenHeight*0.08928571);

		addMbrTitle.Width = (int)(screenWidth*0.234375);
		addMbrTitle.Height = (int)(screenHeight*0.05952381);
		addMbrTitle.Left = (int)(addMbrCont.Width*0.32);
		addMbrTitle.Top = (int)(addMbrCont.Height*0.03529412);
		int addMbrTitleFont = (int)(screenWidth*0.01197917);
		addMbrTitle.Font = new Font("arial",addMbrTitleFont,FontStyle.Bold|FontStyle.Underline);

		addMbrCloseBtn.Width = (int)(screenWidth*0.03125);
		addMbrCloseBtn.Height = (int)(screenHeight*0.05952381);
		addMbrCloseBtn.Left = (int)(addMbrCont.Width*0.9);
		addMbrCloseBtn.Top = (int)(addMbrCont.Height*0.01176471);
		int addMbrCloseBtnFont = (int)(screenWidth*0.00833333);
		addMbrCloseBtn.Font = new Font("arial",addMbrCloseBtnFont,FontStyle.Bold);

		addMbrNameLbl.Width = (int)(screenWidth*0.15625);
		addMbrNameLbl.Height = (int)(screenHeight*0.04960317);
		addMbrNameLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrNameLbl.Top = (int)(addMbrCont.Height*0.21176471);
		int addMbrNameLblFont = (int)(screenWidth*0.00885417);
		addMbrNameLbl.Font = new Font("times new roman",addMbrNameLblFont,FontStyle.Bold);

		addMbrNameInp.Width = (int)(screenWidth*0.20833333);
		addMbrNameInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrNameInp.Top = (int)(addMbrCont.Height*0.21176471);
		int addMbrNameInpFont = (int)(screenWidth*0.00885417);
		addMbrNameInp.Font = new Font("arial",addMbrNameInpFont);

		addMbrEmailLbl.Width = (int)(screenWidth*0.15625);
		addMbrEmailLbl.Height = (int)(screenHeight*0.04960317);
		addMbrEmailLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrEmailLbl.Top = (int)(addMbrCont.Height*0.32941176);
		int addMbrEmailLblFont = (int)(screenWidth*0.00885417);
		addMbrEmailLbl.Font = new Font("times new roman",addMbrEmailLblFont,FontStyle.Bold);

		addMbrEmailInp.Width = (int)(screenWidth*0.20833333);
		addMbrEmailInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrEmailInp.Top = (int)(addMbrCont.Height*0.32941176);
		int addMbrEmailInpFont = (int)(screenWidth*0.00885417);
		addMbrEmailInp.Font = new Font("arial",addMbrEmailInpFont);

		addMbrPhoneLbl.Width = (int)(screenWidth*0.15625);
		addMbrPhoneLbl.Height = (int)(screenHeight*0.04960317);
		addMbrPhoneLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrPhoneLbl.Top = (int)(addMbrCont.Height*0.44705882);
		int addMbrPhoneLblFont = (int)(screenWidth*0.00885417);
		addMbrPhoneLbl.Font = new Font("times new roman",addMbrPhoneLblFont,FontStyle.Bold);

		addMbrPhoneInp.Width = (int)(screenWidth*0.20833333);
		addMbrPhoneInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrPhoneInp.Top = (int)(addMbrCont.Height*0.44705882);
		int addMbrPhoneInpFont = (int)(screenWidth*0.00885417);
		addMbrPhoneInp.Font = new Font("arial",addMbrPhoneInpFont);

		addMbrRegdateLbl.Width = (int)(screenWidth*0.15625);
		addMbrRegdateLbl.Height = (int)(screenHeight*0.04960317);
		addMbrRegdateLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrRegdateLbl.Top = (int)(addMbrCont.Height*0.56470588);
		int addMbrRegdateLblFont = (int)(screenWidth*0.00885417);
		addMbrRegdateLbl.Font = new Font("times new roman",addMbrRegdateLblFont,FontStyle.Bold);

		addMbrRegdateInp.Width = (int)(screenWidth*0.20833333);
		addMbrRegdateInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrRegdateInp.Top = (int)(addMbrCont.Height*0.56470588);
		int addMbrRegdateInpFont = (int)(screenWidth*0.00885417);
		addMbrRegdateInp.Font = new Font("arial",addMbrRegdateInpFont);

		addMbrStatusLbl.Width = (int)(screenWidth*0.15625);
		addMbrStatusLbl.Height = (int)(screenHeight*0.04960317);
		addMbrStatusLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrStatusLbl.Top = (int)(addMbrCont.Height*0.68235294);
		int addMbrStatusLblFont = (int)(screenWidth*0.00885417);
		addMbrStatusLbl.Font = new Font("times new roman",addMbrStatusLblFont,FontStyle.Bold);

		addMbrStatusInp.Width = (int)(screenWidth*0.20833333);
		addMbrStatusInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrStatusInp.Top = (int)(addMbrCont.Height*0.68235294);
		int addMbrStatusInpFont = (int)(screenWidth*0.00885417);
		addMbrStatusInp.Font = new Font("arial",addMbrStatusInpFont);

		addMbrAddBtn.Width = (int)(screenWidth*0.20833333);
		addMbrAddBtn.Height = (int)(screenHeight*0.09920635);
		addMbrAddBtn.Left = (int)(addMbrCont.Width*0.3);
		addMbrAddBtn.Top = (int)(addMbrCont.Height*0.82352941);
		int addMbrAddBtnFont = (int)(screenWidth*0.01041667);
		addMbrAddBtn.Font = new Font("arial",addMbrAddBtnFont,FontStyle.Bold);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		mbrMgtHeader.Width = (int)(formWidth*1);
		mbrMgtHeader.Height = (int)(formHeight*0.1488);
		mbrMgtHeader.Left = (int)(formWidth*0);
		mbrMgtHeader.Top = (int)(formHeight*0);

		mbrMgtMainTitle.Width = (int)(formWidth*0.625);
		mbrMgtMainTitle.Height = (int)(formHeight*0.0793);
		mbrMgtMainTitle.Left = (int)(mbrMgtHeader.Width*0.1302);
		mbrMgtMainTitle.Top = (int)(mbrMgtHeader.Height*0);
		int mbrMgtMainTitleFont = (int)(formWidth*0.0166);
		mbrMgtMainTitle.Font = new Font("roboto",mbrMgtMainTitleFont, FontStyle.Bold);

		mbrMgtPgeTitle.Width = (int)(formWidth*0.625);
		mbrMgtPgeTitle.Height = (int)(formHeight*0.0595);
		mbrMgtPgeTitle.Left = (int)(mbrMgtHeader.Width*0.1302);
		mbrMgtPgeTitle.Top = (int)(mbrMgtHeader.Height*0.5666);
		int mbrMgtPgeTitleFont = (int)(formWidth*0.0104);
		mbrMgtPgeTitle.Font = new Font("broadway",mbrMgtPgeTitleFont);

		mbrMgtLogo.Width = (int)(formWidth*0.0781);
		mbrMgtLogo.Height = (int)(formHeight*0.0892);
		mbrMgtLogo.Left = (int)(mbrMgtHeader.Width*0.0260);
		mbrMgtLogo.Top = (int)(mbrMgtHeader.Height*0.2);

		mbrMgtSideNav.Width = (int)(formWidth*0.2604);
		mbrMgtSideNav.Height = (int)(formHeight*0.744);
		mbrMgtSideNav.Left = (int)(formWidth*0.0156);
		mbrMgtSideNav.Top = (int)(formHeight*0.1984);

		mbrMgtSnvTitle.Width = (int)(formWidth*0.2604);
		mbrMgtSnvTitle.Height = (int)(formHeight*0.0892);
		mbrMgtSnvTitle.Left = (int)(mbrMgtSideNav.Width*0);
		mbrMgtSnvTitle.Top = (int)(mbrMgtSideNav.Height*0);
		int mbrMgtSnvTitleFont = (int)(formWidth*0.0130);
		mbrMgtSnvTitle.Font = new Font("arial",mbrMgtSnvTitleFont,FontStyle.Bold);

		mbrMgtSnvBkMgt.Width = (int)(formWidth*0.2083);
		mbrMgtSnvBkMgt.Height = (int)(formHeight*0.0595);
		mbrMgtSnvBkMgt.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvBkMgt.Top = (int)(mbrMgtSideNav.Height*0.16);
		int mbrMgtSnvBkMgtFont = (int)(formWidth*0.0088);
		mbrMgtSnvBkMgt.Font = new Font("Verdana",mbrMgtSnvBkMgtFont,FontStyle.Underline);

		mbrMgtSnvDshBrd.Width = (int)(formWidth*0.2083);
		mbrMgtSnvDshBrd.Height = (int)(formHeight*0.0595);
		mbrMgtSnvDshBrd.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvDshBrd.Top = (int)(mbrMgtSideNav.Height*0.2666);
		int mbrMgtSnvDshBrdFont = (int)(formWidth*0.0088);
		mbrMgtSnvDshBrd.Font = new Font("Verdana",mbrMgtSnvDshBrdFont,FontStyle.Underline);

		mbrMgtSnvBrw.Width = (int)(formWidth*0.2083);
		mbrMgtSnvBrw.Height = (int)(formHeight*0.0595);
		mbrMgtSnvBrw.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvBrw.Top = (int)(mbrMgtSideNav.Height*0.3733);
		int mbrMgtSnvBrwFont = (int)(formWidth*0.0088);
		mbrMgtSnvBrw.Font = new Font("Verdana",mbrMgtSnvBrwFont,FontStyle.Underline);

		mbrMgtSnvRtn.Width = (int)(formWidth*0.2083);
		mbrMgtSnvRtn.Height = (int)(formHeight*0.0595);
		mbrMgtSnvRtn.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvRtn.Top = (int)(mbrMgtSideNav.Height*0.48);
		int mbrMgtSnvRtnFont = (int)(formWidth*0.0088);
		mbrMgtSnvRtn.Font = new Font("Verdana",mbrMgtSnvRtnFont,FontStyle.Underline);

		mbrMgtSnvRpt.Width = (int)(formWidth*0.2083);
		mbrMgtSnvRpt.Height = (int)(formHeight*0.0595);
		mbrMgtSnvRpt.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvRpt.Top = (int)(mbrMgtSideNav.Height*0.5866);
		int mbrMgtSnvRptFont = (int)(formWidth*0.0088);
		mbrMgtSnvRpt.Font = new Font("Verdana",mbrMgtSnvRptFont,FontStyle.Underline);

		mbrMgtSnvUsrStg.Width = (int)(formWidth*0.2083);
		mbrMgtSnvUsrStg.Height = (int)(formHeight*0.0595);
		mbrMgtSnvUsrStg.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvUsrStg.Top = (int)(mbrMgtSideNav.Height*0.6933);
		int mbrMgtSnvUsrStgFont = (int)(formWidth*0.0088);
		mbrMgtSnvUsrStg.Font = new Font("Verdana",mbrMgtSnvUsrStgFont,FontStyle.Underline);

		mbrMgtSnvSrch.Width = (int)(formWidth*0.2083);
		mbrMgtSnvSrch.Height = (int)(formHeight*0.0595);
		mbrMgtSnvSrch.Left = (int)(mbrMgtSideNav.Width*0.1);
		mbrMgtSnvSrch.Top = (int)(mbrMgtSideNav.Height*0.8);
		int mbrMgtSnvSrchFont = (int)(formWidth*0.0088);
		mbrMgtSnvSrch.Font = new Font("Verdana",mbrMgtSnvSrchFont,FontStyle.Underline);

		mbrMgtMainCont.Width = (int)(formWidth*0.6666);
		mbrMgtMainCont.Height = (int)(formHeight*0.7936);
		mbrMgtMainCont.Left = (int)(formWidth*0.3281);
		mbrMgtMainCont.Top = (int)(formHeight*0.1587);

		MbrMgtMainCntTitle.Width = (int)(formWidth*0.234375);
		MbrMgtMainCntTitle.Height = (int)(formHeight*0.05952381);
		MbrMgtMainCntTitle.Left = (int)(mbrMgtMainCont.Width*0.390625);
		MbrMgtMainCntTitle.Top = (int)(mbrMgtMainCont.Height*0.0375);
		int MbrMgtMainCntTitleFont = (int)(formWidth*0.009375);
		MbrMgtMainCntTitle.Font = new Font("Verdana",MbrMgtMainCntTitleFont,FontStyle.Underline|FontStyle.Bold);

		activateEditBtn.Width = (int)(formWidth*0.13020833);
		activateEditBtn.Height = (int)(formHeight*0.05952381);
		activateEditBtn.Left = (int)(mbrMgtMainCont.Width*0.15625);
		activateEditBtn.Top = (int)(mbrMgtMainCont.Height*0.4375);
		int activateEditBtnFont = (int)(formWidth*0.00833333);
		activateEditBtn.Font = new Font("arial",activateEditBtnFont,FontStyle.Bold);

		actvateEditMessage.Width = (int)(formWidth*0.36458333);
		actvateEditMessage.Height = (int)(formHeight*0.06944444);
		actvateEditMessage.Left = (int)(mbrMgtMainCont.Width*0.1171875);
		actvateEditMessage.Top = (int)(mbrMgtMainCont.Height*0.5125);
		int actvateEditMessageFont = (int)(formWidth*0.00729167);
		actvateEditMessage.Font = new Font("arial",actvateEditMessageFont);

		MbrMgtGridView.Width = (int)(formWidth*0.50260417);
		MbrMgtGridView.Height = (int)(formHeight*0.14880952);
		MbrMgtGridView.Left = (int)(mbrMgtMainCont.Width*0.1171875);
		MbrMgtGridView.Top = (int)(mbrMgtMainCont.Height*0.625);
		int MbrMgtGridViewFont = (int)(formWidth*0.00520833);
		MbrMgtGridView.Font = new Font("arial",MbrMgtGridViewFont);

		MbrMgtAddBtn.Width = (int)(formWidth*0.15625);
		MbrMgtAddBtn.Height = (int)(formHeight*0.07936508);
		MbrMgtAddBtn.Left = (int)(mbrMgtMainCont.Width*0.3828125);
		MbrMgtAddBtn.Top = (int)(mbrMgtMainCont.Height*0.125);
		int MbrMgtAddBtnFont = (int)(formWidth*0.00833333);
		MbrMgtAddBtn.Font = new Font("arial",MbrMgtAddBtnFont,FontStyle.Bold);

		addMbrCont.Width = (int)(formWidth*0.52083333);
		addMbrCont.Height = (int)(formHeight*0.84325397);
		addMbrCont.Left = (int)(formWidth*0.23958333);
		addMbrCont.Top = (int)(formHeight*0.08928571);

		addMbrTitle.Width = (int)(formWidth*0.234375);
		addMbrTitle.Height = (int)(formHeight*0.05952381);
		addMbrTitle.Left = (int)(addMbrCont.Width*0.32);
		addMbrTitle.Top = (int)(addMbrCont.Height*0.03529412);
		int addMbrTitleFont = (int)(formWidth*0.01197917);
		addMbrTitle.Font = new Font("arial",addMbrTitleFont,FontStyle.Bold|FontStyle.Underline);

		addMbrCloseBtn.Width = (int)(formWidth*0.03125);
		addMbrCloseBtn.Height = (int)(formHeight*0.05952381);
		addMbrCloseBtn.Left = (int)(addMbrCont.Width*0.9);
		addMbrCloseBtn.Top = (int)(addMbrCont.Height*0.01176471);
		int addMbrCloseBtnFont = (int)(formWidth*0.00833333);
		addMbrCloseBtn.Font = new Font("arial",addMbrCloseBtnFont,FontStyle.Bold);

		addMbrNameLbl.Width = (int)(formWidth*0.15625);
		addMbrNameLbl.Height = (int)(formHeight*0.04960317);
		addMbrNameLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrNameLbl.Top = (int)(addMbrCont.Height*0.21176471);
		int addMbrNameLblFont = (int)(formWidth*0.00885417);
		addMbrNameLbl.Font = new Font("times new roman",addMbrNameLblFont,FontStyle.Bold);

		addMbrNameInp.Width = (int)(formWidth*0.20833333);
		addMbrNameInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrNameInp.Top = (int)(addMbrCont.Height*0.21176471);
		int addMbrNameInpFont = (int)(formWidth*0.00885417);
		addMbrNameInp.Font = new Font("arial",addMbrNameInpFont);

		addMbrEmailLbl.Width = (int)(formWidth*0.15625);
		addMbrEmailLbl.Height = (int)(formHeight*0.04960317);
		addMbrEmailLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrEmailLbl.Top = (int)(addMbrCont.Height*0.32941176);
		int addMbrEmailLblFont = (int)(formWidth*0.00885417);
		addMbrEmailLbl.Font = new Font("times new roman",addMbrEmailLblFont,FontStyle.Bold);

		addMbrEmailInp.Width = (int)(formWidth*0.20833333);
		addMbrEmailInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrEmailInp.Top = (int)(addMbrCont.Height*0.32941176);
		int addMbrEmailInpFont = (int)(formWidth*0.00885417);
		addMbrEmailInp.Font = new Font("arial",addMbrEmailInpFont);

		addMbrPhoneLbl.Width = (int)(formWidth*0.15625);
		addMbrPhoneLbl.Height = (int)(formHeight*0.04960317);
		addMbrPhoneLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrPhoneLbl.Top = (int)(addMbrCont.Height*0.44705882);
		int addMbrPhoneLblFont = (int)(formWidth*0.00885417);
		addMbrPhoneLbl.Font = new Font("times new roman",addMbrPhoneLblFont,FontStyle.Bold);

		addMbrPhoneInp.Width = (int)(formWidth*0.20833333);
		addMbrPhoneInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrPhoneInp.Top = (int)(addMbrCont.Height*0.44705882);
		int addMbrPhoneInpFont = (int)(formWidth*0.00885417);
		addMbrPhoneInp.Font = new Font("arial",addMbrPhoneInpFont);

		addMbrRegdateLbl.Width = (int)(formWidth*0.15625);
		addMbrRegdateLbl.Height = (int)(formHeight*0.04960317);
		addMbrRegdateLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrRegdateLbl.Top = (int)(addMbrCont.Height*0.56470588);
		int addMbrRegdateLblFont = (int)(formWidth*0.00885417);
		addMbrRegdateLbl.Font = new Font("times new roman",addMbrRegdateLblFont,FontStyle.Bold);

		addMbrRegdateInp.Width = (int)(formWidth*0.20833333);
		addMbrRegdateInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrRegdateInp.Top = (int)(addMbrCont.Height*0.56470588);
		int addMbrRegdateInpFont = (int)(formWidth*0.00885417);
		addMbrRegdateInp.Font = new Font("arial",addMbrRegdateInpFont);

		addMbrStatusLbl.Width = (int)(formWidth*0.15625);
		addMbrStatusLbl.Height = (int)(formHeight*0.04960317);
		addMbrStatusLbl.Left = (int)(addMbrCont.Width*0.08);
		addMbrStatusLbl.Top = (int)(addMbrCont.Height*0.68235294);
		int addMbrStatusLblFont = (int)(formWidth*0.00885417);
		addMbrStatusLbl.Font = new Font("times new roman",addMbrStatusLblFont,FontStyle.Bold);

		addMbrStatusInp.Width = (int)(formWidth*0.20833333);
		addMbrStatusInp.Left = (int)(addMbrCont.Width*0.4);
		addMbrStatusInp.Top = (int)(addMbrCont.Height*0.68235294);
		int addMbrStatusInpFont = (int)(formWidth*0.00885417);
		addMbrStatusInp.Font = new Font("arial",addMbrStatusInpFont);

		addMbrAddBtn.Width = (int)(formWidth*0.20833333);
		addMbrAddBtn.Height = (int)(formHeight*0.09920635);
		addMbrAddBtn.Left = (int)(addMbrCont.Width*0.3);
		addMbrAddBtn.Top = (int)(addMbrCont.Height*0.82352941);
		int addMbrAddBtnFont = (int)(formWidth*0.01041667);
		addMbrAddBtn.Font = new Font("arial",addMbrAddBtnFont,FontStyle.Bold);

	}

	private void mbrMgtSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvBkMgt.ForeColor = Color.Green;
	}
	private void mbrMgtSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvBkMgt.ForeColor = Color.Blue;
	}

	private void mbrMgtSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvDshBrd.ForeColor = Color.Green;
	}
	private void mbrMgtSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvDshBrd.ForeColor = Color.Blue;
	}

	private void mbrMgtSnvBrw_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvBrw.ForeColor = Color.Green;
	}
	private void mbrMgtSnvBrw_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvBrw.ForeColor = Color.Blue;
	}

	private void mbrMgtSnvRtn_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvRtn.ForeColor = Color.Green;
	}
	private void mbrMgtSnvRtn_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvRtn.ForeColor = Color.Blue;
	}

	private void mbrMgtSnvRpt_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvRpt.ForeColor = Color.Green;
	}
	private void mbrMgtSnvRpt_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvRpt.ForeColor = Color.Blue;
	}

	private void mbrMgtSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvUsrStg.ForeColor = Color.Green;
	}
	private void mbrMgtSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvUsrStg.ForeColor = Color.Blue;
	}

	private void mbrMgtSnvSrch_MouseEnter (object sender, EventArgs e) {
		mbrMgtSnvSrch.ForeColor = Color.Green;
	}
	private void mbrMgtSnvSrch_MouseLeave (object sender, EventArgs e) {
		mbrMgtSnvSrch.ForeColor = Color.Blue;
	}

	private void MbrMgtAddBtn_Clicked (object sender, EventArgs e) {
		addMbrCont.Show();
	}

	private void addMbrCloseBtn_Clicked (object sender, EventArgs e) {
		addMbrCont.Hide();
		LoadData();
	}

	private void addMbrAddBtn_Clicked (object sender, EventArgs e) {
		try {
			string name = addMbrNameInp.Text;
			string email = addMbrEmailInp.Text;
			string phone_number = addMbrPhoneInp.Text;
			DateTime registration_date = addMbrRegdateInp.Value;
			string status = addMbrStatusInp.SelectedItem.ToString();
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone_number) || string.IsNullOrEmpty(status)) {
				MessageBox.Show("All fields must have valid values.");
            			return;
			}
	        	string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "INSERT INTO members (name,email,phone_number,registration_date,status) VALUES(@name,@email,@phone_number,@registration_date,@status)";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@name",name);
				command.Parameters.AddWithValue("@email",email);
				command.Parameters.AddWithValue("@phone_number",phone_number);
				command.Parameters.AddWithValue("@registration_date",registration_date);
				command.Parameters.AddWithValue("@status",status);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
               				MessageBox.Show("Member Added successfully.");
           			}
            			else {
                			MessageBox.Show("Member Not Added");
            			}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Add Member Error: {ex.Message}");
		}
	}

	private void LoadData () {
		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
		try {
			string query = "SELECT * FROM members";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter(query,connection);
				DataTable table = new DataTable();
				adapter.Fill(table);
				MbrMgtGridView.DataSource = table;
			}
		} catch (Exception ex) {
			MessageBox.Show($"Book Records Error: {ex.Message}");
		}
	}

	private void MbrMgtGridView_CellValueChanged (object sender, DataGridViewCellEventArgs e) {
		try {
			if (e.RowIndex < 0 || e.ColumnIndex < 0) {
            			return;
			}
			DataGridViewRow row = MbrMgtGridView.Rows[e.RowIndex];
			int member_id = Convert.ToInt32(row.Cells["member_id"].Value);
			string name = row.Cells["name"].Value?.ToString();
			string email = row.Cells["email"].Value?.ToString();
			string phone_number = row.Cells["phone_number"].Value?.ToString();
			DateTime registration_date = DateTime.Parse(row.Cells["registration_date"].Value?.ToString());
			string status = row.Cells["status"].Value?.ToString();
			 if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone_number) || string.IsNullOrEmpty(status)) {
            			MessageBox.Show("All fields must have valid values.");
            			return;
        		}
        		string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "UPDATE members SET name=@name, email=@email, phone_number=@phone_number, registration_date=@registration_date, status=@status WHERE member_id=@member_id";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@member_id",member_id);
				command.Parameters.AddWithValue("@name",name);
				command.Parameters.AddWithValue("@email",email);
				command.Parameters.AddWithValue("@phone_number",phone_number);
				command.Parameters.AddWithValue("@registration_date",registration_date);
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
			MessageBox.Show($"Update Member Error: {ex.Message}");
		}
	}

	private void MbrMgtGridView_KeyDown (object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Delete && MbrMgtGridView.SelectedRows.Count > 0) {
			foreach (DataGridViewRow row in MbrMgtGridView.SelectedRows) {
				DeleteRecord(Convert.ToInt32(row.Cells["member_id"].Value));
				MbrMgtGridView.Rows.Remove(row);
			}
		}
	}

	private void DeleteRecord (int memberId) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "DELETE FROM members WHERE member_id=@memberId";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@memberId",memberId);
				connection.Open();
				command.ExecuteNonQuery();
				MessageBox.Show("Member Record Deleted Successfully!");
			}
		} catch (Exception ex) {
			MessageBox.Show($"Delete Member Error: {ex.Message}");
		}
	}

	private void activateEditBtn_Clicked (object sender, EventArgs e) {
		actvateEditMessage.Show();
		MbrMgtGridView.ReadOnly = false;
		MbrMgtGridView.Columns[0].ReadOnly = true;
		MbrMgtGridView.Columns[4].ReadOnly = true;
	}

}
