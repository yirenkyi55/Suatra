// REQUESTS

export interface LoginRequestModel {
  email: string;
  password: string;
}

export interface RegisterRequestModel {
  email: string;
  firstName: string;
  otherName: string;
  lastName: string;
  password: string;
}

export interface UserModel {
  id: string;
  email: string;
  firstName: string;
  otherName: string;
  lastName: string;
  bio: string;
  photo: string;
  accessToken: string;
  roles: string[];
}
