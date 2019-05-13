import * as React from 'react';
import { RouteComponentProps } from 'react-router';

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
        
        fetch('http://localhost:5000/api/battle/list')
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
                console.log(history);
                <h1>Which battle do you want to join ?</h1>
                <ul>
                    {battleIds.map(item =>                 
                        // this.props.history.push("/:id/register");
                        <li>
                            {/* <a href={`http://localhost:5000/api/battle/${item}/register`}>{item}</a>  */}
                            <a href={`http://localhost:5000/api/battle/${item}/register`}>{item}</a>
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