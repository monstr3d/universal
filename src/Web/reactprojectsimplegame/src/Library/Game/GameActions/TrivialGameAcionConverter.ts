import type { IAction } from "../../Interfaces/IAction";
import { AbstractGameAcionConverter } from "./AbstractGameAcionConverter";

export class TrivialGameAcionConverter extends AbstractGameAcionConverter {
    functT(s: IAction): IAction | undefined {
        return s;
    }

}