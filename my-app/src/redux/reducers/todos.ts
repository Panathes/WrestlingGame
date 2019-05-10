import { ADD_TODO, TOGGLE_TODO, AllActions } from "../actionTypes";
import { any } from "prop-types";

export interface TodoState {
    allIds: number[];
    byIds: {
      [key: number]: {
        // title: string,
        completed: boolean
      },
    };
}

const initialState: TodoState = {
  allIds: [],
  byIds: {
    // title: '',
    // completed: false
  }
};

export default function(state = initialState, action: AllActions) {
  switch (action.type) {
    case ADD_TODO: {
      const { id, content } = action.payload;
      return {
        ...state,
        allIds: [...state.allIds, id],
        byIds: {
          ...state.byIds,
          [id]: {
            content,
            completed: false
          }
        }
      };
    }
    case TOGGLE_TODO: {
      const { id } = action.payload;
      return {
        ...state,
        byIds: {
          ...state.byIds,
          [id]: {
            ...state.byIds[id],
            completed: !state.byIds[id].completed
          }
        }
      };
    }
    default:
      return state;
  }
}
