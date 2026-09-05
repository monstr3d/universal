import type { IGame } from "../../Game/Interfaces/IGame"
import type { IScene } from "../../Game/Interfaces/IScene"
import type { IAction } from "../../Interfaces/IAction"
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove"
import type { IFactory } from "../../Interfaces/IFactory"
import type { IObject } from "../../Interfaces/IObject"
import type { IResourceCollection } from "../../Resources/Infrefaces/IResouceCollection"
import type { IResourceItem } from "../../Resources/Infrefaces/IResourceItem"
import type { IGameDetector } from "../Interfaces/IGameDetector"
import type { IResourceFuncFactory } from "../../Resources/Infrefaces/IResourceFuncFactory"
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT"
import type { IActionT } from "../../Interfaces/IActionT"
import { ActionArray } from "../../Utilities/Generic/ActionArray"
import { GameDetector } from "../GameDetector"
import { GamePerformer } from "../GamePerformer"
import { AbstractGameObject } from "./AbstractGameObject"
import Loader, { type ResourceInformation } from "../../RemoteResuorces/Loader"
import { ActionArrayT } from "../../Utilities/Generic/ActionArrayT"

export abstract class AbstractGame extends AbstractGameObject implements IGame, IResourceCollection {

    constructor(name: string, factory: IFactory | undefined, useLoader: boolean) {
        super(name, factory)
        this.types.push("IGame")
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
        this.useLoader = useLoader;
        if (useLoader) {
            this.loader = new Loader()
            if (factory != undefined) {
                let loadFact = this.performer.createFactory(this.loader, factory)
                factory.addFactory<IResourceFuncFactory>(loadFact, "IResourceFuncFactory")
            }
        }
    }
    addAction(action: IAction, add: boolean): void {
        this.actionF = action
        this.addF = add
    }


    getExternalAction(): IActionAddRemove {
        return this.externalAction
    }

    getResources(): IResourceItem[] {
        return this.resources
    }


    abstract run(): void

    isRunning(): boolean {
        return this.isStarted;
    }


    addScene(name: string, scene: IScene): void {
        this.scenes.set(name, scene)
        this.objects.push(scene)
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

    getScenes(): Map<string, IScene> {
        return this.scenes
    }


    cycle(time: number): void {
        this.internaTimeAction.actionT(time)
        this.externalAction.action()
        this.intAct.action()
        this.timeAction.actionT(time)
        this.internalAction.action()

    }

    getObjectCollection(): IObject[] {
        return this.objects;
    }


    setConsumerFactory(factory: IFactory): void {
        super.setConsumerFactory(factory)
        this.performer.setFactoryToObjectCollection(this, factory)
    }

    startItself(start: boolean): boolean {
        if (this.isStarted == start) return false
        this.isStarted = start
        this.performer.startCollecion(start, this);
        this.intAct.clearActions();
        this.internaTimeAction.clearActionsT()
        for (var scene of this.scenes) {
            let sc = scene[1]
            this.intAct.addAction(sc.getExternalAction())
            this.internaTimeAction.addActionT(sc)
        }
        return true;
    }

    loadItself(load: boolean): boolean {
        if (this.isLoaded == load) return false
        this.isLoaded = load
        if (load) {
            if (this.loader != undefined) {
                this.loadProtected()
                return true
            }
        }
        this.performer.loadCollecion(load, this)
        this.internalAction.clearActions()
        if (load) {
            this.performer.collectResources(this, this)
            for (var s of this.scenes) {
                this.internalAction.addAction(s[1].getInternalAction())
            }
        }
        return true;
    }

    addChildT(child: IScene): void {
        this.children.push(child)
        this.objects.push(child)
        var name = child.getName()
        if (!this.scenes.has(name)) {
            this.scenes.set(name, child)
        }
    }

    removeChildT(child: IScene): void {
        this.performer.remove(this.children, child)
    }

    getChildernT(): IScene[] {
        return this.children;
    }

    protected async loadProtected(): Promise<void> {
        this.resourcesI.clear()
        this.performer.collectResources(this, this)
        this.performer.convertResourceInfo(this.resources, this.resourcesI)
        this.loader.loadMap(this.resourcesI)
        await this.loader.wait()
        this.performer.loadCollecion(true, this)
        this.internalAction.clearActions()
        this.performer.collectResources(this, this)
        for (var s of this.scenes) {
            this.internalAction.addAction(s[1].getInternalAction())
        }
        this.onLoad.action()
    }

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

    protected scenes: Map<string, IScene> = new Map()

    protected children: IScene[] = []


    protected objects: IObject[] = []



    protected internalAction: IActionAddRemove = new ActionArray()

    protected isStarted: boolean = false

    protected isLoaded: boolean = false

    protected intAct: IActionAddRemove = new ActionArray

    protected areResourcesLoaded: boolean = false

    protected resources: IResourceItem[] = []

    protected ft !: number


    protected loader !: Loader;

    protected useLoader: boolean = false;

    protected resourcesI: Map<string, ResourceInformation> = new Map()

    protected onLoad: IActionAddRemove = new ActionArray();


    protected timeAction: IActionAddRemoveT<number> = new ActionArrayT()

    protected internaTimeAction: IActionAddRemoveT<number> = new ActionArrayT()

    

    externalAction: IActionAddRemove = new ActionArray()

    protected actionF !: IAction

    protected addF !: boolean


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