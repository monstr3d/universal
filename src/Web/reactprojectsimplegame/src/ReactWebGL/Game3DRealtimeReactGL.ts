import type { IDesktop } from "../Library/Interfaces/IDesktop";
import type { IFactory } from "../Library/Interfaces/IFactory";
import type { IUpdateRef } from "./Interfaces/IUpdateRef";
import type { IReferenceFrame } from "../Library/Motion6D/Interfaces/IReferenceFrame";
import type { IPosition } from "../Library/Motion6D/Interfaces/IPosition";
import { UpdateMeshByReferenceFrame } from "./UpdateMeshByReferenceFrame";
import { UpdateMeshByPosition } from "./UpdateMeshByPosition";
import { UpdateMeshByPositionCalibrated } from "./UpdateMeshByPositionCalibrated";
import { Game3DRealtime } from "../Library/Abstract3DGame/Game3DRealtime";

export class Game3DRealtimeReactGL extends Game3DRealtime {
    constructor(factory: IFactory, desktop: IDesktop, interval: number,
         consumer: string) {
        super(factory, desktop, interval, consumer)
        this.typeName = "Geme3DRealtimeReactGL"
        this.types.push("Geme3DRealtimeReactGL")
    }

    public getMeshUpdaterPosition(name: string): IUpdateRef {
        let rf = this.scada.getScadaObject<IPosition>(name, "IPosition")[0]
        return new UpdateMeshByPosition(rf)
    }

    public getMeshUpdaterPositionCalibrated(name: string, x: number, y: number, z: number, scale: number): IUpdateRef {
        let rf = this.scada.getScadaObject<IPosition>(name, "IPosition")[0]
        return new UpdateMeshByPositionCalibrated(rf, x, y, z, scale)
    }


    public getMeshUpdater(name: string): IUpdateRef {
        let rf = this.scada.getScadaObject<IReferenceFrame>(name, "IReferenceFrame")[0]
        return new UpdateMeshByReferenceFrame(rf)
    }

}



