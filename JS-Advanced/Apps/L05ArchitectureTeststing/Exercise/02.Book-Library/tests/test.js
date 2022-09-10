const {chromium} = require('playwright-chromium');
const {expect} = require('chai');

let browser;
let page;

const host = 'http://localhost:3000/';
const booksUrl = '**/jsonstore/collections/books';

const testData = {
    0: {
        title: 'title 1',
        author: 'author 1',
    },
    1: {
        title: 'title 2',
        author: 'author 2',
    },
    2: {
        title: 'title 3',
        author: 'author 3',
    },
};

describe('book library tests', function () {
    this.timeout(0); // Otherwise throws Error because the test time exceeds 2000ms

    before(async () => {
        //browser = await chromium.launch({headless: false, slowMo: 500});
        browser = await chromium.launch();
    });
    after(async () => {
        await browser.close();
    });
    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });

    it('loads a static page', async () => {
        await page.goto(host);

        expect(await page.isVisible('#createForm')).to.be.true;
        expect(await page.isVisible('#editForm')).to.be.false;

        expect(await page.isVisible('text="Submit"')).to.be.true;
        expect(await page.isVisible('text="LOAD ALL BOOKS"')).to.be.true;

        expect(await page.$eval('tbody', el => el.innerHTML.trim())).to.equal('');
    });

    it('loads correctly the books when load books btn is clicked', async () => {
        await page.route(booksUrl, route => route.fulfill(json(testData)));

        await page.goto(host);
        await page.click('text="LOAD ALL BOOKS"');

        const rows = await page.$$eval('tbody tr', rows => rows.map(x => ({
            id: x.getAttribute('data-id'),
            title: x.children[0].textContent,
            author: x.children[1].textContent,
            buttons: [...x.querySelectorAll('button')].map(x => x.textContent),
        })));

        for (let x = 0; x < rows.length; x++) {
            expect(rows[x].id).to.equal(x.toString());

            expect(rows[x].title).to.equal(testData[x].title);
            expect(rows[x].author).to.equal(testData[x].author);

            expect(rows[x].buttons[0]).to.equal('Edit');
            expect(rows[x].buttons[1]).to.equal('Delete');
        }
    });

    it('sends the correct request when adding a book', async () => {
        await page.goto(host);

        await page.fill('#title-input', testData[0].title);
        await page.fill('#author-input', testData[0].author);

        const [request] = await Promise.all([
            page.waitForRequest(booksUrl),
            page.click('text="Submit"'),
        ]);

        const postData = JSON.parse(request.postData());

        expect(request.method()).to.equal('POST');
        expect(postData.title).to.equal(testData[0].title);
        expect(postData.author).to.equal(testData[0].author);
    });

    it('does not send anything if the input fields are empty', async () => {
        await page.goto(host);

        await page.fill('#title-input', '');
        await page.fill('#author-input', testData[0].author);

        expect(async () => {
            await Promise.all([

                page.waitForRequest(booksUrl, {timeout: 10000}),
                page.click('text="Submit"'),
            ]);
        }).to.throw;

        await page.fill('#title-input', testData[0].title);
        await page.fill('#author-input', '');

        expect(async () => {
            await Promise.all([
                page.waitForRequest(booksUrl, {timeout: 1000}),
                page.click('text="Submit"'),
            ]);
        }).to.throw;
    });

    it('loads the book for editing in the correct form', async () => {
        await page.route(booksUrl, route => route.fulfill(json(testData)));
        await page.route(booksUrl + '/0', route => route.fulfill(json(testData[0])));

        await page.goto(host);
        await page.click('text="LOAD ALL BOOKS"');
        await page.click('text="Edit"');

        expect(await page.isVisible('#createForm')).to.be.false;
        expect(await page.isVisible('#editForm')).to.be.true;

        expect(await page.$eval('#title-edit', x => x.value)).to.equal(testData[0].title);
        expect(await page.$eval('#author-edit', x => x.value)).to.equal(testData[0].author);
    });

    it('sends the correct data on edit', async () => {
        await page.route(booksUrl, route => route.fulfill(json(testData)));
        await page.route(booksUrl + '/0', route => route.fulfill(json(testData[0])));

        await page.goto(host);
        await page.click('text="LOAD ALL BOOKS"');
        await page.click('text="Edit"');

        await page.fill('#title-edit', testData[1].title);
        await page.fill('#author-edit', testData[1].author);

        const [request] = await Promise.all([
            page.waitForRequest(booksUrl + '/0'),
            page.click('text="Save"'),
        ]);

        const putData = JSON.parse(request.postData());

        expect(request.method()).to.equal('PUT');
        expect(putData.title).to.equal(testData[1].title);
        expect(putData.author).to.equal(testData[1].author);
    });

    it('does not send on edit if fields are empty', async () => {
        await page.route(booksUrl, route => route.fulfill(json(testData)));
        await page.route(booksUrl + '/0', route => route.fulfill(json(testData[0])));

        await page.goto(host);
        await page.click('text="LOAD ALL BOOKS"');
        await page.click('text="Edit"');

        await page.fill('#title-edit', '');

        expect(async () => {
            await Promise.all([
                page.waitForRequest(booksUrl + '/0', {timeout: 1000}),
                page.click('text="Save"'),
            ]);
        }).to.throw;

        await page.fill('#title-edit', '123');
        await page.fill('#author-edit', '');

        expect(async () => {
            await Promise.all([
                page.waitForRequest(booksUrl + '/0', {timeout: 1000}),
                page.click('text="Save"'),
            ]);
        }).to.throw;
    });

    it('sends the correct request on delete', async () => {
        await page.route(booksUrl, route => route.fulfill(json(testData)));
        page.on('dialog', dialog => dialog.accept());

        await page.goto(host);
        await page.click('text="LOAD ALL BOOKS"');

        const [request] = await Promise.all([
            page.waitForRequest(booksUrl + '/1', {timeout: 1000}),
            page.click(':nth-match(:text("Delete"), 2)')
        ]);

        expect(request.method()).to.equal('DELETE');
    });

    it('does not send if the dialog is dismissed', async () => {
        await page.route(booksUrl, route => route.fulfill(json(testData)));
        await page.goto(host);
        await page.click('text="LOAD ALL BOOKS"');

        expect(async() => {
            const [request] = await Promise.all([
                page.waitForRequest(booksUrl + '/1', {timeout: 1000}),
                page.click(':nth-match(:text("Delete"), 2)')
            ]);
        }).to.throw;
    });
});

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}
