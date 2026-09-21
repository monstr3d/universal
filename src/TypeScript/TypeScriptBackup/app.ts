import { Actor } from "./Actor";
import { ActorCessna } from "./src/ActorCessna";
import { ActorGame } from "./src/ActorGame";
import { ActorGameImmelman } from "./src/ActorGameImmelman";
import { Quaternion } from "./src/Library/Vector3D/Quaternion";
import { Vector3DProcessor } from "./src/Library/Vector3D/Vector3DProcessor";

new ActorCessna

//new ActorGameImmelman
 //new Actor(false)

//new ActorGame()
//
//act.actPI()

console.log('Hello world');

//testQ()

//act.loadGame()
console.log("")

function testQ() {
 
    let x: number[] = [0.9813045593964547, 0, 0.042982223683584085, 0.18760034689452026]
    let q = new Quaternion
    q.W = x[0]
    q.X = x[1]
    q.Y = x[2]
    q.Z = x[3]

    let vp = new Vector3DProcessor

    vp.quaternionNormalize(x)
    vp.quaternionNormalizeQ(q)


    let y: number[] = [0, 1, 0, 0]

    let qq = new Quaternion
    qq.W = y[0]
    qq.X = y[1]
    qq.Y = y[2]
    qq.Z = y[3]


    let z: number[] = [1, 0, 0, 0]
    let qqq = new Quaternion
    vp.quaternionMultiply(x, y, z)
    vp.quaternionMultiplyQ(q, qq, qqq)

    let  mat: number[][] = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]
    let mmm: number[][] = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0],
        [0, 0, 0, 0], [0, 0, 0, 0],]

        vp.quaternionToMatrix(z, mat, mmm)




    let i = 0
   ++i

}