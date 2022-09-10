const {chromium} = require('playwright-chromium');
const {expect} = require('chai');

let browser;
let page;

const host = 'http://localhost:3000/';
const messagesUrl = '**/jsonstore/messenger';

const testData = {
    1: {
        author: 'a1',
        content: 'c1'
    },
    2: {
        author: 'a2',
        content: 'c2'
    },
    3: {
        author: 'a3',
        content: 'c3'
    }
};

describe('messenger tests', function () {
    this.timeout(0); // Otherwise throws Error because the test time exceeds 2000ms

    before(async () => {
        browser = await chromium.launch();
        //browser = await chromium.launch({headless: false, slowMo: 500});
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

        expect(await page.isVisible('textarea'));
        expect(await page.isVisible('text="Send"'));
        expect(await page.isVisible('text="Refresh"'));
    });

    it('loads the messages when clicking refresh btn', async () => {
        await page.route(messagesUrl, route => route.fulfill(json(testData)));
        await page.goto(host);
        await page.click('text="Refresh"');

        expect(await page.$eval('textarea', el => el.value)).to.equal(`a1: c1\na2: c2\na3: c3`);
    });

    it('sends the correct data on submit', async () => {
        await page.goto(host);

        await page.fill('#author', testData['1'].author);
        await page.fill('#content', testData['1'].content);

        const [request] = await Promise.all([
            page.waitForRequest(messagesUrl),
            page.click('text="Send"'),
        ]);

        const postData = JSON.parse(request.postData());

        expect(postData.author === testData['1'].author);
        expect(postData.content === testData['1'].content);
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
