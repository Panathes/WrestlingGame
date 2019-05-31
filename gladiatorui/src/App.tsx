import React from 'react';
import { BrowserRouter, Route, Switch } from "react-router-dom";
import './App.css';

import GameCreatorPage from "./pages/CreateBattlePage";
import BattleListPage from "./pages/BattleListPage";
import RegisterPlayerPage from "./pages/RegisterPlayerPage";
import PlayerActionPage from "./pages/PlayerActionPage";
import EndGamePage from "./pages/EndGamePage";
import NavBar from "./components/NavBar";

const App = () => {
  return (
    <>
    <NavBar/>
      <Switch>
          <Route path="/" component={GameCreatorPage} exact />
          <Route path="/list" component={BattleListPage} />
          <Route path="/:id/register" component={RegisterPlayerPage} />
          <Route path="/:id/action" component={PlayerActionPage} />
          <Route path="/:id/endgame" component={EndGamePage} />
      </Switch>
    </>
  );
}

export default App;

      // <GameCreator />
      // <BattleList />
