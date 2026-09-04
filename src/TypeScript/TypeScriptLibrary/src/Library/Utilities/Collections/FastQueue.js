"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FastQueue = void 0;
class FastQueue {
    items = [];
    head = 0;
    array() {
        return this.items;
    }
    // Adds an element to the back of the queue
    enqueue(element) {
        this.items.push(element);
    }
    // Removes and returns the element from the front of the queue
    dequeue() {
        if (this.isEmpty()) {
            return undefined;
        }
        //    let a = this.items[0]
        this.items.shift();
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
    peek() {
        if (this.isEmpty()) {
            return undefined;
        }
        return this.items[this.head];
    }
    // Checks if the queue is empty
    isEmpty() {
        return this.head >= this.items.length;
    }
    // Returns the number of elements in the queue
    size() {
        return this.items.length - this.head;
    }
    // Clears all elements from the queue
    clear() {
        this.items = [];
        this.head = 0;
    }
}
exports.FastQueue = FastQueue;
