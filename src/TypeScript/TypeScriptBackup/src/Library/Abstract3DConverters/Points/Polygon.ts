import type { IFunc } from "../../Interfaces/IFunc";
import type { IMesh } from "../Interfaces/IMesh";
import { EffectTexture } from "../EffectTexture";
import { PointTexture } from "./PointTexture";

export class Polygon {

    protected caclualateVertexNormal !: IFunc<number[]>

    protected vertexNormal: number[] = []

    protected normal: number[] = []

    protected mesh !: IMesh

    public getMesh(): IMesh {
        return this.mesh
    }
    points: PointTexture[] = []

    public getPoints(): PointTexture[] {
        return this.points
    }

    effect!: EffectTexture

    public getEffect(): EffectTexture {
        return this.effect
    }



    normalCalc: boolean = false;

    constructor(mesh: IMesh, points: PointTexture[], effect: EffectTexture | undefined) {
        this.mesh = mesh
        this.points = points
        if (effect === undefined) {
            this.effect = mesh.getEffect()
        }
        else this.effect = effect
        for (var p of points)
        {
            p.setPolygon(this)
        }

    }

    public copy(mesh: IMesh): void {
        for (var point of  this.points)
        {
            point.copy(mesh);
        }
        this.mesh = mesh;
        if (this.effect == undefined) {
            this.effect = mesh.getEffect()
        }

    }

    public setNormals(): void {
        if (this.normalCalc) {
            return;
        }
        for (var p of this.points)
        {
            p.setPolygon(this)
        }
    }

}



    