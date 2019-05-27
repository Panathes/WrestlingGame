import { AnyAction } from "redux";
import { AppThunkAction } from "../store";
import { MainActions } from "./mainActions";
import { ClientApiUrl } from "..";
import { push } from "react-router-redux";

export interface CreateBattleAction {
    type: 'BATTLE_CREATE';
    battleId: string;
}


export const CreateBattle = (): AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + '/api/battle/', {
        method: 'POST'
    })
    .then(response => response.json())
    .then((response: string) => {
        const toto: CreateBattleAction = {
            type: 'BATTLE_CREATE',
            battleId: response
        };
        dispatch(toto);
        dispatch(push('/list'));
    });  
    
}