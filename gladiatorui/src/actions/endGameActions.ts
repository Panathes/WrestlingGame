import { AnyAction, Action } from "redux";
import { AppThunkAction } from "../store";
import { MainActions } from "./mainActions";
import { ClientApiUrl } from "..";

interface PlayerInfo {
    playerId: string;
    name: string;
    pv: number;
    stamina: number;
  }

export interface EndGameAction extends Action<'END_GAME'> {
    playerInfo: PlayerInfo
}

export const EndGame = (id: string): AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + `/api/battle/${id}/winner`)
    .then(response => response.json())
    .then((data: PlayerInfo) => {
        const endGame: EndGameAction = {
            type: 'END_GAME',
            playerInfo: data
        }
        dispatch(endGame)
    });
}
