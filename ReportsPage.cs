
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniProjectApp;

public partial class ReportsPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private DashboardPage DashboardForm;
	private MembermanagementPage MembermanagementForm;
	private BorrowPage BorrowForm;
	private ReturnPage ReturnForm;
	private BookmanagementPage BookmanagementForm;
	private UsersettingPage UsersettingForm;
	private SearchPage SearchForm;

	private string reportType;
	private string reportFilter;

	private string cntQuery;
	private	string query;
	private string rptQuery;
	private string current_time;


    public ReportsPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	rptsLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


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


	private void rptsSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void rptsSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void rptsSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void rptsSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void rptsSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}

	private void rptsSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void rptsSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}



	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);
		
		rptsHeader.Width = (int)(screenWidth*1);
		rptsHeader.Height = (int)(screenHeight*0.1488);
		rptsHeader.Left = (int)(screenWidth*0);
		rptsHeader.Top = (int)(screenHeight*0);

		rptsMainTitle.Width = (int)(screenWidth*0.625);
		rptsMainTitle.Height = (int)(screenHeight*0.0793);
		rptsMainTitle.Left = (int)(rptsHeader.Width*0.1302);
		rptsMainTitle.Top = (int)(rptsHeader.Height*0);
		int rptsMainTitleFont = (int)(screenWidth*0.0166);
		rptsMainTitle.Font = new Font("roboto",rptsMainTitleFont, FontStyle.Bold);

		rptsPgeTitle.Width = (int)(screenWidth*0.625);
		rptsPgeTitle.Height = (int)(screenHeight*0.0595);
		rptsPgeTitle.Left = (int)(rptsHeader.Width*0.1302);
		rptsPgeTitle.Top = (int)(rptsHeader.Height*0.5666);
		int rptsPgeTitleFont = (int)(screenWidth*0.0104);
		rptsPgeTitle.Font = new Font("broadway",rptsPgeTitleFont);

		rptsLogo.Width = (int)(screenWidth*0.0781);
		rptsLogo.Height = (int)(screenHeight*0.0892);
		rptsLogo.Left = (int)(rptsHeader.Width*0.0260);
		rptsLogo.Top = (int)(rptsHeader.Height*0.2);

		rptsSideNav.Width = (int)(screenWidth*0.2604);
		rptsSideNav.Height = (int)(screenHeight*0.744);
		rptsSideNav.Left = (int)(screenWidth*0.0156);
		rptsSideNav.Top = (int)(screenHeight*0.1984);

		rptsSnvTitle.Width = (int)(screenWidth*0.2604);
		rptsSnvTitle.Height = (int)(screenHeight*0.0892);
		rptsSnvTitle.Left = (int)(rptsSideNav.Width*0);
		rptsSnvTitle.Top = (int)(rptsSideNav.Height*0);
		int rptsSnvTitleFont = (int)(screenWidth*0.0130);
		rptsSnvTitle.Font = new Font("arial",rptsSnvTitleFont,FontStyle.Bold);

		rptsSnvBkMgt.Width = (int)(screenWidth*0.2083);
		rptsSnvBkMgt.Height = (int)(screenHeight*0.0595);
		rptsSnvBkMgt.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvBkMgt.Top = (int)(rptsSideNav.Height*0.16);
		int rptsSnvBkMgtFont = (int)(screenWidth*0.0088);
		rptsSnvBkMgt.Font = new Font("Verdana",rptsSnvBkMgtFont,FontStyle.Underline);

		rptsSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		rptsSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		rptsSnvMbrMgt.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvMbrMgt.Top = (int)(rptsSideNav.Height*0.2666);
		int rptsSnvMbrMgtFont = (int)(screenWidth*0.0088);
		rptsSnvMbrMgt.Font = new Font("Verdana",rptsSnvMbrMgtFont,FontStyle.Underline);

		rptsSnvBrw.Width = (int)(screenWidth*0.2083);
		rptsSnvBrw.Height = (int)(screenHeight*0.0595);
		rptsSnvBrw.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvBrw.Top = (int)(rptsSideNav.Height*0.3733);
		int rptsSnvBrwFont = (int)(screenWidth*0.0088);
		rptsSnvBrw.Font = new Font("Verdana",rptsSnvBrwFont,FontStyle.Underline);

		rptsSnvRtn.Width = (int)(screenWidth*0.2083);
		rptsSnvRtn.Height = (int)(screenHeight*0.0595);
		rptsSnvRtn.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvRtn.Top = (int)(rptsSideNav.Height*0.48);
		int rptsSnvRtnFont = (int)(screenWidth*0.0088);
		rptsSnvRtn.Font = new Font("Verdana",rptsSnvRtnFont,FontStyle.Underline);

		rptsSnvDshBrd.Width = (int)(screenWidth*0.2083);
		rptsSnvDshBrd.Height = (int)(screenHeight*0.0595);
		rptsSnvDshBrd.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvDshBrd.Top = (int)(rptsSideNav.Height*0.5866);
		int rptsSnvDshBrdFont = (int)(screenWidth*0.0088);
		rptsSnvDshBrd.Font = new Font("Verdana",rptsSnvDshBrdFont,FontStyle.Underline);

		rptsSnvUsrStg.Width = (int)(screenWidth*0.2083);
		rptsSnvUsrStg.Height = (int)(screenHeight*0.0595);
		rptsSnvUsrStg.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvUsrStg.Top = (int)(rptsSideNav.Height*0.6933);
		int rptsSnvUsrStgFont = (int)(screenWidth*0.0088);
		rptsSnvUsrStg.Font = new Font("Verdana",rptsSnvUsrStgFont,FontStyle.Underline);

		rptsSnvSrch.Width = (int)(screenWidth*0.2083);
		rptsSnvSrch.Height = (int)(screenHeight*0.0595);
		rptsSnvSrch.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvSrch.Top = (int)(rptsSideNav.Height*0.8);
		int rptsSnvSrchFont = (int)(screenWidth*0.0088);
		rptsSnvSrch.Font = new Font("Verdana",rptsSnvSrchFont,FontStyle.Underline);

		rptsMainCont.Width = (int)(screenWidth*0.6666);
		rptsMainCont.Height = (int)(screenHeight*0.7936);
		rptsMainCont.Left = (int)(screenWidth*0.3281);
		rptsMainCont.Top = (int)(screenHeight*0.1587);

		rptsMainContTitle.Width = (int)(screenWidth*0.234375);
		rptsMainContTitle.Height = (int)(screenHeight*0.04960317);
		rptsMainContTitle.Left = (int)(rptsMainCont.Width*0.3515625);
		rptsMainContTitle.Top = (int)(rptsMainCont.Height*0.0375);
		int rptsMainContTitleFont = (int)(screenWidth*0.009375);
		rptsMainContTitle.Font = new Font("Verdana",rptsMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		chseRptTypeLbl.Width = (int)(screenWidth*0.16666667);
		chseRptTypeLbl.Height = (int)(screenHeight*0.03968254);
		chseRptTypeLbl.Left = (int)(rptsMainCont.Width*0.1171875);
		chseRptTypeLbl.Top = (int)(rptsMainCont.Height*0.1875);
		int chseRptTypeLblFont = (int)(screenWidth*0.009375);
		chseRptTypeLbl.Font = new Font("times new roman",chseRptTypeLblFont,FontStyle.Bold);

		chseRptTypeInp.Width = (int)(screenWidth*0.15625);
		chseRptTypeInp.Height = (int)(screenHeight*0.17857143);
		chseRptTypeInp.Left = (int)(rptsMainCont.Width*0.390625);
		chseRptTypeInp.Top = (int)(rptsMainCont.Height*0.125);
		int chseRptTypeInpFont = (int)(screenWidth*0.00833333);
		chseRptTypeInp.Font = new Font("",chseRptTypeInpFont);

		chseRptTypeBtn.Width = (int)(screenWidth*0.09375);
		chseRptTypeBtn.Height = (int)(screenHeight*0.04960317);
		chseRptTypeBtn.Left = (int)(rptsMainCont.Width*0.6953125);
		chseRptTypeBtn.Top = (int)(rptsMainCont.Height*0.1875);
		int chseRptTypeBtnFont = (int)(screenWidth*0.00885417);
		chseRptTypeBtn.Font = new Font("arial",chseRptTypeBtnFont,FontStyle.Bold);

		chseRptFilterLbl.Width = (int)(screenWidth*0.11458333);
		chseRptFilterLbl.Height = (int)(screenHeight*0.03968254);
		chseRptFilterLbl.Left = (int)(rptsMainCont.Width*0.1171875);
		chseRptFilterLbl.Top = (int)(rptsMainCont.Height*0.375);
		int chseRptFilterLblFont = (int)(screenWidth*0.009375);
		chseRptFilterLbl.Font = new Font("times new roman",chseRptFilterLblFont,FontStyle.Bold);

		chseRptFilterInp.Width = (int)(screenWidth*0.22395833);
		chseRptFilterInp.Height = (int)(screenHeight*0.14880952);
		chseRptFilterInp.Left = (int)(rptsMainCont.Width*0.390625);
		chseRptFilterInp.Top = (int)(rptsMainCont.Height*0.375);
		int chseRptFilterInpFont = (int)(screenWidth*0.00833333);
		chseRptFilterInp.Font = new Font("",chseRptFilterInpFont);

		chseRptFilterBtn.Width = (int)(screenWidth*0.09375);
		chseRptFilterBtn.Height = (int)(screenHeight*0.04960317);
		chseRptFilterBtn.Left = (int)(rptsMainCont.Width*0.78125);
		chseRptFilterBtn.Top = (int)(rptsMainCont.Height*0.375);
		int chseRptFilterBtnFont = (int)(screenWidth*0.00885417);
		chseRptFilterBtn.Font = new Font("arial",chseRptFilterBtnFont,FontStyle.Bold);

		generateRptBtn.Width = (int)(screenWidth*0.234375);
		generateRptBtn.Height = (int)(screenHeight*0.14880952);
		generateRptBtn.Left = (int)(rptsMainCont.Width*0.3125);
		generateRptBtn.Top = (int)(rptsMainCont.Height*0.6625);
		int generateRptBtnFont = (int)(screenWidth*0.009375);
		generateRptBtn.Font = new Font("arial",generateRptBtnFont,FontStyle.Bold);

		rptResultCont.Width = (int)(screenWidth*0.52083333);
		rptResultCont.Height = (int)(screenHeight*0.84325397);
		rptResultCont.Left = (int)(screenWidth*0.23958333);
		rptResultCont.Top = (int)(screenHeight*0.08928571);

		rptResultCloseBtn.Width = (int)(screenWidth*0.03125);
		rptResultCloseBtn.Height = (int)(screenHeight*0.05952381);
		rptResultCloseBtn.Left = (int)(rptResultCont.Width*0.9);
		rptResultCloseBtn.Top = (int)(rptResultCont.Height*0.01176471);
		int rptResultCloseBtnFont = (int)(screenWidth*0.00833333);
		rptResultCloseBtn.Font = new Font("arial",rptResultCloseBtnFont,FontStyle.Bold);

		rptResultMainTitle.Width = (int)(screenWidth*0.26041667);
		rptResultMainTitle.Height = (int)(screenHeight*0.05952381);
		rptResultMainTitle.Left = (int)(rptResultCont.Width*0.25);
		rptResultMainTitle.Top = (int)(rptResultCont.Height*0.03529412);
		int rptResultMainTitleFont = (int)(screenWidth*0.01197917);
		rptResultMainTitle.Font = new Font("arial",rptResultMainTitleFont,FontStyle.Bold|FontStyle.Underline);

		rptResultCountLbl.Width = (int)(screenWidth*0.11458333);
		rptResultCountLbl.Height = (int)(screenHeight*0.04960317);
		rptResultCountLbl.Left = (int)(rptResultCont.Width*0.4);
		rptResultCountLbl.Top = (int)(rptResultCont.Height*0.17647059);
		int rptResultCountLblFont = (int)(screenWidth*0.009375);
		rptResultCountLbl.Font = new Font("times new roman",rptResultCountLblFont,FontStyle.Bold);

		rptResultCountVal.Width = (int)(screenWidth*0.05208333);
		rptResultCountVal.Height = (int)(screenHeight*0.04960317);
		rptResultCountVal.Left = (int)(rptResultCont.Width*0.62);
		rptResultCountVal.Top = (int)(rptResultCont.Height*0.17647059);
		int rptResultCountValFont = (int)(screenWidth*0.01041667);
		rptResultCountVal.Font = new Font("arial",rptResultCountValFont,FontStyle.Bold);

		rptResultCatTitle.Width = (int)(screenWidth*0.28645833);
		rptResultCatTitle.Height = (int)(screenHeight*0.04960317);
		rptResultCatTitle.Left = (int)(rptResultCont.Width*0.3);
		rptResultCatTitle.Top = (int)(rptResultCont.Height*0.29411765);
		int rptResultCatTitleFont = (int)(screenWidth*0.0078125);
		rptResultCatTitle.Font = new Font("arial",rptResultCatTitleFont,FontStyle.Bold|FontStyle.Underline);

		rptResultGridview.Width = (int)(screenWidth*0.51041667);
		rptResultGridview.Height = (int)(screenHeight*0.29761905);
		rptResultGridview.Left = (int)(rptResultCont.Width*0.01);
		rptResultGridview.Top = (int)(rptResultCont.Height*0.35294118);
		int rptResultGridviewFont = (int)(screenWidth*0.00520833);
		rptResultGridview.Font = new Font("arial",rptResultGridviewFont);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		rptsHeader.Width = (int)(formWidth*1);
		rptsHeader.Height = (int)(formHeight*0.1488);
		rptsHeader.Left = (int)(formWidth*0);
		rptsHeader.Top = (int)(formHeight*0);

		rptsMainTitle.Width = (int)(formWidth*0.625);
		rptsMainTitle.Height = (int)(formHeight*0.0793);
		rptsMainTitle.Left = (int)(rptsHeader.Width*0.1302);
		rptsMainTitle.Top = (int)(rptsHeader.Height*0);
		int rptsMainTitleFont = (int)(formWidth*0.0166);
		rptsMainTitle.Font = new Font("roboto",rptsMainTitleFont, FontStyle.Bold);

		rptsPgeTitle.Width = (int)(formWidth*0.625);
		rptsPgeTitle.Height = (int)(formHeight*0.0595);
		rptsPgeTitle.Left = (int)(rptsHeader.Width*0.1302);
		rptsPgeTitle.Top = (int)(rptsHeader.Height*0.5666);
		int rptsPgeTitleFont = (int)(formWidth*0.0104);
		rptsPgeTitle.Font = new Font("broadway",rptsPgeTitleFont);

		rptsLogo.Width = (int)(formWidth*0.0781);
		rptsLogo.Height = (int)(formHeight*0.0892);
		rptsLogo.Left = (int)(rptsHeader.Width*0.0260);
		rptsLogo.Top = (int)(rptsHeader.Height*0.2);

		rptsSideNav.Width = (int)(formWidth*0.2604);
		rptsSideNav.Height = (int)(formHeight*0.744);
		rptsSideNav.Left = (int)(formWidth*0.0156);
		rptsSideNav.Top = (int)(formHeight*0.1984);

		rptsSnvTitle.Width = (int)(formWidth*0.2604);
		rptsSnvTitle.Height = (int)(formHeight*0.0892);
		rptsSnvTitle.Left = (int)(rptsSideNav.Width*0);
		rptsSnvTitle.Top = (int)(rptsSideNav.Height*0);
		int rptsSnvTitleFont = (int)(formWidth*0.0130);
		rptsSnvTitle.Font = new Font("arial",rptsSnvTitleFont,FontStyle.Bold);

		rptsSnvBkMgt.Width = (int)(formWidth*0.2083);
		rptsSnvBkMgt.Height = (int)(formHeight*0.0595);
		rptsSnvBkMgt.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvBkMgt.Top = (int)(rptsSideNav.Height*0.16);
		int rptsSnvBkMgtFont = (int)(formWidth*0.0088);
		rptsSnvBkMgt.Font = new Font("Verdana",rptsSnvBkMgtFont,FontStyle.Underline);

		rptsSnvMbrMgt.Width = (int)(formWidth*0.2083);
		rptsSnvMbrMgt.Height = (int)(formHeight*0.0595);
		rptsSnvMbrMgt.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvMbrMgt.Top = (int)(rptsSideNav.Height*0.2666);
		int rptsSnvMbrMgtFont = (int)(formWidth*0.0088);
		rptsSnvMbrMgt.Font = new Font("Verdana",rptsSnvMbrMgtFont,FontStyle.Underline);

		rptsSnvBrw.Width = (int)(formWidth*0.2083);
		rptsSnvBrw.Height = (int)(formHeight*0.0595);
		rptsSnvBrw.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvBrw.Top = (int)(rptsSideNav.Height*0.3733);
		int rptsSnvBrwFont = (int)(formWidth*0.0088);
		rptsSnvBrw.Font = new Font("Verdana",rptsSnvBrwFont,FontStyle.Underline);

		rptsSnvRtn.Width = (int)(formWidth*0.2083);
		rptsSnvRtn.Height = (int)(formHeight*0.0595);
		rptsSnvRtn.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvRtn.Top = (int)(rptsSideNav.Height*0.48);
		int rptsSnvRtnFont = (int)(formWidth*0.0088);
		rptsSnvRtn.Font = new Font("Verdana",rptsSnvRtnFont,FontStyle.Underline);

		rptsSnvDshBrd.Width = (int)(formWidth*0.2083);
		rptsSnvDshBrd.Height = (int)(formHeight*0.0595);
		rptsSnvDshBrd.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvDshBrd.Top = (int)(rptsSideNav.Height*0.5866);
		int rptsSnvDshBrdFont = (int)(formWidth*0.0088);
		rptsSnvDshBrd.Font = new Font("Verdana",rptsSnvDshBrdFont,FontStyle.Underline);

		rptsSnvUsrStg.Width = (int)(formWidth*0.2083);
		rptsSnvUsrStg.Height = (int)(formHeight*0.0595);
		rptsSnvUsrStg.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvUsrStg.Top = (int)(rptsSideNav.Height*0.6933);
		int rptsSnvUsrStgFont = (int)(formWidth*0.0088);
		rptsSnvUsrStg.Font = new Font("Verdana",rptsSnvUsrStgFont,FontStyle.Underline);

		rptsSnvSrch.Width = (int)(formWidth*0.2083);
		rptsSnvSrch.Height = (int)(formHeight*0.0595);
		rptsSnvSrch.Left = (int)(rptsSideNav.Width*0.1);
		rptsSnvSrch.Top = (int)(rptsSideNav.Height*0.8);
		int rptsSnvSrchFont = (int)(formWidth*0.0088);
		rptsSnvSrch.Font = new Font("Verdana",rptsSnvSrchFont,FontStyle.Underline);

		rptsMainCont.Width = (int)(formWidth*0.6666);
		rptsMainCont.Height = (int)(formHeight*0.7936);
		rptsMainCont.Left = (int)(formWidth*0.3281);
		rptsMainCont.Top = (int)(formHeight*0.1587);

		rptsMainContTitle.Width = (int)(formWidth*0.234375);
		rptsMainContTitle.Height = (int)(formHeight*0.04960317);
		rptsMainContTitle.Left = (int)(rptsMainCont.Width*0.3515625);
		rptsMainContTitle.Top = (int)(rptsMainCont.Height*0.0375);
		int rptsMainContTitleFont = (int)(formWidth*0.009375);
		rptsMainContTitle.Font = new Font("Verdana",rptsMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		chseRptTypeLbl.Width = (int)(formWidth*0.16666667);
		chseRptTypeLbl.Height = (int)(formHeight*0.03968254);
		chseRptTypeLbl.Left = (int)(rptsMainCont.Width*0.1171875);
		chseRptTypeLbl.Top = (int)(rptsMainCont.Height*0.1875);
		int chseRptTypeLblFont = (int)(formWidth*0.009375);
		chseRptTypeLbl.Font = new Font("times new roman",chseRptTypeLblFont,FontStyle.Bold);

		chseRptTypeInp.Width = (int)(formWidth*0.15625);
		chseRptTypeInp.Height = (int)(formHeight*0.17857143);
		chseRptTypeInp.Left = (int)(rptsMainCont.Width*0.390625);
		chseRptTypeInp.Top = (int)(rptsMainCont.Height*0.125);
		int chseRptTypeInpFont = (int)(formWidth*0.00833333);
		chseRptTypeInp.Font = new Font("",chseRptTypeInpFont);

		chseRptTypeBtn.Width = (int)(formWidth*0.09375);
		chseRptTypeBtn.Height = (int)(formHeight*0.04960317);
		chseRptTypeBtn.Left = (int)(rptsMainCont.Width*0.6953125);
		chseRptTypeBtn.Top = (int)(rptsMainCont.Height*0.1875);
		int chseRptTypeBtnFont = (int)(formWidth*0.00885417);
		chseRptTypeBtn.Font = new Font("arial",chseRptTypeBtnFont,FontStyle.Bold);

		chseRptFilterLbl.Width = (int)(formWidth*0.11458333);
		chseRptFilterLbl.Height = (int)(formHeight*0.03968254);
		chseRptFilterLbl.Left = (int)(rptsMainCont.Width*0.1171875);
		chseRptFilterLbl.Top = (int)(rptsMainCont.Height*0.375);
		int chseRptFilterLblFont = (int)(formWidth*0.009375);
		chseRptFilterLbl.Font = new Font("times new roman",chseRptFilterLblFont,FontStyle.Bold);

		chseRptFilterInp.Width = (int)(formWidth*0.22395833);
		chseRptFilterInp.Height = (int)(formHeight*0.14880952);
		chseRptFilterInp.Left = (int)(rptsMainCont.Width*0.390625);
		chseRptFilterInp.Top = (int)(rptsMainCont.Height*0.375);
		int chseRptFilterInpFont = (int)(formWidth*0.00833333);
		chseRptFilterInp.Font = new Font("",chseRptFilterInpFont);

		chseRptFilterBtn.Width = (int)(formWidth*0.09375);
		chseRptFilterBtn.Height = (int)(formHeight*0.04960317);
		chseRptFilterBtn.Left = (int)(rptsMainCont.Width*0.78125);
		chseRptFilterBtn.Top = (int)(rptsMainCont.Height*0.375);
		int chseRptFilterBtnFont = (int)(formWidth*0.00885417);
		chseRptFilterBtn.Font = new Font("arial",chseRptFilterBtnFont,FontStyle.Bold);

		generateRptBtn.Width = (int)(formWidth*0.234375);
		generateRptBtn.Height = (int)(formHeight*0.14880952);
		generateRptBtn.Left = (int)(rptsMainCont.Width*0.3125);
		generateRptBtn.Top = (int)(rptsMainCont.Height*0.6625);
		int generateRptBtnFont = (int)(formWidth*0.009375);
		generateRptBtn.Font = new Font("arial",generateRptBtnFont,FontStyle.Bold);

		rptResultCont.Width = (int)(formWidth*0.52083333);
		rptResultCont.Height = (int)(formHeight*0.84325397);
		rptResultCont.Left = (int)(formWidth*0.23958333);
		rptResultCont.Top = (int)(formHeight*0.08928571);

		rptResultCloseBtn.Width = (int)(formWidth*0.03125);
		rptResultCloseBtn.Height = (int)(formHeight*0.05952381);
		rptResultCloseBtn.Left = (int)(rptResultCont.Width*0.9);
		rptResultCloseBtn.Top = (int)(rptResultCont.Height*0.01176471);
		int rptResultCloseBtnFont = (int)(formWidth*0.00833333);
		rptResultCloseBtn.Font = new Font("arial",rptResultCloseBtnFont,FontStyle.Bold);

		rptResultMainTitle.Width = (int)(formWidth*0.26041667);
		rptResultMainTitle.Height = (int)(formHeight*0.05952381);
		rptResultMainTitle.Left = (int)(rptResultCont.Width*0.25);
		rptResultMainTitle.Top = (int)(rptResultCont.Height*0.03529412);
		int rptResultMainTitleFont = (int)(formWidth*0.01197917);
		rptResultMainTitle.Font = new Font("arial",rptResultMainTitleFont,FontStyle.Bold|FontStyle.Underline);

		rptResultCountLbl.Width = (int)(formWidth*0.11458333);
		rptResultCountLbl.Height = (int)(formHeight*0.04960317);
		rptResultCountLbl.Left = (int)(rptResultCont.Width*0.4);
		rptResultCountLbl.Top = (int)(rptResultCont.Height*0.17647059);
		int rptResultCountLblFont = (int)(formWidth*0.009375);
		rptResultCountLbl.Font = new Font("times new roman",rptResultCountLblFont,FontStyle.Bold);

		rptResultCountVal.Width = (int)(formWidth*0.05208333);
		rptResultCountVal.Height = (int)(formHeight*0.04960317);
		rptResultCountVal.Left = (int)(rptResultCont.Width*0.62);
		rptResultCountVal.Top = (int)(rptResultCont.Height*0.17647059);
		int rptResultCountValFont = (int)(formWidth*0.01041667);
		rptResultCountVal.Font = new Font("arial",rptResultCountValFont,FontStyle.Bold);

		rptResultCatTitle.Width = (int)(formWidth*0.28645833);
		rptResultCatTitle.Height = (int)(formHeight*0.04960317);
		rptResultCatTitle.Left = (int)(rptResultCont.Width*0.3);
		rptResultCatTitle.Top = (int)(rptResultCont.Height*0.29411765);
		int rptResultCatTitleFont = (int)(formWidth*0.0078125);
		rptResultCatTitle.Font = new Font("arial",rptResultCatTitleFont,FontStyle.Bold|FontStyle.Underline);

		rptResultGridview.Width = (int)(formWidth*0.51041667);
		rptResultGridview.Height = (int)(formHeight*0.29761905);
		rptResultGridview.Left = (int)(rptResultCont.Width*0.01);
		rptResultGridview.Top = (int)(rptResultCont.Height*0.35294118);
		int rptResultGridviewFont = (int)(formWidth*0.00520833);
		rptResultGridview.Font = new Font("arial",rptResultGridviewFont);

	}

	private void rptsSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		rptsSnvBkMgt.ForeColor = Color.Green;
	}
	private void rptsSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		rptsSnvBkMgt.ForeColor = Color.Blue;
	}

	private void rptsSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		rptsSnvMbrMgt.ForeColor = Color.Green;
	}
	private void rptsSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		rptsSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void rptsSnvBrw_MouseEnter (object sender, EventArgs e) {
		rptsSnvBrw.ForeColor = Color.Green;
	}
	private void rptsSnvBrw_MouseLeave (object sender, EventArgs e) {
		rptsSnvBrw.ForeColor = Color.Blue;
	}

	private void rptsSnvRtn_MouseEnter (object sender, EventArgs e) {
		rptsSnvRtn.ForeColor = Color.Green;
	}
	private void rptsSnvRtn_MouseLeave (object sender, EventArgs e) {
		rptsSnvRtn.ForeColor = Color.Blue;
	}

	private void rptsSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		rptsSnvDshBrd.ForeColor = Color.Green;
	}
	private void rptsSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		rptsSnvDshBrd.ForeColor = Color.Blue;
	}

	private void rptsSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		rptsSnvUsrStg.ForeColor = Color.Green;
	}
	private void rptsSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		rptsSnvUsrStg.ForeColor = Color.Blue;
	}

	private void rptsSnvSrch_MouseEnter (object sender, EventArgs e) {
		rptsSnvSrch.ForeColor = Color.Green;
	}
	private void rptsSnvSrch_MouseLeave (object sender, EventArgs e) {
		rptsSnvSrch.ForeColor = Color.Blue;
	}

	private void chseRptTypeBtn_Clicked (object sender, EventArgs e) {
		chseRptFilterInp.Items.Clear();
		reportType = chseRptTypeInp.SelectedItem.ToString();
		if (reportType == "Member Report") {
			chseRptFilterInp.Items.Add("Active Members List");
			chseRptFilterInp.Items.Add("Inactive Members List");
			chseRptFilterInp.Items.Add("Members With Overdue");
		} else if (reportType == "Book Report") {
			chseRptFilterInp.Items.Add("Available Books List");
			chseRptFilterInp.Items.Add("Borrowed Books List");
			chseRptFilterInp.Items.Add("Most Borrowed Books");
		} else if (reportType == "Special Report") {
			chseRptFilterInp.Items.Add("Report On Reports");
			chseRptFilterInp.Items.Add("User Report");
		} else {
			chseRptFilterInp.Items.Add("Active Transactions List");
			chseRptFilterInp.Items.Add("Completed Transactions List");
			chseRptFilterInp.Items.Add("User With Most Transactions");
		}
		chseRptFilterLbl.Show();
		chseRptFilterInp.Show();
		chseRptFilterBtn.Show();
	}

	private void chseRptFilterBtn_Clicked (object sender, EventArgs e) {
		reportFilter = chseRptFilterInp.SelectedItem.ToString();
		generateRptBtn.Show();
	}

	private void generateRptBtn_Clicked (object sender, EventArgs e) {
		rptResultCont.Show();
		generateReport();
	}

	private void rptResultCloseBtn_Clicked (object sender, EventArgs e) {
		rptResultCont.Hide();
	}

	private void generateReport () {
		rptResultCatTitle.Text = reportFilter+" Report";
		if (reportFilter == "Active Members List") {
			query = "SELECT *FROM members WHERE status='active';";
			cntQuery = "SELECT COUNT(member_id) FROM members WHERE status='active';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Active Members List',@current_time);";
		} else if (reportFilter == "Inactive Members List") {
			query = "SELECT *FROM members WHERE status='inactive';";
			cntQuery = "SELECT COUNT(member_id) FROM members WHERE status='inactive';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Inactive Members List',@current_time);";
		} else if (reportFilter == "Members With Overdue") {
			query = "SELECT T.member_id, T.book_id, B.title, M.name FROM transactions as T JOIN books as B ON T.book_id = B.book_id JOIN members as M ON T.member_id = M.member_id WHERE T.status='overdue';";
			cntQuery = "SELECT COUNT(member_id) FROM transactions WHERE status='overdue';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Members With Overdue',@current_time);";
		} else if (reportFilter == "Available Books List") {
			query = "SELECT *FROM books WHERE status='available';";
			cntQuery = "SELECT COUNT(book_id) FROM books WHERE status='available';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Available Books List',@current_time);";
		} else if (reportFilter == "Borrowed Books List") {
			query = "SELECT *FROM books WHERE status='borrowed';";
			cntQuery = "SELECT COUNT(book_id) FROM books WHERE status='borrowed';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Borrowed Books List',@current_time);";
		} else if (reportFilter == "Most Borrowed Books") {
			query = "SELECT T.book_id, B.title, COUNT(T.book_id) as borrow_count FROM transactions as T JOIN books as B ON T.book_id = B.book_id GROUP BY T.book_id ORDER BY borrow_count DESC;";
			cntQuery = "SELECT COUNT(transaction_id) FROM transactions;";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Most Borrowed Books',@current_time);";
		} else if (reportFilter == "Active Transactions List") {
			query = "SELECT *FROM transactions WHERE status='active';";
			cntQuery = "SELECT COUNT(transaction_id) FROM transactions WHERE status='active';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Active Transactions List',@current_time);";
		} else if (reportFilter == "Completed Transactions List") {
			query = "SELECT *FROM transactions WHERE status='completed';";
			cntQuery = "SELECT COUNT(transaction_id) FROM transactions WHERE status='completed';";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Complete Transactions List',@current_time);";
		} else if (reportFilter == "User With Most Transactions") {
			query = "SELECT M.name, M.phone_number, T.member_id, COUNT(T.transaction_id) AS transactions_count FROM transactions as T JOIN members as M ON T.member_id = M.member_id GROUP BY T.member_id ORDER BY transactions_count DESC LIMIT 1;";
			cntQuery = "SELECT COUNT(transaction_id) FROM transactions;";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('User With Most Transactions',@current_time);";
		} else if (reportFilter == "Report On Reports") {
			query = "SELECT *FROM reports;";
			cntQuery = "SELECT COUNT(report_id) FROM reports;";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('Report On Reports',@current_time);";
		} else if (reportFilter == "User Report") {
			query = "SELECT *FROM users;";
			cntQuery = "SELECT COUNT(user_id) FROM users;";
			current_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
			rptQuery = "INSERT INTO reports (report_type, generated_at) VALUES('User Report',@current_time);";
		} else {
			MessageBox.Show("Error on reportFilter: "+reportFilter);
		}

		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter();
				adapter.SelectCommand = new MySqlCommand(query,connection);
				DataTable table = new DataTable();
				adapter.Fill(table);
				rptResultGridview.DataSource = table;
			}
			using (MySqlConnection connection2 = new MySqlConnection(connectionString)) {
				connection2.Open();
				MySqlCommand command = new MySqlCommand(cntQuery,connection2);
				int totalCount = Convert.ToInt32(command.ExecuteScalar());
				rptResultCountVal.Text = totalCount.ToString();
			}
			try {
			using (MySqlConnection connection3 = new MySqlConnection(connectionString)) {
				MySqlCommand command2 = new MySqlCommand(rptQuery,connection3);
				command2.Parameters.AddWithValue("@current_time",current_time);
				connection3.Open();
				command2.ExecuteNonQuery();
			}
			} catch (Exception ex) {
			MessageBox.Show($"Report insert error: {ex.Message}");
			}
		} catch (Exception ex) {
			MessageBox.Show($"Report Generation Error: {ex.Message}");
		}
	}

}
