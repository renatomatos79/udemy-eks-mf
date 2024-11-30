import React from 'react';
import { Grid } from '@material-ui/core';
import Paper from '@material-ui/core/Paper';
import Avatar from '@material-ui/core/Avatar';
import DropDownButton from '@/components/organisms/buttons/DropDownButton/DropDownButton';
import UserRoles from '@/components/organisms/user/UserRoles';
import { CheckedIcon } from '@/components/atoms/icons/SvgIcons';
import { makeStyles, useTheme, ThemeProvider } from '@material-ui/core/styles';
import StyledCheckbox from '@/components/atoms/checkbox/StyledCheckbox';

export default function UserTableRow({ user }) {

    const useStyles = makeStyles((theme) => ({
        paper: {
            padding: theme.spacing(1),
            textAlign: 'center',
            color: theme.palette.text.secondary,
            whiteSpace: 'nowrap',
            marginBottom: theme.spacing(1),
            width: '100%',
        }
    }));

    const classes = useStyles();

    return (
        <Paper className={classes.paper}>
            <Grid container item xs={12} justifyContent="flex-start" alignItems="center">
                <Grid container item xs={1} justifyContent="flex-start">
                    <StyledCheckbox />
                </Grid>
                <Grid item xs={1}>
                    <Avatar alt="Remy Sharp" src="https://v4.mui.com/static/images/avatar/1.jpg" />
                </Grid>
                <Grid container item xs={2} justifyContent="flex-start">
                    Renato Matos
                </Grid>
                <Grid container item xs={3} justifyContent="flex-start">
                    renato.matos79gmail.com
                </Grid>
                <Grid container item xs={2} justifyContent="flex-start">
                    <UserRoles />
                </Grid>
                <Grid container item xs={1} justifyContent="center" direction="column">
                    <div>
                        <CheckedIcon color="green" />
                    </div>
                    <div>
                        Active
                    </div>
                </Grid>
                <Grid container item xs={2} justifyContent="center">
                    <DropDownButton />
                </Grid>
            </Grid>
        </Paper>
    )
}