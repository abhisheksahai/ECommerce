import { Backdrop, Box, CircularProgress, Typography } from "@mui/material";

interface Props {
  message?: string;
}

export default function LoadingComponent({ message = "Loading..." }: Props) {
  return (
    <Backdrop open={true} invisible={true}>
      <Box
        display="flex"
        justifyContent="center"
        alignContent="center"
        height="100vh"
      >
        <CircularProgress
          size={100}
          color="secondary"
          sx={{ mt: "10rem" }}
        ></CircularProgress>
        <Typography
          variant="h4"
          sx={{ justifyContent: "center", position: "fixed", top: "50%" }}
        >
          {message}
        </Typography>
      </Box>
    </Backdrop>
  );
}
