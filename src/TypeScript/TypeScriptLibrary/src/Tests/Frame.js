"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Frame = void 0;
const AliasName_1 = require("../Library/AliasName");
const BelognsToCollection_1 = require("../Library/Arrows/BelognsToCollection");
const Desktop_1 = require("../Library/Desktop");
const EventLink_1 = require("../Library/Event/Objects/EventLink");
const TimerObject_1 = require("../Library/Event/Objects/TimerObject");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
const ReferenceFrameArrow_1 = require("../Library/Motion6D/Arrows/ReferenceFrameArrow");
const ReferenceFrameData_1 = require("../Library/Motion6D/Objects/ReferenceFrameData");
const RigidReferenceFrame_1 = require("../Library/Motion6D/Objects/RigidReferenceFrame");
const SerializablePosition_1 = require("../Library/Motion6D/Objects/SerializablePosition");
const Basic3DShape_1 = require("../Library/Motion6D/Objects/Shapes/Basic3DShape");
const BasicCamera_1 = require("../Library/Motion6D/Visible/BasicCamera");
const VisibleConsumerLink_1 = require("../Library/Motion6D/Visible/VisibleConsumerLink");
const TimeSpan_1 = require("../Library/Utilities/DateTime/TimeSpan");
class Frame_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["a", 5]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.var_1 = this.getInternalTime();
        this.variable = (this.var_0) * (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
    }
    aliasName0;
    var_0 = 0;
    var_1 = 0;
    var_2 = 0;
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    get_2() {
        return this.success ? this.var_2 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_2());
    }
}
class Frame_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, -19.851545295388156);
        this.addVariableValue("Formula_2", 0, 100.02252954394234);
        this.addVariableValue("Formula_3", 0, 0);
        this.addVariableValue("Formula_4", 0, 0.91141446721709518);
        this.addVariableValue("Formula_5", 0, 0);
        this.addVariableValue("Formula_6", 0, -0.024437251972197357);
        this.addVariableValue("Formula_7", 0, 0.06414828081070735);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = (this.var_3) / (this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = (this.var_7) / (this.var_8);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = Math.atan(this.var_9);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
        this.variable = (this.var_5) - (this.var_10);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_11 = this.convert(this.variable);
        this.variable = (this.var_11) / (this.var_12);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_13 = this.convert(this.variable);
        this.variable = (this.var_2) * (this.var_13);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_14 = this.convert(this.variable);
        this.variable = (this.var_15) / (this.var_16);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_17 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_19);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_20 = this.convert(this.variable);
        this.variable = (this.var_20) / (this.var_21);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_22 = this.convert(this.variable);
        this.variable = (this.var_18) * (this.var_22);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_23 = this.convert(this.variable);
        this.variable = Math.sin(this.var_23);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_24 = this.convert(this.variable);
        this.variable = (this.var_17) * (this.var_24);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_25 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_27);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_28 = this.convert(this.variable);
        this.variable = (this.var_28) / (this.var_29);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_30 = this.convert(this.variable);
        this.variable = Math.atan(this.var_30);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_31 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_32);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_33 = this.convert(this.variable);
        this.variable = (this.var_33) / (this.var_34);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_35 = this.convert(this.variable);
        this.variable = Math.atan(this.var_35);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_36 = this.convert(this.variable);
        this.variable = (this.var_31) - (this.var_36);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_37 = this.convert(this.variable);
        this.variable = (this.var_26) + (this.var_37);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_38 = this.convert(this.variable);
        this.variable = (this.var_38) / (this.var_39);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_40 = this.convert(this.variable);
        this.variable = (this.var_25) * (this.var_40);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_41 = this.convert(this.variable);
        this.variable = (this.var_14) + (this.var_41);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_42 = this.convert(this.variable);
        this.variable = (this.var_43) - (this.var_0);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_44 = this.convert(this.variable);
        this.variable = (this.var_45) / (this.var_46);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_47 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_48);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_49 = this.convert(this.variable);
        this.variable = (this.var_49) / (this.var_50);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_51 = this.convert(this.variable);
        this.variable = Math.atan(this.var_51);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_52 = this.convert(this.variable);
        this.variable = (this.var_47) + (this.var_52);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_53 = this.convert(this.variable);
        this.variable = (this.var_53) / (this.var_54);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_55 = this.convert(this.variable);
        this.variable = (this.var_44) * (this.var_55);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_56 = this.convert(this.variable);
        this.variable = (this.var_42) + (this.var_56);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_57 = this.convert(this.variable);
        this.variable = (this.var_59) / (this.var_60);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_61 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_62);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_63 = this.convert(this.variable);
        this.variable = (this.var_63) / (this.var_64);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_65 = this.convert(this.variable);
        this.variable = Math.atan(this.var_65);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_66 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_67);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_68 = this.convert(this.variable);
        this.variable = (this.var_68) / (this.var_69);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_70 = this.convert(this.variable);
        this.variable = Math.atan(this.var_70);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_71 = this.convert(this.variable);
        this.variable = (this.var_66) - (this.var_71);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_72 = this.convert(this.variable);
        this.variable = (this.var_72) / (this.var_73);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_74 = this.convert(this.variable);
        this.variable = (this.var_61) * (this.var_74);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_75 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_77);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_78 = this.convert(this.variable);
        this.variable = (this.var_78) / (this.var_79);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_80 = this.convert(this.variable);
        this.variable = (this.var_76) * (this.var_80);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_81 = this.convert(this.variable);
        this.variable = Math.cos(this.var_81);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_82 = this.convert(this.variable);
        this.variable = (this.var_82) - (this.var_83);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_84 = this.convert(this.variable);
        this.variable = (this.var_75) * (this.var_84);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_85 = this.convert(this.variable);
        this.variable = (this.var_58) - (this.var_85);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_86 = this.convert(this.variable);
        this.variable = (this.var_87) / (this.var_88);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_89 = this.convert(this.variable);
        this.variable = (this.var_90) / (this.var_91);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_92 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_93);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_94 = this.convert(this.variable);
        this.variable = (this.var_94) / (this.var_95);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_96 = this.convert(this.variable);
        this.variable = Math.atan(this.var_96);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_97 = this.convert(this.variable);
        this.variable = (this.var_92) + (this.var_97);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_98 = this.convert(this.variable);
        this.variable = (this.var_98) / (this.var_99);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_100 = this.convert(this.variable);
        this.variable = (this.var_89) * (this.var_100);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_101 = this.convert(this.variable);
        this.variable = (this.var_86) + (this.var_101);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_102 = this.convert(this.variable);
        this.variable = (this.var_104) / (this.var_105);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_106 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_107);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_108 = this.convert(this.variable);
        this.variable = (this.var_108) / (this.var_109);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_110 = this.convert(this.variable);
        this.variable = Math.atan(this.var_110);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_111 = this.convert(this.variable);
        this.variable = (this.var_106) - (this.var_111);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_112 = this.convert(this.variable);
        this.variable = (this.var_112) / (this.var_113);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_114 = this.convert(this.variable);
        this.variable = (this.var_116) / (this.var_117);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_118 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_119);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_120 = this.convert(this.variable);
        this.variable = (this.var_120) / (this.var_121);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_122 = this.convert(this.variable);
        this.variable = Math.atan(this.var_122);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_123 = this.convert(this.variable);
        this.variable = (this.var_118) + (this.var_123);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_124 = this.convert(this.variable);
        this.variable = (this.var_124) / (this.var_125);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_126 = this.convert(this.variable);
        this.variable = -(this.var_126);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_127 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_128);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_129 = this.convert(this.variable);
        this.variable = (this.var_129) / (this.var_130);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_131 = this.convert(this.variable);
        this.variable = Math.atan(this.var_131);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_132 = this.convert(this.variable);
        this.variable = (this.var_0) - (this.var_133);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_134 = this.convert(this.variable);
        this.variable = (this.var_134) / (this.var_135);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_136 = this.convert(this.variable);
        this.variable = Math.atan(this.var_136);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_137 = this.convert(this.variable);
        this.variable = (this.var_132) - (this.var_137);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_138 = this.convert(this.variable);
        this.variable = (this.var_138) / (this.var_139);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_140 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.measurement0 = all[0].getMeasurement(0);
    }
    measurement0;
    var_0 = 0;
    var_1 = 10;
    var_2 = 0;
    var_3 = Math.PI;
    var_4 = 2;
    var_5 = 0;
    var_6 = 10;
    var_7 = 0;
    var_8 = 0.1;
    var_9 = 0;
    var_10 = 0;
    var_11 = 0;
    var_12 = Math.PI;
    var_13 = 0;
    var_14 = 0;
    var_15 = 120;
    var_16 = Math.PI;
    var_17 = 0;
    var_18 = Math.PI;
    var_19 = 10;
    var_20 = 0;
    var_21 = 120;
    var_22 = 0;
    var_23 = 0;
    var_24 = 0;
    var_25 = 0;
    var_26 = Math.PI;
    var_27 = 10;
    var_28 = 0;
    var_29 = 0.1;
    var_30 = 0;
    var_31 = 0;
    var_32 = 130;
    var_33 = 0;
    var_34 = 0.1;
    var_35 = 0;
    var_36 = 0;
    var_37 = 0;
    var_38 = 0;
    var_39 = Math.PI;
    var_40 = 0;
    var_41 = 0;
    var_42 = 0;
    var_43 = 130;
    var_44 = 0;
    var_45 = Math.PI;
    var_46 = 2;
    var_47 = 0;
    var_48 = 130;
    var_49 = 0;
    var_50 = 0.1;
    var_51 = 0;
    var_52 = 0;
    var_53 = 0;
    var_54 = Math.PI;
    var_55 = 0;
    var_56 = 0;
    var_57 = 0;
    var_58 = 100;
    var_59 = 120;
    var_60 = Math.PI;
    var_61 = 0;
    var_62 = 10;
    var_63 = 0;
    var_64 = 0.1;
    var_65 = 0;
    var_66 = 0;
    var_67 = 130;
    var_68 = 0;
    var_69 = 0.1;
    var_70 = 0;
    var_71 = 0;
    var_72 = 0;
    var_73 = Math.PI;
    var_74 = 0;
    var_75 = 0;
    var_76 = Math.PI;
    var_77 = 10;
    var_78 = 0;
    var_79 = 120;
    var_80 = 0;
    var_81 = 0;
    var_82 = 0;
    var_83 = 1;
    var_84 = 0;
    var_85 = 0;
    var_86 = 0;
    var_87 = 240;
    var_88 = Math.PI;
    var_89 = 0;
    var_90 = Math.PI;
    var_91 = 2;
    var_92 = 0;
    var_93 = 130;
    var_94 = 0;
    var_95 = 0.1;
    var_96 = 0;
    var_97 = 0;
    var_98 = 0;
    var_99 = Math.PI;
    var_100 = 0;
    var_101 = 0;
    var_102 = 0;
    var_103 = 0;
    var_104 = Math.PI;
    var_105 = 2;
    var_106 = 0;
    var_107 = 70;
    var_108 = 0;
    var_109 = 20;
    var_110 = 0;
    var_111 = 0;
    var_112 = 0;
    var_113 = Math.PI;
    var_114 = 0;
    var_115 = 0;
    var_116 = Math.PI;
    var_117 = 2;
    var_118 = 0;
    var_119 = 130;
    var_120 = 0;
    var_121 = 10;
    var_122 = 0;
    var_123 = 0;
    var_124 = 0;
    var_125 = Math.PI;
    var_126 = 0;
    var_127 = 0;
    var_128 = 70;
    var_129 = 0;
    var_130 = 20;
    var_131 = 0;
    var_132 = 0;
    var_133 = 130;
    var_134 = 0;
    var_135 = 10;
    var_136 = 0;
    var_137 = 0;
    var_138 = 0;
    var_139 = Math.PI;
    var_140 = 0;
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    get_2() {
        return this.success ? this.var_2 : undefined;
    }
    get_3() {
        return this.success ? this.var_3 : undefined;
    }
    get_4() {
        return this.success ? this.var_4 : undefined;
    }
    get_5() {
        return this.success ? this.var_5 : undefined;
    }
    get_6() {
        return this.success ? this.var_6 : undefined;
    }
    get_7() {
        return this.success ? this.var_7 : undefined;
    }
    get_8() {
        return this.success ? this.var_8 : undefined;
    }
    get_9() {
        return this.success ? this.var_9 : undefined;
    }
    get_10() {
        return this.success ? this.var_10 : undefined;
    }
    get_11() {
        return this.success ? this.var_11 : undefined;
    }
    get_12() {
        return this.success ? this.var_12 : undefined;
    }
    get_13() {
        return this.success ? this.var_13 : undefined;
    }
    get_14() {
        return this.success ? this.var_14 : undefined;
    }
    get_15() {
        return this.success ? this.var_15 : undefined;
    }
    get_16() {
        return this.success ? this.var_16 : undefined;
    }
    get_17() {
        return this.success ? this.var_17 : undefined;
    }
    get_18() {
        return this.success ? this.var_18 : undefined;
    }
    get_19() {
        return this.success ? this.var_19 : undefined;
    }
    get_20() {
        return this.success ? this.var_20 : undefined;
    }
    get_21() {
        return this.success ? this.var_21 : undefined;
    }
    get_22() {
        return this.success ? this.var_22 : undefined;
    }
    get_23() {
        return this.success ? this.var_23 : undefined;
    }
    get_24() {
        return this.success ? this.var_24 : undefined;
    }
    get_25() {
        return this.success ? this.var_25 : undefined;
    }
    get_26() {
        return this.success ? this.var_26 : undefined;
    }
    get_27() {
        return this.success ? this.var_27 : undefined;
    }
    get_28() {
        return this.success ? this.var_28 : undefined;
    }
    get_29() {
        return this.success ? this.var_29 : undefined;
    }
    get_30() {
        return this.success ? this.var_30 : undefined;
    }
    get_31() {
        return this.success ? this.var_31 : undefined;
    }
    get_32() {
        return this.success ? this.var_32 : undefined;
    }
    get_33() {
        return this.success ? this.var_33 : undefined;
    }
    get_34() {
        return this.success ? this.var_34 : undefined;
    }
    get_35() {
        return this.success ? this.var_35 : undefined;
    }
    get_36() {
        return this.success ? this.var_36 : undefined;
    }
    get_37() {
        return this.success ? this.var_37 : undefined;
    }
    get_38() {
        return this.success ? this.var_38 : undefined;
    }
    get_39() {
        return this.success ? this.var_39 : undefined;
    }
    get_40() {
        return this.success ? this.var_40 : undefined;
    }
    get_41() {
        return this.success ? this.var_41 : undefined;
    }
    get_42() {
        return this.success ? this.var_42 : undefined;
    }
    get_43() {
        return this.success ? this.var_43 : undefined;
    }
    get_44() {
        return this.success ? this.var_44 : undefined;
    }
    get_45() {
        return this.success ? this.var_45 : undefined;
    }
    get_46() {
        return this.success ? this.var_46 : undefined;
    }
    get_47() {
        return this.success ? this.var_47 : undefined;
    }
    get_48() {
        return this.success ? this.var_48 : undefined;
    }
    get_49() {
        return this.success ? this.var_49 : undefined;
    }
    get_50() {
        return this.success ? this.var_50 : undefined;
    }
    get_51() {
        return this.success ? this.var_51 : undefined;
    }
    get_52() {
        return this.success ? this.var_52 : undefined;
    }
    get_53() {
        return this.success ? this.var_53 : undefined;
    }
    get_54() {
        return this.success ? this.var_54 : undefined;
    }
    get_55() {
        return this.success ? this.var_55 : undefined;
    }
    get_56() {
        return this.success ? this.var_56 : undefined;
    }
    get_57() {
        return this.success ? this.var_57 : undefined;
    }
    get_58() {
        return this.success ? this.var_58 : undefined;
    }
    get_59() {
        return this.success ? this.var_59 : undefined;
    }
    get_60() {
        return this.success ? this.var_60 : undefined;
    }
    get_61() {
        return this.success ? this.var_61 : undefined;
    }
    get_62() {
        return this.success ? this.var_62 : undefined;
    }
    get_63() {
        return this.success ? this.var_63 : undefined;
    }
    get_64() {
        return this.success ? this.var_64 : undefined;
    }
    get_65() {
        return this.success ? this.var_65 : undefined;
    }
    get_66() {
        return this.success ? this.var_66 : undefined;
    }
    get_67() {
        return this.success ? this.var_67 : undefined;
    }
    get_68() {
        return this.success ? this.var_68 : undefined;
    }
    get_69() {
        return this.success ? this.var_69 : undefined;
    }
    get_70() {
        return this.success ? this.var_70 : undefined;
    }
    get_71() {
        return this.success ? this.var_71 : undefined;
    }
    get_72() {
        return this.success ? this.var_72 : undefined;
    }
    get_73() {
        return this.success ? this.var_73 : undefined;
    }
    get_74() {
        return this.success ? this.var_74 : undefined;
    }
    get_75() {
        return this.success ? this.var_75 : undefined;
    }
    get_76() {
        return this.success ? this.var_76 : undefined;
    }
    get_77() {
        return this.success ? this.var_77 : undefined;
    }
    get_78() {
        return this.success ? this.var_78 : undefined;
    }
    get_79() {
        return this.success ? this.var_79 : undefined;
    }
    get_80() {
        return this.success ? this.var_80 : undefined;
    }
    get_81() {
        return this.success ? this.var_81 : undefined;
    }
    get_82() {
        return this.success ? this.var_82 : undefined;
    }
    get_83() {
        return this.success ? this.var_83 : undefined;
    }
    get_84() {
        return this.success ? this.var_84 : undefined;
    }
    get_85() {
        return this.success ? this.var_85 : undefined;
    }
    get_86() {
        return this.success ? this.var_86 : undefined;
    }
    get_87() {
        return this.success ? this.var_87 : undefined;
    }
    get_88() {
        return this.success ? this.var_88 : undefined;
    }
    get_89() {
        return this.success ? this.var_89 : undefined;
    }
    get_90() {
        return this.success ? this.var_90 : undefined;
    }
    get_91() {
        return this.success ? this.var_91 : undefined;
    }
    get_92() {
        return this.success ? this.var_92 : undefined;
    }
    get_93() {
        return this.success ? this.var_93 : undefined;
    }
    get_94() {
        return this.success ? this.var_94 : undefined;
    }
    get_95() {
        return this.success ? this.var_95 : undefined;
    }
    get_96() {
        return this.success ? this.var_96 : undefined;
    }
    get_97() {
        return this.success ? this.var_97 : undefined;
    }
    get_98() {
        return this.success ? this.var_98 : undefined;
    }
    get_99() {
        return this.success ? this.var_99 : undefined;
    }
    get_100() {
        return this.success ? this.var_100 : undefined;
    }
    get_101() {
        return this.success ? this.var_101 : undefined;
    }
    get_102() {
        return this.success ? this.var_102 : undefined;
    }
    get_103() {
        return this.success ? this.var_103 : undefined;
    }
    get_104() {
        return this.success ? this.var_104 : undefined;
    }
    get_105() {
        return this.success ? this.var_105 : undefined;
    }
    get_106() {
        return this.success ? this.var_106 : undefined;
    }
    get_107() {
        return this.success ? this.var_107 : undefined;
    }
    get_108() {
        return this.success ? this.var_108 : undefined;
    }
    get_109() {
        return this.success ? this.var_109 : undefined;
    }
    get_110() {
        return this.success ? this.var_110 : undefined;
    }
    get_111() {
        return this.success ? this.var_111 : undefined;
    }
    get_112() {
        return this.success ? this.var_112 : undefined;
    }
    get_113() {
        return this.success ? this.var_113 : undefined;
    }
    get_114() {
        return this.success ? this.var_114 : undefined;
    }
    get_115() {
        return this.success ? this.var_115 : undefined;
    }
    get_116() {
        return this.success ? this.var_116 : undefined;
    }
    get_117() {
        return this.success ? this.var_117 : undefined;
    }
    get_118() {
        return this.success ? this.var_118 : undefined;
    }
    get_119() {
        return this.success ? this.var_119 : undefined;
    }
    get_120() {
        return this.success ? this.var_120 : undefined;
    }
    get_121() {
        return this.success ? this.var_121 : undefined;
    }
    get_122() {
        return this.success ? this.var_122 : undefined;
    }
    get_123() {
        return this.success ? this.var_123 : undefined;
    }
    get_124() {
        return this.success ? this.var_124 : undefined;
    }
    get_125() {
        return this.success ? this.var_125 : undefined;
    }
    get_126() {
        return this.success ? this.var_126 : undefined;
    }
    get_127() {
        return this.success ? this.var_127 : undefined;
    }
    get_128() {
        return this.success ? this.var_128 : undefined;
    }
    get_129() {
        return this.success ? this.var_129 : undefined;
    }
    get_130() {
        return this.success ? this.var_130 : undefined;
    }
    get_131() {
        return this.success ? this.var_131 : undefined;
    }
    get_132() {
        return this.success ? this.var_132 : undefined;
    }
    get_133() {
        return this.success ? this.var_133 : undefined;
    }
    get_134() {
        return this.success ? this.var_134 : undefined;
    }
    get_135() {
        return this.success ? this.var_135 : undefined;
    }
    get_136() {
        return this.success ? this.var_136 : undefined;
    }
    get_137() {
        return this.success ? this.var_137 : undefined;
    }
    get_138() {
        return this.success ? this.var_138 : undefined;
    }
    get_139() {
        return this.success ? this.var_139 : undefined;
    }
    get_140() {
        return this.success ? this.var_140 : undefined;
    }
    save() {
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
class Frame_CategoryObject_2 extends TimerObject_1.TimerObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.span = new TimeSpan_1.TimeSpan(1000000);
        console.log(this.span);
    }
}
class Frame_CategoryObject_3 extends ReferenceFrameData_1.ReferenceFrameData {
    constructor(desktop, name) {
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
class Frame_CategoryObject_4 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryObject_5 extends BasicCamera_1.BasicCamera {
    postVisibleObject(object) {
        throw new Error("Method not implemented.");
    }
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryObject_6 extends BasicCamera_1.BasicCamera {
    postVisibleObject(object) {
        throw new Error("Method not implemented.");
    }
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryObject_7 extends RigidReferenceFrame_1.RigidReferenceFrame {
    constructor(desktop, name) {
        super(desktop, name);
        this.relativePosition = [];
        this.relativeQuaternion = [];
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
class Frame_CategoryObject_8 extends RigidReferenceFrame_1.RigidReferenceFrame {
    constructor(desktop, name) {
        super(desktop, name);
        this.relativePosition = [];
        this.relativeQuaternion = [];
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
class Frame_CategoryObject_9_Visible extends Basic3DShape_1.Basic3DShape {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryObject_9 extends SerializablePosition_1.SerializablePosition {
    constructor(desktop, name) {
        super(desktop, name);
        this.setParameters(new Frame_CategoryObject_9(desktop, name));
    }
}
class Frame_CategoryObject_11 extends RigidReferenceFrame_1.RigidReferenceFrame {
    constructor(desktop, name) {
        super(desktop, name);
        this.relativePosition = [];
        this.relativeQuaternion = [];
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
class Frame_CategoryObject_12 extends RigidReferenceFrame_1.RigidReferenceFrame {
    constructor(desktop, name) {
        super(desktop, name);
        this.relativePosition = [];
        this.relativeQuaternion = [];
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
class Frame_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_1 extends EventLink_1.EventLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_3 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_4 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_5 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_6 extends VisibleConsumerLink_1.VisibleConsumerLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_7 extends VisibleConsumerLink_1.VisibleConsumerLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_8 extends BelognsToCollection_1.BelongsToCollection {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_9 extends BelognsToCollection_1.BelongsToCollection {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_10 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_11 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame_CategoryArrow_12 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Frame extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Frame";
        this.mapObjects.set("Frame_CategoryObject_0", new Frame_CategoryObject_0(this, "Coefficient"));
        this.mapObjects.set("Frame_CategoryObject_1", new Frame_CategoryObject_1(this, "Motion"));
        this.mapObjects.set("Frame_CategoryObject_2", new Frame_CategoryObject_2(this, "Timer"));
        this.mapObjects.set("Frame_CategoryObject_3", new Frame_CategoryObject_3(this, "Plane frame"));
        this.mapObjects.set("Frame_CategoryObject_4", new Frame_CategoryObject_4(this, "Consumer"));
        this.mapObjects.set("Frame_CategoryObject_5", new Frame_CategoryObject_5(this, "Camera 2"));
        this.mapObjects.set("Frame_CategoryObject_6", new Frame_CategoryObject_6(this, "Camera 1"));
        this.mapObjects.set("Frame_CategoryObject_7", new Frame_CategoryObject_7(this, "Left frame"));
        this.mapObjects.set("Frame_CategoryObject_8", new Frame_CategoryObject_8(this, "Forward frame"));
        this.mapObjects.set("Frame_CategoryObject_9", new Frame_CategoryObject_9(this, "Plane"));
        this.mapObjects.set("Frame_CategoryObject_9_Visible", new Frame_CategoryObject_9_Visible(this, "Plane"));
        this.mapObjects.set("Frame_CategoryObject_11", new Frame_CategoryObject_11(this, ""));
        this.mapObjects.set("Frame_CategoryObject_12", new Frame_CategoryObject_12(this, "Transform"));
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
        this.finish();
    }
    finish() {
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        let s0 = this.mapObjects.get("Frame_CategoryObject_4");
        if (s0 != undefined)
            arrows[0].setSource(s0);
        let t0 = this.mapObjects.get("Frame_CategoryObject_1");
        if (t0 != undefined)
            arrows[0].setTarget(t0);
        let s1 = this.mapObjects.get("Frame_CategoryObject_4");
        if (s1 != undefined)
            arrows[1].setSource(s1);
        let t1 = this.mapObjects.get("Frame_CategoryObject_2");
        if (t1 != undefined)
            arrows[1].setTarget(t1);
        let s2 = this.mapObjects.get("Frame_CategoryObject_3");
        if (s2 != undefined)
            arrows[2].setSource(s2);
        let t2 = this.mapObjects.get("Frame_CategoryObject_1");
        if (t2 != undefined)
            arrows[2].setTarget(t2);
        let s3 = this.mapObjects.get("Frame_CategoryObject_4");
        if (s3 != undefined)
            arrows[3].setSource(s3);
        let t3 = this.mapObjects.get("Frame_CategoryObject_3");
        if (t3 != undefined)
            arrows[3].setTarget(t3);
        let s4 = this.mapObjects.get("Frame_CategoryObject_6");
        if (s4 != undefined)
            arrows[4].setSource(s4);
        let t4 = this.mapObjects.get("Frame_CategoryObject_8");
        if (t4 != undefined)
            arrows[4].setTarget(t4);
        let s5 = this.mapObjects.get("Frame_CategoryObject_5");
        if (s5 != undefined)
            arrows[5].setSource(s5);
        let t5 = this.mapObjects.get("Frame_CategoryObject_7");
        if (t5 != undefined)
            arrows[5].setTarget(t5);
        let s6 = this.mapObjects.get("Frame_CategoryObject_5");
        if (s6 != undefined)
            arrows[6].setSource(s6);
        let t6 = this.mapObjects.get("Frame_CategoryObject_9_Visible");
        if (t6 != undefined)
            arrows[6].setTarget(t6);
        let s7 = this.mapObjects.get("Frame_CategoryObject_6");
        if (s7 != undefined)
            arrows[7].setSource(s7);
        let t7 = this.mapObjects.get("Frame_CategoryObject_9_Visible");
        if (t7 != undefined)
            arrows[7].setTarget(t7);
        let s8 = this.mapObjects.get("Frame_CategoryObject_4");
        if (s8 != undefined)
            arrows[8].setSource(s8);
        let t8 = this.mapObjects.get("Frame_CategoryObject_5");
        if (t8 != undefined)
            arrows[8].setTarget(t8);
        let s9 = this.mapObjects.get("Frame_CategoryObject_4");
        if (s9 != undefined)
            arrows[9].setSource(s9);
        let t9 = this.mapObjects.get("Frame_CategoryObject_6");
        if (t9 != undefined)
            arrows[9].setTarget(t9);
        let s10 = this.mapObjects.get("Frame_CategoryObject_1");
        if (s10 != undefined)
            arrows[10].setSource(s10);
        let t10 = this.mapObjects.get("Frame_CategoryObject_0");
        if (t10 != undefined)
            arrows[10].setTarget(t10);
        let s11 = this.mapObjects.get("Frame_CategoryObject_12");
        if (s11 != undefined)
            arrows[11].setSource(s11);
        let t11 = this.mapObjects.get("Frame_CategoryObject_3");
        if (t11 != undefined)
            arrows[11].setTarget(t11);
        let s12 = this.mapObjects.get("Frame_CategoryObject_9");
        if (s12 != undefined)
            arrows[12].setSource(s12);
        let t12 = this.mapObjects.get("Frame_CategoryObject_12");
        if (t12 != undefined)
            arrows[12].setTarget(t12);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
        objects[3].postSetArrow();
        objects[7].postSetArrow();
        objects[8].postSetArrow();
        objects[9].postSetArrow();
        objects[11].postSetArrow();
        objects[12].postSetArrow();
    }
}
exports.Frame = Frame;
