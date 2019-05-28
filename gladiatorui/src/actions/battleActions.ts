import { AnyAction, Action } from "redux";
import { AppThunkAction } from "../store";
import { MainActions } from "./mainActions";
import { ClientApiUrl } from "..";
import { push } from "connected-react-router";

const name = 'BATTLE';

export interface CreateBattleAction extends Action<'BATTLE_CREATE'> {
    battleId: string;
}

export interface ListingBattleAction extends Action<'BATTLE_LIST'> {
    battleIds: string[];
}

export const CreateBattle = (): AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + '/api/battle/', {
        method: 'POST'
    })
    .then(response => response.json())
    .then((response: string) => {
        const createBattleAction: CreateBattleAction = {
            type: 'BATTLE_CREATE',
            battleId: response
        };
        dispatch(createBattleAction);
        dispatch(push('/list'));
    });  
    
}

export const ListingBattle = (): AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {  
    return fetch(ClientApiUrl + '/api/battle/list')
    .then(response => response.json())
    .then((response: string[]) => {
        const battleListing: ListingBattleAction = {
            type: 'BATTLE_LIST',
            battleIds: response
        }
        dispatch(battleListing);
    }); 
    
}
