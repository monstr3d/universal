"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyRealtimeCollection = void 0;
class EmptyRealtimeCollection {
    setComponentCollection(collection) {
        this.collection = collection;
    }
    getComponentCollection() {
        throw new Error("Method not implemented.");
    }
    isComponentCollectionRunning() {
        throw new Error("Method not implemented.");
    }
    setComponentCollectionRunning(running) {
        this.running = running;
    }
    setTimerFactory(timerFactory) {
        this.timerFactory = timerFactory;
    }
    setTimeProvider(timeProvider) {
        this.timeProvider = timeProvider;
    }
    timeProvider;
    timerFactory;
    running = false;
    collection;
}
exports.EmptyRealtimeCollection = EmptyRealtimeCollection;
