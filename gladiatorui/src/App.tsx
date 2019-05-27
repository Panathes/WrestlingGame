import React from 'react';
import { BrowserRouter, Route, Switch } from "react-router-dom";
import './App.css';

import GameCreatorPage from "./pages/CreateBattlePage";
import BattleListPage from "./pages/BattleList";
import RegisterPlayerPage from "./pages/RegisterPlayer";
import Fight from "./pages/Fight";
import PlayerAction from "./pages/PlayerAction";
import EndGamePage from "./pages/EndGame";
import NavBar from "./components/NavBar";

const App = () => {
  return (
    <Switch>
        <Route path="/" component={GameCreatorPage} exact />
        <Route path="/list" component={BattleListPage} />
        <Route path="/:id/register" component={RegisterPlayerPage} />
        <Route path="/:id/:playerId/action" component={PlayerAction} />
        <Route path="/:id/endgame" component={EndGamePage} />
        {/* <Route path="/:id/fight" component={Fight} /> */}
    </Switch>
  );
}

export default App;

      // <GameCreator />
      // <BattleList />
