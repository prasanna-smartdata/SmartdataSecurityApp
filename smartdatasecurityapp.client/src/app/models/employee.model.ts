export interface Employee {
  id: number; // Unique user ID
  name: string; // Full name of the user
  email: string;
  password: string;
  roleId?: string; // (Optional) Role of the user, e.g., 'admin', 'user'
  token?: string; // (Optional) JWT token for authentication
  status?: number; // User account status
  permissions?: string[]; // Array of permissions, e.g., ['read', 'write']
}
