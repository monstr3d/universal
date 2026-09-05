import type { IAction } from "../../Interfaces/IAction"
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT"
import type { IActionT } from "../../Interfaces/IActionT"
import type { IAddAction } from "../../Interfaces/IAddAction"
import type { IExternalAction } from "../../Interfaces/IExternalAction"
import type { IFactoryConsumer } from "../../Interfaces/IFactoryConsumer"
import type { IObject } from "../../Interfaces/IObject"
import type { IObjectCollection } from "../../Interfaces/IObjectCollection"
import type { ISelfLoad } from "../../Interfaces/ISelfLoad"
import type { ISelfStart } from "../../Interfaces/ISelfStart"
import type { IChildrenT } from "../../NamedTree/Interfaces/IChildrenT"
import type { IScene } from "./IScene"

export interface IGame extends IObjectCollection,
    ISelfStart, IAddAction, ISelfLoad, IFactoryConsumer, IExternalAction,
    IChildrenT<IScene>, IObject {

    getScenes(): Map<string, IScene>

    addScene(name: string, scene: IScene): void

    cycle(time: number): void

    getTimeAction(): IActionAddRemoveT<number>

    addTimeAction(action: IActionT<number>, add: boolean): void
    
    addPostLoadAction(action: IAction): void

    run() : void

}
