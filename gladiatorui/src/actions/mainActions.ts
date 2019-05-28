import { AnyAction } from "redux";
import { CreateBattleAction, ListingBattleAction } from "./battleActions";
import { RegisterPlayerAction } from "../actions/playerActions";

export type MainActions = 
    CreateBattleAction |
    ListingBattleAction |
    RegisterPlayerAction
;