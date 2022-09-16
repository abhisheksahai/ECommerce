import { Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import { iproduct } from "../../app/models/iproduct";

export function ProductDetails() {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<iproduct | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios
      .get(`https://localhost:7075/api/Products/GetProduct/${id}`)
      .then((response) => setProduct(response.data))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <h3>Loading...</h3>;
  if (!product) return <h3>Product not found</h3>;

  return <Typography variant="h2">Product details : {product.name}</Typography>;
}
