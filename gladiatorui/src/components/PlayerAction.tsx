import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';

interface PlayerActionState
{
    action: number,
    players: Gladiator[];
    winner : string;
}

interface PlayerActionParams
{
    id: string;
    playerId : string;
}

interface PlayeractionRequest {
    action : number;
    playerId: string;
}

interface Gladiator {
    gladiatorId : string;
    name: string;
    pv: number;
    stamina: number;
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
            winner : "yggyut"
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.onClick = this.onClick.bind(this);
    }
    
    componentDidMount() {
        const id = this.props.match.params.id;
        fetch(ClientApiUrl + `/api/battle/${id}/playerlist`)
        .then(response => response.json())
        .then((data: Gladiator[]) => {
            this.setState({ players: data });
        });
    }

    onClick(event : any) {
        const id = this.props.match.params.id;
        fetch(ClientApiUrl + `/api/battle/${id}/fight`, {
            method: 'POST',
        })
        .then(response => response.json())
        .then((data : string) => {
            this.setState({ winner: data});
        })
    }


    handleChange(event : any) {
        this.setState({action: event.target.value});
    }

    handleSubmit(event : any) {
        event.preventDefault();

        const id = this.props.match.params.id;
        const playerId = this.props.match.params.playerId;
        debugger;

        const action: PlayeractionRequest = { playerId, action : this.state.action};
        fetch(ClientApiUrl + `/api/battle/${id}/action`, {
            method: 'POST',
            body: JSON.stringify(action),
            headers: { 'Content-type': 'application/json' }
        })
    }

    public render() {
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
                <button onClick={this.onClick}>Attack</button>
                <p>{this.state.winner}</p>
            </>
        )
    }
}

export default PlayerAction;