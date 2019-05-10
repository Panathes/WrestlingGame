import * as React from 'react';

interface RegisterPlayerState
{
    isLoaded: boolean;    
}

class RegisterPlayer extends React.Component<{}, RegisterPlayerState>
{
    constructor(props: any){
        super(props)
        this.state = {
            isLoaded: false,
        };    
    }

    public render() {
        return(
            <>
                <h1>Player, choose your fighter !</h1>
            </>
        )
    }
}

export default RegisterPlayer;