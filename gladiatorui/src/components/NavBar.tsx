import * as React from 'react';
import { NavLink } from 'react-router-dom'; 

class NavBar extends React.Component<{}, {}>
{

    public render() {
        return(
            <div className="NavBar-wrapper">           
                <NavLink to="/">Homepage</NavLink>
                <NavLink to="/list">Battle list</NavLink>
            </div>
        )
    }
}

export default NavBar;