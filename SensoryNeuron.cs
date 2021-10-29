using System;

namespace Capstone_project
{
	/// <summary>
	/// SensoryNeuron is derived from Neuron with the additional ability to fire due to 
	///		external (non-Neuronal) stimulation.
	/// </summary>
	[Serializable]
	public class SensoryNeuron : Neuron
	{
		/// <summary>
		/// Listing of additional variables defining a Sensory Neuron
		/// </summary>
		//Not used: public delegate int sensoryMethod(int strength); //Delegate to the test environment sensing proc
		//Not used: private sensoryMethod SensedAmount;
		private int sensoryTypeIndex;	//The index of the type of sensory input this Neuron receives
		private int sensoryMethodIndex; //The index of the method this Neuron uses
		private int strength;			//A quantatative value associated with the Neurons abilities
										// (i.e. detecting strength, vision "distance")
		public SensoryNeuron()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void CheckStimulation()
		{
			//Reset synapse
			synapse = 0;

			//If it senses enough, fire the neuron --- this could also be an incremental change
			//		i.e. synapse += releases;
			if (fmTest.SensoryNetworkInterface(sensoryMethodIndex, strength) >= firesOn)
				synapse = releases;
		}
		public override int Strength
		{
			get
			{
				return strength;
			}
			set
			{
				strength = value;
			}
		}
		public override int SensoryMethodIndex
		{
			get
			{
				return sensoryMethodIndex;
			}
			set
			{
				sensoryMethodIndex = value;
			}
		}


		public override int SensoryTypeIndex
		{
			get
			{
				return sensoryTypeIndex;
			}
			set
			{
				sensoryTypeIndex = value;
			}
		}
	}
}
