import { CategoryObject } from "../../CategoryObject";
import { OwnError } from "../../ErrorHandler/OwnError";
import { Motion6DAcceleratedFrame } from "../Motion6DAcceleratedFrame";
import { Motion6DPerformer } from "../Motion6DPerformer";
import { ReferenceFrame } from "../ReferenceFrame";
import { Motion6DFrame } from "../Motion6DFrame";
import { RotatedFrame } from "../RotatedFrame";
import { MovedFrame } from "../MovedFrame";
import { RealMatrix } from "../../RealMatrixProcessor/RealMatrix";
import { Vector3DProcessor } from "../../Vector3D/Vector3DProcessor";
import { PerformerMeasuremets } from "../../Measurements/PerformerMeasuremets";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { INodeT } from "../../NamedTree/Interfaces/INodeT";
import type { IPosition } from "../Interfaces/IPosition";
import type { IReferenceFrame } from "../Interfaces/IReferenceFrame";
import type { IPostLoadPosition } from "../Interfaces/IPostLoadPosition";
import type { IAlias } from "../../Interfaces/IAlias";
import type { IPostSetArrow } from "../../Interfaces/IPostSetArrow";


export class RigidReferenceFrame extends CategoryObject implements IReferenceFrame, IPostLoadPosition, IAlias, IPostSetArrow
{

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "RigidReferenceFrame";
        this.types.push("IReferenceFrame");
        this.types.push("IPosition");
        this.types.push("IPostLoadPosition");
        this.types.push("IPostSetArrow");
        this.types.push("IAlias");
        this.types.push("RigidReferenceFrame");
    }

    



    /// </summary>
    protected relativePosition: number[] = [0, 0, 0];

    /// <summary> : IFunc<any>[] = [];
    /// Relarive quaternion components
    /// </summary>
    protected relativeQuaternion: number[] = [1, 0, 0, 0];

    children: IPosition[] = [];

    /// <summary>
    /// Parent frame
    /// </summary>
    protected parent!: IReferenceFrame;

    protected parentNode !: INodeT<IPosition>

    /// <summary>
    /// Associated parameters
    /// </summary>
    protected parameters: any;

    //protected double[,] relativeMatrix = new double[3, 3];
    /// <summary>
    /// Auxiliary variable
    /// </summary>
    protected q44: number[][] = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]];


    /// <summary>
    /// Linear velocity
    /// </summary>
    protected velocity: number[] = [0, 0, 0, 0];

    // protected double[] relativeVelocity = new double[] { 0, 0, 0 };
    /// <summary>
    /// Angular velocity
    /// </summary>
    protected omega: number[] = [0, 0, 0];

    protected aliasNames: string[] = ["X", "Y", "Z", "Roll", "Pitch", "Yaw"];

    protected alinames: Map<string, number> = new Map<string, number>();


    protected vp: Vector3DProcessor = new Vector3DProcessor();

    protected realMatrix: RealMatrix = new RealMatrix();

    protected own: ReferenceFrame = new Motion6DAcceleratedFrame();

    protected relative: ReferenceFrame = new Motion6DAcceleratedFrame();

    protected mPerformer: Motion6DPerformer = new Motion6DPerformer();


    protected measuremrntPerformrer: PerformerMeasuremets = new PerformerMeasuremets();

    nodes: INodeT<IPosition>[] = [];

    postSetArrow(): void {
        this.setParameters(this.parameters)
        this.createFrame();
        this.relative.copyReferenceFrameFromPositionQuatetnion(this.relativePosition, this.relativeQuaternion)
        this.own.copyReferenceFrameFromPositionQuatetnion(this.relativePosition, this.relativeQuaternion)
    }


    getAliasNames(): string[] {
        return this.aliasNames;
    }
    getAliasType(name: string) {
        return 0;
    }
    getAliasValue(name: string) {

        return this.alinames.get(name);
    }
    setAliasValue(name: string, value: any): void {
        this.alinames.set(name, value)
    }

    postLoadPosition(): void {
        this.createFrame();
        this.copyPositionToRelativeFrame();
        this.copyQuaternionToRelativeFrame();
        this.init();
        this.relative.setMatrix();
      }

    protected impl(s: string): boolean {
        if (this.parent === undefined) { return true; }
        var own = this.parent.getOwnFrame();
        if (own === undefined) { return false }
        return this.performer.implementsType(own, s)
    }

    protected isAcceleration(): boolean {
        return this.impl("IAcceleration")
    }

    protected isVelocity(): boolean {
        return this.impl("IVelocity")
    }


    protected isAngularVelocity(): boolean {
        return this.impl("IAngularVelocity")
    }

    public copyPositionToRelativeFrame(): void {
        var rp = this.relative.getPosition();
        this.performer.copyArray<number>(this.relativePosition, rp);

    }

    public copyQuaternionToRelativeFrame(): void {
        var rp = this.relative.getQuaternion();
        this.performer.copyArray<number>(this.relativeQuaternion, rp);
        this.relative.setMatrix();
    }

    public copy6DPosition() : void {
        this.copyPositionToRelativeFrame();
        this.copyQuaternionToRelativeFrame();
    }

    public init(): void {
        if (this.relative === undefined) {
            return;
        }
        let q = this.relative.getQuaternion()
        for (let i = 0; i < q.length; i++)
        {
            q[i] = this.relativeQuaternion[i];
        }
        var p = this.relative.getPosition();
        for (let i = 0; i < p.length; i++)
        {
            p[i] = this.relativePosition[i];
        }
    }


    protected createFrame(): void {
        if (this.isAcceleration()) {
            this.relative = new Motion6DAcceleratedFrame();
            this.own = new Motion6DAcceleratedFrame();
        }
        if (this.isVelocity() && this.isAngularVelocity()) {
            this.relative = new Motion6DFrame();
            this.own = new Motion6DFrame();
        }
        if (this.isAngularVelocity()) {
            this.relative = new RotatedFrame();
            this.own = new RotatedFrame();
        }
        if (this.isVelocity()) {
            this.relative = new MovedFrame();
            this.own = new MovedFrame();
        }
        this.relative = new ReferenceFrame();
        this.own = new ReferenceFrame();
    }

    getNodeValueT(): IPosition {
        return this;
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
        this.nodes = this.performer.remove(this.nodes, node)
    }
    getOwnFrame(): ReferenceFrame {
        return this.own;
    }
    getPosition(): number[] {
        return this.own.getPosition();
    }
    getParentFrame(): IReferenceFrame | undefined {
        return this.parent;
    }
    setParentFrame(parent: IReferenceFrame): void {
        if ((parent != undefined) && this.parent != undefined) {
            throw new OwnError("Parent", "", "");
        }
        this.parent = parent;
        if (parent == undefined) {
            this.own = this.mPerformer.getBaseFrame();
            return;
        }
    }
    getParameters(): any {
        return this.parameters;
    }

    setParameters(parameters: any): void {
        this.parameters = parameters;
    }

    updateReferenceFrame(): void {
        let own = this.getOwnFrame()
        let b = this.getBaseFrame();
        if (b === undefined)
        {
            this.relative.copyReferenceFrameFrom(own)
        }
        else
        {
            own.setReferenceFrame(b as ReferenceFrame, this.relative);
        }
    }

    protected getBaseFrame(): ReferenceFrame | undefined {
        if (this.parent === undefined) {
            return undefined;
        }
        else {
            return this.parent.getOwnFrame();
        }

    }
}