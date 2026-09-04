
export interface IAccelerationData {
    getAccelerationX(): number;
    getAccelerationY(): number;
    getAccelerationZ(): number;
    copytAccelerationData(data: IAccelerationData): void

}