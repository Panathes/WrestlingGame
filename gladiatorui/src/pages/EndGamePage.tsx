import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';
import { EndGame } from '../actions/endGameActions';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';

interface EndGameProps {
    playerInfo: PlayerInfo;
}

interface EndGameAction {
    endGame : typeof EndGame;
}

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

type endGameProps = EndGameProps & EndGameAction & RouteComponentProps<EndGameParams>;

class EndGamePage extends React.Component<endGameProps, EndGameState>
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
        this.props.endGame(id)
        // fetch(ClientApiUrl + `/api/battle/${id}/winner`)
        // .then(response => response.json())
        // .then((data: PlayerInfo) => {
        //     this.setState({ playerInfos: data });
        // });
    }

    public render() {
            
        const { playerInfo } = this.props;
        
        return(
            <>
                <h1>The battle is over !</h1>
                 <div >{`The winner is player ${playerInfo.playerId} who choose ${playerInfo.name} !`}</div>               

                <p>Even if you have this navbar 👌, feel free to click on this link for
                   join the homepage and play a new game !
                </p>
                <a href={`/`}>Homepage</a>  
            </>
        )
    }
}

const endGamePage = connect<EndGameProps, EndGameAction, RouteComponentProps<EndGameParams>, ApplicationState>(
    (state: ApplicationState) => ({
        playerInfo: state.main.playerInfo
    }), {
        endGame: EndGame
    }
)(EndGamePage);

export default endGamePage;