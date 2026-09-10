import type { IActionAddRemoveT } from "./IActionAddRemoveT"

export interface IPlayEngine {

    isEngineEnabled(): boolean

    setEngineEnabled(enabled: boolean): void

    getEngineAction(): IActionAddRemoveT<number>
}
