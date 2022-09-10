import {Component} from 'react';

class Dog extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
          <div>"{this.props.name}" => uaf uaf</div>
        );
    }
}

export default Dog;