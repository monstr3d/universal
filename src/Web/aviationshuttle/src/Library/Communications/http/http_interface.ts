import type { Performer } from '../../Performer';


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

export class HttpCommunication {
    constructor() {

    }

    public async http_cancel<RESB, REQB = undefined>(
        config: HttpRequest<REQB>, controller: AbortController,
    ): Promise<HttpResponse<RESB>>  {
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
        } else {
            await this.logError(request, response);
            return { ok: response.ok };
        }
    }
    public  async http<RESB, REQB = undefined>(
        config: HttpRequest<REQB>,
    ): Promise<HttpResponse<RESB>>{
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
        } else {
            await this.logError(request, response);
            return { ok: response.ok };
        }
    };

    async logError(request: Request, response: Response)
    {
        const contentType = response.headers.get('content-type');
        let body: unknown;
        if (contentType && contentType.indexOf('application/json') !== -1) {
            body = await response.json();
        } else {
            body = await response.text();
        }
        console.error(`Error requesting ${request.method} ${request.url}`, body);
    }

    public setPerformer(performer: Performer): void {
        this.performer = performer;
    }

    public getPerformer(): Performer
    {
        return this.performer;
    }


    public setCommunicationServer(s: string): void {
        this.server = s
    }

    protected server: string = ""

    protected performer !: Performer;

}
