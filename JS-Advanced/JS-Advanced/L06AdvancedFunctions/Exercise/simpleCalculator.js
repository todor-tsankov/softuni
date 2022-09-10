function solve() {
    return {
        first: null,
        second: null,
        result: null,
        init(selector1, selector2, resultSelector) {
            this.first = document.querySelector(selector1);
            this.second = document.querySelector(selector2);
            this.result = document.querySelector(resultSelector);
        },
        add() {
            this.result.value = Number(this.first.value) + Number(this.second.value);
        },
        subtract() {
            this.result.value = Number(this.first.value) - Number(this.second.value);
        }
    };
}