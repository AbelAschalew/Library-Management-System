
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace MiniProjectApp;

public partial class HomePage : Form
{

	private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
	private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

	private Image[] slideImages;
	private System.Windows.Forms.Timer slideshowTimer;
	private int slideIndex = 0;
	private LoginPage LoginForm;
	

    public HomePage()
    {
        InitializeComponent();

	this.DoubleBuffered = true;

	this.Icon = EmbeddedFormIconLoader.LoadFormIcon("MiniProjectApp.Resources.cruiseFavicon.ico");
	this.BackgroundImage = EmbeddedBackgroundImageLoader.backgroundImageLoader("MiniProjectApp.Resources.formbackgroundImage.jpg");

	hmeLogo.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.cruiseLogo.jpg");

	slideImages = new Image[4];
	slideImages[0] = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.slideshowImage2.jpg");
	slideImages[1] = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.slideshowImage3.jpg");
	slideImages[2] = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.slideshowImage4.jpg");
	slideImages[3] = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.slideshowImage5.jpg");

	slideshowTimer = new System.Windows.Forms.Timer();
	slideshowTimer.Interval = 2000;
	slideshowTimer.Tick += slideShowFunc;
	slideshowTimer.Start();

	fbIcon.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.facebookIcon.png");
	instaIcon.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.instagramIcon.png");
	twitIcon.Image = EmbeddedImageLoader.ImageLoader("MiniProjectApp.Resources.twitterIcon.png");


	this.FormClosed += (sender,e) => Application.Exit();
	this.VisibleChanged += stopSlideshow;

	LoginForm = new LoginPage(this);

	this.Resize += AdjustSizePosition;


    }

	private void slideShowFunc(object sender, EventArgs e) {
		slideshowBox.Image = slideImages[slideIndex];
		slideIndex++;
		if (slideIndex >= 3) {
			slideIndex = 0;
		}
	}

	private void stopSlideshow (object sender, EventArgs e) {
		if (!this.Visible)
			slideshowTimer.Stop();
		else
			slideshowTimer.Start();
	}

	private void hmeLgnBtn_Clicked (object sender, EventArgs e) {
		this.Hide();
		LoginForm.Show();
	}

	private void fbIcon_Clicked (object sender, EventArgs e) {
		OpenLink ("https://web.facebook.com/groups/1420189281588414/?_rdc=1&_rdr#");
	}


	private void instaIcon_Clicked (object sender, EventArgs e) {
		OpenLink ("https://www.instagram.com/explore/locations/120211328028608/cruise-school/");
	}

	private void twitIcon_Clicked (object sender, EventArgs e) {
		OpenLink ("https://cruiseschoolet.com/");
	}

	private void OpenLink (string url) {
		try {
			Process.Start (new ProcessStartInfo{
				FileName = url,
				UseShellExecute = true
			});
		} catch {
			MessageBox.Show("Unable to open the link.", "Error", MessageBoxButtons.OK, 							MessageBoxIcon.Error);

		}
	}

	
	
