
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProjectApp;

partial class DashboardPage
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


	private Panel dsbrdHeader;
	private Label dsbrdMainTitle;
	private PictureBox dsbrdLogo;
	private Button logoutBtn;
	private Panel dsbrdSideNav;
	private Label dsbrdSnvTitle;
	private Panel dsbrdMainCont;
	private Label dsbrdSnvBkMgt;
	private Label dsbrdSnvMbrMgt;
	private Label dsbrdSnvBrw;
	private Label dsbrdSnvRtn;
	private Label dsbrdSnvRpt;
	private Label dsbrdSnvUsrStg;
	private Label dsbrdSnvSrch;
	private Label dsbrdPgeTitle;

	private Label mainCntGreet;
	private Label mainSttTitle;
	private Label mainSttNmBkLbl;
	private Label mainSttNmBkVal;
	private Label mainSttNmMbrLbl;
	private Label mainSttNmMbrVal;
	private Label mainSttOvrBkLbl;
	private Label mainSttOvrBkVal;

	private Button adminMngUsrBtn;
	private Panel mngUsrChseCont;
	private Button mngUsrContClose;
	private Label mngUsrTitle;

	private DataGridView dataGridView1;
	private Label mngUsrNmUsrLbl;
	private Label mngUsrNmUsrVal;
	private Button mngUsrActivateMng;
	private Label mngUsrActivateLbl;
	private Button mngUsrAddBtn;

	private Panel mngUsrAddCont;
	private Label mngUsrAddTitle;
	private Button mngUsrAddCloseBtn;
	private Label addUsrnmLbl;
	private TextBox addUsrnmVal;
	private Label addPswdLbl;
	private TextBox addPswdVal;
	private Label addRoleLbl;
	private ComboBox addRoleVal;
	private Button addUsrBtn;
	private Label nonAdminMsg;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(19200, 1008);
        this.Text = "Dashboard Page";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;

	dsbrdHeader = new Panel();
	dsbrdHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(dsbrdHeader);

	dsbrdMainTitle = new Label();
	dsbrdMainTitle.Text = "Cruise Library Management System";
	dsbrdMainTitle.ForeColor = Color.White;
	dsbrdMainTitle.BackColor = Color.Transparent;
	dsbrdMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdHeader.Controls.Add(dsbrdMainTitle);

	dsbrdPgeTitle = new Label();
	dsbrdPgeTitle.Text = "DASHBOARD";
	dsbrdPgeTitle.ForeColor = Color.Brown;
	dsbrdPgeTitle.BackColor = Color.Transparent;
	dsbrdPgeTitle.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdHeader.Controls.Add(dsbrdPgeTitle);

	dsbrdLogo = new PictureBox();
	dsbrdLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	dsbrdHeader.Controls.Add(dsbrdLogo);

	logoutBtn = new Button();
	logoutBtn.Text = "LOGOUT";
	logoutBtn.BackColor = Color.Blue;
	logoutBtn.ForeColor = Color.Crimson;
	logoutBtn.Cursor = Cursors.Hand;
	logoutBtn.Click += new EventHandler(logoutBtn_Clicked);
	dsbrdHeader.Controls.Add(logoutBtn);

	dsbrdSideNav = new Panel();
	dsbrdSideNav.BackColor = Color.White;
	dsbrdSideNav.BorderStyle = BorderStyle.Fixed3D;
	this.Controls.Add(dsbrdSideNav);

	dsbrdSnvTitle = new Label();
	dsbrdSnvTitle.Text = "Navigation";
	dsbrdSnvTitle.BackColor = Color.CornflowerBlue;
	dsbrdSnvTitle.ForeColor = Color.White;
	dsbrdSnvTitle.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSideNav.Controls.Add(dsbrdSnvTitle);

	dsbrdSnvBkMgt =  new Label();
	dsbrdSnvBkMgt.Text = "Book Management";
	dsbrdSnvBkMgt.ForeColor = Color.Blue;
	dsbrdSnvBkMgt.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvBkMgt.Click += new EventHandler(dsbrdSnvBkMgt_Clicked);
	dsbrdSnvBkMgt.Cursor = Cursors.Hand;
	dsbrdSnvBkMgt.MouseEnter += new EventHandler(dsbrdSnvBkMgt_MouseEnter);
	dsbrdSnvBkMgt.MouseLeave += new EventHandler(dsbrdSnvBkMgt_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvBkMgt);

	dsbrdSnvMbrMgt =  new Label();
	dsbrdSnvMbrMgt.Text = "Member Management";
	dsbrdSnvMbrMgt.ForeColor = Color.Blue;
	dsbrdSnvMbrMgt.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvMbrMgt.Click += new EventHandler(dsbrdSnvMbrMgt_Clicked);
	dsbrdSnvMbrMgt.Cursor = Cursors.Hand;
	dsbrdSnvMbrMgt.MouseEnter += new EventHandler(dsbrdSnvMbrMgt_MouseEnter);
	dsbrdSnvMbrMgt.MouseLeave += new EventHandler(dsbrdSnvMbrMgt_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvMbrMgt);

	dsbrdSnvBrw =  new Label();
	dsbrdSnvBrw.Text = "Borrow Book";
	dsbrdSnvBrw.ForeColor = Color.Blue;
	dsbrdSnvBrw.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvBrw.Click += new EventHandler(dsbrdSnvBrw_Clicked);
	dsbrdSnvBrw.Cursor = Cursors.Hand;
	dsbrdSnvBrw.MouseEnter += new EventHandler(dsbrdSnvBrw_MouseEnter);
	dsbrdSnvBrw.MouseLeave += new EventHandler(dsbrdSnvBrw_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvBrw);

	dsbrdSnvRtn =  new Label();
	dsbrdSnvRtn.Text = "Return Book";
	dsbrdSnvRtn.ForeColor = Color.Blue;
	dsbrdSnvRtn.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvRtn.Click += new EventHandler(dsbrdSnvRtn_Clicked);
	dsbrdSnvRtn.Cursor = Cursors.Hand;
	dsbrdSnvRtn.MouseEnter += new EventHandler(dsbrdSnvRtn_MouseEnter);
	dsbrdSnvRtn.MouseLeave += new EventHandler(dsbrdSnvRtn_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvRtn);

	dsbrdSnvRpt =  new Label();
	dsbrdSnvRpt.Text = "Reports";
	dsbrdSnvRpt.ForeColor = Color.Blue;
	dsbrdSnvRpt.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvRpt.Click += new EventHandler(dsbrdSnvRpt_Clicked);
	dsbrdSnvRpt.Cursor = Cursors.Hand;
	dsbrdSnvRpt.MouseEnter += new EventHandler(dsbrdSnvRpt_MouseEnter);
	dsbrdSnvRpt.MouseLeave += new EventHandler(dsbrdSnvRpt_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvRpt);

	dsbrdSnvUsrStg =  new Label();
	dsbrdSnvUsrStg.Text = "User Setting";
	dsbrdSnvUsrStg.ForeColor = Color.Blue;
	dsbrdSnvUsrStg.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvUsrStg.Click += new EventHandler(dsbrdSnvUsrStg_Clicked);
	dsbrdSnvUsrStg.Cursor = Cursors.Hand;
	dsbrdSnvUsrStg.MouseEnter += new EventHandler(dsbrdSnvUsrStg_MouseEnter);
	dsbrdSnvUsrStg.MouseLeave += new EventHandler(dsbrdSnvUsrStg_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvUsrStg);

	dsbrdSnvSrch =  new Label();
	dsbrdSnvSrch.Text = "Search";
	dsbrdSnvSrch.ForeColor = Color.Blue;
	dsbrdSnvSrch.TextAlign = ContentAlignment.MiddleCenter;
	dsbrdSnvSrch.Click += new EventHandler(dsbrdSnvSrch_Clicked);
	dsbrdSnvSrch.Cursor = Cursors.Hand;
	dsbrdSnvSrch.MouseEnter += new EventHandler(dsbrdSnvSrch_MouseEnter);
	dsbrdSnvSrch.MouseLeave += new EventHandler(dsbrdSnvSrch_MouseLeave);
	dsbrdSideNav.Controls.Add(dsbrdSnvSrch);

	dsbrdMainCont = new Panel();
	dsbrdMainCont.BackColor = Color.White;
	this.Controls.Add(dsbrdMainCont);

	mainCntGreet = new Label();
	mainCntGreet.AutoSize = true;
	dsbrdMainCont.Controls.Add(mainCntGreet);

	mainSttTitle = new Label();
	mainSttTitle.Text = "Key Statistics";
	mainSttTitle.AutoSize = true;
	mainSttTitle.ForeColor = Color.DarkSlateGray;
	dsbrdMainCont.Controls.Add(mainSttTitle);

	mainSttNmBkLbl = new Label();
	mainSttNmBkLbl.Text = "Total Number Of Books: ";
	mainSttNmBkLbl.TextAlign = ContentAlignment.MiddleLeft;
	dsbrdMainCont.Controls.Add(mainSttNmBkLbl);

	mainSttNmBkVal = new Label();
	mainSttNmBkVal.ForeColor = Color.CornflowerBlue;	
	mainSttNmBkVal.TextAlign = ContentAlignment.MiddleLeft;
	mainSttNmBkVal.TextAlign = ContentAlignment.MiddleLeft;
	dsbrdMainCont.Controls.Add(mainSttNmBkVal);

	mainSttNmMbrLbl = new Label();
	mainSttNmMbrLbl.Text = "Total Number Of Members: ";
	mainSttNmMbrLbl.TextAlign = ContentAlignment.MiddleLeft;
	dsbrdMainCont.Controls.Add(mainSttNmMbrLbl);

	mainSttNmMbrVal = new Label();
	mainSttNmMbrVal.ForeColor = Color.CornflowerBlue;	
	mainSttNmMbrVal.TextAlign = ContentAlignment.MiddleLeft;
	mainSttNmMbrVal.TextAlign = ContentAlignment.MiddleLeft;
	dsbrdMainCont.Controls.Add(mainSttNmMbrVal);

	mainSttOvrBkLbl = new Label();
	mainSttOvrBkLbl.Text = "Total Overdue Books: ";
	mainSttOvrBkLbl.TextAlign = ContentAlignment.MiddleLeft;
	dsbrdMainCont.Controls.Add(mainSttOvrBkLbl);

	mainSttOvrBkVal = new Label();
	mainSttOvrBkVal.ForeColor = Color.CornflowerBlue;	
	mainSttOvrBkVal.TextAlign = ContentAlignment.MiddleLeft;
	mainSttOvrBkVal.TextAlign = ContentAlignment.MiddleLeft;
	dsbrdMainCont.Controls.Add(mainSttOvrBkVal);

	adminMngUsrBtn = new Button();
	adminMngUsrBtn.Text = "MANAGE USERS";
	adminMngUsrBtn.BackColor = Color.CadetBlue;
	adminMngUsrBtn.ForeColor = Color.White;
	adminMngUsrBtn.Cursor = Cursors.Hand;
	adminMngUsrBtn.Click += new EventHandler(adminMngUsrBtn_Clicked);
	dsbrdMainCont.Controls.Add(adminMngUsrBtn);

	mngUsrChseCont = new Panel();
	mngUsrChseCont.BackColor = Color.Azure;
	mngUsrChseCont.BorderStyle = BorderStyle.FixedSingle;
	this.Controls.Add(mngUsrChseCont);
	this.Controls.SetChildIndex(mngUsrChseCont,0);

	mngUsrTitle = new Label();
	mngUsrTitle.Text = "MANAGE USERS";
	mngUsrChseCont.Controls.Add(mngUsrTitle);

	mngUsrContClose = new Button();
	mngUsrContClose.Text = "X";
	mngUsrContClose.ForeColor = Color.Red;
	mngUsrContClose.Click += new EventHandler(mngUsrContClose_Clicked);
	mngUsrChseCont.Controls.Add(mngUsrContClose);

	mngUsrNmUsrLbl = new Label();
	mngUsrNmUsrLbl.Text = "Total Number Of Users: ";
	mngUsrNmUsrLbl.ForeColor = Color.DarkSlateGray;
	mainSttOvrBkLbl.TextAlign = ContentAlignment.MiddleLeft;
	mngUsrChseCont.Controls.Add(mngUsrNmUsrLbl);

	mngUsrNmUsrVal = new Label();
	mngUsrNmUsrVal.ForeColor = Color.CornflowerBlue;	
	mngUsrNmUsrVal.TextAlign = ContentAlignment.MiddleLeft;
	mngUsrNmUsrVal.TextAlign = ContentAlignment.MiddleLeft;
	mngUsrChseCont.Controls.Add(mngUsrNmUsrVal);

	mngUsrActivateMng = new Button();
	mngUsrActivateMng.Text = "EDIT USERS";
	mngUsrActivateMng.BackColor = Color.Yellow;
	mngUsrActivateMng.Click += new EventHandler(mngUsrActivateMng_Clicked);
	mngUsrChseCont.Controls.Add(mngUsrActivateMng);

	mngUsrActivateLbl = new Label();
	mngUsrActivateLbl.Text = "Now You Can Edit the Table!";
	mngUsrActivateLbl.ForeColor = Color.Green;
	mngUsrChseCont.Controls.Add(mngUsrActivateLbl);

	mngUsrAddBtn = new Button();
	mngUsrAddBtn.Text = "ADD USER";
	mngUsrAddBtn.BackColor = Color.Yellow;
	mngUsrAddBtn.Click += new EventHandler(mngUsrAddBtn_Clicked);
	mngUsrChseCont.Controls.Add(mngUsrAddBtn);

	dataGridView1 = new DataGridView();
	mngUsrChseCont.Controls.Add(dataGridView1);
	
	mngUsrAddCont = new Panel();
	mngUsrAddCont.BackColor = Color.Aquamarine;
	mngUsrAddCont.BorderStyle = BorderStyle.FixedSingle;
	this.Controls.Add(mngUsrAddCont);
	this.Controls.SetChildIndex(mngUsrAddCont,0);

	mngUsrAddTitle = new Label();
	mngUsrAddTitle.Text = "Add New User";
	mngUsrAddTitle.Location = new Point(350,30);
	mngUsrAddCont.Controls.Add(mngUsrAddTitle);

	mngUsrAddCloseBtn = new Button();
	mngUsrAddCloseBtn.Text = "X";
	mngUsrAddCloseBtn.ForeColor = Color.Red;
	mngUsrAddCloseBtn.Click += new EventHandler(mngUsrAddCloseBtn_Clicked);
	mngUsrAddCont.Controls.Add(mngUsrAddCloseBtn);

	addUsrnmLbl = new Label();
	addUsrnmLbl.Text = "Username:";
	addUsrnmLbl.ForeColor = Color.DarkSlateGray;
	mngUsrAddCont.Controls.Add(addUsrnmLbl);

	addUsrnmVal = new TextBox();
	mngUsrAddCont.Controls.Add(addUsrnmVal);

	addPswdLbl = new Label();
	addPswdLbl.Text = "Password:";
	addPswdLbl.ForeColor = Color.DarkSlateGray;
	mngUsrAddCont.Controls.Add(addPswdLbl);

	addPswdVal = new TextBox();
	mngUsrAddCont.Controls.Add(addPswdVal);

	addRoleLbl = new Label();
	addRoleLbl.Text = "Role:";
	addRoleLbl.ForeColor = Color.DarkSlateGray;
	mngUsrAddCont.Controls.Add(addRoleLbl);

	addRoleVal = new ComboBox();
	addRoleVal.Items.Add("Admin");
	addRoleVal.Items.Add("librarian");
	mngUsrAddCont.Controls.Add(addRoleVal);

	addUsrBtn = new Button();
	addUsrBtn.Text = "ADD USER";
	addUsrBtn.BackColor = Color.Green;
	addUsrBtn.Click += new EventHandler(addUsrBtn_Clicked);
	mngUsrAddCont.Controls.Add(addUsrBtn);

	nonAdminMsg = new Label();
	nonAdminMsg.Text = "YOU HAVE NO PRIVILAGE TO MANAGE USERS";
	nonAdminMsg.BackColor = Color.CadetBlue;
	nonAdminMsg.ForeColor = Color.Red;
	dsbrdMainCont.Controls.Add(nonAdminMsg);
	
    }

    #endregion
}
