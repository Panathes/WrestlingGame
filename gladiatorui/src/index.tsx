import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';

import { createBrowserHistory } from 'history';
import configureStore from './store/configureStore';
import { Provider } from 'react-redux';
import { ApplicationState } from './store';
import { initialState } from './reducers/mainReducer';
import { ConnectedRouter } from 'connected-react-router';

export const ClientApiUrl = 'http://10.2.103.16:5000';

const win = (window as any);


// const history = createBrowserHistory();
// const store = configureStore(history);

// Create browser history to use in the Redux store
const history = createBrowserHistory({ basename: '/' });

// Get the application-wide store instance, prepopulating with state from the server where available.
const appState: ApplicationState = {
    main: initialState
};
const store = configureStore(history, appState);


ReactDOM.render(
    <Provider store={store}>
        <ConnectedRouter history={history}>
            <App />
        </ConnectedRouter>
    </Provider>, document.getElementById('root'));


// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
