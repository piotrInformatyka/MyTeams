const UsersListItem = (userData: UsersListItemProps) => {
  const { email, name, phoneNumber } = userData;
  return (
    <li>
      <div>{userData.email}</div>
      <div>{email}</div>
    </li>
  );
};

type UsersListItemProps = {
  name: string;
  email: string;
  phoneNumber: string;
};

export default UsersListItem;
