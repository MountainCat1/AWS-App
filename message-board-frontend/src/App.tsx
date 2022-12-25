import React from 'react';
import './App.css';
import MessageList from "./components/MessageList/MessageList";

function App() {

  return (
    <div className="App">


      <header className="App-header">
        <div><MessageList/></div>
      {/*  <div>var - {process.env.REACT_APP_API_URL}</div>*/}

        {/*<img src={logo} className="App-logo" alt="logo" />
        <div>
          Edit <code>src/App.tsx</code> and save to reload.
        </div>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>*/}
      </header>
    </div>
  );
}

export default App;
