"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractMeshPolygon = void 0;
const AbstractMesh_1 = require("./AbstractMesh");
class AbstractMeshPolygon extends AbstractMesh_1.AbstractMesh {
    constructor(parent, name, transformationMatrix, effect, polygons, vertices, textures, normals, tuple, creator) {
        super(parent, name, transformationMatrix, effect, vertices, textures, normals, tuple, creator);
        this.polygons = [];
        this.polygons = polygons;
    }
}
exports.AbstractMeshPolygon = AbstractMeshPolygon;
//# sourceMappingURL=AbstractMeshPolygon.js.map