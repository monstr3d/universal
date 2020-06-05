using System;
using System.Collections.Generic;
using System.Linq;
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
				objects.Add(new IntrenalDesktop.OblectLabel0("Chart", this));
				objects.Add(new IntrenalDesktop.OblectLabel1("Regression formula", this));
				objects.Add(new IntrenalDesktop.OblectLabel2("Regression", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)1;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)0;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this); 
			}
		
			internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel0.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Portable.SeriesBase
				{
					internal CategoryObject()
					{
						points = new List<double[]>()
						{
							new double[] { 0, 2.0043971445315503},
							new double[] { 0.001, 2.002429878371998},
							new double[] { 0.002, 2.0012996842847945},
							new double[] { 0.0030000000000000001, 2.0034269572737671},
							new double[] { 0.0040000000000000001, 2.002969506506624},
							new double[] { 0.0050000000000000001, 2.0023121397220205},
							new double[] { 0.0060000000000000001, 2.0031127101776383},
							new double[] { 0.0070000000000000001, 2.0019552837636909},
							new double[] { 0.0080000000000000002, 2.0056970382335773},
							new double[] { 0.0090000000000000011, 2.0053749358398916},
							new double[] { 0.01, 2.0028213487711231},
							new double[] { 0.010999999999999999, 2.0061039078258593},
							new double[] { 0.012, 2.0055941582385035},
							new double[] { 0.013000000000000001, 2.0059671944383073},
							new double[] { 0.014, 2.0055102713339923},
							new double[] { 0.014999999999999999, 2.0044216300602904},
							new double[] { 0.016, 2.0021664446865812},
							new double[] { 0.017000000000000001, 2.004561442675469},
							new double[] { 0.018000000000000002, 2.0047139480800724},
							new double[] { 0.019, 2.0029591301814262},
							new double[] { 0.02, 2.0040094209084702},
							new double[] { 0.021000000000000001, 2.0025648911344343},
							new double[] { 0.021999999999999999, 2.00352017519783},
							new double[] { 0.023, 2.0064272051930678},
							new double[] { 0.024, 2.0058315532941831},
							new double[] { 0.025000000000000001, 2.0028548882497903},
							new double[] { 0.026000000000000002, 2.0056527004099407},
							new double[] { 0.027, 2.0075333844741339},
							new double[] { 0.028000000000000001, 2.0058170306800593},
							new double[] { 0.029000000000000001, 2.0036712861222608},
							new double[] { 0.029999999999999999, 2.0076252565890806},
							new double[] { 0.031, 2.0032850369356856},
							new double[] { 0.032000000000000001, 2.005364116833646},
							new double[] { 0.033000000000000002, 2.0057991435448908},
							new double[] { 0.034000000000000002, 2.006887916080319},
							new double[] { 0.035000000000000003, 2.0077112064366083},
							new double[] { 0.036000000000000004, 2.0050048282229604},
							new double[] { 0.036999999999999998, 2.0067548799686734},
							new double[] { 0.037999999999999999, 2.0071593707587505},
							new double[] { 0.039, 2.0087356463329606},
							new double[] { 0.040000000000000001, 2.0050581688441236},
							new double[] { 0.041000000000000002, 2.0060560233261513},
							new double[] { 0.042000000000000003, 2.0053957028119482},
							new double[] { 0.043000000000000003, 2.008825642674815},
							new double[] { 0.043999999999999997, 2.00653655974306},
							new double[] { 0.044999999999999998, 2.0047275243651796},
							new double[] { 0.045999999999999999, 2.0064997454906837},
							new double[] { 0.047, 2.0059383304251641},
							new double[] { 0.048000000000000001, 2.0097344258951968},
							new double[] { 0.049000000000000002, 2.0063891251759296},
							new double[] { 0.050000000000000003, 2.0079805920993588},
							new double[] { 0.051000000000000004, 2.010267757545948},
							new double[] { 0.052000000000000005, 2.0062268734647781},
							new double[] { 0.052999999999999999, 2.00915248791673},
							new double[] { 0.053999999999999999, 2.008837576484821},
							new double[] { 0.055, 2.0097788533971164},
							new double[] { 0.056000000000000001, 2.006971603174168},
							new double[] { 0.057000000000000002, 2.0080498790917267},
							new double[] { 0.058000000000000003, 2.0108885039795839},
							new double[] { 0.059000000000000004, 2.0085236182568336},
							new double[] { 0.059999999999999998, 2.0101845393120796},
							new double[] { 0.060999999999999999, 2.0092207257035044},
							new double[] { 0.062, 2.009896153083631},
							new double[] { 0.063, 2.0109003521113169},
							new double[] { 0.064000000000000001, 2.0117411792508104},
							new double[] { 0.065000000000000002, 2.0086449118354368},
							new double[] { 0.066000000000000003, 2.0099656909922134},
							new double[] { 0.067000000000000004, 2.0091384146936129},
							new double[] { 0.068000000000000005, 2.0085403783579885},
							new double[] { 0.069000000000000006, 2.007378064897384},
							new double[] { 0.070000000000000007, 2.0091139018373303},
							new double[] { 0.071000000000000008, 2.0102269647179076},
							new double[] { 0.072000000000000008, 2.0123359719167189},
							new double[] { 0.072999999999999995, 2.0110309017471115},
							new double[] { 0.073999999999999996, 2.0080724613373029},
							new double[] { 0.074999999999999997, 2.0082439975823188},
							new double[] { 0.075999999999999998, 2.0125790883224859},
							new double[] { 0.076999999999999999, 2.0102239325230147},
							new double[] { 0.078, 2.010539745450008},
							new double[] { 0.079000000000000001, 2.0118730289290032},
							new double[] { 0.080000000000000002, 2.012244242759107},
							new double[] { 0.081000000000000003, 2.010723769984776},
							new double[] { 0.082000000000000003, 2.0089288585789369},
							new double[] { 0.083000000000000004, 2.0106785055041296},
							new double[] { 0.084000000000000005, 2.012062194022902},
							new double[] { 0.085000000000000006, 2.0138500990431325},
							new double[] { 0.086000000000000007, 2.0136720634709082},
							new double[] { 0.087000000000000008, 2.0129470289169165},
							new double[] { 0.087999999999999995, 2.0138186670600695},
							new double[] { 0.088999999999999996, 2.0140880626832027},
							new double[] { 0.089999999999999997, 2.01284070326244},
							new double[] { 0.090999999999999998, 2.0141783491312339},
							new double[] { 0.091999999999999998, 2.0132122759890896},
							new double[] { 0.092999999999999999, 2.011104352501917},
							new double[] { 0.094, 2.0111426070208811},
							new double[] { 0.095000000000000001, 2.0135520431406189},
							new double[] { 0.096000000000000002, 2.0139977702425202},
							new double[] { 0.097000000000000003, 2.0124567507006317},
							new double[] { 0.098000000000000004, 2.0151695634240046},
							new double[] { 0.099000000000000005, 2.011100647907623},
							new double[] { 0.10000000000000001, 2.0130949333729666},
							new double[] { 0.10100000000000001, 2.0158187307970707},
							new double[] { 0.10200000000000001, 2.0159798520671757},
							new double[] { 0.10300000000000001, 2.0160629609978131},
							new double[] { 0.10400000000000001, 2.0161067233385994},
							new double[] { 0.105, 2.0117102273814509},
							new double[] { 0.106, 2.0120136856292294},
							new double[] { 0.107, 2.0144033717176661},
							new double[] { 0.108, 2.0154131265794271},
							new double[] { 0.109, 2.0150525789025022},
							new double[] { 0.11, 2.0167848650746305},
							new double[] { 0.111, 2.0164590706511532},
							new double[] { 0.112, 2.0173480336417189},
							new double[] { 0.113, 2.0139800750505805},
							new double[] { 0.114, 2.0163708754977265},
							new double[] { 0.115, 2.0146793693273035},
							new double[] { 0.11600000000000001, 2.0156377671245678},
							new double[] { 0.11700000000000001, 2.0146910475795012},
							new double[] { 0.11800000000000001, 2.0144392580884145},
							new double[] { 0.11900000000000001, 2.0136200802076778},
							new double[] { 0.12, 2.0158299483645288},
							new double[] { 0.121, 2.0180040620752968},
							new double[] { 0.122, 2.0164336476335434},
							new double[] { 0.123, 2.0156949156747856},
							new double[] { 0.124, 2.0159088616349439},
							new double[] { 0.125, 2.0164361527060968},
							new double[] { 0.126, 2.0186445887288182},
							new double[] { 0.127, 2.0179910194148021},
							new double[] { 0.128, 2.0167773947262306},
							new double[] { 0.129, 2.0165394181966838},
							new double[] { 0.13, 2.0163953273397985},
							new double[] { 0.13100000000000001, 2.0174017376218543},
							new double[] { 0.13200000000000001, 2.0174642690990106},
							new double[] { 0.13300000000000001, 2.0169796975423853},
							new double[] { 0.13400000000000001, 2.0164495955560371},
							new double[] { 0.13500000000000001, 2.0192281119620361},
							new double[] { 0.13600000000000001, 2.0176778179176007},
							new double[] { 0.13700000000000001, 2.0159312975811239},
							new double[] { 0.13800000000000001, 2.0177688821655306},
							new double[] { 0.13900000000000001, 2.0186809666414511},
							new double[] { 0.14000000000000001, 2.0202975134139032},
							new double[] { 0.14100000000000001, 2.0178620917532419},
							new double[] { 0.14200000000000002, 2.0162598023374891},
							new double[] { 0.14300000000000002, 2.0176246881575675},
							new double[] { 0.14400000000000002, 2.0212946976085724},
							new double[] { 0.14499999999999999, 2.0205062326112873},
							new double[] { 0.14599999999999999, 2.0210882154895149},
							new double[] { 0.14699999999999999, 2.0186236009385095},
							new double[] { 0.14799999999999999, 2.0192585770041904},
							new double[] { 0.14899999999999999, 2.0211222376935778},
							new double[] { 0.14999999999999999, 2.0177073760160513},
							new double[] { 0.151, 2.0192341226630188},
							new double[] { 0.152, 2.0180793926122171},
							new double[] { 0.153, 2.0217460832163265},
							new double[] { 0.154, 2.0206021995430943},
							new double[] { 0.155, 2.0205574712976695},
							new double[] { 0.156, 2.0199869831635273},
							new double[] { 0.157, 2.0210223363923898},
							new double[] { 0.158, 2.0210271993628695},
							new double[] { 0.159, 2.0206795706325025},
							new double[] { 0.16, 2.019210738652633},
							new double[] { 0.161, 2.0203040662144276},
							new double[] { 0.16200000000000001, 2.0190438769914354},
							new double[] { 0.16300000000000001, 2.0204283083827432},
							new double[] { 0.16400000000000001, 2.0203487515627034},
							new double[] { 0.16500000000000001, 2.0212117274527763},
							new double[] { 0.16600000000000001, 2.0209607015521422},
							new double[] { 0.16700000000000001, 2.0224717360993334},
							new double[] { 0.16800000000000001, 2.0197715794945434},
							new double[] { 0.16900000000000001, 2.0245217635356907},
							new double[] { 0.17000000000000001, 2.0245186514097027},
							new double[] { 0.17100000000000001, 2.022361869543444},
							new double[] { 0.17200000000000001, 2.0247160654139709},
							new double[] { 0.17300000000000001, 2.0236908914469631},
							new double[] { 0.17400000000000002, 2.0213940667937749},
							new double[] { 0.17500000000000002, 2.0211784566112869},
							new double[] { 0.17599999999999999, 2.0250941597378076},
							new double[] { 0.17699999999999999, 2.0222983594759758},
							new double[] { 0.17799999999999999, 2.0230293180662136},
							new double[] { 0.17899999999999999, 2.0241716290236567},
							new double[] { 0.17999999999999999, 2.0242570372165822},
							new double[] { 0.18099999999999999, 2.0240703877903088},
							new double[] { 0.182, 2.0229223424106118},
							new double[] { 0.183, 2.0249857570326535},
							new double[] { 0.184, 2.0233035421806322},
							new double[] { 0.185, 2.0267738046767803},
							new double[] { 0.186, 2.024076245009637},
							new double[] { 0.187, 2.025613585882684},
							new double[] { 0.188, 2.0264145979992914},
							new double[] { 0.189, 2.0260711242583671},
							new double[] { 0.19, 2.0245622287985086},
							new double[] { 0.191, 2.0271188815252108},
							new double[] { 0.192, 2.0255099982182547},
							new double[] { 0.193, 2.0278379115330276},
							new double[] { 0.19400000000000001, 2.0253617279888183},
							new double[] { 0.19500000000000001, 2.0260280471994752},
							new double[] { 0.19600000000000001, 2.0249961147618065},
							new double[] { 0.19700000000000001, 2.0271528939547458},
							new double[] { 0.19800000000000001, 2.0237410365948643},
							new double[] { 0.19900000000000001, 2.0266919701557962},
							new double[] { 0.20000000000000001, 2.0262986310591451},
							new double[] { 0.20100000000000001, 2.0255138793901812},
							new double[] { 0.20200000000000001, 2.0258939214439655},
							new double[] { 0.20300000000000001, 2.0269234134684995},
							new double[] { 0.20400000000000001, 2.0289350862838749},
							new double[] { 0.20500000000000002, 2.0278221064726076},
							new double[] { 0.20600000000000002, 2.0271399572490481},
							new double[] { 0.20700000000000002, 2.0271559011652536},
							new double[] { 0.20800000000000002, 2.0282651164225518},
							new double[] { 0.20899999999999999, 2.0274827429318072},
							new double[] { 0.20999999999999999, 2.0286684115598623},
							new double[] { 0.21099999999999999, 2.0260400236875511},
							new double[] { 0.21199999999999999, 2.0264909183261763},
							new double[] { 0.21299999999999999, 2.0305001703392129},
							new double[] { 0.214, 2.0302140334159207},
							new double[] { 0.215, 2.0290789508623241},
							new double[] { 0.216, 2.026467623803816},
							new double[] { 0.217, 2.0282915199587817},
							new double[] { 0.218, 2.0315058662021106},
							new double[] { 0.219, 2.0281039468859232},
							new double[] { 0.22, 2.031812582443139},
							new double[] { 0.221, 2.0301725156694581},
							new double[] { 0.222, 2.0310310381000423},
							new double[] { 0.223, 2.0288230552361761},
							new double[] { 0.224, 2.0302310347371821},
							new double[] { 0.22500000000000001, 2.0278203698844921},
							new double[] { 0.22600000000000001, 2.0324217713251889},
							new double[] { 0.22700000000000001, 2.0325975538809429},
							new double[] { 0.22800000000000001, 2.0291982634581451},
							new double[] { 0.22900000000000001, 2.0313850195942993},
							new double[] { 0.23000000000000001, 2.0323514418494804},
							new double[] { 0.23100000000000001, 2.0292606657830614},
							new double[] { 0.23200000000000001, 2.0300272228811123},
							new double[] { 0.23300000000000001, 2.032957947910417},
							new double[] { 0.23400000000000001, 2.0296444979645116},
							new double[] { 0.23500000000000001, 2.0306657578264007},
							new double[] { 0.23600000000000002, 2.0302503663463431},
							new double[] { 0.23700000000000002, 2.0332243289421119},
							new double[] { 0.23800000000000002, 2.0334277707487787},
							new double[] { 0.23900000000000002, 2.0330104357080252},
							new double[] { 0.23999999999999999, 2.0323149474277322},
							new double[] { 0.24099999999999999, 2.0347537438443837},
							new double[] { 0.24199999999999999, 2.0303343694601326},
							new double[] { 0.24299999999999999, 2.0320704550674842},
							new double[] { 0.24399999999999999, 2.030694212698505},
							new double[] { 0.245, 2.0319668051109576},
							new double[] { 0.246, 2.0342258631990342},
							new double[] { 0.247, 2.0337612278790416},
							new double[] { 0.248, 2.0315289781171075},
							new double[] { 0.249, 2.0353417771264941},
							new double[] { 0.25, 2.0337735233956593},
							new double[] { 0.251, 2.0360719948030246},
							new double[] { 0.252, 2.0351689277526352},
							new double[] { 0.253, 2.035313689708941},
							new double[] { 0.254, 2.0347108877126576},
							new double[] { 0.255, 2.0361127153896867},
							new double[] { 0.25600000000000001, 2.034624741290139},
							new double[] { 0.25700000000000001, 2.0323682662077895},
							new double[] { 0.25800000000000001, 2.0371454787313175},
							new double[] { 0.25900000000000001, 2.0367237163993832},
							new double[] { 0.26000000000000001, 2.0361654351474185},
							new double[] { 0.26100000000000001, 2.035463803368105},
							new double[] { 0.26200000000000001, 2.0340355377071084},
							new double[] { 0.26300000000000001, 2.0381146968282522},
							new double[] { 0.26400000000000001, 2.0365228010823269},
							new double[] { 0.26500000000000001, 2.0359563457768011},
							new double[] { 0.26600000000000001, 2.037718700806439},
							new double[] { 0.26700000000000002, 2.0353963704157598},
							new double[] { 0.26800000000000002, 2.0378767723747018},
							new double[] { 0.26900000000000002, 2.03672727558952},
							new double[] { 0.27000000000000002, 2.0361656845159808},
							new double[] { 0.27100000000000002, 2.035738694861704},
							new double[] { 0.27200000000000002, 2.0375176492100033},
							new double[] { 0.27300000000000002, 2.0363080304940855},
							new double[] { 0.27400000000000002, 2.0387604994581907},
							new double[] { 0.27500000000000002, 2.0351894385987555},
							new double[] { 0.27600000000000002, 2.0381280462093256},
							new double[] { 0.27700000000000002, 2.0374099830325583},
							new double[] { 0.27800000000000002, 2.0367379425376715},
							new double[] { 0.27900000000000003, 2.0370332296262244},
							new double[] { 0.28000000000000003, 2.0375236066854576},
							new double[] { 0.28100000000000003, 2.0377499434461477},
							new double[] { 0.28200000000000003, 2.040318475763836},
							new double[] { 0.28300000000000003, 2.038267086331651},
							new double[] { 0.28400000000000003, 2.0371829961986405},
							new double[] { 0.28500000000000003, 2.0410120470464554},
							new double[] { 0.28600000000000003, 2.0389856380304261},
							new double[] { 0.28700000000000003, 2.0397689331721716},
							new double[] { 0.28800000000000003, 2.0384641601977593},
							new double[] { 0.28899999999999998, 2.0389107825748245},
							new double[] { 0.28999999999999998, 2.0415821165362615},
							new double[] { 0.29099999999999998, 2.038585500138554},
							new double[] { 0.29199999999999998, 2.0419447502107944},
							new double[] { 0.29299999999999998, 2.0427326543493955},
							new double[] { 0.29399999999999998, 2.0430365005606066},
							new double[] { 0.29499999999999998, 2.0382057440596277},
							new double[] { 0.29599999999999999, 2.0422361061372754},
							new double[] { 0.29699999999999999, 2.0389010726318801},
							new double[] { 0.29799999999999999, 2.042392753985157},
							new double[] { 0.29899999999999999, 2.041746866921704}
						};
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
		
				internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
				{
				
					internal CategoryObject()
					{
						proxyFactory = this;
						formulaString = new string[]
						{
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"1\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"c\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"t = Chart.X"
						};
						parameters =new Dictionary<string, object>()
						{
							{"b", (double)0 },
							{"c", (double)0 },
							{"a", (double)0 }
						};
						operationNames = new Dictionary<System.Int32,System.String>()
						{
						};
						Init();
					}
				
					FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
					{
						FormulaEditor.Interfaces.ITreeCollection f = this;
						var t = 
							FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
						var tt = t.ToArray();
						return new Calculation(tt);
					}
				
					internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
					{
						public void Update()
						{
							var_0 = (double)aliasName0.Value;
							var_1 = (object[])measurement1.Parameter();
							currentArray = treeArray_3;
							currentArray[0] = var_1;
							currentArray[1] = var_2;
							var_3 = (object[])trees[3].Calculate(currentArray);
							currentArray = treeArray_4;
							currentArray[0] = var_0;
							currentArray[1] = var_3;
							var_4 = (object[])trees[4].Calculate(currentArray);
							var_5 = (double)aliasName5.Value;
							var_6 = (object[])measurement6.Parameter();
							currentArray = treeArray_7;
							currentArray[0] = var_5;
							currentArray[1] = var_6;
							var_7 = (object[])trees[7].Calculate(currentArray);
							currentArray = treeArray_8;
							currentArray[0] = var_4;
							currentArray[1] = var_7;
							var_8 = (object[])trees[8].Calculate(currentArray);
							var_9 = (double)aliasName9.Value;
							currentArray = treeArray_10;
							currentArray[0] = var_8;
							currentArray[1] = var_9;
							var_10 = (object[])trees[10].Calculate(currentArray);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
							measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
							aliasName5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[5]);
							measurement6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[6]);
							aliasName9 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[9]);
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
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						Diagram.UI.Interfaces.IAliasName aliasName0;
						DataPerformer.Interfaces.IMeasurement measurement1;
						object[] treeArray_3 = new object[2];
						object[] treeArray_4 = new object[2];
						Diagram.UI.Interfaces.IAliasName aliasName5;
						DataPerformer.Interfaces.IMeasurement measurement6;
						object[] treeArray_7 = new object[2];
						object[] treeArray_8 = new object[2];
						Diagram.UI.Interfaces.IAliasName aliasName9;
						object[] treeArray_10 = new object[2];
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						object[] var_1 = new object[300];
						double var_2 = 2;
						object[] var_3 = new object[300];
						object[] var_4 = new object[300];
						double var_5 = 0;
						object[] var_6 = new object[300];
						object[] var_7 = new object[300];
						object[] var_8 = new object[300];
						double var_9 = 0;
						object[] var_10 = new object[300];
						
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
		
				internal class CategoryObject : Regression.Portable.AliasRegression
				{
					internal CategoryObject()
					{
						var d = new  Dictionary<int, object[]>();
						double x = 0;
						double y = 0;
						string s = "";
						var la = new List<double>();
						var ld = new List<double>();
						x = 0;
						y = 1.0000000000000001E-05;
						s = "Regression formula.a";
						d[0] = new object[] {s, x, y};
						aliasNames.Add(s);
						la.Add(x);
						ld.Add(y);
						x = 0;
						y = 1.0000000000000001E-05;
						s = "Regression formula.b";
						d[1] = new object[] {s, x, y};
						aliasNames.Add(s);
						la.Add(x);
						ld.Add(y);
						x = 0;
						y = 1.0000000000000001E-05;
						s = "Regression formula.c";
						d[2] = new object[] {s, x, y};
						aliasNames.Add(s);
						la.Add(x);
						ld.Add(y);
						dispersions =  la.ToArray();
						delta =  ld.ToArray();
						standardDeviation = 0.00060048926121168613;
						int i = 0;
						i = 0;
						measurementsNames[i] = "Regression formula.Formula_1";
						i = 0;
						selectionNames[i] = "Chart.Y";
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
		
				internal class CategoryArrow : Regression.Portable.SelectionLink
				{
				}
			}
		
		}
		
	}
}
