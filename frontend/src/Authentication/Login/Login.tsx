import PetraStar from "../../../public/Authentication/Login/petra.svg";
import styles from "./Login.module.scss";
import LoginFormPanel from "./LoginFormPanel/LoginFormPanel";
import SignUpPanel from "./SignUpPanel/SignUpPanel";

const Login = () => {
  return (
    <main className={styles.loginPage}>
      <div className={styles.loginArtwork}>
        <img
          className={styles.loginArtworkImage}
          src={PetraStar}
          alt="Petra, Jordan"
        />
      </div>
      <LoginFormPanel  />
      <SignUpPanel />
    </main>
  );
};

export default Login;
