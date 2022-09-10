function solve() {
    const lectureName = document.querySelector('body > main > section.admin-view.section-view > div > div > form > div:nth-child(1) > input[type=text]');
    const date = document.querySelector('body > main > section.admin-view.section-view > div > div > form > div:nth-child(2) > input[type=datetime-local]');
    const select = document.querySelector('body > main > section.admin-view.section-view > div > div > form > div:nth-child(3) > select');
    const addBtn = document.querySelector('body > main > section.admin-view.section-view > div > div > form > div:nth-child(4) > button');

    const modulesDiv = document.querySelector('body > main > section.user-view.section-view > div');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (lectureName.value === '' || date.value === '' || select.value === 'Select module') {
            return;
        }

        let moduleDiv;

        for(let module of modulesDiv.querySelectorAll('.module')){
            if( module.querySelector('h3').textContent === select.value.toUpperCase() + '-MODULE'){
                moduleDiv = module;
            }
        }

        if(moduleDiv === undefined){
            moduleDiv = document.createElement('div');
            moduleDiv.className = 'module';

            let headingInModule = document.createElement('h3');
            headingInModule.textContent = select.value.toUpperCase() + '-MODULE';

            let ul = document.createElement('ul');

            moduleDiv.appendChild((headingInModule));
            moduleDiv.appendChild(ul);

            modulesDiv.appendChild(moduleDiv);
        }

        let lecture = document.createElement('li');
        lecture.className = 'flex';
        let headingInLi = document.createElement('h4');

        let datePrs = Date.parse(date.value);
        let newDate = new Date(datePrs);

        headingInLi.textContent = lectureName.value + ' - ' +  `${newDate.getFullYear()}/${(newDate.getMonth() + 1).toString().padStart(2, '0')}/${newDate.getDate().toString().padStart(2, '0')} - ${newDate.getHours().toString().padStart(2, '0')}:${newDate.getMinutes().toString().padStart(2, '0')}`;
        lecture.appendChild(headingInLi);

        let delBtn = document.createElement('button');
        delBtn.textContent = 'Del';
        delBtn.className = 'red';

        lecture.appendChild(delBtn);
        moduleDiv.querySelector('ul').appendChild(lecture);

        let lectures = Array.from(moduleDiv.querySelectorAll('li')).sort((a, b) => a.querySelector('h4').textContent.split(' - ')[1].localeCompare(b.querySelector('h4').textContent.split(' - ')[1]));
        lectures.forEach(x => moduleDiv.querySelector('ul').appendChild(x));

        delBtn.addEventListener('click', () => {
            lecture.remove();

            if(moduleDiv.querySelectorAll('li').length === 0){
                moduleDiv.remove();
            }
        });

        lectureName.value = '';
        date.value = '';
        select.value = 'Select module';
    });
};