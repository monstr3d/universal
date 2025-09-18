import { AtmosphereCategoryObject } from "../ExternalObjects/Components/Atmosphere/AtmosphereCategoryObject";
import { GravityCategoryObject } from "../ExternalObjects/Components/Gravity_36_36/GravityCategoryObject";
import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { FeedbackAliasCollection } from "../Library/FeedbackAliasCollection";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { ObjectTransformerLink } from "../Library/Measurements/Arrows/ObjectTransformerLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { DifferentialEquationSolverFormula } from "../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { ObjectTransformer } from "../Library/Measurements/ObjectTransformer";
import { RecursiveFormula } from "../Library/Measurements/RecursiveFormula";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class Density_CategoryObject_0 extends AtmosphereCategoryObject
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
let iff : number[] =  [150,6,140];
 this.setIf(iff);
	}
}

class Density_CategoryObject_1 extends GravityCategoryObject
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	this.SetN0(36);
	this.SetNK(36);
		this.R = [];
		this.R.push(398600.43599999999);
		this.R.push(6378.1369999999997);
		this.R.push(398600.40000000002);
	
		this.C = [];
		this.C.push(-0.0004841650994);
		this.C.push(9.5720110000000009E-07);
		this.C.push(5.3952120000000001E-07);
		this.C.push(6.8343299999999995E-08);
		this.C.push(-1.4951350000000001E-07);
		this.C.push(9.1300899999999999E-08);
		this.C.push(4.8883199999999999E-08);
		this.C.push(2.6862400000000001E-08);
		this.C.push(5.4065000000000001E-08);
		this.C.push(-4.9463800000000001E-08);
		this.C.push(3.56285E-08);
		this.C.push(4.01122E-08);
		this.C.push(-2.1554900000000001E-08);
		this.C.push(3.2274999999999999E-09);
		this.C.push(-6.1890999999999996E-09);
		this.C.push(1.7426599999999999E-08);
		this.C.push(8.5246000000000001E-09);
		this.C.push(-2.1551000000000001E-09);
		this.C.push(1.9923799999999999E-08);
		this.C.push(6.0954000000000003E-09);
		this.C.push(-9.5104999999999994E-09);
		this.C.push(-2.1642599999999999E-08);
		this.C.push(-2.2919999999999999E-10);
		this.C.push(5.1981000000000001E-09);
		this.C.push(5.7589999999999997E-09);
		this.C.push(3.7752E-09);
		this.C.push(-9.9774999999999995E-09);
		this.C.push(-2.5026E-09);
		this.C.push(-6.7262999999999998E-09);
		this.C.push(5.9286000000000004E-09);
		this.C.push(-4.0391000000000002E-09);
		this.C.push(-1.15E-09);
		this.C.push(-4.5042000000000002E-09);
		this.C.push(6.8919000000000002E-09);
		this.C.push(-3.7241E-09);
		this.C.push(-1.7000000000000001E-10);
		this.C.push(2.0277141999999999E-06);
		this.C.push(-5.3615110000000001E-07);
		this.C.push(-5.8280200000000001E-08);
		this.C.push(-7.6894199999999998E-08);
		this.C.push(2.7486870000000002E-07);
		this.C.push(2.3628199999999999E-08);
		this.C.push(1.460968E-07);
		this.C.push(8.1493500000000001E-08);
		this.C.push(1.5143799999999999E-08);
		this.C.push(-5.4500200000000003E-08);
		this.C.push(-5.59665E-08);
		this.C.push(-2.0669300000000001E-08);
		this.C.push(1.3079399999999999E-08);
		this.C.push(2.3769400000000001E-08);
		this.C.push(-2.7380800000000001E-08);
		this.C.push(-1.2802E-09);
		this.C.push(-9.6288999999999993E-09);
		this.C.push(5.2110999999999999E-09);
		this.C.push(-1.71788E-08);
		this.C.push(9.6642000000000006E-09);
		this.C.push(6.3465E-09);
		this.C.push(-5.0423000000000003E-09);
		this.C.push(6.5866000000000004E-09);
		this.C.push(-2.6663999999999998E-09);
		this.C.push(3.9251E-09);
		this.C.push(-7.3064999999999999E-09);
		this.C.push(1.9969E-09);
		this.C.push(-1.7521E-09);
		this.C.push(4.6820999999999998E-09);
		this.C.push(-1.9391000000000001E-09);
		this.C.push(-3.1760999999999998E-09);
		this.C.push(-1.409E-10);
		this.C.push(-1.10388E-08);
		this.C.push(2.3560000000000001E-09);
		this.C.push(2.4390658000000001E-06);
		this.C.push(9.044707E-07);
		this.C.push(3.5021810000000001E-07);
		this.C.push(6.52711E-07);
		this.C.push(4.8734499999999999E-08);
		this.C.push(3.2779499999999998E-07);
		this.C.push(7.7598500000000005E-08);
		this.C.push(2.2451399999999999E-08);
		this.C.push(-9.1276599999999996E-08);
		this.C.push(1.67542E-08);
		this.C.push(1.2380799999999999E-08);
		this.C.push(5.4324200000000001E-08);
		this.C.push(-3.7195200000000001E-08);
		this.C.push(-2.35054E-08);
		this.C.push(-2.1291799999999999E-08);
		this.C.push(-1.91519E-08);
		this.C.push(1.31239E-08);
		this.C.push(2.7528099999999999E-08);
		this.C.push(1.7485999999999999E-08);
		this.C.push(-6.1390000000000004E-09);
		this.C.push(-1.9640799999999999E-08);
		this.C.push(-1.3082700000000001E-08);
		this.C.push(-2.1465E-09);
		this.C.push(1.6401700000000001E-08);
		this.C.push(-1.5745999999999999E-09);
		this.C.push(3.6962000000000001E-09);
		this.C.push(-1.19628E-08);
		this.C.push(-2.5286000000000001E-09);
		this.C.push(-9.2717999999999994E-09);
		this.C.push(1.3617E-09);
		this.C.push(8.3159999999999998E-09);
		this.C.push(-6.8686E-09);
		this.C.push(9.6775000000000001E-09);
		this.C.push(-1.32095E-08);
		this.C.push(-4.8740000000000003E-09);
		this.C.push(7.2034250000000002E-07);
		this.C.push(9.9093369999999997E-07);
		this.C.push(-4.5233010000000002E-07);
		this.C.push(5.7203199999999997E-08);
		this.C.push(2.5122009999999999E-07);
		this.C.push(-1.7785200000000001E-08);
		this.C.push(-1.612938E-07);
		this.C.push(-8.6059000000000006E-09);
		this.C.push(-2.84259E-08);
		this.C.push(4.2159799999999997E-08);
		this.C.push(-2.11569E-08);
		this.C.push(3.2988700000000002E-08);
		this.C.push(5.4276799999999999E-08);
		this.C.push(-3.4110900000000001E-08);
		this.C.push(1.27131E-08);
		this.C.push(-3.3637999999999999E-09);
		this.C.push(-3.3835000000000002E-09);
		this.C.push(-8.1594000000000006E-09);
		this.C.push(2.6379199999999998E-08);
		this.C.push(9.2975999999999998E-09);
		this.C.push(-1.2194E-08);
		this.C.push(-3.3461999999999999E-09);
		this.C.push(-6.8316999999999999E-09);
		this.C.push(9.0688999999999996E-09);
		this.C.push(5.6586000000000003E-09);
		this.C.push(2.4984E-09);
		this.C.push(1.5286000000000001E-09);
		this.C.push(3.8607999999999997E-09);
		this.C.push(-6.3296999999999998E-09);
		this.C.push(-1.5101E-09);
		this.C.push(-5.4439999999999998E-09);
		this.C.push(1.01568E-08);
		this.C.push(2.137E-09);
		this.C.push(-6.0150000000000004E-10);
		this.C.push(-1.8877059999999999E-07);
		this.C.push(-2.955841E-07);
		this.C.push(-8.68265E-08);
		this.C.push(-2.7556099999999999E-07);
		this.C.push(-2.4633979999999998E-07);
		this.C.push(-1.01377E-08);
		this.C.push(-8.5342400000000006E-08);
		this.C.push(-4.0683500000000002E-08);
		this.C.push(-6.9557400000000001E-08);
		this.C.push(-3.8557000000000002E-09);
		this.C.push(-7.8510000000000001E-10);
		this.C.push(-4.3480499999999997E-08);
		this.C.push(3.9121999999999998E-08);
		this.C.push(6.8146999999999996E-09);
		this.C.push(5.2164700000000001E-08);
		this.C.push(1.21511E-08);
		this.C.push(1.4180000000000001E-09);
		this.C.push(-9.4317E-09);
		this.C.push(-3.8186E-09);
		this.C.push(-1.9116200000000001E-08);
		this.C.push(7.1524999999999999E-09);
		this.C.push(5.1080999999999998E-09);
		this.C.push(1.47221E-08);
		this.C.push(5.8679999999999998E-10);
		this.C.push(4.2378000000000004E-09);
		this.C.push(-2.1991300000000001E-08);
		this.C.push(-8.4529999999999997E-10);
		this.C.push(-7.8644000000000003E-09);
		this.C.push(2.0706999999999999E-09);
		this.C.push(-3.2131E-09);
		this.C.push(-4.4926999999999996E-09);
		this.C.push(1.1719999999999999E-10);
		this.C.push(8.4559999999999995E-10);
		this.C.push(1.7376350000000001E-07);
		this.C.push(-2.6733040000000002E-07);
		this.C.push(1.3262E-09);
		this.C.push(-2.5041100000000001E-08);
		this.C.push(-1.71468E-08);
		this.C.push(-5.1021499999999998E-08);
		this.C.push(3.7614600000000001E-08);
		this.C.push(3.1915900000000001E-08);
		this.C.push(6.0720700000000002E-08);
		this.C.push(2.5954799999999999E-08);
		this.C.push(1.13901E-08);
		this.C.push(-1.41227E-08);
		this.C.push(-1.25322E-08);
		this.C.push(1.9873E-09);
		this.C.push(-1.5459700000000001E-08);
		this.C.push(-1.34176E-08);
		this.C.push(4.3733000000000002E-09);
		this.C.push(-8.2423E-09);
		this.C.push(8.0082000000000005E-09);
		this.C.push(-6.0088000000000002E-09);
		this.C.push(-3.7810999999999997E-09);
		this.C.push(3.8380000000000002E-09);
		this.C.push(1.57567E-08);
		this.C.push(5.5800000000000002E-09);
		this.C.push(-3.1614999999999999E-09);
		this.C.push(-1.9984E-09);
		this.C.push(-4.6503E-09);
		this.C.push(5.0123999999999998E-09);
		this.C.push(-4.8492999999999998E-09);
		this.C.push(-4.0990999999999996E-09);
		this.C.push(-6.2657E-09);
		this.C.push(-3.5798E-09);
		this.C.push(9.6846000000000002E-09);
		this.C.push(-3.5883139999999999E-07);
		this.C.push(-6.4923700000000003E-08);
		this.C.push(6.3914300000000002E-08);
		this.C.push(-3.70547E-08);
		this.C.push(-3.9179999999999998E-10);
		this.C.push(4.1892000000000004E-09);
		this.C.push(-3.4153600000000001E-08);
		this.C.push(-1.88109E-08);
		this.C.push(3.4206899999999998E-08);
		this.C.push(1.6911900000000001E-08);
		this.C.push(-1.09756E-08);
		this.C.push(1.5699699999999999E-08);
		this.C.push(-3.8121000000000001E-09);
		this.C.push(1.13814E-08);
		this.C.push(-1.16607E-08);
		this.C.push(1.38314E-08);
		this.C.push(-1.2887200000000001E-08);
		this.C.push(4.2666000000000001E-09);
		this.C.push(1.46476E-08);
		this.C.push(1.14084E-08);
		this.C.push(3.1000000000000001E-12);
		this.C.push(-2.3066999999999999E-09);
		this.C.push(9.9066000000000005E-09);
		this.C.push(7.8999999999999999E-11);
		this.C.push(-1.9375E-09);
		this.C.push(-5.9529E-09);
		this.C.push(1.1794999999999999E-09);
		this.C.push(-3.7860000000000002E-10);
		this.C.push(1.5394999999999999E-09);
		this.C.push(7.3451999999999998E-09);
		this.C.push(9.7030000000000005E-10);
		this.C.push(6.7462199999999996E-08);
		this.C.push(-1.190107E-07);
		this.C.push(7.5610999999999995E-09);
		this.C.push(3.8816999999999999E-09);
		this.C.push(-1.8389399999999999E-08);
		this.C.push(3.5556E-09);
		this.C.push(3.7678799999999999E-08);
		this.C.push(5.6823599999999998E-08);
		this.C.push(-6.9833000000000001E-09);
		this.C.push(2.47642E-08);
		this.C.push(5.8839000000000003E-09);
		this.C.push(5.0711999999999996E-09);
		this.C.push(-1.9405500000000001E-08);
		this.C.push(-1.1822599999999999E-08);
		this.C.push(1.4605799999999999E-08);
		this.C.push(-6.1313000000000001E-09);
		this.C.push(-2.4921000000000001E-09);
		this.C.push(6.9129E-09);
		this.C.push(-2.373E-10);
		this.C.push(-1.28755E-08);
		this.C.push(-8.5909999999999996E-10);
		this.C.push(-4.4995999999999996E-09);
		this.C.push(7.0755000000000002E-09);
		this.C.push(3.4009999999999999E-10);
		this.C.push(2.5424999999999999E-09);
		this.C.push(-4.8291000000000002E-09);
		this.C.push(4.4472999999999997E-09);
		this.C.push(-1.1804E-09);
		this.C.push(7.9530000000000004E-10);
		this.C.push(-1.2419840000000001E-07);
		this.C.push(1.8713229999999999E-07);
		this.C.push(4.0054700000000001E-08);
		this.C.push(-6.9703000000000002E-09);
		this.C.push(-2.5516799999999999E-08);
		this.C.push(-1.16966E-08);
		this.C.push(-3.48919E-08);
		this.C.push(-3.2726099999999997E-08);
		this.C.push(-2.06218E-08);
		this.C.push(3.7817099999999999E-08);
		this.C.push(3.0129099999999997E-08);
		this.C.push(2.9418400000000001E-08);
		this.C.push(4.9121999999999996E-09);
		this.C.push(-1.5243599999999999E-08);
		this.C.push(-2.34988E-08);
		this.C.push(5.5469000000000004E-09);
		this.C.push(1.5658699999999998E-08);
		this.C.push(5.1782000000000002E-09);
		this.C.push(3.5160999999999999E-09);
		this.C.push(-5.2480999999999997E-09);
		this.C.push(-2.0044999999999999E-09);
		this.C.push(-1.2184500000000001E-08);
		this.C.push(1.6689999999999999E-09);
		this.C.push(-1.19E-10);
		this.C.push(1.0039600000000001E-08);
		this.C.push(1.1497000000000001E-09);
		this.C.push(-1.35093E-08);
		this.C.push(2.3738999999999998E-09);
		this.C.push(3.6649999999999998E-10);
		this.C.push(-4.8132399999999999E-08);
		this.C.push(1.243124E-07);
		this.C.push(-3.2224800000000001E-08);
		this.C.push(4.0905299999999998E-08);
		this.C.push(2.4146700000000001E-08);
		this.C.push(3.2298399999999998E-08);
		this.C.push(1.1740299999999999E-08);
		this.C.push(-2.4003700000000001E-08);
		this.C.push(2.2023000000000001E-09);
		this.C.push(-1.78758E-08);
		this.C.push(2.2163999999999999E-09);
		this.C.push(1.9012100000000001E-08);
		this.C.push(1.5020300000000001E-08);
		this.C.push(1.02897E-08);
		this.C.push(-5.8560000000000003E-10);
		this.C.push(-7.4084000000000002E-09);
		this.C.push(-2.9785600000000001E-08);
		this.C.push(-7.2797999999999996E-09);
		this.C.push(1.65E-10);
		this.C.push(8.2431000000000002E-09);
		this.C.push(-5.0682000000000003E-09);
		this.C.push(-5.4353E-09);
		this.C.push(-1.4883999999999999E-09);
		this.C.push(5.8073999999999996E-09);
		this.C.push(3.0105999999999999E-09);
		this.C.push(5.7399999999999997E-11);
		this.C.push(-4.1607999999999999E-09);
		this.C.push(2.3523999999999999E-09);
		this.C.push(9.9753200000000004E-08);
		this.C.push(-5.2064999999999997E-08);
		this.C.push(-6.4899000000000001E-09);
		this.C.push(4.1465899999999997E-08);
		this.C.push(3.8510599999999998E-08);
		this.C.push(1.1479299999999999E-08);
		this.C.push(-1.09552E-08);
		this.C.push(-2.5897999999999999E-09);
		this.C.push(4.7002E-09);
		this.C.push(-3.3704899999999998E-08);
		this.C.push(-3.0161500000000002E-08);
		this.C.push(-9.6824000000000004E-09);
		this.C.push(5.1670999999999997E-09);
		this.C.push(1.45345E-08);
		this.C.push(1.13588E-08);
		this.C.push(7.5752999999999997E-09);
		this.C.push(-1.3095000000000001E-08);
		this.C.push(-1.2852200000000001E-08);
		this.C.push(-7.5322000000000001E-09);
		this.C.push(8.4163000000000004E-09);
		this.C.push(1.6217999999999999E-09);
		this.C.push(1.9809999999999999E-10);
		this.C.push(1.4409000000000001E-09);
		this.C.push(-2.7284999999999998E-09);
		this.C.push(-6.7001999999999997E-09);
		this.C.push(-6.3194999999999999E-09);
		this.C.push(1.3133E-09);
		this.C.push(4.5318100000000001E-08);
		this.C.push(1.05182E-08);
		this.C.push(-4.4539099999999998E-08);
		this.C.push(1.47653E-08);
		this.C.push(-8.754E-10);
		this.C.push(1.8427500000000001E-08);
		this.C.push(-1.5788900000000001E-08);
		this.C.push(-7.8403000000000007E-09);
		this.C.push(1.5746500000000001E-08);
		this.C.push(1.31223E-08);
		this.C.push(8.4047000000000001E-09);
		this.C.push(-3.4555999999999999E-09);
		this.C.push(8.0666000000000002E-09);
		this.C.push(1.1889299999999999E-08);
		this.C.push(4.4306E-09);
		this.C.push(-1.7838E-09);
		this.C.push(2.7287999999999999E-09);
		this.C.push(-4.1603000000000002E-09);
		this.C.push(-5.7377999999999998E-09);
		this.C.push(-1.10613E-08);
		this.C.push(8.508E-10);
		this.C.push(-5.4061999999999998E-09);
		this.C.push(2.0112999999999999E-09);
		this.C.push(-4.2243E-09);
		this.C.push(3.2848000000000001E-09);
		this.C.push(-4.0690000000000001E-10);
		this.C.push(-3.3602E-09);
		this.C.push(-3.1280300000000003E-08);
		this.C.push(8.3128000000000005E-09);
		this.C.push(-3.2455600000000001E-08);
		this.C.push(1.9897400000000001E-08);
		this.C.push(2.91379E-08);
		this.C.push(-2.87346E-08);
		this.C.push(-2.1222E-09);
		this.C.push(-5.9513000000000003E-09);
		this.C.push(-1.9521999999999999E-09);
		this.C.push(-3.8281E-09);
		this.C.push(1.70577E-08);
		this.C.push(1.16255E-08);
		this.C.push(-8.2097999999999995E-09);
		this.C.push(-1.67307E-08);
		this.C.push(-8.6416000000000004E-09);
		this.C.push(1.4295999999999999E-09);
		this.C.push(-2.6580000000000001E-09);
		this.C.push(1.2371400000000001E-08);
		this.C.push(2.7782999999999998E-09);
		this.C.push(-1.2597199999999999E-08);
		this.C.push(-6.8980000000000004E-10);
		this.C.push(1.03061E-08);
		this.C.push(6.7832000000000003E-09);
		this.C.push(-7.2520000000000004E-10);
		this.C.push(-6.1412900000000003E-08);
		this.C.push(3.1958400000000002E-08);
		this.C.push(-2.8757200000000002E-08);
		this.C.push(1.3712400000000001E-08);
		this.C.push(1.64865E-08);
		this.C.push(-6.1816000000000002E-09);
		this.C.push(-7.0963999999999996E-09);
		this.C.push(2.77741E-08);
		this.C.push(-1.85066E-08);
		this.C.push(-1.69513E-08);
		this.C.push(-1.11264E-08);
		this.C.push(-2.5191000000000001E-09);
		this.C.push(8.0623999999999998E-09);
		this.C.push(1.7499999999999999E-10);
		this.C.push(-4.5565999999999998E-09);
		this.C.push(1.6575999999999999E-09);
		this.C.push(-7.2729999999999996E-10);
		this.C.push(1.34213E-08);
		this.C.push(9.3804999999999992E-09);
		this.C.push(4.1739999999999999E-09);
		this.C.push(3.4056999999999999E-09);
		this.C.push(-5.2037999999999998E-09);
		this.C.push(-1.7808000000000001E-09);
		this.C.push(-6.5508000000000002E-09);
		this.C.push(-5.1785100000000002E-08);
		this.C.push(5.4459E-09);
		this.C.push(-1.96596E-08);
		this.C.push(-1.4095600000000001E-08);
		this.C.push(-8.8532999999999996E-09);
		this.C.push(-4.8123999999999996E-09);
		this.C.push(1.08561E-08);
		this.C.push(2.0369799999999999E-08);
		this.C.push(1.0178E-08);
		this.C.push(5.8014000000000003E-09);
		this.C.push(-2.0155699999999999E-08);
		this.C.push(-2.0673100000000001E-08);
		this.C.push(7.3957999999999996E-09);
		this.C.push(1.6175999999999999E-08);
		this.C.push(-6.2352999999999998E-09);
		this.C.push(-6.1507000000000003E-09);
		this.C.push(4.3796000000000001E-09);
		this.C.push(-6.0838E-09);
		this.C.push(-5.282E-10);
		this.C.push(3.7931000000000001E-09);
		this.C.push(-1.2805999999999999E-09);
		this.C.push(-6.8707000000000003E-09);
		this.C.push(-8.0168000000000007E-09);
		this.C.push(-1.9573100000000001E-08);
		this.C.push(-1.3478E-08);
		this.C.push(5.3063999999999998E-09);
		this.C.push(-3.9385700000000003E-08);
		this.C.push(-1.7539299999999999E-08);
		this.C.push(-2.4648099999999999E-08);
		this.C.push(1.78471E-08);
		this.C.push(2.6347199999999999E-08);
		this.C.push(1.8417799999999999E-08);
		this.C.push(6.6160999999999999E-09);
		this.C.push(-3.6318999999999998E-09);
		this.C.push(-1.3675E-08);
		this.C.push(-2.3151E-09);
		this.C.push(-1.08597E-08);
		this.C.push(-7.7082999999999999E-09);
		this.C.push(-1.6878999999999999E-09);
		this.C.push(1.753E-09);
		this.C.push(5.0419000000000001E-09);
		this.C.push(-5.0421999999999998E-09);
		this.C.push(-9.3209999999999991E-10);
		this.C.push(-1.4351099999999999E-08);
		this.C.push(7.5180000000000003E-10);
		this.C.push(-3.6127000000000003E-08);
		this.C.push(-2.9409900000000001E-08);
		this.C.push(1.1331799999999999E-08);
		this.C.push(-2.1050599999999999E-08);
		this.C.push(-1.0692700000000001E-08);
		this.C.push(8.4444999999999999E-09);
		this.C.push(1.2215E-09);
		this.C.push(6.8979000000000003E-09);
		this.C.push(9.4515000000000003E-09);
		this.C.push(1.5537999999999999E-09);
		this.C.push(2.5097000000000001E-09);
		this.C.push(4.3338999999999997E-09);
		this.C.push(-3.1453999999999999E-09);
		this.C.push(-1.6790000000000001E-10);
		this.C.push(-8.8025999999999994E-09);
		this.C.push(-4.6677999999999999E-09);
		this.C.push(2.5011E-09);
		this.C.push(4.3554999999999997E-09);
		this.C.push(5.727E-10);
		this.C.push(-4.1016999999999996E-09);
		this.C.push(3.2539999999999998E-10);
		this.C.push(-3.29779E-08);
		this.C.push(3.6681999999999998E-09);
		this.C.push(3.0652500000000003E-08);
		this.C.push(4.4349000000000001E-09);
		this.C.push(-5.6776000000000003E-09);
		this.C.push(8.9480000000000001E-09);
		this.C.push(-4.0493999999999997E-09);
		this.C.push(-1.1989000000000001E-08);
		this.C.push(-1.31607E-08);
		this.C.push(-1.08818E-08);
		this.C.push(4.5031000000000003E-09);
		this.C.push(1.35711E-08);
		this.C.push(4.1030000000000002E-10);
		this.C.push(-6.5044E-09);
		this.C.push(-3.9763E-09);
		this.C.push(-5.1155000000000004E-09);
		this.C.push(-4.3785999999999997E-09);
		this.C.push(-5.5791000000000003E-09);
		this.C.push(7.9109999999999999E-10);
		this.C.push(5.4932999999999996E-09);
		this.C.push(2.7593999999999998E-09);
		this.C.push(3.3034200000000001E-08);
		this.C.push(1.5241099999999999E-08);
		this.C.push(2.43699E-08);
		this.C.push(8.767E-09);
		this.C.push(7.4795999999999997E-09);
		this.C.push(-7.5720000000000003E-10);
		this.C.push(6.0510000000000001E-10);
		this.C.push(-1.31056E-08);
		this.C.push(-2.6532999999999999E-09);
		this.C.push(3.8205000000000002E-09);
		this.C.push(-4.8796000000000004E-09);
		this.C.push(-1.00442E-08);
		this.C.push(-1.1248999999999999E-09);
		this.C.push(8.2253999999999993E-09);
		this.C.push(-9.6199999999999995E-09);
		this.C.push(-1.0918099999999999E-08);
		this.C.push(-4.4956000000000001E-09);
		this.C.push(3.531E-10);
		this.C.push(-2.3480000000000002E-09);
		this.C.push(-4.7068000000000003E-09);
		this.C.push(-2.7750800000000001E-08);
		this.C.push(1.2513700000000001E-08);
		this.C.push(-7.1168999999999997E-09);
		this.C.push(-4.9207999999999998E-09);
		this.C.push(6.5225999999999998E-09);
		this.C.push(-1.1322000000000001E-09);
		this.C.push(-8.0810000000000003E-10);
		this.C.push(4.1720000000000001E-09);
		this.C.push(-6.2726999999999996E-09);
		this.C.push(-1.16142E-08);
		this.C.push(2.5044000000000002E-09);
		this.C.push(-1.3520000000000001E-10);
		this.C.push(8.4762000000000002E-09);
		this.C.push(-3.8300000000000002E-10);
		this.C.push(4.4389999999999999E-10);
		this.C.push(-4.2858000000000002E-09);
		this.C.push(4.0221E-09);
		this.C.push(-2.6306200000000002E-08);
		this.C.push(-1.66678E-08);
		this.C.push(9.8039999999999996E-09);
		this.C.push(-4.9043999999999997E-09);
		this.C.push(-6.2665000000000002E-09);
		this.C.push(6.6383999999999997E-09);
		this.C.push(6.3429999999999997E-10);
		this.C.push(-1.8593E-09);
		this.C.push(-6.0496000000000003E-09);
		this.C.push(-3.9430000000000001E-09);
		this.C.push(-2.2369E-09);
		this.C.push(2.8537999999999998E-09);
		this.C.push(-8.262E-10);
		this.C.push(4.3770000000000001E-09);
		this.C.push(-1.1465999999999999E-09);
		this.C.push(-5.7191000000000002E-09);
		this.C.push(7.5179999999999999E-09);
		this.C.push(-2.4615599999999998E-08);
		this.C.push(1.5767999999999999E-08);
		this.C.push(1.1140300000000001E-08);
		this.C.push(4.8717999999999997E-09);
		this.C.push(-6.5966999999999998E-09);
		this.C.push(5.9840999999999996E-09);
		this.C.push(7.7244000000000003E-09);
		this.C.push(-7.7158000000000002E-09);
		this.C.push(-8.8595000000000007E-09);
		this.C.push(-6.1490000000000002E-09);
		this.C.push(-1.5404E-09);
		this.C.push(1.7740000000000001E-09);
		this.C.push(-5.6959999999999998E-10);
		this.C.push(1.04901E-08);
		this.C.push(6.2678000000000002E-09);
		this.C.push(-8.9299000000000008E-09);
		this.C.push(-1.7092300000000001E-08);
		this.C.push(3.3958999999999998E-09);
		this.C.push(-1.2772500000000001E-08);
		this.C.push(1.21192E-08);
		this.C.push(-5.4096E-09);
		this.C.push(-1.0523E-09);
		this.C.push(1.2454100000000001E-08);
		this.C.push(-2.6737E-09);
		this.C.push(-7.4700000000000001E-09);
		this.C.push(-9.1124999999999997E-09);
		this.C.push(-6.0012999999999999E-09);
		this.C.push(-2.0442E-09);
		this.C.push(2.2849999999999999E-09);
		this.C.push(9.8619999999999997E-10);
		this.C.push(4.5640000000000004E-09);
		this.C.push(-7.1693E-09);
		this.C.push(8.4211000000000002E-09);
		this.C.push(-2.176E-10);
		this.C.push(-5.0968E-09);
		this.C.push(4.5908999999999999E-09);
		this.C.push(-2.2659999999999998E-09);
		this.C.push(3.3951E-09);
		this.C.push(8.6391999999999997E-09);
		this.C.push(6.7808000000000004E-09);
		this.C.push(-7.0919999999999999E-10);
		this.C.push(-1.4309999999999999E-09);
		this.C.push(-6.7571999999999998E-09);
		this.C.push(-9.853000000000001E-10);
		this.C.push(1.1140300000000001E-08);
		this.C.push(4.8717999999999997E-09);
		this.C.push(6.7431E-09);
		this.C.push(2.2200000000000002E-11);
		this.C.push(9.6281999999999995E-09);
		this.C.push(1.001E-10);
		this.C.push(-2.6160000000000001E-09);
		this.C.push(-3.0546999999999998E-09);
		this.C.push(-4.6500999999999999E-09);
		this.C.push(9.0192999999999992E-09);
		this.C.push(4.8196999999999998E-09);
		this.C.push(2.1631000000000001E-09);
		this.C.push(1.7057E-09);
		this.C.push(8.9667999999999993E-09);
		this.C.push(3.6502000000000001E-09);
		this.C.push(1.07286E-08);
		this.C.push(5.6096999999999998E-09);
		this.C.push(5.6260000000000002E-09);
		this.C.push(3.4385000000000001E-09);
		this.C.push(-1.6244899999999999E-08);
		this.C.push(-1.80762E-08);
		this.C.push(2.9450000000000001E-09);
		this.C.push(5.8310000000000002E-09);
		this.C.push(5.3013999999999999E-09);
		this.C.push(3.4153E-09);
		this.C.push(-8.3959999999999998E-10);
		this.C.push(-5.8366999999999999E-09);
		this.C.push(8.6338000000000005E-09);
		this.C.push(9.0137999999999996E-09);
		this.C.push(3.6889999999999999E-10);
		this.C.push(-1.13406E-08);
		this.C.push(4.2350000000000004E-09);
		this.C.push(1.0518899999999999E-08);
		this.C.push(2.4294999999999999E-09);
		this.C.push(-4.6325999999999999E-09);
		this.C.push(3.0975000000000001E-09);
		this.C.push(6.8459999999999997E-09);
		this.C.push(-7.3754999999999996E-09);
		this.C.push(-6.7189E-09);
		this.C.push(-5.6394999999999998E-09);
		this.C.push(6.2000000000000003E-10);
		this.C.push(-3.6279999999999999E-09);
		this.C.push(-8.5760000000000002E-10);
		this.C.push(1.2529700000000001E-08);
		this.C.push(1.16954E-08);
		this.C.push(-7.1207999999999996E-09);
		this.C.push(7.2606000000000003E-09);
		this.C.push(7.9714999999999996E-09);
		this.C.push(-3.786E-09);
		this.C.push(8.9150999999999995E-09);
		this.C.push(2.9940000000000002E-09);
		this.C.push(9.2619999999999997E-10);
		this.C.push(1.0961E-09);
		this.C.push(6.8818E-09);
		this.C.push(1.9693999999999998E-09);
		this.C.push(1.04845E-08);
		this.C.push(2.1891999999999998E-09);
		this.C.push(-2.1781000000000002E-09);
		this.C.push(3.1745000000000002E-09);
		this.C.push(-1.5941099999999999E-08);
		this.C.push(5.1354000000000003E-09);
		this.C.push(8.0871000000000003E-09);
		this.C.push(2.7622999999999999E-09);
		this.C.push(-5.4599999999999998E-11);
		this.C.push(-9.4740000000000006E-10);
		this.C.push(-4.2625999999999997E-09);
		this.C.push(-3.1930000000000002E-10);
		this.C.push(-1.6973299999999999E-08);
		this.C.push(-2.6501999999999998E-09);
		this.C.push(-8.9973999999999996E-09);
		this.C.push(-9.1731999999999997E-09);
		this.C.push(-3.2430000000000001E-09);
		this.C.push(3.6344000000000002E-09);
		this.C.push(-2.8722000000000001E-09);
		this.C.push(6.4791999999999997E-09);
		this.C.push(-5.8913000000000001E-09);
		this.C.push(5.0965000000000003E-09);
		this.C.push(6.5942000000000002E-09);
		this.C.push(6.24E-09);
		this.C.push(-5.3443000000000002E-09);
		this.C.push(7.4786000000000002E-09);
		this.C.push(2.4732000000000001E-09);
		this.C.push(1.06401E-08);
		this.C.push(6.0071000000000001E-09);
		this.C.push(1.3699E-09);
		this.C.push(-5.7815000000000004E-09);
		this.C.push(-2.0539000000000001E-09);
		this.C.push(-5.7021E-09);
		this.C.push(-5.5092E-09);
		this.C.push(-1.4267E-09);
		this.C.push(1.3750999999999999E-09);
	
		this.S = [];
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(0);
		this.S.push(1.19E-09);
		this.S.push(2.4921710000000002E-07);
		this.S.push(-4.7343599999999998E-07);
		this.S.push(-9.6083899999999997E-08);
		this.S.push(2.69984E-08);
		this.S.push(9.7465900000000002E-08);
		this.S.push(5.8847200000000002E-08);
		this.S.push(1.9970700000000001E-08);
		this.S.push(-1.3027769999999999E-07);
		this.S.push(-2.66145E-08);
		this.S.push(-4.2095400000000003E-08);
		this.S.push(3.9529299999999999E-08);
		this.S.push(3.0458199999999998E-08);
		this.S.push(7.0986999999999999E-09);
		this.S.push(3.4085499999999998E-08);
		this.S.push(-3.1844899999999999E-08);
		this.S.push(-3.6262100000000003E-08);
		this.S.push(-2.9679000000000001E-09);
		this.S.push(5.8029999999999999E-09);
		this.S.push(2.05518E-08);
		this.S.push(-9.644000000000001E-10);
		this.S.push(1.30062E-08);
		this.S.push(-3.3126999999999999E-09);
		this.S.push(-1.0529699999999999E-08);
		this.S.push(-8.2429999999999998E-09);
		this.S.push(-1.4270000000000001E-10);
		this.S.push(6.2147999999999997E-09);
		this.S.push(-3.1928E-09);
		this.S.push(1.7543E-09);
		this.S.push(-1.19952E-08);
		this.S.push(3.4070000000000002E-10);
		this.S.push(7.4670000000000002E-10);
		this.S.push(2.4123E-09);
		this.S.push(-5.7405000000000002E-09);
		this.S.push(5.0525000000000001E-09);
		this.S.push(-1.4000946E-06);
		this.S.push(-6.1944769999999997E-07);
		this.S.push(6.6301520000000002E-07);
		this.S.push(-3.2386370000000002E-07);
		this.S.push(-3.7401310000000002E-07);
		this.S.push(9.3246699999999998E-08);
		this.S.push(6.6008700000000003E-08);
		this.S.push(-3.35532E-08);
		this.S.push(-5.1102899999999999E-08);
		this.S.push(-9.84958E-08);
		this.S.push(3.1920600000000003E-08);
		this.S.push(-6.3428299999999994E-08);
		this.S.push(-3.3551000000000001E-09);
		this.S.push(-3.33181E-08);
		this.S.push(2.6832000000000002E-08);
		this.S.push(7.7318000000000001E-09);
		this.S.push(1.2939399999999999E-08);
		this.S.push(-2.3289000000000001E-09);
		this.S.push(1.37476E-08);
		this.S.push(4.7932000000000004E-09);
		this.S.push(-2.0825999999999998E-09);
		this.S.push(-4.0370999999999996E-09);
		this.S.push(1.34247E-08);
		this.S.push(1.04728E-08);
		this.S.push(9.2185000000000008E-09);
		this.S.push(3.1719999999999998E-09);
		this.S.push(-1.16064E-08);
		this.S.push(-6.536E-10);
		this.S.push(-3.0842000000000002E-09);
		this.S.push(5.7275000000000003E-09);
		this.S.push(-4.9376999999999996E-09);
		this.S.push(1.5229E-09);
		this.S.push(6.367E-09);
		this.S.push(2.4944E-09);
		this.S.push(-2.0946000000000002E-09);
		this.S.push(1.4138845E-06);
		this.S.push(-2.009274E-07);
		this.S.push(-2.1529579999999999E-07);
		this.S.push(9.3727999999999997E-09);
		this.S.push(-2.1529269999999999E-07);
		this.S.push(-8.6346999999999999E-08);
		this.S.push(-7.5968299999999999E-08);
		this.S.push(-1.5502819999999999E-07);
		this.S.push(-1.4628950000000001E-07);
		this.S.push(2.4672800000000001E-08);
		this.S.push(9.6380799999999997E-08);
		this.S.push(2.1021599999999999E-08);
		this.S.push(1.5095699999999999E-08);
		this.S.push(-2.7123000000000001E-08);
		this.S.push(8.5514000000000001E-09);
		this.S.push(-1.4744E-09);
		this.S.push(-9.9510000000000001E-10);
		this.S.push(3.0306500000000001E-08);
		this.S.push(1.8713399999999999E-08);
		this.S.push(8.2273999999999999E-09);
		this.S.push(-1.7319300000000001E-08);
		this.S.push(-8.2339999999999995E-09);
		this.S.push(-1.4673900000000001E-08);
		this.S.push(-3.1308E-09);
		this.S.push(2.1284999999999998E-09);
		this.S.push(9.0419999999999992E-09);
		this.S.push(-8.2879999999999995E-09);
		this.S.push(-9.4092999999999998E-09);
		this.S.push(-8.6681000000000007E-09);
		this.S.push(1.3112E-09);
		this.S.push(2.6047999999999999E-09);
		this.S.push(7.4330999999999999E-09);
		this.S.push(3.5834999999999999E-09);
		this.S.push(-9.9549E-09);
		this.S.push(3.094237E-07);
		this.S.push(4.96903E-08);
		this.S.push(-4.7130640000000002E-07);
		this.S.push(-1.2376720000000001E-07);
		this.S.push(7.0179600000000002E-08);
		this.S.push(1.89722E-08);
		this.S.push(-7.8733999999999995E-08);
		this.S.push(-6.4482600000000001E-08);
		this.S.push(-2.8551999999999998E-09);
		this.S.push(-1.3302799999999999E-08);
		this.S.push(-1.9293299999999999E-08);
		this.S.push(7.0734E-09);
		this.S.push(4.5473400000000001E-08);
		this.S.push(2.10642E-08);
		this.S.push(2.0212E-09);
		this.S.push(-4.2206999999999997E-09);
		this.S.push(-2.2961599999999999E-08);
		this.S.push(1.3932E-08);
		this.S.push(1.43386E-08);
		this.S.push(6.4666999999999996E-09);
		this.S.push(3.7349000000000004E-09);
		this.S.push(4.1832999999999998E-09);
		this.S.push(-1.6528500000000001E-08);
		this.S.push(9.2713999999999992E-09);
		this.S.push(3.3269000000000002E-09);
		this.S.push(-1.3639999999999999E-10);
		this.S.push(-3.0520999999999998E-09);
		this.S.push(-8.4769999999999998E-10);
		this.S.push(-6.5448E-09);
		this.S.push(3.1032000000000002E-09);
		this.S.push(-3.7018000000000002E-09);
		this.S.push(1.8778999999999999E-09);
		this.S.push(-3.0954999999999999E-09);
		this.S.push(-6.6890700000000005E-07);
		this.S.push(-5.3678019999999995E-07);
		this.S.push(1.8620000000000001E-08);
		this.S.push(8.9462800000000001E-08);
		this.S.push(-5.3773299999999998E-08);
		this.S.push(-5.1106500000000002E-08);
		this.S.push(5.03126E-08);
		this.S.push(9.6522000000000002E-09);
		this.S.push(6.4653700000000001E-08);
		this.S.push(-1.62511E-08);
		this.S.push(8.8505000000000004E-09);
		this.S.push(3.3199999999999999E-11);
		this.S.push(5.0564E-09);
		this.S.push(2.9103599999999999E-08);
		this.S.push(2.73694E-08);
		this.S.push(-3.5994000000000002E-09);
		this.S.push(9.7040000000000008E-10);
		this.S.push(3.5020000000000001E-09);
		this.S.push(-2.3535999999999998E-09);
		this.S.push(-1.26654E-08);
		this.S.push(-3.6623000000000001E-09);
		this.S.push(1.06647E-08);
		this.S.push(7.9196000000000007E-09);
		this.S.push(3.2829999999999999E-10);
		this.S.push(1.8419E-09);
		this.S.push(-3.3849000000000002E-09);
		this.S.push(-2.0512000000000001E-09);
		this.S.push(5.4480000000000002E-10);
		this.S.push(1.1091E-09);
		this.S.push(5.9137000000000004E-09);
		this.S.push(-8.9831999999999993E-09);
		this.S.push(1.6489999999999999E-10);
		this.S.push(-2.371348E-07);
		this.S.push(1.517387E-07);
		this.S.push(3.0912260000000001E-07);
		this.S.push(2.2264820000000001E-07);
		this.S.push(-7.8379799999999994E-08);
		this.S.push(3.4921599999999998E-08);
		this.S.push(4.0134500000000001E-08);
		this.S.push(-4.2567999999999996E-09);
		this.S.push(5.4355999999999997E-09);
		this.S.push(-3.5833099999999999E-08);
		this.S.push(-3.2851799999999998E-08);
		this.S.push(-2.7477900000000001E-08);
		this.S.push(-1.15996E-08);
		this.S.push(2.0107700000000001E-08);
		this.S.push(8.9349999999999996E-10);
		this.S.push(1.8168E-09);
		this.S.push(-5.2022999999999997E-09);
		this.S.push(1.6717399999999999E-08);
		this.S.push(9.0189999999999996E-10);
		this.S.push(3.9236999999999996E-09);
		this.S.push(-6.4851999999999999E-09);
		this.S.push(6.2788000000000003E-09);
		this.S.push(4.9177000000000001E-09);
		this.S.push(6.8547999999999999E-09);
		this.S.push(1.4467E-09);
		this.S.push(3.3188000000000002E-09);
		this.S.push(-8.5579000000000008E-09);
		this.S.push(-4.8727000000000003E-09);
		this.S.push(3.5989000000000001E-09);
		this.S.push(6.0509000000000003E-09);
		this.S.push(-4.6861999999999998E-09);
		this.S.push(2.4083600000000001E-08);
		this.S.push(7.5094800000000001E-08);
		this.S.push(-9.6990999999999998E-08);
		this.S.push(-3.3500999999999998E-09);
		this.S.push(-8.9553700000000006E-08);
		this.S.push(3.5816600000000001E-08);
		this.S.push(-5.8835999999999998E-09);
		this.S.push(-6.3812999999999999E-09);
		this.S.push(6.1453000000000003E-09);
		this.S.push(-7.0595000000000003E-09);
		this.S.push(-3.5158000000000002E-09);
		this.S.push(3.3473999999999998E-09);
		this.S.push(-6.3048999999999996E-09);
		this.S.push(-1.5386E-09);
		this.S.push(3.5728999999999999E-09);
		this.S.push(1.8228E-09);
		this.S.push(2.8609999999999999E-09);
		this.S.push(2.8966000000000001E-09);
		this.S.push(-7.4194000000000002E-09);
		this.S.push(1.1771E-09);
		this.S.push(-2.3620999999999999E-09);
		this.S.push(5.2728999999999999E-09);
		this.S.push(-4.6636000000000003E-09);
		this.S.push(1.4214999999999999E-09);
		this.S.push(-2.4004000000000001E-09);
		this.S.push(2.4856000000000002E-09);
		this.S.push(-1.447E-10);
		this.S.push(-3.3291E-09);
		this.S.push(2.9285E-09);
		this.S.push(4.1387999999999998E-09);
		this.S.push(1.2017220000000001E-07);
		this.S.push(-2.3538999999999999E-09);
		this.S.push(-9.1679999999999998E-08);
		this.S.push(2.5325099999999999E-08);
		this.S.push(1.6192099999999999E-08);
		this.S.push(-8.8472999999999994E-09);
		this.S.push(-1.4984800000000001E-08);
		this.S.push(2.35054E-08);
		this.S.push(5.6651999999999998E-09);
		this.S.push(3.9290999999999996E-09);
		this.S.push(2.4813000000000001E-09);
		this.S.push(-9.3126000000000003E-09);
		this.S.push(3.4215999999999998E-09);
		this.S.push(4.0666999999999996E-09);
		this.S.push(2.1983000000000002E-09);
		this.S.push(-1.5897E-09);
		this.S.push(-4.8356999999999998E-09);
		this.S.push(1.6270000000000001E-09);
		this.S.push(1.4723E-09);
		this.S.push(-9.8612999999999994E-09);
		this.S.push(-5.3160000000000003E-09);
		this.S.push(7.4112999999999998E-09);
		this.S.push(2.5351000000000001E-09);
		this.S.push(1.9169999999999999E-10);
		this.S.push(3.0254999999999999E-09);
		this.S.push(1.10768E-08);
		this.S.push(3.7096000000000001E-09);
		this.S.push(1.01232E-08);
		this.S.push(-3.4356E-09);
		this.S.push(9.8739200000000006E-08);
		this.S.push(-3.8032800000000003E-08);
		this.S.push(4.3290199999999997E-08);
		this.S.push(2.43333E-08);
		this.S.push(4.60357E-08);
		this.S.push(2.7619999999999999E-08);
		this.S.push(3.7432799999999998E-08);
		this.S.push(-3.8312099999999998E-08);
		this.S.push(-2.8306100000000001E-08);
		this.S.push(3.44506E-08);
		this.S.push(2.5673E-09);
		this.S.push(-4.8859000000000003E-09);
		this.S.push(6.8850000000000001E-09);
		this.S.push(8.3147999999999995E-09);
		this.S.push(-1.8424200000000001E-08);
		this.S.push(-1.6283399999999999E-08);
		this.S.push(1.3628E-08);
		this.S.push(1.699E-09);
		this.S.push(7.6482999999999997E-09);
		this.S.push(-6.4752999999999998E-09);
		this.S.push(-3.8188999999999997E-09);
		this.S.push(-7.5010999999999993E-09);
		this.S.push(1.742E-09);
		this.S.push(1.0645E-09);
		this.S.push(3.6263999999999998E-09);
		this.S.push(4.0018999999999996E-09);
		this.S.push(-1.7539999999999999E-09);
		this.S.push(-1.2762E-09);
		this.S.push(-2.24543E-08);
		this.S.push(-1.7331000000000001E-08);
		this.S.push(3.1763300000000001E-08);
		this.S.push(-3.6184299999999998E-08);
		this.S.push(-1.0119E-09);
		this.S.push(1.5596100000000002E-08);
		this.S.push(1.28282E-08);
		this.S.push(1.8696999999999999E-08);
		this.S.push(-5.1743999999999998E-09);
		this.S.push(-6.9965999999999996E-09);
		this.S.push(-5.4108000000000004E-09);
		this.S.push(-5.8739999999999996E-10);
		this.S.push(2.4126099999999999E-08);
		this.S.push(-3.1763999999999999E-09);
		this.S.push(1.7288400000000001E-08);
		this.S.push(-4.7881999999999997E-09);
		this.S.push(-4.2048999999999998E-09);
		this.S.push(7.0209999999999998E-10);
		this.S.push(7.9032999999999994E-09);
		this.S.push(1.8968999999999999E-09);
		this.S.push(-5.5394999999999997E-09);
		this.S.push(-8.0774000000000003E-09);
		this.S.push(-5.6584000000000002E-09);
		this.S.push(5.3440000000000004E-10);
		this.S.push(8.1729999999999996E-10);
		this.S.push(6.8519999999999999E-09);
		this.S.push(5.3536000000000002E-09);
		this.S.push(-6.9074100000000006E-08);
		this.S.push(-6.8163999999999997E-09);
		this.S.push(-4.3063000000000003E-09);
		this.S.push(-3.94554E-08);
		this.S.push(1.9130899999999999E-08);
		this.S.push(-2.9384000000000001E-09);
		this.S.push(1.1855700000000001E-08);
		this.S.push(2.1960999999999999E-09);
		this.S.push(1.02937E-08);
		this.S.push(-1.8428999999999999E-08);
		this.S.push(-3.5139199999999999E-08);
		this.S.push(-1.64381E-08);
		this.S.push(1.5378899999999999E-08);
		this.S.push(1.85777E-08);
		this.S.push(7.9568999999999993E-09);
		this.S.push(1.8849E-09);
		this.S.push(-7.6154000000000008E-09);
		this.S.push(2.3565999999999999E-09);
		this.S.push(7.0721999999999996E-09);
		this.S.push(9.9434000000000002E-09);
		this.S.push(1.5715499999999999E-08);
		this.S.push(4.811E-09);
		this.S.push(-7.7170000000000005E-09);
		this.S.push(2.4097000000000001E-09);
		this.S.push(-1.8095E-09);
		this.S.push(1.9426999999999999E-09);
		this.S.push(-1.0879700000000001E-08);
		this.S.push(8.7796399999999996E-08);
		this.S.push(-3.13314E-08);
		this.S.push(1.4775599999999999E-08);
		this.S.push(6.1632000000000004E-09);
		this.S.push(1.9377499999999999E-08);
		this.S.push(-1.6901200000000001E-08);
		this.S.push(8.1173000000000005E-09);
		this.S.push(1.7357999999999999E-08);
		this.S.push(1.40674E-08);
		this.S.push(-8.7932000000000006E-09);
		this.S.push(-1.33824E-08);
		this.S.push(-5.5536000000000003E-09);
		this.S.push(1.22275E-08);
		this.S.push(1.7457000000000001E-09);
		this.S.push(4.264E-10);
		this.S.push(1.0900199999999999E-08);
		this.S.push(-1.7172E-09);
		this.S.push(-8.5304999999999999E-09);
		this.S.push(3.1964999999999999E-09);
		this.S.push(1.3919499999999999E-08);
		this.S.push(1.01392E-08);
		this.S.push(-2.4785000000000001E-09);
		this.S.push(-5.4193000000000001E-09);
		this.S.push(-3.4005E-09);
		this.S.push(6.7812399999999994E-08);
		this.S.push(4.5298900000000002E-08);
		this.S.push(-4.2554E-09);
		this.S.push(1.2041E-09);
		this.S.push(2.0753099999999999E-08);
		this.S.push(-3.46579E-08);
		this.S.push(-2.8023499999999999E-08);
		this.S.push(6.7269E-09);
		this.S.push(1.36367E-08);
		this.S.push(1.9729500000000001E-08);
		this.S.push(-4.4651999999999998E-09);
		this.S.push(2.7378000000000002E-09);
		this.S.push(-1.16876E-08);
		this.S.push(2.1769000000000002E-09);
		this.S.push(-2.5631E-09);
		this.S.push(5.5353000000000001E-09);
		this.S.push(-1.7457999999999999E-09);
		this.S.push(3.4719E-09);
		this.S.push(3.6678000000000001E-09);
		this.S.push(2.3826E-09);
		this.S.push(5.2653999999999996E-09);
		this.S.push(3.1756000000000001E-09);
		this.S.push(2.5409000000000002E-09);
		this.S.push(5.6450000000000003E-09);
		this.S.push(-5.0039000000000001E-09);
		this.S.push(-2.4319800000000001E-08);
		this.S.push(-3.8677100000000002E-08);
		this.S.push(1.1643800000000001E-08);
		this.S.push(-1.2869300000000001E-08);
		this.S.push(-1.2904300000000001E-08);
		this.S.push(-1.39252E-08);
		this.S.push(7.9162999999999992E-09);
		this.S.push(7.7607999999999999E-09);
		this.S.push(-2.0946999999999998E-09);
		this.S.push(-6.0990000000000003E-10);
		this.S.push(7.8295000000000007E-09);
		this.S.push(6.5214999999999999E-09);
		this.S.push(1.0670099999999999E-08);
		this.S.push(-1.09321E-08);
		this.S.push(-4.3945999999999997E-09);
		this.S.push(6.0829999999999998E-09);
		this.S.push(3.1072000000000002E-09);
		this.S.push(3.3685000000000001E-09);
		this.S.push(3.4849999999999999E-09);
		this.S.push(7.1894999999999996E-09);
		this.S.push(-6.7366000000000001E-09);
		this.S.push(-4.1709999999999998E-09);
		this.S.push(-5.1538000000000001E-09);
		this.S.push(-3.33624E-08);
		this.S.push(5.3556E-09);
		this.S.push(-2.0874299999999999E-08);
		this.S.push(-1.3702399999999999E-08);
		this.S.push(-1.4079000000000001E-09);
		this.S.push(1.09014E-08);
		this.S.push(4.2003000000000001E-09);
		this.S.push(-3.1340000000000001E-09);
		this.S.push(-1.6102300000000001E-08);
		this.S.push(-7.2531000000000001E-09);
		this.S.push(7.6165999999999995E-09);
		this.S.push(1.0877999999999999E-09);
		this.S.push(-9.772000000000001E-10);
		this.S.push(-6.2682000000000003E-09);
		this.S.push(-1.9558999999999998E-09);
		this.S.push(-3.3483000000000001E-09);
		this.S.push(-7.7404000000000003E-09);
		this.S.push(-1.7867E-09);
		this.S.push(7.1017999999999996E-09);
		this.S.push(8.7396999999999995E-09);
		this.S.push(2.1175999999999998E-09);
		this.S.push(3.7963999999999998E-09);
		this.S.push(3.2960999999999998E-09);
		this.S.push(7.1842999999999997E-09);
		this.S.push(-7.5292E-09);
		this.S.push(-2.663E-10);
		this.S.push(-7.3172000000000003E-09);
		this.S.push(-7.1399999999999997E-09);
		this.S.push(1.11168E-08);
		this.S.push(3.7851999999999997E-09);
		this.S.push(-1.2863000000000001E-08);
		this.S.push(-7.5036000000000004E-09);
		this.S.push(1.6662999999999999E-09);
		this.S.push(-1.19188E-08);
		this.S.push(-1.31772E-08);
		this.S.push(3.3800999999999999E-09);
		this.S.push(5.2229000000000002E-09);
		this.S.push(3.1105E-09);
		this.S.push(3.7108E-09);
		this.S.push(-2.2594999999999999E-09);
		this.S.push(-1.2433E-09);
		this.S.push(2.0824000000000002E-09);
		this.S.push(-1.9037E-08);
		this.S.push(5.0832999999999996E-09);
		this.S.push(-1.37472E-08);
		this.S.push(-1.25965E-08);
		this.S.push(-5.9466999999999997E-09);
		this.S.push(-1.34798E-08);
		this.S.push(-1.1688E-08);
		this.S.push(-4.6885999999999997E-09);
		this.S.push(-1.4118E-09);
		this.S.push(8.0827999999999994E-09);
		this.S.push(9.3409999999999991E-10);
		this.S.push(-3.4579999999999998E-09);
		this.S.push(-2.8975E-09);
		this.S.push(-4.3441000000000003E-09);
		this.S.push(7.4653000000000007E-09);
		this.S.push(9.8834E-09);
		this.S.push(9.4764000000000001E-09);
		this.S.push(4.0699999999999999E-10);
		this.S.push(-7.2514E-09);
		this.S.push(-4.4269000000000001E-09);
		this.S.push(-1.0543400000000001E-08);
		this.S.push(-8.7291000000000004E-09);
		this.S.push(-5.9279999999999996E-10);
		this.S.push(-9.4125999999999995E-09);
		this.S.push(-1.4985199999999999E-08);
		this.S.push(-1.20752E-08);
		this.S.push(-9.5975999999999992E-09);
		this.S.push(-1.2915100000000001E-08);
		this.S.push(5.9036000000000002E-09);
		this.S.push(1.09539E-08);
		this.S.push(-2.9946E-09);
		this.S.push(-3.669E-09);
		this.S.push(-7.8313999999999992E-09);
		this.S.push(1.9857999999999999E-09);
		this.S.push(1.0409999999999999E-10);
		this.S.push(-4.9602999999999999E-09);
		this.S.push(-5.8118000000000001E-09);
		this.S.push(-9.1086000000000006E-09);
		this.S.push(4.0581000000000003E-09);
		this.S.push(4.2819000000000003E-09);
		this.S.push(1.0673400000000001E-08);
		this.S.push(1.5313299999999999E-08);
		this.S.push(-3.7544000000000002E-09);
		this.S.push(9.0104999999999999E-09);
		this.S.push(-8.6424999999999995E-09);
		this.S.push(8.4412000000000002E-09);
		this.S.push(2.9262000000000001E-09);
		this.S.push(-4.1454000000000002E-09);
		this.S.push(2.24177E-08);
		this.S.push(5.7826000000000003E-09);
		this.S.push(5.2409999999999998E-10);
		this.S.push(2.2133999999999998E-09);
		this.S.push(-1.4221000000000001E-09);
		this.S.push(2.4841000000000001E-09);
		this.S.push(4.2618999999999999E-09);
		this.S.push(-4.3685000000000004E-09);
		this.S.push(-3.5370000000000001E-09);
		this.S.push(-1.12091E-08);
		this.S.push(1.5860500000000002E-08);
		this.S.push(1.8929099999999999E-08);
		this.S.push(-1.0896400000000001E-08);
		this.S.push(7.6167E-09);
		this.S.push(-2.1785999999999999E-09);
		this.S.push(-1.2914400000000001E-08);
		this.S.push(2.3213999999999999E-09);
		this.S.push(4.6444999999999998E-09);
		this.S.push(3.0398999999999998E-09);
		this.S.push(1.0770599999999999E-08);
		this.S.push(5.6219999999999998E-09);
		this.S.push(4.5399999999999998E-10);
		this.S.push(-8.0768999999999997E-09);
		this.S.push(-5.7621999999999998E-09);
		this.S.push(2.8395E-09);
		this.S.push(1.6190999999999999E-09);
		this.S.push(-2.2236000000000001E-09);
		this.S.push(2.23187E-08);
		this.S.push(1.32542E-08);
		this.S.push(-3.2617E-09);
		this.S.push(-7.7411000000000001E-09);
		this.S.push(1.6121E-09);
		this.S.push(-5.5616000000000003E-09);
		this.S.push(5.3421000000000004E-09);
		this.S.push(-4.0463E-09);
		this.S.push(-6.5115000000000001E-09);
		this.S.push(5.2115E-09);
		this.S.push(9.0297999999999996E-09);
		this.S.push(3.0135E-09);
		this.S.push(-5.7345E-09);
		this.S.push(-1.5149999999999999E-10);
		this.S.push(-4.7129999999999998E-09);
		this.S.push(2.4227999999999999E-09);
		this.S.push(3.6872999999999999E-09);
		this.S.push(-1.9882999999999998E-09);
		this.S.push(4.1806999999999998E-09);
		this.S.push(8.4745999999999997E-09);
		this.S.push(3.4241000000000002E-09);
		this.S.push(-5.8837999999999999E-09);
		this.S.push(7.0090000000000003E-10);
		this.S.push(-5.5580999999999997E-09);
		this.S.push(-9.0752999999999999E-09);
		this.S.push(-2.0044999999999999E-09);
		this.S.push(-1.3228699999999999E-08);
		this.S.push(5.6377000000000001E-09);
		this.S.push(4.1636E-09);
		this.S.push(-6.4260000000000004E-10);
		this.S.push(-1.0896400000000001E-08);
		this.S.push(-9.1901000000000003E-09);
		this.S.push(-1.0824E-08);
		this.S.push(1.18854E-08);
		this.S.push(-8.0894000000000006E-09);
		this.S.push(2.9153000000000001E-09);
		this.S.push(1.6815E-09);
		this.S.push(-8.4043E-09);
		this.S.push(6.1025000000000004E-09);
		this.S.push(6.3699999999999997E-11);
		this.S.push(-7.1528000000000004E-09);
		this.S.push(-8.0674000000000005E-09);
		this.S.push(-1.9524E-09);
		this.S.push(7.7399999999999999E-11);
		this.S.push(-3.2617E-09);
		this.S.push(-7.7411000000000001E-09);
		this.S.push(1.3169899999999999E-08);
		this.S.push(-6.1479999999999999E-10);
		this.S.push(-1.3781699999999999E-08);
		this.S.push(-9.3040000000000001E-10);
		this.S.push(-3.2619000000000001E-09);
		this.S.push(-2.9426000000000002E-09);
		this.S.push(6.8929999999999999E-10);
		this.S.push(-6.2328999999999998E-09);
		this.S.push(4.5286999999999999E-09);
		this.S.push(4.8391E-09);
		this.S.push(-4.5420999999999999E-09);
		this.S.push(5.2190999999999999E-09);
		this.S.push(1.4492999999999999E-09);
		this.S.push(3.9942000000000001E-09);
		this.S.push(-1.7208399999999999E-08);
		this.S.push(6.3145000000000001E-09);
		this.S.push(-1.5072300000000001E-08);
		this.S.push(-1.7282999999999999E-09);
		this.S.push(-5.5120999999999996E-09);
		this.S.push(-1.04979E-08);
		this.S.push(-9.5514999999999995E-09);
		this.S.push(1.7015E-09);
		this.S.push(1.3716100000000001E-08);
		this.S.push(5.3569999999999996E-09);
		this.S.push(-2.9276000000000001E-09);
		this.S.push(2.9511999999999999E-09);
		this.S.push(-8.6781000000000005E-09);
		this.S.push(1.00453E-08);
		this.S.push(-9.3520000000000004E-10);
		this.S.push(-3.7771999999999997E-09);
		this.S.push(2.7860000000000001E-09);
		this.S.push(-1.3695600000000001E-08);
		this.S.push(1.7638000000000001E-09);
		this.S.push(7.3591000000000004E-09);
		this.S.push(2.1540999999999998E-09);
		this.S.push(1.1044E-09);
		this.S.push(-1.2353000000000001E-09);
		this.S.push(1.26688E-08);
		this.S.push(1.0135699999999999E-08);
		this.S.push(-7.0194999999999996E-09);
		this.S.push(1.6316E-09);
		this.S.push(-4.1028000000000003E-09);
		this.S.push(-1.3122500000000001E-08);
		this.S.push(7.3980999999999999E-09);
		this.S.push(5.4994999999999999E-09);
		this.S.push(-5.3912000000000002E-09);
		this.S.push(-5.0892000000000002E-09);
		this.S.push(2.8652E-09);
		this.S.push(-2.5111000000000001E-09);
		this.S.push(3.2099999999999998E-10);
		this.S.push(-1.8440600000000001E-08);
		this.S.push(-1.5044100000000001E-08);
		this.S.push(-3.4620999999999999E-09);
		this.S.push(-8.0465000000000003E-09);
		this.S.push(3.3029999999999999E-09);
		this.S.push(-4.1551000000000003E-09);
		this.S.push(3.4309999999999998E-09);
		this.S.push(4.0290999999999997E-09);
		this.S.push(-4.7807000000000003E-09);
		this.S.push(1.8070000000000001E-09);
		this.S.push(-1.453E-10);
		this.S.push(4.1452999999999997E-09);
		this.S.push(-5.6003000000000002E-09);
		this.S.push(-1.4377999999999999E-09);
		this.S.push(-1.73273E-08);
		this.S.push(-1.9148E-09);
		this.S.push(3.6857000000000002E-09);
		this.S.push(4.3111000000000001E-09);
		this.S.push(-1.8424E-09);
		this.S.push(5.9459999999999999E-10);
		this.S.push(2.2099E-09);
		this.S.push(1.1197E-09);
		this.S.push(6.6707000000000001E-09);
		this.S.push(-7.7810000000000003E-10);
		this.S.push(2.4247000000000001E-09);
		this.S.push(-4.1506000000000001E-09);
		this.S.push(3.65E-09);
		this.S.push(-6.0513000000000004E-09);
		this.S.push(4.7941999999999998E-09);
		this.S.push(8.9332999999999993E-09);
		this.S.push(1.7421E-09);
		this.S.push(-1.6236000000000001E-09);
		this.S.push(-6.6836000000000004E-09);
		this.S.push(9.6230000000000008E-10);
		this.S.push(2.5193000000000002E-09);
		this.S.push(4.8661999999999996E-09);
		this.S.push(-4.9306000000000003E-09);
		this.S.push(-9.0703999999999996E-09);
		this.S.push(-3.8034999999999999E-09);
	
		this.HP = [];
		this.HP.push(2);
		this.HP.push(3);
		this.HP.push(4);
		this.HP.push(5);
		this.HP.push(6);
		this.HP.push(7);
		this.HP.push(8);
		this.HP.push(9);
		this.HP.push(10);
		this.HP.push(11);
		this.HP.push(12);
		this.HP.push(13);
		this.HP.push(14);
		this.HP.push(15);
		this.HP.push(16);
		this.HP.push(17);
		this.HP.push(18);
		this.HP.push(19);
		this.HP.push(20);
		this.HP.push(21);
		this.HP.push(22);
		this.HP.push(23);
		this.HP.push(24);
		this.HP.push(25);
		this.HP.push(26);
		this.HP.push(27);
		this.HP.push(28);
		this.HP.push(29);
		this.HP.push(30);
		this.HP.push(31);
		this.HP.push(32);
		this.HP.push(33);
		this.HP.push(34);
		this.HP.push(35);
		this.HP.push(36);
		this.HP.push(37);
		this.HP.push(0);
	
		this.CO = [];
		this.CO.push(-0.77903980555890728);
		this.CO.push(0.21380603729052017);
		this.CO.push(0.44591297812265268);
		this.CO.push(-0.90857395683624942);
		this.CO.push(0.96971757921654489);
		this.CO.push(-0.6023232318835734);
		this.CO.push(-0.031250032316161636);
		this.CO.push(0.6510132700821577);
		this.CO.push(-0.98308047036598334);
		this.CO.push(0.88070436688319187);
		this.CO.push(-0.38912704709714141);
		this.CO.push(-0.27441344866665429);
		this.CO.push(0.81668504648118057);
		this.CO.push(-0.99804687096047773);
		this.CO.push(0.73835143410227233);
		this.CO.push(-0.1523634443538715);
		this.CO.push(-0.50095705797482148);
		this.CO.push(0.93289442243000587);
		this.CO.push(-0.95256672093890038);
		this.CO.push(0.55128036369424793);
		this.CO.push(0.093628026257279173);
		this.CO.push(-0.69716028243491801);
		this.CO.push(0.99260319548570364);
		this.CO.push(-0.84939451838174718);
		this.CO.push(0.33082108540013244);
		this.CO.push(0.33394893029193551);
		this.CO.push(-0.8511401048426015);
		this.CO.push(0.99219511326800103);
		this.CO.push(-0.69477887139100147);
		this.CO.push(0.090325680481764592);
		this.CO.push(0.55404427027202174);
		this.CO.push(-0.95357076164924959);
		this.CO.push(0.93169489121175919);
		this.CO.push(-0.49808405213042273);
		this.CO.push(-0.15564028496440485);
		this.CO.push(0.74058400680202852);
		this.CO.push(0);
	
		this.SI = [];
		this.SI.push(0.62697446627015052);
		this.SI.push(-0.97687613258699546);
		this.SI.push(0.89507631850127012);
		this.SI.push(-0.41772402966422861);
		this.SI.push(-0.24422902480746234);
		this.SI.push(0.79825229365992256);
		this.SI.push(-0.99951159847209325);
		this.SI.push(0.75906634899522163);
		this.SI.push(-0.18317420338300106);
		this.SI.push(-0.47366635742141988);
		this.SI.push(0.92118409735375872);
		this.SI.push(-0.96161180275143954);
		this.SI.push(0.57708364632350484);
		this.SI.push(0.062469539505262683);
		this.SI.push(-0.67441616214257349);
		this.SI.push(0.98832453213740712);
		this.SI.push(-0.86547214054827371);
		this.SI.push(0.3601499640413498);
		this.SI.push(0.30432982463063252);
		this.SI.push(-0.83432005885339844);
		this.SI.push(0.99560724821546276);
		this.SI.push(-0.71691529527222719);
		this.SI.push(0.12140385624670214);
		this.SI.push(0.52775842214316249);
		this.SI.push(-0.94369349338367214);
		this.SI.push(0.94259116904248141);
		this.SI.push(-0.52493858872112342);
		this.SI.push(-0.124695056867139);
		this.SI.push(0.71922341443298909);
		this.SI.push(-0.9959122809994394);
		this.SI.push(0.83248720505407314);
		this.SI.push(-0.30116905971176733);
		this.SI.push(-0.36324183361764484);
		this.SI.push(0.86712875457646932);
		this.SI.push(-0.98781379910193534);
		this.SI.push(0.67196378538508517);
		this.SI.push(0);
	
		this.AR = [];
		this.AR.push(0.90596306682259042);
		this.AR.push(0.82076907844659341);
		this.AR.push(0.74358647146262702);
		this.AR.push(0.67366188013407013);
		this.AR.push(0.6103127829277345);
		this.AR.push(0.55292084054224022);
		this.AR.push(0.50092586040777243);
		this.AR.push(0.45382032874577033);
		this.AR.push(0.41114445681695427);
		this.AR.push(0.37248169300499601);
		this.AR.push(0.33745465693007681);
		this.AR.push(0.30572145590593752);
		this.AR.push(0.27697234778601049);
		this.AR.push(0.25092671762526719);
		this.AR.push(0.22733033864751323);
		this.AR.push(0.20595289078291915);
		this.AR.push(0.18658571255467143);
		this.AR.push(0.16903976437130844);
		this.AR.push(0.15314378334479864);
		this.AR.push(0.13874261162386811);
		this.AR.push(0.12569568192573513);
		this.AR.push(0.11387564548379585);
		this.AR.push(0.10316712901890175);
		this.AR.push(0.0934656086012461);
		this.AR.push(0.084676389410824809);
		this.AR.push(0.076713681438094761);
		this.AR.push(0.069499762102907564);
		this.AR.push(0.062964217618190585);
		this.AR.push(0.057043255693460922);
		this.AR.push(0.051679082869593052);
		this.AR.push(0.046819340407115315);
		this.AR.push(0.04241659322184102);
		this.AR.push(0.038427866879425392);
		this.AR.push(0.034814228129534476);
		this.AR.push(0.031540404885294353);
		this.AR.push(0.028574441938707486);
		this.AR.push(0);
	
		this.CF = [];
		this.CF.push(0.93180338993169209);
		this.CF.push(0.868257557488193);
		this.CF.push(0.8090453354013093);
		this.CF.push(0.75387118613536286);
		this.CF.push(0.7024597268127567);
		this.CF.push(0.65455435473461698);
		this.CF.push(0.60991596663626746);
		this.CF.push(0.56832176528513878);
		this.CF.push(0.52956414746465574);
		this.CF.push(0.49344966779385269);
		this.CF.push(0.45979807321097926);
		this.CF.push(0.42844140330205083);
		this.CF.push(0.3992231519839422);
		this.CF.push(0.37199748635785246);
		this.CF.push(0.34662851883431528);
		this.CF.push(0.32298962889681637);
		this.CF.push(0.30096283111883271);
		this.CF.push(0.28043818627996769);
		this.CF.push(0.26131325264196925);
		this.CF.push(0.24349257464586366);
		this.CF.push(0.22688720647821134);
		this.CF.push(0.21141426812852909);
		this.CF.push(0.19699653172209111);
		this.CF.push(0.18356203606343061);
		this.CF.push(0.17104372746666816);
		this.CF.push(0.15937912507999386);
		this.CF.push(0.14851000903388545);
		this.CF.push(0.13838212985656068);
		this.CF.push(0.12894493770631085);
		this.CF.push(0.12015133006927131);
		this.CF.push(0.11195741666334866);
		this.CF.push(0.10432230037490318);
		this.CF.push(0.097207873134807027);
		this.CF.push(0.090578625715063046);
		this.CF.push(0.084401470496649686);
		this.CF.push(0.078645576323997879);
		this.CF.push(0);
	
		this.PNK = [];
		this.PNK.push(0.29089327063157433);
		this.PNK.push(0.96147609795796074);
		this.PNK.push(1.9929057067906695);
		this.PNK.push(2.852080391448482);
		this.PNK.push(2.6751984765768806);
		this.PNK.push(1.0472212836930446);
		this.PNK.push(-1.1988598034590252);
		this.PNK.push(-2.2804345150557359);
		this.PNK.push(-1.1293205866090439);
		this.PNK.push(1.1403084488907371);
		this.PNK.push(2.0354551847450315);
		this.PNK.push(0.48276794194439082);
		this.PNK.push(-1.6171794809836411);
		this.PNK.push(-1.5503343002056609);
		this.PNK.push(0.60493754639339159);
		this.PNK.push(1.8621354405329114);
		this.PNK.push(0.41794829019526042);
		this.PNK.push(-1.6115367529736164);
		this.PNK.push(-1.1679804969994156);
		this.PNK.push(1.0716797147348209);
		this.PNK.push(1.5850389233986588);
		this.PNK.push(-0.45797638107805388);
		this.PNK.push(-1.723479126358191);
		this.PNK.push(-0.10194460999719542);
		this.PNK.push(1.6742132263995639);
		this.PNK.push(0.55274470231814254);
		this.PNK.push(-1.5235707057849284);
		this.PNK.push(-0.88507487987264877);
		this.PNK.push(1.3378229934051453);
		this.PNK.push(1.1129249869847508);
		this.PNK.push(-1.1615627754195379);
		this.PNK.push(-1.2582568842298383);
		this.PNK.push(1.0218141707166259);
		this.PNK.push(1.3420804385948193);
		this.PNK.push(-0.93336139182442901);
		this.PNK.push(0);
		this.PNK.push(0);
	
		this.ANAI = [];
		this.ANAI.push(1);
		this.ANAI.push(36);
		this.ANAI.push(71);
		this.ANAI.push(106);
		this.ANAI.push(140);
		this.ANAI.push(173);
		this.ANAI.push(205);
		this.ANAI.push(236);
		this.ANAI.push(266);
		this.ANAI.push(295);
		this.ANAI.push(323);
		this.ANAI.push(350);
		this.ANAI.push(376);
		this.ANAI.push(401);
		this.ANAI.push(425);
		this.ANAI.push(448);
		this.ANAI.push(470);
		this.ANAI.push(491);
		this.ANAI.push(511);
		this.ANAI.push(530);
		this.ANAI.push(548);
		this.ANAI.push(565);
		this.ANAI.push(581);
		this.ANAI.push(596);
		this.ANAI.push(610);
		this.ANAI.push(623);
		this.ANAI.push(635);
		this.ANAI.push(646);
		this.ANAI.push(656);
		this.ANAI.push(665);
		this.ANAI.push(673);
		this.ANAI.push(680);
		this.ANAI.push(686);
		this.ANAI.push(691);
		this.ANAI.push(695);
		this.ANAI.push(698);
		this.ANAI.push(700);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
		this.ANAI.push(0);
	
}
}

