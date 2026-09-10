import { AliasName } from "../Library/AliasName";
import { BelongsToCollection } from "../Library/Arrows/BelognsToCollection";
import { Desktop } from "../Library/Desktop";
import { EventLink } from "../Library/Event/Objects/EventLink";
import { TimerObject } from "../Library/Event/Objects/TimerObject";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import type { IDesktop } from "../Library/Interfaces/IDesktop";
import type { IFactory } from "../Library/Interfaces/IFactory";
import type { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import type { IPrinter } from "../Library/Interfaces/IPrinter";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import type { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { ReferenceFrameArrow } from "../Library/Motion6D/Arrows/ReferenceFrameArrow";
import { ReferenceFrameData } from "../Library/Motion6D/Objects/ReferenceFrameData";
import { RigidReferenceFrame } from "../Library/Motion6D/Objects/RigidReferenceFrame";
import { SerializablePosition } from "../Library/Motion6D/Objects/SerializablePosition";
import { Basic3DShape } from "../Library/Motion6D/Objects/Shapes/Basic3DShape";
import { BasicCamera } from "../Library/Motion6D/Visible/BasicCamera";
import { VisibleConsumerLink } from "../Library/Motion6D/Visible/VisibleConsumerLink";
import { TimeSpan } from "../Library/Utilities/DateTime/TimeSpan";

class Immelman_CategoryObject_0 extends VectorFormulaConsumer {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		let map = new Map<string, any>(
			[
				["a", 5]
			]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
	}

	calculateTree(): void {
		this.success = true;
		this.variable = this.aliasName0.getAliasNameValue()
		if (this.check(this.variable)) { this.success = false; return; }
		this.var_0 = this.convert<number>(this.variable);
		this.var_1 = this.getInternalTime();
		this.variable = (this.var_0) * (this.var_1);
		if (this.check(this.variable)) { this.success = false; return; }
		this.var_2 = this.convert<number>(this.variable);
	}

	init(): void {
		var all = this.getAllMeasurements()
		this.fic = all
		this.aliasName0 = new AliasName(this.alias, "a");
	}

	aliasName0 !: IAliasName;
	var_0: number = 0
	var_1: number = 0
	var_2: number = 0

	get_0(): any {
		return this.success ? this.var_0 : undefined;
	}

	get_1(): any {
		return this.success ? this.var_1 : undefined;
	}

	get_2(): any {
		return this.success ? this.var_2 : undefined;
	}
	save(): void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_2());
	}


	reset(): void {
		this.var_0 = 0
		this.var_1 = 0
		this.var_2 = 0
	}


	print(printer: IPrinter): void {
		printer.print("var_0")
		printer.print(this.var_0)
		printer.print("var_1")
		printer.print(this.var_1)
		printer.print("var_2")
		printer.print(this.var_2)
	}

}

class Immelman_CategoryObject_1 extends VectorFormulaConsumer {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		let map = new Map<string, any>(
			[
			]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
		this.addVariableValue("Formula_2", 0, 0);
		this.addVariableValue("Formula_3", 0, 0);
		this.addVariableValue("Formula_4", 0, 0);
		this.addVariableValue("Formula_5", 0, 0);
		this.addVariableValue("Formula_6", 0, 0);
		this.addVariableValue("Formula_7", 0, 0);
	}

