import { CategoryArrow } from "../../CategoryArrow";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IIterator } from "../Interfaces/IIterator";
import type { IIteratorConsumer } from "../Interfaces/IIteratorConsumer";

export class IteratorConsumerLink extends CategoryArrow {

    iterator !: IIterator;

    consumer !:  IIteratorConsumer;

    setSource(source: ICategoryObject): void{
        super.setSource(source);
        this.consumer = source as unknown as IIteratorConsumer;
    }

    /**
     * @param target
     */
    setTarget(target: ICategoryObject) {
        super.setTarget(target);
        this.iterator = target as unknown as IIterator;
        this.consumer.addIterator(this.iterator);
    }

}
