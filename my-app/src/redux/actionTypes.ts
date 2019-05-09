export const ADD_TODO = "ADD_TODO";
export const TOGGLE_TODO = "TOGGLE_TODO";
export const SET_FILTER = "SET_FILTER";

export interface TodoAddAction { type: 'ADD_TODO'; payload: any; }
export interface TodoToggleTodo { type: 'TOGGLE_TODO'; payload: any; }
export interface TodoSetFilter {type: 'SET_FILTER'; payload: any;}


export type AllActions = TodoAddAction | TodoToggleTodo | TodoSetFilter;