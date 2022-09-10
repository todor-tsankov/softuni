const endpoints = {
    register: 'http://localhost:3030/users/register',                               // (POST)
    login: 'http://localhost:3030/users/login',                                  // (POST)
    logout: 'http://localhost:3030/users/logout',                                  // (GET)
    create: 'http://localhost:3030/data/catalog',                                 //(POST)
    all: 'http://localhost:3030/data/catalog',                                 // (GET)
    details: 'http://localhost:3030/data/catalog/:id',                             // (GET)
    update: 'http://localhost:3030/data/catalog/:id',                             // (PUT)
    delete: 'http://localhost:3030/data/catalog/:id',                             // (DELETE)
    my: 'http://localhost:3030/data/catalog?where=_ownerId%3D%22{userId}%22', // (GET)
};

async function login(email, password) {
    const response = await fetch(endpoints.login, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password }),
    });

    const info = await response.json();

    if (response.ok) {
        sessionStorage.clear();
        sessionStorage.setItem('_id', info._id);
        sessionStorage.setItem('accessToken', info.accessToken);
    }

    return response.ok;
}

async function register(email, password) {
    const response = await fetch(endpoints.register, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password }),
    });

    const info = await response.json();

    if (response.ok) {
        sessionStorage.clear();
        sessionStorage.setItem('_id', info._id);
        sessionStorage.setItem('accessToken', info.accessToken);
    }

    return response.ok;
}

async function logout() {
    await fetch(endpoints.logout, {
        method: 'get',
        headers: { 'X-Authorization': sessionStorage.getItem('accessToken') },
    });

    sessionStorage.clear();
}

async function create(info) {
    const response = await fetch(endpoints.create, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('accessToken'),
        },
        body: JSON.stringify(info),
    });

    return response.ok;
}

async function all() {
    const response = await fetch(endpoints.all);
    return await response.json();
}

async function details(id) {
    const response = await fetch(endpoints.details.replace(':id', id));
    return await response.json();
}

async function update(id, info) {
    const response = await fetch(endpoints.update.replace(':id', id), {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('accessToken'),
        },
        body: JSON.stringify(info),
    });

    return response.ok;
}

async function del(id) {
    const response = await fetch(endpoints.delete.replace(':id', id), {
        method: 'delete',
        headers: { 'X-Authorization': sessionStorage.getItem('accessToken') },
    });

    return response.ok;
}

async function getMy() {
    const response = await fetch(endpoints.my.replace('{userId}', sessionStorage.getItem('_id')));
    return await response.json();
}

export default {
    login, register, logout, all, details, getMy, create, update, del,
};