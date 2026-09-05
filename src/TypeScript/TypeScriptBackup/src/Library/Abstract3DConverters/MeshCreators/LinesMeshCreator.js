"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LinesMeshCreator = void 0;
const AbstractMeshCreator_1 = require("./AbstractMeshCreator");
class LinesMeshCreator extends AbstractMeshCreator_1.AbstractMeshCreator {
    constructor(url, name, directory, obj, factory, func) {
        super(url, name, directory, obj, factory);
        this.lines = [];
        this.globalString = "";
        if (func == undefined)
            return;
        this.func = func;
        var r = func.getTextReader(obj, url);
        if (r === undefined)
            return;
        let tc = factory.getFactory("IStringSplitter");
        if (tc != undefined) {
            this.textConverter = tc;
        }
        /*    let tf = factory.getFactory<ITextReaderFactory>("ITextReaderFactory")
               if (tf != undefined) {
                   this.textReaderFactory = tf
               }
               let tfile = factory.getFactory<IFileFactory>("IFileFactory")
               if (tfile != undefined) {
                   this.fileio = tfile.createFile(obj)
               }
               let tpath = factory.getFactory<IPathFactory>("IPathFactory")
               if (tpath != undefined) {
                   this.path = tpath.createPath(obj)
               }
               if (directory.length == 0) {
                   this.directory = this.path.getDirectoryName(url)
               }
               let td = factory.getFactory<IIODirectoryFactory>("IIODirectoryFactory")
               if (td != undefined) {
                   this.directoryio = td.createDirectoryFactory(obj)
               }
               let idt = factory.getFactory<IImageDetectorFactory>("IImageDetectorFactory")
               if (idt != undefined)
                   this.imageDetector = idt.getImageDetector(obj)*/
        this.globalString = r.readToEnd();
        this.loadMeshCreator();
    }
    loadMeshCreator() {
        this.lines = this.textConverter.splitStrings(this.obj, this.globalString);
        this.loadLines();
    }
    loadStrings(url) {
        var r = this.textReaderFactory.getTextReader(this.obj, url);
        if (r === undefined)
            return [];
        return r.getStrings();
    }
    getName() {
        return this.name;
    }
}
exports.LinesMeshCreator = LinesMeshCreator;
//# sourceMappingURL=LinesMeshCreator.js.map