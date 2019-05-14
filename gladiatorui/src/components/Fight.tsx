import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { render } from 'react-dom';

interface FightState
{
    isLoaded: boolean
}

class Fight extends React.Component<{}, FightState>
{
    constructor(props:any)
    {
        super(props);
        this.state = {
            isLoaded : false
        }
    };

    public render() {
        return(
            <>
                <h1>Player choose your action</h1>
                <p>press 1 for Weak attack,press 2 for Strong attack, press 3 for Parry</p>
                <div>
                    <p>Some attack from <i>GladiatorName</i></p>
                    <p>Afficher Life/Stamina</p>
                </div>
            </>
        )
    }
}

export default Fight;

