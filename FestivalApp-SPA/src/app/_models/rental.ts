export interface Rental {
  id: number;
  name: string;
  created: Date;
  location: string;
  userId: number;
  festivalId: number;
  thumbnailUrl: string;
  isSelected: boolean;
}
