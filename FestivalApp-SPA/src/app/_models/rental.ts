export interface Rental {
  id: number;
  name: string;
  created: Date;
  county: string;
  city: string;
  street: string;
  description: string;
  price: number;
  userId: number;
  festivalId: number;
  thumbnailUrl: string;
  isSelected: boolean;
}
