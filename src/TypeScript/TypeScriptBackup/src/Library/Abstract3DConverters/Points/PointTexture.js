"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PointTexture = void 0;
class PointTexture {
    constructor(geometry, vertex, texture, normal) {
        this.vertex = [];
        this.texture = [];
        this.normal = [];
        this.vertexIndex = 0;
        this.textureIndex = 0;
        this.normalIndex = 0;
        try {
            this.geometry = geometry;
            this.vertexIndex = vertex;
            this.textureIndex = texture;
            this.normalIndex = normal;
            this.vertex = geometry.getVertices()[vertex];
            this.normal = geometry.getVertices()[vertex];
            this.texture = geometry.getTextures()[vertex];
            var nn = geometry.getNormals();
            if (nn.length == 0) {
                this.normalIndex = -1;
            }
            else if (normal >= 0) {
                this.normal = geometry.getNormals()[normal];
            }
        }
        catch (e) {
        }
    }
    getGeometry() {
        return this.geometry;
    }
    getVertex() {
        return this.vertex;
    }
    getTexture() {
        return this.texture;
    }
    getNormal() {
        return this.normal;
    }
    getVertexIndex() {
        return this.vertexIndex;
    }
    getTextureIndex() {
        return this.textureIndex;
    }
    getNormalIndex() {
        return this.normalIndex;
    }
    getPolygon() {
        return this.polygon;
    }
    setPolygon(polyon) {
        this.polygon = polyon;
    }
    copy(geometry) {
        this.geometry = geometry;
    }
}
exports.PointTexture = PointTexture;
//# sourceMappingURL=PointTexture.js.map