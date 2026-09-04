import { AliasName } from "../Library/AliasName";
import { BelongsToCollection } from "../Library/Arrows/BelognsToCollection";
import { Desktop } from "../Library/Desktop";
import { EventLink } from "../Library/Event/Objects/EventLink";
import { TimerObject } from "../Library/Event/Objects/TimerObject";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { ReferenceFrameArrow } from "../Library/Motion6D/Arrows/ReferenceFrameArrow";
import { ReferenceFrameData } from "../Library/Motion6D/Objects/ReferenceFrameData";
import { RigidReferenceFrame } from "../Library/Motion6D/Objects/RigidReferenceFrame";
import { SerializablePosition } from "../Library/Motion6D/Objects/SerializablePosition";
import { Basic3DShape } from "../Library/Motion6D/Objects/Shapes/Basic3DShape";
import { BasicCamera } from "../Library/Motion6D/Visible/BasicCamera";
import { IVisible } from "../Library/Motion6D/Visible/Interfaces/IVisible";
import { VisibleConsumerLink } from "../Library/Motion6D/Visible/VisibleConsumerLink";
import { TimeSpan } from "../Library/Utilities/DateTime/TimeSpan";

class Frame_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 5 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.aliasName0.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.var_1 = this.getInternalTime();
			this.variable = (this.var_0) * (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "a");
	}
	
	aliasName0 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	
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
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_2());
	}
	
}

