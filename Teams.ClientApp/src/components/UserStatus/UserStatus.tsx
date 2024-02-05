import styles from "./UsersStatus.module.scss";

const UserStatus = ({ status }: { status: boolean }) =>
  status ? (
    <div className={`${styles.userStatusActive} ${styles.userStatus}`}>
      Aktywny
    </div>
  ) : (
    <div className={`${styles.userStatusBlocked} ${styles.userStatus}`}>
      Zablokowany
    </div>
  );
export default UserStatus;
