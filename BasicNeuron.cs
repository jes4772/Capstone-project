using System;
using System.Collections;

namespace Capstone_project
{
	/// <summary>
	/// This is the base class for the Neuron type.
	/// </summary>
	[Serializable]
	public class Neuron
	{
		/// <summary>
		/// Listing of values defining each neuron
		/// </summary>
		protected string name;	//name of neuron
		protected int firesOn;	//the amount of charge that will cause the neuron to fire
		protected int releases;	//the amount of neurotransmitter the neuron releases
		protected int synapse;	//the the amount of neurotransmitter the neuron has released
		public int charge;		//the amount of neurotransmitter the neuron has received
		protected System.Collections.ArrayList listOfAttachments;
								//a list of other neurons this one is attached to

		/// <summary>
		/// Methods
		/// </summary>
		//Constructors
		public Neuron()
		{
			this.listOfAttachments = new ArrayList();
			//
			// TODO: Add constructor logic here
			//			
		}

		public Neuron(string name, int index, int firesOn, int releases, int synapse, int charge)
		{
			this.name = name;
			this.firesOn = firesOn;
			this.releases = releases;
			this.synapse = synapse;
			this.charge = charge;			
			this.listOfAttachments = new ArrayList();
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
		public int FiresOn
		{
			get
			{
				return firesOn;
			}
			set
			{
				firesOn = value;
			}
		}
		public int Releases
		 {
			 get
			 {
				 return releases;
			 }
			 set
			 {
				 releases = value;
			 }
		 }
		public int Synapse
		  {
			  get
			  {
				  return synapse;
			  }
			  set
			  {
				  synapse = value;
			  }
		  }
		public void GetAttachments(out System.Collections.ArrayList listing)
		{
			listing = listOfAttachments;
			return;
		}
		//Add/Remove attachments
		public void AddAttachment(Neuron thisNeuron)
		{
			this.listOfAttachments.Add(thisNeuron);
		}
		public void RemoveAttachment(Neuron thisNeuron)
		{
			this.listOfAttachments.Remove(thisNeuron);
		}
		//Neuron functionality
		public virtual void CheckStimulation()
		{
			//Reset synapse
			synapse = 0;

			//If excited enough, fire the neuron --- this could also be an incremental change
			//		i.e. synapse += releases;
			if (charge >= firesOn)
				synapse = releases;
			
			//Reduce the charge --- this could also be a decremental change
			//		i.e. charge -= 100
			charge = 0;
		}
		public virtual int Strength {return};
		public virtual string SensoryType;
		public virtual void SetSensingMethod(SensoryNeuron.SensoryMethod sensingMethodName) {}

	}
}
