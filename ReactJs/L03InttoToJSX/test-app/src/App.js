import logo from './logo.svg';
import './App.css';
import React, { useState } from "react";

function App() {
    const [count, setCount] = useState(0);

    // Create handleIncrement event handler
    const handleIncrement = () => {
        setCount(prevCount => prevCount + 1);
    };

    //Create handleDecrement event handler
    const handleDecrement = () => {
        setCount(prevCount => prevCount - 1);
    };

    return (
        <div>
            <div>
                <button onClick={handleDecrement}>-</button>
                <h5>Count is {count}</h5>
                <button onClick={handleIncrement}>+</button>
            </div>
            <button onClick={() => setCount(0)}>Reset</button>
        </div>
    );
}

export default App;
