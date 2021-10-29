using System;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for NeuronIconInfo.
	/// </summary>
	[Serializable]
	public class NeuronIconInfo
	{
	
		private string neuronName; //The name of the Neuron this Icon represents
		private int x; //The X coordinate of the Neuron Icon
		private int y; //The Y coordinate of the Neuron Icon
		private AttachmentLine newAttachmentLine;
		private System.Collections.ArrayList listOfAttachmentLines;

		public NeuronIconInfo()
		{
			//
			// TODO: Add constructor logic here
			//
			listOfAttachmentLines = new System.Collections.ArrayList(); 
		}
		public NeuronIconInfo(string neuronName, int x, int y)
		{
			listOfAttachmentLines = new System.Collections.ArrayList();
			this.neuronName = neuronName;
			this.x = x;
			this.y = y;
		}
		public string NeuronName
		{
			get
			{
				return neuronName;
			}
			set
			{
				neuronName = value;
			}
		}     
		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x= value;
			}
		}
		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public void AddAttachmentLine(System.Collections.ArrayList newLine, string attachedNeuronName)
		{
			newAttachmentLine = new AttachmentLine();
			newAttachmentLine.theLine = newLine;
			newAttachmentLine.attachedNeuronName = attachedNeuronName;

			listOfAttachmentLines.Add(newAttachmentLine);
			return;
		}
		public void DeleteAttachmentLine(AttachmentLine thisAttachmentLine)
		{
			this.listOfAttachmentLines.Remove(thisAttachmentLine);
		}

		public System.Collections.ArrayList GetAttachmentLines()
		{
			return listOfAttachmentLines;
		}
	}
}
