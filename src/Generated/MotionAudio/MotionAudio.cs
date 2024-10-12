using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GeneratedProject
{
	public static class MotionAudio
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new InternalDesktop(); }

		internal class InternalDesktop : Diagram.UI.PureDesktop
		{
			internal InternalDesktop()
			{
				objects.Add(new InternalDesktop.OblectLabel0("Relative", this));
				objects.Add(new InternalDesktop.OblectLabel1("Motion + Audio", this));
				objects.Add(new InternalDesktop.OblectLabel2("Timer", this));
				objects.Add(new InternalDesktop.OblectLabel3("Camera 1", this));
				objects.Add(new InternalDesktop.OblectLabel4("Main Frame", this));
				objects.Add(new InternalDesktop.OblectLabel5("Plane", this));
				objects.Add(new InternalDesktop.OblectLabel6("Earth", this));
				objects.Add(new InternalDesktop.OblectLabel7("Base", this));
				objects.Add(new InternalDesktop.OblectLabel8("Motion", this));
				objects.Add(new InternalDesktop.OblectLabel9("EndOfRunway", this));
				objects.Add(new InternalDesktop.OblectLabel10("Motion frame", this));
				objects.Add(new InternalDesktop.OblectLabel11("Start", this));
				objects.Add(new InternalDesktop.OblectLabel12("Rotate", this));
				objects.Add(new InternalDesktop.OblectLabel13("Earth frame", this));
				objects.Add(new InternalDesktop.OblectLabel14("Camera 2 frame", this));
				objects.Add(new InternalDesktop.OblectLabel15("Camera 2", this));
				objects.Add(new InternalDesktop.OblectLabel16("Side frame", this));
				objects.Add(new InternalDesktop.OblectLabel17("Side camera", this));
				objects.Add(new InternalDesktop.OblectLabel18("Consumer", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new InternalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)10;
				currALabel.TargetNumber = (int)8;
				currALabel  = new InternalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)9;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel3("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)11;
				currALabel.TargetNumber = (int)9;
				currALabel  = new InternalDesktop.ArrowLabel4("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)4;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel5("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)13;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel6("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)13;
				currALabel  = new InternalDesktop.ArrowLabel7("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)16;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel8("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)4;
				currALabel  = new InternalDesktop.ArrowLabel9("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)14;
				currALabel  = new InternalDesktop.ArrowLabel10("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)10;
				currALabel.TargetNumber = (int)11;
				currALabel  = new InternalDesktop.ArrowLabel11("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)12;
				currALabel  = new InternalDesktop.ArrowLabel12("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)12;
				currALabel.TargetNumber = (int)10;
				currALabel  = new InternalDesktop.ArrowLabel13("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel14("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)14;
				currALabel.TargetNumber = (int)10;
				currALabel  = new InternalDesktop.ArrowLabel15("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)6;
				currALabel  = new InternalDesktop.ArrowLabel16("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel17("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)17;
				currALabel.TargetNumber = (int)16;
				currALabel  = new InternalDesktop.ArrowLabel18("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)17;
				currALabel.TargetNumber = (int)6;
				currALabel  = new InternalDesktop.ArrowLabel19("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)17;
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel20("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)17;
				currALabel  = new InternalDesktop.ArrowLabel21("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)3;
				currALabel  = new InternalDesktop.ArrowLabel22("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)15;
				currALabel  = new InternalDesktop.ArrowLabel23("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)10;
				currALabel  = new InternalDesktop.ArrowLabel24("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = new object[] {(int)1,"Equations" };
				currALabel  = new InternalDesktop.ArrowLabel25("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = new object[] {(int)1,"H,V" };
				currALabel  = new InternalDesktop.ArrowLabel26("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)18;
				currALabel  = new InternalDesktop.ArrowLabel27("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"ATIS Sound" };
				currALabel  = new InternalDesktop.ArrowLabel28("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"Height sound" };
				currALabel  = new InternalDesktop.ArrowLabel29("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"Velocity sound" };
				currALabel  = new InternalDesktop.ArrowLabel30("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"Meteo" };
				currALabel  = new InternalDesktop.ArrowLabel31("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"Equations" };
				currALabel  = new InternalDesktop.ArrowLabel32("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"H,V" };
				currALabel  = new InternalDesktop.ArrowLabel33("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"Peaks" };
				currALabel  = new InternalDesktop.ArrowLabel34("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = new object[] {(int)1,"ATIS Peaks" };
				currALabel  = new InternalDesktop.ArrowLabel35("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)0;
				currALabel.TargetNumber = (int)16;
				currALabel  = new InternalDesktop.ArrowLabel36("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)12;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel37("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)0;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this);
				Name = "MotionAudio"; 
			}
		
			internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel0.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
				}
			}
		
			internal class OblectLabel1 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel1.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.ObjectContainerPortable
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0("Meteo", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel1("Heights", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel2("V(H)", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel3("Velocities", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel4("H(L)", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel5("Equations", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel6("H,V", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel7("Recurrsive ATIS", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel8("Condition ATIS", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel9("Recursive", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel10("Condition ATIS", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel11("Peaks", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel12("Sounds", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel13("Height sound", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel14("Velocity sound", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel15("ATIS Peaks", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel16("ATIS Calculation", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel17("ATIS Calculation", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel18("ATIS Recursive", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel19("ATIS Sound", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel20("Chart ATIS", this));
							objects.Add(new InternalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel21("Timer", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)5;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)6;
							currALabel.TargetNumber = (int)5;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel2("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)6;
							currALabel.TargetNumber = (int)4;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel3("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)7;
							currALabel.TargetNumber = (int)5;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel4("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)8;
							currALabel.TargetNumber = (int)5;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel5("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)8;
							currALabel.TargetNumber = (int)7;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel6("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)9;
							currALabel.TargetNumber = (int)6;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel7("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)9;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel8("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)9;
							currALabel.TargetNumber = (int)3;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel9("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)10;
							currALabel.TargetNumber = (int)5;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel10("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)10;
							currALabel.TargetNumber = (int)7;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel11("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)11;
							currALabel.TargetNumber = (int)9;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel12("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)12;
							currALabel.TargetNumber = (int)9;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel13("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)13;
							currALabel.TargetNumber = (int)9;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel14("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)13;
							currALabel.TargetNumber = (int)12;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel15("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)14;
							currALabel.TargetNumber = (int)9;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel16("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)14;
							currALabel.TargetNumber = (int)12;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel17("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)15;
							currALabel.TargetNumber = (int)10;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel18("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)16;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel19("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)17;
							currALabel.TargetNumber = (int)16;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel20("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)18;
							currALabel.TargetNumber = (int)8;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel21("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)19;
							currALabel.TargetNumber = (int)10;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel22("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)19;
							currALabel.TargetNumber = (int)17;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel23("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)10;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel24("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)17;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel25("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)15;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel26("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)11;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel27("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel28("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)5;
							currALabel.TargetNumber = (int)2;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel29("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)5;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel30("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)13;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel31("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)14;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel32("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)19;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel33("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)21;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel34("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)8;
							currALabel  = new InternalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel35("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)20;
							currALabel.TargetNumber = (int)7;
						}
					
						internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel0.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"8\" S=\"8\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"p\" S=\"p\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
									};
									parameters =new Dictionary<string, object>()
									{
										{"a", (double)4.8466666666666667 },
										{"k", (double)0.75006375541921 },
										{"t", (double)22.503536067892504 },
										{"b", (double)80.88333333333334 },
										{"p", (double)1028 }
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = aliasName0.Value;
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										variable = aliasName2.Value;
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_3 = (var_1) * (var_2);
										var_5 = (var_3) / (var_4);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										variable = aliasName7.Value;
										if (checkValue(variable)) { success = false; return; }
										var_7 = (double)variable;
										var_8 = (var_6) * (var_7);
										variable = aliasName9.Value;
										if (checkValue(variable)) { success = false; return; }
										var_9 = (double)variable;
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										aliasName2 = dataPerformerFormula.ToAliasName(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										aliasName7 = dataPerformerFormula.ToAliasName(trees[7]);
										aliasName9 = dataPerformerFormula.ToAliasName(trees[9]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									Diagram.UI.Interfaces.IAliasName aliasName0;
									Diagram.UI.Interfaces.IAliasName aliasName2;
									Diagram.UI.Interfaces.IAliasName aliasName6;
									Diagram.UI.Interfaces.IAliasName aliasName7;
									Diagram.UI.Interfaces.IAliasName aliasName9;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = Math.PI;
									double var_2 = 0;
									double var_3 = 0;
									double var_4 = 180;
									double var_5 = 0;
									double var_6 = 0;
									double var_7 = 0;
									double var_8 = 0;
									double var_9 = 0;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel1 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel1.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Portable.SeriesBase
							{
								internal CategoryObject()
								{
									points = new List<double[]>()
									{
										new double[] { 0, 200},
										new double[] { 1, 150},
										new double[] { 2, 120},
										new double[] { 3, 100},
										new double[] { 4, 80},
										new double[] { 5, 60},
										new double[] { 6, 40},
										new double[] { 7, 30},
										new double[] { 8, 20},
										new double[] { 9, 10},
										new double[] { 10, 6},
										new double[] { 11, 3},
										new double[] { 12, 1},
										new double[] { 13, -1},
										new double[] { 14, 0}
									};
							}
							}
						}
					
						internal class OblectLabel2 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel2(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel2.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Portable.SeriesBase
							{
								internal CategoryObject()
								{
									points = new List<double[]>()
									{
										new double[] { 0, 5},
										new double[] { 100, 100},
										new double[] { 200, 150},
										new double[] { 300, 250},
										new double[] { 400, 550}
									};
							}
							}
						}
					
						internal class OblectLabel3 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel3(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel3.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Portable.SeriesBase
							{
								internal CategoryObject()
								{
									points = new List<double[]>()
									{
										new double[] { 0, 220},
										new double[] { 1, 200},
										new double[] { 2, 180},
										new double[] { 3, 160},
										new double[] { 4, 140},
										new double[] { 5, 2},
										new double[] { 6, 1}
									};
							}
							}
						}
					
						internal class OblectLabel4 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel4.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Portable.SeriesBase
							{
								internal CategoryObject()
								{
									points = new List<double[]>()
									{
										new double[] { 0, 0},
										new double[] { 10000, 140},
										new double[] { 20000, 400}
									};
							}
							}
						}
					
						internal class OblectLabel5 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel5.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.DifferentialEquationSolver, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									aliasNames  = new Dictionary<object, object>()
									{
									};
							
									feedback = new Dictionary<int, string>()
									{
									};
							
									vars = new Dictionary<object, object>()
									{
													{'x' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"v\" S=\"v\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>" , (System.Double)(19000)}}
									};
									pars = new Dictionary<object, object>()
									{
													{'f' , "V(H).Function"}
										,			{'v' , "Meteo.Formula_1"}
										,			{'b' , "Meteo.Formula_2"}
									};
									aliases = new Dictionary<object, object>()
									{
													{"a" , (System.Double)(0.59999999999999998)}
										,			{"x" , (System.Double)(19000)}
										,			{"h" , (System.Double)(205.59930691663146)}
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"v = Meteo.Formula_1",
										"b = Meteo.Formula_2",
										"f = V(H).Function"
									};
								}
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									FormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);
									return new Calculation(trees, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = aliasName0.Value;
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										currentArray = treeArray_1;
										currentArray[0] = var_0;
										variable = trees[1].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_2 = -(var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										variable = aliasName4.Value;
										if (checkValue(variable)) { success = false; return; }
										var_4 = (double)variable;
										variable = measurement5.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										var_6 = (var_4) - (var_5);
										var_7 = Math.Cos(var_6);
										var_8 = (var_3) * (var_7);
										var_9 = (var_2) - (var_8);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										aliasName4 = dataPerformerFormula.ToAliasName(trees[4]);
										measurement5 = dataPerformerFormula.ToMeasurement(trees[5]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									Diagram.UI.Interfaces.IAliasName aliasName0;
									object[] treeArray_1 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement3;
									Diagram.UI.Interfaces.IAliasName aliasName4;
									DataPerformer.Interfaces.IMeasurement measurement5;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									double var_2 = 0;
									double var_3 = 0;
									double var_4 = 0;
									double var_5 = 0;
									double var_6 = 0;
									double var_7 = 0;
									double var_8 = 0;
									double var_9 = 0;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel6 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel6(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel6.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
										{ 0,"Equations.h" }
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"'\" S=\"d/dt\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"x = Equations.x",
										"f = H(L).Function"
									};
									parameters =new Dictionary<string, object>()
									{
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										currentArray = treeArray_1;
										currentArray[0] = var_0;
										variable = trees[1].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_3 = -(var_2);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									object[] treeArray_1 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement2;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									double var_2 = 0;
									double var_3 = 0;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel7 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel7.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.Recursive, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									vars = new Dictionary<object, object>()
									{
										{'y', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Double)(0)}}
										,{'x', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Double)(0)}}
									};
							
									aliases = new Dictionary<object, object>()
									{
									};
							
									externalAls = new Dictionary<object, object>()
									{
									};
							
									pars = new Dictionary<object, object>()
									{
										{'a', "Equations.x"}
									};
							
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									FormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);
									return new Calculation(trees, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel8 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel8.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&lt;\" S=\"&lt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"a = Equations.x",
										"x = Recurrsive ATIS.x"
									};
									parameters =new Dictionary<string, object>()
									{
										{"b", (double)17500 }
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										variable = aliasName1.Value;
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_2 = (var_0) > (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = (var_3) < (var_1);
										var_5 = (var_2) & (var_4);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										aliasName1 = dataPerformerFormula.ToAliasName(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									Diagram.UI.Interfaces.IAliasName aliasName1;
									DataPerformer.Interfaces.IMeasurement measurement3;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									bool var_2 = false;
									double var_3 = 0;
									bool var_4 = false;
									bool var_5 = false;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel9 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel9.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.Recursive, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									vars = new Dictionary<object, object>()
									{
										{'b', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"v\" S=\"v\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"g\" S=\"g\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Double)(0)}}
										,{'j', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Double)(0)}}
										,{'a', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Double)(0)}}
										,{'i', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Double)(0)}}
										,{'s', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"g\" S=\"g\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",(System.Double)(0)}}
										,{'y', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"v\" S=\"v\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&lt;\" S=\"&lt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"g\" S=\"g\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",(System.Boolean)(false)}}
										,{'x', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&lt;\" S=\"&lt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",(System.Boolean)(false)}}
										,{'r', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",(System.Double)(0)}}
									};
							
									aliases = new Dictionary<object, object>()
									{
									};
							
									externalAls = new Dictionary<object, object>()
									{
									};
							
									pars = new Dictionary<object, object>()
									{
										{'f', "Heights.Function"}
										,{'h', "H,V.Formula_1"}
										,{'v', "H,V.Formula_2"}
										,{'g', "Velocities.Function"}
									};
							
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									FormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);
									return new Calculation(trees, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										currentArray = treeArray_2;
										currentArray[0] = var_1;
										variable = trees[2].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_3 = (var_0) > (var_2);
										variable = measurement4.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_4 = (double)variable;
										variable = measurement5.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										var_7 = (var_5) + (var_6);
										var_8 = (var_3) ? (var_4) : (var_7);
										variable = measurement9.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_9 = (double)variable;
										variable = measurement10.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_10 = (double)variable;
										currentArray = treeArray_11;
										currentArray[0] = var_10;
										variable = trees[11].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_11 = (double)variable;
										var_12 = (var_9) > (var_11);
										variable = measurement13.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_13 = (double)variable;
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_16 = (var_14) + (var_15);
										var_17 = (var_12) ? (var_13) : (var_16);
										variable = measurement18.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_18 = (double)variable;
										variable = measurement19.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_19 = (double)variable;
										variable = measurement20.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_20 = (double)variable;
										var_22 = (var_20) - (var_21);
										currentArray = treeArray_23;
										currentArray[0] = var_22;
										variable = trees[23].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_23 = (double)variable;
										variable = measurement24.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_24 = (double)variable;
										var_26 = (var_24) - (var_25);
										currentArray = treeArray_27;
										currentArray[0] = var_26;
										variable = trees[27].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_27 = (double)variable;
										variable = measurement28.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_28 = (double)variable;
										currentArray = treeArray_29;
										currentArray[0] = var_28;
										variable = trees[29].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_29 = (double)variable;
										var_30 = (var_0) < (var_29);
										variable = measurement31.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_31 = (double)variable;
										currentArray = treeArray_32;
										currentArray[0] = var_31;
										variable = trees[32].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_32 = (double)variable;
										var_33 = (var_9) < (var_32);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement4 = dataPerformerFormula.ToMeasurement(trees[4]);
										measurement5 = dataPerformerFormula.ToMeasurement(trees[5]);
										measurement9 = dataPerformerFormula.ToMeasurement(trees[9]);
										measurement10 = dataPerformerFormula.ToMeasurement(trees[10]);
										measurement13 = dataPerformerFormula.ToMeasurement(trees[13]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
										measurement18 = dataPerformerFormula.ToMeasurement(trees[18]);
										measurement19 = dataPerformerFormula.ToMeasurement(trees[19]);
										measurement20 = dataPerformerFormula.ToMeasurement(trees[20]);
										measurement24 = dataPerformerFormula.ToMeasurement(trees[24]);
										measurement28 = dataPerformerFormula.ToMeasurement(trees[28]);
										measurement31 = dataPerformerFormula.ToMeasurement(trees[31]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
										dictionary[trees[10]] = Get_10;
										dictionary[trees[11]] = Get_11;
										dictionary[trees[12]] = Get_12;
										dictionary[trees[13]] = Get_13;
										dictionary[trees[14]] = Get_14;
										dictionary[trees[15]] = Get_15;
										dictionary[trees[16]] = Get_16;
										dictionary[trees[17]] = Get_17;
										dictionary[trees[18]] = Get_18;
										dictionary[trees[19]] = Get_19;
										dictionary[trees[20]] = Get_20;
										dictionary[trees[21]] = Get_21;
										dictionary[trees[22]] = Get_22;
										dictionary[trees[23]] = Get_23;
										dictionary[trees[24]] = Get_24;
										dictionary[trees[25]] = Get_25;
										dictionary[trees[26]] = Get_26;
										dictionary[trees[27]] = Get_27;
										dictionary[trees[28]] = Get_28;
										dictionary[trees[29]] = Get_29;
										dictionary[trees[30]] = Get_30;
										dictionary[trees[31]] = Get_31;
										dictionary[trees[32]] = Get_32;
										dictionary[trees[33]] = Get_33;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									object[] treeArray_2 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement4;
									DataPerformer.Interfaces.IMeasurement measurement5;
									DataPerformer.Interfaces.IMeasurement measurement9;
									DataPerformer.Interfaces.IMeasurement measurement10;
									object[] treeArray_11 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement13;
									DataPerformer.Interfaces.IMeasurement measurement14;
									DataPerformer.Interfaces.IMeasurement measurement18;
									DataPerformer.Interfaces.IMeasurement measurement19;
									DataPerformer.Interfaces.IMeasurement measurement20;
									object[] treeArray_23 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement24;
									object[] treeArray_27 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement28;
									object[] treeArray_29 = new object[1];
									DataPerformer.Interfaces.IMeasurement measurement31;
									object[] treeArray_32 = new object[1];
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									double var_2 = 0;
									bool var_3 = false;
									double var_4 = 0;
									double var_5 = 0;
									double var_6 = 1;
									double var_7 = 0;
									double var_8 = 0;
									double var_9 = 0;
									double var_10 = 0;
									double var_11 = 0;
									bool var_12 = false;
									double var_13 = 0;
									double var_14 = 0;
									double var_15 = 1;
									double var_16 = 0;
									double var_17 = 0;
									double var_18 = 0;
									double var_19 = 0;
									double var_20 = 0;
									double var_21 = 1;
									double var_22 = 0;
									double var_23 = 0;
									double var_24 = 0;
									double var_25 = 1;
									double var_26 = 0;
									double var_27 = 0;
									double var_28 = 0;
									double var_29 = 0;
									bool var_30 = false;
									double var_31 = 0;
									double var_32 = 0;
									bool var_33 = false;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									object Get_10()
									{
										return success ? var_10 : null;
									}
									
									object Get_11()
									{
										return success ? var_11 : null;
									}
									
									object Get_12()
									{
										return success ? var_12 : null;
									}
									
									object Get_13()
									{
										return success ? var_13 : null;
									}
									
									object Get_14()
									{
										return success ? var_14 : null;
									}
									
									object Get_15()
									{
										return success ? var_15 : null;
									}
									
									object Get_16()
									{
										return success ? var_16 : null;
									}
									
									object Get_17()
									{
										return success ? var_17 : null;
									}
									
									object Get_18()
									{
										return success ? var_18 : null;
									}
									
									object Get_19()
									{
										return success ? var_19 : null;
									}
									
									object Get_20()
									{
										return success ? var_20 : null;
									}
									
									object Get_21()
									{
										return success ? var_21 : null;
									}
									
									object Get_22()
									{
										return success ? var_22 : null;
									}
									
									object Get_23()
									{
										return success ? var_23 : null;
									}
									
									object Get_24()
									{
										return success ? var_24 : null;
									}
									
									object Get_25()
									{
										return success ? var_25 : null;
									}
									
									object Get_26()
									{
										return success ? var_26 : null;
									}
									
									object Get_27()
									{
										return success ? var_27 : null;
									}
									
									object Get_28()
									{
										return success ? var_28 : null;
									}
									
									object Get_29()
									{
										return success ? var_29 : null;
									}
									
									object Get_30()
									{
										return success ? var_30 : null;
									}
									
									object Get_31()
									{
										return success ? var_31 : null;
									}
									
									object Get_32()
									{
										return success ? var_32 : null;
									}
									
									object Get_33()
									{
										return success ? var_33 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel10 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel10.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&lt;\" S=\"&lt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"x = Recurrsive ATIS.x",
										"a = Recurrsive ATIS.y"
									};
									parameters =new Dictionary<string, object>()
									{
										{"b", (double)17500 }
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (double)variable;
										variable = aliasName1.Value;
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_2 = (var_0) > (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = (var_3) < (var_1);
										var_5 = (var_2) & (var_4);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										aliasName1 = dataPerformerFormula.ToAliasName(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									Diagram.UI.Interfaces.IAliasName aliasName1;
									DataPerformer.Interfaces.IMeasurement measurement3;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									bool var_2 = false;
									double var_3 = 0;
									bool var_4 = false;
									bool var_5 = false;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel11 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel11(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel11.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"v\" S=\"v\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"h = Recursive.r",
										"v = Recursive.s",
										"a = Recursive.x",
										"b = Recursive.y"
									};
									parameters =new Dictionary<string, object>()
									{
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (bool)variable;
										var_3 = (var_0) ? (var_1) : (var_2);
										variable = measurement4.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_4 = (bool)variable;
										var_7 = (var_4) ? (var_5) : (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (double)variable;
										variable = measurement9.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_9 = (double)variable;
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement4 = dataPerformerFormula.ToMeasurement(trees[4]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
										measurement9 = dataPerformerFormula.ToMeasurement(trees[9]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement4;
									DataPerformer.Interfaces.IMeasurement measurement8;
									DataPerformer.Interfaces.IMeasurement measurement9;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									bool var_0 = false;
									double var_1 = 0;
									double var_2 = 1;
									double var_3 = 0;
									bool var_4 = false;
									double var_5 = 0;
									double var_6 = 1;
									double var_7 = 0;
									double var_8 = 0;
									double var_9 = 0;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel12 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel12.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"C\" S=\"UInt32\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"C\" S=\"UInt32\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"v\" S=\"v\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"h = Recursive.r",
										"v = Recursive.s"
									};
									parameters =new Dictionary<string, object>()
									{
										{"a", "St H " },
										{"f", ".wav" },
										{"b", "St V " }
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = aliasName0.Value;
										if (checkValue(variable)) { success = false; return; }
										var_0 = (string)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_2 = (UInt32)var_1;
										currentArray = treeArray_3;
										currentArray[0] = var_0;
										currentArray[1] = var_2;
										variable = trees[3].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_3 = (string)variable;
										variable = aliasName4.Value;
										if (checkValue(variable)) { success = false; return; }
										var_4 = (string)variable;
										currentArray = treeArray_5;
										currentArray[0] = var_3;
										currentArray[1] = var_4;
										variable = trees[5].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_5 = (string)variable;
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (string)variable;
										variable = measurement7.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_7 = (double)variable;
										var_8 = (UInt32)var_7;
										currentArray = treeArray_9;
										currentArray[0] = var_6;
										currentArray[1] = var_8;
										variable = trees[9].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_9 = (string)variable;
										currentArray = treeArray_10;
										currentArray[0] = var_9;
										currentArray[1] = var_4;
										variable = trees[10].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_10 = (string)variable;
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName4 = dataPerformerFormula.ToAliasName(trees[4]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement7 = dataPerformerFormula.ToMeasurement(trees[7]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
										dictionary[trees[10]] = Get_10;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									Diagram.UI.Interfaces.IAliasName aliasName0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									object[] treeArray_3 = new object[2];
									Diagram.UI.Interfaces.IAliasName aliasName4;
									object[] treeArray_5 = new object[2];
									Diagram.UI.Interfaces.IAliasName aliasName6;
									DataPerformer.Interfaces.IMeasurement measurement7;
									object[] treeArray_9 = new object[2];
									object[] treeArray_10 = new object[2];
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									string var_0 = "";
									double var_1 = 0;
									uint var_2 = 0;
									string var_3 = "";
									string var_4 = "";
									string var_5 = "";
									string var_6 = "";
									double var_7 = 0;
									uint var_8 = 0;
									string var_9 = "";
									string var_10 = "";
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									object Get_10()
									{
										return success ? var_10 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel13 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel13.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : SoundService.MultiSound
							{
								internal CategoryObject()
								{
									conditionName = "Recursive.x";
									soundName = "Sounds.Formula_1";
								}
							}
						}
					
						internal class OblectLabel14 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel14.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : SoundService.MultiSound
							{
								internal CategoryObject()
								{
									conditionName = "Recursive.y";
									soundName = "Sounds.Formula_2";
								}
							}
						}
					
						internal class OblectLabel15 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel15(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel15.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"a = Condition ATIS.Formula_1"
									};
									parameters =new Dictionary<string, object>()
									{
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (bool)variable;
										var_3 = (var_0) ? (var_1) : (var_2);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									bool var_0 = false;
									double var_1 = 1;
									double var_2 = 0;
									double var_3 = 0;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel16 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel16.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : SoundService.Object2SoundName
							{
								internal CategoryObject()
								{
									inputs = new string[] {

										"Meteo.Formula_1",
										"Meteo.Formula_2",
										"Meteo.Formula_3",
										"Meteo.Formula_4"
									};
								}
							}
						}
					
						internal class OblectLabel17 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel17.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									feedback = new Dictionary<int, string>()
									{
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"c\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"d\" S=\"d\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"g\" S=\"g\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"i\" S=\"i\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"j\" S=\"j\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"d = ATIS Calculation.Sound_1",
										"b = ATIS Calculation.Sound_2",
										"g = ATIS Calculation.Sound_3",
										"i = ATIS Calculation.Sound_4"
									};
									parameters =new Dictionary<string, object>()
									{
										{"a", "wind.wav_" },
										{"f", "_pressure.wav_" },
										{"c", "_degree.wav_" },
										{"h", "_hectopascal.wav_temperature.wav_" },
										{"j", "_degree.wav" }
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = aliasName0.Value;
										if (checkValue(variable)) { success = false; return; }
										var_0 = (string)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (string)variable;
										currentArray = treeArray_2;
										currentArray[0] = var_0;
										currentArray[1] = var_1;
										variable = trees[2].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_2 = (string)variable;
										variable = aliasName3.Value;
										if (checkValue(variable)) { success = false; return; }
										var_3 = (string)variable;
										currentArray = treeArray_4;
										currentArray[0] = var_2;
										currentArray[1] = var_3;
										variable = trees[4].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_4 = (string)variable;
										variable = measurement5.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_5 = (string)variable;
										currentArray = treeArray_6;
										currentArray[0] = var_4;
										currentArray[1] = var_5;
										variable = trees[6].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_6 = (string)variable;
										variable = aliasName7.Value;
										if (checkValue(variable)) { success = false; return; }
										var_7 = (string)variable;
										currentArray = treeArray_8;
										currentArray[0] = var_6;
										currentArray[1] = var_7;
										variable = trees[8].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_8 = (string)variable;
										variable = measurement9.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_9 = (string)variable;
										currentArray = treeArray_10;
										currentArray[0] = var_8;
										currentArray[1] = var_9;
										variable = trees[10].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_10 = (string)variable;
										variable = aliasName11.Value;
										if (checkValue(variable)) { success = false; return; }
										var_11 = (string)variable;
										currentArray = treeArray_12;
										currentArray[0] = var_10;
										currentArray[1] = var_11;
										variable = trees[12].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_12 = (string)variable;
										variable = measurement13.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_13 = (string)variable;
										currentArray = treeArray_14;
										currentArray[0] = var_12;
										currentArray[1] = var_13;
										variable = trees[14].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_14 = (string)variable;
										variable = aliasName15.Value;
										if (checkValue(variable)) { success = false; return; }
										var_15 = (string)variable;
										currentArray = treeArray_16;
										currentArray[0] = var_14;
										currentArray[1] = var_15;
										variable = trees[16].Calculate(currentArray);
										if (checkValue(variable)) { success = false; return; }
										var_16 = (string)variable;
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName3 = dataPerformerFormula.ToAliasName(trees[3]);
										measurement5 = dataPerformerFormula.ToMeasurement(trees[5]);
										aliasName7 = dataPerformerFormula.ToAliasName(trees[7]);
										measurement9 = dataPerformerFormula.ToMeasurement(trees[9]);
										aliasName11 = dataPerformerFormula.ToAliasName(trees[11]);
										measurement13 = dataPerformerFormula.ToMeasurement(trees[13]);
										aliasName15 = dataPerformerFormula.ToAliasName(trees[15]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
										dictionary[trees[10]] = Get_10;
										dictionary[trees[11]] = Get_11;
										dictionary[trees[12]] = Get_12;
										dictionary[trees[13]] = Get_13;
										dictionary[trees[14]] = Get_14;
										dictionary[trees[15]] = Get_15;
										dictionary[trees[16]] = Get_16;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									Diagram.UI.Interfaces.IAliasName aliasName0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									object[] treeArray_2 = new object[2];
									Diagram.UI.Interfaces.IAliasName aliasName3;
									object[] treeArray_4 = new object[2];
									DataPerformer.Interfaces.IMeasurement measurement5;
									object[] treeArray_6 = new object[2];
									Diagram.UI.Interfaces.IAliasName aliasName7;
									object[] treeArray_8 = new object[2];
									DataPerformer.Interfaces.IMeasurement measurement9;
									object[] treeArray_10 = new object[2];
									Diagram.UI.Interfaces.IAliasName aliasName11;
									object[] treeArray_12 = new object[2];
									DataPerformer.Interfaces.IMeasurement measurement13;
									object[] treeArray_14 = new object[2];
									Diagram.UI.Interfaces.IAliasName aliasName15;
									object[] treeArray_16 = new object[2];
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									string var_0 = "";
									string var_1 = "";
									string var_2 = "";
									string var_3 = "";
									string var_4 = "";
									string var_5 = "";
									string var_6 = "";
									string var_7 = "";
									string var_8 = "";
									string var_9 = "";
									string var_10 = "";
									string var_11 = "";
									string var_12 = "";
									string var_13 = "";
									string var_14 = "";
									string var_15 = "";
									string var_16 = "";
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									object Get_10()
									{
										return success ? var_10 : null;
									}
									
									object Get_11()
									{
										return success ? var_11 : null;
									}
									
									object Get_12()
									{
										return success ? var_12 : null;
									}
									
									object Get_13()
									{
										return success ? var_13 : null;
									}
									
									object Get_14()
									{
										return success ? var_14 : null;
									}
									
									object Get_15()
									{
										return success ? var_15 : null;
									}
									
									object Get_16()
									{
										return success ? var_16 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel18 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel18.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Formula.Recursive, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
							{
							
								internal CategoryObject()
								{
									proxyFactory = this;
									vars = new Dictionary<object, object>()
									{
										{'a', new object[] {(System.Boolean)(false),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"¬\" S=\"¬\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Boolean)(false)}}
										,{'b', new object[] {(System.Double)(0),"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"¬\" S=\"¬\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",(System.Boolean)(true)}}
									};
							
									aliases = new Dictionary<object, object>()
									{
									};
							
									externalAls = new Dictionary<object, object>()
									{
									};
							
									pars = new Dictionary<object, object>()
									{
										{'x', "Condition ATIS.Formula_1"}
									};
							
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
								{
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
									FormulaEditor.Interfaces.ITreeCollection f = this;
									FormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);
									return new Calculation(trees, checkValue, dataPerformerFormula);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public bool Success { get => success; }
									
									public void Update()
									{
										success = true;
										variable = measurement0.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = !var_1;
										var_3 = (var_0) & (var_2);
										variable = measurement4.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_4 = (bool)variable;
										var_5 = (var_0) & (var_4);
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (bool)variable;
										var_7 = !var_6;
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = (var_5) ? (var_7) : (var_8);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement4 = dataPerformerFormula.ToMeasurement(trees[4]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
										dictionary[trees[0]] = Get_0;
										dictionary[trees[1]] = Get_1;
										dictionary[trees[2]] = Get_2;
										dictionary[trees[3]] = Get_3;
										dictionary[trees[4]] = Get_4;
										dictionary[trees[5]] = Get_5;
										dictionary[trees[6]] = Get_6;
										dictionary[trees[7]] = Get_7;
										dictionary[trees[8]] = Get_8;
										dictionary[trees[9]] = Get_9;
									}
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement4;
									DataPerformer.Interfaces.IMeasurement measurement6;
									DataPerformer.Interfaces.IMeasurement measurement8;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									bool var_0 = false;
									bool var_1 = false;
									bool var_2 = false;
									bool var_3 = false;
									bool var_4 = false;
									bool var_5 = false;
									bool var_6 = false;
									bool var_7 = false;
									bool var_8 = false;
									bool var_9 = false;
									
									object Get_0()
									{
										return success ? var_0 : null;
									}
									
									object Get_1()
									{
										return success ? var_1 : null;
									}
									
									object Get_2()
									{
										return success ? var_2 : null;
									}
									
									object Get_3()
									{
										return success ? var_3 : null;
									}
									
									object Get_4()
									{
										return success ? var_4 : null;
									}
									
									object Get_5()
									{
										return success ? var_5 : null;
									}
									
									object Get_6()
									{
										return success ? var_6 : null;
									}
									
									object Get_7()
									{
										return success ? var_7 : null;
									}
									
									object Get_8()
									{
										return success ? var_8 : null;
									}
									
									object Get_9()
									{
										return success ? var_9 : null;
									}
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
								}
							}
						}
					
						internal class OblectLabel19 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel19(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel19.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : SoundService.MultiSound
							{
								internal CategoryObject()
								{
									conditionName = "Condition ATIS.Formula_1";
									soundName = "ATIS Calculation.Formula_1";
								}
							}
						}
					
						internal class OblectLabel20 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel20(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel20.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : DataPerformer.Portable.DataConsumer
							{
							internal CategoryObject() : base(0)
							{
							}
							}
						}
					
						internal class OblectLabel21 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel21(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel21.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : Event.Portable.Events.Timer
							{
							internal CategoryObject()
							{
							var ts = this as Event.Interfaces.ITimerEvent;
							ts.TimeSpan = TimeSpan.FromTicks(100000);
							}
							}
						}
					
						internal class ArrowLabel0 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel0.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel1 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel1.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel2 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel2(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel2.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel3 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel3(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel3.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel4 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel4.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel5 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel5.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel6 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel6(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel6.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel7 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel7.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel8 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel8.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel9 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel9.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel10 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel10.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel11 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel11(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel11.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel12 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel12.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel13 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel13.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel14 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel14.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel15 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel15(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel15.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel16 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel16.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel17 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel17.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel18 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel18.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel19 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel19(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel19.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel20 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel20(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel20.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel21 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel21(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel21.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel22 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel22(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel22.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel23 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel23(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel23.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel24 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel24(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel24.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel25 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel25(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel25.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel26 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel26(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel26.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel27 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel27(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel27.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel28 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel28(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel28.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel29 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel29(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel29.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel30 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel30(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel30.CategoryArrow();
							}
					
							internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
							{
							}
						}
					
						internal class ArrowLabel31 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel31(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel31.CategoryArrow();
							}
					
							internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
							{
							}
						}
					
						internal class ArrowLabel32 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel32(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel32.CategoryArrow();
							}
					
							internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
							{
							}
						}
					
						internal class ArrowLabel33 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel33(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel33.CategoryArrow();
							}
					
							internal class CategoryArrow : Event.Portable.Arrows.EventLink
							{
							}
						}
					
						internal class ArrowLabel34 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel34(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel34.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
						internal class ArrowLabel35 : Diagram.UI.Labels.PureArrowLabel
						{
							internal ArrowLabel35(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								arrow = new ArrowLabel35.CategoryArrow();
							}
					
							internal class CategoryArrow : DataPerformer.Portable.DataLink
							{
							}
						}
					
				
					CategoryTheory.ICategoryObject obj;
				
					internal Desktop(CategoryTheory.ICategoryObject obj) : this()
					{
						this.obj = obj;
					}
				
					public override Diagram.UI.Interfaces.IDesktop Root
					{
						get
						{
							Diagram.UI.Labels.INamedComponent nc = obj.Object as Diagram.UI.Labels.INamedComponent;
						return nc.Desktop.Root;
						}
					}
				}
				}
			}
		
			internal class OblectLabel2 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel2(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel2.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.Timer
				{
				internal CategoryObject()
				{
				var ts = this as Event.Interfaces.ITimerEvent;
				ts.TimeSpan = TimeSpan.FromTicks(100000);
				}
				}
			}
		
			internal class OblectLabel3 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel3(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel3.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.EmptyCamera
				{
					internal CategoryObject()
					{
						near = 10000;
						far = 400000;
						fieldOfView = 40;
						width = 0;
						height = 0;
						Scale = 300;
					}
				}
			}
		
			internal class OblectLabel4 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel4.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				16000
				, 61000
				, -1500
						};
				
						relativeQuaternion = new double[]
						{
				0
				, 0
				, 0.70710678118654757
				, 0.70710678118654746
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel5 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel5.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.SerializablePosition
				{
					internal CategoryObject()
					{
						double[,] size = null;
						size = new double[,]
						{
							{-15.00006, -0.4933044, -11.28006 },
							{13.76094, 5.465994, 11.27994 }
						};
						Parameters = new  Motion6D.Portable.EmptyCameraConsumer(this, size);
					}
				}
			}
		
			internal class OblectLabel6 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel6(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel6.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.SerializablePosition
				{
					internal CategoryObject()
					{
						double[,] size = null;
						size = new double[,]
						{
							{-21063, 27.127, -25704 },
							{53295, 27.127, 19330 }
						};
						Parameters = new  Motion6D.Portable.EmptyCameraConsumer(this, size);
					}
				}
			}
		
			internal class OblectLabel7 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel7.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				0
				, 0
				, 0
						};
				
						relativeQuaternion = new double[]
						{
				1
				, 0
				, 0
				, 0
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel8 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel8.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
				{
				
					internal CategoryObject()
					{
						proxyFactory = this;
						feedback = new Dictionary<int, string>()
						{
						};
				
						formulaString = new string[]
						{
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"l\" S=\"l\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"x = Motion + Audio/Equations.x",
							"y = Motion + Audio/H,V.Formula_1"
						};
						parameters =new Dictionary<string, object>()
						{
							{"l", (double)100 },
							{"k", (double)10 }
						};
						operationNames = new Dictionary<System.Int32,System.String>()
						{
						};
						Init();
					}
				
					FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
					{
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
						FormulaEditor.Interfaces.ITreeCollection f = this;
						var t = 
							FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
						var tt = t.ToArray();
						return new Calculation(tt, checkValue, dataPerformerFormula);
					}
				
					internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
					{
						public bool Success { get => success; }
						
						public void Update()
						{
							success = true;
							variable = aliasName0.Value;
							if (checkValue(variable)) { success = false; return; }
							var_0 = (double)variable;
							variable = measurement1.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_1 = (double)variable;
							var_2 = (var_0) * (var_1);
							variable = aliasName3.Value;
							if (checkValue(variable)) { success = false; return; }
							var_3 = (double)variable;
							variable = measurement4.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_4 = (double)variable;
							var_5 = (var_3) * (var_4);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
							measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
							aliasName3 = dataPerformerFormula.ToAliasName(trees[3]);
							measurement4 = dataPerformerFormula.ToMeasurement(trees[4]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
							dictionary[trees[2]] = Get_2;
							dictionary[trees[3]] = Get_3;
							dictionary[trees[4]] = Get_4;
							dictionary[trees[5]] = Get_5;
							dictionary[trees[6]] = Get_6;
							dictionary[trees[7]] = Get_7;
						}
						
						public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
						
						Diagram.UI.Interfaces.IAliasName aliasName0;
						DataPerformer.Interfaces.IMeasurement measurement1;
						Diagram.UI.Interfaces.IAliasName aliasName3;
						DataPerformer.Interfaces.IMeasurement measurement4;
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						double var_1 = 0;
						double var_2 = 0;
						double var_3 = 0;
						double var_4 = 0;
						double var_5 = 0;
						double var_6 = 0;
						double var_7 = 1;
						
						object Get_0()
						{
							return success ? var_0 : null;
						}
						
						object Get_1()
						{
							return success ? var_1 : null;
						}
						
						object Get_2()
						{
							return success ? var_2 : null;
						}
						
						object Get_3()
						{
							return success ? var_3 : null;
						}
						
						object Get_4()
						{
							return success ? var_4 : null;
						}
						
						object Get_5()
						{
							return success ? var_5 : null;
						}
						
						object Get_6()
						{
							return success ? var_6 : null;
						}
						
						object Get_7()
						{
							return success ? var_7 : null;
						}
						
						Func<object, bool> checkValue = (o) => false;
						object variable;
						bool success = true;
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
					
					}
				}
			}
		
			internal class OblectLabel9 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel9.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				357
				, 0
				, -164
						};
				
						relativeQuaternion = new double[]
						{
				0.53970206235395057
				, -5.1548818575209616E-17
				, 0.84185609452619181
				, -3.3047220157749523E-17
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel10 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel10.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.ReferenceFrameDataBase
				{
				
					internal CategoryObject()
					{
						parameters = new List<string>()
						{
				"Motion.Formula_1",
				"Motion.Formula_2",
				"Motion.Formula_3",
				"Motion.Formula_4",
				"Motion.Formula_3",
				"Motion.Formula_3",
				"Motion.Formula_3"
						};
					}
				
				}
			}
		
			internal class OblectLabel11 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel11(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel11.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				-0.10000000000000001
				, 0
				, 0
						};
				
						relativeQuaternion = new double[]
						{
				0.70710678118654757
				, -0
				, -0.70710678118654746
				, 0
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel12 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel12.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				0
				, 200
				, 0
						};
				
						relativeQuaternion = new double[]
						{
				1
				, 0
				, 0
				, 0
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel13 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel13.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				-15700
				, 0
				, 1500
						};
				
						relativeQuaternion = new double[]
						{
				1
				, 0
				, 0
				, 0
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel14 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel14.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				3500
				, 4000
				, 500
						};
				
						relativeQuaternion = new double[]
						{
				0.64391470861216948
				, -0.29218803540341076
				, 0.64391470861222289
				, 0.29218803540329341
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel15 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel15(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel15.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.EmptyCamera
				{
					internal CategoryObject()
					{
						near = 150;
						far = 40000;
						fieldOfView = 40;
						width = 0;
						height = 0;
						Scale = 50;
					}
				}
			}
		
			internal class OblectLabel16 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel16.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				250000
				, 1000
				, 80000
						};
				
						relativeQuaternion = new double[]
						{
				0.92385643869831202
				, -0.0065323249265471775
				, 0.38267386659454838
				, 0.002705777578403607
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel17 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel17.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.EmptyCamera
				{
					internal CategoryObject()
					{
						near = 50000;
						far = 300000;
						fieldOfView = 60;
						width = 0;
						height = 0;
						Scale = 1000;
					}
				}
			}
		
			internal class OblectLabel18 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel18.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
				}
				}
			}
		
			internal class ArrowLabel0 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel0.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel1 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel1.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel2 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel2(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel2.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel3 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel3(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel3.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel4 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel4.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel5 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel5.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel6 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel6(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel6.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel7 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel7.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel8 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel8.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel9 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel9.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel10 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel10.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel11 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel11(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel11.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel12 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel12.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel13 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel13.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.VisibleConsumerLink
				{
					internal CategoryArrow()
					{
				
					}
				}
			}
		
			internal class ArrowLabel14 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel14.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel15 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel15(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel15.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.VisibleConsumerLink
				{
					internal CategoryArrow()
					{
				
					}
				}
			}
		
			internal class ArrowLabel16 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel16.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.VisibleConsumerLink
				{
					internal CategoryArrow()
					{
				
					}
				}
			}
		
			internal class ArrowLabel17 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel17.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel18 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel18.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.VisibleConsumerLink
				{
					internal CategoryArrow()
					{
				
					}
				}
			}
		
			internal class ArrowLabel19 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel19(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel19.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.VisibleConsumerLink
				{
					internal CategoryArrow()
					{
				
					}
				}
			}
		
			internal class ArrowLabel20 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel20(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel20.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel21 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel21(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel21.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel22 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel22(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel22.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel23 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel23(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel23.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel24 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel24(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel24.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel25 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel25(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel25.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel26 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel26(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel26.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel27 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel27(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel27.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel28 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel28(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel28.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel29 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel29(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel29.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.BelongsToCollectionPortable
				{
				}
			}
		
			internal class ArrowLabel30 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel30(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel30.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel31 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel31(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel31.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel32 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel32(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel32.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel33 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel33(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel33.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel34 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel34(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel34.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel35 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel35(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel35.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel36 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel36(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel36.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel37 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel37(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel37.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
		}
		
	}
}
