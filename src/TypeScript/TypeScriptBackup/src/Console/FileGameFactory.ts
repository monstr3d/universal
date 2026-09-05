import { FileResourceFuncText } from "../FileSystem/FileImitation/FlleResourceFuncText"
import { FilePath } from "../FileSystem/IO/FilePath"
import { RelativeFileSystemFactory } from "../FileSystem/IO/RelativeFileSystemFactory"
import { IMtlDetector } from "../Library/Abstract3DConverters/Interfaces/IMtlDetector"
import { MtlDetectorTextReader } from "../Library/Abstract3DConverters/MeshCreators/MtlDetectorTextReader"
import { BasicGameLoaderFactory } from "../Library/Abstract3DGame/Factory/BacicGameLoaderFactory"
import { CameraMeshDrawing } from "../Library/Abstract3DGame/Factory/CameraMeshDrawing"
import { IGameActionFactory } from "../Library/Game/Interfaces/IGameActionFactory"
import { IGameLoaderFactory } from "../Library/Game/Interfaces/IGameLoaderFactory"
import type { IShowObject } from "../Library/Show/Interfaces/IShowObject"
import { IPath } from "../Library/IO/Interfaces/IPath"
import { Motion6DFactory } from "../Library/Motion6D/Motion6DFactory"
import { ResourceFuncFactory } from "../Library/Resources/ResourceFuncFactory"
import { ShowObject } from "../Library/Show/ShowObject"
import { IStringSplitter } from "../Library/Utilities/String/Interfaces/IStringSplitter"
import { LineEndSplitter } from "../Library/Utilities/String/LineEndSplitter"
import { ConsoleShowObject } from "../Library/Show/ConsoleShowObject"
import { IFuncT } from "../Library/Interfaces/IFuncT"
import { IShowData } from "../Library/Show/Interfaces/IShowData"

export class FileGameFactory extends Motion6DFactory  {
    rpath: string = ""

    path: IPath = new FilePath()
    constructor(path: string, gameActionFactory: IGameActionFactory) {
        super()
        this.typeName = "RelativeFileSystemDirectory"
        this.types.push("RelativeFileSystemDirectory")
        this.types.push("IGameHolder")
        this.rpath = path;
        var f = new RelativeFileSystemFactory(path)
        f.setFactory(this)
        var mtl = new MtlDetectorTextReader(f)
        this.addFactory<IGameLoaderFactory>(new BasicGameLoaderFactory(), "IGameLoaderFactory")
        this.addFactory<IMtlDetector>(mtl, "IMtlDetector")
        this.addFactory<IStringSplitter>(new LineEndSplitter(), "IStringSplitter")
        this.addFactory<IGameActionFactory>(gameActionFactory, "IGameActionFactory")
        let rf = new ResourceFuncFactory("", undefined);
        this.addFactory<ResourceFuncFactory>(rf, "IResourceFuncFactory")
        rf.addFunction("text", new FileResourceFuncText(path))
    //    let show = new ShowObject(this)
   //     this.addFactory<IShowObject>(show, "IShowObject")
  //      var cc = new CameraMeshDrawing();
   //     show.addActionT(new ConsoleShowObject(new Filrer()))
        //var ccc = new CameraActionConveretFactory("Camera", cc)
        //this.addFactory<IGameAcionConverterFactory>(ccc, "IGameAcionConverterFactory")
        //    this.addFactory<IGameAcionConverterFactory>(new GameAcionConverterFactory(),
        //        "IGameAcionConverterFactory")

    }

}

class Filrer implements IFuncT<boolean, IShowData> {
    functT(sd : IShowData): boolean | undefined {
        var s = sd.name
        if (s == undefined) return true
        if (s.includes("Rotation")) return false
        return true
        
    }

}
