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

export interface ForgotPasswordRequestModel {
  email: string;
}
