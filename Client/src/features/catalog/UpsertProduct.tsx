import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import AddIcon from "@mui/icons-material/Add";
import Typography from "@mui/material/Typography";
import { useState } from "react";
import agent from "../../app/api/agent";
import { useNavigate } from "react-router-dom";
import { MemoizedSelectList } from "../../common/SelectList";

export default function UpsertProduct() {
  const [file, setFile] = useState("");
  const navigation = useNavigate();

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);
    formData.append("formFile", file);
    await agent.Catalog.addProduct(formData)
      .then(() => {
        navigation("/catalog");
      })
      .catch((error) => console.log(error));
  };

  const saveFile = (e: any) => {
    console.log(e.target.files[0]);
    setFile(e.target.files[0]);
  };

  return (
    <Box
      sx={{
        marginTop: 8,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
        <AddIcon />
      </Avatar>
      <Typography component="h1" variant="h5">
        Add product
      </Typography>
      <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <TextField
              autoComplete="code"
              name="code"
              required
              fullWidth
              id="code"
              label="Code"
              autoFocus
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              id="name"
              label="Name"
              name="name"
              autoComplete="family-name"
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              id="quantity"
              label="Quantity"
              name="quantity"
              autoComplete="quantity"
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              name="price"
              label="Price"
              type="price"
              id="price"
              autoComplete="price"
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              name="description"
              label="Description"
              type="description"
              id="description"
              autoComplete="description"
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              name="categoryId"
              label="Category"
              type="categoryId"
              id="categoryId"
              autoComplete="categoryId"
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              name="subCategoryId"
              label="SubCategory"
              type="subCategoryId"
              id="subCategoryId"
              autoComplete="subCategoryId"
            />
          </Grid>
          
          <Grid item xs={12} sm={6}>
            <input
              type="file"
              name="pictureurl"
              id="pictureurl"
              onChange={saveFile}
            />
          </Grid>
        </Grid>
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Submit
        </Button>
        <Grid container justifyContent="flex-end">
          <Grid item>
            <Button component={Link} href="catalog">
              Catalog
            </Button>
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
}
