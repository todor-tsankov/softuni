import page from '../node_modules/page/page.mjs';

import index from './index.js';
import myFurniture from './myFurniture.js';
import details from './details.js';

import create from './create.js';
import del from './delete.js'
import edit from './edit.js';

import login from './login.js';
import register from './register.js';
import logout from './logout.js';

const userLinksDiv = document.getElementById('user');
const guestLinksDiv = document.getElementById('guest');

page('/', wrapper(() => page.redirect('/index')));

page('/index', wrapper(index));
page('/my-furniture', wrapper(myFurniture));
page('/details/:id', wrapper(details));

page('/create', wrapper(create));
page('/delete/:id', wrapper(del));
page('/edit/:id', wrapper(edit));

page('/login',  wrapper(login));
page('/register', wrapper(register));
page('/logout', wrapper(logout));

page.start();

function wrapper(func){
    return async(context) => {
        document.getElementById('indexLink').classList.remove('active');
        [...userLinksDiv.children].forEach(x => x.classList.remove('active'));
        [...guestLinksDiv.children].forEach(x => x.classList.remove('active'));

        try{
            const linkId = context.pathname.slice(1) + 'Link';
            document.getElementById(linkId).classList.add('active');
        } catch { }

        await func(context);

        if(sessionStorage.getItem('accessToken')){
            userLinksDiv.style.display = 'inline';
            guestLinksDiv.style.display = 'none';
        } else{
            userLinksDiv.style.display = 'none';
            guestLinksDiv.style.display = 'inline';
        }
    };
}
