export interface Festival {
  id: number;
  name: string;
  imageUrl: string;
  startDate: Date;
  endDate: Date;
  location: string;
  city: string;
  ticketUrl: string;
  isLiked: boolean;
}