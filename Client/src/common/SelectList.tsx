import * as React from "react";
import {
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  Typography,
} from "@mui/material";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";

export interface SelectOption {
  name: string;
  value: string;
}

interface Props {
  caption: string;
  selectedValue: string;
  options: SelectOption[];
  widthValue?: string;
  onSelectChange?: any;
}

export function SelectList({
  caption,
  selectedValue,
  options,
  widthValue = "100%",
  onSelectChange,
}: Props) {
  const handleChange = (event: SelectChangeEvent) => {
    onSelectChange(event.target.value);
  };

  return (
    <>
      <InputLabel>
        <Typography variant="h5" sx={{ lineHeight: "24px" }}>
          {caption}
        </Typography>
      </InputLabel>
      <Select
        displayEmpty
        value={
          options.find((x) => x.value == selectedValue) ? selectedValue : ""
        }
        onChange={handleChange}
        IconComponent={(props) => <KeyboardArrowDownIcon {...props} />}
        SelectDisplayProps={
          !options.find((x) => x.value == selectedValue) || selectedValue === ""
            ? {
                style: {
                  color: "#C3C3C3",
                  fontFamily: "Graphik",
                  fontSize: "14px",
                  fontWeight: 400,
                  backgroundColor: "#ffffff",
                },
              }
            : {
                style: {
                  fontFamily: "Graphik Bold",
                  fontWeight: 600,
                  fontSize: "14px",
                  backgroundColor: "#ffffff",
                },
              }
        }
        style={{ width: widthValue, height: "36px" }}
      >
        <MenuItem disabled value="">
          Select
        </MenuItem>
        {options &&
          options.map((item) => (
            <MenuItem key={item.value} value={item.value}>
              {item.name}
            </MenuItem>
          ))}
      </Select>
    </>
  );
}
export const MemoizedSelectList = React.memo(SelectList);
