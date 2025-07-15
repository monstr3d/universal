

class CategoryArrow implements ICategoryArrow
{

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