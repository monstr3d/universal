import type { IDesktop } from "../Library/Interfaces/IDesktop";
import type { IFactory } from "../Library/Interfaces/IFactory";
import type { IUpdateRef } from "./Interfaces/IUpdateRef";
import type { IPosition } from "../Library/Motion6D/Interfaces/IPosition";
import { UpdateMeshByReferenceFrame } from "./UpdateMeshByReferenceFrame";
import { UpdateMeshByPosition } from "./UpdateMeshByPosition";
import { UpdateMeshByPositionCalibrated } from "./UpdateMeshByPositionCalibrated";
import { Quaternion } from "../Library/Vector3D/Quaternion";
import { UpdateQuaternionScene } from "./UpdateQuaternionScene";
import { Scada3DGame } from "../Library/Abstract3DGame/Scada3DGame";
import { IComponentCollection } from "../Library/Interfaces/IComponentCollection";

export class Game3DRealtimeReactGL extends Scada3DGame {
    constructor(name : string, factory: IFactory, desktop: IComponentCollection,
         consumer: string,  interval : number) 
    {
        super(name, factory, desktop, consumer, interval)
        this.typeName = "Geme3DRealtimeReactGL"
        this.types.push("Geme3DRealtimeReactGL")
    }


    getPosition(name: string): IPosition {
        let rf = this.scada.getScadaObject<IPosition>(name, "IPosition")[0]
        return rf
    }

    public getMeshUpdaterPosition(name: string): IUpdateRef {
        let rf = this.getPosition(name)
        return new UpdateMeshByPosition(rf)
    }

    public getMeshUpdaterPositionCalibrated(name: string, x: number, y: number, z: number, scale: number): IUpdateRef {
        let rf = this.getPosition(name)
        return new UpdateMeshByPositionCalibrated(rf, x, y, z, scale)
    }

    public getMeshUpdaterPositionCalibratedScene(name: string, x: number, y: number, z: number, scale: number): IUpdateRef {
        let rf = this.getPosition(name)
        return new UpdateMeshByPositionCalibrated(rf, x, y, z, scale)
    }

    public getQuaternionScene(name: string, x: number, y: number, z: number, scale: number,
        quaternion: Quaternion) {
        let rf = this.getPosition(name)
        return new UpdateQuaternionScene(rf, x, y, z, scale, quaternion)
    }

    public getMeshUpdater(name: string): IUpdateRef {
        let rf = this.getPosition(name)
        return new UpdateMeshByReferenceFrame(rf)
    }

}



