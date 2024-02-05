import styles from "./UserProfileField.module.scss";
import { useState } from "react";
import PencilIcon from "../../../assets/PencilIcon.tsx";
import AcceptIcon from "../../../assets/AcceptIcon.tsx";
import CloseIcon from "../../../assets/CloseIcon.tsx";

const UserProfileField = ({
  label,
  name,
  id,
  selectedField,
  fieldValue,
  onFieldChange,
  onSelectedFieldChange,
}: UserProfileFieldProps) => {
  const [value, setValue] = useState(fieldValue);
  const enableEditing = selectedField == id;
  const chosenAnotherField = !enableEditing && selectedField != "";

  const onValueChanged = (e: React.FormEvent<HTMLInputElement>) => {
    setValue(e.currentTarget.value);
  };

  const acceptValue = () => {
    onFieldChange(value, name);
    onSelectedFieldChange("");
  };

  const discardValue = () => {
    setValue(fieldValue);
    onSelectedFieldChange("");
  };

  return (
    <div className={styles.wrapper}>
      <label htmlFor={id}>{label}</label>
      {enableEditing ? (
        <div className={styles.rowContainer}>
          <div>
            <input
              name={name}
              id={id}
              type={"text"}
              value={value}
              onChange={onValueChanged}
            ></input>
          </div>
          <div>
            <button onClick={acceptValue}>
              <AcceptIcon />
            </button>
            <button onClick={() => discardValue()}>
              <CloseIcon />
            </button>
          </div>
        </div>
      ) : (
        <div className={styles.rowContainer}>
          <div>{value}</div>
          <div>
            {chosenAnotherField ? (
              <PencilIcon />
            ) : (
              <button onClick={() => onSelectedFieldChange(id)}>
                <PencilIcon />
              </button>
            )}
          </div>
        </div>
      )}
    </div>
  );
};

export interface UserProfileFieldProps {
  label: string;
  name: string;
  id: string;
  selectedField: string;
  fieldValue: string;
  onFieldChange: (value: string, id: string) => void;
  onSelectedFieldChange: (e: string) => void;
}
export default UserProfileField;
