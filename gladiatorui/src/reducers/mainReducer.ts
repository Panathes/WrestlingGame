import { MainActions } from "../actions/mainActions";
import { CreateBattleAction } from "../actions/battleActions";

export type MainState = {
    battleIds: string[];
}

export const initialState: MainState = {
    battleIds: []
}

export default (state: MainState = initialState, action : MainActions): MainState => {
    switch (action.type) {
        case 'BATTLE_CREATE': {
            const typedAction = action as CreateBattleAction;
            return Object.assign({}, state, {
                battleIds: [...state.battleIds, typedAction.battleId]
            } as MainState);
        }
        default: {
            return state;
        }
    }
}



 