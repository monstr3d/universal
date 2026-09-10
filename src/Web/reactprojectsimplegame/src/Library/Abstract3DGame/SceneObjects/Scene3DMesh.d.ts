import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import type { IMeshHolder } from "../../Abstract3DConverters/Interfaces/IMeshHolder";
import type { IScene } from "../../Game/Interfaces/IScene";
import type { ISelfLoad } from "../../Interfaces/ISelfLoad";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import type { IResourceCollection } from "../../Resources/Infrefaces/IResouceCollection";
import type { IResourceItem } from "../../Resources/Infrefaces/IResourceItem";
import { AssociatedSceneObject } from "../../Game/Abstract/AssociatedSceneObject";
import { Basic3DShape } from "../../Motion6D/Objects/Shapes/Basic3DShape";
export declare class Scene3DMesh extends AssociatedSceneObject implements IMeshHolder, ISelfLoad, IResourceCollection {
    constructor(scene: IScene, object: Basic3DShape);
    createTextReaderFactory(): void;
    setScene(scene: IScene): void;
    getResources(): IResourceItem[];
    loadItself(load: boolean): boolean;
    getHolderMeshes(): IMesh[];
    loadMesh(load: boolean): void;
    shape: Basic3DShape;
    meshes: IMesh[];
    isLoaded: boolean;
    textReader: ITextReaderFactory | undefined;
}
//# sourceMappingURL=Scene3DMesh.d.ts.map