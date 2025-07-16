

class CategoryArrow implements ICategoryArrow
{
    GetName(): string {
        throw new Error("Method not implemented.");
    }

    source!: ICategoryObject;

    target!: ICategoryObject;

    getSource(): ICategoryObject {
        return this.source;
    }
    getTagret(): ICategoryObject {
        return this.target;
    }
    setSource(source: ICategoryObject): void {
        this.source = source;
    }
    setTarget(target: ICategoryObject): void {
        this.target = target;
    }

}