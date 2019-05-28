import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';

interface EndGameState
{
    playerInfos : PlayerInfo;
}

interface EndGameParams
{
    id: string;
    playerId : string;
}

interface PlayerInfo {
    playerId: string;
    name: string;
    pv: number;
    stamina: number;
}

class EndGamePage extends React.Component<RouteComponentProps<EndGameParams>, EndGameState>
{
    constructor(props : any)
    {
        super(props);
        this.state = {
            playerInfos : {
                playerId: " ",
                name: " ",
                pv: 100,
                stamina: 100
            } 
        }
    }

    componentDidMount() {
        const id = this.props.match.params.id;
        fetch(ClientApiUrl + `/api/battle/${id}/winner`)
        .then(response => response.json())
        .then((data: PlayerInfo) => {
            this.setState({ playerInfos: data });
        });
    }

    public render() {
        console.log();
            
        const { playerInfos } = this.state;
        
        return(
            <>
                <h1>The battle is over !</h1>
                 <div >{`The winner is player ${playerInfos.playerId} who choose ${playerInfos.name} !`}</div>               

                <p>Even if you have this navbar 👌, feel free to click on this link for
                   join the homepage and play a new game !
                </p>
                <a href={`/`}>Homepage</a>  
            </>
        )
    }
}

export default EndGamePage;