import mainReducer, { MainState } from '../reducers/mainReducer';

// the top-level state object
export interface ApplicationState {
    main: MainState;

}

// whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    main: mainReducer
};

// this type can be used as a hint on action creators so that its 'dispatch' and 'getState' params are
// correctly typed to match your store.
export type AppThunkAction<TAction> = Promise<any> | ((dispatch: (action: TAction | AppThunkAction<TAction> | any) => Promise<any>, getState: () => ApplicationState) => Promise<any>);
