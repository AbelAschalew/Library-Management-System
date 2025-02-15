namespace MiniProjectApp;

public partial class LoginPage : Form
{

	public static String DBusername;
	public static String DBuserrole;
	public static string DBuserid;
	
	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

	private HomePage HomeForm;
	private DashboardPage DashboardForm;

    public LoginPage(HomePage homePage)
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	HomeForm = homePage;
	DashboardForm = new DashboardPage();

	this.Icon = EmbeddedFormIconLoader.LoadFormIcon("MiniProjectApp.Resources.cruiseFavicon.ico");
	this.BackgroundImage = EmbeddedBackgroundImageLoader.backgroundImageLoader("MiniProjectApp.Resources.formbackgroundImage.jpg");


	this.FormClosed += (sender,e) => Application.Exit();

	this.Resize += AdjustSizePosition;


    }

	private void backtoHome_Clicked (object sender, EventArgs e) {
		this.Hide();
		HomeForm.Show();
	}

	
	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		lgnHeader.Width = (int)(screenWidth*1);
		lgnHeader.Height = (int)(screenHeight*0.1488);
		lgnHeader.Left = (int)(screenWidth*0);
		lgnHeader.Top = (int)(screenHeight*0);

		lgnMainTitle.Width = (int)(screenWidth*0.8333);
		lgnMainTitle.Height = (int)(screenHeight*0.0892);
		lgnMainTitle.Left = (int)(lgnHeader.Width*0.1302);
		lgnMainTitle.Top = (int)(lgnHeader.Height*0.2);
		int lgnMainTitleFont = (int)(screenWidth*0.0166);
		lgnMainTitle.Font = new Font("roboto",lgnMainTitleFont, FontStyle.Bold);

		lgnFormCont.Width = (int)(screenWidth*0.5208);
		lgnFormCont.Height = (int)(screenHeight*0.6944);
		lgnFormCont.Left = (int)(screenWidth*0.2473);
		lgnFormCont.Top = (int)(screenHeight*0.1984);

		lgnFormTitle.Left = (int)(lgnFormCont.Width*0.1200);
		lgnFormTitle.Top = (int)(lgnFormCont.Height*0.0714);
		int lgnFormTitleFont = (int)(screenWidth*0.0114);
		lgnFormTitle.Font = new Font("arial",lgnFormTitleFont, FontStyle.Bold);

		lgnUsrnmLbl.Width = (int)(screenWidth*0.1041);
		lgnUsrnmLbl.Height = (int)(screenHeight*0.0992);
		lgnUsrnmLbl.Left = (int)(lgnFormCont.Width*0.145);
		lgnUsrnmLbl.Top = (int)(lgnFormCont.Height*0.2857);
		int lgnUsrnmLblFont = (int)(screenWidth*0.0104);
		lgnUsrnmLbl.Font = new Font("times new roman",lgnUsrnmLblFont, FontStyle.Bold);

		lgnUsrnmInp.Width = (int)(screenWidth*0.2083);
		lgnUsrnmInp.Height = (int)(screenHeight*0.0793);
		lgnUsrnmInp.Left = (int)(lgnFormCont.Width*0.4500);
		lgnUsrnmInp.Top = (int)(lgnFormCont.Height*0.3214);
		int lgnUsrnmInpFont = (int)(screenWidth*0.0088);
		lgnUsrnmInp.Font = new Font("arial",lgnUsrnmInpFont);

		lgnPswLbl.Width = (int)(screenWidth*0.1041);
		lgnPswLbl.Height = (int)(screenHeight*0.0992);
		lgnPswLbl.Left = (int)(lgnFormCont.Width*0.145);
		lgnPswLbl.Top = (int)(lgnFormCont.Height*0.5);
		int lgnPswLblFont = (int)(screenWidth*0.0104);
		lgnPswLbl.Font = new Font("times new roman",lgnPswLblFont, FontStyle.Bold);

		lgnPswInp.Width = (int)(screenWidth*0.2083);
		lgnPswInp.Height = (int)(screenHeight*0.0793);
		lgnPswInp.Left = (int)(lgnFormCont.Width*0.4500);
		lgnPswInp.Top = (int)(lgnFormCont.Height*0.5357);
		int lgnPswInpFont = (int)(screenWidth*0.0088);
		lgnPswInp.Font = new Font("arial",lgnPswInpFont);

		lgnBtn.Width = (int)(screenWidth*0.2083);
		lgnBtn.Height = (int)(screenHeight*0.0992);
		lgnBtn.Left = (int)(lgnFormCont.Width*0.3);
		lgnBtn.Top = (int)(lgnFormCont.Height*0.7428);
		int lgnBtnFont = (int)(screenWidth*0.0088);
		lgnBtn.Font = new Font("arial",lgnBtnFont,FontStyle.Bold);

		backtoHome.Width = (int)(screenWidth*0.1041);
		backtoHome.Height = (int)(screenHeight*0.0793);
		backtoHome.Left = (int)(screenWidth*0.0260);
		backtoHome.Top = (int)(screenHeight*0.1984);
		int backtoHomeFont = (int)(screenWidth*0.0067);
		backtoHome.Font = new Font("roboto",backtoHomeFont, FontStyle.Bold);

		
	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		lgnHeader.Width = (int)(formWidth*1);
		lgnHeader.Height = (int)(formHeight*0.1488);
		lgnHeader.Left = (int)(formWidth*0);
		lgnHeader.Top = (int)(formHeight*0);

		lgnMainTitle.Width = (int)(formWidth*0.8333);
		lgnMainTitle.Height = (int)(formHeight*0.0892);
		lgnMainTitle.Left = (int)(lgnHeader.Width*0.1302);
		lgnMainTitle.Top = (int)(lgnHeader.Height*0.2);
		int lgnMainTitleFont = (int)(formWidth*0.0166);
		lgnMainTitle.Font = new Font("roboto",lgnMainTitleFont, FontStyle.Bold);

		lgnFormCont.Width = (int)(formWidth*0.5208);
		lgnFormCont.Height = (int)(formHeight*0.6944);
		lgnFormCont.Left = (int)(formWidth*0.2473);
		lgnFormCont.Top = (int)(formHeight*0.1984);

		lgnFormTitle.Width = (int)(formWidth*0.8333);
		lgnFormTitle.Left = (int)(lgnFormCont.Width*0.08);
		lgnFormTitle.Top = (int)(lgnFormCont.Height*0.0714);
		int lgnFormTitleFont = (int)(formWidth*0.0114);
		lgnFormTitle.Font = new Font("arial",lgnFormTitleFont, FontStyle.Bold);

		lgnUsrnmLbl.Width = (int)(formWidth*0.1041);
		lgnUsrnmLbl.Height = (int)(formHeight*0.0992);
		lgnUsrnmLbl.Left = (int)(lgnFormCont.Width*0.1302);
		lgnUsrnmLbl.Top = (int)(lgnFormCont.Height*0.2857);
		int lgnUsrnmLblFont = (int)(formWidth*0.0104);
		lgnUsrnmLbl.Font = new Font("times new roman",lgnUsrnmLblFont, FontStyle.Bold);

		lgnUsrnmInp.Width = (int)(formWidth*0.2083);
		lgnUsrnmInp.Height = (int)(formHeight*0.0793);
		lgnUsrnmInp.Left = (int)(lgnFormCont.Width*0.4500);
		lgnUsrnmInp.Top = (int)(lgnFormCont.Height*0.3214);
		int lgnUsrnmInpFont = (int)(formWidth*0.0088);
		lgnUsrnmInp.Font = new Font("arial",lgnUsrnmInpFont);

		lgnPswLbl.Width = (int)(formWidth*0.1041);
		lgnPswLbl.Height = (int)(formHeight*0.0992);
		lgnPswLbl.Left = (int)(lgnFormCont.Width*0.145);
		lgnPswLbl.Top = (int)(lgnFormCont.Height*0.5);
		int lgnPswLblFont = (int)(formWidth*0.0104);
		lgnPswLbl.Font = new Font("times new roman",lgnPswLblFont, FontStyle.Bold);

		lgnPswInp.Width = (int)(formWidth*0.2083);
		lgnPswInp.Height = (int)(formHeight*0.0793);
		lgnPswInp.Left = (int)(lgnFormCont.Width*0.4500);
		lgnPswInp.Top = (int)(lgnFormCont.Height*0.5357);
		int lgnPswInpFont = (int)(formWidth*0.0088);
		lgnPswInp.Font = new Font("arial",lgnPswInpFont);

		lgnBtn.Width = (int)(formWidth*0.2083);
		lgnBtn.Height = (int)(formHeight*0.0992);
		lgnBtn.Left = (int)(lgnFormCont.Width*0.3);
		lgnBtn.Top = (int)(lgnFormCont.Height*0.7428);
		int lgnBtnFont = (int)(formWidth*0.0088);
		lgnBtn.Font = new Font("arial",lgnBtnFont,FontStyle.Bold);

		backtoHome.Width = (int)(formWidth*0.1041);
		backtoHome.Height = (int)(formHeight*0.0793);
		backtoHome.Left = (int)(formWidth*0.0260);
		backtoHome.Top = (int)(formHeight*0.1984);
		int backtoHomeFont = (int)(formWidth*0.0067);
		backtoHome.Font = new Font("arial",backtoHomeFont, FontStyle.Bold);

	}

	private void lgnBtn_Clicked (object sender, EventArgs e) {
		login_Authentication(sender,e);
	}

	private void login_Authentication (object sender, EventArgs e) {
		string username = lgnUsrnmInp.Text.Trim();
		string password = lgnPswInp.Text.Trim();
		if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
			MessageBox.Show("Please enter both username & password!");
			return;
		}
		string loginQuery = "SELECT user_id, username, password_hash, role FROM users WHERE username=@username";
		DatabaseHelper db = new DatabaseHelper();
		try {
			(string dbuserid, string dbUsername, string dbPasswordHash, string dbuserrole) = db.GetUserCredentials(loginQuery,username);
			if (dbUsername == null) {
				MessageBox.Show("Username Incorrect!");
			} else if (password == dbPasswordHash) {
				DBusername = dbUsername;
				DBuserrole = dbuserrole;
				DBuserid = dbuserid;
				this.Hide();
				DashboardForm.Show();

			} else {
				MessageBox.Show("Incorrect Password!");
			}
		} catch (Exception ex) {
			MessageBox.Show($"9Error: {ex.Message}");
		}
	}

}
