import fs from 'fs';
import { IResourceItem } from "../../Library/Resources/Infrefaces/IResourceItem";
import { FileResourceFunc } from "./FileResourceFunc";

export class FileResourceFuncText extends FileResourceFunc {
    functT(s: string) {

        if (s.includes(".jpg")) return undefined
        let path = this.getFillPath(s)
        return fs.readFileSync(path, "utf-8").replaceAll("\r\n", "\n")
    }

    constructor(directory: string) {
        super(directory)
        this.types.push("FileResourceFuncText")
        this.typeName = "FileResourceFuncText";
   }

}

