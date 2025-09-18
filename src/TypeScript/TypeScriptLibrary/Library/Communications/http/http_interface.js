"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.http = exports.http_cancel = void 0;
const AppSettings_1 = require("./AppSettings");
const http_cancel = (config, controller) => __awaiter(void 0, void 0, void 0, function* () {
    const request = new Request(`${AppSettings_1.webAPIUrl}${config.path}`, {
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
    // console.log('Config', config);
    console.log('Request', request);
    // console.log('Request BODY', request.body);
    const response = yield fetch(request, { signal });
    console.log('Response', response);
    console.log('Response BODY', response.body);
    if (response.ok) {
        const body = yield response.json();
        return { ok: response.ok, body };
    }
    else {
        console.log('Response BAD', response);
        logError(request, response);
        return { ok: response.ok };
    }
});
exports.http_cancel = http_cancel;
const http = (config) => __awaiter(void 0, void 0, void 0, function* () {
    const request = new Request(`${AppSettings_1.webAPIUrl}${config.path}`, {
        method: config.method || 'get',
        headers: {
            'Content-Type': 'application/json',
        },
        body: config.body ? JSON.stringify(config.body) : undefined,
    });
    if (config.accessToken) {
        request.headers.set('authorization', `bearer ${config.accessToken}`);
    }
    // console.log('Config', config);
    console.log('Request', request);
    // console.log('Request BODY', request.body);
    const response = yield fetch(request);
    console.log('Response', response);
    console.log('Response BODY', response.body);
    if (response.ok) {
        const body = yield response.json();
        return { ok: response.ok, body };
    }
    else {
        console.log('Response BAD', response);
        logError(request, response);
        return { ok: response.ok };
    }
});
exports.http = http;
const logError = (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const contentType = response.headers.get('content-type');
    let body;
    if (contentType && contentType.indexOf('application/json') !== -1) {
        body = yield response.json();
    }
    else {
        body = yield response.text();
    }
    console.error(`Error requesting ${request.method} ${request.url}`, body);
});
//# sourceMappingURL=http_interface.js.map