/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
export interface IStateVariables
{
    getStateVariablesVectorVariables(): string[];

    getStateVariablesVector(): number;

    setStateVariablesVector(input: number[], offset: number, length: number): void;
}


