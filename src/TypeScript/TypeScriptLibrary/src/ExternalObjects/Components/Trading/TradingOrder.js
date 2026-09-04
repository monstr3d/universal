"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TradingOrder = void 0;
const Measurement_1 = require("../../../Library/Measurements/Measurement");
const DataConsumer_1 = require("../../../Library/Measurements/DataConsumer");
class TradingOrder extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.types.push("IMeasurements");
        this.types.push("TradingOrder");
        this.typeName = "TradingOrder";
        this.output = [new PositionMeasurement(this),
            new IncomeMeasurement(this),
            new SellTaxMeasurement(this),
            new BuyTaxMeasurement(this)];
    }
    changed = false;
    isPost = false;
    currentPositionValue = undefined;
    isRunning = false;
    isMeaUpdated = false;
    income = 0;
    sellPrice = "";
    buyPrice = "";
    position = "";
    date = "";
    positionM;
    buyPriceM;
    sellPriceM;
    currentDate;
    output = [];
    mSellPrice = undefined;
    mBuyPrice = undefined;
    enterPrice = 0;
    exitPrice = 0;
    exitDate = 0;
    any;
    printer;
    getEnterPrice() {
        return this.enterPrice;
    }
    setEnterPrice(value) {
        this.enterPrice = value;
    }
    tempIncome = 0;
    getTempIncome() {
        return this.tempIncome;
    }
    setTempIncome(value) {
        this.tempIncome = value;
    }
    getExitPrice() {
        return this.exitPrice;
    }
    setExitPrice(value) {
        this.exitPrice = value;
    }
    getExitDate() {
        return this.exitDate;
    }
    setExitDate(value) {
        this.exitDate = value;
    }
    getCurrentPositionValue() {
        return 0;
    }
    getMeasurementsCount() {
        return this.output.length;
    }
    getMeasurement(i) {
        return this.output[i];
    }
    updateMeasurements() {
    }
    postSetArrow() {
        this.isPost = false;
        this.find();
    }
    find() {
        if (this.isPost) {
            return;
        }
        this.positionM = this.performer.getMeasurementDC(this, this.position);
        this.buyPriceM = this.performer.getMeasurementDC(this, this.buyPrice);
        this.sellPriceM = this.performer.getMeasurementDC(this, this.sellPrice);
        this.currentDate = this.performer.getMeasurementDC(this, this.date);
    }
}
exports.TradingOrder = TradingOrder;
class BasicMeasurement extends Measurement_1.Measurement {
    order;
    any;
    constructor(name, order, type) {
        super(name, type);
        this.order = order;
    }
    getAssociatedObject() {
        return this.order;
    }
    setAssociatedObject(obj) {
        this.any = obj;
    }
}
class PositionMeasurement extends BasicMeasurement {
    constructor(order) {
        super("Position", order, 0);
    }
    getMeasurementValue() {
        return this.order.getCurrentPositionValue();
    }
}
class IncomeMeasurement extends BasicMeasurement {
    constructor(order) {
        super("Income", order, 0);
    }
    getMeasurementValue() {
        return this.order.income;
    }
}
class BuyTaxMeasurement extends BasicMeasurement {
    constructor(order) {
        super("Buy Price", order, 0);
    }
    getMeasurementValue() {
        return this.order.mBuyPrice;
    }
}
class SellTaxMeasurement extends BasicMeasurement {
    constructor(order) {
        super("Sell Price", order, 0);
    }
    getMeasurementValue() {
        return this.order.mSellPrice;
    }
}
