function encodeAndDecodeMessages() {
    const buttons = document.querySelectorAll('button');
    const textAreas = document.querySelectorAll('textarea');

    const sendArea = textAreas[0];
    const receiveArea = textAreas[1];

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encode(){
        receiveArea.value = code(sendArea.value, 1);;
        sendArea.value = '';
    }

    function decode(){
        receiveArea.value = code(receiveArea.value, -1);
    }

    function code(str, num){
        let newString = '';

        for(let x = 0; x < str.length; x++){
            newString += String.fromCharCode(str.charCodeAt(x) + num);
        }

        return newString;
    }
}