class Frame_CategoryObject_1 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, -19.851545295388156);
		this.addVariableValue("Formula_2", 0, 100.02252954394234);
		this.addVariableValue("Formula_3", 0, 0);
		this.addVariableValue("Formula_4", 0, 0.91141446721709518);
		this.addVariableValue("Formula_5", 0, 0);
		this.addVariableValue("Formula_6", 0, -0.024437251972197357);
		this.addVariableValue("Formula_7", 0, 0.06414828081070735);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = (this.var_3) / (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
			this.variable = (this.var_7) / (this.var_8);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_9);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_10 = this.convert<number>(this.variable);
			this.variable = (this.var_5) - (this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
			this.variable = (this.var_11) / (this.var_12);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_13 = this.convert<number>(this.variable);
			this.variable = (this.var_2) * (this.var_13);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_14 = this.convert<number>(this.variable);
			this.variable = (this.var_15) / (this.var_16);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_17 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_19);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_20 = this.convert<number>(this.variable);
			this.variable = (this.var_20) / (this.var_21);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_22 = this.convert<number>(this.variable);
			this.variable = (this.var_18) * (this.var_22);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_23 = this.convert<number>(this.variable);
			this.variable = Math.sin(this.var_23);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_24 = this.convert<number>(this.variable);
			this.variable = (this.var_17) * (this.var_24);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_25 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_27);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_28 = this.convert<number>(this.variable);
			this.variable = (this.var_28) / (this.var_29);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_30 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_30);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_31 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_32);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_33 = this.convert<number>(this.variable);
			this.variable = (this.var_33) / (this.var_34);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_35 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_35);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_36 = this.convert<number>(this.variable);
			this.variable = (this.var_31) - (this.var_36);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_37 = this.convert<number>(this.variable);
			this.variable = (this.var_26) + (this.var_37);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_38 = this.convert<number>(this.variable);
			this.variable = (this.var_38) / (this.var_39);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_40 = this.convert<number>(this.variable);
			this.variable = (this.var_25) * (this.var_40);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_41 = this.convert<number>(this.variable);
			this.variable = (this.var_14) + (this.var_41);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_42 = this.convert<number>(this.variable);
			this.variable = (this.var_43) - (this.var_0);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_44 = this.convert<number>(this.variable);
			this.variable = (this.var_45) / (this.var_46);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_47 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_48);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_49 = this.convert<number>(this.variable);
			this.variable = (this.var_49) / (this.var_50);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_51 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_51);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_52 = this.convert<number>(this.variable);
			this.variable = (this.var_47) + (this.var_52);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_53 = this.convert<number>(this.variable);
			this.variable = (this.var_53) / (this.var_54);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_55 = this.convert<number>(this.variable);
			this.variable = (this.var_44) * (this.var_55);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_56 = this.convert<number>(this.variable);
			this.variable = (this.var_42) + (this.var_56);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_57 = this.convert<number>(this.variable);
			this.variable = (this.var_59) / (this.var_60);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_61 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_62);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_63 = this.convert<number>(this.variable);
			this.variable = (this.var_63) / (this.var_64);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_65 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_65);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_66 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_67);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_68 = this.convert<number>(this.variable);
			this.variable = (this.var_68) / (this.var_69);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_70 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_70);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_71 = this.convert<number>(this.variable);
			this.variable = (this.var_66) - (this.var_71);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_72 = this.convert<number>(this.variable);
			this.variable = (this.var_72) / (this.var_73);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_74 = this.convert<number>(this.variable);
			this.variable = (this.var_61) * (this.var_74);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_75 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_77);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_78 = this.convert<number>(this.variable);
			this.variable = (this.var_78) / (this.var_79);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_80 = this.convert<number>(this.variable);
			this.variable = (this.var_76) * (this.var_80);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_81 = this.convert<number>(this.variable);
			this.variable = Math.cos(this.var_81);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_82 = this.convert<number>(this.variable);
			this.variable = (this.var_82) - (this.var_83);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_84 = this.convert<number>(this.variable);
			this.variable = (this.var_75) * (this.var_84);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_85 = this.convert<number>(this.variable);
			this.variable = (this.var_58) - (this.var_85);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_86 = this.convert<number>(this.variable);
			this.variable = (this.var_87) / (this.var_88);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_89 = this.convert<number>(this.variable);
			this.variable = (this.var_90) / (this.var_91);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_92 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_93);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_94 = this.convert<number>(this.variable);
			this.variable = (this.var_94) / (this.var_95);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_96 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_96);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_97 = this.convert<number>(this.variable);
			this.variable = (this.var_92) + (this.var_97);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_98 = this.convert<number>(this.variable);
			this.variable = (this.var_98) / (this.var_99);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_100 = this.convert<number>(this.variable);
			this.variable = (this.var_89) * (this.var_100);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_101 = this.convert<number>(this.variable);
			this.variable = (this.var_86) + (this.var_101);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_102 = this.convert<number>(this.variable);
			this.variable = (this.var_104) / (this.var_105);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_106 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_107);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_108 = this.convert<number>(this.variable);
			this.variable = (this.var_108) / (this.var_109);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_110 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_110);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_111 = this.convert<number>(this.variable);
			this.variable = (this.var_106) - (this.var_111);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_112 = this.convert<number>(this.variable);
			this.variable = (this.var_112) / (this.var_113);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_114 = this.convert<number>(this.variable);
			this.variable = (this.var_116) / (this.var_117);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_118 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_119);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_120 = this.convert<number>(this.variable);
			this.variable = (this.var_120) / (this.var_121);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_122 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_122);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_123 = this.convert<number>(this.variable);
			this.variable = (this.var_118) + (this.var_123);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_124 = this.convert<number>(this.variable);
			this.variable = (this.var_124) / (this.var_125);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_126 = this.convert<number>(this.variable);
			this.variable = -(this.var_126);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_127 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_128);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_129 = this.convert<number>(this.variable);
			this.variable = (this.var_129) / (this.var_130);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_131 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_131);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_132 = this.convert<number>(this.variable);
			this.variable = (this.var_0) - (this.var_133);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_134 = this.convert<number>(this.variable);
			this.variable = (this.var_134) / (this.var_135);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_136 = this.convert<number>(this.variable);
			this.variable = Math.atan(this.var_136);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_137 = this.convert<number>(this.variable);
			this.variable = (this.var_132) - (this.var_137);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_138 = this.convert<number>(this.variable);
			this.variable = (this.var_138) / (this.var_139);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_140 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement0 = all[0].getMeasurement(0);
	}
	
	measurement0 ! : IMeasurement;
	var_0 : number  = 0;
	var_1 : number  = 10;
	var_2 : number  = 0;
	var_3 : number  = Math.PI;
	var_4 : number  = 2;
	var_5 : number  = 0;
	var_6 : number  = 10;
	var_7 : number  = 0;
	var_8 : number  = 0.1;
	var_9 : number  = 0;
	var_10 : number  = 0;
	var_11 : number  = 0;
	var_12 : number  = Math.PI;
	var_13 : number  = 0;
	var_14 : number  = 0;
	var_15 : number  = 120;
	var_16 : number  = Math.PI;
	var_17 : number  = 0;
	var_18 : number  = Math.PI;
	var_19 : number  = 10;
	var_20 : number  = 0;
	var_21 : number  = 120;
	var_22 : number  = 0;
	var_23 : number  = 0;
	var_24 : number  = 0;
	var_25 : number  = 0;
	var_26 : number  = Math.PI;
	var_27 : number  = 10;
	var_28 : number  = 0;
	var_29 : number  = 0.1;
	var_30 : number  = 0;
	var_31 : number  = 0;
	var_32 : number  = 130;
	var_33 : number  = 0;
	var_34 : number  = 0.1;
	var_35 : number  = 0;
	var_36 : number  = 0;
	var_37 : number  = 0;
	var_38 : number  = 0;
	var_39 : number  = Math.PI;
	var_40 : number  = 0;
	var_41 : number  = 0;
	var_42 : number  = 0;
	var_43 : number  = 130;
	var_44 : number  = 0;
	var_45 : number  = Math.PI;
	var_46 : number  = 2;
	var_47 : number  = 0;
	var_48 : number  = 130;
	var_49 : number  = 0;
	var_50 : number  = 0.1;
	var_51 : number  = 0;
	var_52 : number  = 0;
	var_53 : number  = 0;
	var_54 : number  = Math.PI;
	var_55 : number  = 0;
	var_56 : number  = 0;
	var_57 : number  = 0;
	var_58 : number  = 100;
	var_59 : number  = 120;
	var_60 : number  = Math.PI;
	var_61 : number  = 0;
	var_62 : number  = 10;
	var_63 : number  = 0;
	var_64 : number  = 0.1;
	var_65 : number  = 0;
	var_66 : number  = 0;
	var_67 : number  = 130;
	var_68 : number  = 0;
	var_69 : number  = 0.1;
	var_70 : number  = 0;
	var_71 : number  = 0;
	var_72 : number  = 0;
	var_73 : number  = Math.PI;
	var_74 : number  = 0;
	var_75 : number  = 0;
	var_76 : number  = Math.PI;
	var_77 : number  = 10;
	var_78 : number  = 0;
	var_79 : number  = 120;
	var_80 : number  = 0;
	var_81 : number  = 0;
	var_82 : number  = 0;
	var_83 : number  = 1;
	var_84 : number  = 0;
	var_85 : number  = 0;
	var_86 : number  = 0;
	var_87 : number  = 240;
	var_88 : number  = Math.PI;
	var_89 : number  = 0;
	var_90 : number  = Math.PI;
	var_91 : number  = 2;
	var_92 : number  = 0;
	var_93 : number  = 130;
	var_94 : number  = 0;
	var_95 : number  = 0.1;
	var_96 : number  = 0;
	var_97 : number  = 0;
	var_98 : number  = 0;
	var_99 : number  = Math.PI;
	var_100 : number  = 0;
	var_101 : number  = 0;
	var_102 : number  = 0;
	var_103 : number  = 0;
	var_104 : number  = Math.PI;
	var_105 : number  = 2;
	var_106 : number  = 0;
	var_107 : number  = 70;
	var_108 : number  = 0;
	var_109 : number  = 20;
	var_110 : number  = 0;
	var_111 : number  = 0;
	var_112 : number  = 0;
	var_113 : number  = Math.PI;
	var_114 : number  = 0;
	var_115 : number  = 0;
	var_116 : number  = Math.PI;
	var_117 : number  = 2;
	var_118 : number  = 0;
	var_119 : number  = 130;
	var_120 : number  = 0;
	var_121 : number  = 10;
	var_122 : number  = 0;
	var_123 : number  = 0;
	var_124 : number  = 0;
	var_125 : number  = Math.PI;
	var_126 : number  = 0;
	var_127 : number  = 0;
	var_128 : number  = 70;
	var_129 : number  = 0;
	var_130 : number  = 20;
	var_131 : number  = 0;
	var_132 : number  = 0;
	var_133 : number  = 130;
	var_134 : number  = 0;
	var_135 : number  = 10;
	var_136 : number  = 0;
	var_137 : number  = 0;
	var_138 : number  = 0;
	var_139 : number  = Math.PI;
	var_140 : number  = 0;
	
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
	
	get_33() : any
	{
		return this.success ? this.var_33 : undefined;
	}
	
	get_34() : any
	{
		return this.success ? this.var_34 : undefined;
	}
	
	get_35() : any
	{
		return this.success ? this.var_35 : undefined;
	}
	
	get_36() : any
	{
		return this.success ? this.var_36 : undefined;
	}
	
	get_37() : any
	{
		return this.success ? this.var_37 : undefined;
	}
	
	get_38() : any
	{
		return this.success ? this.var_38 : undefined;
	}
	
	get_39() : any
	{
		return this.success ? this.var_39 : undefined;
	}
	
	get_40() : any
	{
		return this.success ? this.var_40 : undefined;
	}
	
	get_41() : any
	{
		return this.success ? this.var_41 : undefined;
	}
	
	get_42() : any
	{
		return this.success ? this.var_42 : undefined;
	}
	
	get_43() : any
	{
		return this.success ? this.var_43 : undefined;
	}
	
	get_44() : any
	{
		return this.success ? this.var_44 : undefined;
	}
	
	get_45() : any
	{
		return this.success ? this.var_45 : undefined;
	}
	
	get_46() : any
	{
		return this.success ? this.var_46 : undefined;
	}
	
	get_47() : any
	{
		return this.success ? this.var_47 : undefined;
	}
	
	get_48() : any
	{
		return this.success ? this.var_48 : undefined;
	}
	
	get_49() : any
	{
		return this.success ? this.var_49 : undefined;
	}
	
	get_50() : any
	{
		return this.success ? this.var_50 : undefined;
	}
	
	get_51() : any
	{
		return this.success ? this.var_51 : undefined;
	}
	
	get_52() : any
	{
		return this.success ? this.var_52 : undefined;
	}
	
	get_53() : any
	{
		return this.success ? this.var_53 : undefined;
	}
	
	get_54() : any
	{
		return this.success ? this.var_54 : undefined;
	}
	
	get_55() : any
	{
		return this.success ? this.var_55 : undefined;
	}
	
	get_56() : any
	{
		return this.success ? this.var_56 : undefined;
	}
	
	get_57() : any
	{
		return this.success ? this.var_57 : undefined;
	}
	
	get_58() : any
	{
		return this.success ? this.var_58 : undefined;
	}
	
	get_59() : any
	{
		return this.success ? this.var_59 : undefined;
	}
	
	get_60() : any
	{
		return this.success ? this.var_60 : undefined;
	}
	
	get_61() : any
	{
		return this.success ? this.var_61 : undefined;
	}
	
	get_62() : any
	{
		return this.success ? this.var_62 : undefined;
	}
	
	get_63() : any
	{
		return this.success ? this.var_63 : undefined;
	}
	
	get_64() : any
	{
		return this.success ? this.var_64 : undefined;
	}
	
	get_65() : any
	{
		return this.success ? this.var_65 : undefined;
	}
	
	get_66() : any
	{
		return this.success ? this.var_66 : undefined;
	}
	
	get_67() : any
	{
		return this.success ? this.var_67 : undefined;
	}
	
	get_68() : any
	{
		return this.success ? this.var_68 : undefined;
	}
	
	get_69() : any
	{
		return this.success ? this.var_69 : undefined;
	}
	
	get_70() : any
	{
		return this.success ? this.var_70 : undefined;
	}
	
	get_71() : any
	{
		return this.success ? this.var_71 : undefined;
	}
	
	get_72() : any
	{
		return this.success ? this.var_72 : undefined;
	}
	
	get_73() : any
	{
		return this.success ? this.var_73 : undefined;
	}
	
	get_74() : any
	{
		return this.success ? this.var_74 : undefined;
	}
	
	get_75() : any
	{
		return this.success ? this.var_75 : undefined;
	}
	
	get_76() : any
	{
		return this.success ? this.var_76 : undefined;
	}
	
	get_77() : any
	{
		return this.success ? this.var_77 : undefined;
	}
	
	get_78() : any
	{
		return this.success ? this.var_78 : undefined;
	}
	
	get_79() : any
	{
		return this.success ? this.var_79 : undefined;
	}
	
	get_80() : any
	{
		return this.success ? this.var_80 : undefined;
	}
	
	get_81() : any
	{
		return this.success ? this.var_81 : undefined;
	}
	
	get_82() : any
	{
		return this.success ? this.var_82 : undefined;
	}
	
	get_83() : any
	{
		return this.success ? this.var_83 : undefined;
	}
	
	get_84() : any
	{
		return this.success ? this.var_84 : undefined;
	}
	
	get_85() : any
	{
		return this.success ? this.var_85 : undefined;
	}
	
	get_86() : any
	{
		return this.success ? this.var_86 : undefined;
	}
	
	get_87() : any
	{
		return this.success ? this.var_87 : undefined;
	}
	
	get_88() : any
	{
		return this.success ? this.var_88 : undefined;
	}
	
	get_89() : any
	{
		return this.success ? this.var_89 : undefined;
	}
	
	get_90() : any
	{
		return this.success ? this.var_90 : undefined;
	}
	
	get_91() : any
	{
		return this.success ? this.var_91 : undefined;
	}
	
	get_92() : any
	{
		return this.success ? this.var_92 : undefined;
	}
	
	get_93() : any
	{
		return this.success ? this.var_93 : undefined;
	}
	
	get_94() : any
	{
		return this.success ? this.var_94 : undefined;
	}
	
	get_95() : any
	{
		return this.success ? this.var_95 : undefined;
	}
	
	get_96() : any
	{
		return this.success ? this.var_96 : undefined;
	}
	
	get_97() : any
	{
		return this.success ? this.var_97 : undefined;
	}
	
	get_98() : any
	{
		return this.success ? this.var_98 : undefined;
	}
	
	get_99() : any
	{
		return this.success ? this.var_99 : undefined;
	}
	
	get_100() : any
	{
		return this.success ? this.var_100 : undefined;
	}
	
	get_101() : any
	{
		return this.success ? this.var_101 : undefined;
	}
	
	get_102() : any
	{
		return this.success ? this.var_102 : undefined;
	}
	
	get_103() : any
	{
		return this.success ? this.var_103 : undefined;
	}
	
	get_104() : any
	{
		return this.success ? this.var_104 : undefined;
	}
	
	get_105() : any
	{
		return this.success ? this.var_105 : undefined;
	}
	
	get_106() : any
	{
		return this.success ? this.var_106 : undefined;
	}
	
	get_107() : any
	{
		return this.success ? this.var_107 : undefined;
	}
	
	get_108() : any
	{
		return this.success ? this.var_108 : undefined;
	}
	
	get_109() : any
	{
		return this.success ? this.var_109 : undefined;
	}
	
	get_110() : any
	{
		return this.success ? this.var_110 : undefined;
	}
	
	get_111() : any
	{
		return this.success ? this.var_111 : undefined;
	}
	
	get_112() : any
	{
		return this.success ? this.var_112 : undefined;
	}
	
	get_113() : any
	{
		return this.success ? this.var_113 : undefined;
	}
	
	get_114() : any
	{
		return this.success ? this.var_114 : undefined;
	}
	
	get_115() : any
	{
		return this.success ? this.var_115 : undefined;
	}
	
	get_116() : any
	{
		return this.success ? this.var_116 : undefined;
	}
	
	get_117() : any
	{
		return this.success ? this.var_117 : undefined;
	}
	
	get_118() : any
	{
		return this.success ? this.var_118 : undefined;
	}
	
	get_119() : any
	{
		return this.success ? this.var_119 : undefined;
	}
	
	get_120() : any
	{
		return this.success ? this.var_120 : undefined;
	}
	
	get_121() : any
	{
		return this.success ? this.var_121 : undefined;
	}
	
	get_122() : any
	{
		return this.success ? this.var_122 : undefined;
	}
	
	get_123() : any
	{
		return this.success ? this.var_123 : undefined;
	}
	
	get_124() : any
	{
		return this.success ? this.var_124 : undefined;
	}
	
	get_125() : any
	{
		return this.success ? this.var_125 : undefined;
	}
	
	get_126() : any
	{
		return this.success ? this.var_126 : undefined;
	}
	
	get_127() : any
	{
		return this.success ? this.var_127 : undefined;
	}
	
	get_128() : any
	{
		return this.success ? this.var_128 : undefined;
	}
	
	get_129() : any
	{
		return this.success ? this.var_129 : undefined;
	}
	
	get_130() : any
	{
		return this.success ? this.var_130 : undefined;
	}
	
	get_131() : any
	{
		return this.success ? this.var_131 : undefined;
	}
	
	get_132() : any
	{
		return this.success ? this.var_132 : undefined;
	}
	
	get_133() : any
	{
		return this.success ? this.var_133 : undefined;
	}
	
	get_134() : any
	{
		return this.success ? this.var_134 : undefined;
	}
	
	get_135() : any
	{
		return this.success ? this.var_135 : undefined;
	}
	
	get_136() : any
	{
		return this.success ? this.var_136 : undefined;
	}
	
	get_137() : any
	{
		return this.success ? this.var_137 : undefined;
	}
	
	get_138() : any
	{
		return this.success ? this.var_138 : undefined;
	}
	
	get_139() : any
	{
		return this.success ? this.var_139 : undefined;
	}
	
	get_140() : any
	{
		return this.success ? this.var_140 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_57());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_102());
		var x2 = v.get("Formula_3");
		x2?.setIValue(this.get_103());
		var x3 = v.get("Formula_4");
		x3?.setIValue(this.get_114());
		var x4 = v.get("Formula_5");
		x4?.setIValue(this.get_115());
		var x5 = v.get("Formula_6");
		x5?.setIValue(this.get_127());
		var x6 = v.get("Formula_7");
		x6?.setIValue(this.get_140());
	}
	
}

