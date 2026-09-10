"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getFactory = exports.Game3DRealtime = void 0;
const RungeProcessor_1 = require("../Measurements/DifferentialEquations/Processors/RungeProcessor");
const Motion6DRealtimeFactory_1 = require("../Motion6D/Runtime/Event/Motion6DRealtimeFactory");
const PerformerRealtime_1 = require("../Event/Wrappers/PerformerRealtime");
const Motion6DFactory_1 = require("../Motion6D/Motion6DFactory");
const ResourceFuncFactory_1 = require("../Resources/ResourceFuncFactory");
const UniversalFactory_1 = require("../UniversalFactory");
const LineEndSplitter_1 = require("../Utilities/String/LineEndSplitter");
const BacicGameLoaderFactory_1 = require("./Factory/BacicGameLoaderFactory");
const EmptyObject_1 = require("../EmptyObject");
class Game3DRealtime extends PerformerRealtime_1.PerformerRealtime {
    constructor(factory, desktop, interval, chart) {
        super(factory, desktop, interval, chart);
    }
    prepare() {
    }
}
exports.Game3DRealtime = Game3DRealtime;
const getFactory = () => {
    let f = new UniversalFactory_1.UniversalFactory();
    f.addFactory(new GA, "IGameActionFactory");
    f.addFactory(new BacicGameLoaderFactory_1.BasicGameLoaderFactory(), "IGameLoaderFactory");
    f.addFactory(new LineEndSplitter_1.LineEndSplitter(), "IStringSplitter");
    let rf = new ResourceFuncFactory_1.ResourceFuncFactory("", undefined);
    let processor = new RungeProcessor_1.RungeProcessor();
    f.addFactory(processor, "IDifferentialEquationProcessor");
    let fm = new Motion6DRealtimeFactory_1.Motion6DRealtimeFactory(new Motion6DFactory_1.Motion6DFactory);
    f.addFactory(fm, "IRealtimeCollectionFactory");
    f.addFactory(rf, "IResourceFuncFactory");
    return f;
};
exports.getFactory = getFactory;
class GA extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("IGameActionFactory");
        this.types.push("IGameAction");
        this.types.push("IAction");
        this.types.push("GA");
    }
    action() {
    }
    isEmptyAction() {
        return true;
    }
    functT(s) {
        return this;
    }
    getGameAction(object) {
        return this;
    }
}
//# sourceMappingURL=Game3DRealtime.js.map