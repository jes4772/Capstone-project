using System;

namespace Capstone_project
{
	/// <summary>
	/// Summary description for MotorNeuron.
	/// </summary>
	[Serializable]
	public class MotorNeuron : Neuron
	{
		/// <summary>
		/// Listing of additional variables defining a Motor Neuron
		/// </summary>
		private int motorTypeIndex;		//The index of the type of motor response this Neuron does
		private int motorMethodIndex;	//The index of the method this Neuron uses
		private int strength;			//A quantatative value associated with the Neurons abilities
										// (i.e. how fast it can move)
		public MotorNeuron()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public override void CheckStimulation()
		{			
			//Reset synapse
			synapse = 0;

			//If it is stimulated enough, the Neuron triggers the Motor method
			//	--- this could also be an incremental chang	i.e. synapse += releases;
			if (charge >= firesOn)
			{
				fmTest.MotorNetworkInterface(motorMethodIndex, strength);
				//This helps indicate the Neuron actually fired.
				synapse = 1;
			}

			charge = 0;
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
		public override int MotorMethodIndex
		{
			get
			{
				return motorMethodIndex;
			}
			set
			{
				motorMethodIndex = value;
			}
		}

		public override int MotorTypeIndex
		{
			get
			{
				return motorTypeIndex;
			}
			set
			{
				motorTypeIndex = value;
			}
		}
	}
}
