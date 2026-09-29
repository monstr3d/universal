export interface IExceptionHandler {

    /// <summary>
    /// Handles an exception
    /// </summary>
    /// <typeparam name="T">Type of exception</typeparam>
    /// <param name="exception">The exception</param>
    handleException<T>(exception: T, obj: any[]): void

    /// <summary>
    /// Shows message
    /// </summary>
    /// <param name="message">The message to show</param>
    /// <param name="obj">Attached object</param>
    log(message: string, obj: any[]): void


}