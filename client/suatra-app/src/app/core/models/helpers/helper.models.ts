import { ActionButtonTypes } from '../../enums';

export interface NotificationMessage {
  notificationType: NotificationType;
  title: string;
  message: string;
}

export enum NotificationType {
  success = 'success',
  info = 'info',
  warning = 'warning',
  error = 'error',
}

export interface ActionButton {
  key: string;
  type: ActionButtonTypes;
  icon: any;
  toolTipMessage: string;
  includeConfirm?: boolean;
  confirmMessage?: string;
  confirmButtonText?: string;
  style: {};
  hasAccess: boolean;
  disabled?(id: string, items: any[]): boolean;
}

export interface ActionButtonData {
  id: string;
  type: ActionButtonTypes;
}

export interface ListItem {
  id: string;
  text: string;
}

export interface InspectItem {
  label: string;
  text: string;
}

export interface InspectModeContent {
  title?: string;
  text?: string;
  isMultiple: boolean;
  contents?: InspectMultiple[];
  isImage?: boolean;
}

export interface InspectMultiple {
  title: string;
  text: string;
  isImage?: boolean;
}

export interface DropDownOptions {
  value: any;
  label: string;
  disabled?: boolean;
}

export interface TableHeaders {
  key: string;
  label: string;
  isImage?: boolean;
}

export interface ContactModel {
  name: string;
  email: string;
  message: string;
}

export interface ContactResponse {
  id: string;
  name: string;
  email: string;
  message: string;
}