	calculateTree(): void {
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

	init(): void {
		var all = this.getAllMeasurements()
		this.fic = all
		this.measurement0 = all[0].getMeasurement(0);
	}

	measurement0 !: IMeasurement;
	var_0: number = 0
	var_1: number = 10
	var_2: number = 0
	var_3: number = Math.PI
	var_4: number = 2
	var_5: number = 0
	var_6: number = 10
	var_7: number = 0
	var_8: number = 0.1
	var_9: number = 0
	var_10: number = 0
	var_11: number = 0
	var_12: number = Math.PI
	var_13: number = 0
	var_14: number = 0
	var_15: number = 120
	var_16: number = Math.PI
	var_17: number = 0
	var_18: number = Math.PI
	var_19: number = 10
	var_20: number = 0
	var_21: number = 120
	var_22: number = 0
	var_23: number = 0
	var_24: number = 0
	var_25: number = 0
	var_26: number = Math.PI
	var_27: number = 10
	var_28: number = 0
	var_29: number = 0.1
	var_30: number = 0
	var_31: number = 0
	var_32: number = 130
	var_33: number = 0
	var_34: number = 0.1
	var_35: number = 0
	var_36: number = 0
	var_37: number = 0
	var_38: number = 0
	var_39: number = Math.PI
	var_40: number = 0
	var_41: number = 0
	var_42: number = 0
	var_43: number = 130
	var_44: number = 0
	var_45: number = Math.PI
	var_46: number = 2
	var_47: number = 0
	var_48: number = 130
	var_49: number = 0
	var_50: number = 0.1
	var_51: number = 0
	var_52: number = 0
	var_53: number = 0
	var_54: number = Math.PI
	var_55: number = 0
	var_56: number = 0
	var_57: number = 0
	var_58: number = 100
	var_59: number = 120
	var_60: number = Math.PI
	var_61: number = 0
	var_62: number = 10
	var_63: number = 0
	var_64: number = 0.1
	var_65: number = 0
	var_66: number = 0
	var_67: number = 130
	var_68: number = 0
	var_69: number = 0.1
	var_70: number = 0
	var_71: number = 0
	var_72: number = 0
	var_73: number = Math.PI
	var_74: number = 0
	var_75: number = 0
	var_76: number = Math.PI
	var_77: number = 10
	var_78: number = 0
	var_79: number = 120
	var_80: number = 0
	var_81: number = 0
	var_82: number = 0
	var_83: number = 1
	var_84: number = 0
	var_85: number = 0
	var_86: number = 0
	var_87: number = 240
	var_88: number = Math.PI
	var_89: number = 0
	var_90: number = Math.PI
	var_91: number = 2
	var_92: number = 0
	var_93: number = 130
	var_94: number = 0
	var_95: number = 0.1
	var_96: number = 0
	var_97: number = 0
	var_98: number = 0
	var_99: number = Math.PI
	var_100: number = 0
	var_101: number = 0
	var_102: number = 0
	var_103: number = 0
	var_104: number = Math.PI
	var_105: number = 2
	var_106: number = 0
	var_107: number = 70
	var_108: number = 0
	var_109: number = 20
	var_110: number = 0
	var_111: number = 0
	var_112: number = 0
	var_113: number = Math.PI
	var_114: number = 0
	var_115: number = 0
	var_116: number = Math.PI
	var_117: number = 2
	var_118: number = 0
	var_119: number = 130
	var_120: number = 0
	var_121: number = 10
	var_122: number = 0
	var_123: number = 0
	var_124: number = 0
	var_125: number = Math.PI
	var_126: number = 0
	var_127: number = 0
	var_128: number = 70
	var_129: number = 0
	var_130: number = 20
	var_131: number = 0
	var_132: number = 0
	var_133: number = 130
	var_134: number = 0
	var_135: number = 10
	var_136: number = 0
	var_137: number = 0
	var_138: number = 0
	var_139: number = Math.PI
	var_140: number = 0

	get_0(): any {
		return this.success ? this.var_0 : undefined;
	}

	get_1(): any {
		return this.success ? this.var_1 : undefined;
	}

	get_2(): any {
		return this.success ? this.var_2 : undefined;
	}

	get_3(): any {
		return this.success ? this.var_3 : undefined;
	}

	get_4(): any {
		return this.success ? this.var_4 : undefined;
	}

	get_5(): any {
		return this.success ? this.var_5 : undefined;
	}

	get_6(): any {
		return this.success ? this.var_6 : undefined;
	}

	get_7(): any {
		return this.success ? this.var_7 : undefined;
	}

	get_8(): any {
		return this.success ? this.var_8 : undefined;
	}

	get_9(): any {
		return this.success ? this.var_9 : undefined;
	}

	get_10(): any {
		return this.success ? this.var_10 : undefined;
	}

	get_11(): any {
		return this.success ? this.var_11 : undefined;
	}

	get_12(): any {
		return this.success ? this.var_12 : undefined;
	}

	get_13(): any {
		return this.success ? this.var_13 : undefined;
	}

	get_14(): any {
		return this.success ? this.var_14 : undefined;
	}

	get_15(): any {
		return this.success ? this.var_15 : undefined;
	}

	get_16(): any {
		return this.success ? this.var_16 : undefined;
	}

	get_17(): any {
		return this.success ? this.var_17 : undefined;
	}

	get_18(): any {
		return this.success ? this.var_18 : undefined;
	}

	get_19(): any {
		return this.success ? this.var_19 : undefined;
	}

	get_20(): any {
		return this.success ? this.var_20 : undefined;
	}

	get_21(): any {
		return this.success ? this.var_21 : undefined;
	}

	get_22(): any {
		return this.success ? this.var_22 : undefined;
	}

	get_23(): any {
		return this.success ? this.var_23 : undefined;
	}

	get_24(): any {
		return this.success ? this.var_24 : undefined;
	}

	get_25(): any {
		return this.success ? this.var_25 : undefined;
	}

	get_26(): any {
		return this.success ? this.var_26 : undefined;
	}

	get_27(): any {
		return this.success ? this.var_27 : undefined;
	}

	get_28(): any {
		return this.success ? this.var_28 : undefined;
	}

	get_29(): any {
		return this.success ? this.var_29 : undefined;
	}

	get_30(): any {
		return this.success ? this.var_30 : undefined;
	}

	get_31(): any {
		return this.success ? this.var_31 : undefined;
	}

	get_32(): any {
		return this.success ? this.var_32 : undefined;
	}

	get_33(): any {
		return this.success ? this.var_33 : undefined;
	}

	get_34(): any {
		return this.success ? this.var_34 : undefined;
	}

	get_35(): any {
		return this.success ? this.var_35 : undefined;
	}

	get_36(): any {
		return this.success ? this.var_36 : undefined;
	}

	get_37(): any {
		return this.success ? this.var_37 : undefined;
	}

	get_38(): any {
		return this.success ? this.var_38 : undefined;
	}

	get_39(): any {
		return this.success ? this.var_39 : undefined;
	}

	get_40(): any {
		return this.success ? this.var_40 : undefined;
	}

	get_41(): any {
		return this.success ? this.var_41 : undefined;
	}

	get_42(): any {
		return this.success ? this.var_42 : undefined;
	}

	get_43(): any {
		return this.success ? this.var_43 : undefined;
	}

	get_44(): any {
		return this.success ? this.var_44 : undefined;
	}

	get_45(): any {
		return this.success ? this.var_45 : undefined;
	}

	get_46(): any {
		return this.success ? this.var_46 : undefined;
	}

	get_47(): any {
		return this.success ? this.var_47 : undefined;
	}

	get_48(): any {
		return this.success ? this.var_48 : undefined;
	}

	get_49(): any {
		return this.success ? this.var_49 : undefined;
	}

	get_50(): any {
		return this.success ? this.var_50 : undefined;
	}

	get_51(): any {
		return this.success ? this.var_51 : undefined;
	}

	get_52(): any {
		return this.success ? this.var_52 : undefined;
	}

	get_53(): any {
		return this.success ? this.var_53 : undefined;
	}

	get_54(): any {
		return this.success ? this.var_54 : undefined;
	}

	get_55(): any {
		return this.success ? this.var_55 : undefined;
	}

	get_56(): any {
		return this.success ? this.var_56 : undefined;
	}

	get_57(): any {
		return this.success ? this.var_57 : undefined;
	}

	get_58(): any {
		return this.success ? this.var_58 : undefined;
	}

	get_59(): any {
		return this.success ? this.var_59 : undefined;
	}

	get_60(): any {
		return this.success ? this.var_60 : undefined;
	}

	get_61(): any {
		return this.success ? this.var_61 : undefined;
	}

	get_62(): any {
		return this.success ? this.var_62 : undefined;
	}

	get_63(): any {
		return this.success ? this.var_63 : undefined;
	}

	get_64(): any {
		return this.success ? this.var_64 : undefined;
	}

	get_65(): any {
		return this.success ? this.var_65 : undefined;
	}

	get_66(): any {
		return this.success ? this.var_66 : undefined;
	}

	get_67(): any {
		return this.success ? this.var_67 : undefined;
	}

	get_68(): any {
		return this.success ? this.var_68 : undefined;
	}

	get_69(): any {
		return this.success ? this.var_69 : undefined;
	}

	get_70(): any {
		return this.success ? this.var_70 : undefined;
	}

	get_71(): any {
		return this.success ? this.var_71 : undefined;
	}

	get_72(): any {
		return this.success ? this.var_72 : undefined;
	}

	get_73(): any {
		return this.success ? this.var_73 : undefined;
	}

	get_74(): any {
		return this.success ? this.var_74 : undefined;
	}

	get_75(): any {
		return this.success ? this.var_75 : undefined;
	}

	get_76(): any {
		return this.success ? this.var_76 : undefined;
	}

	get_77(): any {
		return this.success ? this.var_77 : undefined;
	}

	get_78(): any {
		return this.success ? this.var_78 : undefined;
	}

	get_79(): any {
		return this.success ? this.var_79 : undefined;
	}

	get_80(): any {
		return this.success ? this.var_80 : undefined;
	}

	get_81(): any {
		return this.success ? this.var_81 : undefined;
	}

	get_82(): any {
		return this.success ? this.var_82 : undefined;
	}

	get_83(): any {
		return this.success ? this.var_83 : undefined;
	}

	get_84(): any {
		return this.success ? this.var_84 : undefined;
	}

	get_85(): any {
		return this.success ? this.var_85 : undefined;
	}

	get_86(): any {
		return this.success ? this.var_86 : undefined;
	}

	get_87(): any {
		return this.success ? this.var_87 : undefined;
	}

	get_88(): any {
		return this.success ? this.var_88 : undefined;
	}

	get_89(): any {
		return this.success ? this.var_89 : undefined;
	}

	get_90(): any {
		return this.success ? this.var_90 : undefined;
	}

	get_91(): any {
		return this.success ? this.var_91 : undefined;
	}

	get_92(): any {
		return this.success ? this.var_92 : undefined;
	}

	get_93(): any {
		return this.success ? this.var_93 : undefined;
	}

	get_94(): any {
		return this.success ? this.var_94 : undefined;
	}

	get_95(): any {
		return this.success ? this.var_95 : undefined;
	}

	get_96(): any {
		return this.success ? this.var_96 : undefined;
	}

	get_97(): any {
		return this.success ? this.var_97 : undefined;
	}

	get_98(): any {
		return this.success ? this.var_98 : undefined;
	}

	get_99(): any {
		return this.success ? this.var_99 : undefined;
	}

	get_100(): any {
		return this.success ? this.var_100 : undefined;
	}

	get_101(): any {
		return this.success ? this.var_101 : undefined;
	}

	get_102(): any {
		return this.success ? this.var_102 : undefined;
	}

	get_103(): any {
		return this.success ? this.var_103 : undefined;
	}

	get_104(): any {
		return this.success ? this.var_104 : undefined;
	}

	get_105(): any {
		return this.success ? this.var_105 : undefined;
	}

	get_106(): any {
		return this.success ? this.var_106 : undefined;
	}

	get_107(): any {
		return this.success ? this.var_107 : undefined;
	}

	get_108(): any {
		return this.success ? this.var_108 : undefined;
	}

	get_109(): any {
		return this.success ? this.var_109 : undefined;
	}

	get_110(): any {
		return this.success ? this.var_110 : undefined;
	}

	get_111(): any {
		return this.success ? this.var_111 : undefined;
	}

	get_112(): any {
		return this.success ? this.var_112 : undefined;
	}

	get_113(): any {
		return this.success ? this.var_113 : undefined;
	}

	get_114(): any {
		return this.success ? this.var_114 : undefined;
	}

	get_115(): any {
		return this.success ? this.var_115 : undefined;
	}

	get_116(): any {
		return this.success ? this.var_116 : undefined;
	}

	get_117(): any {
		return this.success ? this.var_117 : undefined;
	}

	get_118(): any {
		return this.success ? this.var_118 : undefined;
	}

	get_119(): any {
		return this.success ? this.var_119 : undefined;
	}

	get_120(): any {
		return this.success ? this.var_120 : undefined;
	}

	get_121(): any {
		return this.success ? this.var_121 : undefined;
	}

	get_122(): any {
		return this.success ? this.var_122 : undefined;
	}

	get_123(): any {
		return this.success ? this.var_123 : undefined;
	}

	get_124(): any {
		return this.success ? this.var_124 : undefined;
	}

	get_125(): any {
		return this.success ? this.var_125 : undefined;
	}

	get_126(): any {
		return this.success ? this.var_126 : undefined;
	}

	get_127(): any {
		return this.success ? this.var_127 : undefined;
	}

	get_128(): any {
		return this.success ? this.var_128 : undefined;
	}

	get_129(): any {
		return this.success ? this.var_129 : undefined;
	}

	get_130(): any {
		return this.success ? this.var_130 : undefined;
	}

	get_131(): any {
		return this.success ? this.var_131 : undefined;
	}

	get_132(): any {
		return this.success ? this.var_132 : undefined;
	}

	get_133(): any {
		return this.success ? this.var_133 : undefined;
	}

	get_134(): any {
		return this.success ? this.var_134 : undefined;
	}

	get_135(): any {
		return this.success ? this.var_135 : undefined;
	}

	get_136(): any {
		return this.success ? this.var_136 : undefined;
	}

	get_137(): any {
		return this.success ? this.var_137 : undefined;
	}

	get_138(): any {
		return this.success ? this.var_138 : undefined;
	}

	get_139(): any {
		return this.success ? this.var_139 : undefined;
	}

	get_140(): any {
		return this.success ? this.var_140 : undefined;
	}
	save(): void {
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


	reset(): void {
		this.var_0 = 0
		this.var_1 = 10
		this.var_2 = 0
		this.var_3 = Math.PI
		this.var_4 = 2
		this.var_5 = 0
		this.var_6 = 10
		this.var_7 = 0
		this.var_8 = 0.1
		this.var_9 = 0
		this.var_10 = 0
		this.var_11 = 0
		this.var_12 = Math.PI
		this.var_13 = 0
		this.var_14 = 0
		this.var_15 = 120
		this.var_16 = Math.PI
		this.var_17 = 0
		this.var_18 = Math.PI
		this.var_19 = 10
		this.var_20 = 0
		this.var_21 = 120
		this.var_22 = 0
		this.var_23 = 0
		this.var_24 = 0
		this.var_25 = 0
		this.var_26 = Math.PI
		this.var_27 = 10
		this.var_28 = 0
		this.var_29 = 0.1
		this.var_30 = 0
		this.var_31 = 0
		this.var_32 = 130
		this.var_33 = 0
		this.var_34 = 0.1
		this.var_35 = 0
		this.var_36 = 0
		this.var_37 = 0
		this.var_38 = 0
		this.var_39 = Math.PI
		this.var_40 = 0
		this.var_41 = 0
		this.var_42 = 0
		this.var_43 = 130
		this.var_44 = 0
		this.var_45 = Math.PI
		this.var_46 = 2
		this.var_47 = 0
		this.var_48 = 130
		this.var_49 = 0
		this.var_50 = 0.1
		this.var_51 = 0
		this.var_52 = 0
		this.var_53 = 0
		this.var_54 = Math.PI
		this.var_55 = 0
		this.var_56 = 0
		this.var_57 = 0
		this.var_58 = 100
		this.var_59 = 120
		this.var_60 = Math.PI
		this.var_61 = 0
		this.var_62 = 10
		this.var_63 = 0
		this.var_64 = 0.1
		this.var_65 = 0
		this.var_66 = 0
		this.var_67 = 130
		this.var_68 = 0
		this.var_69 = 0.1
		this.var_70 = 0
		this.var_71 = 0
		this.var_72 = 0
		this.var_73 = Math.PI
		this.var_74 = 0
		this.var_75 = 0
		this.var_76 = Math.PI
		this.var_77 = 10
		this.var_78 = 0
		this.var_79 = 120
		this.var_80 = 0
		this.var_81 = 0
		this.var_82 = 0
		this.var_83 = 1
		this.var_84 = 0
		this.var_85 = 0
		this.var_86 = 0
		this.var_87 = 240
		this.var_88 = Math.PI
		this.var_89 = 0
		this.var_90 = Math.PI
		this.var_91 = 2
		this.var_92 = 0
		this.var_93 = 130
		this.var_94 = 0
		this.var_95 = 0.1
		this.var_96 = 0
		this.var_97 = 0
		this.var_98 = 0
		this.var_99 = Math.PI
		this.var_100 = 0
		this.var_101 = 0
		this.var_102 = 0
		this.var_103 = 0
		this.var_104 = Math.PI
		this.var_105 = 2
		this.var_106 = 0
		this.var_107 = 70
		this.var_108 = 0
		this.var_109 = 20
		this.var_110 = 0
		this.var_111 = 0
		this.var_112 = 0
		this.var_113 = Math.PI
		this.var_114 = 0
		this.var_115 = 0
		this.var_116 = Math.PI
		this.var_117 = 2
		this.var_118 = 0
		this.var_119 = 130
		this.var_120 = 0
		this.var_121 = 10
		this.var_122 = 0
		this.var_123 = 0
		this.var_124 = 0
		this.var_125 = Math.PI
		this.var_126 = 0
		this.var_127 = 0
		this.var_128 = 70
		this.var_129 = 0
		this.var_130 = 20
		this.var_131 = 0
		this.var_132 = 0
		this.var_133 = 130
		this.var_134 = 0
		this.var_135 = 10
		this.var_136 = 0
		this.var_137 = 0
		this.var_138 = 0
		this.var_139 = Math.PI
		this.var_140 = 0
	}


	print(printer: IPrinter): void {
		printer.print("var_0")
		printer.print(this.var_0)
		printer.print("var_1")
		printer.print(this.var_1)
		printer.print("var_2")
		printer.print(this.var_2)
		printer.print("var_3")
		printer.print(this.var_3)
		printer.print("var_4")
		printer.print(this.var_4)
		printer.print("var_5")
		printer.print(this.var_5)
		printer.print("var_6")
		printer.print(this.var_6)
		printer.print("var_7")
		printer.print(this.var_7)
		printer.print("var_8")
		printer.print(this.var_8)
		printer.print("var_9")
		printer.print(this.var_9)
		printer.print("var_10")
		printer.print(this.var_10)
		printer.print("var_11")
		printer.print(this.var_11)
		printer.print("var_12")
		printer.print(this.var_12)
		printer.print("var_13")
		printer.print(this.var_13)
		printer.print("var_14")
		printer.print(this.var_14)
		printer.print("var_15")
		printer.print(this.var_15)
		printer.print("var_16")
		printer.print(this.var_16)
		printer.print("var_17")
		printer.print(this.var_17)
		printer.print("var_18")
		printer.print(this.var_18)
		printer.print("var_19")
		printer.print(this.var_19)
		printer.print("var_20")
		printer.print(this.var_20)
		printer.print("var_21")
		printer.print(this.var_21)
		printer.print("var_22")
		printer.print(this.var_22)
		printer.print("var_23")
		printer.print(this.var_23)
		printer.print("var_24")
		printer.print(this.var_24)
		printer.print("var_25")
		printer.print(this.var_25)
		printer.print("var_26")
		printer.print(this.var_26)
		printer.print("var_27")
		printer.print(this.var_27)
		printer.print("var_28")
		printer.print(this.var_28)
		printer.print("var_29")
		printer.print(this.var_29)
		printer.print("var_30")
		printer.print(this.var_30)
		printer.print("var_31")
		printer.print(this.var_31)
		printer.print("var_32")
		printer.print(this.var_32)
		printer.print("var_33")
		printer.print(this.var_33)
		printer.print("var_34")
		printer.print(this.var_34)
		printer.print("var_35")
		printer.print(this.var_35)
		printer.print("var_36")
		printer.print(this.var_36)
		printer.print("var_37")
		printer.print(this.var_37)
		printer.print("var_38")
		printer.print(this.var_38)
		printer.print("var_39")
		printer.print(this.var_39)
		printer.print("var_40")
		printer.print(this.var_40)
		printer.print("var_41")
		printer.print(this.var_41)
		printer.print("var_42")
		printer.print(this.var_42)
		printer.print("var_43")
		printer.print(this.var_43)
		printer.print("var_44")
		printer.print(this.var_44)
		printer.print("var_45")
		printer.print(this.var_45)
		printer.print("var_46")
		printer.print(this.var_46)
		printer.print("var_47")
		printer.print(this.var_47)
		printer.print("var_48")
		printer.print(this.var_48)
		printer.print("var_49")
		printer.print(this.var_49)
		printer.print("var_50")
		printer.print(this.var_50)
		printer.print("var_51")
		printer.print(this.var_51)
		printer.print("var_52")
		printer.print(this.var_52)
		printer.print("var_53")
		printer.print(this.var_53)
		printer.print("var_54")
		printer.print(this.var_54)
		printer.print("var_55")
		printer.print(this.var_55)
		printer.print("var_56")
		printer.print(this.var_56)
		printer.print("var_57")
		printer.print(this.var_57)
		printer.print("var_58")
		printer.print(this.var_58)
		printer.print("var_59")
		printer.print(this.var_59)
		printer.print("var_60")
		printer.print(this.var_60)
		printer.print("var_61")
		printer.print(this.var_61)
		printer.print("var_62")
		printer.print(this.var_62)
		printer.print("var_63")
		printer.print(this.var_63)
		printer.print("var_64")
		printer.print(this.var_64)
		printer.print("var_65")
		printer.print(this.var_65)
		printer.print("var_66")
		printer.print(this.var_66)
		printer.print("var_67")
		printer.print(this.var_67)
		printer.print("var_68")
		printer.print(this.var_68)
		printer.print("var_69")
		printer.print(this.var_69)
		printer.print("var_70")
		printer.print(this.var_70)
		printer.print("var_71")
		printer.print(this.var_71)
		printer.print("var_72")
		printer.print(this.var_72)
		printer.print("var_73")
		printer.print(this.var_73)
		printer.print("var_74")
		printer.print(this.var_74)
		printer.print("var_75")
		printer.print(this.var_75)
		printer.print("var_76")
		printer.print(this.var_76)
		printer.print("var_77")
		printer.print(this.var_77)
		printer.print("var_78")
		printer.print(this.var_78)
		printer.print("var_79")
		printer.print(this.var_79)
		printer.print("var_80")
		printer.print(this.var_80)
		printer.print("var_81")
		printer.print(this.var_81)
		printer.print("var_82")
		printer.print(this.var_82)
		printer.print("var_83")
		printer.print(this.var_83)
		printer.print("var_84")
		printer.print(this.var_84)
		printer.print("var_85")
		printer.print(this.var_85)
		printer.print("var_86")
		printer.print(this.var_86)
		printer.print("var_87")
		printer.print(this.var_87)
		printer.print("var_88")
		printer.print(this.var_88)
		printer.print("var_89")
		printer.print(this.var_89)
		printer.print("var_90")
		printer.print(this.var_90)
		printer.print("var_91")
		printer.print(this.var_91)
		printer.print("var_92")
		printer.print(this.var_92)
		printer.print("var_93")
		printer.print(this.var_93)
		printer.print("var_94")
		printer.print(this.var_94)
		printer.print("var_95")
		printer.print(this.var_95)
		printer.print("var_96")
		printer.print(this.var_96)
		printer.print("var_97")
		printer.print(this.var_97)
		printer.print("var_98")
		printer.print(this.var_98)
		printer.print("var_99")
		printer.print(this.var_99)
		printer.print("var_100")
		printer.print(this.var_100)
		printer.print("var_101")
		printer.print(this.var_101)
		printer.print("var_102")
		printer.print(this.var_102)
		printer.print("var_103")
		printer.print(this.var_103)
		printer.print("var_104")
		printer.print(this.var_104)
		printer.print("var_105")
		printer.print(this.var_105)
		printer.print("var_106")
		printer.print(this.var_106)
		printer.print("var_107")
		printer.print(this.var_107)
		printer.print("var_108")
		printer.print(this.var_108)
		printer.print("var_109")
		printer.print(this.var_109)
		printer.print("var_110")
		printer.print(this.var_110)
		printer.print("var_111")
		printer.print(this.var_111)
		printer.print("var_112")
		printer.print(this.var_112)
		printer.print("var_113")
		printer.print(this.var_113)
		printer.print("var_114")
		printer.print(this.var_114)
		printer.print("var_115")
		printer.print(this.var_115)
		printer.print("var_116")
		printer.print(this.var_116)
		printer.print("var_117")
		printer.print(this.var_117)
		printer.print("var_118")
		printer.print(this.var_118)
		printer.print("var_119")
		printer.print(this.var_119)
		printer.print("var_120")
		printer.print(this.var_120)
		printer.print("var_121")
		printer.print(this.var_121)
		printer.print("var_122")
		printer.print(this.var_122)
		printer.print("var_123")
		printer.print(this.var_123)
		printer.print("var_124")
		printer.print(this.var_124)
		printer.print("var_125")
		printer.print(this.var_125)
		printer.print("var_126")
		printer.print(this.var_126)
		printer.print("var_127")
		printer.print(this.var_127)
		printer.print("var_128")
		printer.print(this.var_128)
		printer.print("var_129")
		printer.print(this.var_129)
		printer.print("var_130")
		printer.print(this.var_130)
		printer.print("var_131")
		printer.print(this.var_131)
		printer.print("var_132")
		printer.print(this.var_132)
		printer.print("var_133")
		printer.print(this.var_133)
		printer.print("var_134")
		printer.print(this.var_134)
		printer.print("var_135")
		printer.print(this.var_135)
		printer.print("var_136")
		printer.print(this.var_136)
		printer.print("var_137")
		printer.print(this.var_137)
		printer.print("var_138")
		printer.print(this.var_138)
		printer.print("var_139")
		printer.print(this.var_139)
		printer.print("var_140")
		printer.print(this.var_140)
	}

}

class Immelman_CategoryObject_2 extends TimerObject {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.span = TimeSpan.fromMilliseconds(100)
	}
}

class Immelman_CategoryObject_3 extends ReferenceFrameData {
	constructor(desktop: IDesktop, name: string) {
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

class Immelman_CategoryObject_4 extends RigidReferenceFrame {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(0);
		this.relativePosition.push(0);
		this.relativePosition.push(0);

		this.relativeQuaternion = [];
		this.relativeQuaternion.push(0.5);
		this.relativeQuaternion.push(0.5);
		this.relativeQuaternion.push(0.5);
		this.relativeQuaternion.push(-0.5);

	}
}

class Immelman_CategoryObject_5 extends DataConsumer {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryObject_6 extends BasicCamera {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.fieldOfView = 40
		this.nearDistance = 1
		this.farDistance = 500
	}
}

class Immelman_CategoryObject_7 extends BasicCamera {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.fieldOfView = 40
		this.nearDistance = 1
		this.farDistance = 500
	}
}

class Immelman_CategoryObject_8 extends RigidReferenceFrame {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(25);
		this.relativePosition.push(140);
		this.relativePosition.push(150);

