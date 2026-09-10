import { getFactory } from "./Library/Abstract3DGame/Game3DRealtime";
import { Game3DRealtimeReactGL } from "./ReactWebGL/Game3DRealtimeReactGL";
import { Immelman } from "./scenes/Immelman";

export class ActImmelman extends Game3DRealtimeReactGL {

    constructor() {
        super(getFactory(), new Immelman, 0.5, "Consumer")
        this.loadGame()
    }
}
