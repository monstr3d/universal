interface IAlias
{
    getNames() : string[];


    getType(name: string): any;

    getVelue(name: string): any;

    setVelue(name: string, value: any): any;


}