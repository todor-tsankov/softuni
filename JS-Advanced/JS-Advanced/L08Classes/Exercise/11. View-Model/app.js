class Textbox {
    constructor(selector, regex) {
        this._value = '';
        this._invalidSymbols = regex;
        this._elements =  document.querySelectorAll(selector);

        this.elements.forEach(x => x.addEventListener('change', (e) => {
            this.value = e.target.value;
        }));
    }

    get value(){
        return this._value;
    }

    set value(value){
        this._value = value;
        this.elements.forEach(x => x.value = this.value);
    }

    get elements(){
        return this._elements;
    }

    isValid(){
        return this._invalidSymbols.test(this.value);
    }
}