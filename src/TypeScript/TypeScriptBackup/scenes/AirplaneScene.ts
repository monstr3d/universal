import type { IGame } from "../src/Library/Game/Interfaces/IGame";
import { ScadaScene } from "../src/Library/Game/Scenes/ScadaScene";
import { Airplane } from "./Airplane";



export class AirplaneScene extends ScadaScene {
    constructor(game: IGame, chart: string) {
        super(game, new Airplane(), chart)
    }
}
