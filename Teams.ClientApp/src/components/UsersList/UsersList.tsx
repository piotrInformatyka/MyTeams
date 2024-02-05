import { DataGrid } from "@mui/x-data-grid";
import { User, users } from "../../data/usersData.tsx";
import UserStatus from "../UserStatus/UserStatus.tsx";
import { format } from "date-fns";

const UsersList = () => {
  const rows = users;
  const columns = [
    {
      field: "name",
      headerName: "Nazwa",
      flex: 1,
    },
    {
      field: "email",
      headerName: "Adres e-mail",
      flex: 1,
    },
    {
      field: "phoneNumber",
      headerName: "Numer telefonu",
      flex: 1,
    },
    {
      field: "status",
      headerName: "Status",
      flex: 1,
      renderCell: ({ row }: { row: User }) => {
        return <UserStatus status={row.status}></UserStatus>;
      },
    },
    {
      field: "dateCreated",
      headerName: "Data utworzenia",
      flex: 1,
      valueFormatter: ({ value }: { value: string }) =>
        format(new Date(value), "dd.MM.yyyy"),
    },
    // {
    //   field: "status",
    //   headerName: "Akcje",
    //   flex: 1,
    //   renderCell: ({ row: { name: name } }) => {
    //     return <div>test + {name}</div>;
    //   },
    // },
  ];

  return <DataGrid rows={rows} columns={columns} disableColumnMenu></DataGrid>;
};
export default UsersList;
