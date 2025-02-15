
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProjectApp;

partial class LoginPage
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


	private Panel lgnHeader;
	private Label lgnMainTitle;
	private Panel lgnFormCont;
	private Label lgnFormTitle;
	private Label lgnUsrnmLbl;
	private TextBox lgnUsrnmInp;
	private Label lgnPswLbl;
	private TextBox lgnPswInp;
	private Button lgnBtn;
	private Button backtoHome;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "LoginPage";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;

	lgnHeader = new Panel();
	lgnHeader.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(lgnHeader);

	lgnMainTitle = new Label();
	lgnMainTitle.Text = "Login Page";
	lgnMainTitle.ForeColor = Color.White;
	lgnMainTitle.BackColor = Color.Transparent;
	lgnMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	lgnHeader.Controls.Add(lgnMainTitle);

	lgnFormCont = new Panel();
	lgnFormCont.BackColor = Color.White;
	this.Controls.Add(lgnFormCont);

	lgnFormTitle = new Label();
	lgnFormTitle.Text = "Enter Credentials to Login:";
	lgnFormTitle.AutoSize = true;
	lgnFormCont.Controls.Add(lgnFormTitle);

	lgnUsrnmLbl = new Label();
	lgnUsrnmLbl.Text = "Username:";
	lgnUsrnmLbl.TextAlign = ContentAlignment.MiddleCenter;
	lgnUsrnmLbl.ForeColor = Color.DarkSlateGray;
	lgnFormCont.Controls.Add(lgnUsrnmLbl);

	lgnUsrnmInp = new TextBox();
	lgnUsrnmInp.BackColor = Color.LightGray;
	lgnFormCont.Controls.Add(lgnUsrnmInp);

	lgnPswLbl = new Label();
	lgnPswLbl.Text = "Password:";
	lgnPswLbl.Location = new Point(120,350);
	lgnPswLbl.TextAlign = ContentAlignment.MiddleCenter;
	lgnPswLbl.ForeColor = Color.DarkSlateGray;
	lgnFormCont.Controls.Add(lgnPswLbl);

	lgnPswInp = new TextBox();
	lgnPswInp.BackColor = Color.LightGray;
	lgnPswInp.UseSystemPasswordChar = true;
	lgnFormCont.Controls.Add(lgnPswInp);

	lgnBtn = new Button();
	lgnBtn.Text = "LOGIN";
	lgnBtn.BackColor = Color.Green;
	lgnBtn.Click += new EventHandler(lgnBtn_Clicked);
	lgnFormCont.Controls.Add(lgnBtn);

	backtoHome = new Button();
	backtoHome.Text = "Back to Home";
	backtoHome.ForeColor = Color.Blue;
	backtoHome.BackColor = Color.BurlyWood;
	backtoHome.Click += new EventHandler(backtoHome_Clicked);
	this.Controls.Add(backtoHome);

    }

    #endregion
}
