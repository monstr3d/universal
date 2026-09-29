import type { IAction } from "../../Interfaces/IAction"
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT"
import type { IActionT } from "../../Interfaces/IActionT"
import type { IAddAction } from "../../Interfaces/IAddAction"
import type { IExternalAction } from "../../Interfaces/IExternalAction"
import type { IFactoryConsumer } from "../../Interfaces/IFactoryConsumer"
import type { IObject } from "../../Interfaces/IObject"
import { IObjectCollection } from "../../Interfaces/IObjectCollection"
import type { ISelfLoad } from "../../Interfaces/ISelfLoad"
import type { ISelfStart } from "../../Interfaces/ISelfStart"

export interface IGame extends IObjectCollection, ISelfStart, IAddAction, ISelfLoad, IFactoryConsumer, IExternalAction, IObject {

    cycle(time: number): void

    getTimeAction(): IActionAddRemoveT<number>

    addTimeAction(action: IActionT<number>, add: boolean): void
    
    addPostLoadAction(action: IAction): void

    run() : void

}
