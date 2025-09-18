"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RealMatrix = void 0;
class RealMatrix {
    normalize(inp, outp, offset) {
        let a = 0;
        for (let i = offset; i < outp.length + offset; i++) {
            let b = inp[i];
            a += b * b;
        }
        a = Math.sqrt(a);
        let c = 1 / a;
        for (let i = 0; i < outp.length; i++) {
            outp[i] = c * inp[i + offset];
        }
        return a;
    }
}
exports.RealMatrix = RealMatrix;
//# sourceMappingURL=RealMatrix.js.map