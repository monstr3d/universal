"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LoadImage = LoadImage;
exports.CheckerBoard = CheckerBoard;
exports.SingleColor = SingleColor;
function LoadImage(gl, image) {
    const texture = gl.createTexture();
    gl.bindTexture(gl.TEXTURE_2D, texture);
    gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, true);
    gl.pixelStorei(gl.UNPACK_ALIGNMENT, 4);
    gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, image);
    gl.generateMipmap(gl.TEXTURE_2D);
    return texture;
}
function CheckerBoard(gl, imageSize, cellSize, color0, color1) {
    const texture = gl.createTexture();
    gl.bindTexture(gl.TEXTURE_2D, texture);
    gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, true);
    gl.pixelStorei(gl.UNPACK_ALIGNMENT, 4);
    let data = Array(imageSize[0] * imageSize[1] * 4);
    for (let j = 0; j < imageSize[1]; j++) {
        for (let i = 0; i < imageSize[0]; i++) {
            data[i + j * imageSize[0]] = (Math.floor(i / cellSize[0]) + Math.floor(j / cellSize[1])) % 2 == 0 ? color0 : color1;
        }
    }
    gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA8, imageSize[0], imageSize[1], 0, gl.RGBA, gl.UNSIGNED_BYTE, new Uint8Array(data.flat()));
    gl.generateMipmap(gl.TEXTURE_2D);
    return texture;
}
function SingleColor(gl, color = [255, 255, 255, 255]) {
    const texture = gl.createTexture();
    gl.bindTexture(gl.TEXTURE_2D, texture);
    gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, true);
    gl.pixelStorei(gl.UNPACK_ALIGNMENT, 4);
    gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA8, 1, 1, 0, gl.RGBA, gl.UNSIGNED_BYTE, new Uint8Array(color));
    gl.generateMipmap(gl.TEXTURE_2D);
    return texture;
}
//# sourceMappingURL=texture-utils.js.map