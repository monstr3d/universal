import type { IDesktop } from "../../Interfaces/IDesktop";
import type { ICamera } from "../Interfaces/ICamera";
import { BasicPosition } from "../Objects/BasicPosition";
import type { IVisible } from "./Interfaces/IVisible";
import type { IVisibleConsumer } from "./Interfaces/IVisibleConsumer";


export abstract class BasicCamera extends BasicPosition implements IVisibleConsumer, ICamera {

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "BasicCamera";
        this.types.push("IVisibleConsumer");
        this.types.push("ICamera");
        this.types.push("BasicCamera");
    }
    getCameraType(): 'orthographic' | 'perspective' {
        return 'perspective';
    }
    getFieldOfView(): number {
        return this.fieldOfView;
    }
    getNearDistance(): number {
        return this.nearDistance;
    }
    getFarDistance(): number {
        return this.farDistance;
    }


    addVisibleObject(object: IVisible): void {
        this.visible.push(object);
    }
    removeVisibleObject(object: IVisible): void {
        this.performer.remove<IVisible>(this.visible, object);
    }

    abstract postVisibleObject(object: IVisible): void;


    protected visible: IVisible[] = [];

    protected fieldOfView: number = 0;

    protected nearDistance: number = 0;

    protected farDistance: number = 0;


}

