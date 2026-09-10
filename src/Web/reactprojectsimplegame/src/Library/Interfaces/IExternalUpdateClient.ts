import type { IActionAddRemove } from "./IActionAddRemove";

export interface IExternalUpdateClient {
    setExternalUpdate(action: IActionAddRemove | undefined): void
}