"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DBAccess = void 0;
class DBAccess {
    dbAccess;
    db;
    async connect(dbName, storeName) {
        if (this.db) {
            return this.db;
        }
        let attempts = 3;
        const request = indexedDB.open(dbName, 1);
        return new Promise((resolve, reject) => {
            request.onerror = error => {
                attempts--;
                if (attempts) {
                    return this.connect(dbName, storeName);
                }
                return reject(error);
            };
            request.onsuccess = () => {
                this.db = request.result;
                if (!this.db.objectStoreNames.contains(storeName)) {
                }
                resolve(this.db);
            };
            request.onupgradeneeded = () => {
                this.db = request.result;
                request.result.createObjectStore(storeName, { keyPath: 'uid' });
                resolve(this.db);
            };
        });
    }
    get instance() {
        return this.dbAccess ? this.dbAccess : this.dbAccess = new DBAccess();
    }
}
exports.DBAccess = DBAccess;
