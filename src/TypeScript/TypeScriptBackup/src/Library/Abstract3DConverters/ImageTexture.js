"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImageTexture = void 0;
class ImageTexture {
    constructor(url, directory) {
        this.url = "";
        this.directory = "";
        this.url = url;
        this.directory = directory;
    }
    getObjectUrl() {
        return this.url;
    }
    setObjecttUrl(url) {
        this.url = url;
    }
}
exports.ImageTexture = ImageTexture;
//# sourceMappingURL=ImageTexture.js.map