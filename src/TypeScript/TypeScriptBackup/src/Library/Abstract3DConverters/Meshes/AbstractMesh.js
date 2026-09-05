"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractMesh = void 0;
const Performer_1 = require("../../Performer");
const Converter3DPerformer_1 = require("../Converter3DPerformer");
class AbstractMesh {
    constructor(parent, name, transformationMatrix, effect, vertices, textures, normals, tuple, creator) {
        this.typeName = "AbstractMesh";
        this.types = ["IObject", "IMesh", "INodeT<IMesh>", "IGeometry", "INamed", "AbstractMesh"];
        this.name = "";
        this.cPerformer = new Converter3DPerformer_1.Converter3DPefrormer();
        this.performer = new Performer_1.Performer();
        this.nodes = [];
        this.transformationMatrix = [];
        this.textures = [];
        this.normals = [];
        this.vertices = [];
        this.indexes = [];
        this.absolutevertices = [];
        if (tuple != null)
            this.tuple = tuple;
        if (parent != undefined) {
            this.parent = parent;
            parent.addNodeT(this);
        }
        this.name = name;
        this.transformationMatrix = transformationMatrix;
        if (effect != undefined)
            this.effect = effect;
        this.vertices = vertices;
        this.textures = textures;
        this.normals = normals;
        this.creator = creator;
    }
    getIndexes() {
        return this.indexes;
    }
    getAbsoluteVertices() {
        return this.vertices;
    }
    getEffect() {
        return this.effect;
    }
    calculateAbsolute() {
    }
    getVertices() {
        return this.vertices;
    }
    getNormals() {
        return this.normals;
    }
    getTextures() {
        return this.textures;
    }
    getTransformationMatrix() {
        return this.transformationMatrix;
    }
    getNamedName() {
        return this.name;
    }
    setNamedName(name) {
        this.name = name;
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
    getParentT() {
        return this.parent;
    }
    setParentT(parent) {
        this.parent = parent;
    }
    getNodesT() {
        return this.nodes;
    }
    addNodeT(node) {
        this.nodes.push(node);
    }
    removeNodeT(node) {
        this.performer.remove(this.nodes, node);
    }
    getNodeValueT() {
        return this;
    }
    createPointTexture(geometry, vertex, texture, normal) {
        return this.cPerformer.createPointTexture(geometry, vertex, texture, normal);
    }
    toFloat(s) {
        return this.performer.convert(s);
    }
}
exports.AbstractMesh = AbstractMesh;
//# sourceMappingURL=AbstractMesh.js.map