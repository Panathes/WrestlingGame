import React from 'react';
import { BrowserRouter, Route } from "react-router-dom";
import './App.css';

import GameCreatorPage from "./pages/GameCreator";
import BattleListPage from "./pages/BattleList";
import RegisterPlayerPage from "./pages/RegisterPlayer";
import Fight from "./pages/Fight";
import PlayerActionPage from "./pages/PlayerAction";
import EndGamePage from "./pages/EndGame";
import NavBar from "./components/NavBar";

const App: React.FC = () => {
  return (
    <BrowserRouter>
        <NavBar />
        <Route path="/" component={GameCreatorPage} exact />
        <Route path="/list" component={BattleListPage} />
        <Route path="/:id/register" component={RegisterPlayerPage} />
        <Route path="/:id/:playerId/action" component={PlayerActionPage} />
        <Route path="/:id/endgame" component={EndGamePage} />
        {/* <Route path="/:id/fight" component={Fight} /> */}
    </BrowserRouter>
  );
}

export default App;

      // <GameCreator />
      // <BattleList />
