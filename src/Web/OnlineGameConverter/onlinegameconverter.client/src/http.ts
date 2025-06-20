import { webAPIUrl } from './AppSettings';

export interface HttpRequest<REQB> {
  path: string;
  method?: string;
  body?: REQB;
  accessToken?: string;
}
export interface HttpResponse<RESB> {
  ok: boolean;
  body?: RESB;
}

export const http = async <RESB, REQB = undefined>(
  config: HttpRequest<REQB>,
): Promise<HttpResponse<RESB>> => {
  const request = new Request(`${webAPIUrl}${config.path}`, {
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
  const response = await fetch(request);
  console.log('Response', response);
  console.log('Response BODY', response.body);

  if (response.ok) {
    const body = await response.json();
    return { ok: response.ok, body };
  } else {
    console.log('Response BAD', response);
    logError(request, response);
    return { ok: response.ok };
  }
};

const logError = async (request: Request, response: Response) => {
  const contentType = response.headers.get('content-type');
  let body: unknown;
  if (contentType && contentType.indexOf('application/json') !== -1) {
    body = await response.json();
  } else {
    body = await response.text();
  }
  console.error(`Error requesting ${request.method} ${request.url}`, body);
};
