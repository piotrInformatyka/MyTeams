import { users } from "../../data/usersData";
import UsersListItem from "./UsersListItem";
import styles from "./UsersList.module.scss";

const UsersList = () => (
  <div className={styles.user}>
    <ul>
      {users.map((user) => (
        <UsersListItem {...user}></UsersListItem>
      ))}
    </ul>
  </div>
);

export default UsersList;