class Frame_CategoryObject_2 extends TimerObject
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.span = new TimeSpan(1000000)
		console.log(this.span)
	}
}

class Frame_CategoryObject_3 extends ReferenceFrameData
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
this.parametersList.push("Motion.Formula_1");
this.parametersList.push("Motion.Formula_2");
this.parametersList.push("Motion.Formula_3");
this.parametersList.push("Motion.Formula_4");
this.parametersList.push("Motion.Formula_5");
this.parametersList.push("Motion.Formula_6");
this.parametersList.push("Motion.Formula_7");
	}
}

class Frame_CategoryObject_4 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryObject_5 extends BasicCamera
{
    postVisibleObject(object: IVisible): void {
        throw new Error("Method not implemented.");
    }
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryObject_6 extends BasicCamera
{
    postVisibleObject(object: IVisible): void {
        throw new Error("Method not implemented.");
    }
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryObject_7 extends RigidReferenceFrame
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(25);
		this.relativePosition.push(140);
		this.relativePosition.push(150);
	
		this.relativePosition = [];
		this.relativePosition.push(1);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
	
	}
}

class Frame_CategoryObject_8 extends RigidReferenceFrame
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(150);
		this.relativePosition.push(140);
		this.relativePosition.push(0);
	
		this.relativePosition = [];
		this.relativePosition.push(0.70710678118654757);
		this.relativePosition.push(0);
		this.relativePosition.push(0.70710678118654746);
		this.relativePosition.push(0);
	
	}
}

		class Frame_CategoryObject_9_Visible extends Basic3DShape
		{
			constructor(desktop: IDesktop, name: string)
			{
				super(desktop, name);
			}
		}
