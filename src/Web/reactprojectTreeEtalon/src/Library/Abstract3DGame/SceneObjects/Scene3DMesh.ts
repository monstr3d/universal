import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import type { IMeshHolder } from "../../Abstract3DConverters/Interfaces/IMeshHolder";
import type { IScene } from "../../Game/Interfaces/IScene";
import type { ISelfLoad } from "../../Interfaces/ISelfLoad";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import type { IResourceCollection } from "../../Resources/Infrefaces/IResouceCollection";
import type { IResourceItem } from "../../Resources/Infrefaces/IResourceItem";
import { Obj3DCreator } from "../../Abstract3DConverters/MeshCreators/Obj3DCreator";
import { AssociatedSceneObject } from "../../Game/Abstract/AssociatedSceneObject";
import { Basic3DShape } from "../../Motion6D/Objects/Shapes/Basic3DShape";

export class Scene3DMesh extends AssociatedSceneObject implements IMeshHolder,
    ISelfLoad, IResourceCollection
{
    constructor(scene: IScene, object: Basic3DShape) {
        super(scene, object)
        this.types.push("IMeshHolder")
        this.types.push("ISelfLoad")
        this.types.push("Scene3DMesh")
        this.types.push("IResourceCollection")
        this.typeName = "Scene3DMesh"
        this.shape = object
    }

  
    createTextReaderFactory(): void {
        this.textReader = this.getTextFactory(this.textReader, this.getResources())
    }


    setScene(scene: IScene): void {
        this.scene = scene
    }

    getResources(): IResourceItem[] {
        return this.shape.getResources()
    }

    loadItself(load: boolean): boolean {
        if (load == this.isLoaded) return false
        this.isLoaded = load
        this.createTextReaderFactory()
        this.loadMesh(load)
        return true;
    }

    getHolderMeshes(): IMesh[] {
        return this.meshes
    }

    loadMesh(load: boolean): void {
        if (!load) return
        var res = this.shape.getResources()
        for (var r of res) {
            if (r.ext == ".obj") {
                var creator = new Obj3DCreator(r.url, r.name,
                    "", this.scene, this.factory, this.textReader);
                this.meshes = creator.getMeshCreatorMeshes()
               break;
            }
        }
    }

 
    shape !: Basic3DShape
    meshes: IMesh[] = []
    isLoaded: boolean = false

    textReader !: ITextReaderFactory | undefined



}