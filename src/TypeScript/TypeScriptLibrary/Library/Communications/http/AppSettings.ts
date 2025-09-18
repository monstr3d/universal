export const server = 'http://localhost:5218';

export const webAPIUrl = `${server}/api`;

export const authSettings = {
  domain: 'your-tenant-id.auth0.com',
  client_id: 'your-client-id',
  redirect_uri: window.location.origin + '/signin-callback',
  scope: 'openid profile QandAAPI email',
  audience: 'https://qanda',
};
