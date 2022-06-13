export interface User {
  id: number;
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  roles?: string;
  clientURI: string;
}
