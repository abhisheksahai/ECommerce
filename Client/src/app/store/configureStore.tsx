import { createStore } from "redux";
import counterReducer from "../../features/counter/counterReducer";

export function configureStore() {
  return createStore(counterReducer);
}
