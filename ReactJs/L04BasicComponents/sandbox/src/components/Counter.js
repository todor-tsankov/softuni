import {Component} from 'react';

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {counter: 0};
    }

    plus(){
        this.setState(prev => ({counter: prev.counter + 1}));
    }

    minus(){
        this.setState(prev => ({counter: prev.counter - 1}));
    }

    render() {
        return (
            <div>
                <button onClick={this.minus.bind(this)}>Minus</button>
                <input value={this.state.counter} disabled={true}/>
                <button onClick={this.plus.bind(this)}>Plus</button>
            </div>
        );
    }
}

export default Counter;