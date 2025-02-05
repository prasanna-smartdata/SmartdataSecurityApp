import { Role } from './role.model';

export interface Employee {
  id: number; // Unique user ID
  firstName: string;
  lastName: string;
  middleName: string;
  fullName: string;
  email: string;
  password: string;
  roleId: string;
  skills?: string;
  role: Role;
  //token?: string; // (Optional) JWT token for authentication
  status: string; // User account status
  permissions?: string[]; // Array of permissions, e.g., ['read', 'write']
  active: string;
  tenantId: string;
}
