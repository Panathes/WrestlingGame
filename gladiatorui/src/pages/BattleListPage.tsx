import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';
import { ListingBattle } from '../actions/battleActions';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';

interface ListingBattleProps {
    battleIds: string[];
}

interface ListingBattleAction {
    listingBattle: typeof ListingBattle;
}

interface BattleListState
{
    battleIds : string[];
    battleName : string[];
}

interface BattleListParams 
{
    id: string;
    battleName : string;
}

type listingBattleProps = ListingBattleProps & ListingBattleAction & RouteComponentProps<BattleListParams>;

class BattleListPage extends React.Component<listingBattleProps, BattleListState>
{
    constructor(props: any)
    {
        super(props);
        this.state = {
            battleIds : [],
            battleName : [] 
        };
    }


    componentDidMount() {
        this.props.listingBattle();       
    //     // const id = this.props.match.params.id;
        
    //     // console.log("hello");
        
    //     // fetch(ClientApiUrl + '/api/battle/list')
    //     // .then(response => response.json())
    //     // .then((data: string[]) => {
    //     //     // debugger;
    //     //     this.setState({ battleIds: data });
    //     // });
    //     // fetch(ClientApiUrl + `/api/battle/${id}/name`)
    //     // .then(response => response.json())
    //     // .then((data: string[]) => {
    //     //     // debugger;
    //     //     this.setState({ battleName: data });
    //     // });
    //     // .then(data => console.log(data));
    }
    public render() {   
        const { battleIds } = this.props;
        const { battleName } = this.state;     

        return( 
            <>
                <h1>Which battle do you want to join ?</h1>
                <ul>
                    {battleIds.map((item, index) =>                 
                        // this.props.history.push("/:id/register");
                        <li key={index}>
                            {/* <a href={`http://localhost:5000/api/battle/${item}/register`}>{item}</a>  */}
                            <a href={`/${item}/register`}>{'Battle:' +' ' + index + battleName }</a>
                        </li>
                    )}               
                </ul> 
                {/* <ul>
                     <li>{this.state.battleIds}</li>
                </ul> */}
            </>
        );
    } 
}

const battleListPage = connect<ListingBattleProps, ListingBattleAction, RouteComponentProps<BattleListParams>, ApplicationState>(
    (state: ApplicationState) => ({
        battleIds: state.main.battleIds
    }), {
        listingBattle: ListingBattle
    }
)(BattleListPage);

export default battleListPage;