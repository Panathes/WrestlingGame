import * as React from 'react';

interface BattleListState
{
    battleIds : string[];
}

class BattleList extends React.Component<{}, BattleListState>
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
                <h1>Which battle do you want to join ?</h1>
                <ul>
                    {battleIds.map(item =>
                        <li>
                            {/* <a href={`http://localhost:5000/api/battle/${item}/register`}>{item}</a>  */}
                            <a href={`http://localhost:5000/api/battle/${item}/register`}>{item}</a>
                        </li>
                    )}               
                </ul> 
                {/* <ul>
                     <li>{this.state.battleIds}</li>
                </ul>                   */}
            </>
        );
    } 
}

export default BattleList;