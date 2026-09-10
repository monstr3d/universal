import type { IUrlObject } from "../IO/Interfaces/IUrlObject";

export class ImageTexture implements IUrlObject {

    constructor(url: string, directory: string) {
        this.url = url
        this.directory = directory
    }
    getObjectUrl(): string {
       return this.url
    }
    setObjecttUrl(url: string): void {
        this.url = url
    }


    url: string = "";

    directory: string = ""
}