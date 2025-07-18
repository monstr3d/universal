export interface IAlias
{
    getAliasNames() : string[];


    getAliasType(name: string): any;

    getAliasVаlue(name: string): any;

    setAliasValue(name: string, value: any): any;

}