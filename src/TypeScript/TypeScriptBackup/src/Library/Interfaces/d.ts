import type { IActionT2 } from "./IActionT2";
export interface IActionAddRemoveT2<T1, T2> extends IActionT2<T1, T2> {
    addActionT2(action: IActionT2<T1, T2> | undefined): void;
    removeActionT2(action: IActionT2<T1, T2> | undefined): void;
    clearActionsT2(): void;
}
//# sourceMappingURL=IActionAddRemoveT2.d.ts.map