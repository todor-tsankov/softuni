(function () {
    String.prototype.ensureStart = function (str) {
        if (this.startsWith(str)) {
            return String(this);
        }

        return str + String(this);
    };

    String.prototype.ensureEnd = function (str) {
        if (this.endsWith(str)) {
            return String(this);
        }

        return String(this) + str;
    };

    String.prototype.isEmpty = function () {
        return this.length === 0;
    }

    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return String(this);
        }

        let newString = '';
        const words = this.split(' ');

        if (words.length < 2) {
            if (n >= 4) {
                newString = words[0].slice(0, n - 3) + '...';
            } else {
                newString = '.'.repeat(n);
            }
        } else {
            for (let word of words) {
                if (newString.length + word.length + 3 > n) {
                    break;
                }

                newString += word + ' ';
            }

            newString = newString.trim() + '...';
        }

        return newString;
    };

    String.format = function (string, ...params) {
        let newString = string;

        for (let x = 0; x < params.length; x++) {
            newString = newString.replace(`{${x}}`, params[x]);
        }

        return newString;
    };
}());

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');
