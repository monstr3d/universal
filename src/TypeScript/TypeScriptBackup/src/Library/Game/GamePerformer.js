"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GamePerformer = void 0;
const EmptyObject_1 = require("../EmptyObject");
const Performer_1 = require("../Performer");
const ResourceFuncFactory_1 = require("../Resources/ResourceFuncFactory");
class GamePerformer extends Performer_1.Performer {
    sceneToScada(scene) {
        var sh = this.convertObject(scene, "IScadaConsumer");
        if (sh.length == 0)
            return undefined;
        return sh[0].getConsumerScada();
    }
    convertResourceInfo(input, output) {
        for (let item of input) {
            let o = { url: item.url, type: item.type };
            output.set(item.name, o);
        }
    }
    createFactory(loader, factory) {
        var fact = new ResourceFuncFactory_1.ResourceFuncFactory("", factory);
        let rf = new ResourceFactory(loader);
        fact.addFunction("text", rf);
        let lf = new LoaderFactory(loader);
        fact.addFunction("image", lf);
        return fact;
    }
}
exports.GamePerformer = GamePerformer;
class AbstractFactory extends EmptyObject_1.EmptyObject {
    constructor(loader) {
        super("");
        this.loader = loader;
        this.types.push("IResourceFunc");
    }
}
class ResourceFactory extends AbstractFactory {
    constructor(loader) {
        super(loader);
    }
    functT(s) {
        let res = this.loader.getResult();
        let k = res.get(s);
        return k;
    }
}
class LoaderFactory extends AbstractFactory {
    constructor(loader) {
        super(loader);
    }
    functT(s) {
        let p = { loader: this.loader, url: s };
        return p;
    }
}
//# sourceMappingURL=GamePerformer.js.map