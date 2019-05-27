import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';
import { connect } from 'react-redux';
import { CreateBattle } from '../actions/battleActions';
import { ApplicationState } from '../store';

interface CreateBattleProps {
}

interface CreateBattleActions {
    createBattle: typeof CreateBattle;
}

interface GameCreatorState
{
    battleName : string;
}

interface GameCreatorRequest{
    battleName : string;
}

interface GameCreatorParams 
{
    id: string;
    battleName : string;
}

type createBattleProps = CreateBattleProps & CreateBattleActions & RouteComponentProps<GameCreatorParams>;

// {} = any
class CreateBattlePage extends React.Component<createBattleProps, GameCreatorState>
{
    constructor(props: createBattleProps) {
        super(props);       
        this.state = {
            battleName : " ",
        };  
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);     
    }

    // createBattle = () => {
    //     fetch(ClientApiUrl + '/api/battle/', {
    //         method: 'POST'
    //     }).then(response => {
    //         this.props.history.push('/list');
    //     });       
    // }

    handleChange(event: any) {
        this.setState({ battleName: event.target.value });
    }

    handleSubmit(event: any) {
        event.preventDefault();

        // const { battleName } = this.state;
        // const id = this.props.match.params.id;

        // // fetch(ClientApiUrl + `/api/battle/${id}/name`)
        // // .then(response => response.json())
        // // .then((data: string) => {
        // //     // debugger;
        // //     this.setState({ battleName: data });
        // // });

        // fetch(ClientApiUrl + '/api/battle/', {
        //     method: 'POST'
        // })

        // .then(response => {
        //     this.props.history.push('/list');
        // });  
        this.props.createBattle();
    }

    public render() {
        return(
            <>
                <h1>Welcome to Gladiator Game ! (such a beautiful name doesn't it ?)</h1>
                {/* <h1>What's your game's name ?</h1> */}
                <h1>Let's create a game !</h1>

                <form onSubmit={this.handleSubmit}>
                    <label>
                        {/* <input type="text" value={this.state.battleName} onChange={this.handleChange} /> */}
                    </label>
                    <input type="submit" value="Submit" />
                </form>
                {/* <h1>Please create a game !</h1>            
                <button onClick={this.createBattle}>Create Battle</button> */}
            </>
        )
    }

}

const createBattlePage = connect<CreateBattleProps, CreateBattleActions, RouteComponentProps<GameCreatorParams>, ApplicationState>(
    (state: ApplicationState) => ({
    }), {
        createBattle: CreateBattle
    }
)(CreateBattlePage);

// Pas de href="#" dans un button
export default createBattlePage;