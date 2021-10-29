using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for fmTest.
	/// </summary>
	public class fmTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bPlay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bStep;
		private System.Windows.Forms.Button bClose;
		private System.Windows.Forms.TrackBar trbSpeed;
		private System.Windows.Forms.PictureBox pbWorld;
		private static System.Collections.ArrayList listOfWorldObjects; 
		//A list of the objects in the world 
		private WorldObject tempWorldObject;
		private Random randomNumber;
		private static System.Drawing.Point creaturePosition;
		private static System.Drawing.Point lastCreaturePosition;
		private System.Windows.Forms.Panel pnlButtons;
		private static System.Drawing.Graphics worldPanelGraphicsObject;
		private System.Windows.Forms.ListBox lbNeuronDetails;
		private System.Windows.Forms.Button bShowSenses;
		private System.Windows.Forms.Button bStop;
		private System.Windows.Forms.Timer timerNetThink;
		private System.ComponentModel.IContainer components;
		private static int storedEnergy = 0;
		private static readonly int creatureSize = 10;
		private System.Windows.Forms.Label lblStoredEnergy;
		private System.Windows.Forms.TextBox tbStoredEnergy;
		private readonly int SizeOfWorld = 400;
		private ulong ticksSinceStart = 0;
		private static bool verbose = false;
		private System.Windows.Forms.Button bExpand;
		private System.Windows.Forms.Form editFormHandle;

		public fmTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//			
			listOfWorldObjects = new ArrayList();
		}
		public fmTest(System.Windows.Forms.Form passedEditFormHandle)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//			
			listOfWorldObjects = new ArrayList();
			this.editFormHandle = passedEditFormHandle;
			ResetWorld();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmTest));
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.bShowSenses = new System.Windows.Forms.Button();
			this.bClose = new System.Windows.Forms.Button();
			this.bStep = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.trbSpeed = new System.Windows.Forms.TrackBar();
			this.bPlay = new System.Windows.Forms.Button();
			this.bStop = new System.Windows.Forms.Button();
			this.pbWorld = new System.Windows.Forms.PictureBox();
			this.lbNeuronDetails = new System.Windows.Forms.ListBox();
			this.timerNetThink = new System.Windows.Forms.Timer(this.components);
			this.tbStoredEnergy = new System.Windows.Forms.TextBox();
			this.lblStoredEnergy = new System.Windows.Forms.Label();
			this.bExpand = new System.Windows.Forms.Button();
			this.pnlButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlButtons
			// 
			this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlButtons.BackColor = System.Drawing.Color.CornflowerBlue;
			this.pnlButtons.Controls.Add(this.bShowSenses);
			this.pnlButtons.Controls.Add(this.bClose);
			this.pnlButtons.Controls.Add(this.bStep);
			this.pnlButtons.Controls.Add(this.label1);
			this.pnlButtons.Controls.Add(this.trbSpeed);
			this.pnlButtons.Controls.Add(this.bPlay);
			this.pnlButtons.Controls.Add(this.bStop);
			this.pnlButtons.ForeColor = System.Drawing.Color.DarkBlue;
			this.pnlButtons.Location = new System.Drawing.Point(0, 416);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(328, 112);
			this.pnlButtons.TabIndex = 0;
			// 
			// bShowSenses
			// 
			this.bShowSenses.Location = new System.Drawing.Point(248, 16);
			this.bShowSenses.Name = "bShowSenses";
			this.bShowSenses.Size = new System.Drawing.Size(64, 32);
			this.bShowSenses.TabIndex = 6;
			this.bShowSenses.Text = "Show Senses";
			this.bShowSenses.Click += new System.EventHandler(this.bShowSenses_Click);
			// 
			// bClose
			// 
			this.bClose.Location = new System.Drawing.Point(248, 80);
			this.bClose.Name = "bClose";
			this.bClose.TabIndex = 5;
			this.bClose.Text = "&Close";
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// bStep
			// 
			this.bStep.Location = new System.Drawing.Point(168, 80);
			this.bStep.Name = "bStep";
			this.bStep.Size = new System.Drawing.Size(72, 24);
			this.bStep.TabIndex = 4;
			this.bStep.Text = "Ste&p";
			this.bStep.Click += new System.EventHandler(this.bStep_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(64, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Speed";
			// 
			// trbSpeed
			// 
			this.trbSpeed.BackColor = System.Drawing.Color.RoyalBlue;
			this.trbSpeed.Location = new System.Drawing.Point(8, 8);
			this.trbSpeed.Maximum = 30;
			this.trbSpeed.Minimum = 1;
			this.trbSpeed.Name = "trbSpeed";
			this.trbSpeed.Size = new System.Drawing.Size(232, 45);
			this.trbSpeed.TabIndex = 2;
			this.trbSpeed.Value = 10;
			this.trbSpeed.Scroll += new System.EventHandler(this.trbSpeed_Scroll);
			// 
			// bPlay
			// 
			this.bPlay.Location = new System.Drawing.Point(8, 80);
			this.bPlay.Name = "bPlay";
			this.bPlay.TabIndex = 1;
			this.bPlay.Text = "&Play";
			this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
			// 
			// bStop
			// 
			this.bStop.Location = new System.Drawing.Point(88, 80);
			this.bStop.Name = "bStop";
			this.bStop.TabIndex = 0;
			this.bStop.Text = "&Stop";
			this.bStop.Click += new System.EventHandler(this.bStop_Click);
			// 
			// pbWorld
			// 
			this.pbWorld.BackColor = System.Drawing.Color.Tan;
			this.pbWorld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbWorld.Location = new System.Drawing.Point(8, 8);
			this.pbWorld.Name = "pbWorld";
			this.pbWorld.Size = new System.Drawing.Size(400, 400);
			this.pbWorld.TabIndex = 1;
			this.pbWorld.TabStop = false;
			this.pbWorld.Resize += new System.EventHandler(this.pbWorld_Resize);
			this.pbWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.pbWorld_Paint);
			// 
			// lbNeuronDetails
			// 
			this.lbNeuronDetails.Location = new System.Drawing.Point(416, 8);
			this.lbNeuronDetails.Name = "lbNeuronDetails";
			this.lbNeuronDetails.Size = new System.Drawing.Size(144, 511);
			this.lbNeuronDetails.TabIndex = 2;
			// 
			// timerNetThink
			// 
			this.timerNetThink.Interval = 1;
			this.timerNetThink.Tick += new System.EventHandler(this.timerNetThink_Tick);
			// 
			// tbStoredEnergy
			// 
			this.tbStoredEnergy.Location = new System.Drawing.Point(336, 432);
			this.tbStoredEnergy.Name = "tbStoredEnergy";
			this.tbStoredEnergy.Size = new System.Drawing.Size(72, 20);
			this.tbStoredEnergy.TabIndex = 3;
			this.tbStoredEnergy.Text = "";
			// 
			// lblStoredEnergy
			// 
			this.lblStoredEnergy.Location = new System.Drawing.Point(336, 416);
			this.lblStoredEnergy.Name = "lblStoredEnergy";
			this.lblStoredEnergy.Size = new System.Drawing.Size(80, 16);
			this.lblStoredEnergy.TabIndex = 4;
			this.lblStoredEnergy.Text = "Stored Energy";
			// 
			// bExpand
			// 
			this.bExpand.Location = new System.Drawing.Point(336, 464);
			this.bExpand.Name = "bExpand";
			this.bExpand.TabIndex = 5;
			this.bExpand.Text = "Expand";
			this.bExpand.Click += new System.EventHandler(this.bExpand_Click);
			// 
			// fmTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(416, 526);
			this.Controls.Add(this.bExpand);
			this.Controls.Add(this.lblStoredEnergy);
			this.Controls.Add(this.tbStoredEnergy);
			this.Controls.Add(this.lbNeuronDetails);
			this.Controls.Add(this.pnlButtons);
			this.Controls.Add(this.pbWorld);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "fmTest";
			this.Text = "Test Network";
			this.pnlButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		//On Click events
		private void bClose_Click(object sender, System.EventArgs e)
		{
			//Clear all Neuronal activity
			fmMain.currentNetwork.Reset();
			//Reset the creatures 'hunger'
			storedEnergy = 0;
			//After Reset, this will change all NeuronButtons back to the normal color
			((fmEdit)editFormHandle).ShowFiringNeurons();
			this.Visible = false;
			ResetWorld();
		}

		private void bPlay_Click(object sender, System.EventArgs e)
		{
			timerNetThink.Interval = 1000/trbSpeed.Value;
			this.bClose.Enabled = false;
			timerNetThink.Enabled = true;
			timerNetThink.Start();
		}
		private void bStop_Click(object sender, System.EventArgs e)
		{
			this.bClose.Enabled = true;
			timerNetThink.Stop();
			timerNetThink.Enabled = false;
		}
		private void bShowSenses_Click(object sender, System.EventArgs e)
		{
			verbose = true;
			if (IsFoodLeft(20)>0)
			{
				MessageBox.Show(this, "Found food Left!", "Found", MessageBoxButtons.OK);
			}
			verbose = true;
			if (IsFoodRight(20)>0)
			{
				MessageBox.Show(this, "Found food Right!", "Found", MessageBoxButtons.OK);
			}
			verbose = true;
			if (IsFoodUp(20)>0)
			{
				MessageBox.Show(this, "Found food Up!", "Found", MessageBoxButtons.OK);
			}
			verbose = true;
			if (IsFoodDown(20)>0)
			{
				MessageBox.Show(this, "Found food Down!", "Found", MessageBoxButtons.OK);
			}		
		}

		private void bStep_Click(object sender, System.EventArgs e)
		{
			processOneCycle();
		}
		//This creates all the "Things" in the world
		private void pbWorld_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{			
			Graphics worldPanelGraphicsObject = e.Graphics;
			System.Drawing.SolidBrush CreatureFillBrush = new SolidBrush(System.Drawing.Color.White);
			//Display each worldObject on the World panel
			foreach(WorldObject thisWorldObject in listOfWorldObjects)
			{
				worldPanelGraphicsObject.DrawEllipse(new Pen(thisWorldObject.ObjectColor,2),
					thisWorldObject.Location.X - 1, thisWorldObject.Location.Y - 1, 2, 2);					
			}
			//Display the creature
			worldPanelGraphicsObject.DrawEllipse(new Pen(Color.White,2),
				creaturePosition.X - creatureSize/2, creaturePosition.Y - creatureSize/2,
				creatureSize, creatureSize);
			worldPanelGraphicsObject.FillEllipse(CreatureFillBrush,
				creaturePosition.X - creatureSize/2, creaturePosition.Y - creatureSize/2,
				creatureSize, creatureSize);

			tbStoredEnergy.Text = storedEnergy.ToString();
		}	
		private void pbWorld_Resize(object sender, System.EventArgs e)
		{
			pbWorld.Invalidate();
		}
		//Misc. Methods
		private void PopulatelistOfWorldObjects()
		{
			randomNumber = new Random();
			listOfWorldObjects.Clear();

			//Add in food based on the size of the world
			for (int i = 1; i < (SizeOfWorld/2); i++)
			{
				tempWorldObject = new WorldObject();
				tempWorldObject.ObjectName = "Food";
				tempWorldObject.ObjectColor = Color.Green;
				tempWorldObject.Location = new Point(randomNumber.Next(SizeOfWorld),
					randomNumber.Next(SizeOfWorld));
				listOfWorldObjects.Add(tempWorldObject);
			}
			//Add in obstacles based on the size of the world
			for (int i = 1; i < (SizeOfWorld/2); i++)
			{
				tempWorldObject = new WorldObject();
				tempWorldObject.ObjectName = "Obstacle";
				tempWorldObject.ObjectColor = Color.Blue;
				tempWorldObject.Location = new Point(randomNumber.Next(SizeOfWorld),
					randomNumber.Next(SizeOfWorld));
				listOfWorldObjects.Add(tempWorldObject);
			}
		}

		//Network interface Methods
		public static int SensoryNetworkInterface(int methodNumber, int parameter)
		{
			switch(methodNumber)
			{
				case 0:
					return IsFoodLeft(parameter);
				case 1:
					return IsFoodRight(parameter);
				case 2:
					return IsFoodUp(parameter);
				case 3:
					return IsFoodDown(parameter);
				case 4:
					return EatFood(parameter);
				case 5:
					return IsHungry(parameter);
				case 6:
					return DidNotMove();
				default:
					return 0;
			}
		}
		public static void MotorNetworkInterface(int methodNumber, int parameter)
		{
			switch(methodNumber)
			{
				case 0:
					MoveCreatureLeft(parameter);
					break;
				case 1:
					MoveCreatureRight(parameter);
					break;
				case 2:
					MoveCreatureUp(parameter);
					break;
				case 3:
					MoveCreatureDown(parameter);
					break;
				default:
					return;
			}
		}
		private static int IsFoodLeft(int detectDistance)
		{
			#region build border that should be checked for food.
			GraphicsPath sensoryBorder = new GraphicsPath();
			sensoryBorder.StartFigure();
			sensoryBorder.AddPie((creaturePosition.X - detectDistance), (creaturePosition.Y - detectDistance),
				detectDistance*2, detectDistance*2, 135, 90);
			sensoryBorder.CloseFigure();
			#endregion

			if(verbose)
				worldPanelGraphicsObject.DrawPath(new Pen(Color.Red,2),sensoryBorder);
			//Check each WorldObject to see if it is in the Sensory area
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Green))
				{
					if (sensoryBorder.IsVisible(tempWorldObject.Location))
					{
						return 10000;
					}
				}
			}
			verbose = false;
			return 0;
		}
		private static int IsFoodRight(int detectDistance)
		{
			#region build border that should be checked for food.
			GraphicsPath sensoryBorder = new GraphicsPath();
			sensoryBorder.StartFigure();
			sensoryBorder.AddPie((creaturePosition.X - detectDistance), (creaturePosition.Y - detectDistance),
				detectDistance*2, detectDistance*2, 315, 90);
			sensoryBorder.CloseFigure();
			#endregion

			if(verbose)
				worldPanelGraphicsObject.DrawPath(new Pen(Color.Red,2),sensoryBorder);
			//Check each WorldObject to see if it is in the Sensory area
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Green))
				{
					if (sensoryBorder.IsVisible(tempWorldObject.Location))
					{
						return 100000;
					}
				}
			}	
			verbose = false;
			return 0;
		}

		private static int IsFoodUp(int detectDistance)
		{
			#region build border that should be checked for food.
			GraphicsPath sensoryBorder = new GraphicsPath();
			sensoryBorder.StartFigure();
			sensoryBorder.AddPie((creaturePosition.X - detectDistance), (creaturePosition.Y - detectDistance),
				detectDistance*2, detectDistance*2, 225, 90);
			sensoryBorder.CloseFigure();
			#endregion

			if(verbose)
				worldPanelGraphicsObject.DrawPath(new Pen(Color.Red,2),sensoryBorder);
			//Check each WorldObject to see if it is in the Sensory area
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Green))
				{
					if (sensoryBorder.IsVisible(tempWorldObject.Location))
					{
						return 100000;
					}
				}
			}
			verbose = false;
			return 0;
		}
		private static int IsFoodDown(int detectDistance)
		{
			#region build border that should be checked for food.
			GraphicsPath sensoryBorder = new GraphicsPath();
			sensoryBorder.StartFigure();
			sensoryBorder.AddPie((creaturePosition.X - detectDistance), (creaturePosition.Y - detectDistance),
				detectDistance*2, detectDistance*2, 45, 90);
			sensoryBorder.CloseFigure();
			#endregion

			if(verbose)
				worldPanelGraphicsObject.DrawPath(new Pen(Color.Red,2),sensoryBorder);
			//Check each WorldObject to see if it is in the Sensory area
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Green))
				{
					if (sensoryBorder.IsVisible(tempWorldObject.Location))
					{
						return 100000;
					}
				}
			}
			verbose = false;
			return 0;
		}
		private static void MoveCreatureLeft(int distance)
		{
			//Move the creature
			creaturePosition.X -= distance;
			#region build border that should be checked for food.
			GraphicsPath creatureBody = new GraphicsPath();
			creatureBody.StartFigure();
			creatureBody.AddEllipse((creaturePosition.X - creatureSize/2), (creaturePosition.Y - creatureSize/2),
				creatureSize, creatureSize);
			creatureBody.CloseFigure();
			#endregion
			//If any inedible object is in the way, move the creature back
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Blue))
				{
					if (creatureBody.IsVisible(tempWorldObject.Location))
					{
						creaturePosition.X += distance;
					}
				}
			}
			return;
		}
		private static void MoveCreatureRight(int distance)
		{
			//Move the creature
			creaturePosition.X += distance;

			#region build border that should be checked for food.
			GraphicsPath creatureBody = new GraphicsPath();
			creatureBody.StartFigure();
			creatureBody.AddEllipse((creaturePosition.X - creatureSize/2), (creaturePosition.Y - creatureSize/2),
				creatureSize, creatureSize);
			creatureBody.CloseFigure();
			#endregion
			//If any inedible object is in the way, move the creature back
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Blue))
				{
					if (creatureBody.IsVisible(tempWorldObject.Location))
					{
						creaturePosition.X -= distance;
					}
				}
			}
			return;

		}
		private static void MoveCreatureUp(int distance)
		{
			//Move the creature
			creaturePosition.Y -= distance;
			#region build border that should be checked for food.
			GraphicsPath creatureBody = new GraphicsPath();
			creatureBody.StartFigure();
			creatureBody.AddEllipse((creaturePosition.X - creatureSize/2), (creaturePosition.Y - creatureSize/2),
				creatureSize, creatureSize);
			creatureBody.CloseFigure();
			#endregion
			//If any inedible object is in the way, move the creature back
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Blue))
				{
					if (creatureBody.IsVisible(tempWorldObject.Location))
					{
						creaturePosition.Y += distance;
					}
				}
			}
			return;
		}
		private static void MoveCreatureDown(int distance)
		{
			//Move the creature
			creaturePosition.Y += distance;
			#region build border that should be checked for food.
			GraphicsPath creatureBody = new GraphicsPath();
			creatureBody.StartFigure();
			creatureBody.AddEllipse((creaturePosition.X - creatureSize/2), (creaturePosition.Y - creatureSize/2),
				creatureSize, creatureSize);
			creatureBody.CloseFigure();
			#endregion
			//If any inedible object is in the way, move the creature back
			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (tempWorldObject.ObjectColor.Equals(Color.Blue))
				{
					if (creatureBody.IsVisible(tempWorldObject.Location))
					{
						creaturePosition.Y -= distance;
					}
				}
			}
			return;
		}

		private static int EatFood(int reach)
		{
			Rectangle creaturesBodyArea = new Rectangle((creaturePosition.X - creatureSize/2),
				(creaturePosition.Y - creatureSize/2), creatureSize, creatureSize);

			foreach(WorldObject tempWorldObject in listOfWorldObjects)
			{
				if (creaturesBodyArea.Contains(tempWorldObject.Location)
					&& (tempWorldObject.ObjectColor == Color.Green))
				{
					listOfWorldObjects.Remove(tempWorldObject);
					//MessageBox.Show("I just ate something.", "Yum!", MessageBoxButtons.OK);
					storedEnergy += 100;
					return 100;
				}				
			}
			return 0;
		}

		private static int IsHungry(int consumed)
		{
			storedEnergy -= consumed;
			if (storedEnergy < -1000)
			{
				fmMain.currentNetwork.Reset();
				storedEnergy = 0;
				MessageBox.Show("Your creature is DEAD!", "AACKH", MessageBoxButtons.OK);
			}
			if (storedEnergy < 0)
			{
				return 100;
			}

			return 0;
		}
		private static int DidNotMove()
		{
			if(lastCreaturePosition == creaturePosition)
			{
				return 100;
			}
			else
			{
				lastCreaturePosition = creaturePosition;
				return 0;
			}
		}

		private void timerNetThink_Tick(object sender, System.EventArgs e)
		{
			processOneCycle();
		}

		private void trbSpeed_Scroll(object sender, System.EventArgs e)
		{
			timerNetThink.Interval = 1000/trbSpeed.Value;
		}

		private void processOneCycle()
		{
			++ticksSinceStart;
			fmMain.currentNetwork.Think();
			//Add a new piece of food to the world
			if(ticksSinceStart % 100 == 0)
			{
				tempWorldObject = new WorldObject();
				tempWorldObject.ObjectName = "Food";
				tempWorldObject.ObjectColor = Color.Green;
				tempWorldObject.Location = new Point(randomNumber.Next(SizeOfWorld),
					randomNumber.Next(SizeOfWorld));
				listOfWorldObjects.Add(tempWorldObject);
			}
			//Repaint the world
			pbWorld.Invalidate();
			this.lbNeuronDetails.Items.Clear();
			this.lbNeuronDetails.Items.AddRange(fmMain.currentNetwork.ListNeurons().ToArray());

			try
			{
			((fmEdit)editFormHandle).ShowFiringNeurons();
			}
			catch (Exception except)
			{
				MessageBox.Show(this, except.ToString(), "Error", MessageBoxButtons.OK);
			}
			return;
		}

		private void bExpand_Click(object sender, System.EventArgs e)
		{
			if (bExpand.Text == "Expand")
			{
				this.Width = 576;
				bExpand.Text = "Contract";
			}
			else
			{
				this.Width = 424;
				bExpand.Text = "Expand";
			}
		}

		private void ResetWorld()
		{
			fmMain.sensoryMethodsList.Clear();
			fmMain.motorMethodsList.Clear();
			PopulatelistOfWorldObjects();
			creaturePosition = new Point(SizeOfWorld/2, SizeOfWorld/2);
			lastCreaturePosition = creaturePosition;
			worldPanelGraphicsObject = Graphics.FromHwnd(this.pbWorld.Handle);
			this.lbNeuronDetails.Items.AddRange(fmMain.currentNetwork.ListNeurons().ToArray());
			fmMain.sensoryMethodsList.AddRange(new String[]
					{"IsFoodLeft", "IsFoodRight", "IsFoodUp", "IsFoodDown",
						"EatFood", "IsHungry", "DidNotMove"});
			fmMain.motorMethodsList.AddRange(new String[]
					{"MoveCreatureLeft", "MoveCreatureRight", "MoveCreatureUp", "MoveCreatureDown"});

		}
	}
}
