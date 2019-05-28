import { MainActions } from "../actions/mainActions";
import { CreateBattleAction, ListingBattleAction } from "../actions/battleActions";
import { RegisterPlayerAction } from "../actions/playerActions";

export type MainState = {
    battleIds: string[];
}

export const initialState: MainState = {
    battleIds: [],
}

export default (state: MainState = initialState, action : MainActions): MainState => {
    switch (action.type) {
        case 'BATTLE_CREATE': {
            const typedAction = action as CreateBattleAction;
            return Object.assign({}, state, {
                battleIds: [...state.battleIds, typedAction.battleId]
            } as MainState);
        }
        case 'BATTLE_LIST': {
            const typedAction = action as ListingBattleAction;
            return Object.assign({}, state, {
                battleIds: typedAction.battleIds
            } as MainState)
        }
        case 'REGISTER_PLAYER': {
            const typedAction = action as RegisterPlayerAction;
        }
        default: {
            return state;
        }
    }
}



 