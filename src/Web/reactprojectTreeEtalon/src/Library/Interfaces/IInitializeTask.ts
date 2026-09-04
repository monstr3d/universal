export interface IInitializeTask {
     initializeTaskAsync(controller: AbortController): Promise<void>
}