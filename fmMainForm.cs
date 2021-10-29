using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for fmMain.
	/// </summary>
	public class fmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnl1MainForm;
		private System.Windows.Forms.PictureBox pb1MainForm;
		private System.Windows.Forms.Button bLoadSave;
		private System.Windows.Forms.Button bTestNetwork;
		private System.Windows.Forms.Button bEditNetwork;
		private System.Windows.Forms.Label lblMainMenu;
		private System.Windows.Forms.Label lblNeuralNetworkSimulator;
		private System.Windows.Forms.Form ifmLoadSave;
		private System.Windows.Forms.Button bExit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmMain));
			this.pnl1MainForm = new System.Windows.Forms.Panel();
			this.lblNeuralNetworkSimulator = new System.Windows.Forms.Label();
			this.lblMainMenu = new System.Windows.Forms.Label();
			this.bEditNetwork = new System.Windows.Forms.Button();
			this.bTestNetwork = new System.Windows.Forms.Button();
			this.bLoadSave = new System.Windows.Forms.Button();
			this.pb1MainForm = new System.Windows.Forms.PictureBox();
			this.bExit = new System.Windows.Forms.Button();
			this.pnl1MainForm.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnl1MainForm
			// 
			this.pnl1MainForm.BackColor = System.Drawing.Color.LightGray;
			this.pnl1MainForm.Controls.Add(this.bExit);
			this.pnl1MainForm.Controls.Add(this.lblNeuralNetworkSimulator);
			this.pnl1MainForm.Controls.Add(this.lblMainMenu);
			this.pnl1MainForm.Controls.Add(this.bEditNetwork);
			this.pnl1MainForm.Controls.Add(this.bTestNetwork);
			this.pnl1MainForm.Controls.Add(this.bLoadSave);
			this.pnl1MainForm.Location = new System.Drawing.Point(328, 0);
			this.pnl1MainForm.Name = "pnl1MainForm";
			this.pnl1MainForm.Size = new System.Drawing.Size(208, 408);
			this.pnl1MainForm.TabIndex = 0;
			// 
			// lblNeuralNetworkSimulator
			// 
			this.lblNeuralNetworkSimulator.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblNeuralNetworkSimulator.Font = new System.Drawing.Font("Amery", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNeuralNetworkSimulator.Location = new System.Drawing.Point(0, 0);
			this.lblNeuralNetworkSimulator.Name = "lblNeuralNetworkSimulator";
			this.lblNeuralNetworkSimulator.Size = new System.Drawing.Size(208, 96);
			this.lblNeuralNetworkSimulator.TabIndex = 4;
			this.lblNeuralNetworkSimulator.Text = "Neural Network Simulator";
			this.lblNeuralNetworkSimulator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMainMenu
			// 
			this.lblMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMainMenu.Location = new System.Drawing.Point(24, 112);
			this.lblMainMenu.Name = "lblMainMenu";
			this.lblMainMenu.Size = new System.Drawing.Size(160, 40);
			this.lblMainMenu.TabIndex = 0;
			this.lblMainMenu.Text = "Main Menu";
			this.lblMainMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bEditNetwork
			// 
			this.bEditNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bEditNetwork.Location = new System.Drawing.Point(40, 224);
			this.bEditNetwork.Name = "bEditNetwork";
			this.bEditNetwork.Size = new System.Drawing.Size(128, 48);
			this.bEditNetwork.TabIndex = 1;
			this.bEditNetwork.Text = "Edit Network";
			// 
			// bTestNetwork
			// 
			this.bTestNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bTestNetwork.Location = new System.Drawing.Point(40, 288);
			this.bTestNetwork.Name = "bTestNetwork";
			this.bTestNetwork.Size = new System.Drawing.Size(128, 48);
			this.bTestNetwork.TabIndex = 2;
			this.bTestNetwork.Text = "Test Network";
			// 
			// bLoadSave
			// 
			this.bLoadSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bLoadSave.Location = new System.Drawing.Point(40, 160);
			this.bLoadSave.Name = "bLoadSave";
			this.bLoadSave.Size = new System.Drawing.Size(128, 48);
			this.bLoadSave.TabIndex = 0;
			this.bLoadSave.Text = "Load / Save";
			this.bLoadSave.Click += new System.EventHandler(this.bLoadSave_Click);
			// 
			// pb1MainForm
			// 
			this.pb1MainForm.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.pb1MainForm.Image = ((System.Drawing.Image)(resources.GetObject("pb1MainForm.Image")));
			this.pb1MainForm.Location = new System.Drawing.Point(0, 0);
			this.pb1MainForm.Name = "pb1MainForm";
			this.pb1MainForm.Size = new System.Drawing.Size(328, 408);
			this.pb1MainForm.TabIndex = 1;
			this.pb1MainForm.TabStop = false;
			// 
			// bExit
			// 
			this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bExit.Location = new System.Drawing.Point(64, 352);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(80, 40);
			this.bExit.TabIndex = 5;
			this.bExit.Text = "Exit";
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// fmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Gray;
			this.ClientSize = new System.Drawing.Size(534, 404);
			this.Controls.Add(this.pb1MainForm);
			this.Controls.Add(this.pnl1MainForm);
			this.ForeColor = System.Drawing.Color.Blue;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "fmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Neural Network Simulator";
			this.pnl1MainForm.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new fmMain());
		}

		private void bLoadSave_Click(object sender, System.EventArgs e)
		{
			ifmLoadSave = new fmLoadSave();
			ifmLoadSave.Activate();
			ifmLoadSave.ShowDialog();
		}

		private void bExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

	}
}