		this.relativeQuaternion = [];
		this.relativeQuaternion.push(1);
		this.relativeQuaternion.push(0);
		this.relativeQuaternion.push(0);
		this.relativeQuaternion.push(0);

	}
}

class Immelman_CategoryObject_9 extends RigidReferenceFrame {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(150);
		this.relativePosition.push(140);
		this.relativePosition.push(0);

		this.relativeQuaternion = [];
		this.relativeQuaternion.push(0.70710678118654757);
		this.relativeQuaternion.push(0);
		this.relativeQuaternion.push(0.70710678118654746);
		this.relativeQuaternion.push(0);

	}
}

class Immelman_CategoryObject_10_Visible0 extends Basic3DShape {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryObject_10 extends SerializablePosition {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
		this.addChildT(new Immelman_CategoryObject_10_Visible0(desktop, name))
	}
}

class Immelman_CategoryArrow_0 extends DataLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_1 extends EventLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_2 extends DataLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_3 extends DataLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_4 extends ReferenceFrameArrow {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_5 extends ReferenceFrameArrow {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_6 extends VisibleConsumerLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_7 extends VisibleConsumerLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_8 extends ReferenceFrameArrow {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_9 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_10 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_11 extends DataLink {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_12 extends ReferenceFrameArrow {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_13 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_14 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_15 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_16 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}

class Immelman_CategoryArrow_17 extends BelongsToCollection {
	constructor(desktop: IDesktop, name: string) {
		super(desktop, name);
	}
}



export class Immelman extends Desktop {

