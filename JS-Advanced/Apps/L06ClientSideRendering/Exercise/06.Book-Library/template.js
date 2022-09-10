import {html} from 'https://unpkg.com/lit-html?module';

const makeTable = (onClick, booksData) => {
    let bookTemplates;

    if (booksData) {
        bookTemplates = Object.entries(booksData || {}).map(([id, info]) => html`
            <tr id=${id}>
                <td>${info.title}</td>
                <td>${info.author}</td>
                <td>
                    <button>Edit</button>
                    <button>Delete</button>
                </td>
            </tr>
        `);
    }

    return html`
        <div @click=${onClick}>
            <button id="loadBooks">LOAD ALL BOOKS</button>
            <table>
                <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Action</th>
                </tr>
                </thead>
                <tbody>${bookTemplates}</tbody>
            </table>
        </div>
    `;
};

const makeAddForm = (onSubmit) => html`
    <form id="add-form" @submit=${onSubmit}>
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit">
    </form>
`;

const makeEditForm = (onEdit, id, title, author) => html`
    <form id="edit-form" @submit=${onEdit}>
        <input type="hidden" name="id" value=${id}>
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title..." value=${title}>
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author..." value=${author}>
        <input type="submit" value="Save">
    </form>
`;

export {
    makeTable,
    makeAddForm,
    makeEditForm,
};