import { createStore, applyMiddleware, compose, combineReducers, Store, StoreEnhancerStoreCreator, ReducersMapObject, StoreEnhancer, AnyAction } from 'redux';
import thunk from 'redux-thunk';
import * as StoreModule from '.';
import { ApplicationState, reducers } from '.';
import { History } from 'history';
import { Middleware } from 'redux';
import { MainActions } from '../actions/mainActions';
import { routerMiddleware, connectRouter } from 'connected-react-router'

export default function configureStore(history: History, initialState?: ApplicationState, middlewares: Middleware[] = []) {
    // build middleware. These are functions that can process the actions before they reach the store.
    const windowIfDefined = typeof window === 'undefined' ? null : window as any;
    // If devTools is installed, connect to it
    const devToolsExtension = windowIfDefined && windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__ as <S>() => StoreEnhancerStoreCreator<S>;
    const createStoreWithMiddleware = compose(
        applyMiddleware(thunk, routerMiddleware(history), ...middlewares),
        devToolsExtension ? devToolsExtension() : <S>(next: StoreEnhancerStoreCreator<S>) => next
    ) as StoreEnhancer<Store<ApplicationState, MainActions>, any>;

    // combine all reducers and instantiate the app-wide store instance
    const allReducers = buildRootReducer(reducers, history);
    const store = createStore(allReducers, initialState, createStoreWithMiddleware) as Store<ApplicationState>;

    // enable Webpack hot module replacement for reducers
    // if (module.hot) {
    //     module.hot.accept("./store", () => {
    //         const nextRootReducer = require<typeof StoreModule>("./store");
    //         store.replaceReducer(buildRootReducer(nextRootReducer.reducers));
    //     });
    // }

    return store;
}

function buildRootReducer(allReducers: ReducersMapObject<ApplicationState, MainActions>, history: History) {
    return combineReducers<ApplicationState>(Object.assign({}, allReducers, { router: connectRouter(history) }));
}
