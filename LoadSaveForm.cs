using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for LoadSaveForm.
	/// </summary>
	public class fmLoadSave : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bLoad;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.OpenFileDialog ofdLoad;
		private System.Windows.Forms.Button bMainMenu;
		private System.Windows.Forms.SaveFileDialog sfdSave;
		private System.Windows.Forms.Label lblLoadedNetworkNamePath;
		private System.Windows.Forms.Label lblNetworkName;
		private System.Windows.Forms.Label lblLoadedNetworkName;
		private System.Windows.Forms.Label lblFilePath;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmLoadSave()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmLoadSave));
			this.bLoad = new System.Windows.Forms.Button();
			this.bSave = new System.Windows.Forms.Button();
			this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
			this.lblLoadedNetworkNamePath = new System.Windows.Forms.Label();
			this.bMainMenu = new System.Windows.Forms.Button();
			this.sfdSave = new System.Windows.Forms.SaveFileDialog();
			this.lblNetworkName = new System.Windows.Forms.Label();
			this.lblLoadedNetworkName = new System.Windows.Forms.Label();
			this.lblFilePath = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bLoad
			// 
			this.bLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bLoad.Location = new System.Drawing.Point(16, 56);
			this.bLoad.Name = "bLoad";
			this.bLoad.Size = new System.Drawing.Size(136, 32);
			this.bLoad.TabIndex = 0;
			this.bLoad.Text = "&Load Network";
			this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
			// 
			// bSave
			// 
			this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bSave.Location = new System.Drawing.Point(208, 56);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(136, 32);
			this.bSave.TabIndex = 1;
			this.bSave.Text = "&Save Network";
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// ofdLoad
			// 
			this.ofdLoad.DefaultExt = "nt";
			this.ofdLoad.Filter = "Network Files | *.nt|All Files | *.*";
			this.ofdLoad.InitialDirectory = "net files";
			this.ofdLoad.RestoreDirectory = true;
			this.ofdLoad.Title = "Load File";
			this.ofdLoad.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdLoad_FileOk);
			// 
			// lblLoadedNetworkNamePath
			// 
			this.lblLoadedNetworkNamePath.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblLoadedNetworkNamePath.Location = new System.Drawing.Point(64, 120);
			this.lblLoadedNetworkNamePath.Name = "lblLoadedNetworkNamePath";
			this.lblLoadedNetworkNamePath.Size = new System.Drawing.Size(288, 40);
			this.lblLoadedNetworkNamePath.TabIndex = 3;
			// 
			// bMainMenu
			// 
			this.bMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bMainMenu.Location = new System.Drawing.Point(256, 192);
			this.bMainMenu.Name = "bMainMenu";
			this.bMainMenu.Size = new System.Drawing.Size(88, 40);
			this.bMainMenu.TabIndex = 4;
			this.bMainMenu.Text = "&Main Menu";
			this.bMainMenu.Click += new System.EventHandler(this.bMainMenu_Click);
			// 
			// sfdSave
			// 
			this.sfdSave.DefaultExt = "nt";
			this.sfdSave.Filter = "Network Files | *.nt|All Files | *.*";
			this.sfdSave.InitialDirectory = "net files";
			this.sfdSave.RestoreDirectory = true;
			this.sfdSave.Title = "Save File";
			this.sfdSave.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdSave_FileOk);
			// 
			// lblNetworkName
			// 
			this.lblNetworkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNetworkName.Location = new System.Drawing.Point(8, 16);
			this.lblNetworkName.Name = "lblNetworkName";
			this.lblNetworkName.Size = new System.Drawing.Size(120, 16);
			this.lblNetworkName.TabIndex = 5;
			this.lblNetworkName.Text = "Current Network Name";
			// 
			// lblLoadedNetworkName
			// 
			this.lblLoadedNetworkName.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblLoadedNetworkName.Location = new System.Drawing.Point(128, 16);
			this.lblLoadedNetworkName.Name = "lblLoadedNetworkName";
			this.lblLoadedNetworkName.Size = new System.Drawing.Size(224, 16);
			this.lblLoadedNetworkName.TabIndex = 6;
			// 
			// lblFilePath
			// 
			this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFilePath.Location = new System.Drawing.Point(8, 120);
			this.lblFilePath.Name = "lblFilePath";
			this.lblFilePath.Size = new System.Drawing.Size(56, 16);
			this.lblFilePath.TabIndex = 7;
			this.lblFilePath.Text = "File Path";
			// 
			// fmLoadSave
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.CornflowerBlue;
			this.ClientSize = new System.Drawing.Size(358, 244);
			this.Controls.Add(this.lblFilePath);
			this.Controls.Add(this.lblLoadedNetworkName);
			this.Controls.Add(this.lblNetworkName);
			this.Controls.Add(this.bMainMenu);
			this.Controls.Add(this.lblLoadedNetworkNamePath);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.bLoad);
			this.ForeColor = System.Drawing.Color.DarkBlue;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "fmLoadSave";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Load / Save";
			this.Load += new System.EventHandler(this.fmLoadSave_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void bLoad_Click(object sender, System.EventArgs e)
		{
			if (ofdLoad.ShowDialog(this) == DialogResult.OK)
			{
				this.Close();
			}
		}

		private void bSave_Click(object sender, System.EventArgs e)
		{
			if (sfdSave.ShowDialog(this) == DialogResult.OK)
			{
				this.Close();
			}
		}

		private void bMainMenu_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ofdLoad_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Clear out the current Network
			fmMain.currentNetwork.Clear();
			fmMain.currentNetworkDisplayList.Clear();
			try
			{
				Stream loadStream = null;
				if((loadStream = ofdLoad.OpenFile()) != null)
				{
					BinaryFormatter loadBinaryFormat = new BinaryFormatter();
					fmMain.currentNetwork = (Network)loadBinaryFormat.Deserialize(loadStream);
					loadStream.Close();
				}
				//".nt" is added to the Network file, ".nti" represents the info file.
				ofdLoad.FileName += "i";
				if((loadStream = ofdLoad.OpenFile()) != null)
				{
					BinaryFormatter loadBinaryFormat = new BinaryFormatter();
					fmMain.currentNetworkDisplayList = (ArrayList)loadBinaryFormat.Deserialize(loadStream);
					loadStream.Close();
				}
				lblLoadedNetworkName.Text = fmMain.currentNetwork.Name;
				lblLoadedNetworkNamePath.Text = ofdLoad.FileName;
			}
			catch (Exception except)
			{
				MessageBox.Show(this, except.Message, "Error", MessageBoxButtons.OK);
			}
		}

		private void sfdSave_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Stream saveStream = null;
			if((saveStream = sfdSave.OpenFile()) != null)
			{
				BinaryFormatter saveBinaryFormat = new BinaryFormatter();
				saveBinaryFormat.Serialize(saveStream, fmMain.currentNetwork);
				saveStream.Close();
			}
			//".nt" is added to the Network file, ".nti" represents the info file.
			sfdSave.FileName += "i";
			if((saveStream = sfdSave.OpenFile()) != null)
			{
				BinaryFormatter saveBinaryFormat = new BinaryFormatter();
				saveBinaryFormat.Serialize(saveStream, fmMain.currentNetworkDisplayList);
				saveStream.Close();
			}

		}

		private void fmLoadSave_Load(object sender, System.EventArgs e)
		{
			lblLoadedNetworkName.Text = fmMain.currentNetwork.Name;
		}
	}
}
