import './App.css';
import Person from './components/Person.js';
import Dog from './components/Dog.js';
import Counter from './components/Counter.js';
import Ascents from './components/Ascents.js';

function App() {
    return (
        <div className="App">
            <Person name={'Toshko'}/>
            <Dog name={'Andi'}/>
            <Counter/>
            <Ascents/>
        </div>
    );
}

export default App;
