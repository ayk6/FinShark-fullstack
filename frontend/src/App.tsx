import React from 'react';
import logo from './logo.svg';
import './App.css';
import Card from './Components/Card/Card';

function App() {
  return (
    <div className="App">
      <Card companyName='Tesla' ticker='TSLA' price={150} />
    </div>
  );
}

export default App;
