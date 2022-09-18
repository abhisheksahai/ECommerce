import { icategory } from "../models/icategory";
import { isubCategory } from "../models/isubCategory";
export interface iproduct {
  id: number;
  code: string;
  name: string;
  quantity: number;
  price: number;
  description: string;
  categoryId: number;
  category: icategory;
  subCategoryId: number;
  subCategory: isubCategory;
  pictureUrl: string;
}
