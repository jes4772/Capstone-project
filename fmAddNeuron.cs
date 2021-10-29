using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for fmAddNeuron.
	/// </summary>
	public class fmAddNeuron : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlAddNeuron;
		private System.Windows.Forms.Button bAddToNetwork;
		private System.Windows.Forms.Label lblReleases;
		private System.Windows.Forms.Label lblFiresOn;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox tbReleases;
		private System.Windows.Forms.TextBox tbFiresOn;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Button bCancel;
		//TODO: may need to remove
		private int indexOfNewNeuron;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmAddNeuron()
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
			this.pnlAddNeuron = new System.Windows.Forms.Panel();
			this.bAddToNetwork = new System.Windows.Forms.Button();
			this.lblReleases = new System.Windows.Forms.Label();
			this.lblFiresOn = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.tbReleases = new System.Windows.Forms.TextBox();
			this.tbFiresOn = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.bCancel = new System.Windows.Forms.Button();
			this.pnlAddNeuron.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlAddNeuron
			// 
			this.pnlAddNeuron.BackColor = System.Drawing.Color.CornflowerBlue;
			this.pnlAddNeuron.Controls.Add(this.bAddToNetwork);
			this.pnlAddNeuron.Controls.Add(this.lblReleases);
			this.pnlAddNeuron.Controls.Add(this.lblFiresOn);
			this.pnlAddNeuron.Controls.Add(this.lblName);
			this.pnlAddNeuron.Controls.Add(this.tbReleases);
			this.pnlAddNeuron.Controls.Add(this.tbFiresOn);
			this.pnlAddNeuron.Controls.Add(this.tbName);
			this.pnlAddNeuron.Controls.Add(this.bCancel);
			this.pnlAddNeuron.Location = new System.Drawing.Point(0, 0);
			this.pnlAddNeuron.Name = "pnlAddNeuron";
			this.pnlAddNeuron.Size = new System.Drawing.Size(184, 184);
			this.pnlAddNeuron.TabIndex = 2;
			// 
			// bAddToNetwork
			// 
			this.bAddToNetwork.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAddToNetwork.Location = new System.Drawing.Point(32, 104);
			this.bAddToNetwork.Name = "bAddToNetwork";
			this.bAddToNetwork.Size = new System.Drawing.Size(128, 23);
			this.bAddToNetwork.TabIndex = 6;
			this.bAddToNetwork.Text = "&Add To Network";
			this.bAddToNetwork.Click += new System.EventHandler(this.bAddToNetwork_Click);
			// 
			// lblReleases
			// 
			this.lblReleases.Location = new System.Drawing.Point(8, 80);
			this.lblReleases.Name = "lblReleases";
			this.lblReleases.Size = new System.Drawing.Size(56, 16);
			this.lblReleases.TabIndex = 5;
			this.lblReleases.Text = "Releases:";
			// 
			// lblFiresOn
			// 
			this.lblFiresOn.Location = new System.Drawing.Point(8, 48);
			this.lblFiresOn.Name = "lblFiresOn";
			this.lblFiresOn.Size = new System.Drawing.Size(56, 16);
			this.lblFiresOn.TabIndex = 4;
			this.lblFiresOn.Text = "Fires On:";
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(8, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(56, 16);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name:";
			// 
			// tbReleases
			// 
			this.tbReleases.Location = new System.Drawing.Point(72, 72);
			this.tbReleases.MaxLength = 10;
			this.tbReleases.Name = "tbReleases";
			this.tbReleases.TabIndex = 2;
			this.tbReleases.Text = "";
			// 
			// tbFiresOn
			// 
			this.tbFiresOn.Location = new System.Drawing.Point(72, 40);
			this.tbFiresOn.MaxLength = 10;
			this.tbFiresOn.Name = "tbFiresOn";
			this.tbFiresOn.TabIndex = 1;
			this.tbFiresOn.Text = "";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(72, 8);
			this.tbName.MaxLength = 50;
			this.tbName.Name = "tbName";
			this.tbName.TabIndex = 0;
			this.tbName.Text = "";
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(56, 144);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 3;
			this.bCancel.Text = "&Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// fmAddNeuron
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(184, 174);
			this.Controls.Add(this.pnlAddNeuron);
			this.Name = "fmAddNeuron";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Neuron";
			this.pnlAddNeuron.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void bAddToNetwork_Click(object sender, System.EventArgs e)
		{
			int newFiresOn, newReleases;
			Neuron newNeuron;

			newNeuron = new Neuron();

			#region Validate user input
			//Check edit boxes for good data.
			if (tbName.TextLength == 0)
			{
				MessageBox.Show(this, "You did not enter a name.", "Name missing", 
					MessageBoxButtons.OK);
				tbName.Focus();
				//TODO: stop ModelOK return
				return;
			}

			try
			{
				newFiresOn = System.Convert.ToInt32(tbFiresOn.Text);
			}
			catch
			{
				MessageBox.Show(this, "'Fires On' must be an integer value.",
					"'Fires On' value is invalid", MessageBoxButtons.OK);
				tbFiresOn.Focus();
				return;
			}

			try
			{
				newReleases = System.Convert.ToInt32(tbReleases.Text);
			}
			catch
			{
				MessageBox.Show(this, "'Releases' must be an integer value.",
					"'Releases' value is invalid", MessageBoxButtons.OK);
				tbFiresOn.Focus();
				return;
			}
			#endregion

			//Add Neuron to Network
			newNeuron.Name = tbName.Text;
			newNeuron.FiresOn = newFiresOn;
			newNeuron.Releases = newReleases;
			fmMain.currentNetwork.AddNeuron(newNeuron);
			
			this.Close();
		}

		private void bCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		//TODO: may need to remove
		public int GetIndexOfNewNeuron()
		{
			return indexOfNewNeuron;
		}

	}
}
