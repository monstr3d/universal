using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GeneratedProject
{
	public static class RigidBodyStation
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new IntrenalDesktop(); }

		internal class IntrenalDesktop : Diagram.UI.PureDesktop
		{
			internal IntrenalDesktop()
			{
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this);
				Name = "RigidBodyStation"; 
			}
		
		}
		
	}
}
