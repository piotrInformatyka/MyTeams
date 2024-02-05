import { DataGrid } from "@mui/x-data-grid";
import { User, users } from "../../data/usersData.tsx";
import UserStatus from "../UserStatus/UserStatus.tsx";
import { format } from "date-fns";
import { useState } from "react";
import { Modal } from "@mui/material";
import UserProfile from "../UserProfile/UserProfile.tsx";

const UsersList = () => {
  const [openUserProfile, setOpenUserProfile] = useState({
    open: false,
    userId: 0,
  });

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
    {
      field: "actions",
      headerName: "Akcje",
      flex: 1,
      renderCell: ({ row }: { row: User }) => {
        return (
          <button
            onClick={() => setOpenUserProfile({ open: true, userId: row.id })}
          >
            {row.name}
          </button>
        );
      },
    },
  ];

  return (
    <div>
      <DataGrid rows={rows} columns={columns} disableColumnMenu></DataGrid>
      <Modal
        open={openUserProfile.open}
        onClose={() => setOpenUserProfile({ ...openUserProfile, open: false })}
      >
        <UserProfile
          user={users.find((x) => x.id == openUserProfile.userId)}
        ></UserProfile>
      </Modal>
    </div>
  );
};
export default UsersList;
