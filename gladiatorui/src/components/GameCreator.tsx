import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';

interface GameCreatorState
{
    isLoaded: boolean;
}
// {} = any
class GameCreator extends React.Component<RouteComponentProps, GameCreatorState>
{
    constructor(props: any)
    {
        super(props);
        this.state = {
            isLoaded: false,
        };       
    }

    createBattle = () => {
        fetch(ClientApiUrl + '/api/battle/', {
            method: 'POST'
        }).then(response => {
            this.props.history.push('/list');
        });
    }

    public render() {
        return(
            <>
                <h1>Welcome to Gladiator Game ! (such a beautiful name doesn't it ?)</h1>
                <h1>Please create a game !</h1>            
                <button onClick={this.createBattle}>Create Battle</button>
            </>
        )
    }

}

// Pas de href="#" dans un button
export default GameCreator;