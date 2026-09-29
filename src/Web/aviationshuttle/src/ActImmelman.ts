import { Game3DRealtimeReactGL } from "./ReactWebGL/Game3DRealtimeReactGL";
import { Immelman } from "./scenes/Immelman";
import { getRungeFactory } from "./Library/Measurements/Factories"

export class ActImmelman extends Game3DRealtimeReactGL {

    stopped: boolean = true;
    constructor() {
        super("", getRungeFactory(), new Immelman,  "Consumer", 0.1)
        this.startItself(true)
    }

    public stopItself(): void {
        this.startItself(false)
    }
}
