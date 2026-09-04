import { CategoryObject } from "../../../CategoryObject"
import type { IDesktop } from "../../../Interfaces/IDesktop"
import type { IResourceCollection } from "../../../Resources/Infrefaces/IResouceCollection"
import type { IResourceItem } from "../../../Resources/Infrefaces/IResourceItem"
import type { IStartPrimitive } from "../../../UI/IStartPrimitive"
import type { IPosition } from "../../Interfaces/IPosition"
import type { IVisible } from "../../Visible/Interfaces/IVisible"

export class Basic3DShape extends CategoryObject implements IVisible,
    IStartPrimitive, IResourceCollection
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        this.typeName = "Basic3DShape"
        this.types.push("Basic3DShape")
        this.types.push("IVisible")
        this.types.push("IPositionObject")
        this.types.push("ISaveGrahicalData")
        this.types.push("IStartPrimitive")
    }
    getResources(): IResourceItem[] {
        return this.resources
    }

    startPrimitive(): void {
       
    }
    getSaveGrahicalData(): Map<string, string> {
        return this.grahicalData;
    }
    getVisibleSize(): number[][] {
        return this.size
    }
    setVisibleSize(size: number[][]): void {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                this.size[i][j] = size[i][j]
            }
        }
    }
    protected addResource(name: string, url: string, type: 'text' | 'json' | 'image', ext: string): void {
        let r: IResourceItem = { name: name, type: type, ext: ext, url: url }
        this.resources.push(r)
    }


    resources: IResourceItem[] = []
    grahicalData: Map<string, string> = new Map();

    position !: IPosition

    size: number[][] = [[0, 0, 0], [0, 0, 0], [0, 0, 0],]


    getObjectPosition(): IPosition {
        return this.position
    }
    setObjectPosition(position: IPosition): void {
        this.position = position
    }

}

