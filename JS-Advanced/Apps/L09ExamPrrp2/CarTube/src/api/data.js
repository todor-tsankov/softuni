import * as api from './api.js';


const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function all(){
    return await api.get(host);
}

export async function details(id){
    return await api.get(host);
}

export async function create(){
    await api.post(host);
}

export async function edit(){
    await api.put(host);
}

export async function del(id){
    return await api.del(host);
}