	public static async getDesktopAsync(controller: AbortController, factory?: IFactory): Promise<IDesktop> {
		let d = new Immelman(factory)
		await d.loadAsync(controller)
		return d
	}

	constructor(factory?: IFactory) {
		super(factory);

		this.name = "Immelman";

		this.mapObjects.set("Immelman_CategoryObject_0", new Immelman_CategoryObject_0(this, "Coefficient"))
		this.mapObjects.set("Immelman_CategoryObject_1", new Immelman_CategoryObject_1(this, "Motion"))
		this.mapObjects.set("Immelman_CategoryObject_2", new Immelman_CategoryObject_2(this, "Timer"))
		this.mapObjects.set("Immelman_CategoryObject_3", new Immelman_CategoryObject_3(this, "Plane frame"))
		this.mapObjects.set("Immelman_CategoryObject_4", new Immelman_CategoryObject_4(this, "Unity plane"))
		this.mapObjects.set("Immelman_CategoryObject_5", new Immelman_CategoryObject_5(this, "Consumer"))
		this.mapObjects.set("Immelman_CategoryObject_6", new Immelman_CategoryObject_6(this, "Camera 2"))
		this.mapObjects.set("Immelman_CategoryObject_7", new Immelman_CategoryObject_7(this, "Camera 1"))
		this.mapObjects.set("Immelman_CategoryObject_8", new Immelman_CategoryObject_8(this, "Left frame"))
		this.mapObjects.set("Immelman_CategoryObject_9", new Immelman_CategoryObject_9(this, "Forward frame"))
		this.mapObjects.set("Immelman_CategoryObject_10", new Immelman_CategoryObject_10(this, "Plane"))
		new Immelman_CategoryArrow_0(this, "");
		new Immelman_CategoryArrow_1(this, "");
		new Immelman_CategoryArrow_2(this, "");
		new Immelman_CategoryArrow_3(this, "");
		new Immelman_CategoryArrow_4(this, "");
		new Immelman_CategoryArrow_5(this, "");
		new Immelman_CategoryArrow_6(this, "");
		new Immelman_CategoryArrow_7(this, "");
		new Immelman_CategoryArrow_8(this, "");
		new Immelman_CategoryArrow_9(this, "");
		new Immelman_CategoryArrow_10(this, "");
		new Immelman_CategoryArrow_11(this, "");
		new Immelman_CategoryArrow_12(this, "");
		new Immelman_CategoryArrow_13(this, "");
		new Immelman_CategoryArrow_14(this, "");
		new Immelman_CategoryArrow_15(this, "");
		new Immelman_CategoryArrow_16(this, "");
		new Immelman_CategoryArrow_17(this, "");
		this.finish()
	}

