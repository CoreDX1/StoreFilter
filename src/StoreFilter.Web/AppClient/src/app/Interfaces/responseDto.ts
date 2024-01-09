export interface ResponseDto {
  isSuccess: boolean;
  message: string;
  data: Game[];
}

export interface Game {
  gameId: string;
  name: string;
  price: number;
  stock: number;
  imageUrl: string;
  description: string;
  releaseDate: string;
  developerId: number;
  rating: number;
}
