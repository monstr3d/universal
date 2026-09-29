export interface IExceptionHandler {
    handleException(error: Error, obj?: any): void
    log(message: string, obj?: any): void
}