	protected override void OnLoad (EventArgs e) {
		base.OnLoad(e);

		hmeHeaderPanel.Width = (int)(screenWidth*1);
		hmeHeaderPanel.Height = (int)(screenHeight*0.1984);
		hmeHeaderPanel.Left = (int)(screenWidth*0);
		hmeHeaderPanel.Top = (int)(screenHeight*0);

		hmeLogo.Width = (int)(screenWidth*0.0781);
		hmeLogo.Height = (int)(screenHeight*0.0892);
		hmeLogo.Left = (int)(hmeHeaderPanel.Width*0.0260);
		hmeLogo.Top = (int)(hmeHeaderPanel.Height*0.15);

		hmeMainTitle.Width = (int)(screenWidth*0.8333);
		hmeMainTitle.Height = (int)(screenHeight*0.0892);
		hmeMainTitle.Left = (int)(hmeHeaderPanel.Width*0.1302);
		hmeMainTitle.Top = (int)(hmeHeaderPanel.Height*0.15);
		int hmeMainTitleFont = (int)(screenWidth*0.0166);
		hmeMainTitle.Font = new Font("roboto",hmeMainTitleFont, FontStyle.Bold);

		hmeSlogan.Width = (int)(screenWidth*0.5208);
		hmeSlogan.Height = (int)(screenHeight*0.0496);
		hmeSlogan.Left = (int)(hmeHeaderPanel.Width*0.1302);
		hmeSlogan.Top = (int)(hmeHeaderPanel.Height*0.65);
		int hmeSloganFont = (int)(screenWidth*0.0088);
		hmeSlogan.Font = new Font("roboto",hmeSloganFont, FontStyle.Bold);

		slideshowBox.Width = (int)(screenWidth*0.9375);
		slideshowBox.Height = (int)(screenHeight*0.5952);
		slideshowBox.Left = (int)(screenWidth*0.0260);
		slideshowBox.Top = (int)(screenHeight*0.248);

		hmeLgnBtn.Width = (int)(screenWidth*0.1562);
		hmeLgnBtn.Height = (int)(screenHeight*0.0992);
		hmeLgnBtn.Left = (int)(screenWidth*0.4296);
		hmeLgnBtn.Top = (int)(screenHeight*0.4216);
		int hmeLgnBtnFont = (int)(screenWidth*0.0114);
		hmeLgnBtn.Font = new Font("Arial",hmeLgnBtnFont, FontStyle.Bold);

		hmeFooter.Width = (int)(screenWidth*1);
		hmeFooter.Height = (int)(screenHeight*0.0992);
		hmeFooter.Left = (int)(screenWidth*0);
		hmeFooter.Top = (int)(screenHeight*0.8730);

		fbIcon.Width = (int)(screenWidth*0.0416);
		fbIcon.Height = (int)(screenHeight*0.0793);
		fbIcon.Left = (int)(hmeFooter.Width*0.3645);
		fbIcon.Top = (int)(hmeFooter.Height*0.1);

		instaIcon.Width = (int)(screenWidth*0.0416);
		instaIcon.Height = (int)(screenHeight*0.0793);
		instaIcon.Left = (int)(hmeFooter.Width*0.4427);
		instaIcon.Top = (int)(hmeFooter.Height*0.1);

		twitIcon.Width = (int)(screenWidth*0.0416);
		twitIcon.Height = (int)(screenHeight*0.0793);
		twitIcon.Left = (int)(hmeFooter.Width*0.5208);
		twitIcon.Top = (int)(hmeFooter.Height*0.1);

		copyrightLbl.Left = (int)(hmeFooter.Width*0.0260);
		copyrightLbl.Top = (int)(hmeFooter.Height*0.25);
		int copyrightLblFont = (int)(screenWidth*0.0093);
		copyrightLbl.Font = new Font("Arial",copyrightLblFont,FontStyle.Bold);

		exitBtn.Width = (int)(screenWidth*0.1041);
		exitBtn.Height = (int)(screenHeight*0.0793);
		exitBtn.Left = (int)(hmeFooter.Width*0.8697);
		exitBtn.Top = (int)(hmeFooter.Height*0.1);
		int exitBtnFont = (int)(screenWidth*0.0088);
		exitBtn.Font = new Font("Arial",exitBtnFont, FontStyle.Bold);
		
	}

