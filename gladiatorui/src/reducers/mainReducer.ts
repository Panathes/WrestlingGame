import { MainActions } from "../actions/mainActions";
import { CreateBattleAction, ListingBattleAction } from "../actions/battleActions";
import { RegisterPlayerAction, Gladiator, GameInfo, PlayerInfo, Error, PlayerListAction, HandleBattleAction, HandleError } from "../actions/playerActions";

export type MainState = {
    battleIds: string[];

    playerId: string;

    players: Gladiator[];
    playerInfo: PlayerInfo;
    playerInfos: PlayerInfo[];
    gameInfos: GameInfo;
    error: Error;
}

export const initialState: MainState = {
    battleIds: [],

    playerId: ' ',
    
    players: [],

    playerInfo : {
        playerId: " ",
        name: " ",
        pv: 100,
        stamina: 100
    }, 

    playerInfos: [],

    gameInfos: {
        gladiators: [],
        isBattleFinish: false,
        winner: " ",
    },

    error: {
        hasError: false,
        message: ''
    }
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
            return Object.assign({}, state, {
                playerId: typedAction.playerId
            } as MainState)
        }
        case 'PLAYER_LIST': {
            const typedAction = action as PlayerListAction;
            return Object.assign({}, state, {
                players: typedAction.players
            } as MainState)
        }
        case 'HANDLE_BATTLE': {
            const typedAction = action as HandleBattleAction;
            return Object.assign({}, state, {
                gameInfos: typedAction.gameInfos
            } as MainState)
        }
        case 'HANDLE_ERROR': {
            const typedAction = action as HandleError; 
            return Object.assign({}, state, {
                error: typedAction.error
            })
        }
        default: {
            return state;
        }
    }
}



 