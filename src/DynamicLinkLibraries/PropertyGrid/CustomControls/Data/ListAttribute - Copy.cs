using System;

namespace CustomControls.Data
{
	[AttributeUsage( AttributeTargets.Field | AttributeTargets.Property )]
	public abstract class ListAttribute : Attribute
	{
	}
}