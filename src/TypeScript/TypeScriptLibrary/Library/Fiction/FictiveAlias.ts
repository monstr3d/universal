import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IAlias } from "../Interfaces/IAlias";

export class FictiveAlias implements IAlias {
    getAliasNames(): string[] {
        throw new OwnNotImplemented();
    }
    getAliasType(name: string) {
        throw new OwnNotImplemented();
    }
    getAliasValue(name: string) {
        throw new OwnNotImplemented();
    }
    setAliasValue(name: string, value: any) {
        throw new OwnNotImplemented();
    }

}