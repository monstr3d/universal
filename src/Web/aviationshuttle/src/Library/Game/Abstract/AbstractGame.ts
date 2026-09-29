import type { IGame } from "../../Game/Interfaces/IGame"
import type { IAction } from "../../Interfaces/IAction"
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove"
import type { IFactory } from "../../Interfaces/IFactory"
import type { IObject } from "../../Interfaces/IObject"
import type { IGameDetector } from "../Interfaces/IGameDetector"
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT"
import type { IActionT } from "../../Interfaces/IActionT"
import { ActionArray } from "../../Utilities/Generic/ActionArray"
import { GameDetector } from "../GameDetector"
import { GamePerformer } from "../GamePerformer"
import { AbstractGameObject } from "./AbstractGameObject"
import { ActionArrayT } from "../../Utilities/Generic/ActionArrayT"

export abstract class AbstractGame extends AbstractGameObject implements IGame {

    constructor(name: string, factory: IFactory | undefined) {
        super(name, factory)
        this.types.push("IGame")
        this.types.push("IObjectCollection")
        this.types.push("IObjectCollection")
        this.types.push("ISelfStart")
        this.types.push("IAddAction")
        this.types.push("ISelfLoad")
        this.types.push("IExternalAction")
        this.types.push("IResourceCollection")
        this.types.push("AbstractGame")
        this.typeName = "AbstractGame"
        if (factory != undefined) {
            factory.addFactory<IGameDetector>(new GameDetector(this, factory), "IGameDetector")
        }
    }
    
    getObjectCollection(): IObject[] 
    {
        return this.objects
    }

    addAction(action: IAction, add: boolean): void {
        this.actionF = action
        this.addF = add
    }


    getExternalAction(): IActionAddRemove {
        return this.externalAction
    }



    abstract run(): void

    isRunning(): boolean {
        return this.isStarted;
    }



    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

    cycle(time: number): void {
        this.internaTimeAction.actionT(time)
        this.externalAction.action()
        this.intAct.action()
        this.timeAction.actionT(time)
        this.internalAction.action()
    }



    abstract startItself(start: boolean): boolean 

    abstract loadItself(load: boolean): boolean

    addPostLoadAction(action: IAction): void {
        this.onLoad.addAction(action)
    }

    getTimeAction(): IActionAddRemoveT<number> {
        return this.timeAction
    }

    addTimeAction(action: IActionT<number>, add: boolean): void {
        if (add) {
            this.timeAction.addActionT(action)
            return
        }
        this.timeAction.removeActionT(action)
    }




    public shouldStartAfterLoad(): void {
        const a = new StartAfrerLoad(this)
        this.addPostLoadAction(a)
    }

    protected performer: GamePerformer = new GamePerformer()

    protected typeName: string = "AbstractGame";

    protected types: string[] = ["IObject", "IGame", "IChildrenT<IScene>", "ISelfLoad",
        "IAddAction", "SelfStart", "IObjectCollection", "IExternalAction",
        "IFactoryConsumer", "AbstractGame"];

    protected name: string = "";

    protected internalAction: IActionAddRemove = new ActionArray()

    protected isStarted: boolean = false

    protected isLoaded: boolean = false

    protected intAct: IActionAddRemove = new ActionArray

    protected ft !: number



    protected onLoad: IActionAddRemove = new ActionArray();


    protected timeAction: IActionAddRemoveT<number> = new ActionArrayT()

    protected internaTimeAction: IActionAddRemoveT<number> = new ActionArrayT()


    protected externalAction: IActionAddRemove = new ActionArray()

    protected actionF !: IAction

    protected addF !: boolean

    protected any : any

    protected objects : IObject[] = []


}

class StartAfrerLoad implements IAction {
    constructor(game: IGame) {
        this.game = game
    }

    action(): void {
        this.game.startItself(true)
    }
    isEmptyAction(): boolean {
        return false
    }

    game !: IGame

}