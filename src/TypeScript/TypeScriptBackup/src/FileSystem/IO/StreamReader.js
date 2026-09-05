"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.StreamReader = void 0;
const fs_1 = __importDefault(require("fs"));
const LinesTextReader_1 = require("../../Library/IO/LinesTextReader");
class StreamReader extends LinesTextReader_1.LinesTextReader {
    constructor(fullpath) {
        super();
        this.typeName = "StreamReader";
        this.types.push("StreamReader");
        this.text = fs_1.default.readFileSync(fullpath, "utf-8").replaceAll("\r\n", "\n");
        this.split();
    }
}
exports.StreamReader = StreamReader;
//# sourceMappingURL=StreamReader.js.map