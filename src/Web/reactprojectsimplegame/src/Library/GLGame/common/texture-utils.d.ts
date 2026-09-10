export declare function LoadImage(gl: WebGL2RenderingContext, image: ImageData): WebGLTexture;
type Size = [number, number];
type Color = [number, number, number, number];
export declare function CheckerBoard(gl: WebGL2RenderingContext, imageSize: Size, cellSize: Size, color0: Color, color1: Color): WebGLTexture;
export declare function SingleColor(gl: WebGL2RenderingContext, color?: Color): WebGLTexture;
export {};
//# sourceMappingURL=texture-utils.d.ts.map