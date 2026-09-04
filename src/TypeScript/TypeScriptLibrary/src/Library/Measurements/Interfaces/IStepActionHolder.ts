import type { IStepAction } from "./IStepAction";

export interface IStepActionHolder {
    getStepAction(): IStepAction | undefined
}