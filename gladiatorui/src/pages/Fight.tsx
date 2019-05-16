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
                <h1>Action in progress...</h1>
            </>
        )
    }
}

export default Fight;

