import { Employee } from './employee.model';

export interface Role {
  id: number;
  name: string;
  status: number;
  employees: Employee[];
}
