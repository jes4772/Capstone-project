using System;
using System.Collections;
using System.Windows.Forms;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for Network.
	/// </summary>
	[Serializable]
	public class Network
	{
		private string name;	//name of Network
		//TODO: change this back to private
		public System.Collections.ArrayList ListOfNeurons;
								//the list of neurons that comprise the Network

		public Network()
		{
			ListOfNeurons = new ArrayList();
		}
		public Network(string name)
		{
			this.name = name;
			ListOfNeurons = new ArrayList();
			//
			// TODO: Add constructor logic here
			//
		}
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public void AddNeuron(Neuron thisNeuron)
		{
			//Add the newly created "thisNeuron" to the network
			this.ListOfNeurons.Add(thisNeuron);
		}
		public void RemoveNeuron(Neuron thisNeuron)
		{
			this.ListOfNeurons.Remove(thisNeuron);
			//Search every Neuron in the list for any attachments to the neuron being deleted
			foreach(Neuron neuronWithAttachments in ListOfNeurons)
			{
				System.Collections.ArrayList ListOfAttachments;                
				neuronWithAttachments.GetAttachments(out ListOfAttachments);
				foreach (Neuron thisAttachedNeuron in ListOfAttachments)
				{
					if (thisAttachedNeuron.Equals(thisNeuron))
					{
						neuronWithAttachments.RemoveAttachment(thisNeuron);
						break;
					}
				}
			}
			//TODO: Do I need a Destructor?
		}
		public ArrayList ListNeurons()
		{
			string NeuronDataAsText;
			ArrayList ListOfNeuronData;
			ListOfNeuronData = new ArrayList();
			
			foreach (Neuron thisNeuron in ListOfNeurons)
			{
				//Concat the data for each neuron
				NeuronDataAsText = "";			
				NeuronDataAsText += thisNeuron.Synapse.ToString() + " ";
				NeuronDataAsText += thisNeuron.Name;
				ListOfNeuronData.Add(NeuronDataAsText);
			}
			return ListOfNeuronData;
		}

		public void Think()
		{
			//First have every neuron do it's processing
			foreach (Neuron thisNeuron in ListOfNeurons)
			{
				thisNeuron.CheckStimulation();
			}
			//Then move any stimulation to the attached neurons.
			foreach (Neuron thisNeuron in ListOfNeurons)
			{
				if(thisNeuron.Synapse != 0)
				{
					System.Collections.ArrayList thisNeuronsAttachments;	                
					thisNeuron.GetAttachments(out thisNeuronsAttachments);

					foreach (Neuron thisAttachedNeuron in thisNeuronsAttachments)
					{
						thisAttachedNeuron.charge += thisNeuron.Synapse;
					}
				}
			}
		}
		public void Clear()
		{
			this.name = "";
			this.ListOfNeurons.Clear();
		}
		public void Reset()
		{
			foreach (Neuron thisNeuron in ListOfNeurons)
			{
				thisNeuron.charge = 0;
				thisNeuron.Synapse = 0;
			}
		}
	}
}
