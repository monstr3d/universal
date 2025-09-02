export interface IStateVariables
{
    getStateVariablesVectorVariables(): string[];

    getStateVariablesVector(): number;

    setStateVariablesVector(input: number[], offset: number, length: number): void;
}


