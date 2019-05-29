import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';
import { PlayerAttack as PlayerActionEnum } from '../models/PlayerAttack';

interface PlayerActionState {
    action: number,
    players: Gladiator[];
    playerInfos: PlayerInfo[];
    gameInfos: GameInfo;
    error: Error;
}

interface PlayerActionParams {
    id: string;
    playerId: string;
}

interface PlayeractionRequest {
    playerId: string;
    action: PlayerActionEnum;
}

interface Gladiator {
    playerId: string;
    name: string;
    pv: number;
    stamina: number;
}

interface PlayerInfo {
    playerId: string;
    name: string;
    pv: number;
    stamina: number;
}

interface GameInfo {
    gladiators: PlayerInfo[];
    isBattleFinish: boolean;
    winner: string;
}

interface Error {
    hasError: boolean;
    message: string;
}


export type PlayerActionProps = RouteComponentProps<PlayerActionParams>;

class PlayerAction extends React.Component<PlayerActionProps, PlayerActionState>
{
    constructor(props: PlayerActionProps) {
        super(props);
        this.state = {
            action: 0,
            players: [],
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
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleBattle = this.handleBattle.bind(this);
        this.setWeakAction = this.setWeakAction.bind(this);
        this.setStrongAction = this.setStrongAction.bind(this);
        this.setParryAction = this.setParryAction.bind(this);
    }

    componentDidMount() {
        const id = this.props.match.params.id;
        fetch(ClientApiUrl + `/api/battle/${id}/playerlist`)
            .then(response => response.json())
            .then((data: Gladiator[]) => {
                this.setState({ players: data });
            });
    }

    handleBattle(event: any) {
        const id = this.props.match.params.id;
        // const playerId = this.props.match.params.playerId;

        // const attack: PlayeractionRequest = { playerId, action : this.state.action};

        fetch(ClientApiUrl + `/api/battle/${id}/fight`, {
            method: 'POST',
            // body: JSON.stringify(attack),
            // headers: { 'Content-type': 'application/json' }
        })
            .then(response => response.json())
            .then((data: GameInfo) => {
                this.setState({ gameInfos: data });
                if (data.isBattleFinish) {
                    this.props.history.push(`/${id}/endgame`)
                }
            })
    }


    handleChange(event: any) {
        this.setState({ action: event.target.value });
    }

    setWeakAction(event: any) {
        this.setState({ action: PlayerActionEnum.Weak });
    }

    setStrongAction(event: any) {
        this.setState({ action: PlayerActionEnum.Strong });
    }

    setParryAction(event: any) {
        this.setState({ action: PlayerActionEnum.Parry });
    }

    handleSubmit(event: any) {
        event.preventDefault();

        const id = this.props.match.params.id;
        const playerId = this.props.match.params.playerId;

        const action: PlayeractionRequest = { playerId, action: this.state.action };
        fetch(ClientApiUrl + `/api/battle/${id}/action`, {
            method: 'POST',
            body: JSON.stringify(action),
            headers: { 'Content-type': 'application/json' }
        })
            .then((data) => {
                if (data.status === 400) {
                    data.json().then((error) => {
                        this.setState({ error: error })
                    });
                }
            });
    }

    public render() {
        const { playerInfos } = this.state;
        const { players } = this.state;

        const id = this.props.match.params.id;
        const { gameInfos } = this.state;
        
        return (
            <>
                <h1>Player, choose your action</h1>
                <p>1 for a weak attack, 2 for a strong attack, 3 for a parry</p>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        <button onClick={this.setPlayerAction(PlayerActionEnum.Weak)}>Weak</button>
                        <button onClick={this.setPlayerAction(PlayerActionEnum.Strong)}>Strong</button>
                        <button onClick={this.setPlayerAction(PlayerActionEnum.Parry)}>Parry</button>
                        {/* <input type="text" value={this.state.action} onChange={this.handleChange} /> */}
                    </label>
                    {/* <input type="submit" value="Submit" /> */}
                </form>
                <button onClick={this.handleBattle}>Attack</button>               
                {players.map((item, index) => <div key={index}>{item.name + this.state.action + " " + item.pv + " " + item.stamina}</div>)}             
                {/* {playerInfos.map((item, index) =>                 
                <ul key={index}>
                    <li></li>
                    <li>{item.name}</li>
                    <li>{this.state.action}</li>
                    <li>{item.pv}</li>
                    <li>{item.stamina}</li>
                </ul>)} */}
                {this.state.error.hasError ? <p>{this.state.error.message}</p> : null}
            </>
        )
    }

    private setPlayerAction = (action: PlayerActionEnum) => () => {
        this.setState({ 
            action
        });
    }
}

export default PlayerAction;