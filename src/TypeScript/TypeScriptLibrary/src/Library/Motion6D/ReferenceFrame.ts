import type { IObject } from "../Interfaces/IObject";
import type { INodeT } from "../NamedTree/Interfaces/INodeT";
import type { IOrientation } from "./Interfaces/IOrientation";
import type { IPosition } from "./Interfaces/IPosition";
import type { IReferenceFrame } from "./Interfaces/IReferenceFrame";
import { Performer } from "../Performer";
import { RealMatrix } from "../RealMatrixProcessor/RealMatrix";
import { Vector3DProcessor } from "../Vector3D/Vector3DProcessor";

export class ReferenceFrame implements IPosition, IOrientation, IObject {
    setParameters(parameters: any): void {
        this.parameters = parameters;
    }
    getParentT(): INodeT<IPosition> | undefined {
        return this.parentNode;
    }
    setParentT(parent: INodeT<IPosition>): void {
        this.parentNode = parent;
    }
    getNodesT(): INodeT<IPosition>[] {
        return this.nodes;
    }
    addNodeT(node: INodeT<IPosition>): void {
        this.nodes.push(node);
    }
    removeNodeT(node: INodeT<IPosition>): void {
       this.nodes =  this.performer.remove(this.nodes, node);
    }
    getNodeValueT(): IPosition {
        return this;
    }

    public copyReferenceFrameFromArrays(m: number[][], p: number[]): void {
        var mm = this.matrix;
        for (var i = 0; i < m.length; i++) {
            var c = m[i]
            var cc = mm[i]
            for (var j = 0; j < cc.length; j++) {
                cc[j] = c[i]
            }
        }
        var pp = this.position
        for (var i = 0; i < p.length; i++) {
            pp[i] = p[i]
        }
    }

    public copyReferenceFrameFromPositionQuatetnion(position: number[], quaternion: number[]): void {
        var p = this.position
        for (var i = 0; i < p.length; i++) {
            p[i] = position[i]
        }
        var q = this.quaternion
        for (var i = 0; i < q.length; i++) {
            q[i] = quaternion[i]
        }
        this.setMatrix()
    }


    public copyReferenceFrameFrom(frame: ReferenceFrame): void {
        this.copyReferenceFrameFromArrays(frame.matrix, frame.position)
    }


    protected nodes: INodeT<IPosition>[] = [];
   
    protected performer: Performer = new Performer();

    protected realMatrix: RealMatrix = new RealMatrix();

    protected vp: Vector3DProcessor = new Vector3DProcessor();

    protected positions: IPosition[] = [];


    protected types: string[] = ["IObject", "IOrientation", "IPosition", "ReferenceFrame"];

    protected typeName: string = "ReferenceFrame";

    protected quaternion: number[] = [1, 0, 0, 0];

    /// <summary>
    /// Absolute position
    /// </summary>
    protected position: number[] = [0, 0, 0];

    /// <summary>
    /// Orientation matrix
    /// </summary>
    protected matrix: number[][] = [[1, 0, 0], [0, 1, 0], [0, 0, 1]];

    /// <summary>
    /// Auxiliary array
    /// </summary>
    protected qq: number[][] = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]]

    /// <summary>
    /// Auxiliary array
    /// </summary>
    protected p: number[] = [0, 0, 0]

    /// <summary>
    /// Parent frame
    /// </summary>
    protected parent: IReferenceFrame | undefined;

    protected parentNode: INodeT<IPosition> | undefined;

    /// <summary>
    /// Parameters
    /// </summary>
    protected parameters: any;

    /// <summary>
    /// Auxliary position
    /// </summary>
    private auxPos: number[] = [0, 0, 0]

    public setReferenceFrame(baseFrame: ReferenceFrame, relative: ReferenceFrame): void{
        let m = baseFrame.getMatrix();
        var bp = baseFrame.getPosition();
        var rp = relative.getPosition();
        for (let i = 0; i < 3; i++) {
            this.position[i] = bp[i];
            for (let j = 0; j < 3; j++) {
                this.position[i] += m[i][j] * rp[j];
            }
        }
        this.vp.quaternionMultiply(baseFrame.quaternion, relative.quaternion, this.quaternion);
        this.setMatrix();
    }


    getQuaternion(): number[] {
        return this.quaternion;
    }
    getMatrix(): number[][] {
        return this.matrix;
    }
    getPosition(): number[] {
        return this.position;
    }
    getParentFrame(): IReferenceFrame | undefined {
        return this.parent;
    }
    setParentFrame(parent: IReferenceFrame): void {
        this.parent = parent;
    }


    getParameters() {
        return this.parameters;
    }
    updateReferenceFrame(): void {
        let p = this.getParentFrame();
        if (p === undefined) {
            return;
        }
        let r = p.getOwnFrame();
        if (r === undefined) {
            return;
        }
        this.position = r.getPosition();
        this.quaternion = r.getQuaternion();
        this.matrix = r.getMatrix();
    }

    getPositions(): IPosition[] {
        return this.positions;
    }
    addPosition(position: IPosition): void {
        this.positions.push(position);
    }


    // new Error

    getClassName(): string {
        return this.typeName;
    }
    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) > 0;
    }
    getName(): string {
        return "";
    }

    public getRelativePosition(inPosition: number[], outPosition: number[]): void {
        for (let i = 0; i < 3; i++) {
            this.auxPos[i] = inPosition[i] - this.position[i];
        }
        for (let i = 0; i < 3; i++) {
            outPosition[i] = 0;
            for (let j = 0; j < 3; j++) {
                outPosition[i] += this.matrix[j][i] * this.auxPos[j];
            }
        }
    }

    protected norm(): void {
        this.vp.quaternionNormalize(this.quaternion);
    }

    public setMatrix(): void {
        this.norm();
        this.vp.quaternionToMatrix(this.quaternion, this.matrix, this.qq)
    }

    public getPositionArray(position: IPosition, coordinates: number[]) {
        let p1 = this.getPosition();
        let p2 = position.getPosition();
        for (let i = 0; i < 3; i++) {
            this.p[i] = p2[i] - p1[i];
        }
        for (let i = 0; i < 3; i++) {
            coordinates[i] = 0;
            for (let j = 0; j < 3; j++) {
                coordinates[i] += this.matrix[i][j] * this.p[j];
            }
        }
    }

    public getRelative(baseFrame: ReferenceFrame, relativeFrame: ReferenceFrame,
        result: ReferenceFrame, diff: number[]): void {
        this.vp.quaternionInvertMultiply(relativeFrame.quaternion, baseFrame.quaternion, result.quaternion);
        result.setMatrix();
        for (let i = 0; i < 3; i++) {
            diff[i] = relativeFrame.position[i] - baseFrame.position[i];
        }
        let m = baseFrame.getMatrix();
        let p = result.getPosition();
        for (let i = 0; i < 3; i++) {
            p[i] = 0;
            for (let j = 0; j < 3; j++) {
                p[i] += m[j][i] * diff[j];
            }
        }
    }

    public calculateRotatedPosition(abs: number[], rot: number[]) {
        for (let i = 0; i < 3; i++)
        {
            rot[i] = 0;
            for (let j = 0; j < 3; j++)
            {
                rot[i] += this.matrix[j][i] * abs[j];
            }
        }
    }

}