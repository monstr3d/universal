import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { ICategoryArrow } from "../Interfaces/ICategoryArrow";
import { ICategoryObject } from "../Interfaces/ICategoryObject";
import { IDesktop } from "../Interfaces/IDesktop";
import { IObject } from "../Interfaces/IObject";
import { Check } from "../Types/Check";

export class FictiveDesktop implements IDesktop{
    getCategoryObjects(): ICategoryObject[] {
        throw new OwnNotImplemented();
    }
    getCategoryArrows(): ICategoryArrow[] {
        throw new OwnNotImplemented();
    }
    addCategoryObject(obj: ICategoryObject): void {
        throw new OwnNotImplemented();
    }
    addCategoryArrow(arr: ICategoryArrow): void {
        throw new OwnNotImplemented();
    }
    addObject(obj: IObject): void {
        throw new OwnNotImplemented();
    }
    getObjects(): IObject[] {
        throw new OwnNotImplemented();
    }
    getCheck(): Check {
        throw new OwnNotImplemented();
    }
    setCheck(check: Check): void {
        throw new OwnNotImplemented();
    }
    getCategoryObject(name: string): ICategoryObject {
        throw new OwnNotImplemented();
    }

}
