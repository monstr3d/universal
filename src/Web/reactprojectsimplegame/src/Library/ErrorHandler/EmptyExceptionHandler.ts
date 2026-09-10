import type { IExceptionHandler } from "../Interfaces/IExceptionHandler";

export class EmptyExceptionHandler implements IExceptionHandler {
    handleException<T>(exception: T, obj: any[]): void {
        this.any = exception;
        this.any = obj
        console.log("EXCEPTION", exception)
    }
    log(message: string, obj: any[]): void {
        this.any = message
        this.any = obj
    }

    any : any

}