	private void AdjustSizePosition (object sender, EventArgs e) {
		int formWidth = this.ClientSize.Width;
		int formHeight = this.ClientSize.Height;

		hmeHeaderPanel.Width = (int)(formWidth*1);
		hmeHeaderPanel.Height = (int)(formHeight*0.1984);
		hmeHeaderPanel.Left = (int)(formWidth*0);
		hmeHeaderPanel.Top = (int)(formHeight*0);

		hmeLogo.Width = (int)(formWidth*0.0781);
		hmeLogo.Height = (int)(formHeight*0.0892);
		hmeLogo.Left = (int)(hmeHeaderPanel.Width*0.0260);
		hmeLogo.Top = (int)(hmeHeaderPanel.Height*0.15);

		hmeMainTitle.Width = (int)(formWidth*0.8333);
		hmeMainTitle.Height = (int)(formHeight*0.0892);
		hmeMainTitle.Left = (int)(hmeHeaderPanel.Width*0.1302);
		hmeMainTitle.Top = (int)(hmeHeaderPanel.Height*0.15);
		int hmeMainTitleFont = (int)(formWidth*0.0166);
		hmeMainTitle.Font = new Font("roboto",hmeMainTitleFont, FontStyle.Bold);

		hmeSlogan.Width = (int)(formWidth*0.5208);
		hmeSlogan.Height = (int)(formHeight*0.0496);
		hmeSlogan.Left = (int)(hmeHeaderPanel.Width*0.1302);
		hmeSlogan.Top = (int)(hmeHeaderPanel.Height*0.65);
		int hmeSloganFont = (int)(formWidth*0.0088);
		hmeSlogan.Font = new Font("roboto",hmeSloganFont, FontStyle.Bold);

		slideshowBox.Width = (int)(formWidth*0.9375);
		slideshowBox.Height = (int)(formHeight*0.5952);
		slideshowBox.Left = (int)(formWidth*0.0260);
		slideshowBox.Top = (int)(formHeight*0.248);

		hmeLgnBtn.Width = (int)(formWidth*0.1562);
		hmeLgnBtn.Height = (int)(formHeight*0.0992);
		hmeLgnBtn.Left = (int)(formWidth*0.4296);
		hmeLgnBtn.Top = (int)(formHeight*0.4216);
		int hmeLgnBtnFont = (int)(formWidth*0.0114);
		hmeLgnBtn.Font = new Font("Arial",hmeLgnBtnFont, FontStyle.Bold);

		hmeFooter.Width = (int)(formWidth*1);
		hmeFooter.Height = (int)(formHeight*0.0992);
		hmeFooter.Left = (int)(formWidth*0);
		hmeFooter.Top = (int)(formHeight*0.8730);

		fbIcon.Width = (int)(formWidth*0.0416);
		fbIcon.Height = (int)(formHeight*0.0793);
		fbIcon.Left = (int)(hmeFooter.Width*0.3645);
		fbIcon.Top = (int)(hmeFooter.Height*0.1);

		instaIcon.Width = (int)(formWidth*0.0416);
		instaIcon.Height = (int)(formHeight*0.0793);
		instaIcon.Left = (int)(hmeFooter.Width*0.4427);
		instaIcon.Top = (int)(hmeFooter.Height*0.1);
		
		twitIcon.Width = (int)(formWidth*0.0416);
		twitIcon.Height = (int)(formHeight*0.0793);
		twitIcon.Left = (int)(hmeFooter.Width*0.5208);
		twitIcon.Top = (int)(hmeFooter.Height*0.1);

		copyrightLbl.Left = (int)(hmeFooter.Width*0.0260);
		copyrightLbl.Top = (int)(hmeFooter.Height*0.25);
		int copyrightLblFont = (int)(formWidth*0.0093);
		copyrightLbl.Font = new Font("Arial",copyrightLblFont,FontStyle.Bold);

		exitBtn.Width = (int)(formWidth*0.1041);
		exitBtn.Height = (int)(formHeight*0.0793);
		exitBtn.Left = (int)(hmeFooter.Width*0.8697);
		exitBtn.Top = (int)(hmeFooter.Height*0.1);
		int exitBtnFont = (int)(formWidth*0.0088);
		exitBtn.Font = new Font("Arial",exitBtnFont, FontStyle.Bold);

	}

	private void exitBtn_Clicked (object sender, EventArgs e) {
		Application.Exit();
	}

}
