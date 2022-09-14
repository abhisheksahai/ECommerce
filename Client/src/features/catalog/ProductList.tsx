import { Grid } from "@mui/material";
import { iproduct } from "../../app/models/iproduct";
import { ProductCard } from "./ProductCard";

interface Props {
  products: iproduct[];
}

export function ProductList({ products }: Props) {
  return (
    <>
      <Grid container spacing={4}>
        {products.map((product) => (
          <Grid item xs={3} key={product.id}>
            <ProductCard product={product} />
          </Grid>
        ))}
      </Grid>
    </>
  );
}
