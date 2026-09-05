import type { IGame } from "../../Game/Interfaces/IGame";
import type { IScene } from "../../Game/Interfaces/IScene";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { IFactory } from "../../Interfaces/IFactory";
import type { IObject } from "../../Interfaces/IObject";
import type { IStepAction } from "../../Measurements/Interfaces/IStepAction";
import { ActionArray } from "../../Utilities/Generic/ActionArray";
import { ScenePerformer } from "../ScenePerformer";

export abstract class AbstractScene implements IScene {
    constructor(game: IGame, name: string) {
        this.game = game;
        this.factory = game.getConsumerFactory()
        this.name = name;
        this.performer = new ScenePerformer(this)
        game.addChildT(this)
    }
    actionT(t: number): void {
        if (this.stepAction === undefined) return
        if (this.currentTime > t) {
            this.currentTime = t
            return
        }
        this.stepAction.actionT2(this.currentTime, t)
        this.currentTime = t;
    }
    isEmptyActionT(): boolean {
        return false
    }
    abstract getStepAction(): IStepAction | undefined

    isRunning(): boolean {
        return this.isStarted;
    }

    getSceneObject(name: string): ISceneObject | undefined {
        if (this.objectMap.has(name)) return this.objectMap.get(name)
        return undefined
    }


    getGame(): IGame {
        return this.game;
    }
    getObjectCollection(): IObject[] {
        return this.objects
    }

    getInternalAction(): IActionAddRemove {
        return this.internalAction
    }

    getExternalAction(): IActionAddRemove {
        return this.externalAction
    }
    setConsumerFactory(factory: IFactory): void {
        this.factory = factory;
        this.performer.setFactoryToObjectCollection(this, factory)
    }
    getConsumerFactory(): IFactory {
        return this.factory
    }
    startItself(start: boolean): boolean {
        if (this.isStarted == start) return false
        this.isStarted = start
        this.performer.startCollecion(start, this);
        return true
    }
    addAction(action: IAction, add: boolean): void {
        if (add) this.externalAction.addAction(action)
        else this.externalAction.removeAction(action)
    }

    loadItself(load: boolean): boolean {
        if (this.isLoaded == load) return false
        this.isLoaded = load
        this.performer.loadCollecion(load, this)
        return true
    }

    getChildernT(): ISceneObject[] {
        return this.children;
    }

    addChildT(child: ISceneObject): void {
        var b = this.performer.addUnique(this.children, child)
        if (b) {
            this.objects.push(child)
            var name = child.getName()
            if (!this.objectMap.has(name)) {
                this.objectMap.set(name, child)
            }
        }
    }

    removeChildT(child: ISceneObject): void {
        var b = this.performer.remove(this.children, child);
        if (b) {
            this.performer.remove(this.objects, child)
            var name = child.getName()
            if (this.objectMap.has(name)) this.objectMap.delete(name)
        }
    }

    protected setFactoryToChildren(): void {
        this.performer.setFactoryToObjectCollection(this, this.getConsumerFactory())
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


    protected game !: IGame

    protected factory !: IFactory

    protected performer !: ScenePerformer

    protected externalAction: IActionAddRemove = new ActionArray();

    protected internalAction: IActionAddRemove = new ActionArray();


    protected objects: IObject[] = []

    protected children: ISceneObject[] = []

    protected objectMap: Map<string, ISceneObject> = new Map()

    protected isStarted: boolean = false

    protected isLoaded: boolean = false

    protected stepAction !: IStepAction


    protected currentTime: number = Number.MAX_VALUE

    protected typeName: string = "AbstractScene";

    protected types: string[] = ["IObject", "IChildrenT<ISceneObject>", "ISelfLoad",
        "IAddAction", "ISelfStart", "IObjectCollection", "IExternalAction",
        "IFactoryConsumer", "IScene", "AbstractScene"];

    protected name: string = "";


}