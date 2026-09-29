import type { IDataConsumer } from "./Library/Measurements/Interfaces/IDataConsumer";
import type { IMeasurement } from "./Library/Measurements/Interfaces/IMeasurement";
import { Game3DRealtimeReactGL} from "./ReactWebGL/Game3DRealtimeReactGL"
import { Cessna } from "./scenes/Cessna";

export class ActorCessna extends Game3DRealtimeReactGL {

    constructor() {
        super(getRungeFactory(), new Cessna, 0.05, "Chart")
        let dataConsumer = this.scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")[0]
        var mmm = dataConsumer.getAllMeasurements()
        var mm = mmm[2];
        this.X = mm.getMeasurement(3)
        this.Y = mm.getMeasurement(4)
        this.loadGame()

    }


    public getX(): number {
        let xx = this.X.getMeasurementValue()
        return 10 * Number(xx)
    }

    public getY(): number {
        let xx = this.Y.getMeasurementValue()
        return 10 * Number(xx)
    }

    vel: number = 0.005

    public setMotion(forward: boolean, backward: boolean, left: boolean, right: boolean, jump: boolean, stop: boolean): void {
        if (stop) {
            this.game.startItself(false)
        }
        let v = 0;
        if (forward) v = this.vel
        if (backward) v = -this.vel
        this.inputs[0].setInputValue("X", v)
     //   if (v != 0) console.log("X", v)
        v = 0
        if (left) v = this.vel
        if (right) v = -this.vel
        this.inputs[0].setInputValue("Y", v)
        //if (v != 0) console.log("Y", v)

    }



    X !: IMeasurement

    Y !: IMeasurement

}
