import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { ClientApiUrl } from '..';

interface BattleListState
{
    battleIds : string[];
}

interface BattleListParams 
{
    id: string;
}

class BattleList extends React.Component<RouteComponentProps<BattleListParams>, BattleListState>
{
    constructor(props: any)
    {
        super(props);
        this.state = {
            battleIds : [],
        };
    }

    componentDidMount() {        
        console.log("hello");
        
        fetch(ClientApiUrl + '/api/battle/list')
        .then(response => response.json())
        .then((data: string[]) => {
            // debugger;
            this.setState({ battleIds: data });
        });
        // .then(data => console.log(data));
    }
    public render() {     
        const { battleIds } = this.state;
        return( 
            <>
                <h1>Which battle do you want to join ?</h1>
                <ul>
                    {battleIds.map((item, index) =>                 
                        // this.props.history.push("/:id/register");
                        <li key={index}>
                            {/* <a href={`http://localhost:5000/api/battle/${item}/register`}>{item}</a>  */}
                            <a href={`/${item}/register`}>{'Battle:' +' ' + index  }</a>
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

export default BattleList;