export interface IQueue<T> {

    // Adds an element to the back of the queue
  enqueue(element: T): void

    // Removes and returns the element from the front of the queue
   dequeue(): T | undefined

    // Returns the element at the front of the queue without removing it
    peek(): T | undefined

    // Checks if the queue is empty
    isEmpty(): boolean

    // Returns the number of elements in the queue
    size(): number

    // Clears all elements from the queue
    clear(): void
}
