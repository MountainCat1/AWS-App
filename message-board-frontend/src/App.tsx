import React from 'react';
import logo from './logo.svg';
import './App.css';
import {useGetMessages} from "./services/board";

function App() {
  const getMessages = useGetMessages();

  getMessages().then(x => {
    console.log(x)
  })

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <p>var - {process.env.REACT_APP_API_URL}</p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
