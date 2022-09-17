import { useState, useEffect } from "react";
import { iproduct } from "../app/models/iproduct";
import { ProductList } from "./catalog/ProductList";
import axios from "axios";
import agent from "../app/api/agent";

export function Catalog() {
  const [products, setProducts] = useState<iproduct[]>([]);

  useEffect(() => {
    agent.Catalog.list()
      .then((products) => setProducts(products))
      .catch((error) => console.log(error));
  }, []);

  return (
    <>
      <ProductList products={products} />
    </>
  );
}
