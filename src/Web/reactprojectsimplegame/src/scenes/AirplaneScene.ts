import type { IGame } from "../Library/Game/Interfaces/IGame";
import { ScadaScene } from "../Library/Game/Scenes/ScadaScene";
import { Airplane } from "./Airplane";



export class AirplaneScene extends ScadaScene {
    constructor(game: IGame, chart: string) {
        super(game, new Airplane(), chart)
    }
}
