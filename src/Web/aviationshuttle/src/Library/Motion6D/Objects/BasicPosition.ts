import type { IPosition } from "../Interfaces/IPosition";
import type { IReferenceFrame } from "../Interfaces/IReferenceFrame";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { INodeT } from "../../NamedTree/Interfaces/INodeT";
import { ReferenceFrame } from "../ReferenceFrame";
import { CategoryObject } from "../../CategoryObject";
import { Performer } from "../../Performer";

export class BasicPosition extends CategoryObject implements IPosition {

    /// <summary>
    /// Absolute position
    /// </summary>
    protected position: number[] = [0, 0, 0];

    /// <summary>
    /// Absolute position
    /// </summary>
    protected own: number[] = [0, 0, 0];

    /// <summary>
    /// Parent frame
    /// </summary>
    protected parent: IReferenceFrame | undefined;

    protected parentNode: INodeT<IPosition> | undefined;

    protected parameters: any

    protected performer: Performer = new Performer();

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "BasicPosition";
        this.types.push("IPosition");
        this.types.push("BasicPosition");
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
        return this.parameters
    }
    setParameters(parameters: any): void {
        this.parameters = parameters;
    }
    updateReferenceFrame(): void {
        var f = this.getBaseFrame()
        if (f === undefined) return
        this.udateFrameProtected(f)
    }

    getParentT(): INodeT<IPosition> | undefined {
        return this.parentNode
    }
    setParentT(parent: INodeT<IPosition>): void {
        this.parentNode = parent;
    }
    getNodesT(): INodeT<IPosition>[] {
        return this.nodes
    }
    addNodeT(node: INodeT<IPosition>): void {
        this.current = node
    }
    removeNodeT(node: INodeT<IPosition>): void {
        this.current = node
    }
    getNodeValueT(): IPosition {
        return this;
    }

    current !: INodeT<IPosition>

    nodes: INodeT<IPosition>[] = []

    protected udateFrameProtected(frame: ReferenceFrame): void {
        let m = frame.getMatrix();
        let p = frame.getPosition();
        for (let i = 0; i < 3; i++) {
            this.position[i] = p[i];
            for (let j = 0; j < 3; j++) {
                this.position[i] += m[i][j] * this.own[j];
            }
        }
    }

    protected getBaseFrame(): ReferenceFrame | undefined
    {
        if (this.parent == undefined) {
            return undefined
        }
        return this.parent.getOwnFrame();
    }
}

