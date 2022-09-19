import { Button, ButtonGroup, Typography } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import {
  CounterState,
  decrement,
  DECREMENT_COUNTER,
  increment,
  INCREMENT_COUNTER,
} from "./counterReducer";

export default function Counter() {
  const dispatch = useDispatch();
  const { data, title } = useSelector((state: CounterState) => state);
  return (
    <>
      <Typography variant="h2">{title}</Typography>
      <Typography variant="h5">The data is {data}</Typography>
      <ButtonGroup>
        <Button
          variant="contained"
          color="error"
          onClick={() => dispatch(increment())}
        >
          Decrement
        </Button>
        <Button
          variant="contained"
          color="primary"
          onClick={() => dispatch(decrement())}
        >
          Increment
        </Button>
        <Button
          variant="contained"
          color="primary"
          onClick={() => dispatch(increment(10))}
        >
          Increment by 10
        </Button>
      </ButtonGroup>
    </>
  );
}
