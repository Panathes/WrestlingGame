import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';

interface PlayerActionState
{
    action: number,
    players: Gladiator[];
    playerInfos : PlayerInfo[];

}

interface PlayerActionParams
{
    id: string;
    playerId : string;
}

interface PlayeractionRequest {
    playerId: string;
    action : number;
}

interface Gladiator {
    playerId : string;
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

interface WinnerInfo {
    gladiators: PlayerInfo[];
    stillfighting: boolean;
    winner: string;
}


// const req: PlayerChooseActionRequest = {

// }

class PlayerAction extends React.Component<RouteComponentProps<PlayerActionParams>, PlayerActionState>
{
    constructor(props:any)
    {
        super(props);
        this.state = {
            action : 0,
            players : [],
            playerInfos : [],
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleBattle = this.handleBattle.bind(this);
    }
    
    componentDidMount() {
        const id = this.props.match.params.id;
        fetch(ClientApiUrl + `/api/battle/${id}/playerlist`)
        .then(response => response.json())
        .then((data: Gladiator[]) => {
            this.setState({ players: data });
        });
    }

    handleBattle(event : any) {
        const id = this.props.match.params.id;
        const playerId = this.props.match.params.playerId;

        // const attack: PlayeractionRequest = { playerId, action : this.state.action};

        fetch(ClientApiUrl + `/api/battle/${id}/fight`, {
            method: 'POST',
            // body: JSON.stringify(attack),
            // headers: { 'Content-type': 'application/json' }
        })
        .then(response => response.json())      
        .then((data : PlayerInfo[]) => {
            this.setState({ playerInfos: data});
        })
        // console.log(attack);    
    }


    handleChange(event : any) {
        this.setState({action: event.target.value});
    }

    handleSubmit(event : any) {
        event.preventDefault();

        const id = this.props.match.params.id;
        const playerId = this.props.match.params.playerId;

        const action: PlayeractionRequest = { playerId, action : this.state.action};
        fetch(ClientApiUrl + `/api/battle/${id}/action`, {
            method: 'POST',
            body: JSON.stringify(action),
            headers: { 'Content-type': 'application/json' }
        })
    }

    public render() {

        const { playerInfos } = this.state;
        const id = this.props.match.params.id;

        return(
            <>
                <h1>Player, choose your action</h1>
                <p>1 for a weak attack, 2 for a strong attack, 3 for a parry</p>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        <input type="text" value={this.state.action} onChange={this.handleChange} />
                    </label>
                    <input type="submit" value="Submit" />
                </form>
                <button onClick={this.handleBattle}>Attack</button>
                    {playerInfos.map((item, index) => <div key={index}>{item.name +" "+ "pv:"+" "+ item.pv +" "+ "stamina:"+" "+ item.stamina}</div>)}
            </>
        )
    }
}

export default PlayerAction;