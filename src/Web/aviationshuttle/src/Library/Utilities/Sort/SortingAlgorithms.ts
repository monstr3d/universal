import type { IComparator } from "./Interfaces/IComparator";

export class SortingAlgorithms {


    constructor() {

    }

    public mergesort<T>(unsorted: T[], comparator: IComparator<T>) {
        if (unsorted.length <= 1) {
            return unsorted;
        }
        var left: T[] = [];
        var right: T[] = [];
        var middle = Math.floor(unsorted.length / 2);
        for (var i = 0; i < middle; i++)  //Dividing the unsorted list
        {
            left.push(unsorted[i]);
        }
        for (var j = middle; j < unsorted.length; j++) {
            right.push(unsorted[j]);
        }
        left = this.mergesort(left, comparator);
        right = this.mergesort(right, comparator);
        let result = this.merge(left, right, comparator);
        return result;
    }

    protected merge<T>(left: T[], right: T[], comparator: IComparator<T>): T[] {
        var result: T[] = [];
        while (left.length > 0 || right.length > 0) {
            if (left.length > 0 && right.length > 0) {
                if (comparator.compare(left[0], right[0]) <= 0)  //Comparing First two elements to see which is smaller
                {
                    result.push(left[0]);
                    left.shift();
                    //Rest of the list minus the first element
                }
                else {
                    result.push(right[0]);
                    right.shift();
                }
            }
            else if (left.length > 0) {
                result.push(left[0]);
                left.shift();
            }
            else if (right.length > 0) {
                result.push(right[0]);
                right.shift();
            }
        }
        return result;
    }

}