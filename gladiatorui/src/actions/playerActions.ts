import { AnyAction, Action } from "redux";
import { AppThunkAction } from "../store";
import { MainActions } from "./mainActions";
import { ClientApiUrl } from "..";
import { push } from "connected-react-router";
import { GameRegisterPlayerRequest } from "../pages/RegisterPlayerPage";
import { PlayerAttack as PlayerActionEnum } from '../models/PlayerAttack';


// Interface from old React State

export interface PlayeractionRequest {
  playerId: string;
  action: PlayerActionEnum;
}

export interface PlayerInfo {
  playerId: string;
  name: string;
  pv: number;
  stamina: number;
}

export interface GameInfo {
  gladiators: PlayerInfo[];
  isBattleFinish: boolean;
  winner: string;
}

export interface Error {
  hasError: boolean;
  message: string;
}

export interface Gladiator {
  playerId: string;
  name: string;
  pv: number;
  stamina: number;
}

// Action Redux Interface

export interface RegisterPlayerAction extends Action<'REGISTER_PLAYER'> {
  playerId: string;
}

export interface PlayerListAction extends Action<'PLAYER_LIST'> {
  players: Gladiator[];
}

export interface HandleBattleAction extends Action<'HANDLE_BATTLE'> {
  gameInfos: GameInfo;
}

export interface HandleErrorAction extends Action<'HANDLE_ERROR'> {
  error: Error;
}

// Actions Method

export const RegisterPlayer = (id: string, gladiator: GameRegisterPlayerRequest): AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + `/api/battle/${id}/register`, {
        method: 'POST',
        body: JSON.stringify(gladiator),
        headers: { 'Content-type': 'application/json' }
      }).then(response => response.json())
      .then((playerId : string) =>{
        const registeredPlayerId: RegisterPlayerAction = {
            type: 'REGISTER_PLAYER',
            playerId: playerId
        }
        dispatch(registeredPlayerId);
        dispatch(push(`/${id}/action`));
      }
    ) 
}

export const PlayerList = (id: string): AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + `/api/battle/${id}/playerlist`)
    .then(response => response.json())
    .then((data: Gladiator[]) => {
        const listingPlayer: PlayerListAction = {
           type: 'PLAYER_LIST',
           players: data
        }
        dispatch(listingPlayer);
    });
}

export const HandleBattle = (id: string) : AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + `/api/battle/${id}/fight`, {
      method: 'POST',
      // body: JSON.stringify(attack),
      // headers: { 'Content-type': 'application/json' }
  })
      .then(response => response.json())
      .then((data: GameInfo) => {
          const handleBattle: HandleBattleAction ={
             type: 'HANDLE_BATTLE',
             gameInfos: data
          }
          dispatch(handleBattle);
          if (data.isBattleFinish) {        
            dispatch(push(`/${id}/endgame`));
        }        
      })
}

export const HandleSubmitAction = (id: string, action: PlayeractionRequest) : AppThunkAction<MainActions> => (dispatch, getState): Promise<any> => {
    return fetch(ClientApiUrl + `/api/battle/${id}/action`, {
      method: 'POST',
      body: JSON.stringify(action),
      headers: { 'Content-type': 'application/json' }
  })
      .then((data) => {
          if (data.status === 400) {
              data.json().then((error) => {
                const handleError: HandleErrorAction ={
                  type: 'HANDLE_ERROR',
                  error: error
                } 
              dispatch(error) 
            });
          }
      });
}




