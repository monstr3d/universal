"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CompositionAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const Composition_1 = require("../Composition");
class CompositionAct extends Composition_1.Composition {
    dc;
    factory = new Motion6DFactory_1.Motion6DFactory;
    constructor() {
        super();
        var co = this.getCategoryObject("Chart");
        this.dc = co;
    }
    action() {
        var k = this.dc.getAllMeasurements();
        var a = k[0].getMeasurement(0).getMeasurementValue();
        console.log(a);
    }
    isEmptyAction() {
        return false;
    }
    func() {
        return false;
    }
    test() {
        var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 1000, this, this);
    }
}
exports.CompositionAct = CompositionAct;
/*

import { AliasName } from "../Library/AliasName";
import { BelongsToCollection } from "../Library/Arrows/BelognsToCollection";
import { Desktop } from "../Library/Desktop";
import { EventLink } from "../Library/Event/Objects/EventLink";
import { TimerObject } from "../Library/Event/Objects/TimerObject";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { TimeSpan } from "../Library/Utilities/DateTime/TimeSpan";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
*/ 
