
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MiniProjectApp;

public partial class UsersettingPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private DashboardPage DashboardForm;
	private MembermanagementPage MembermanagementForm;
	private BorrowPage BorrowForm;
	private ReturnPage ReturnForm;
	private ReportsPage ReportsForm;
	private BookmanagementPage BookmanagementForm;
	private SearchPage SearchForm;
	private string user_id;

    public UsersettingPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	usrStgLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


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


	private void usrStgSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void usrStgSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void usrStgSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void usrStgSnvRtn_Clicked (object sender, EventArgs e) {
		ReturnForm = NavigateTo(ReturnForm);
	}

	private void usrStgSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void usrStgSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}

	private void usrStgSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}



	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		user_id = LoginPage.DBuserid;
		usrStgMainUsrIdInp.Text = user_id;
		getUserRole();
		
		usrStgHeader.Width = (int)(screenWidth*1);
		usrStgHeader.Height = (int)(screenHeight*0.1488);
		usrStgHeader.Left = (int)(screenWidth*0);
		usrStgHeader.Top = (int)(screenHeight*0);

		usrStgMainTitle.Width = (int)(screenWidth*0.625);
		usrStgMainTitle.Height = (int)(screenHeight*0.0793);
		usrStgMainTitle.Left = (int)(usrStgHeader.Width*0.1302);
		usrStgMainTitle.Top = (int)(usrStgHeader.Height*0);
		int usrStgMainTitleFont = (int)(screenWidth*0.0166);
		usrStgMainTitle.Font = new Font("roboto",usrStgMainTitleFont, FontStyle.Bold);

		usrStgPgeTitle.Width = (int)(screenWidth*0.625);
		usrStgPgeTitle.Height = (int)(screenHeight*0.0595);
		usrStgPgeTitle.Left = (int)(usrStgHeader.Width*0.1302);
		usrStgPgeTitle.Top = (int)(usrStgHeader.Height*0.5666);
		int usrStgPgeTitleFont = (int)(screenWidth*0.0104);
		usrStgPgeTitle.Font = new Font("broadway",usrStgPgeTitleFont);

		usrStgLogo.Width = (int)(screenWidth*0.0781);
		usrStgLogo.Height = (int)(screenHeight*0.0892);
		usrStgLogo.Left = (int)(usrStgHeader.Width*0.0260);
		usrStgLogo.Top = (int)(usrStgHeader.Height*0.2);

		usrStgSideNav.Width = (int)(screenWidth*0.2604);
		usrStgSideNav.Height = (int)(screenHeight*0.744);
		usrStgSideNav.Left = (int)(screenWidth*0.0156);
		usrStgSideNav.Top = (int)(screenHeight*0.1984);

		usrStgSnvTitle.Width = (int)(screenWidth*0.2604);
		usrStgSnvTitle.Height = (int)(screenHeight*0.0892);
		usrStgSnvTitle.Left = (int)(usrStgSideNav.Width*0);
		usrStgSnvTitle.Top = (int)(usrStgSideNav.Height*0);
		int usrStgSnvTitleFont = (int)(screenWidth*0.0130);
		usrStgSnvTitle.Font = new Font("arial",usrStgSnvTitleFont,FontStyle.Bold);

		usrStgSnvBkMgt.Width = (int)(screenWidth*0.2083);
		usrStgSnvBkMgt.Height = (int)(screenHeight*0.0595);
		usrStgSnvBkMgt.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvBkMgt.Top = (int)(usrStgSideNav.Height*0.16);
		int usrStgSnvBkMgtFont = (int)(screenWidth*0.0088);
		usrStgSnvBkMgt.Font = new Font("Verdana",usrStgSnvBkMgtFont,FontStyle.Underline);

		usrStgSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		usrStgSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		usrStgSnvMbrMgt.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvMbrMgt.Top = (int)(usrStgSideNav.Height*0.2666);
		int usrStgSnvMbrMgtFont = (int)(screenWidth*0.0088);
		usrStgSnvMbrMgt.Font = new Font("Verdana",usrStgSnvMbrMgtFont,FontStyle.Underline);

		usrStgSnvBrw.Width = (int)(screenWidth*0.2083);
		usrStgSnvBrw.Height = (int)(screenHeight*0.0595);
		usrStgSnvBrw.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvBrw.Top = (int)(usrStgSideNav.Height*0.3733);
		int usrStgSnvBrwFont = (int)(screenWidth*0.0088);
		usrStgSnvBrw.Font = new Font("Verdana",usrStgSnvBrwFont,FontStyle.Underline);

		usrStgSnvRtn.Width = (int)(screenWidth*0.2083);
		usrStgSnvRtn.Height = (int)(screenHeight*0.0595);
		usrStgSnvRtn.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvRtn.Top = (int)(usrStgSideNav.Height*0.48);
		int usrStgSnvRtnFont = (int)(screenWidth*0.0088);
		usrStgSnvRtn.Font = new Font("Verdana",usrStgSnvRtnFont,FontStyle.Underline);

		usrStgSnvRpt.Width = (int)(screenWidth*0.2083);
		usrStgSnvRpt.Height = (int)(screenHeight*0.0595);
		usrStgSnvRpt.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvRpt.Top = (int)(usrStgSideNav.Height*0.5866);
		int usrStgSnvRptFont = (int)(screenWidth*0.0088);
		usrStgSnvRpt.Font = new Font("Verdana",usrStgSnvRptFont,FontStyle.Underline);

		usrStgSnvDshBrd.Width = (int)(screenWidth*0.2083);
		usrStgSnvDshBrd.Height = (int)(screenHeight*0.0595);
		usrStgSnvDshBrd.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvDshBrd.Top = (int)(usrStgSideNav.Height*0.6933);
		int usrStgSnvDshBrdFont = (int)(screenWidth*0.0088);
		usrStgSnvDshBrd.Font = new Font("Verdana",usrStgSnvDshBrdFont,FontStyle.Underline);

		usrStgSnvSrch.Width = (int)(screenWidth*0.2083);
		usrStgSnvSrch.Height = (int)(screenHeight*0.0595);
		usrStgSnvSrch.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvSrch.Top = (int)(usrStgSideNav.Height*0.8);
		int usrStgSnvSrchFont = (int)(screenWidth*0.0088);
		usrStgSnvSrch.Font = new Font("Verdana",usrStgSnvSrchFont,FontStyle.Underline);

		usrStgMainCont.Width = (int)(screenWidth*0.6666);
		usrStgMainCont.Height = (int)(screenHeight*0.7936);
		usrStgMainCont.Left = (int)(screenWidth*0.3281);
		usrStgMainCont.Top = (int)(screenHeight*0.1587);

		usrStgMainContTitle.Width = (int)(screenWidth*0.26041667);
		usrStgMainContTitle.Height = (int)(screenHeight*0.05952381);
		usrStgMainContTitle.Left = (int)(usrStgMainCont.Width*0.3515625);
		usrStgMainContTitle.Top = (int)(usrStgMainCont.Height*0.0375);
		int usrStgMainContTitleFont = (int)(screenWidth*0.009375);
		usrStgMainContTitle.Font = new Font("Verdana",usrStgMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		usrStgMainUsrIdLbl.Width = (int)(screenWidth*0.13020833);
		usrStgMainUsrIdLbl.Height = (int)(screenHeight*0.04960317);
		usrStgMainUsrIdLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrIdLbl.Top = (int)(usrStgMainCont.Height*0.25);
		int usrStgMainUsrIdLblFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrIdLbl.Font = new Font("times new roman",usrStgMainUsrIdLblFont,FontStyle.Bold);

		usrStgMainUsrIdInp.Width = (int)(screenWidth*0.234375);
		usrStgMainUsrIdInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrIdInp.Top = (int)(usrStgMainCont.Height*0.25);
		int usrStgMainUsrIdInpFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrIdInp.Font = new Font("",usrStgMainUsrIdInpFont);

		usrStgMainUsrRoleLbl.Width = (int)(screenWidth*0.13020833);
		usrStgMainUsrRoleLbl.Height = (int)(screenHeight*0.04960317);
		usrStgMainUsrRoleLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrRoleLbl.Top = (int)(usrStgMainCont.Height*0.375);
		int usrStgMainUsrRoleLblFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrRoleLbl.Font = new Font("times new roman",usrStgMainUsrRoleLblFont,FontStyle.Bold);

		usrStgMainUsrRoleInp.Width = (int)(screenWidth*0.234375);
		usrStgMainUsrRoleInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrRoleInp.Top = (int)(usrStgMainCont.Height*0.375);
		int usrStgMainUsrRoleInpFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrRoleInp.Font = new Font("",usrStgMainUsrRoleInpFont);

		usrStgMainUsrNameLbl.Width = (int)(screenWidth*0.13020833);
		usrStgMainUsrNameLbl.Height = (int)(screenHeight*0.04960317);
		usrStgMainUsrNameLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrNameLbl.Top = (int)(usrStgMainCont.Height*0.5);
		int usrStgMainUsrNameLblFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrNameLbl.Font = new Font("times new roman",usrStgMainUsrNameLblFont,FontStyle.Bold);

		usrStgMainUsrNameInp.Width = (int)(screenWidth*0.234375);
		usrStgMainUsrNameInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrNameInp.Top = (int)(usrStgMainCont.Height*0.5);
		int usrStgMainUsrNameInpFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrNameInp.Font = new Font("",usrStgMainUsrNameInpFont);

		usrStgMainUsrPasswordLbl.Width = (int)(screenWidth*0.13020833);
		usrStgMainUsrPasswordLbl.Height = (int)(screenHeight*0.04960317);
		usrStgMainUsrPasswordLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrPasswordLbl.Top = (int)(usrStgMainCont.Height*0.625);
		int usrStgMainUsrPasswordLblFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrPasswordLbl.Font = new Font("times new roman",usrStgMainUsrPasswordLblFont,FontStyle.Bold);

		usrStgMainUsrPasswordInp.Width = (int)(screenWidth*0.234375);
		usrStgMainUsrPasswordInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrPasswordInp.Top = (int)(usrStgMainCont.Height*0.625);
		int usrStgMainUsrPasswordInpFont = (int)(screenWidth*0.00885417);
		usrStgMainUsrPasswordInp.Font = new Font("",usrStgMainUsrPasswordInpFont);

		saveChangesBtn.Width = (int)(screenWidth*0.20833333);
		saveChangesBtn.Height = (int)(screenHeight*0.09920635);
		saveChangesBtn.Left = (int)(usrStgMainCont.Width*0.390625);
		saveChangesBtn.Top = (int)(usrStgMainCont.Height*0.75);
		int saveChangesBtnFont = (int)(screenWidth*0.01041667);
		saveChangesBtn.Font = new Font("arial",saveChangesBtnFont,FontStyle.Bold);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		usrStgHeader.Width = (int)(formWidth*1);
		usrStgHeader.Height = (int)(formHeight*0.1488);
		usrStgHeader.Left = (int)(formWidth*0);
		usrStgHeader.Top = (int)(formHeight*0);

		usrStgMainTitle.Width = (int)(formWidth*0.625);
		usrStgMainTitle.Height = (int)(formHeight*0.0793);
		usrStgMainTitle.Left = (int)(usrStgHeader.Width*0.1302);
		usrStgMainTitle.Top = (int)(usrStgHeader.Height*0);
		int usrStgMainTitleFont = (int)(formWidth*0.0166);
		usrStgMainTitle.Font = new Font("roboto",usrStgMainTitleFont, FontStyle.Bold);

		usrStgPgeTitle.Width = (int)(formWidth*0.625);
		usrStgPgeTitle.Height = (int)(formHeight*0.0595);
		usrStgPgeTitle.Left = (int)(usrStgHeader.Width*0.1302);
		usrStgPgeTitle.Top = (int)(usrStgHeader.Height*0.5666);
		int usrStgPgeTitleFont = (int)(formWidth*0.0104);
		usrStgPgeTitle.Font = new Font("broadway",usrStgPgeTitleFont);

		usrStgLogo.Width = (int)(formWidth*0.0781);
		usrStgLogo.Height = (int)(formHeight*0.0892);
		usrStgLogo.Left = (int)(usrStgHeader.Width*0.0260);
		usrStgLogo.Top = (int)(usrStgHeader.Height*0.2);

		usrStgSideNav.Width = (int)(formWidth*0.2604);
		usrStgSideNav.Height = (int)(formHeight*0.744);
		usrStgSideNav.Left = (int)(formWidth*0.0156);
		usrStgSideNav.Top = (int)(formHeight*0.1984);

		usrStgSnvTitle.Width = (int)(formWidth*0.2604);
		usrStgSnvTitle.Height = (int)(formHeight*0.0892);
		usrStgSnvTitle.Left = (int)(usrStgSideNav.Width*0);
		usrStgSnvTitle.Top = (int)(usrStgSideNav.Height*0);
		int usrStgSnvTitleFont = (int)(formWidth*0.0130);
		usrStgSnvTitle.Font = new Font("arial",usrStgSnvTitleFont,FontStyle.Bold);

		usrStgSnvBkMgt.Width = (int)(formWidth*0.2083);
		usrStgSnvBkMgt.Height = (int)(formHeight*0.0595);
		usrStgSnvBkMgt.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvBkMgt.Top = (int)(usrStgSideNav.Height*0.16);
		int usrStgSnvBkMgtFont = (int)(formWidth*0.0088);
		usrStgSnvBkMgt.Font = new Font("Verdana",usrStgSnvBkMgtFont,FontStyle.Underline);

		usrStgSnvMbrMgt.Width = (int)(formWidth*0.2083);
		usrStgSnvMbrMgt.Height = (int)(formHeight*0.0595);
		usrStgSnvMbrMgt.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvMbrMgt.Top = (int)(usrStgSideNav.Height*0.2666);
		int usrStgSnvMbrMgtFont = (int)(formWidth*0.0088);
		usrStgSnvMbrMgt.Font = new Font("Verdana",usrStgSnvMbrMgtFont,FontStyle.Underline);

		usrStgSnvBrw.Width = (int)(formWidth*0.2083);
		usrStgSnvBrw.Height = (int)(formHeight*0.0595);
		usrStgSnvBrw.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvBrw.Top = (int)(usrStgSideNav.Height*0.3733);
		int usrStgSnvBrwFont = (int)(formWidth*0.0088);
		usrStgSnvBrw.Font = new Font("Verdana",usrStgSnvBrwFont,FontStyle.Underline);

		usrStgSnvRtn.Width = (int)(formWidth*0.2083);
		usrStgSnvRtn.Height = (int)(formHeight*0.0595);
		usrStgSnvRtn.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvRtn.Top = (int)(usrStgSideNav.Height*0.48);
		int usrStgSnvRtnFont = (int)(formWidth*0.0088);
		usrStgSnvRtn.Font = new Font("Verdana",usrStgSnvRtnFont,FontStyle.Underline);

		usrStgSnvRpt.Width = (int)(formWidth*0.2083);
		usrStgSnvRpt.Height = (int)(formHeight*0.0595);
		usrStgSnvRpt.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvRpt.Top = (int)(usrStgSideNav.Height*0.5866);
		int usrStgSnvRptFont = (int)(formWidth*0.0088);
		usrStgSnvRpt.Font = new Font("Verdana",usrStgSnvRptFont,FontStyle.Underline);

		usrStgSnvDshBrd.Width = (int)(formWidth*0.2083);
		usrStgSnvDshBrd.Height = (int)(formHeight*0.0595);
		usrStgSnvDshBrd.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvDshBrd.Top = (int)(usrStgSideNav.Height*0.6933);
		int usrStgSnvDshBrdFont = (int)(formWidth*0.0088);
		usrStgSnvDshBrd.Font = new Font("Verdana",usrStgSnvDshBrdFont,FontStyle.Underline);

		usrStgSnvSrch.Width = (int)(formWidth*0.2083);
		usrStgSnvSrch.Height = (int)(formHeight*0.0595);
		usrStgSnvSrch.Left = (int)(usrStgSideNav.Width*0.1);
		usrStgSnvSrch.Top = (int)(usrStgSideNav.Height*0.8);
		int usrStgSnvSrchFont = (int)(formWidth*0.0088);
		usrStgSnvSrch.Font = new Font("Verdana",usrStgSnvSrchFont,FontStyle.Underline);

		usrStgMainCont.Width = (int)(formWidth*0.6666);
		usrStgMainCont.Height = (int)(formHeight*0.7936);
		usrStgMainCont.Left = (int)(formWidth*0.3281);
		usrStgMainCont.Top = (int)(formHeight*0.1587);

		usrStgMainContTitle.Width = (int)(formWidth*0.26041667);
		usrStgMainContTitle.Height = (int)(formHeight*0.05952381);
		usrStgMainContTitle.Left = (int)(usrStgMainCont.Width*0.3515625);
		usrStgMainContTitle.Top = (int)(usrStgMainCont.Height*0.0375);
		int usrStgMainContTitleFont = (int)(formWidth*0.009375);
		usrStgMainContTitle.Font = new Font("Verdana",usrStgMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		usrStgMainUsrIdLbl.Width = (int)(formWidth*0.13020833);
		usrStgMainUsrIdLbl.Height = (int)(formHeight*0.04960317);
		usrStgMainUsrIdLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrIdLbl.Top = (int)(usrStgMainCont.Height*0.25);
		int usrStgMainUsrIdLblFont = (int)(formWidth*0.00885417);
		usrStgMainUsrIdLbl.Font = new Font("times new roman",usrStgMainUsrIdLblFont,FontStyle.Bold);

		usrStgMainUsrIdInp.Width = (int)(formWidth*0.234375);
		usrStgMainUsrIdInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrIdInp.Top = (int)(usrStgMainCont.Height*0.25);
		int usrStgMainUsrIdInpFont = (int)(formWidth*0.00885417);
		usrStgMainUsrIdInp.Font = new Font("",usrStgMainUsrIdInpFont);

		usrStgMainUsrRoleLbl.Width = (int)(formWidth*0.13020833);
		usrStgMainUsrRoleLbl.Height = (int)(formHeight*0.04960317);
		usrStgMainUsrRoleLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrRoleLbl.Top = (int)(usrStgMainCont.Height*0.375);
		int usrStgMainUsrRoleLblFont = (int)(Width*0.00885417);
		usrStgMainUsrRoleLbl.Font = new Font("times new roman",usrStgMainUsrRoleLblFont,FontStyle.Bold);

		usrStgMainUsrRoleInp.Width = (int)(formWidth*0.234375);
		usrStgMainUsrRoleInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrRoleInp.Top = (int)(usrStgMainCont.Height*0.375);
		int usrStgMainUsrRoleInpFont = (int)(formWidth*0.00885417);
		usrStgMainUsrRoleInp.Font = new Font("",usrStgMainUsrRoleInpFont);

		usrStgMainUsrNameLbl.Width = (int)(formWidth*0.13020833);
		usrStgMainUsrNameLbl.Height = (int)(formHeight*0.04960317);
		usrStgMainUsrNameLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrNameLbl.Top = (int)(usrStgMainCont.Height*0.5);
		int usrStgMainUsrNameLblFont = (int)(formWidth*0.00885417);
		usrStgMainUsrNameLbl.Font = new Font("times new roman",usrStgMainUsrNameLblFont,FontStyle.Bold);

		usrStgMainUsrNameInp.Width = (int)(formWidth*0.234375);
		usrStgMainUsrNameInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrNameInp.Top = (int)(usrStgMainCont.Height*0.5);
		int usrStgMainUsrNameInpFont = (int)(formWidth*0.00885417);
		usrStgMainUsrNameInp.Font = new Font("",usrStgMainUsrNameInpFont);

		usrStgMainUsrPasswordLbl.Width = (int)(formWidth*0.13020833);
		usrStgMainUsrPasswordLbl.Height = (int)(formHeight*0.04960317);
		usrStgMainUsrPasswordLbl.Left = (int)(usrStgMainCont.Width*0.1953125);
		usrStgMainUsrPasswordLbl.Top = (int)(usrStgMainCont.Height*0.625);
		int usrStgMainUsrPasswordLblFont = (int)(formWidth*0.00885417);
		usrStgMainUsrPasswordLbl.Font = new Font("times new roman",usrStgMainUsrPasswordLblFont,FontStyle.Bold);

		usrStgMainUsrPasswordInp.Width = (int)(formWidth*0.234375);
		usrStgMainUsrPasswordInp.Left = (int)(usrStgMainCont.Width*0.5078125);
		usrStgMainUsrPasswordInp.Top = (int)(usrStgMainCont.Height*0.625);
		int usrStgMainUsrPasswordInpFont = (int)(formWidth*0.00885417);
		usrStgMainUsrPasswordInp.Font = new Font("",usrStgMainUsrPasswordInpFont);

		saveChangesBtn.Width = (int)(formWidth*0.20833333);
		saveChangesBtn.Height = (int)(formHeight*0.09920635);
		saveChangesBtn.Left = (int)(usrStgMainCont.Width*0.390625);
		saveChangesBtn.Top = (int)(usrStgMainCont.Height*0.75);
		int saveChangesBtnFont = (int)(formWidth*0.01041667);
		saveChangesBtn.Font = new Font("arial",saveChangesBtnFont,FontStyle.Bold);

	}

	private void usrStgSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		usrStgSnvBkMgt.ForeColor = Color.Green;
	}
	private void usrStgSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		usrStgSnvBkMgt.ForeColor = Color.Blue;
	}

	private void usrStgSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		usrStgSnvMbrMgt.ForeColor = Color.Green;
	}
	private void usrStgSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		usrStgSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void usrStgSnvBrw_MouseEnter (object sender, EventArgs e) {
		usrStgSnvBrw.ForeColor = Color.Green;
	}
	private void usrStgSnvBrw_MouseLeave (object sender, EventArgs e) {
		usrStgSnvBrw.ForeColor = Color.Blue;
	}

	private void usrStgSnvRtn_MouseEnter (object sender, EventArgs e) {
		usrStgSnvRtn.ForeColor = Color.Green;
	}
	private void usrStgSnvRtn_MouseLeave (object sender, EventArgs e) {
		usrStgSnvRtn.ForeColor = Color.Blue;
	}

	private void usrStgSnvRpt_MouseEnter (object sender, EventArgs e) {
		usrStgSnvRpt.ForeColor = Color.Green;
	}
	private void usrStgSnvRpt_MouseLeave (object sender, EventArgs e) {
		usrStgSnvRpt.ForeColor = Color.Blue;
	}

	private void usrStgSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		usrStgSnvDshBrd.ForeColor = Color.Green;
	}
	private void usrStgSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		usrStgSnvDshBrd.ForeColor = Color.Blue;
	}

	private void usrStgSnvSrch_MouseEnter (object sender, EventArgs e) {
		usrStgSnvSrch.ForeColor = Color.Green;
	}
	private void usrStgSnvSrch_MouseLeave (object sender, EventArgs e) {
		usrStgSnvSrch.ForeColor = Color.Blue;
	}

	private void getUserRole () {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "SELECT role FROM users WHERE user_id=@user_id";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@user_id",user_id);
				connection.Open();
				using (MySqlDataReader reader = command.ExecuteReader()) {
					if (reader.Read()) {
						usrStgMainUsrRoleInp.Text = reader["role"].ToString();
					} else {
						MessageBox.Show("Can Not Read User Role!");
					}
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Get User Role Error: {ex.Message}");
		}
	}

	private void saveChangesBtn_Clicked (object sender, EventArgs e) {
		try {
			string username = usrStgMainUsrNameInp.Text;
			string password_hash = usrStgMainUsrPasswordInp.Text;
			if (string.IsNullOrEmpty(username)) {
				MessageBox.Show("Username Field Must Not Be Empty!");
				return;
			} else if (string.IsNullOrEmpty(password_hash)) {
				MessageBox.Show("Password Field Must Not Be Empty!");
				return;
			}
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "UPDATE users SET username=@username, password_hash=@password_hash WHERE user_id=@user_id";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@username",username);
				command.Parameters.AddWithValue("@password_hash",password_hash);
				command.Parameters.AddWithValue("@user_id",user_id);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
					MessageBox.Show("Change Saved Successfully!");
				} else {
					MessageBox.Show("Change Not Saved!");
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Save Setting Error: {ex.Message}");
		}
	}

}
