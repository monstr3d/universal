"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractMeshCreator = void 0;
const Performer_1 = require("../../Performer");
const Converter3DPerformer_1 = require("../Converter3DPerformer");
const FactoryObject_1 = require("../../FactoryObject");
class AbstractMeshCreator extends FactoryObject_1.FactoryObject {
    constructor(url, name, directory, obj, factory) {
        super(name, factory);
        this.effects = new Map();
        this.meshes = [];
        this.performer = new Performer_1.Performer();
        this.directory = "";
        this.dict = new Map();
        this.url = "";
        this.typeName = "AbstractMeshCreator";
        this.types = ["IObject", "IMeshCreator", "AbstractMeshCreator"];
        this.name = "";
        this.cPerformer = new Converter3DPerformer_1.Converter3DPefrormer();
        this.effectList = [];
        this.vertices = [];
        this.normals = [];
        this.textures = [];
        this.url = url;
        this.directory = directory;
        this.obj = obj;
        this.types.push("IMeshCreator");
        this.types.push("AbstractMeshCreator");
        this.typeName = "AbstractMeshCreator";
    }
    getObjectUrl() {
        return this.url;
    }
    setObjecttUrl(url) {
        this.url = url;
    }
    getMeshCreatorDirectory() {
        return this.directory;
    }
    getName() {
        return "";
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
    getMeshCreatorURL() {
        return this.url;
    }
    getMeshCreatorMeshes() {
        return this.meshes;
    }
    getMeshCreatorEffects() {
        return this.effects;
    }
    getMeshCreatorFactory() {
        return this.factory;
    }
    getMeshCreatorGenerator() {
        return this.obj;
    }
    detectImage(path) {
        if (this.imageDetector === undefined) {
            return true;
        }
        return this.imageDetector.detectImage(path);
    }
    existsFile(fileName) {
        return this.fileio.existsFile(fileName);
    }
    pathCombine(path1, path2) {
        return this.path.pathCombine(path1, path2);
    }
    toStringT(object) {
        return this.performer.convert(object);
    }
    toShiftString(str, shift) {
        return this.cPerformer.toShiftString(str, shift);
    }
    toReal(s) {
        return this.performer.convert(s);
    }
    toRealArray(str) {
        return this.cPerformer.toRealArray(str);
    }
    addTexture(l, texture) {
        this.cPerformer.addTexture(l, texture);
    }
    toFloat(s) {
        return this.performer.convert(s);
    }
}
exports.AbstractMeshCreator = AbstractMeshCreator;
//# sourceMappingURL=AbstractMeshCreator.js.map