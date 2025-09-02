export interface IAlias
{
    getAliasNames() : string[];


    getAliasType(name: string): any;

    getAliasValue(name: string): any;

    setAliasValue(name: string, value: any): void;

}