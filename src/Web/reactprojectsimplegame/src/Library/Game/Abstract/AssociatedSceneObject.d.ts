import type { IScene } from "../../Game/Interfaces/IScene";
import type { IAssociatedObject } from "../../Interfaces/IAssociatedObject";
import type { IObject } from "../../Interfaces/IObject";
import type { IShowObject } from "../../Show/Interfaces/IShowObject";
import type { IResourceFuncFactory } from "../../Resources/Infrefaces/IResourceFuncFactory";
import { AbstractSceneObject } from "./AbstractSceneObject";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import type { IResourceItem } from "../../Resources/Infrefaces/IResourceItem";
export declare abstract class AssociatedSceneObject extends AbstractSceneObject implements IAssociatedObject {
    protected object: IObject;
    constructor(scene: IScene, object: IObject);
    protected getTextFactory(f: ITextReaderFactory | undefined, items: IResourceItem[]): ITextReaderFactory | undefined;
    protected showObject(object: any, str?: string | undefined): void;
    getAssociatedObject(): IObject;
    setAssociatedObject(obj: IObject): void;
    show: IShowObject | undefined;
    protected resourceFactory: IResourceFuncFactory | undefined;
}
//# sourceMappingURL=AssociatedSceneObject.d.ts.map