/* eslint-disable @typescript-eslint/no-unused-vars */
export class OwnError implements Error {
    name: string = "";
    message: string = "";
    stack?: string | undefined;
    constructor(name: string | undefined, message: string, stack?: string | undefined) {
        if (name != undefined) this.name = name;
        this.message = message;
        this.stack = stack;
        this.init();
    }

    protected init() {

    }
}