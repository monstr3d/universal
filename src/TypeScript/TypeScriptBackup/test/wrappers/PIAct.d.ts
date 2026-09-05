import { IAction } from "../../src/Library/Interfaces/IAction";
import { IDataConsumer } from "../../src/Library/Measurements/Interfaces/IDataConsumer";
import { PI } from "../tests/PI";
export declare class PIAct extends PI implements IAction {
    dc: IDataConsumer;
    constructor();
    action(): void;
    isEmptyAction(): boolean;
    func(): boolean;
    test(): void;
}
//# sourceMappingURL=PIAct.d.ts.map