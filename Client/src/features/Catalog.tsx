import { useState, useEffect } from "react";
import { iproduct } from "../app/models/iproduct";
import { ProductList } from "./catalog/ProductList";
import axios from "axios";

export function Catalog() {
  const [products, setProducts] = useState<iproduct[]>([]);

  useEffect(() => {
    axios
      .get(`https://localhost:7075/api/Products/GetProducts`)
      .then((response) => setProducts(response.data))
      .catch((error) => console.log(error));
  }, []);

  return (
    <>
      <ProductList products={products} />
    </>
  );
}
