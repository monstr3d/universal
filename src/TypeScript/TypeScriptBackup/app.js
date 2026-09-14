"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const Quaternion_1 = require("./src/Library/Vector3D/Quaternion");
const Vector3DProcessor_1 = require("./src/Library/Vector3D/Vector3DProcessor");
//new ActorGameImmelman
// new Actor(false)
//new ActorGame()
//
//act.actPI()
console.log('Hello world');
testQ();
//act.loadGame()
console.log("");
function testQ() {
    let x = [0.9813045593964547, 0, 0.042982223683584085, 0.18760034689452026];
    let q = new Quaternion_1.Quaternion;
    q.W = x[0];
    q.X = x[1];
    q.Y = x[2];
    q.Z = x[3];
    let vp = new Vector3DProcessor_1.Vector3DProcessor;
    vp.quaternionNormalize(x);
    vp.quaternionNormalizeQ(q);
    let y = [0, 1, 0, 0];
    let qq = new Quaternion_1.Quaternion;
    qq.W = y[0];
    qq.X = y[1];
    qq.Y = y[2];
    qq.Z = y[3];
    let z = [1, 0, 0, 0];
    let qqq = new Quaternion_1.Quaternion;
    vp.quaternionMultiply(x, y, z);
    vp.quaternionMultiplyQ(q, qq, qqq);
    let mat = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];
    let mmm = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0],
        [0, 0, 0, 0], [0, 0, 0, 0],];
    vp.quaternionToMatrix(z, mat, mmm);
    let i = 0;
    ++i;
}
//# sourceMappingURL=app.js.map