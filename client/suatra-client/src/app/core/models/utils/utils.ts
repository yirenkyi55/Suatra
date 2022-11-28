export enum Sizes {
  None,
  Sm,
  Md,
  Lg,
  Xl,
  Xxl,
}

export enum LoadingStatus {
  Loading,
  Success,
  Error,
  Idle,
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

export interface ActionButton {
  type: ActionButtonTypes;
  icon: any;
  toolTipMessage?: string;
  showConfirmMessage?: boolean;
  confirmMessage?: string;
  confirmButtonText?: string;
}

export class ActionButtonData {
  constructor(public tableData: any, public actionButton: ActionButton) {}
}

export enum ActionButtonTypes {
  Create = 'create',
  Read = 'read',
  Update = 'update',
  Delete = 'delete',
}

export const FieldSize = {
  MaxSizeOf64: 64,
  MaxSizeOf128: 128,
  MaxSizeOf256: 256,
  MaxSizeOf512: 512,
};

export interface NotificationMessage {
  notificationType: NotificationType;
  title: string;
  message: string;
}

export enum NotificationType {
  Success = 'success',
  Info = 'info',
  Warning = 'warning',
  Error = 'error',
}

export interface SearchQuery {
  query?: string | null;
}
