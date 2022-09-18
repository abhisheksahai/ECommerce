import { icategory } from "./icategory";
export interface isubCategory {
  id: number;
  name: string;
  createdDateTime: Date;
  categoryId: number;
  category: icategory;
}
