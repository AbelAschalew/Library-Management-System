
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProjectApp;

partial class HomePage
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



	private Panel hmeHeaderPanel;
	private PictureBox hmeLogo;
	private Label hmeMainTitle;
	private PictureBox slideshowBox;
	private Label hmeSlogan;
	private Button hmeLgnBtn;
	private Panel hmeFooter;
	private PictureBox fbIcon;
	private PictureBox instaIcon;
	private PictureBox twitIcon;

	private Label copyrightLbl;
	private Button exitBtn;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1008);
        this.Text = "HomePage";
	this.WindowState = FormWindowState.Maximized;
	this.BackgroundImageLayout = ImageLayout.Stretch;


	hmeHeaderPanel = new Panel();
	hmeHeaderPanel.BackColor = Color.FromArgb(200, 154,205,50);
	this.Controls.Add(hmeHeaderPanel);
	
	hmeLogo = new PictureBox();
	hmeLogo.SizeMode = PictureBoxSizeMode.StretchImage;
	hmeHeaderPanel.Controls.Add(hmeLogo);

	hmeMainTitle = new Label();
	hmeMainTitle.Text = "Cruise School Library Management System";
	hmeMainTitle.BackColor = Color.Transparent;
	hmeMainTitle.ForeColor = Color.White;
	hmeMainTitle.TextAlign = ContentAlignment.MiddleCenter;
	hmeHeaderPanel.Controls.Add(hmeMainTitle);

	hmeSlogan  = new Label();
	hmeSlogan.Text = "Start your future with us!";
	hmeSlogan.BackColor = Color.Transparent;
	hmeHeaderPanel.Controls.Add(hmeSlogan);

	slideshowBox = new PictureBox();
	slideshowBox.SizeMode = PictureBoxSizeMode.StretchImage;
	this.Controls.Add(slideshowBox);

	hmeLgnBtn = new Button();
	hmeLgnBtn.Text = "Login";
	hmeLgnBtn.BackColor = Color.Green;
	hmeLgnBtn.Cursor = Cursors.Hand;
	hmeLgnBtn.Click += new EventHandler(hmeLgnBtn_Clicked);
	this.Controls.Add(hmeLgnBtn);
	this.Controls.SetChildIndex(hmeLgnBtn,0);

	hmeFooter = new Panel();
	hmeFooter.BackColor = Color.FromArgb(200,154,205,50);
	this.Controls.Add(hmeFooter);

	fbIcon = new PictureBox();
	fbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
	fbIcon.Cursor = Cursors.Hand;
	fbIcon.Click += new EventHandler(fbIcon_Clicked);
	hmeFooter.Controls.Add(fbIcon);

	instaIcon = new PictureBox();
	instaIcon.SizeMode = PictureBoxSizeMode.StretchImage;
	instaIcon.Cursor = Cursors.Hand;
	instaIcon.Click += new EventHandler(instaIcon_Clicked);
	hmeFooter.Controls.Add(instaIcon);

	twitIcon = new PictureBox();
	twitIcon.SizeMode = PictureBoxSizeMode.StretchImage;
	twitIcon.Cursor = Cursors.Hand;
	twitIcon.Click += new EventHandler(twitIcon_Clicked);
	hmeFooter.Controls.Add(twitIcon);

	copyrightLbl = new Label();
	copyrightLbl.Text = "@Copyright: Abel Aschalew";
	copyrightLbl.AutoSize = true;
	copyrightLbl.ForeColor = Color.Red;
	hmeFooter.Controls.Add(copyrightLbl); 

	exitBtn = new Button();
	exitBtn.Text = "EXIT";
	exitBtn.BackColor = Color.Red;
	exitBtn.ForeColor = Color.White;
	exitBtn.Cursor = Cursors.Hand;
	exitBtn.Click += new EventHandler(exitBtn_Clicked);
	hmeFooter.Controls.Add(exitBtn);

    }

    #endregion
}
