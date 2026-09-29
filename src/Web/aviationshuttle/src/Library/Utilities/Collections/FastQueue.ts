import type { IArray } from "./Interfaces/IArray";
import type { IQueue } from "./Interfaces/IQueue";

export class FastQueue<T> implements IQueue<T>, IArray<T>{

    private items: T[] = [];
    protected head: number = 0;

    array(): T[] {
        return this.items;
    }


    // Adds an element to the back of the queue
    enqueue(element: T): void {
        this.items.push(element);
    }

    // Removes and returns the element from the front of the queue
    dequeue(): T | undefined {
        if (this.isEmpty()) {
            return undefined;
        }
        //    let a = this.items[0]
        this.items.shift()
      //  return a
        /*
        this.head++;

        // Optional: To prevent the array from growing indefinitely and consuming memory
        // if the queue is often cleared or very large and then becomes small.
        // This adds some overhead but can be beneficial for memory management.
        if (this.head * 2 > this.items.length) {
            this.items = this.items.slice(this.head);
            this.head = 0;
        }

        return element;*/
    }

    // Returns the element at the front of the queue without removing it
    peek(): T | undefined {
        if (this.isEmpty()) {
            return undefined;
        }
        return this.items[this.head];
    }

    // Checks if the queue is empty
    isEmpty(): boolean {
        return this.head >= this.items.length;
    }

    // Returns the number of elements in the queue
    size(): number {
        return this.items.length - this.head;
    }

    // Clears all elements from the queue
    clear(): void {
        this.items = [];
        this.head = 0;
    }

}