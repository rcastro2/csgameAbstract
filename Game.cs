using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class Game : System.Windows.Forms.Form{

	//bm is "Canvas" in memory where we can draw
	Bitmap bm = new Bitmap(1000, 1000);
	//bmg is the Graphics we will use in order to draw on the "Canvas"
	Graphics canvas;
	Input tool;
	Start main;

	//Main starts the program which creates and runs the Form
	static void Main(){

		Application.Run(new Game());
	}

	//This function must have the same name as the program.  This is called a constructor.
	//Any variables that need initializing going here.
	public Game(){
		InitializeComponent();
	}

	//Any initial processing goes here such as loading arrays or generating initial random values
	private void Game_Load(object sender, EventArgs e){
		//Following line connects canvas to bm so that we can draw on it
		canvas = Graphics.FromImage(bm);
		tool = new Input();
		main = new Start(canvas,tool);
		//Enable the timer for create animation
	  tmrGame.Enabled = true;

	}

	//Paints to the Form1
	private void Game_Paint(object sender,PaintEventArgs e){
		//Take the image stored on the Canvas and draw it to the form once
		e.Graphics.DrawImage(bm, 0, 0);
	}

	private void Game_KeyDown(object sender,KeyEventArgs e){
		tool.keyDown = e.KeyCode.ToString();
	}

	private void Game_KeyUp(object sender,KeyEventArgs e){
		tool.keyDown = "";
	}

	private void Game_MouseMove(object sender, MouseEventArgs e)
	{
		tool.mouseX = e.X;
		tool.mouseY = e.Y;
	}

	private void Game_MouseDown(object sender, MouseEventArgs e)
	{
		tool.leftButton = e.Button == MouseButtons.Left;
		tool.rightButton = e.Button == MouseButtons.Right;
	}

	private void Game_MouseUp(object sender, MouseEventArgs e)
	{
		tool.leftButton = false;
		tool.rightButton = false;
	}

	//Timer controls the game
	private void tmrGame_Tick(object sender, EventArgs e){
		main.update();

		this.Invalidate();
	}


	//Used to initialize the Form and Add a Timer called tmrGame
	private System.ComponentModel.IContainer components = null;
	private System.Windows.Forms.Timer tmrGame;

	private void InitializeComponent()
	{

		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
		this.tmrGame = new System.Windows.Forms.Timer(this.components);

		this.tmrGame.Interval = 10;
		this.tmrGame.Tick += new EventHandler(this.tmrGame_Tick);

		this.Width = 800;
		this.Height = 600;
		this.DoubleBuffered = true;
		this.Load += new EventHandler(this.Game_Load);
		this.KeyDown += new KeyEventHandler(this.Game_KeyDown);
		this.KeyUp += new KeyEventHandler(this.Game_KeyUp);
		this.MouseMove += new MouseEventHandler(this.Game_MouseMove);
		this.MouseDown += new MouseEventHandler(this.Game_MouseDown);
		this.MouseUp += new MouseEventHandler(this.Game_MouseUp);
		this.Paint += new PaintEventHandler(this.Game_Paint);


	}
}
