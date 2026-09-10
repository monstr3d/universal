export class Coord {
    x: number = 0
    y: number = 0
    z: number = 0
    constructor() {
    }


    setCoord(x: number, y: number, z: number): void {
        this.x = x
        this.y = y
        this.z = z

    }

}

let coord: Coord = new Coord

export const getCoord = (): Coord => { return coord }
