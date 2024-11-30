import React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { Link } from 'react-router-dom';
import Copyright from './Copyright';
import VpnKeyIcon from '@material-ui/icons/VpnKey';
import { validateFirstName, validateLastName, validateEmail, validatePassword, validateConfirmPassword } from '@/libs';

const useStyles = makeStyles((theme) => ({
  '@global': {
    a: {
      textDecoration: 'none',
    },
  },
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.primary.main,
  },
  form: {
    width: '100%',
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

export default function SignUp({ onSignIn }) {
  const classes = useStyles();

  const [firstName, setFirstName] = React.useState(''); 
  const [lastName, setLastName] = React.useState(''); 
  const [email, setEmail] = React.useState(''); 
  const [password, setPassword] = React.useState(''); 
  const [confirmPassword, setConfirmPassword] = React.useState(''); 
  const [errors, setErrors] = React.useState({ email: "", password: "", confirmPassword: "", firstName: "", lastName: "" });

  const handleSingUp = (event) => {
    event.preventDefault();

    const firstNameError = validateFirstName(firstName);
    const lastNameNameError = validateLastName(lastName);
    const emailError = validateEmail(email);
    const passwordError = validatePassword(password);
    const confirmPasswordError = validateConfirmPassword(password, confirmPassword);
    const hasError = emailError || passwordError || confirmPasswordError || firstNameError || lastNameNameError 

    if (hasError) {
      setErrors({ 
        email: emailError, 
        password: passwordError, 
        confirmPassword: confirmPasswordError,
        firstName: firstNameError,
        lastName: lastNameNameError });
    } else {
      onSignIn(firstName, email, password);
    }
  }

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
      <Avatar className={classes.avatar}>
          <VpnKeyIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          {'Criar uma conta'}
        </Typography>
        <form
          onSubmit={(e) => e.preventDefault()}
          className={classes.form}
          noValidate
        >
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <TextField
                autoFocus
                error={errors.firstName !== ""}
                autoComplete="fname"
                name="firstName"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="First Name"
                helperText={errors.firstName}
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                required
                error={errors.lastName !== ""}
                variant="outlined"
                fullWidth
                id="lastName"
                label="Last Name"
                name="lastName"
                autoComplete="lname"
                helperText={errors.lastName}
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                error={errors.email !== ""}
                variant="outlined"
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
                helperText={errors.email}
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                error={errors.password !== ""}
                variant="outlined"
                name="password"
                label="Password"
                type="password"
                id="password"
                helperText={errors.password}
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                error={errors.confirmPassword !== ""}
                variant="outlined"
                name="confirmPassword"
                label="Confirm Password"
                type="password"
                id="confirmPassword"
                helperText={errors.confirmPassword}
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
              />
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={handleSingUp}
          >
            CADASTRE-SE
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link to="/auth/signin">{"Já tenho uma conta"}</Link>
            </Grid>
          </Grid>
        </form>
      </div>
      <Box mt={5}>
        <Copyright />
      </Box>
    </Container>
  );
}