class Density_CategoryObject_2 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["v", 1.7737490756446463 ],
			["y", 4112.9884575937604 ],
			["u", -0.44668389543569337 ],
			["x", -5110.5458047301981 ],
			["w", 6.9300634873392948 ],
			["z", 2555.3253638965743 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, -5110.5458047301981);
		this.addVariableValue("Formula_2", 0, 4112.9884575937604);
		this.addVariableValue("Formula_3", 0, 2555.3253638965743);
		this.addVariableValue("Formula_4", 0, -0.44668389543569337);
		this.addVariableValue("Formula_5", 0, 1.7737490756446463);
		this.addVariableValue("Formula_6", 0, 6.9300634873392948);
		this.addVariableValue("Formula_7", 0, 7.1673908937873003);
		this.addVariableValue("Formula_8", 0, 1770475503);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.aliasName0.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.aliasName1.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_1 = this.convert<number>(this.variable);
			this.variable = this.aliasName2.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.aliasName3.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_3 = this.convert<number>(this.variable);
			this.variable = this.aliasName4.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_4 = this.convert<number>(this.variable);
			this.variable = this.aliasName5.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_5 = this.convert<number>(this.variable);
			this.variable = this.aliasName6.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_6 = this.convert<number>(this.variable);
			this.variable = Math.pow(this.var_6, this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_8 = this.convert<number>(this.variable);
			this.variable = this.aliasName9.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_9 = this.convert<number>(this.variable);
			this.variable = Math.pow(this.var_9, this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
			this.variable = (this.var_8) + (this.var_11);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_12 = this.convert<number>(this.variable);
			this.variable = this.aliasName13.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_13 = this.convert<number>(this.variable);
			this.variable = Math.pow(this.var_13, this.var_14);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_15 = this.convert<number>(this.variable);
			this.variable = (this.var_12) + (this.var_15);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_16 = this.convert<number>(this.variable);
			this.variable = Math.sqrt(this.var_16);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_17 = this.convert<number>(this.variable);
			this.var_18 = this.getInternalTime();
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "x");
		this.aliasName1 = new AliasName(this.alias, "y");
		this.aliasName2 = new AliasName(this.alias, "z");
		this.aliasName3 = new AliasName(this.alias, "u");
		this.aliasName4 = new AliasName(this.alias, "v");
		this.aliasName5 = new AliasName(this.alias, "w");
		this.aliasName6 = new AliasName(this.alias, "u");
		this.aliasName9 = new AliasName(this.alias, "v");
		this.aliasName13 = new AliasName(this.alias, "w");
	}
	
	aliasName0 ! : IAliasName;
	aliasName1 ! : IAliasName;
	aliasName2 ! : IAliasName;
	aliasName3 ! : IAliasName;
	aliasName4 ! : IAliasName;
	aliasName5 ! : IAliasName;
	aliasName6 ! : IAliasName;
	aliasName9 ! : IAliasName;
	aliasName13 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	var_6 : number  = 0;
	var_7 : number  = 2;
	var_8 : number  = 0;
	var_9 : number  = 0;
	var_10 : number  = 2;
	var_11 : number  = 0;
	var_12 : number  = 0;
	var_13 : number  = 0;
	var_14 : number  = 2;
	var_15 : number  = 0;
	var_16 : number  = 0;
	var_17 : number  = 0;
	var_18 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	
	get_2() : any
	{
		return this.success ? this.var_2 : undefined;
	}
	
	get_3() : any
	{
		return this.success ? this.var_3 : undefined;
	}
	
	get_4() : any
	{
		return this.success ? this.var_4 : undefined;
	}
	
	get_5() : any
	{
		return this.success ? this.var_5 : undefined;
	}
	
	get_6() : any
	{
		return this.success ? this.var_6 : undefined;
	}
	
	get_7() : any
	{
		return this.success ? this.var_7 : undefined;
	}
	
	get_8() : any
	{
		return this.success ? this.var_8 : undefined;
	}
	
	get_9() : any
	{
		return this.success ? this.var_9 : undefined;
	}
	
	get_10() : any
	{
		return this.success ? this.var_10 : undefined;
	}
	
	get_11() : any
	{
		return this.success ? this.var_11 : undefined;
	}
	
	get_12() : any
	{
		return this.success ? this.var_12 : undefined;
	}
	
	get_13() : any
	{
		return this.success ? this.var_13 : undefined;
	}
	
	get_14() : any
	{
		return this.success ? this.var_14 : undefined;
	}
	
	get_15() : any
	{
		return this.success ? this.var_15 : undefined;
	}
	
	get_16() : any
	{
		return this.success ? this.var_16 : undefined;
	}
	
	get_17() : any
	{
		return this.success ? this.var_17 : undefined;
	}
	
	get_18() : any
	{
		return this.success ? this.var_18 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_0());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_1());
		var x2 = v.get("Formula_3");
		x2?.setIValue(this.get_2());
		var x3 = v.get("Formula_4");
		x3?.setIValue(this.get_3());
		var x4 = v.get("Formula_5");
		x4?.setIValue(this.get_4());
		var x5 = v.get("Formula_6");
		x5?.setIValue(this.get_5());
		var x6 = v.get("Formula_7");
		x6?.setIValue(this.get_17());
		var x7 = v.get("Formula_8");
		x7?.setIValue(this.get_18());
	}
	
}

