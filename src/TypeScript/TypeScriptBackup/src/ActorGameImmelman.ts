import { Cessna } from "../Cessna"
import { Game3DRealtime, getFactory } from "./Library/Abstract3DGame/Game3DRealtime"
import { Immelman } from "./scenes/Immelman"

export class ActorGameImmelman extends Game3DRealtime {

    constructor() {
        super(getFactory(), new Immelman, 0.5, "Consumer")
        this.loadGame()
          for (var i = 0; i < 1000; i++) {
            let t = i * i * 0.01
            this.actionT(t)
        }
    }

}