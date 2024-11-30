import React from 'react';
import FormControl from '@material-ui/core/FormControl';
import FormGroup from '@material-ui/core/FormGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Switch from '@material-ui/core/Switch';
import Typography from '@material-ui/core/Typography';


export default function UserRoles() {
  const [state, setState] = React.useState({
    admin: true,
    dashboard: false
  });

  const handleChange = (event) => {
    setState({ ...state, [event.target.name]: event.target.checked });
  };

  return (
    <FormControl component="fieldset">
      <FormGroup>
        <FormControlLabel
          control={<Switch checked={state.admin} onChange={handleChange} name="admin" color="primary" />}
          label={
            <Typography variant="caption">
              Admin
            </Typography>
          }
        />
        <FormControlLabel
          control={<Switch checked={state.dashboard} onChange={handleChange} name="dashboard" color="primary" />}
          label={
            <Typography variant="caption">
              Dashboard
            </Typography>
          }
        />
      </FormGroup>
    </FormControl>
  );
}