export interface User {
  id: number;
  name: string;
  email: string;
  phoneNumber: string;
  dateCreated: Date;
  status: boolean;
}

export const users: User[] = [
  {
    id: 0,
    name: "Jan Kowalski",
    email: "JanKowalski@test.com",
    phoneNumber: "+48 123123123",
    dateCreated: new Date(),
    status: true,
  },
  {
    id: 1,
    name: "Piotr Zieliński",
    email: "PiotrZieliński@test.com",
    phoneNumber: "+48 123123123",
    dateCreated: new Date(),
    status: false,
  },
];
