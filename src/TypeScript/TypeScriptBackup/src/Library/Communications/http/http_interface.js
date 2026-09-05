"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.HttpCommunication = void 0;
class HttpCommunication {
    constructor() {
        this.server = "";
    }
    async http_cancel(config, controller) {
        const request = new Request(`${this.server}${config.path}`, {
            method: config.method || 'get',
            headers: {
                'Content-Type': 'application/json',
            },
            body: config.body ? JSON.stringify(config.body) : undefined,
        });
        if (config.accessToken) {
            request.headers.set('authorization', `bearer ${config.accessToken}`);
        }
        const signal = controller.signal;
        const response = await fetch(request, { signal });
        if (response.ok) {
            const body = await response.json();
            return { ok: response.ok, body };
        }
        else {
            await this.logError(request, response);
            return { ok: response.ok };
        }
    }
    async http(config) {
        const request = new Request(`${this.server}}${config.path}`, {
            method: config.method || 'get',
            headers: {
                'Content-Type': 'application/json',
            },
            body: config.body ? JSON.stringify(config.body) : undefined,
        });
        if (config.accessToken) {
            request.headers.set('authorization', `bearer ${config.accessToken}`);
        }
        const response = await fetch(request);
        if (response.ok) {
            const body = await response.json();
            return { ok: response.ok, body };
        }
        else {
            await this.logError(request, response);
            return { ok: response.ok };
        }
    }
    ;
    async logError(request, response) {
        const contentType = response.headers.get('content-type');
        let body;
        if (contentType && contentType.indexOf('application/json') !== -1) {
            body = await response.json();
        }
        else {
            body = await response.text();
        }
        console.error(`Error requesting ${request.method} ${request.url}`, body);
    }
    setPerformer(performer) {
        this.performer = performer;
    }
    getPerformer() {
        return this.performer;
    }
    setCommunicationServer(s) {
        this.server = s;
    }
}
exports.HttpCommunication = HttpCommunication;
//# sourceMappingURL=http_interface.js.map