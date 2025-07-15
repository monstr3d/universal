interface ICategoryArrow
{
    getSource(): ICategoryObject; 

    getTagret(): ICategoryObject;

    setSource(source: ICategoryObject): void;

    setTarget(target: ICategoryObject): void;

}