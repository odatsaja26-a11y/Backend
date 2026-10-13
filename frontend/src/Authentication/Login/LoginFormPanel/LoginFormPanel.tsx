import styles from "./LoginFormPanel.module.scss";
import mountainLines from "../../../assets/mountain-lines.png";
const LoginFormPanel = () => {
  return (
    <div className={styles.loginFormPanel} aria-labelledby="loginTitle">
      <h1 className={styles.loginTitle} id="loginTitle">
        Login
      </h1>
      <div>
        <p className={styles.loginIntro}>
          Log in to access your saved trips and continue your journey with
          GoFun.
        </p>

        <form className={styles.loginForm}>
          <div className={styles.loginField}>
            <label className={styles.loginLabel} htmlFor="loginEmail">
              Email
            </label>
            <input
              className={styles.loginInput}
              id="loginEmail"
              type="text"
              placeholder="Enter your email"
            />
          </div>
          <div className={styles.loginField}>
            <label className={styles.loginLabel} htmlFor="loginPassword">
              Password
            </label>
            <input
              className={styles.loginInput}
              id="loginPassword"
              type="password"
              placeholder="Enter your password"
            />
          </div>
          <button className={styles.forgotPassword} type="button">
            Forgot password?
          </button>
          <button className={styles.loginSubmit} type="submit">
            Log In
          </button>
        </form>

        <div className={styles.formDivider}>
          <span>or</span>
        </div>
        <button className={styles.signupLink} type="button">
          <span>Create a new account</span>
          <span className={styles.signupArrow} aria-hidden="true">
            &#8594;
          </span>

      </button>


    </div>
  </div>

  );
};

export default LoginFormPanel;
