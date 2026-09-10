import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import type { IGameAction } from "../Game/Interfaces/IGameAction";
import type { IGameActionFactory } from "../Game/Interfaces/IGameActionFactory";
import type { IScene } from "../Game/Interfaces/IScene";
import type { ISceneObject } from "../Game/Interfaces/ISceneObject";
import type { IActionAddRemove } from "../Interfaces/IActionAddRemove";
import type { IActionT } from "../Interfaces/IActionT";
import type { IGameActionConverter } from "./Interfaces/IGameActionConverter";
import type { IGameActionConverterFactory } from "./Interfaces/IGameActionConverterFactory";
import { GamePerformer } from "./GamePerformer";

export class SceneObjectAction implements IActionT<ISceneObject> {

    performer: GamePerformer = new GamePerformer()

    conv !: IGameActionConverter;

    current !: IActionT<ISceneObject>
    

    actionT(t: ISceneObject): void
    {
        var a = this.gameAcion.functT(t)
        if (this.conv != undefined) {
            if (a != undefined) {
                var b = this.conv.functT(a)
                this.action.addAction(b)
                return;
            }
        }
        this.action.addAction(a)
    }

    constructor(scene: IScene) {
        this.scene = scene;
        var f = scene.getConsumerFactory();
        var ff = f.getFactory<IGameActionFactory>("IGameActionFactory")
        var a = ff?.getGameAction(scene)
        if (a != undefined) {
            this.gameAcion = a
        }
        else {
            throw new OwnNotImplemented("SCENE OBJECT ACTION");
        }

        var conv = f.getFactory<IGameActionConverter>("IGameActionConverter")
        if (conv != undefined) {
            this.conv = conv
        }
        var fc = f.getFactory<IGameActionConverterFactory>("IGameActionConverterFactory")
        if (fc != undefined) {
            var conv = fc.getGameActionConverter(scene)
            if (conv != undefined) {
                this.conv = conv
            }
        }
     this.action = scene.getInternalAction()
    }

    isEmptyActionT(): boolean {
        return false;
    }

    gameAcion !: IGameAction;

    scene !: IScene;

    action !: IActionAddRemove

}