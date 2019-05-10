import React from 'react';
import logo from './logo.svg';
import BattleList from "./components/BattleList";
import GameCreator from "./components/GameCreator";
import './App.css';

const App: React.FC = () => {
  return (
    <div className="App">
      <GameCreator />
      {/* <BattleList /> */}
    </div>
  );
}

export default App;
