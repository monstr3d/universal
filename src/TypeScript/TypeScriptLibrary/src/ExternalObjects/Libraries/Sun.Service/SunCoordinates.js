"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SunCoordinates = void 0;
class SunCoordinates {
    azimuth = 0;
    zenithAngle = 0;
    getAzimuth() {
        return this.azimuth;
    }
    setAzimuth(azimuth) {
        this.azimuth = azimuth;
    }
    getZenithAngle() {
        return this.zenithAngle;
    }
    setZenithAngle(zenithAngle) {
        this.zenithAngle = zenithAngle;
    }
}
exports.SunCoordinates = SunCoordinates;
