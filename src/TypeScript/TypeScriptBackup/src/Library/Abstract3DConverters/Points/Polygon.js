"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Polygon = void 0;
class Polygon {
    getMesh() {
        return this.mesh;
    }
    getPoints() {
        return this.points;
    }
    getEffect() {
        return this.effect;
    }
    constructor(mesh, points, effect) {
        this.vertexNormal = [];
        this.normal = [];
        this.points = [];
        this.normalCalc = false;
        this.mesh = mesh;
        this.points = points;
        if (effect === undefined) {
            this.effect = mesh.getEffect();
        }
        else
            this.effect = effect;
        for (var p of points) {
            p.setPolygon(this);
        }
    }
    copy(mesh) {
        for (var point of this.points) {
            point.copy(mesh);
        }
        this.mesh = mesh;
        if (this.effect == undefined) {
            this.effect = mesh.getEffect();
        }
    }
    setNormals() {
        if (this.normalCalc) {
            return;
        }
        for (var p of this.points) {
            p.setPolygon(this);
        }
    }
}
exports.Polygon = Polygon;
//# sourceMappingURL=Polygon.js.map