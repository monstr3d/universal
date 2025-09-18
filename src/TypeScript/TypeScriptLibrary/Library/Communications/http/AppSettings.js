"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.authSettings = exports.webAPIUrl = exports.server = void 0;
exports.server = 'http://localhost:5218';
exports.webAPIUrl = `${exports.server}/api`;
exports.authSettings = {
    domain: 'your-tenant-id.auth0.com',
    client_id: 'your-client-id',
    redirect_uri: window.location.origin + '/signin-callback',
    scope: 'openid profile QandAAPI email',
    audience: 'https://qanda',
};
//# sourceMappingURL=AppSettings.js.map