"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileGameFactory = void 0;
const FlleResourceFuncText_1 = require("../FileSystem/FileImitation/FlleResourceFuncText");
const FilePath_1 = require("../FileSystem/IO/FilePath");
const RelativeFileSystemFactory_1 = require("../FileSystem/IO/RelativeFileSystemFactory");
const MtlDetectorTextReader_1 = require("../Library/Abstract3DConverters/MeshCreators/MtlDetectorTextReader");
const BacicGameLoaderFactory_1 = require("../Library/Abstract3DGame/Factory/BacicGameLoaderFactory");
const Motion6DFactory_1 = require("../Library/Motion6D/Motion6DFactory");
const ResourceFuncFactory_1 = require("../Library/Resources/ResourceFuncFactory");
const LineEndSplitter_1 = require("../Library/Utilities/String/LineEndSplitter");
class FileGameFactory extends Motion6DFactory_1.Motion6DFactory {
    constructor(path, gameActionFactory) {
        super();
        this.rpath = "";
        this.path = new FilePath_1.FilePath();
        this.typeName = "RelativeFileSystemDirectory";
        this.types.push("RelativeFileSystemDirectory");
        this.types.push("IGameHolder");
        this.rpath = path;
        var f = new RelativeFileSystemFactory_1.RelativeFileSystemFactory(path);
        f.setFactory(this);
        var mtl = new MtlDetectorTextReader_1.MtlDetectorTextReader(f);
        this.addFactory(new BacicGameLoaderFactory_1.BasicGameLoaderFactory(), "IGameLoaderFactory");
        this.addFactory(mtl, "IMtlDetector");
        this.addFactory(new LineEndSplitter_1.LineEndSplitter(), "IStringSplitter");
        this.addFactory(gameActionFactory, "IGameActionFactory");
        let rf = new ResourceFuncFactory_1.ResourceFuncFactory("", undefined);
        this.addFactory(rf, "IResourceFuncFactory");
        rf.addFunction("text", new FlleResourceFuncText_1.FileResourceFuncText(path));
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
exports.FileGameFactory = FileGameFactory;
class Filrer {
    functT(sd) {
        var s = sd.name;
        if (s == undefined)
            return true;
        if (s.includes("Rotation"))
            return false;
        return true;
    }
}
//# sourceMappingURL=FileGameFactory.js.map