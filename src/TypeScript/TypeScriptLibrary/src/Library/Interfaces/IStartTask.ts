export interface IStartTask {
    startAsync(controller : AbortController) : Promise<void>
}