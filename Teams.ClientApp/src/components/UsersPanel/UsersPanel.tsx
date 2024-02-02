import styles from "./UsersPanel.module.scss";

const UsersPanel = () => (
  <div className={styles.wrapper}>
    <div className={styles.container}>
      <div className={styles.header}>
        <h3 className={styles.title}>Lista członków zespołu</h3>
        <p>Zarządzaj listą członków swojego zespołu</p>
      </div>
      <div className={styles.buttons}>
        <button>Zaimportuj członka zespołu</button>
        <button>Dodaj członka zespołu</button>
      </div>
    </div>
  </div>
);

export default UsersPanel;