class Density_CategoryObject_3 extends ObjectTransformer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	let map = new Map<string, string>(
	[
		["x", "Vector.Formula_1" ],
		["y", "Vector.Formula_2" ],
		["z", "Vector.Formula_3" ]
	]);
		this.setLinks(map);
	}
}

class Density_CategoryObject_4 extends ObjectTransformer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	let map = new Map<string, string>(
	[
		["t", "Vector.Formula_8" ],
		["x", "Vector.Formula_1" ],
		["y", "Vector.Formula_2" ],
		["z", "Vector.Formula_3" ]
	]);
		this.setLinks(map);
	}
}

class Density_CategoryObject_5 extends DifferentialEquationSolverFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["x", -5448.3481532400001 ],
			["o", 0.00014584231700000001 ],
			["s", 1.6189340462770081E-13 ],
			["q", 5.3174953569821228E-09 ],
			["v", 1.2168189383400001 ],
			["u", -0.98539477743199999 ],
			["w", 7.45047785592 ],
			["z", 0 ],
			["y", -4463.9369842100004 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("u", 0, -0.98539477743199999);
		this.addVariableValue("v", 0, 1.2168189383400001);
		this.addVariableValue("w", 0, 7.45047785592);
		this.addVariableValue("x", 0, -5448.3481532400001);
		this.addVariableValue("y", 0, -4463.9369842100004);
		this.addVariableValue("z", 0, 0);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.aliasName1.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_1 = this.convert<number>(this.variable);
			this.variable = this.value2.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = (this.var_1) * (this.var_2);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = this.aliasName4.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_4 = this.convert<number>(this.variable);
			this.variable = this.measurement5.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = (this.var_4) * (this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_6 = this.convert<number>(this.variable);
			this.variable = this.measurement7.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
			this.variable = (this.var_6) * (this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_8 = this.convert<number>(this.variable);
			this.variable = this.value9.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_9 = this.convert<number>(this.variable);
			this.variable = (this.var_8) * (this.var_9);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_10 = this.convert<number>(this.variable);
			this.variable = (this.var_3) - (this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
			this.variable = (this.var_0) + (this.var_11);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_12 = this.convert<number>(this.variable);
			this.variable = this.aliasName13.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_13 = this.convert<number>(this.variable);
			this.variable = this.value14.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_14 = this.convert<number>(this.variable);
			this.variable = (this.var_13) * (this.var_14);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_15 = this.convert<number>(this.variable);
			this.variable = (this.var_12) + (this.var_15);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_16 = this.convert<number>(this.variable);
			this.variable = this.measurement17.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_17 = this.convert<number>(this.variable);
			this.variable = this.value18.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_18 = this.convert<number>(this.variable);
			this.variable = (this.var_1) * (this.var_18);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_19 = this.convert<number>(this.variable);
			this.variable = (this.var_4) * (this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_20 = this.convert<number>(this.variable);
			this.variable = (this.var_20) * (this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_21 = this.convert<number>(this.variable);
			this.variable = (this.var_21) * (this.var_14);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_22 = this.convert<number>(this.variable);
			this.variable = (this.var_19) - (this.var_22);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_23 = this.convert<number>(this.variable);
			this.variable = (this.var_13) * (this.var_9);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_24 = this.convert<number>(this.variable);
			this.variable = (this.var_23) - (this.var_24);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_25 = this.convert<number>(this.variable);
			this.variable = (this.var_17) + (this.var_25);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_26 = this.convert<number>(this.variable);
			this.variable = this.measurement27.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_27 = this.convert<number>(this.variable);
			this.variable = (this.var_4) * (this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_28 = this.convert<number>(this.variable);
			this.variable = (this.var_28) * (this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_29 = this.convert<number>(this.variable);
			this.variable = this.value30.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_30 = this.convert<number>(this.variable);
			this.variable = (this.var_29) * (this.var_30);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_31 = this.convert<number>(this.variable);
			this.variable = (this.var_27) - (this.var_31);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_32 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement0 = all[0].getMeasurement(0);
		this.value2 = this.output[3];
		this.measurement5 = all[1].getMeasurement(0);
		this.measurement7 = all[2].getMeasurement(6);
		this.value9 = this.output[0];
		this.value14 = this.output[1];
		this.measurement17 = all[0].getMeasurement(1);
		this.value18 = this.output[4];
		this.measurement27 = all[0].getMeasurement(2);
		this.value30 = this.output[2];
		this.aliasName1 = new AliasName(this.alias, "q");
		this.aliasName4 = new AliasName(this.alias, "s");
		this.aliasName13 = new AliasName(this.alias, "o");
	}
	
	measurement0 ! : IMeasurement;
	value2 ! : IValue;
	measurement5 ! : IMeasurement;
	measurement7 ! : IMeasurement;
	value9 ! : IValue;
	value14 ! : IValue;
	measurement17 ! : IMeasurement;
	value18 ! : IValue;
	measurement27 ! : IMeasurement;
	value30 ! : IValue;
	aliasName1 ! : IAliasName;
	aliasName4 ! : IAliasName;
	aliasName13 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	var_6 : number  = 0;
	var_7 : number  = 0;
	var_8 : number  = 0;
	var_9 : number  = 0;
	var_10 : number  = 0;
	var_11 : number  = 0;
	var_12 : number  = 0;
	var_13 : number  = 0;
	var_14 : number  = 0;
	var_15 : number  = 0;
	var_16 : number  = 0;
	var_17 : number  = 0;
	var_18 : number  = 0;
	var_19 : number  = 0;
	var_20 : number  = 0;
	var_21 : number  = 0;
	var_22 : number  = 0;
	var_23 : number  = 0;
	var_24 : number  = 0;
	var_25 : number  = 0;
	var_26 : number  = 0;
	var_27 : number  = 0;
	var_28 : number  = 0;
	var_29 : number  = 0;
	var_30 : number  = 0;
	var_31 : number  = 0;
	var_32 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	
	get_2() : any
	{
		return this.success ? this.var_2 : undefined;
	}
	
	get_3() : any
	{
		return this.success ? this.var_3 : undefined;
	}
	
	get_4() : any
	{
		return this.success ? this.var_4 : undefined;
	}
	
	get_5() : any
	{
		return this.success ? this.var_5 : undefined;
	}
	
	get_6() : any
	{
		return this.success ? this.var_6 : undefined;
	}
	
	get_7() : any
	{
		return this.success ? this.var_7 : undefined;
	}
	
	get_8() : any
	{
		return this.success ? this.var_8 : undefined;
	}
	
	get_9() : any
	{
		return this.success ? this.var_9 : undefined;
	}
	
	get_10() : any
	{
		return this.success ? this.var_10 : undefined;
	}
	
	get_11() : any
	{
		return this.success ? this.var_11 : undefined;
	}
	
	get_12() : any
	{
		return this.success ? this.var_12 : undefined;
	}
	
	get_13() : any
	{
		return this.success ? this.var_13 : undefined;
	}
	
	get_14() : any
	{
		return this.success ? this.var_14 : undefined;
	}
	
	get_15() : any
	{
		return this.success ? this.var_15 : undefined;
	}
	
	get_16() : any
	{
		return this.success ? this.var_16 : undefined;
	}
	
	get_17() : any
	{
		return this.success ? this.var_17 : undefined;
	}
	
	get_18() : any
	{
		return this.success ? this.var_18 : undefined;
	}
	
	get_19() : any
	{
		return this.success ? this.var_19 : undefined;
	}
	
	get_20() : any
	{
		return this.success ? this.var_20 : undefined;
	}
	
	get_21() : any
	{
		return this.success ? this.var_21 : undefined;
	}
	
	get_22() : any
	{
		return this.success ? this.var_22 : undefined;
	}
	
	get_23() : any
	{
		return this.success ? this.var_23 : undefined;
	}
	
	get_24() : any
	{
		return this.success ? this.var_24 : undefined;
	}
	
	get_25() : any
	{
		return this.success ? this.var_25 : undefined;
	}
	
	get_26() : any
	{
		return this.success ? this.var_26 : undefined;
	}
	
	get_27() : any
	{
		return this.success ? this.var_27 : undefined;
	}
	
	get_28() : any
	{
		return this.success ? this.var_28 : undefined;
	}
	
	get_29() : any
	{
		return this.success ? this.var_29 : undefined;
	}
	
	get_30() : any
	{
		return this.success ? this.var_30 : undefined;
	}
	
	get_31() : any
	{
		return this.success ? this.var_31 : undefined;
	}
	
	get_32() : any
	{
		return this.success ? this.var_32 : undefined;
	}
	save() : void {
		var v = this.derivations;
		var x0 = v.get("v");
		x0?.setIValue(this.get_26());
		var x1 = v.get("u");
		x1?.setIValue(this.get_16());
		var x2 = v.get("z");
		x2?.setIValue(this.get_30());
		var x3 = v.get("y");
		x3?.setIValue(this.get_14());
		var x4 = v.get("x");
		x4?.setIValue(this.get_9());
		var x5 = v.get("w");
		x5?.setIValue(this.get_32());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
			["v", "Vector.u" ],
			["u", "Vector.u" ],
			["z", "Vector.z" ],
			["y", "Vector.y" ],
			["x", "Vector.x" ],
			["w", "Vector.w" ]
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class Density_CategoryObject_6 extends RecursiveFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["x", 0 ],
			["y", false ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("x", 0, 0);
		this.addVariableValue("y", false, false);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = (this.var_0) > (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<boolean>(this.variable);
			this.variable = this.value3.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_3 = this.convert<number>(this.variable);
			this.variable = (this.var_3) < (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<boolean>(this.variable);
			this.variable = (this.var_2) && (this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_6 = this.convert<boolean>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement0 = all[0].getMeasurement(5);
		this.value3 = this.output[0];
	}
	
	measurement0 ! : IMeasurement;
	value3 ! : IValue;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : boolean  = false;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : boolean  = false;
	var_6 : boolean  = false;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	
	get_2() : any
	{
		return this.success ? this.var_2 : undefined;
	}
	
	get_3() : any
	{
		return this.success ? this.var_3 : undefined;
	}
	
	get_4() : any
	{
		return this.success ? this.var_4 : undefined;
	}
	
	get_5() : any
	{
		return this.success ? this.var_5 : undefined;
	}
	
	get_6() : any
	{
		return this.success ? this.var_6 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("x");
		x0?.setIValue(this.get_0());
		var x1 = v.get("y");
		x1?.setIValue(this.get_6());
	}
	
}

class Density_CategoryObject_7 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_0 extends ObjectTransformerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_1 extends ObjectTransformerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_3 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_4 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_5 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_6 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_7 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_8 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_9 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_10 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Density_CategoryArrow_11 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Density extends Desktop
{
	constructor()
	{
		super();

		this.name = "Density";

		new Density_CategoryObject_0(this, "Atmosphere");
		new Density_CategoryObject_1(this, "Gravity");
		new Density_CategoryObject_2(this, "Vector");
		new Density_CategoryObject_3(this, "G-transformation");
		new Density_CategoryObject_4(this, "A-transformation");
		new Density_CategoryObject_5(this, "Motion equations");
		new Density_CategoryObject_6(this, "Recursive");
		new Density_CategoryObject_7(this, "Chart");
		new Density_CategoryArrow_0(this, "");
		new Density_CategoryArrow_1(this, "");
		new Density_CategoryArrow_2(this, "");
		new Density_CategoryArrow_3(this, "");
		new Density_CategoryArrow_4(this, "");
		new Density_CategoryArrow_5(this, "");
		new Density_CategoryArrow_6(this, "");
		new Density_CategoryArrow_7(this, "");
		new Density_CategoryArrow_8(this, "");
		new Density_CategoryArrow_9(this, "");
		new Density_CategoryArrow_10(this, "");
		new Density_CategoryArrow_11(this, "");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[3]);
		arrows[0].setTarget(objects[1]);
		arrows[1].setSource(objects[4]);
		arrows[1].setTarget(objects[0]);
		arrows[2].setSource(objects[3]);
		arrows[2].setTarget(objects[2]);
		arrows[3].setSource(objects[4]);
		arrows[3].setTarget(objects[2]);
		arrows[4].setSource(objects[5]);
		arrows[4].setTarget(objects[3]);
		arrows[5].setSource(objects[5]);
		arrows[5].setTarget(objects[4]);
		arrows[6].setSource(objects[5]);
		arrows[6].setTarget(objects[2]);
		arrows[7].setSource(objects[6]);
		arrows[7].setTarget(objects[5]);
		arrows[8].setSource(objects[7]);
		arrows[8].setTarget(objects[6]);
		arrows[9].setSource(objects[7]);
		arrows[9].setTarget(objects[2]);
		arrows[10].setSource(objects[7]);
		arrows[10].setTarget(objects[5]);
		arrows[11].setSource(objects[7]);
		arrows[11].setTarget(objects[4]);
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
		(objects[3] as unknown as IPostSetArrow).postSetArrow();
		(objects[4] as unknown as IPostSetArrow).postSetArrow();
		(objects[5] as unknown as IPostSetArrow).postSetArrow();
		(objects[6] as unknown as IPostSetArrow).postSetArrow();
	}
}
