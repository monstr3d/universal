export class EulerAngles {

    roll: number = 0;
    pitch: number = 0;
    yaw: number = 0;

    constructor(roll: number, pitch: number, yaw: number) {
        this.roll = roll;
        this.pitch = pitch
        this.yaw = yaw
    }

    getRoll(): number {
        return this.roll
    }

    getPitch(): number {
        return this.pitch
    }

    getYaw(): number {
        return this.yaw
    }

    setRoll(roll: number): void {
        this.roll = roll
    }

    setPitch(pitch: number): void {
        this.pitch = pitch
    }

    setYaw(yaw: number): void {
        this.yaw = yaw
    }
}
