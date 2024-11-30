import React from 'react';
import { Box, Grid } from '@material-ui/core';
import Paper from '@material-ui/core/Paper';
import { EmailIcon, SecurityIcon, LightIcon, UserIcon } from '@/components/atoms/icons/SvgIcons';
import { makeStyles } from '@material-ui/core/styles';
import StyledCheckbox from '@/components/atoms/checkbox/StyledCheckbox';
import TableColumnHeader from '@/components/organisms/table/TableColumnHeader';

export default function UserTableHeader() {
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
                <Grid container item xs={1} justifyContent="flex-start">
                    Avatar
                </Grid>
                <Grid container item xs={2} alignItems="flex-start">
                    <TableColumnHeader enabledSort={true}>
                        Nome
                    </TableColumnHeader>
                </Grid>
                <Grid container item xs={3} alignItems="center">
                    <TableColumnHeader enabledSort={true}>
                        <EmailIcon /> Email
                    </TableColumnHeader>
                </Grid>
                <Grid container item xs={2} alignItems="flex-start">
                    <TableColumnHeader >
                        <SecurityIcon /> Permissões
                    </TableColumnHeader>
                </Grid>
                <Grid container item xs={1} alignItems="flex-start">
                    <TableColumnHeader >
                        <UserIcon /> Status
                    </TableColumnHeader>
                </Grid>
                <Grid container item xs={2} justifyContent="center">
                    <TableColumnHeader >
                        <LightIcon /> Ações
                    </TableColumnHeader>
                </Grid>
            </Grid>
        </Paper>
    )
}