	finish(): void {
		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		let s0 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s0 != undefined) arrows[0].setSource(s0);
		let t0 = this.mapObjects.get("Immelman_CategoryObject_1")
		if (t0 != undefined) arrows[0].setTarget(t0);
		let s1 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s1 != undefined) arrows[1].setSource(s1);
		let t1 = this.mapObjects.get("Immelman_CategoryObject_2")
		if (t1 != undefined) arrows[1].setTarget(t1);
		let s2 = this.mapObjects.get("Immelman_CategoryObject_3")
		if (s2 != undefined) arrows[2].setSource(s2);
		let t2 = this.mapObjects.get("Immelman_CategoryObject_1")
		if (t2 != undefined) arrows[2].setTarget(t2);
		let s3 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s3 != undefined) arrows[3].setSource(s3);
		let t3 = this.mapObjects.get("Immelman_CategoryObject_3")
		if (t3 != undefined) arrows[3].setTarget(t3);
		let s4 = this.mapObjects.get("Immelman_CategoryObject_7")
		if (s4 != undefined) arrows[4].setSource(s4);
		let t4 = this.mapObjects.get("Immelman_CategoryObject_9")
		if (t4 != undefined) arrows[4].setTarget(t4);
		let s5 = this.mapObjects.get("Immelman_CategoryObject_6")
		if (s5 != undefined) arrows[5].setSource(s5);
		let t5 = this.mapObjects.get("Immelman_CategoryObject_8")
		if (t5 != undefined) arrows[5].setTarget(t5);
		let s6 = this.mapObjects.get("Immelman_CategoryObject_6")
		if (s6 != undefined) arrows[6].setSource(s6);
		let t6 = this.mapObjects.get("Immelman_CategoryObject_10_Visible0")
		if (t6 != undefined) arrows[6].setTarget(t6);
		let s7 = this.mapObjects.get("Immelman_CategoryObject_7")
		if (s7 != undefined) arrows[7].setSource(s7);
		let t7 = this.mapObjects.get("Immelman_CategoryObject_10_Visible0")
		if (t7 != undefined) arrows[7].setTarget(t7);
		let s8 = this.mapObjects.get("Immelman_CategoryObject_10")
		if (s8 != undefined) arrows[8].setSource(s8);
		let t8 = this.mapObjects.get("Immelman_CategoryObject_3")
		if (t8 != undefined) arrows[8].setTarget(t8);
		let s9 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s9 != undefined) arrows[9].setSource(s9);
		let t9 = this.mapObjects.get("Immelman_CategoryObject_6")
		if (t9 != undefined) arrows[9].setTarget(t9);
		let s10 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s10 != undefined) arrows[10].setSource(s10);
		let t10 = this.mapObjects.get("Immelman_CategoryObject_7")
		if (t10 != undefined) arrows[10].setTarget(t10);
		let s11 = this.mapObjects.get("Immelman_CategoryObject_1")
		if (s11 != undefined) arrows[11].setSource(s11);
		let t11 = this.mapObjects.get("Immelman_CategoryObject_0")
		if (t11 != undefined) arrows[11].setTarget(t11);
		let s12 = this.mapObjects.get("Immelman_CategoryObject_4")
		if (s12 != undefined) arrows[12].setSource(s12);
		let t12 = this.mapObjects.get("Immelman_CategoryObject_3")
		if (t12 != undefined) arrows[12].setTarget(t12);
		let s13 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s13 != undefined) arrows[13].setSource(s13);
		let t13 = this.mapObjects.get("Immelman_CategoryObject_4")
		if (t13 != undefined) arrows[13].setTarget(t13);
		let s14 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s14 != undefined) arrows[14].setSource(s14);
		let t14 = this.mapObjects.get("Immelman_CategoryObject_9")
		if (t14 != undefined) arrows[14].setTarget(t14);
		let s15 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s15 != undefined) arrows[15].setSource(s15);
		let t15 = this.mapObjects.get("Immelman_CategoryObject_4")
		if (t15 != undefined) arrows[15].setTarget(t15);
		let s16 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s16 != undefined) arrows[16].setSource(s16);
		let t16 = this.mapObjects.get("Immelman_CategoryObject_8")
		if (t16 != undefined) arrows[16].setTarget(t16);
		let s17 = this.mapObjects.get("Immelman_CategoryObject_5")
		if (s17 != undefined) arrows[17].setSource(s17);
		let t17 = this.mapObjects.get("Immelman_CategoryObject_10")
		if (t17 != undefined) arrows[17].setTarget(t17);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
		(objects[3] as unknown as IPostSetArrow).postSetArrow();
		(objects[4] as unknown as IPostSetArrow).postSetArrow();
		(objects[5] as unknown as IPostSetArrow).postSetArrow();
		(objects[8] as unknown as IPostSetArrow).postSetArrow();
		(objects[9] as unknown as IPostSetArrow).postSetArrow();
		(objects[10] as unknown as IPostSetArrow).postSetArrow();
	}
}
