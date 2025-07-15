class CategoryObject implements ICategoryObject
{
    obj: any;

    Get(): any {
        return this.obj;
    }
    Set(obj: any): void {
        this.obj = obj;
    }

}