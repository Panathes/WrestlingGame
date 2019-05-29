import { AnyAction } from "redux";
import { CreateBattleAction, ListingBattleAction } from "./battleActions";
import { RegisterPlayerAction, PlayerListAction, HandleBattleAction, HandleError } from "../actions/playerActions";

export type MainActions = 
    CreateBattleAction |
    ListingBattleAction |
    RegisterPlayerAction |
    PlayerListAction |
    HandleBattleAction |
    HandleError
;