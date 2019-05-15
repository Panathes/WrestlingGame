import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';

interface RegisterPlayerState
{
    isLoaded: boolean;
    value: string;   

}

interface RegisterPlayerParams 
{
    id: string;
}

interface GameRegisterPlayerRequest {
    playerId: string;
}

class RegisterPlayer extends React.Component<RouteComponentProps<RegisterPlayerParams>, RegisterPlayerState>
{
    constructor(props: any)
    {
        super(props)
        this.state = {
            isLoaded: false,
            value: ''
        };        
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event : any) {
        this.setState({value: event.target.value});

    }

    handleSubmit(event : any){
        event.preventDefault();

        const id = this.props.match.params.id;
        const gladiator: GameRegisterPlayerRequest =  {playerId: this.state.value } ;

        fetch(ClientApiUrl + `/api/battle/${id}/register`, {
            method: 'POST',
            body: JSON.stringify(gladiator),
            headers: { 'Content-type': 'application/json' }
          }).then(response => response.json())
          .then((playerId : string) =>{
            this.props.history.push(`/${id}/${playerId}/action`);
          })       
    }

    public render() {
        console.log(this.props.match.params.id); 
        const id = this.props.match.params.id;      
        return(
            <>
                <h1>Player, choose your fighter !</h1>
                <p>Spartacus, Crixus ou Piscus ?</p>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        <input type="text" value={this.state.value} onChange={this.handleChange} />
                    </label>
                    <input type="submit" value="Submit" />
                </form>
            </>
        )
    }
}

export default RegisterPlayer;