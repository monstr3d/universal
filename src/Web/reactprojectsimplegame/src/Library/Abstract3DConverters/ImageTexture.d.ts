import type { IUrlObject } from "../IO/Interfaces/IUrlObject";
export declare class ImageTexture implements IUrlObject {
    constructor(url: string, directory: string);
    getObjectUrl(): string;
    setObjecttUrl(url: string): void;
    url: string;
    directory: string;
}
//# sourceMappingURL=ImageTexture.d.ts.map