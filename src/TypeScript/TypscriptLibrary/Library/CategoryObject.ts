class CategoryObject implements ICategoryObject
{
    GetName(): string {
        throw new Error("Method not implemented.");
    }
    obj: any;

    Get(): any {
        return this.obj;
    }
    Set(obj: any): void {
        this.obj = obj;
    }

}