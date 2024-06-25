export default class BaseApi {

    constructor(apiBase) {
        this.apiBase = apiBase;
        this._headerBase = {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8'
        }
    }

    getResource = async (url) => {
        const res = await fetch(`${this.apiBase}${url}`, {
            method: 'GET',
            headers: this._headerBase
        }) 

        return (res.status === 200) ? await res.json(): new Error(await res.text());
    }

    getResourceWithBody = async(url, body) => {
        const res = await fetch(`${this.apiBase}${url}`, {
            method: 'POST',
            headers: this._headerBase,
            body: body
        })

        return (res.status === 200) ? await res.text() : new Error(await res.text());
    }
}