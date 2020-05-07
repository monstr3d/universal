using System;
using System.Collections.Generic;
using System.Text;


namespace GeneratedProject
{
	public static class StaticExtensionGeneratedProject
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new IntrenalDesktop(); }

		internal class IntrenalDesktop : Diagram.UI.PureDesktop
		{
			internal IntrenalDesktop()
			{
				objects.Add(new IntrenalDesktop.OblectLabel0("Motion", this));
				objects.Add(new IntrenalDesktop.OblectLabel1("Plane frame", this));
				objects.Add(new IntrenalDesktop.OblectLabel2("Forward frame", this));
				objects.Add(new IntrenalDesktop.OblectLabel3("Consumer", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)1;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)1;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
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
						formulaString = new string[]
						{
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"(\" S=\"(\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\")\" S=\")\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"s\" S=\"sin\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"(\" S=\"(\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\")\" S=\")\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"(\" S=\"(\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\")\" S=\")\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"(\" S=\"(\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\")\" S=\")\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"*\" S=\"∙\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"(\" S=\"(\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\")\" S=\")\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"4\" S=\"4\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\".\" S=\".\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"7\" S=\"7\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>            </S>          </F>          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"7\" S=\"7\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>            </S>          </F>          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"arctg\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"3\" S=\"3\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>            </S>          </F>          <F />        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"%\" S=\"π\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"t = Time"
						};
						parameters =new Dictionary<string, object>()
						{
						};
						operationNames = new Dictionary<System.Int32,System.String>()
						{
						};
						Init();
					}
				
					FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
					{
						FormulaEditor.Interfaces.ITreeCollection f = this;
						return new Calculation(f.Trees);
					}
				
					internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
					{
						public void Update()
						{
							var_0 = (double)measurement0.Parameter();
							var_2 = (var_0) - (var_1);
							var_5 = (var_3) / (var_4);
							var_7 = (var_0) - (var_6);
							var_9 = (var_7) / (var_8);
							var_10 = Math.Atan(var_9);
							var_11 = (var_5) - (var_10);
							var_13 = (var_11) / (var_12);
							var_14 = (var_2) * (var_13);
							var_17 = (var_15) / (var_16);
							var_20 = (var_0) - (var_19);
							var_22 = (var_20) / (var_21);
							var_23 = (var_18) * (var_22);
							var_24 = Math.Sin(var_23);
							var_25 = (var_17) * (var_24);
							var_28 = (var_0) - (var_27);
							var_30 = (var_28) / (var_29);
							var_31 = Math.Atan(var_30);
							var_33 = (var_0) - (var_32);
							var_35 = (var_33) / (var_34);
							var_36 = Math.Atan(var_35);
							var_37 = (var_31) - (var_36);
							var_38 = (var_26) + (var_37);
							var_40 = (var_38) / (var_39);
							var_41 = (var_25) * (var_40);
							var_42 = (var_14) + (var_41);
							var_44 = (var_43) - (var_0);
							var_47 = (var_45) / (var_46);
							var_49 = (var_0) - (var_48);
							var_51 = (var_49) / (var_50);
							var_52 = Math.Atan(var_51);
							var_53 = (var_47) + (var_52);
							var_55 = (var_53) / (var_54);
							var_56 = (var_44) * (var_55);
							var_57 = (var_42) + (var_56);
							var_61 = (var_59) / (var_60);
							var_63 = (var_0) - (var_62);
							var_65 = (var_63) / (var_64);
							var_66 = Math.Atan(var_65);
							var_68 = (var_0) - (var_67);
							var_70 = (var_68) / (var_69);
							var_71 = Math.Atan(var_70);
							var_72 = (var_66) - (var_71);
							var_74 = (var_72) / (var_73);
							var_75 = (var_61) * (var_74);
							var_78 = (var_0) - (var_77);
							var_80 = (var_78) / (var_79);
							var_81 = (var_76) * (var_80);
							var_82 = Math.Cos(var_81);
							var_84 = (var_82) - (var_83);
							var_85 = (var_75) * (var_84);
							var_86 = (var_58) - (var_85);
							var_89 = (var_87) / (var_88);
							var_92 = (var_90) / (var_91);
							var_94 = (var_0) - (var_93);
							var_96 = (var_94) / (var_95);
							var_97 = Math.Atan(var_96);
							var_98 = (var_92) + (var_97);
							var_100 = (var_98) / (var_99);
							var_101 = (var_89) * (var_100);
							var_102 = (var_86) + (var_101);
							var_106 = (var_104) / (var_105);
							var_108 = (var_0) - (var_107);
							var_110 = (var_108) / (var_109);
							var_111 = Math.Atan(var_110);
							var_112 = (var_106) - (var_111);
							var_114 = (var_112) / (var_113);
							var_118 = (var_116) / (var_117);
							var_120 = (var_0) - (var_119);
							var_122 = (var_120) / (var_121);
							var_123 = Math.Atan(var_122);
							var_124 = (var_118) + (var_123);
							var_126 = (var_124) / (var_125);
							var_127 = -(var_126);
							var_129 = (var_0) - (var_128);
							var_131 = (var_129) / (var_130);
							var_132 = Math.Atan(var_131);
							var_134 = (var_0) - (var_133);
							var_136 = (var_134) / (var_135);
							var_137 = Math.Atan(var_136);
							var_138 = (var_132) - (var_137);
							var_140 = (var_138) / (var_139);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
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
							dictionary[trees[34]] = Get_34;
							dictionary[trees[35]] = Get_35;
							dictionary[trees[36]] = Get_36;
							dictionary[trees[37]] = Get_37;
							dictionary[trees[38]] = Get_38;
							dictionary[trees[39]] = Get_39;
							dictionary[trees[40]] = Get_40;
							dictionary[trees[41]] = Get_41;
							dictionary[trees[42]] = Get_42;
							dictionary[trees[43]] = Get_43;
							dictionary[trees[44]] = Get_44;
							dictionary[trees[45]] = Get_45;
							dictionary[trees[46]] = Get_46;
							dictionary[trees[47]] = Get_47;
							dictionary[trees[48]] = Get_48;
							dictionary[trees[49]] = Get_49;
							dictionary[trees[50]] = Get_50;
							dictionary[trees[51]] = Get_51;
							dictionary[trees[52]] = Get_52;
							dictionary[trees[53]] = Get_53;
							dictionary[trees[54]] = Get_54;
							dictionary[trees[55]] = Get_55;
							dictionary[trees[56]] = Get_56;
							dictionary[trees[57]] = Get_57;
							dictionary[trees[58]] = Get_58;
							dictionary[trees[59]] = Get_59;
							dictionary[trees[60]] = Get_60;
							dictionary[trees[61]] = Get_61;
							dictionary[trees[62]] = Get_62;
							dictionary[trees[63]] = Get_63;
							dictionary[trees[64]] = Get_64;
							dictionary[trees[65]] = Get_65;
							dictionary[trees[66]] = Get_66;
							dictionary[trees[67]] = Get_67;
							dictionary[trees[68]] = Get_68;
							dictionary[trees[69]] = Get_69;
							dictionary[trees[70]] = Get_70;
							dictionary[trees[71]] = Get_71;
							dictionary[trees[72]] = Get_72;
							dictionary[trees[73]] = Get_73;
							dictionary[trees[74]] = Get_74;
							dictionary[trees[75]] = Get_75;
							dictionary[trees[76]] = Get_76;
							dictionary[trees[77]] = Get_77;
							dictionary[trees[78]] = Get_78;
							dictionary[trees[79]] = Get_79;
							dictionary[trees[80]] = Get_80;
							dictionary[trees[81]] = Get_81;
							dictionary[trees[82]] = Get_82;
							dictionary[trees[83]] = Get_83;
							dictionary[trees[84]] = Get_84;
							dictionary[trees[85]] = Get_85;
							dictionary[trees[86]] = Get_86;
							dictionary[trees[87]] = Get_87;
							dictionary[trees[88]] = Get_88;
							dictionary[trees[89]] = Get_89;
							dictionary[trees[90]] = Get_90;
							dictionary[trees[91]] = Get_91;
							dictionary[trees[92]] = Get_92;
							dictionary[trees[93]] = Get_93;
							dictionary[trees[94]] = Get_94;
							dictionary[trees[95]] = Get_95;
							dictionary[trees[96]] = Get_96;
							dictionary[trees[97]] = Get_97;
							dictionary[trees[98]] = Get_98;
							dictionary[trees[99]] = Get_99;
							dictionary[trees[100]] = Get_100;
							dictionary[trees[101]] = Get_101;
							dictionary[trees[102]] = Get_102;
							dictionary[trees[103]] = Get_103;
							dictionary[trees[104]] = Get_104;
							dictionary[trees[105]] = Get_105;
							dictionary[trees[106]] = Get_106;
							dictionary[trees[107]] = Get_107;
							dictionary[trees[108]] = Get_108;
							dictionary[trees[109]] = Get_109;
							dictionary[trees[110]] = Get_110;
							dictionary[trees[111]] = Get_111;
							dictionary[trees[112]] = Get_112;
							dictionary[trees[113]] = Get_113;
							dictionary[trees[114]] = Get_114;
							dictionary[trees[115]] = Get_115;
							dictionary[trees[116]] = Get_116;
							dictionary[trees[117]] = Get_117;
							dictionary[trees[118]] = Get_118;
							dictionary[trees[119]] = Get_119;
							dictionary[trees[120]] = Get_120;
							dictionary[trees[121]] = Get_121;
							dictionary[trees[122]] = Get_122;
							dictionary[trees[123]] = Get_123;
							dictionary[trees[124]] = Get_124;
							dictionary[trees[125]] = Get_125;
							dictionary[trees[126]] = Get_126;
							dictionary[trees[127]] = Get_127;
							dictionary[trees[128]] = Get_128;
							dictionary[trees[129]] = Get_129;
							dictionary[trees[130]] = Get_130;
							dictionary[trees[131]] = Get_131;
							dictionary[trees[132]] = Get_132;
							dictionary[trees[133]] = Get_133;
							dictionary[trees[134]] = Get_134;
							dictionary[trees[135]] = Get_135;
							dictionary[trees[136]] = Get_136;
							dictionary[trees[137]] = Get_137;
							dictionary[trees[138]] = Get_138;
							dictionary[trees[139]] = Get_139;
							dictionary[trees[140]] = Get_140;
						}
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						DataPerformer.Interfaces.IMeasurement measurement0;
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						double var_1 = 10;
						double var_2 = 0;
						double var_3 = Math.PI;
						double var_4 = 2;
						double var_5 = 0;
						double var_6 = 10;
						double var_7 = 0;
						double var_8 = 0.1;
						double var_9 = 0;
						double var_10 = 0;
						double var_11 = 0;
						double var_12 = Math.PI;
						double var_13 = 0;
						double var_14 = 0;
						double var_15 = 120;
						double var_16 = Math.PI;
						double var_17 = 0;
						double var_18 = Math.PI;
						double var_19 = 10;
						double var_20 = 0;
						double var_21 = 120;
						double var_22 = 0;
						double var_23 = 0;
						double var_24 = 0;
						double var_25 = 0;
						double var_26 = Math.PI;
						double var_27 = 10;
						double var_28 = 0;
						double var_29 = 0.1;
						double var_30 = 0;
						double var_31 = 0;
						double var_32 = 130;
						double var_33 = 0;
						double var_34 = 0.1;
						double var_35 = 0;
						double var_36 = 0;
						double var_37 = 0;
						double var_38 = 0;
						double var_39 = Math.PI;
						double var_40 = 0;
						double var_41 = 0;
						double var_42 = 0;
						double var_43 = 130;
						double var_44 = 0;
						double var_45 = Math.PI;
						double var_46 = 2;
						double var_47 = 0;
						double var_48 = 130;
						double var_49 = 0;
						double var_50 = 0.1;
						double var_51 = 0;
						double var_52 = 0;
						double var_53 = 0;
						double var_54 = Math.PI;
						double var_55 = 0;
						double var_56 = 0;
						double var_57 = 0;
						double var_58 = 100;
						double var_59 = 120;
						double var_60 = Math.PI;
						double var_61 = 0;
						double var_62 = 10;
						double var_63 = 0;
						double var_64 = 0.1;
						double var_65 = 0;
						double var_66 = 0;
						double var_67 = 130;
						double var_68 = 0;
						double var_69 = 0.1;
						double var_70 = 0;
						double var_71 = 0;
						double var_72 = 0;
						double var_73 = Math.PI;
						double var_74 = 0;
						double var_75 = 0;
						double var_76 = Math.PI;
						double var_77 = 10;
						double var_78 = 0;
						double var_79 = 120;
						double var_80 = 0;
						double var_81 = 0;
						double var_82 = 0;
						double var_83 = 1;
						double var_84 = 0;
						double var_85 = 0;
						double var_86 = 0;
						double var_87 = 240;
						double var_88 = Math.PI;
						double var_89 = 0;
						double var_90 = Math.PI;
						double var_91 = 2;
						double var_92 = 0;
						double var_93 = 130;
						double var_94 = 0;
						double var_95 = 0.1;
						double var_96 = 0;
						double var_97 = 0;
						double var_98 = 0;
						double var_99 = Math.PI;
						double var_100 = 0;
						double var_101 = 0;
						double var_102 = 0;
						double var_103 = 0;
						double var_104 = Math.PI;
						double var_105 = 2;
						double var_106 = 0;
						double var_107 = 70;
						double var_108 = 0;
						double var_109 = 20;
						double var_110 = 0;
						double var_111 = 0;
						double var_112 = 0;
						double var_113 = Math.PI;
						double var_114 = 0;
						double var_115 = 0;
						double var_116 = Math.PI;
						double var_117 = 2;
						double var_118 = 0;
						double var_119 = 130;
						double var_120 = 0;
						double var_121 = 10;
						double var_122 = 0;
						double var_123 = 0;
						double var_124 = 0;
						double var_125 = Math.PI;
						double var_126 = 0;
						double var_127 = 0;
						double var_128 = 70;
						double var_129 = 0;
						double var_130 = 20;
						double var_131 = 0;
						double var_132 = 0;
						double var_133 = 130;
						double var_134 = 0;
						double var_135 = 10;
						double var_136 = 0;
						double var_137 = 0;
						double var_138 = 0;
						double var_139 = Math.PI;
						double var_140 = 0;
						
						object Get_0()
						{
							return var_0;
						}
						
						object Get_1()
						{
							return var_1;
						}
						
						object Get_2()
						{
							return var_2;
						}
						
						object Get_3()
						{
							return var_3;
						}
						
						object Get_4()
						{
							return var_4;
						}
						
						object Get_5()
						{
							return var_5;
						}
						
						object Get_6()
						{
							return var_6;
						}
						
						object Get_7()
						{
							return var_7;
						}
						
						object Get_8()
						{
							return var_8;
						}
						
						object Get_9()
						{
							return var_9;
						}
						
						object Get_10()
						{
							return var_10;
						}
						
						object Get_11()
						{
							return var_11;
						}
						
						object Get_12()
						{
							return var_12;
						}
						
						object Get_13()
						{
							return var_13;
						}
						
						object Get_14()
						{
							return var_14;
						}
						
						object Get_15()
						{
							return var_15;
						}
						
						object Get_16()
						{
							return var_16;
						}
						
						object Get_17()
						{
							return var_17;
						}
						
						object Get_18()
						{
							return var_18;
						}
						
						object Get_19()
						{
							return var_19;
						}
						
						object Get_20()
						{
							return var_20;
						}
						
						object Get_21()
						{
							return var_21;
						}
						
						object Get_22()
						{
							return var_22;
						}
						
						object Get_23()
						{
							return var_23;
						}
						
						object Get_24()
						{
							return var_24;
						}
						
						object Get_25()
						{
							return var_25;
						}
						
						object Get_26()
						{
							return var_26;
						}
						
						object Get_27()
						{
							return var_27;
						}
						
						object Get_28()
						{
							return var_28;
						}
						
						object Get_29()
						{
							return var_29;
						}
						
						object Get_30()
						{
							return var_30;
						}
						
						object Get_31()
						{
							return var_31;
						}
						
						object Get_32()
						{
							return var_32;
						}
						
						object Get_33()
						{
							return var_33;
						}
						
						object Get_34()
						{
							return var_34;
						}
						
						object Get_35()
						{
							return var_35;
						}
						
						object Get_36()
						{
							return var_36;
						}
						
						object Get_37()
						{
							return var_37;
						}
						
						object Get_38()
						{
							return var_38;
						}
						
						object Get_39()
						{
							return var_39;
						}
						
						object Get_40()
						{
							return var_40;
						}
						
						object Get_41()
						{
							return var_41;
						}
						
						object Get_42()
						{
							return var_42;
						}
						
						object Get_43()
						{
							return var_43;
						}
						
						object Get_44()
						{
							return var_44;
						}
						
						object Get_45()
						{
							return var_45;
						}
						
						object Get_46()
						{
							return var_46;
						}
						
						object Get_47()
						{
							return var_47;
						}
						
						object Get_48()
						{
							return var_48;
						}
						
						object Get_49()
						{
							return var_49;
						}
						
						object Get_50()
						{
							return var_50;
						}
						
						object Get_51()
						{
							return var_51;
						}
						
						object Get_52()
						{
							return var_52;
						}
						
						object Get_53()
						{
							return var_53;
						}
						
						object Get_54()
						{
							return var_54;
						}
						
						object Get_55()
						{
							return var_55;
						}
						
						object Get_56()
						{
							return var_56;
						}
						
						object Get_57()
						{
							return var_57;
						}
						
						object Get_58()
						{
							return var_58;
						}
						
						object Get_59()
						{
							return var_59;
						}
						
						object Get_60()
						{
							return var_60;
						}
						
						object Get_61()
						{
							return var_61;
						}
						
						object Get_62()
						{
							return var_62;
						}
						
						object Get_63()
						{
							return var_63;
						}
						
						object Get_64()
						{
							return var_64;
						}
						
						object Get_65()
						{
							return var_65;
						}
						
						object Get_66()
						{
							return var_66;
						}
						
						object Get_67()
						{
							return var_67;
						}
						
						object Get_68()
						{
							return var_68;
						}
						
						object Get_69()
						{
							return var_69;
						}
						
						object Get_70()
						{
							return var_70;
						}
						
						object Get_71()
						{
							return var_71;
						}
						
						object Get_72()
						{
							return var_72;
						}
						
						object Get_73()
						{
							return var_73;
						}
						
						object Get_74()
						{
							return var_74;
						}
						
						object Get_75()
						{
							return var_75;
						}
						
						object Get_76()
						{
							return var_76;
						}
						
						object Get_77()
						{
							return var_77;
						}
						
						object Get_78()
						{
							return var_78;
						}
						
						object Get_79()
						{
							return var_79;
						}
						
						object Get_80()
						{
							return var_80;
						}
						
						object Get_81()
						{
							return var_81;
						}
						
						object Get_82()
						{
							return var_82;
						}
						
						object Get_83()
						{
							return var_83;
						}
						
						object Get_84()
						{
							return var_84;
						}
						
						object Get_85()
						{
							return var_85;
						}
						
						object Get_86()
						{
							return var_86;
						}
						
						object Get_87()
						{
							return var_87;
						}
						
						object Get_88()
						{
							return var_88;
						}
						
						object Get_89()
						{
							return var_89;
						}
						
						object Get_90()
						{
							return var_90;
						}
						
						object Get_91()
						{
							return var_91;
						}
						
						object Get_92()
						{
							return var_92;
						}
						
						object Get_93()
						{
							return var_93;
						}
						
						object Get_94()
						{
							return var_94;
						}
						
						object Get_95()
						{
							return var_95;
						}
						
						object Get_96()
						{
							return var_96;
						}
						
						object Get_97()
						{
							return var_97;
						}
						
						object Get_98()
						{
							return var_98;
						}
						
						object Get_99()
						{
							return var_99;
						}
						
						object Get_100()
						{
							return var_100;
						}
						
						object Get_101()
						{
							return var_101;
						}
						
						object Get_102()
						{
							return var_102;
						}
						
						object Get_103()
						{
							return var_103;
						}
						
						object Get_104()
						{
							return var_104;
						}
						
						object Get_105()
						{
							return var_105;
						}
						
						object Get_106()
						{
							return var_106;
						}
						
						object Get_107()
						{
							return var_107;
						}
						
						object Get_108()
						{
							return var_108;
						}
						
						object Get_109()
						{
							return var_109;
						}
						
						object Get_110()
						{
							return var_110;
						}
						
						object Get_111()
						{
							return var_111;
						}
						
						object Get_112()
						{
							return var_112;
						}
						
						object Get_113()
						{
							return var_113;
						}
						
						object Get_114()
						{
							return var_114;
						}
						
						object Get_115()
						{
							return var_115;
						}
						
						object Get_116()
						{
							return var_116;
						}
						
						object Get_117()
						{
							return var_117;
						}
						
						object Get_118()
						{
							return var_118;
						}
						
						object Get_119()
						{
							return var_119;
						}
						
						object Get_120()
						{
							return var_120;
						}
						
						object Get_121()
						{
							return var_121;
						}
						
						object Get_122()
						{
							return var_122;
						}
						
						object Get_123()
						{
							return var_123;
						}
						
						object Get_124()
						{
							return var_124;
						}
						
						object Get_125()
						{
							return var_125;
						}
						
						object Get_126()
						{
							return var_126;
						}
						
						object Get_127()
						{
							return var_127;
						}
						
						object Get_128()
						{
							return var_128;
						}
						
						object Get_129()
						{
							return var_129;
						}
						
						object Get_130()
						{
							return var_130;
						}
						
						object Get_131()
						{
							return var_131;
						}
						
						object Get_132()
						{
							return var_132;
						}
						
						object Get_133()
						{
							return var_133;
						}
						
						object Get_134()
						{
							return var_134;
						}
						
						object Get_135()
						{
							return var_135;
						}
						
						object Get_136()
						{
							return var_136;
						}
						
						object Get_137()
						{
							return var_137;
						}
						
						object Get_138()
						{
							return var_138;
						}
						
						object Get_139()
						{
							return var_139;
						}
						
						object Get_140()
						{
							return var_140;
						}
					
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
				"Motion.Formula_5",
				"Motion.Formula_6",
				"Motion.Formula_7"
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
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				150
				, 140
				, 0
						};
				
						relativeQuaternion = new double[]
						{
				0.70710678118654757
				, 0
				, 0.70710678118654746
				, 0
						};
				
						isSerialized = true;
						Init();
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
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
		}
		
	}
}
