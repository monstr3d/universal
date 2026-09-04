"use strict";
/* eslint-disable @typescript-eslint/no-unused-vars */
Object.defineProperty(exports, "__esModule", { value: true });
exports.toDateTime = toDateTime;
const DateTimeConverter_1 = require("../../../Library/Utilities/DateTime/DateTimeConverter");
const converter = new DateTimeConverter_1.DateTimeConverter();
function toDateTime(time) {
    return {
        orbitalTime: converter.fromOADate(time.orbitalTime / 86400.), x: time.x, y: time.y, z: time.z, vx: time.vx, vy: time.vy, vz: time.vz, duration: time.duration
    };
}
