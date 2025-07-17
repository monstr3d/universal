export class OwnError implements Error {
    constructor(name: string,
        message: string,
        stack?: string | undefined)
    {
        this.init();
        this.name = name;
        this.message = message;
        this.stack = stack;
    }
    name: string;
    message: string;
    stack?: string | undefined;

    init(): void
    {

    }
}