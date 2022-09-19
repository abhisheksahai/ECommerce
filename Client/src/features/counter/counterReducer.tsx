export interface CounterState {
  data: number;
}

const initialState: CounterState = {
  data: 50,
};

export default function counterReducer(state = initialState, action: any) {
  return state;
}
