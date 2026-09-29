import type { IScene } from "../../Game/Interfaces/IScene";
import type { IObject } from "../../Interfaces/IObject";
import { Performer } from "../../Performer";

export class SceneHolder implements IObject {

    protected performer: Performer = new Performer()
    constructor(scene: any) {
        this.performer = new Performer()
        this.scene = this.performer.convertObject<IScene, any>(scene, "IScene")[0]
    }
    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

    protected typeName: string = "SceneHolder";

    protected types: string[] = ["IObject", "SceneHolder"];

    protected name: string = ""

    protected scene: IScene
}