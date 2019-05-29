import { AnyAction, Action } from "redux";
import { AppThunkAction } from "../store";
import { MainActions } from "./mainActions";
import { ClientApiUrl } from "..";
import { push } from "connected-react-router";
import { GameRegisterPlayerRequest } from "../pages/RegisterPlayerPage";

export interface RegisterPlayerAction extends Action<'REGISTER_PLAYER'> {
    playerId: string;
}

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
        dispatch(push(`/${id}/${playerId}/action`));
      }
    ) 
}

