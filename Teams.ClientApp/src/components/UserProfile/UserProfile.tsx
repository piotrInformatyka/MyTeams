import styles from "./UserProfile.module.scss";
import UserProfileField from "./UserProfileField/UserProfileField.tsx";
import { useState } from "react";
import UserStatus from "../UserStatus/UserStatus.tsx";

const UserProfile = () => {
  const [selectedField, setSelectedField] = useState("");
  const [userFields, setUserFields] = useState({
    name: "",
    email: "",
    phoneNumber: "",
  });

  const handleUserFieldChange = (newValue: string, id: string) => {
    setUserFields({ ...userFields, [id]: newValue });
  };

  const handleSelectedField = (newValue: string) => {
    setSelectedField(newValue);
  };

  return (
    <div className={styles.container}>
      <h3>Jan Kowalski</h3>
      <div className={styles.wrapper}>
        <div className={styles.imageSection}>
          <img
            src={
              "https://s3-alpha-sig.figma.com/img/63d6/0ced/b2f762c0ae0902a87c3bca861a6c664f?Expires=1708300800&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=TVppZy4DJLcmhMWz5SdQTxN8O2IT5fkHepvkZs0V8qMwnSuVG68qTJmVX8v-a58Ihhy19Abnhf1~Tfly5Xl2D0PcRGqoy~vZlvunTqcBuqwwsqATeSHB2gBJIXKVyHFFnjQjV-O4qlswDm3X9CTdKhC18gNvi2QoCsZNau9o~kHHYg9MfeD5NiKSic9RaWDUFr6DTZEoypQ1V5U-4RCdtLOU2~A9PkBsPfStOlW0FD~Och2kNYJCeubcMmziM7wzaGWM7qyxCqBxK6urhh7EmP8Y4rj6unvPAz075DwcSX523n4Q9sDbSsgZJTgDAbwhYL~mjZgxIjGf6EgvNX2-mA__"
            }
          />
          <UserStatus status={true}></UserStatus>
        </div>
        <div>
          <UserProfileField
            label={"Nazwa"}
            name={"name"}
            id={"name"}
            selectedField={selectedField}
            fieldValue={userFields.name}
            onFieldChange={handleUserFieldChange}
            onSelectedFieldChange={handleSelectedField}
          />
          <UserProfileField
            label={"Adres e-mail"}
            name={"email"}
            id={"email"}
            selectedField={selectedField}
            fieldValue={userFields.email}
            onFieldChange={handleUserFieldChange}
            onSelectedFieldChange={handleSelectedField}
          ></UserProfileField>
          <UserProfileField
            label={"Numer telefonu"}
            name={"phoneNumber"}
            id={"phoneNumber"}
            selectedField={selectedField}
            fieldValue={userFields.phoneNumber}
            onFieldChange={handleUserFieldChange}
            onSelectedFieldChange={handleSelectedField}
          ></UserProfileField>
        </div>
      </div>
      <button className={styles.closeButton}>Zamknij</button>
    </div>
  );
};

export default UserProfile;
