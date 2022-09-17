import { useState, useEffect } from "react";
import { iproduct } from "../app/models/iproduct";
import { ProductList } from "./catalog/ProductList";
import agent from "../app/api/agent";
import LoadingComponent from "../app/layout/LoadingComponent";

export function Catalog() {
  const [products, setProducts] = useState<iproduct[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    agent.Catalog.list()
      .then((products) => setProducts(products))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <LoadingComponent message="Loading product..." />;

  return (
    <>
      <ProductList products={products} />
    </>
  );
}
