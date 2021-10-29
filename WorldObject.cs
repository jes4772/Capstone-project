using System;
using System.Drawing;
namespace Capstone_project
{
	/// <summary>
	/// Summary description for WorldObject.
	/// </summary>
	public class WorldObject
	{
		private string objectName;	//The name of the object
		private string objectType;	//The type of object it is
		private Point location;		//The Point where the object is located
		private Color objectColor; //The color of the object.
		public WorldObject()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public WorldObject(string objectName, string objectType, Point location, Color objectColor)
		{
			this.objectName = objectName;
			this.objectType = objectType;
			this.location	= location;
			this.objectColor = objectColor;
		}
		public string ObjectName
		{
			get
			{
				return objectName;
			}
			set
			{
				objectName = value;
			}
		}     
		public string ObjectType
		{
			get
			{
				return ObjectType;
			}
			set
			{
				ObjectType = value;
			}
		}   
		public Point Location
		{
			get
			{
				return location;
			}
			set
			{
				location= value;
			}
		}

		public Color ObjectColor
		{
			get
			{
				return objectColor;
			}
			set
			{
				objectColor = value;
			}
		}
	}
}
