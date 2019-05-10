import * as React from 'react';

interface GameCreatorState
{
    isLoaded: boolean;
}
// {} = any
class GameCreator extends React.Component<{}, GameCreatorState>
{
    constructor(props: any)
    {
        super(props);
        this.state = {
            isLoaded: false,
        };       
    }

    createBattle = () => {
        return fetch('http://localhost:5000/api/battle/', {
            method: 'POST'
        }).then(response => {
            return response;
        })
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