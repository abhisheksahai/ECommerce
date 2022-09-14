import { useState, useEffect } from "react";
import { iproduct } from "../app/models/iproduct";
import { ProductList } from "./catalog/ProductList";

export function Catalog() {
  const [products, setProducts] = useState<iproduct[]>([]);

  useEffect(() => {
    fetch("https://localhost:7075/api/Products/GetProducts")
      .then((respose) => respose.json())
      .then((data) => setProducts(data));
  }, []);
  return (
    <>
      <ProductList products={products} />
    </>
  );
}
