export enum Sizes {
  None,
  Sm,
  Md,
  Lg,
  Xl,
  Xxl,
}

export enum LoadingStatus {
  loading,
  success,
  error,
  idle,
}

export interface DashboardMenu {
  title: string;
  icon: string;
  route?: string;
  children?: DashboardMenuChild[];
}

export interface DashboardMenuChild {
  title: string;
  icon?: string;
  route: string;
}

export interface TableHeaders {
  key: string;
  label: string;
}
