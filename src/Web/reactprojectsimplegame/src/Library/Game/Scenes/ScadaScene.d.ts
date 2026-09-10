import type { IGame } from "../../Game/Interfaces/IGame";
import type { IComponentCollection } from "../../Interfaces/IComponentCollection";
import type { IStepAction } from "../../Measurements/Interfaces/IStepAction";
import type { IScadaConsumer } from "../../Scada/Interfaces/IScadaConsumer";
import type { IScadaInterface } from "../../Scada/Interfaces/IScadaInterface";
import { AbstractScene } from "../../Game/Abstract/AbstractScene";
export declare class ScadaScene extends AbstractScene implements IScadaConsumer {
    constructor(game: IGame, collection: IComponentCollection, chart: string);
    protected collection: IComponentCollection;
    protected scada: IScadaInterface;
    getStepAction(): IStepAction | undefined;
    getConsumerScada(): IScadaInterface;
    setConsumerScada(scada: IScadaInterface): boolean;
    loadItself(load: boolean): boolean;
    startItself(start: boolean): boolean;
}
//# sourceMappingURL=ScadaScene.d.ts.map