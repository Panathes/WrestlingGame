import { AnyAction } from "redux";
import { CreateBattleAction, ListingBattleAction } from "./battleActions";
import { RegisterPlayerAction, PlayerListAction, HandleBattleAction, HandleErrorAction } from "../actions/playerActions";
import { EndGameAction } from "./endGameActions";

export type MainActions = 
    CreateBattleAction |
    ListingBattleAction |
    RegisterPlayerAction |
    PlayerListAction |
    HandleBattleAction |
    HandleErrorAction |
    EndGameAction
;