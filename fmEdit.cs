using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for fmEdit.
	/// </summary>
	public class fmEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlEditButtons;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bClose;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel pnlDisplay;
		private System.Windows.Forms.Panel pnlAddNeuron;
		private System.Windows.Forms.Label lblReleases;
		private System.Windows.Forms.Label lblFiresOn;
		private System.Windows.Forms.TextBox tbReleases;
		private System.Windows.Forms.TextBox tbFiresOn;
		private System.Windows.Forms.ListBox lbAttachmentList;
		private System.Windows.Forms.Label lblAttachments;
		private System.Windows.Forms.Button bTempNeuronButton;
		private System.Windows.Forms.Button bAddToNetwork;
		private System.Windows.Forms.Button bUpdateNeuron;
		private System.Windows.Forms.Button bEditNeuron;
		private System.Windows.Forms.Button bDeleteConnection;  //Holds the currently selected Neuron
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label lblNetworkName;
		private System.Windows.Forms.TextBox tbNetworkName;	//Holds the Neuron waiting to receive an attachment
		private System.Windows.Forms.Button bNewBaseNeuron;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Label lblStrength;
		private System.Windows.Forms.TextBox tbStrength;
		private System.Windows.Forms.Label lblNeuronName;
		private System.Windows.Forms.GroupBox gbDerivedAttributes;
		private System.Windows.Forms.Label lblLinkedMethod;
		private System.Windows.Forms.ComboBox cbTypeSelect;
		private System.Windows.Forms.ComboBox cbLinkedMethodSelect;
		private System.Windows.Forms.Button bNewDerivedNeuron;	//Holds the Neuron waiting to remove an attachment
		private NeuronIconInfo tempNeuronIconInfo;			
		private Neuron selectedNeuron;
		private System.Windows.Forms.Button selectedNeuronIcon;	//This is a handle to the Button that represents
																// the most recently clicked Neuron
		private Neuron creatingAttachmentNeuron = null;
		private Neuron deletingAttachmentNeuron = null;
		private int neuronIconSize = 50;
		private System.Drawing.Graphics displayPanelGraphics;
		private System.Windows.Forms.Button bDetailCancel;
		private System.Windows.Forms.Button bMainCancel;
		private System.Windows.Forms.Button bTestNetwork;
		private System.Windows.Forms.ToolTip ttDelConnectButton;
		private System.Windows.Forms.ToolTip ttTestNetworkButton;
		private System.Windows.Forms.ToolTip ttNewBaseNeuronButton;
		private System.Windows.Forms.ToolTip ttNewDerivedNeuronButton;
		private System.Windows.Forms.ToolTip ttEditNeuronButton;
		private System.Windows.Forms.ToolTip ttDeleteNeuronButton;
		private System.Collections.ArrayList currentAttachmentLine;
		
		public fmEdit()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//		
			displayPanelGraphics = Graphics.FromHwnd(this.pnlDisplay.Handle);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmEdit));
			this.pnlEditButtons = new System.Windows.Forms.Panel();
			this.bTestNetwork = new System.Windows.Forms.Button();
			this.bMainCancel = new System.Windows.Forms.Button();
			this.bNewDerivedNeuron = new System.Windows.Forms.Button();
			this.bDeleteConnection = new System.Windows.Forms.Button();
			this.bEditNeuron = new System.Windows.Forms.Button();
			this.bClose = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.bNewBaseNeuron = new System.Windows.Forms.Button();
			this.pnlAddNeuron = new System.Windows.Forms.Panel();
			this.bDetailCancel = new System.Windows.Forms.Button();
			this.tbNetworkName = new System.Windows.Forms.TextBox();
			this.lblNetworkName = new System.Windows.Forms.Label();
			this.lblAttachments = new System.Windows.Forms.Label();
			this.lbAttachmentList = new System.Windows.Forms.ListBox();
			this.lblReleases = new System.Windows.Forms.Label();
			this.lblFiresOn = new System.Windows.Forms.Label();
			this.lblNeuronName = new System.Windows.Forms.Label();
			this.tbReleases = new System.Windows.Forms.TextBox();
			this.tbFiresOn = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.bAddToNetwork = new System.Windows.Forms.Button();
			this.bUpdateNeuron = new System.Windows.Forms.Button();
			this.gbDerivedAttributes = new System.Windows.Forms.GroupBox();
			this.cbLinkedMethodSelect = new System.Windows.Forms.ComboBox();
			this.lblLinkedMethod = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.lblStrength = new System.Windows.Forms.Label();
			this.tbStrength = new System.Windows.Forms.TextBox();
			this.cbTypeSelect = new System.Windows.Forms.ComboBox();
			this.pnlDisplay = new System.Windows.Forms.Panel();
			this.ttDelConnectButton = new System.Windows.Forms.ToolTip(this.components);
			this.ttTestNetworkButton = new System.Windows.Forms.ToolTip(this.components);
			this.ttNewBaseNeuronButton = new System.Windows.Forms.ToolTip(this.components);
			this.ttNewDerivedNeuronButton = new System.Windows.Forms.ToolTip(this.components);
			this.ttEditNeuronButton = new System.Windows.Forms.ToolTip(this.components);
			this.ttDeleteNeuronButton = new System.Windows.Forms.ToolTip(this.components);
			this.pnlEditButtons.SuspendLayout();
			this.pnlAddNeuron.SuspendLayout();
			this.gbDerivedAttributes.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlEditButtons
			// 
			this.pnlEditButtons.BackColor = System.Drawing.Color.SkyBlue;
			this.pnlEditButtons.Controls.Add(this.bTestNetwork);
			this.pnlEditButtons.Controls.Add(this.bMainCancel);
			this.pnlEditButtons.Controls.Add(this.bNewDerivedNeuron);
			this.pnlEditButtons.Controls.Add(this.bDeleteConnection);
			this.pnlEditButtons.Controls.Add(this.bEditNeuron);
			this.pnlEditButtons.Controls.Add(this.bClose);
			this.pnlEditButtons.Controls.Add(this.bDelete);
			this.pnlEditButtons.Controls.Add(this.bNewBaseNeuron);
			this.pnlEditButtons.ForeColor = System.Drawing.Color.Blue;
			this.pnlEditButtons.Location = new System.Drawing.Point(0, 0);
			this.pnlEditButtons.Name = "pnlEditButtons";
			this.pnlEditButtons.Size = new System.Drawing.Size(248, 176);
			this.pnlEditButtons.TabIndex = 0;
			// 
			// bTestNetwork
			// 
			this.bTestNetwork.Location = new System.Drawing.Point(8, 96);
			this.bTestNetwork.Name = "bTestNetwork";
			this.bTestNetwork.Size = new System.Drawing.Size(112, 32);
			this.bTestNetwork.TabIndex = 8;
			this.bTestNetwork.Text = "Test Network";
			this.ttTestNetworkButton.SetToolTip(this.bTestNetwork, "Click to open a new test environment.");
			this.bTestNetwork.Click += new System.EventHandler(this.bTestNetwork_Click);
			// 
			// bMainCancel
			// 
			this.bMainCancel.Location = new System.Drawing.Point(128, 144);
			this.bMainCancel.Name = "bMainCancel";
			this.bMainCancel.Size = new System.Drawing.Size(64, 23);
			this.bMainCancel.TabIndex = 7;
			this.bMainCancel.Text = "Cancel";
			this.bMainCancel.Click += new System.EventHandler(this.bMainCancel_Click);
			// 
			// bNewDerivedNeuron
			// 
			this.bNewDerivedNeuron.Location = new System.Drawing.Point(8, 48);
			this.bNewDerivedNeuron.Name = "bNewDerivedNeuron";
			this.bNewDerivedNeuron.Size = new System.Drawing.Size(112, 32);
			this.bNewDerivedNeuron.TabIndex = 1;
			this.bNewDerivedNeuron.Text = "New Derived Neuron";
			this.ttNewDerivedNeuronButton.SetToolTip(this.bNewDerivedNeuron, "Click to create a new derived neuron.");
			this.bNewDerivedNeuron.Click += new System.EventHandler(this.bNewDerivedNeuron_Click);
			// 
			// bDeleteConnection
			// 
			this.bDeleteConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bDeleteConnection.Location = new System.Drawing.Point(128, 40);
			this.bDeleteConnection.Name = "bDeleteConnection";
			this.bDeleteConnection.Size = new System.Drawing.Size(112, 23);
			this.bDeleteConnection.TabIndex = 3;
			this.bDeleteConnection.Text = "De&lete Connection";
			this.ttDelConnectButton.SetToolTip(this.bDeleteConnection, "Click on a Neuron to which the Selected Neuron has a connection to remove the con" +
				"nection.");
			this.bDeleteConnection.Click += new System.EventHandler(this.bDeleteConnection_Click);
			// 
			// bEditNeuron
			// 
			this.bEditNeuron.Location = new System.Drawing.Point(128, 72);
			this.bEditNeuron.Name = "bEditNeuron";
			this.bEditNeuron.Size = new System.Drawing.Size(112, 23);
			this.bEditNeuron.TabIndex = 4;
			this.bEditNeuron.Text = "Edit Neuron";
			this.ttEditNeuronButton.SetToolTip(this.bEditNeuron, "Click to make the selected neuron editable.");
			this.bEditNeuron.Click += new System.EventHandler(this.bEditNeuron_Click);
			// 
			// bClose
			// 
			this.bClose.Location = new System.Drawing.Point(48, 144);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(64, 23);
			this.bClose.TabIndex = 6;
			this.bClose.Text = "&Close";
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// bDelete
			// 
			this.bDelete.AccessibleDescription = "";
			this.bDelete.Location = new System.Drawing.Point(128, 104);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(112, 23);
			this.bDelete.TabIndex = 5;
			this.bDelete.Text = "&Delete Neuron";
			this.ttDeleteNeuronButton.SetToolTip(this.bDelete, "Click to permanently delete the selected neuron.");
			this.bDelete.Click += new System.EventHandler(this.bDeleteNeuron_Click);
			// 
			// bNewBaseNeuron
			// 
			this.bNewBaseNeuron.BackColor = System.Drawing.Color.SkyBlue;
			this.bNewBaseNeuron.Location = new System.Drawing.Point(8, 8);
			this.bNewBaseNeuron.Name = "bNewBaseNeuron";
			this.bNewBaseNeuron.Size = new System.Drawing.Size(112, 32);
			this.bNewBaseNeuron.TabIndex = 0;
			this.bNewBaseNeuron.Text = "New &Base Neuron";
			this.ttNewBaseNeuronButton.SetToolTip(this.bNewBaseNeuron, "Click to create a new base neuron.");
			this.bNewBaseNeuron.Click += new System.EventHandler(this.bNewBaseNeuron_Click);
			// 
			// pnlAddNeuron
			// 
			this.pnlAddNeuron.BackColor = System.Drawing.Color.CornflowerBlue;
			this.pnlAddNeuron.Controls.Add(this.bDetailCancel);
			this.pnlAddNeuron.Controls.Add(this.tbNetworkName);
			this.pnlAddNeuron.Controls.Add(this.lblNetworkName);
			this.pnlAddNeuron.Controls.Add(this.lblAttachments);
			this.pnlAddNeuron.Controls.Add(this.lbAttachmentList);
			this.pnlAddNeuron.Controls.Add(this.lblReleases);
			this.pnlAddNeuron.Controls.Add(this.lblFiresOn);
			this.pnlAddNeuron.Controls.Add(this.lblNeuronName);
			this.pnlAddNeuron.Controls.Add(this.tbReleases);
			this.pnlAddNeuron.Controls.Add(this.tbFiresOn);
			this.pnlAddNeuron.Controls.Add(this.tbName);
			this.pnlAddNeuron.Controls.Add(this.bAddToNetwork);
			this.pnlAddNeuron.Controls.Add(this.bUpdateNeuron);
			this.pnlAddNeuron.Controls.Add(this.gbDerivedAttributes);
			this.pnlAddNeuron.Enabled = false;
			this.pnlAddNeuron.Location = new System.Drawing.Point(0, 176);
			this.pnlAddNeuron.Name = "pnlAddNeuron";
			this.pnlAddNeuron.Size = new System.Drawing.Size(248, 408);
			this.pnlAddNeuron.TabIndex = 4;
			// 
			// bDetailCancel
			// 
			this.bDetailCancel.Location = new System.Drawing.Point(80, 376);
			this.bDetailCancel.Name = "bDetailCancel";
			this.bDetailCancel.Size = new System.Drawing.Size(80, 23);
			this.bDetailCancel.TabIndex = 10;
			this.bDetailCancel.Text = "Cancel";
			this.bDetailCancel.Click += new System.EventHandler(this.bDetailCancel_Click);
			// 
			// tbNetworkName
			// 
			this.tbNetworkName.Location = new System.Drawing.Point(128, 24);
			this.tbNetworkName.Name = "tbNetworkName";
			this.tbNetworkName.Size = new System.Drawing.Size(112, 20);
			this.tbNetworkName.TabIndex = 0;
			this.tbNetworkName.Text = "";
			this.tbNetworkName.Leave += new System.EventHandler(this.tbNetworkName_Leave);
			// 
			// lblNetworkName
			// 
			this.lblNetworkName.Location = new System.Drawing.Point(128, 8);
			this.lblNetworkName.Name = "lblNetworkName";
			this.lblNetworkName.Size = new System.Drawing.Size(112, 16);
			this.lblNetworkName.TabIndex = 9;
			this.lblNetworkName.Text = "Network Name";
			// 
			// lblAttachments
			// 
			this.lblAttachments.Location = new System.Drawing.Point(128, 48);
			this.lblAttachments.Name = "lblAttachments";
			this.lblAttachments.Size = new System.Drawing.Size(100, 16);
			this.lblAttachments.TabIndex = 8;
			this.lblAttachments.Text = "Attachments";
			// 
			// lbAttachmentList
			// 
			this.lbAttachmentList.BackColor = System.Drawing.Color.Gainsboro;
			this.lbAttachmentList.Location = new System.Drawing.Point(128, 64);
			this.lbAttachmentList.Name = "lbAttachmentList";
			this.lbAttachmentList.Size = new System.Drawing.Size(112, 108);
			this.lbAttachmentList.TabIndex = 0;
			this.lbAttachmentList.TabStop = false;
			// 
			// lblReleases
			// 
			this.lblReleases.Location = new System.Drawing.Point(8, 88);
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
			// lblNeuronName
			// 
			this.lblNeuronName.BackColor = System.Drawing.Color.CornflowerBlue;
			this.lblNeuronName.ForeColor = System.Drawing.Color.Blue;
			this.lblNeuronName.Location = new System.Drawing.Point(8, 8);
			this.lblNeuronName.Name = "lblNeuronName";
			this.lblNeuronName.Size = new System.Drawing.Size(96, 16);
			this.lblNeuronName.TabIndex = 3;
			this.lblNeuronName.Text = "Neuron Name:";
			// 
			// tbReleases
			// 
			this.tbReleases.Location = new System.Drawing.Point(8, 104);
			this.tbReleases.MaxLength = 10;
			this.tbReleases.Name = "tbReleases";
			this.tbReleases.Size = new System.Drawing.Size(112, 20);
			this.tbReleases.TabIndex = 3;
			this.tbReleases.Text = "";
			// 
			// tbFiresOn
			// 
			this.tbFiresOn.Location = new System.Drawing.Point(8, 64);
			this.tbFiresOn.MaxLength = 10;
			this.tbFiresOn.Name = "tbFiresOn";
			this.tbFiresOn.Size = new System.Drawing.Size(112, 20);
			this.tbFiresOn.TabIndex = 2;
			this.tbFiresOn.Text = "";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(8, 24);
			this.tbName.MaxLength = 50;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(112, 20);
			this.tbName.TabIndex = 1;
			this.tbName.Text = "";
			// 
			// bAddToNetwork
			// 
			this.bAddToNetwork.BackColor = System.Drawing.Color.CornflowerBlue;
			this.bAddToNetwork.ForeColor = System.Drawing.Color.Blue;
			this.bAddToNetwork.Location = new System.Drawing.Point(64, 344);
			this.bAddToNetwork.Name = "bAddToNetwork";
			this.bAddToNetwork.Size = new System.Drawing.Size(112, 23);
			this.bAddToNetwork.TabIndex = 5;
			this.bAddToNetwork.Text = "&Add To Network";
			this.bAddToNetwork.Click += new System.EventHandler(this.bAddToNetwork_Click);
			// 
			// bUpdateNeuron
			// 
			this.bUpdateNeuron.Location = new System.Drawing.Point(64, 344);
			this.bUpdateNeuron.Name = "bUpdateNeuron";
			this.bUpdateNeuron.Size = new System.Drawing.Size(112, 23);
			this.bUpdateNeuron.TabIndex = 3;
			this.bUpdateNeuron.Text = "&Update Neuron";
			this.bUpdateNeuron.Click += new System.EventHandler(this.bUpdateNeuron_Click);
			// 
			// gbDerivedAttributes
			// 
			this.gbDerivedAttributes.Controls.Add(this.cbLinkedMethodSelect);
			this.gbDerivedAttributes.Controls.Add(this.lblLinkedMethod);
			this.gbDerivedAttributes.Controls.Add(this.lblType);
			this.gbDerivedAttributes.Controls.Add(this.lblStrength);
			this.gbDerivedAttributes.Controls.Add(this.tbStrength);
			this.gbDerivedAttributes.Controls.Add(this.cbTypeSelect);
			this.gbDerivedAttributes.Enabled = false;
			this.gbDerivedAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbDerivedAttributes.Location = new System.Drawing.Point(8, 200);
			this.gbDerivedAttributes.Name = "gbDerivedAttributes";
			this.gbDerivedAttributes.Size = new System.Drawing.Size(232, 136);
			this.gbDerivedAttributes.TabIndex = 4;
			this.gbDerivedAttributes.TabStop = false;
			this.gbDerivedAttributes.Text = "Add. Attributes";
			// 
			// cbLinkedMethodSelect
			// 
			this.cbLinkedMethodSelect.Location = new System.Drawing.Point(8, 70);
			this.cbLinkedMethodSelect.Name = "cbLinkedMethodSelect";
			this.cbLinkedMethodSelect.Size = new System.Drawing.Size(184, 21);
			this.cbLinkedMethodSelect.TabIndex = 5;
			// 
			// lblLinkedMethod
			// 
			this.lblLinkedMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLinkedMethod.Location = new System.Drawing.Point(8, 56);
			this.lblLinkedMethod.Name = "lblLinkedMethod";
			this.lblLinkedMethod.Size = new System.Drawing.Size(96, 16);
			this.lblLinkedMethod.TabIndex = 15;
			this.lblLinkedMethod.Text = "Linked Method";
			// 
			// lblType
			// 
			this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblType.Location = new System.Drawing.Point(8, 16);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(96, 16);
			this.lblType.TabIndex = 11;
			this.lblType.Text = "Type";
			// 
			// lblStrength
			// 
			this.lblStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStrength.Location = new System.Drawing.Point(8, 96);
			this.lblStrength.Name = "lblStrength";
			this.lblStrength.Size = new System.Drawing.Size(96, 16);
			this.lblStrength.TabIndex = 12;
			this.lblStrength.Text = "Strength";
			// 
			// tbStrength
			// 
			this.tbStrength.Location = new System.Drawing.Point(8, 112);
			this.tbStrength.MaxLength = 10;
			this.tbStrength.Name = "tbStrength";
			this.tbStrength.Size = new System.Drawing.Size(96, 20);
			this.tbStrength.TabIndex = 6;
			this.tbStrength.Text = "";
			// 
			// cbTypeSelect
			// 
			this.cbTypeSelect.Items.AddRange(new object[] {
															  "Sensory",
															  "Motor"});
			this.cbTypeSelect.Location = new System.Drawing.Point(8, 32);
			this.cbTypeSelect.Name = "cbTypeSelect";
			this.cbTypeSelect.Size = new System.Drawing.Size(136, 21);
			this.cbTypeSelect.TabIndex = 4;
			this.cbTypeSelect.TextChanged += new System.EventHandler(this.cbTypeSelect_DisplayMemberChanged);
			// 
			// pnlDisplay
			// 
			this.pnlDisplay.BackColor = System.Drawing.Color.Silver;
			this.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDisplay.ForeColor = System.Drawing.Color.Orange;
			this.pnlDisplay.Location = new System.Drawing.Point(256, 8);
			this.pnlDisplay.Name = "pnlDisplay";
			this.pnlDisplay.Size = new System.Drawing.Size(800, 700);
			this.pnlDisplay.TabIndex = 1;
			this.ttNewBaseNeuronButton.SetToolTip(this.pnlDisplay, "Click to create a new base neuron");
			this.pnlDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDisplay_Paint);
			this.pnlDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDisplay_MouseDown);
			// 
			// fmEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(724, 498);
			this.Controls.Add(this.pnlDisplay);
			this.Controls.Add(this.pnlEditButtons);
			this.Controls.Add(this.pnlAddNeuron);
			this.ForeColor = System.Drawing.Color.Blue;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "fmEdit";
			this.Text = "Edit Network";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.VisibleChanged += new System.EventHandler(this.fmEdit_VisibleChanged);
			this.pnlEditButtons.ResumeLayout(false);
			this.pnlAddNeuron.ResumeLayout(false);
			this.gbDerivedAttributes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//On Click events
		private void bNewBaseNeuron_Click(object sender, System.EventArgs e)
		{
			pnlAddNeuron.Enabled = true;
			pnlEditButtons.Enabled = false;	
			bUpdateNeuron.Hide();			
			bAddToNetwork.Show();
			tbName.Clear();
			tbFiresOn.Clear();
			tbReleases.Clear();
			cbTypeSelect.SelectedIndex = -1;
			cbLinkedMethodSelect.SelectedIndex = -1;
			tbStrength.Clear();		
			//MessageBox.Show(this, "Enter the Neuron information at right and click"
			//				+ " 'Add to Network'.", "Enter at right", MessageBoxButtons.OK);
			if (fmMain.currentNetwork.Name == null)
			{
				tbNetworkName.Enabled = true;
				tbNetworkName.Focus();
			}
			else
			{
				tbNetworkName.Enabled = false;
				tbName.Focus();
			}
			return;
		}

		private void bNewDerivedNeuron_Click(object sender, System.EventArgs e)
		{
			//Enable Add. Attributes combo box and clear out boxes.
			gbDerivedAttributes.Enabled = true;
			tbStrength.Enabled = true;
			cbTypeSelect.SelectedIndex = -1;
			cbLinkedMethodSelect.SelectedIndex = -1;
			tbStrength.Clear();
			this.bNewBaseNeuron_Click(sender, e);
		}

		private void bDeleteNeuron_Click(object sender, System.EventArgs e)
		{
			try
			{				
				//Remove the dynamically created Neuron Icon from the Edit panel
				foreach(Button thisButton in this.pnlDisplay.Controls)
					if(thisButton.Tag.Equals(selectedNeuron))
					{
						this.pnlDisplay.Controls.Remove(thisButton);
						thisButton.Dispose();
						break;
					}

				fmMain.currentNetwork.RemoveNeuron(selectedNeuron);
				selectedNeuron = null;
				tbName.Clear();
				tbFiresOn.Clear();
				tbReleases.Clear();
			}
			catch (Exception except)
			{
				MessageBox.Show(this, except.ToString(), "Error", MessageBoxButtons.OK);
			}
			return;			
		}

		private void bClose_Click(object sender, System.EventArgs e)
		{
			//This updates the currentNetworkDisplayList with the current locations of each NeuronIcon
			foreach(Button thisNeuronIcon in this.pnlDisplay.Controls)
			{
				foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
					if(((Neuron)(thisNeuronIcon.Tag)).Name == thisNeuronIconInfo.NeuronName)
					{
						thisNeuronIconInfo.X = thisNeuronIcon.Location.X;
						thisNeuronIconInfo.Y = thisNeuronIcon.Location.Y;
					}
			}
			this.Visible = false;
		}

		private void bAddToNetwork_Click(object sender, System.EventArgs e)
		{
			switch (cbTypeSelect.SelectedIndex)
			{
				case -1:		//Base
					Neuron newNeuron;
					newNeuron = new Neuron();

					#region Validate user input
					//Check edit boxes for good data.
					if (tbName.TextLength > 0)
						newNeuron.Name = tbName.Text;
					else
					{
						MessageBox.Show(this, "You did not enter a name.", "Name missing", 
							MessageBoxButtons.OK);
						tbName.Focus();
						return;
					}

					try
					{
						newNeuron.FiresOn = System.Convert.ToInt32(tbFiresOn.Text);
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
						newNeuron.Releases = System.Convert.ToInt32(tbReleases.Text);
					}
					catch
					{
						MessageBox.Show(this, "'Releases' must be an integer value.",
							"'Releases' value is invalid", MessageBoxButtons.OK);
						tbReleases.Focus();
						return;
					}
					#endregion
					selectedNeuron = newNeuron;

					fmMain.currentNetwork.AddNeuron(newNeuron);
					AddNewNeuronIconToPanel(selectedNeuron);
					pnlAddNeuron.Enabled = false;
					pnlEditButtons.Enabled = true;
					break;

				case 0:		//Sensory
					SensoryNeuron newSensoryNeuron;
					newSensoryNeuron = new SensoryNeuron();

					#region Validate user input
					//Check edit boxes for good data
					if (tbName.TextLength > 0)
						newSensoryNeuron.Name = tbName.Text;
					else
					{
						MessageBox.Show(this, "You did not enter a name.", "Name missing", 
							MessageBoxButtons.OK);
						tbName.Focus();
						return;
					}

					try
					{
						newSensoryNeuron.FiresOn = System.Convert.ToInt32(tbFiresOn.Text);
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
						newSensoryNeuron.Releases = System.Convert.ToInt32(tbReleases.Text);
					}
					catch
					{
						MessageBox.Show(this, "'Releases' must be an integer value.",
							"'Releases' value is invalid", MessageBoxButtons.OK);
						tbReleases.Focus();
						return;
					}

					try
					{
						newSensoryNeuron.Strength = System.Convert.ToInt32(tbStrength.Text);
					}
					catch
					{
						MessageBox.Show(this, "'Strength' must be an integer value.",
							"'Strength' value is invalid", MessageBoxButtons.OK);
						tbStrength.Focus();
						return;
					}
					#endregion
					
					newSensoryNeuron.SensoryMethodIndex = cbLinkedMethodSelect.SelectedIndex;
					newSensoryNeuron.SensoryTypeIndex = cbTypeSelect.SelectedIndex;
					selectedNeuron = newSensoryNeuron;

					fmMain.currentNetwork.AddNeuron(newSensoryNeuron);
					AddNewNeuronIconToPanel(selectedNeuron);
					gbDerivedAttributes.Enabled = false;
					pnlAddNeuron.Enabled = false;
					pnlEditButtons.Enabled = true;
					break;

				case 1:		//Motor
					MotorNeuron newMotorNeuron;
					newMotorNeuron = new MotorNeuron();

					#region Validate user input
					//Check edit boxes for good data
					if (tbName.TextLength > 0)
						newMotorNeuron.Name = tbName.Text;
					else
					{
						MessageBox.Show(this, "You did not enter a name.", "Name missing", 
							MessageBoxButtons.OK);
						tbName.Focus();
						return;
					}

					try
					{
						newMotorNeuron.FiresOn = System.Convert.ToInt32(tbFiresOn.Text);
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
						newMotorNeuron.Releases = System.Convert.ToInt32(tbReleases.Text);
					}
					catch
					{
						MessageBox.Show(this, "'Releases' must be an integer value.",
							"'Releases' value is invalid", MessageBoxButtons.OK);
						tbReleases.Focus();
						return;
					}

					try
					{
						newMotorNeuron.Strength = System.Convert.ToInt32(tbStrength.Text);
					}
					catch
					{
						MessageBox.Show(this, "'Strength' must be an integer value.",
							"'Strength' value is invalid", MessageBoxButtons.OK);
						tbStrength.Focus();
						return;
					}
					#endregion
					
					newMotorNeuron.MotorMethodIndex = cbLinkedMethodSelect.SelectedIndex;
					newMotorNeuron.MotorTypeIndex = cbTypeSelect.SelectedIndex;
					selectedNeuron = newMotorNeuron;

					fmMain.currentNetwork.AddNeuron(newMotorNeuron);
					AddNewNeuronIconToPanel(selectedNeuron);
					gbDerivedAttributes.Enabled = false;
					pnlAddNeuron.Enabled = false;
					pnlEditButtons.Enabled = true;
					break;

				default:
					break;
			}
		}
		
		private void bUpdateNeuron_Click(object sender, System.EventArgs e)
		{	
			if (selectedNeuron != null)
			{
				selectedNeuron.Name = tbName.Text;
				selectedNeuron.FiresOn = Convert.ToInt32(tbFiresOn.Text);
				selectedNeuron.Releases = Convert.ToInt32(tbReleases.Text);

				switch (cbTypeSelect.SelectedIndex)
				{
					case 0:		//Sensory
						selectedNeuron.Strength = System.Convert.ToInt32(tbStrength.Text);
						selectedNeuron.SensoryMethodIndex = cbLinkedMethodSelect.SelectedIndex;
						selectedNeuron.SensoryTypeIndex = cbTypeSelect.SelectedIndex;
						break;
					case 1:		//Motor
						selectedNeuron.Strength = System.Convert.ToInt32(tbStrength.Text);
						selectedNeuron.MotorMethodIndex = cbLinkedMethodSelect.SelectedIndex;
						selectedNeuron.MotorTypeIndex = cbTypeSelect.SelectedIndex;
						break;
					default:
						break;
				}

				//This finds the Neuron Icon to change the name displayed
				foreach(Button thisNeuronIcon in this.pnlDisplay.Controls)
					if(thisNeuronIcon.Tag.Equals(selectedNeuron))
					{
						foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
							if(thisNeuronIcon.Text == thisNeuronIconInfo.NeuronName)
							{
								thisNeuronIconInfo.NeuronName = tbName.Text;
								break;
							}
						thisNeuronIcon.Text = tbName.Text;
						break;
					}
				//TODO: Update List of Attachments
			}
			pnlAddNeuron.Enabled = false;
			gbDerivedAttributes.Enabled = false;
			pnlEditButtons.Enabled = true;
		}

		private void bEditNeuron_Click(object sender, System.EventArgs e)
		{
			if (selectedNeuron == null)
			{
				return;
            }

			pnlAddNeuron.Enabled = true;
			pnlEditButtons.Enabled = false;
			if ((selectedNeuron.SensoryTypeIndex >= 0) || (selectedNeuron.MotorTypeIndex >= 0))
			{
				gbDerivedAttributes.Enabled = true;
			}
			bAddToNetwork.Hide();
			bUpdateNeuron.Show();
			tbName.Focus();
			return;
		}

		private void bDeleteConnection_Click(object sender, System.EventArgs e)
		{
			deletingAttachmentNeuron = selectedNeuron;	
		}

		private void bDetailCancel_Click(object sender, System.EventArgs e)
		{
			gbDerivedAttributes.Enabled = false;
			pnlAddNeuron.Enabled = false;
			pnlEditButtons.Enabled = true;
			bUpdateNeuron.Hide();			
			bAddToNetwork.Show();
			tbName.Clear();
			tbFiresOn.Clear();
			tbReleases.Clear();
			cbTypeSelect.SelectedIndex = -1;
			cbLinkedMethodSelect.SelectedIndex = -1;
			tbStrength.Clear();
		}
				
		private void bMainCancel_Click(object sender, System.EventArgs e)
		{
			if (currentAttachmentLine != null)
			{
				currentAttachmentLine.Clear();
				this.Invalidate();
			}
		}


		//NeuronIcon events
		private void AnyNeuronIcon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//This allows the dynamically created NeuronButtons to be clicked and draged.
			if(e.Button == MouseButtons.Right)
				((Button)sender).Location =
					new Point(((Button)sender).Location.X + (e.X - (((Button)sender).Width / 2)),
					((Button)sender).Location.Y + (e.Y - (((Button)sender).Height / 2)));
		}

		private void AnyNeuronIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
				{
					ArrayList tempListOfAttachmentLines = thisNeuronIconInfo.GetAttachmentLines();
					//Check this Neuron to see if it was the one moved and update the Attachment Line
					if(thisNeuronIconInfo.NeuronName == ((Neuron)((Button)sender).Tag).Name)
					{
						foreach(AttachmentLine tempAttachmentLine in tempListOfAttachmentLines)
						{
							tempAttachmentLine.theLine.RemoveAt(0);
							tempAttachmentLine.theLine.Insert
								(0,new Point(((Button)sender).Location.X + (neuronIconSize/2),
								((Button)sender).Location.Y + (neuronIconSize/2)));
						}
					}
					//Check each attachment of this Neuron to see if it was attached to the Neuron moved.
					//	If so, up date the Attachment Line
					foreach(AttachmentLine tempAttachmentLine in tempListOfAttachmentLines)
					{
						if(tempAttachmentLine.attachedNeuronName == ((Neuron)((Button)sender).Tag).Name)
						{
							tempAttachmentLine.theLine.RemoveAt(tempAttachmentLine.theLine.Count-1);
							tempAttachmentLine.theLine.Add
								(new Point(((Button)sender).Location.X + (neuronIconSize/2),
                                ((Button)sender).Location.Y + (neuronIconSize/2)));
						}	
					}	
				}
				pnlDisplay.Refresh();
			}
		}

		private void AnyNeuronIcon_Click(object sender, System.EventArgs e)
		{	
			if (pnlAddNeuron.Enabled == true)
			{
				//don't display info if currently creating or editing.
				return;
			}

			selectedNeuron = (Neuron)((Button)sender).Tag;
			selectedNeuronIcon = (Button)sender;
						
			//This removes the just selected Neuron from the previously selected
			//	Neuron's(deletingAttachementNeuron) attachment list if one is assigned.
			#region Delete Attachment
			if (deletingAttachmentNeuron != null)
			{
				deletingAttachmentNeuron.RemoveAttachment(selectedNeuron);
				#region Remove the corresponding Attachment line
				foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
				{
					if(thisNeuronIconInfo.NeuronName == deletingAttachmentNeuron.Name)
					{
						ArrayList tempListOfAttachmentLines = thisNeuronIconInfo.GetAttachmentLines();
						foreach(AttachmentLine tempAttachmentLine in tempListOfAttachmentLines)
						{
							if(tempAttachmentLine.attachedNeuronName == selectedNeuron.Name)
							{
								thisNeuronIconInfo.DeleteAttachmentLine(tempAttachmentLine);
								break;
							}																					  
						}
					}
				}
				#endregion
				//Finds the Neuron Icon Button to set the focus back on it.
				foreach(Button thisButton in this.pnlDisplay.Controls)
					if(thisButton.Tag.Equals(deletingAttachmentNeuron))
					{
						thisButton.Focus();
						break;
					}
				selectedNeuron = deletingAttachmentNeuron;
				deletingAttachmentNeuron = null;							
				pnlDisplay.Refresh();
			}
			#endregion
			
			//This Adds the just selected Neuron to the previously selected Neuron
			//	(creatingAttachementNeuron) if at least one point has been designated inbetween
			#region Create Attachment
			if (currentAttachmentLine != null)
			{
				try
				{
					//Draw the last line
					Point lastPoint = new Point();
					IEnumerator enumForCurrentAttachmentLine = currentAttachmentLine.GetEnumerator();
					while(enumForCurrentAttachmentLine.MoveNext())
						lastPoint = (Point)enumForCurrentAttachmentLine.Current;
					currentAttachmentLine.Add(new Point((selectedNeuronIcon.Location.X + neuronIconSize/2),
						(selectedNeuronIcon.Location.Y + neuronIconSize/2)));
					displayPanelGraphics.DrawLine(new Pen(Color.Salmon,2), lastPoint.X, lastPoint.Y,
						(selectedNeuronIcon.Location.X + neuronIconSize/2),
						(selectedNeuronIcon.Location.Y + neuronIconSize/2));

					//Adds the attachmentLine to the NeuronIconInfo					
					foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
						if(thisNeuronIconInfo.NeuronName == creatingAttachmentNeuron.Name)
						{
							thisNeuronIconInfo.AddAttachmentLine(currentAttachmentLine,
								((Neuron)(selectedNeuronIcon.Tag)).Name);
						}
					//Reset the list of Points
					currentAttachmentLine = null;
				}
				catch (Exception except)
				{
					MessageBox.Show(this, except.Message, "Error Creating Attachment in AnyNeuronIcon_Click",
						MessageBoxButtons.OK);	
				}
				//Add the attachment to the actual Neuron
				creatingAttachmentNeuron.AddAttachment(selectedNeuron);

				//Finds the Neuron Icon Button to set the focus back on it.
				foreach(Button thisButton in this.pnlDisplay.Controls)
					if(thisButton.Tag.Equals(creatingAttachmentNeuron))
					{
						thisButton.Focus();
						break;
					}
				selectedNeuron = creatingAttachmentNeuron;
				creatingAttachmentNeuron = null;
				pnlDisplay.Refresh();
			}
			#endregion

			//Lists the currently selected Neurons details in the display fields
			try
			{
				tbName.Text = selectedNeuron.Name.ToString();
				tbFiresOn.Text = selectedNeuron.FiresOn.ToString();
				tbReleases.Text = selectedNeuron.Releases.ToString();
				if(selectedNeuron.SensoryTypeIndex == 0)
				{
					//SensoryNeuron specific values
					cbTypeSelect.SelectedIndex = selectedNeuron.SensoryTypeIndex;
					cbTypeSelect_DisplayMemberChanged(sender,e);
					cbLinkedMethodSelect.SelectedIndex = selectedNeuron.SensoryMethodIndex;
					tbStrength.Text = selectedNeuron.Strength.ToString();				
				}
				else if(selectedNeuron.MotorTypeIndex == 1)
				{
					//Motor Neuron specific values
					cbTypeSelect.SelectedIndex = selectedNeuron.MotorTypeIndex;
					cbTypeSelect_DisplayMemberChanged(sender,e);
					cbLinkedMethodSelect.SelectedIndex = selectedNeuron.MotorMethodIndex;
					tbStrength.Text = selectedNeuron.Strength.ToString();
				}
				else
				{
					cbTypeSelect.SelectedIndex = -1;
					cbLinkedMethodSelect.SelectedIndex = -1;
					tbStrength.Clear();
				}
			}
			catch (Exception except)
			{
				MessageBox.Show(this, except.Message, "Error", MessageBoxButtons.OK);
			}

			//This gets the list of attached Neurons
			lbAttachmentList.Items.Clear();
			ArrayList listOfattachments;
			selectedNeuron.GetAttachments(out listOfattachments);
			foreach (Neuron attachedNeuron in listOfattachments)
			{
				lbAttachmentList.Items.Add(attachedNeuron.Name);
			}
			//this keeps the attachment creation process in sync with the selected Neuron
			creatingAttachmentNeuron = selectedNeuron;
		}


		//Misc. methods
		private void AddNewNeuronIconToPanel(Neuron selectedNeuron)
		{
			//Create a representation of a new Neuron and add it to the Edit panel
			bTempNeuronButton = new Button();
			tempNeuronIconInfo = new NeuronIconInfo();
			
			bTempNeuronButton.BackColor = SystemColors.Info;
			bTempNeuronButton.Width = neuronIconSize;
			bTempNeuronButton.Height = neuronIconSize;
			bTempNeuronButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			bTempNeuronButton.Tag = selectedNeuron;
			//Set the Neuron Icon Information object reference
			tempNeuronIconInfo.NeuronName = selectedNeuron.Name;
			bTempNeuronButton.Text = selectedNeuron.Name;
			//TODO: make the start position dynamic
			bTempNeuronButton.Location = new Point(200, 200);
			//Set the Neuron Icon Information object position
			tempNeuronIconInfo.X = bTempNeuronButton.Location.X;
			tempNeuronIconInfo.Y = bTempNeuronButton.Location.Y;
			bTempNeuronButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnyNeuronIcon_MouseMove);
			bTempNeuronButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnyNeuronIcon_MouseUp);
			bTempNeuronButton.Click += new System.EventHandler(this.AnyNeuronIcon_Click);
			this.pnlDisplay.Controls.Add(this.bTempNeuronButton);
			//Add the Neuron Icon Information object to the current network display list.
			fmMain.currentNetworkDisplayList.Add(tempNeuronIconInfo);
		}
				
		private void AddExistingNeuronIconToPanel(Neuron thisNeuron)
		{
			bTempNeuronButton = new Button();
			
			try
			{
				bTempNeuronButton.BackColor = SystemColors.Info;
				bTempNeuronButton.Width = neuronIconSize;
				bTempNeuronButton.Height = neuronIconSize;
				bTempNeuronButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				bTempNeuronButton.Tag = thisNeuron;
				bTempNeuronButton.Text = thisNeuron.Name;
				foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
					if(thisNeuronIconInfo.NeuronName == thisNeuron.Name)
					{
						bTempNeuronButton.Location = new Point(thisNeuronIconInfo.X, thisNeuronIconInfo.Y);
					}
				bTempNeuronButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnyNeuronIcon_MouseMove);
				bTempNeuronButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnyNeuronIcon_MouseUp);
				bTempNeuronButton.Click += new System.EventHandler(this.AnyNeuronIcon_Click);
				this.pnlDisplay.Controls.Add(this.bTempNeuronButton);
			}
			catch (Exception except)
			{
				MessageBox.Show(this, except.Message, "Error", MessageBoxButtons.OK);	
			}

		}

		private void tbNetworkName_Leave(object sender, System.EventArgs e)
		{
			//Saves the entered Network Name
			fmMain.currentNetwork.Name = tbNetworkName.Text;
			tbNetworkName.Enabled = false;
			tbName.Focus();
		}

		private void cbTypeSelect_DisplayMemberChanged(object sender, System.EventArgs e)
		{
			if (cbTypeSelect.SelectedIndex == 0)	//Sensory
			{
				cbLinkedMethodSelect.SelectedIndex = -1;
				cbLinkedMethodSelect.Items.Clear();
				cbLinkedMethodSelect.Items.AddRange(fmMain.sensoryMethodsList.ToArray());
			}
			else if (cbTypeSelect.SelectedIndex == 1)	//Motor
			{
				cbLinkedMethodSelect.SelectedIndex = -1;
				cbLinkedMethodSelect.Items.Clear();
				cbLinkedMethodSelect.Items.AddRange(fmMain.motorMethodsList.ToArray());
			}

		}

		public void ShowFiringNeurons()
		{
			foreach(Button thisButton in this.pnlDisplay.Controls)
			{
				if(((Neuron)thisButton.Tag).Synapse != 0)
				{
					thisButton.BackColor = SystemColors.HighlightText;
				}
				else
				{
					thisButton.BackColor = SystemColors.Info;
				}
			}
		}

		private void bTest_Click(object sender, System.EventArgs e)
		{

		}

		private void pnlDisplay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if((selectedNeuronIcon != null) &&
				(e.Button == MouseButtons.Left) && (creatingAttachmentNeuron != null))
			{
				try
				{
					if(currentAttachmentLine == null)
					{
						currentAttachmentLine = new ArrayList();
						//Start a line
						currentAttachmentLine.Add(new Point((selectedNeuronIcon.Location.X + neuronIconSize/2),
							(selectedNeuronIcon.Location.Y + neuronIconSize/2)));
					}
					//Find the last Point
					Point lastPoint = new Point();
					IEnumerator enumForCurrentAttachmentLine = currentAttachmentLine.GetEnumerator();
					while(enumForCurrentAttachmentLine.MoveNext())
						lastPoint = (Point)enumForCurrentAttachmentLine.Current;
					//Add to the line
					currentAttachmentLine.Add(new Point(e.X, e.Y));
					//Draw the line
					displayPanelGraphics.DrawLine(new Pen(Color.Salmon,2),
						lastPoint.X, lastPoint.Y, e.X, e.Y);
					return;
				}
				catch (Exception except)
				{
					MessageBox.Show(this, except.Message, "Error in pnlDisplay_MouseDown", MessageBoxButtons.OK);	
				}
			}
		}

		private void bTestNetwork_Click(object sender, System.EventArgs e)
		{
			fmMain.ifmTest.Visible = true;
		}

		private void pnlDisplay_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			#region Draw all the Attachment lines
			foreach(NeuronIconInfo thisNeuronIconInfo in fmMain.currentNetworkDisplayList)
			{
				ArrayList tempListOfAttachmentLines = thisNeuronIconInfo.GetAttachmentLines();
				foreach(AttachmentLine tempAttachmentLine in tempListOfAttachmentLines)
				{
					bool firstLineSegment = new bool();
					Point lastPoint = new Point();
					IEnumerator currentLinePosition = tempAttachmentLine.theLine.GetEnumerator();
					currentLinePosition.MoveNext();
					lastPoint = (Point)currentLinePosition.Current;
					firstLineSegment = true;
					while(currentLinePosition.MoveNext())
					{
						if(firstLineSegment)
						{
							displayPanelGraphics.DrawLine(new Pen(SystemColors.Info,2),
								lastPoint, (Point)currentLinePosition.Current);
						}
						else
						{							
							displayPanelGraphics.DrawLine(new Pen(Color.Salmon,2),
								lastPoint, (Point)currentLinePosition.Current);
						}
						lastPoint = (Point)currentLinePosition.Current;
						firstLineSegment = false;
					}
				}	
			}
			#endregion
		}

		private void fmEdit_VisibleChanged(object sender, System.EventArgs e)
		{
			if (fmMain.currentNetwork.Name != null)
			{
				tbNetworkName.Text = fmMain.currentNetwork.Name;
				foreach (Neuron thisNeuron in fmMain.currentNetwork.ListOfNeurons)
				{
					AddExistingNeuronIconToPanel(thisNeuron);
				}				
			}		
		}

	}
}
