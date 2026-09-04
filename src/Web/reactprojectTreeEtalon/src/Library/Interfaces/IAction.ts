export interface IAction {
    action(): void;
    isEmptyAction(): boolean
}