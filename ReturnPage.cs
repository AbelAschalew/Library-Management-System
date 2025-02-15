
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MiniProjectApp;

public partial class ReturnPage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


	private DashboardPage DashboardForm;
	private MembermanagementPage MembermanagementForm;
	private BorrowPage BorrowForm;
	private BookmanagementPage BookmanagementForm;
	private ReportsPage ReportsForm;
	private UsersettingPage UsersettingForm;
	private SearchPage SearchForm;

	private string member_id;



    public ReturnPage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	rtnLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");


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


	private void rtnSnvBkMgt_Clicked (object sender, EventArgs e) {
		BookmanagementForm = NavigateTo(BookmanagementForm);
	}

	private void rtnSnvMbrMgt_Clicked (object sender, EventArgs e) {
		MembermanagementForm = NavigateTo(MembermanagementForm);
	}

	private void rtnSnvBrw_Clicked (object sender, EventArgs e) {
		BorrowForm = NavigateTo(BorrowForm);
	}

	private void rtnSnvDshBrd_Clicked (object sender, EventArgs e) {
		DashboardForm = NavigateTo(DashboardForm);
	}

	private void rtnSnvRpt_Clicked (object sender, EventArgs e) {
		ReportsForm = NavigateTo(ReportsForm);
	}

	private void rtnSnvUsrStg_Clicked (object sender, EventArgs e) {
		UsersettingForm = NavigateTo(UsersettingForm);
	}

	private void rtnSnvSrch_Clicked (object sender, EventArgs e) {
		SearchForm = NavigateTo(SearchForm);
	}


	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		rtnBookGridView.KeyDown += returnBook_KeyDown;
		
		rtnHeader.Width = (int)(screenWidth*1);
		rtnHeader.Height = (int)(screenHeight*0.1488);
		rtnHeader.Left = (int)(screenWidth*0);
		rtnHeader.Top = (int)(screenHeight*0);

		rtnMainTitle.Width = (int)(screenWidth*0.625);
		rtnMainTitle.Height = (int)(screenHeight*0.0793);
		rtnMainTitle.Left = (int)(rtnHeader.Width*0.1302);
		rtnMainTitle.Top = (int)(rtnHeader.Height*0);
		int rtnMainTitleFont = (int)(screenWidth*0.0166);
		rtnMainTitle.Font = new Font("roboto",rtnMainTitleFont, FontStyle.Bold);

		rtnPgeTitle.Width = (int)(screenWidth*0.625);
		rtnPgeTitle.Height = (int)(screenHeight*0.0595);
		rtnPgeTitle.Left = (int)(rtnHeader.Width*0.1302);
		rtnPgeTitle.Top = (int)(rtnHeader.Height*0.5666);
		int rtnPgeTitleFont = (int)(screenWidth*0.0104);
		rtnPgeTitle.Font = new Font("broadway",rtnPgeTitleFont);

		rtnLogo.Width = (int)(screenWidth*0.0781);
		rtnLogo.Height = (int)(screenHeight*0.0892);
		rtnLogo.Left = (int)(rtnHeader.Width*0.0260);
		rtnLogo.Top = (int)(rtnHeader.Height*0.2);

		rtnSideNav.Width = (int)(screenWidth*0.2604);
		rtnSideNav.Height = (int)(screenHeight*0.744);
		rtnSideNav.Left = (int)(screenWidth*0.0156);
		rtnSideNav.Top = (int)(screenHeight*0.1984);

		rtnSnvTitle.Width = (int)(screenWidth*0.2604);
		rtnSnvTitle.Height = (int)(screenHeight*0.0892);
		rtnSnvTitle.Left = (int)(rtnSideNav.Width*0);
		rtnSnvTitle.Top = (int)(rtnSideNav.Height*0);
		int rtnSnvTitleFont = (int)(screenWidth*0.0130);
		rtnSnvTitle.Font = new Font("arial",rtnSnvTitleFont,FontStyle.Bold);

		rtnSnvBkMgt.Width = (int)(screenWidth*0.2083);
		rtnSnvBkMgt.Height = (int)(screenHeight*0.0595);
		rtnSnvBkMgt.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvBkMgt.Top = (int)(rtnSideNav.Height*0.16);
		int rtnSnvBkMgtFont = (int)(screenWidth*0.0088);
		rtnSnvBkMgt.Font = new Font("Verdana",rtnSnvBkMgtFont,FontStyle.Underline);

		rtnSnvMbrMgt.Width = (int)(screenWidth*0.2083);
		rtnSnvMbrMgt.Height = (int)(screenHeight*0.0595);
		rtnSnvMbrMgt.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvMbrMgt.Top = (int)(rtnSideNav.Height*0.2666);
		int rtnSnvMbrMgtFont = (int)(screenWidth*0.0088);
		rtnSnvMbrMgt.Font = new Font("Verdana",rtnSnvMbrMgtFont,FontStyle.Underline);

		rtnSnvBrw.Width = (int)(screenWidth*0.2083);
		rtnSnvBrw.Height = (int)(screenHeight*0.0595);
		rtnSnvBrw.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvBrw.Top = (int)(rtnSideNav.Height*0.3733);
		int rtnSnvBrwFont = (int)(screenWidth*0.0088);
		rtnSnvBrw.Font = new Font("Verdana",rtnSnvBrwFont,FontStyle.Underline);

		rtnSnvDshBrd.Width = (int)(screenWidth*0.2083);
		rtnSnvDshBrd.Height = (int)(screenHeight*0.0595);
		rtnSnvDshBrd.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvDshBrd.Top = (int)(rtnSideNav.Height*0.48);
		int rtnSnvDshBrdFont = (int)(screenWidth*0.0088);
		rtnSnvDshBrd.Font = new Font("Verdana",rtnSnvDshBrdFont,FontStyle.Underline);

		rtnSnvRpt.Width = (int)(screenWidth*0.2083);
		rtnSnvRpt.Height = (int)(screenHeight*0.0595);
		rtnSnvRpt.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvRpt.Top = (int)(rtnSideNav.Height*0.5866);
		int rtnSnvRptFont = (int)(screenWidth*0.0088);
		rtnSnvRpt.Font = new Font("Verdana",rtnSnvRptFont,FontStyle.Underline);

		rtnSnvUsrStg.Width = (int)(screenWidth*0.2083);
		rtnSnvUsrStg.Height = (int)(screenHeight*0.0595);
		rtnSnvUsrStg.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvUsrStg.Top = (int)(rtnSideNav.Height*0.6933);
		int rtnSnvUsrStgFont = (int)(screenWidth*0.0088);
		rtnSnvUsrStg.Font = new Font("Verdana",rtnSnvUsrStgFont,FontStyle.Underline);

		rtnSnvSrch.Width = (int)(screenWidth*0.2083);
		rtnSnvSrch.Height = (int)(screenHeight*0.0595);
		rtnSnvSrch.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvSrch.Top = (int)(rtnSideNav.Height*0.8);
		int rtnSnvSrchFont = (int)(screenWidth*0.0088);
		rtnSnvSrch.Font = new Font("Verdana",rtnSnvSrchFont,FontStyle.Underline);

		rtnMainCont.Width = (int)(screenWidth*0.6666);
		rtnMainCont.Height = (int)(screenHeight*0.7936);
		rtnMainCont.Left = (int)(screenWidth*0.3281);
		rtnMainCont.Top = (int)(screenHeight*0.1587);

		rtnMainContTitle.Width = (int)(screenWidth*0.18229167);
		rtnMainContTitle.Height = (int)(screenHeight*0.05952381);
		rtnMainContTitle.Left = (int)(rtnMainCont.Width*0.390625);
		rtnMainContTitle.Top = (int)(rtnMainCont.Height*0.0375);
		int rtnMainContTitleFont = (int)(screenWidth*0.009375);
		rtnMainContTitle.Font = new Font("Verdana",rtnMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		rtnBkMbrNmLbl.Width = (int)(screenWidth*0.15625);
		rtnBkMbrNmLbl.Height = (int)(screenHeight*0.04960317);
		rtnBkMbrNmLbl.Left = (int)(rtnMainCont.Width*0.15625);
		rtnBkMbrNmLbl.Top = (int)(rtnMainCont.Height*0.1875);
		int rtnBkMbrNmLblFont = (int)(screenWidth*0.00885417);
		rtnBkMbrNmLbl.Font = new Font("times new roman",rtnBkMbrNmLblFont,FontStyle.Bold);

		rtnBkMbrNmInp.Width = (int)(screenWidth*0.20833333);
		rtnBkMbrNmInp.Left = (int)(rtnMainCont.Width*0.390625);
		rtnBkMbrNmInp.Top = (int)(rtnMainCont.Height*0.1875);
		int rtnBkMbrNmInpFont = (int)(screenWidth*0.00885417);
		rtnBkMbrNmInp.Font = new Font("",rtnBkMbrNmInpFont);

		rtnBkListBtn.Width = (int)(screenWidth*0.10416667);
		rtnBkListBtn.Height = (int)(screenHeight*0.07936508);
		rtnBkListBtn.Left = (int)(rtnMainCont.Width*0.78125);
		rtnBkListBtn.Top = (int)(rtnMainCont.Height*0.16875);
		int rtnBkListBtnFont = (int)(screenWidth*0.00885417);
		rtnBkListBtn.Font = new Font("arial",rtnBkListBtnFont,FontStyle.Bold);

		mbrBorrowedBksListTitle.Width = (int)(screenWidth*0.390625);
		mbrBorrowedBksListTitle.Height = (int)(screenHeight*0.03968254);
		mbrBorrowedBksListTitle.Left = (int)(rtnMainCont.Width*0.3125);
		mbrBorrowedBksListTitle.Top = (int)(rtnMainCont.Height*0.375);
		int mbrBorrowedBksListTitleFont = (int)(screenWidth*0.00885417);
		mbrBorrowedBksListTitle.Font = new Font("arial",mbrBorrowedBksListTitleFont,FontStyle.Bold|FontStyle.Underline);

		mbrBorrowListMsg.Width = (int)(screenWidth*0.26041667);
		mbrBorrowListMsg.Height = (int)(screenHeight*0.0297619);
		mbrBorrowListMsg.Left = (int)(rtnMainCont.Width*0.07815);
		mbrBorrowListMsg.Top = (int)(rtnMainCont.Height*0.425);
		int mbrBorrowListMsgFont = (int)(screenWidth*0.00625);
		mbrBorrowListMsg.Font = new Font("arial",mbrBorrowListMsgFont,FontStyle.Bold);

		rtnBookGridView.Width = (int)(screenWidth*0.52083333);
		rtnBookGridView.Height = (int)(screenHeight*0.14880952);
		rtnBookGridView.Left = (int)(rtnMainCont.Width*0.0390625);
		rtnBookGridView.Top = (int)(rtnMainCont.Height*0.4625);
		int rtnBookGridViewFont = (int)(screenWidth*0.00520833);
		rtnBookGridView.Font = new Font("arial",rtnBookGridViewFont);

	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		rtnHeader.Width = (int)(formWidth*1);
		rtnHeader.Height = (int)(formHeight*0.1488);
		rtnHeader.Left = (int)(formWidth*0);
		rtnHeader.Top = (int)(formHeight*0);

		rtnMainTitle.Width = (int)(formWidth*0.625);
		rtnMainTitle.Height = (int)(formHeight*0.0793);
		rtnMainTitle.Left = (int)(rtnHeader.Width*0.1302);
		rtnMainTitle.Top = (int)(rtnHeader.Height*0);
		int rtnMainTitleFont = (int)(formWidth*0.0166);
		rtnMainTitle.Font = new Font("roboto",rtnMainTitleFont, FontStyle.Bold);

		rtnPgeTitle.Width = (int)(formWidth*0.625);
		rtnPgeTitle.Height = (int)(formHeight*0.0595);
		rtnPgeTitle.Left = (int)(rtnHeader.Width*0.1302);
		rtnPgeTitle.Top = (int)(rtnHeader.Height*0.5666);
		int rtnPgeTitleFont = (int)(formWidth*0.0104);
		rtnPgeTitle.Font = new Font("broadway",rtnPgeTitleFont);

		rtnLogo.Width = (int)(formWidth*0.0781);
		rtnLogo.Height = (int)(formHeight*0.0892);
		rtnLogo.Left = (int)(rtnHeader.Width*0.0260);
		rtnLogo.Top = (int)(rtnHeader.Height*0.2);

		rtnSideNav.Width = (int)(formWidth*0.2604);
		rtnSideNav.Height = (int)(formHeight*0.744);
		rtnSideNav.Left = (int)(formWidth*0.0156);
		rtnSideNav.Top = (int)(formHeight*0.1984);

		rtnSnvTitle.Width = (int)(formWidth*0.2604);
		rtnSnvTitle.Height = (int)(formHeight*0.0892);
		rtnSnvTitle.Left = (int)(rtnSideNav.Width*0);
		rtnSnvTitle.Top = (int)(rtnSideNav.Height*0);
		int rtnSnvTitleFont = (int)(formWidth*0.0130);
		rtnSnvTitle.Font = new Font("arial",rtnSnvTitleFont,FontStyle.Bold);

		rtnSnvBkMgt.Width = (int)(formWidth*0.2083);
		rtnSnvBkMgt.Height = (int)(formHeight*0.0595);
		rtnSnvBkMgt.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvBkMgt.Top = (int)(rtnSideNav.Height*0.16);
		int rtnSnvBkMgtFont = (int)(formWidth*0.0088);
		rtnSnvBkMgt.Font = new Font("Verdana",rtnSnvBkMgtFont,FontStyle.Underline);

		rtnSnvMbrMgt.Width = (int)(formWidth*0.2083);
		rtnSnvMbrMgt.Height = (int)(formHeight*0.0595);
		rtnSnvMbrMgt.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvMbrMgt.Top = (int)(rtnSideNav.Height*0.2666);
		int rtnSnvMbrMgtFont = (int)(formWidth*0.0088);
		rtnSnvMbrMgt.Font = new Font("Verdana",rtnSnvMbrMgtFont,FontStyle.Underline);

		rtnSnvBrw.Width = (int)(formWidth*0.2083);
		rtnSnvBrw.Height = (int)(formHeight*0.0595);
		rtnSnvBrw.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvBrw.Top = (int)(rtnSideNav.Height*0.3733);
		int rtnSnvBrwFont = (int)(formWidth*0.0088);
		rtnSnvBrw.Font = new Font("Verdana",rtnSnvBrwFont,FontStyle.Underline);

		rtnSnvDshBrd.Width = (int)(formWidth*0.2083);
		rtnSnvDshBrd.Height = (int)(formHeight*0.0595);
		rtnSnvDshBrd.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvDshBrd.Top = (int)(rtnSideNav.Height*0.48);
		int rtnSnvDshBrdFont = (int)(formWidth*0.0088);
		rtnSnvDshBrd.Font = new Font("Verdana",rtnSnvDshBrdFont,FontStyle.Underline);

		rtnSnvRpt.Width = (int)(formWidth*0.2083);
		rtnSnvRpt.Height = (int)(formHeight*0.0595);
		rtnSnvRpt.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvRpt.Top = (int)(rtnSideNav.Height*0.5866);
		int rtnSnvRptFont = (int)(formWidth*0.0088);
		rtnSnvRpt.Font = new Font("Verdana",rtnSnvRptFont,FontStyle.Underline);

		rtnSnvUsrStg.Width = (int)(formWidth*0.2083);
		rtnSnvUsrStg.Height = (int)(formHeight*0.0595);
		rtnSnvUsrStg.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvUsrStg.Top = (int)(rtnSideNav.Height*0.6933);
		int rtnSnvUsrStgFont = (int)(formWidth*0.0088);
		rtnSnvUsrStg.Font = new Font("Verdana",rtnSnvUsrStgFont,FontStyle.Underline);

		rtnSnvSrch.Width = (int)(formWidth*0.2083);
		rtnSnvSrch.Height = (int)(formHeight*0.0595);
		rtnSnvSrch.Left = (int)(rtnSideNav.Width*0.1);
		rtnSnvSrch.Top = (int)(rtnSideNav.Height*0.8);
		int rtnSnvSrchFont = (int)(formWidth*0.0088);
		rtnSnvSrch.Font = new Font("Verdana",rtnSnvSrchFont,FontStyle.Underline);

		rtnMainCont.Width = (int)(formWidth*0.6666);
		rtnMainCont.Height = (int)(formHeight*0.7936);
		rtnMainCont.Left = (int)(formWidth*0.3281);
		rtnMainCont.Top = (int)(formHeight*0.1587);

		rtnMainContTitle.Width = (int)(formWidth*0.18229167);
		rtnMainContTitle.Height = (int)(formHeight*0.05952381);
		rtnMainContTitle.Left = (int)(rtnMainCont.Width*0.390625);
		rtnMainContTitle.Top = (int)(rtnMainCont.Height*0.0375);
		int rtnMainContTitleFont = (int)(formWidth*0.009375);
		rtnMainContTitle.Font = new Font("Verdana",rtnMainContTitleFont,FontStyle.Underline|FontStyle.Bold);

		rtnBkMbrNmLbl.Width = (int)(formWidth*0.15625);
		rtnBkMbrNmLbl.Height = (int)(formHeight*0.04960317);
		rtnBkMbrNmLbl.Left = (int)(rtnMainCont.Width*0.15625);
		rtnBkMbrNmLbl.Top = (int)(rtnMainCont.Height*0.1875);
		int rtnBkMbrNmLblFont = (int)(formWidth*0.00885417);
		rtnBkMbrNmLbl.Font = new Font("times new roman",rtnBkMbrNmLblFont,FontStyle.Bold);

		rtnBkMbrNmInp.Width = (int)(formWidth*0.20833333);
		rtnBkMbrNmInp.Left = (int)(rtnMainCont.Width*0.390625);
		rtnBkMbrNmInp.Top = (int)(rtnMainCont.Height*0.1875);
		int rtnBkMbrNmInpFont = (int)(formWidth*0.00885417);
		rtnBkMbrNmInp.Font = new Font("",rtnBkMbrNmInpFont);

		rtnBkListBtn.Width = (int)(formWidth*0.10416667);
		rtnBkListBtn.Height = (int)(formHeight*0.07936508);
		rtnBkListBtn.Left = (int)(rtnMainCont.Width*0.78125);
		rtnBkListBtn.Top = (int)(rtnMainCont.Height*0.16875);
		int rtnBkListBtnFont = (int)(formWidth*0.00885417);
		rtnBkListBtn.Font = new Font("arial",rtnBkListBtnFont,FontStyle.Bold);

		mbrBorrowedBksListTitle.Width = (int)(formWidth*0.390625);
		mbrBorrowedBksListTitle.Height = (int)(formHeight*0.03968254);
		mbrBorrowedBksListTitle.Left = (int)(rtnMainCont.Width*0.3125);
		mbrBorrowedBksListTitle.Top = (int)(rtnMainCont.Height*0.375);
		int mbrBorrowedBksListTitleFont = (int)(formWidth*0.00885417);
		mbrBorrowedBksListTitle.Font = new Font("arial",mbrBorrowedBksListTitleFont,FontStyle.Bold|FontStyle.Underline);

		mbrBorrowListMsg.Width = (int)(formWidth*0.26041667);
		mbrBorrowListMsg.Height = (int)(formHeight*0.0297619);
		mbrBorrowListMsg.Left = (int)(rtnMainCont.Width*0.07815);
		mbrBorrowListMsg.Top = (int)(rtnMainCont.Height*0.425);
		int mbrBorrowListMsgFont = (int)(formWidth*0.00625);
		mbrBorrowListMsg.Font = new Font("arial",mbrBorrowListMsgFont,FontStyle.Bold);

		rtnBookGridView.Width = (int)(formWidth*0.52083333);
		rtnBookGridView.Height = (int)(formHeight*0.14880952);
		rtnBookGridView.Left = (int)(rtnMainCont.Width*0.0390625);
		rtnBookGridView.Top = (int)(rtnMainCont.Height*0.4625);
		int rtnBookGridViewFont = (int)(formWidth*0.00520833);
		rtnBookGridView.Font = new Font("arial",rtnBookGridViewFont);

	}

	private void rtnSnvBkMgt_MouseEnter (object sender, EventArgs e) {
		rtnSnvBkMgt.ForeColor = Color.Green;
	}
	private void rtnSnvBkMgt_MouseLeave (object sender, EventArgs e) {
		rtnSnvBkMgt.ForeColor = Color.Blue;
	}

	private void rtnSnvMbrMgt_MouseEnter (object sender, EventArgs e) {
		rtnSnvMbrMgt.ForeColor = Color.Green;
	}
	private void rtnSnvMbrMgt_MouseLeave (object sender, EventArgs e) {
		rtnSnvMbrMgt.ForeColor = Color.Blue;
	}

	private void rtnSnvBrw_MouseEnter (object sender, EventArgs e) {
		rtnSnvBrw.ForeColor = Color.Green;
	}
	private void rtnSnvBrw_MouseLeave (object sender, EventArgs e) {
		rtnSnvBrw.ForeColor = Color.Blue;
	}

	private void rtnSnvDshBrd_MouseEnter (object sender, EventArgs e) {
		rtnSnvDshBrd.ForeColor = Color.Green;
	}
	private void rtnSnvDshBrd_MouseLeave (object sender, EventArgs e) {
		rtnSnvDshBrd.ForeColor = Color.Blue;
	}

	private void rtnSnvRpt_MouseEnter (object sender, EventArgs e) {
		rtnSnvRpt.ForeColor = Color.Green;
	}
	private void rtnSnvRpt_MouseLeave (object sender, EventArgs e) {
		rtnSnvRpt.ForeColor = Color.Blue;
	}

	private void rtnSnvUsrStg_MouseEnter (object sender, EventArgs e) {
		rtnSnvUsrStg.ForeColor = Color.Green;
	}
	private void rtnSnvUsrStg_MouseLeave (object sender, EventArgs e) {
		rtnSnvUsrStg.ForeColor = Color.Blue;
	}

	private void rtnSnvSrch_MouseEnter (object sender, EventArgs e) {
		rtnSnvSrch.ForeColor = Color.Green;
	}
	private void rtnSnvSrch_MouseLeave (object sender, EventArgs e) {
		rtnSnvSrch.ForeColor = Color.Blue;
	}

	private void rtnBkListBtn_Clicked (object sender, EventArgs e) {
		try {
			string memberName = rtnBkMbrNmInp.Text;
			if (string.IsNullOrEmpty(memberName)) {
				MessageBox.Show("Member Name Field Must Not Be Empty!");
				return;
			}
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990";
			string mbrnmQuery = "SELECT member_id FROM members WHERE name=@memberName";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(mbrnmQuery,connection);
				command.Parameters.AddWithValue("@memberName",memberName);
				connection.Open();
				object result = command.ExecuteScalar();
				if (result == null) {
					MessageBox.Show("Member Doesn't Exist");
				} else {
					member_id = result.ToString();
					memberBorrowList(memberName);
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Return Check Member Error: {ex.Message}");
		}
	}

	private void memberBorrowList (string memberName) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "SELECT M.name, T.member_id, T.book_id, T.status, B.title, T.transaction_id FROM members M JOIN transactions T ON M.member_id = T.member_id JOIN books B ON T.book_id = B.book_id WHERE M.member_id = @member_id AND T.status != 'completed'";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlDataAdapter adapter = new MySqlDataAdapter();
				adapter.SelectCommand = new MySqlCommand(query,connection);
				adapter.SelectCommand.Parameters.AddWithValue("@member_id",member_id);
				DataTable table = new DataTable();
				adapter.Fill(table);
				if (table.Rows.Count == 0) {
					MessageBox.Show("Member Don't Have Active Borrowed Books!");
				} else {
					rtnBookGridView.DataSource = table;
					mbrBorrowedBksListTitle.Text = memberName+"'s Borrow Records";
					mbrBorrowedBksListTitle.Show();
					mbrBorrowListMsg.Show();
					rtnBookGridView.Show();
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Borrow List Error: {ex.Message}");
		}
	}

	private void returnBook_KeyDown (object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.R && rtnBookGridView.SelectedRows.Count > 0) {
			DataGridViewRow selectedRow = rtnBookGridView.CurrentRow;
			string book_id = selectedRow.Cells[2].Value.ToString();
			string transaction_id = selectedRow.Cells[5].Value.ToString();
			updateBookStatus(book_id);
			updateTransactionStatus(transaction_id);
			rtnBookGridView.Rows.Remove(selectedRow);
		}
	}

	private void updateBookStatus (string book_id) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "UPDATE books SET status='available' WHERE book_id=@book_id";
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
			MessageBox.Show($"Update Book Status Error: {ex.Message}");
		}
	}

	private void updateTransactionStatus (string transaction_id) {
		try {
			string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";
			string query = "UPDATE transactions SET status='completed' WHERE transaction_id=@transaction_id";
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				MySqlCommand command = new MySqlCommand(query,connection);
				command.Parameters.AddWithValue("@transaction_id",transaction_id);
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0) {
					MessageBox.Show("Transaction Status Updated Successfully!");
				} else {
					MessageBox.Show("Transaction Status Not Updated!");
				}
			}
		} catch (Exception ex) {
			MessageBox.Show($"Update Transaction Status Error: {ex.Message}");
		}
	}

}
