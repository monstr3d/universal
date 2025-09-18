/* eslint-disable @typescript-eslint/no-unused-vars */
export class OwnError implements Error {
    name: string = "";
    message: string = "";
    stack?: string | undefined;
    constructor(name: string, message: string, stack?: string | undefined) {
        this.name = name;
        this.message = message;
        this.stack = stack;
        this.init();
    }

    protected init() {

    }
}