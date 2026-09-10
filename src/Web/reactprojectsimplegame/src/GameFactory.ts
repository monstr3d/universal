import type { IMtlDetector } from "./Library/Abstract3DConverters/Interfaces/IMtlDetector";
import type { IObject } from "./Library/Interfaces/IObject";
import { Motion6DFactory } from "./Library/Motion6D/Motion6DFactory";

export class GameFactory extends Motion6DFactory {
    constructor() {
        super()
        this.addFactory<IMtlDetector>(new GameMtlDetector(), "IMtlDetector")
    }
}
class GameMtlDetector implements IMtlDetector, IObject {
    getName(): string {
        return "";
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) >= 0;
    }

    protected typeName: string = "GameMtlDetector";

    protected types: string[] = ["IObject", "IMtlDetector", "GameMtlDetector"];

    detectMtl(url: string, obj: any): string[] {
        let game = obj as Game
        var str = game.loader.resources[url] as string
        return str.split('\n')
    }

}