class Frame_CategoryObject_9 extends SerializablePosition
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.setParameters(new Frame_CategoryObject_9(desktop, name))
	}
}

class Frame_CategoryObject_11 extends RigidReferenceFrame
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(0);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
	
		this.relativePosition = [];
		this.relativePosition.push(1);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
	
	}
}

class Frame_CategoryObject_12 extends RigidReferenceFrame
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(1);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
	
		this.relativePosition = [];
		this.relativePosition.push(0.70710678118654757);
		this.relativePosition.push(-4.3297802811774658E-17);
		this.relativePosition.push(0.70710678118654746);
		this.relativePosition.push(-4.3297802811774658E-17);
	
	}
}

class Frame_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_1 extends EventLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_3 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_4 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_5 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_6 extends VisibleConsumerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_7 extends VisibleConsumerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_8 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_9 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_10 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_11 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Frame_CategoryArrow_12 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Frame extends Desktop
{
	constructor()
	{
		super();

		this.name = "Frame";

		this.mapObjects.set("Frame_CategoryObject_0", new Frame_CategoryObject_0(this, "Coefficient"))
		this.mapObjects.set("Frame_CategoryObject_1", new Frame_CategoryObject_1(this, "Motion"))
		this.mapObjects.set("Frame_CategoryObject_2", new Frame_CategoryObject_2(this, "Timer"))
		this.mapObjects.set("Frame_CategoryObject_3", new Frame_CategoryObject_3(this, "Plane frame"))
		this.mapObjects.set("Frame_CategoryObject_4", new Frame_CategoryObject_4(this, "Consumer"))
		this.mapObjects.set("Frame_CategoryObject_5", new Frame_CategoryObject_5(this, "Camera 2"))
		this.mapObjects.set("Frame_CategoryObject_6", new Frame_CategoryObject_6(this, "Camera 1"))
		this.mapObjects.set("Frame_CategoryObject_7", new Frame_CategoryObject_7(this, "Left frame"))
		this.mapObjects.set("Frame_CategoryObject_8", new Frame_CategoryObject_8(this, "Forward frame"))
		this.mapObjects.set("Frame_CategoryObject_9", new Frame_CategoryObject_9(this, "Plane"))
		this.mapObjects.set("Frame_CategoryObject_9_Visible", new Frame_CategoryObject_9_Visible(this, "Plane"))
		this.mapObjects.set("Frame_CategoryObject_11", new Frame_CategoryObject_11(this, ""))
		this.mapObjects.set("Frame_CategoryObject_12", new Frame_CategoryObject_12(this, "Transform"))
		new Frame_CategoryArrow_0(this, "");
		new Frame_CategoryArrow_1(this, "");
		new Frame_CategoryArrow_2(this, "");
		new Frame_CategoryArrow_3(this, "");
		new Frame_CategoryArrow_4(this, "");
		new Frame_CategoryArrow_5(this, "");
		new Frame_CategoryArrow_6(this, "");
		new Frame_CategoryArrow_7(this, "");
		new Frame_CategoryArrow_8(this, "");
		new Frame_CategoryArrow_9(this, "");
		new Frame_CategoryArrow_10(this, "");
		new Frame_CategoryArrow_11(this, "");
		new Frame_CategoryArrow_12(this, "");
	this.finish()
}

finish() : void
{
		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		let s0 = this.mapObjects.get("Frame_CategoryObject_4")
		if(s0 != undefined)    arrows[0].setSource(s0);
		let t0 = this.mapObjects.get("Frame_CategoryObject_1")
		if(t0 != undefined)    arrows[0].setTarget(t0);
		let s1 = this.mapObjects.get("Frame_CategoryObject_4")
		if(s1 != undefined)    arrows[1].setSource(s1);
		let t1 = this.mapObjects.get("Frame_CategoryObject_2")
		if(t1 != undefined)    arrows[1].setTarget(t1);
		let s2 = this.mapObjects.get("Frame_CategoryObject_3")
		if(s2 != undefined)    arrows[2].setSource(s2);
		let t2 = this.mapObjects.get("Frame_CategoryObject_1")
		if(t2 != undefined)    arrows[2].setTarget(t2);
		let s3 = this.mapObjects.get("Frame_CategoryObject_4")
		if(s3 != undefined)    arrows[3].setSource(s3);
		let t3 = this.mapObjects.get("Frame_CategoryObject_3")
		if(t3 != undefined)    arrows[3].setTarget(t3);
		let s4 = this.mapObjects.get("Frame_CategoryObject_6")
		if(s4 != undefined)    arrows[4].setSource(s4);
		let t4 = this.mapObjects.get("Frame_CategoryObject_8")
		if(t4 != undefined)    arrows[4].setTarget(t4);
		let s5 = this.mapObjects.get("Frame_CategoryObject_5")
		if(s5 != undefined)    arrows[5].setSource(s5);
		let t5 = this.mapObjects.get("Frame_CategoryObject_7")
		if(t5 != undefined)    arrows[5].setTarget(t5);
		let s6 = this.mapObjects.get("Frame_CategoryObject_5")
		if(s6 != undefined)    arrows[6].setSource(s6);
		let t6 = this.mapObjects.get("Frame_CategoryObject_9_Visible")
		if(t6 != undefined)    arrows[6].setTarget(t6);
		let s7 = this.mapObjects.get("Frame_CategoryObject_6")
		if(s7 != undefined)    arrows[7].setSource(s7);
		let t7 = this.mapObjects.get("Frame_CategoryObject_9_Visible")
		if(t7 != undefined)    arrows[7].setTarget(t7);
		let s8 = this.mapObjects.get("Frame_CategoryObject_4")
		if(s8 != undefined)    arrows[8].setSource(s8);
		let t8 = this.mapObjects.get("Frame_CategoryObject_5")
		if(t8 != undefined)    arrows[8].setTarget(t8);
		let s9 = this.mapObjects.get("Frame_CategoryObject_4")
		if(s9 != undefined)    arrows[9].setSource(s9);
		let t9 = this.mapObjects.get("Frame_CategoryObject_6")
		if(t9 != undefined)    arrows[9].setTarget(t9);
		let s10 = this.mapObjects.get("Frame_CategoryObject_1")
		if(s10 != undefined)    arrows[10].setSource(s10);
		let t10 = this.mapObjects.get("Frame_CategoryObject_0")
		if(t10 != undefined)    arrows[10].setTarget(t10);
		let s11 = this.mapObjects.get("Frame_CategoryObject_12")
		if(s11 != undefined)    arrows[11].setSource(s11);
		let t11 = this.mapObjects.get("Frame_CategoryObject_3")
		if(t11 != undefined)    arrows[11].setTarget(t11);
		let s12 = this.mapObjects.get("Frame_CategoryObject_9")
		if(s12 != undefined)    arrows[12].setSource(s12);
		let t12 = this.mapObjects.get("Frame_CategoryObject_12")
		if(t12 != undefined)    arrows[12].setTarget(t12);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
		(objects[3] as unknown as IPostSetArrow).postSetArrow();
		(objects[7] as unknown as IPostSetArrow).postSetArrow();
		(objects[8] as unknown as IPostSetArrow).postSetArrow();
		(objects[9] as unknown as IPostSetArrow).postSetArrow();
		(objects[11] as unknown as IPostSetArrow).postSetArrow();
		(objects[12] as unknown as IPostSetArrow).postSetArrow();
	}
}
