import React from 'react';
import { BrowserRouter, Route } from "react-router-dom";
import './App.css';

import GameCreator from "./components/GameCreator";
import BattleList from "./components/BattleList";
import RegisterPlayer from "./components/RegisterPlayer";
import Fight from "./components/Fight";
import PlayerAction from "./components/PlayerAction";
import NavBar from "./components/NavBar";

const App: React.FC = () => {
  return (
    <BrowserRouter>
        <NavBar />
        <Route path="/" component={GameCreator} exact />
        <Route path="/list" component={BattleList} />
        <Route path="/:id/register" component={RegisterPlayer} />
        <Route path="/:id/:playerId/action" component={PlayerAction} />
        {/* <Route path="/:id/fight" component={Fight} /> */}
    </BrowserRouter>
  );
}

export default App;

      // <GameCreator />
      // <BattleList />
