import React from 'react';
import ScopedCssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import SearchIcon from '@material-ui/icons/Search';
import FilterIcon from '@material-ui/icons/Search';
import { Box, Grid } from '@material-ui/core';
import { makeStyles, useTheme, ThemeProvider } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import UserTableRow from '@/components/organisms/user/table/UserTableRow';
import UserTableHeader from '@/components/organisms/user/table/UserTableHeader';
import { EmailIcon, SecurityIcon } from '@/components/atoms/icons/SvgIcons';


export default function FixedContainer() {
    const theme = useTheme();

    const useStyles = makeStyles((theme) => ({
        container: {
            display: 'grid',
            gridTemplateColumns: 'repeat(12, 1fr)',
            gridGap: theme.spacing(3),
        },
        title: {
            margin: theme.spacing(1, 0),
        },
        paper: {
            padding: theme.spacing(1),
            textAlign: 'center',
            color: theme.palette.text.secondary,
            whiteSpace: 'nowrap',
            marginBottom: theme.spacing(1),
            width: '100%',
        },
        divider: {
            margin: theme.spacing(2, 0),
        },
    }));

    const classes = useStyles();


    const rows = [
        { id: 1, lastName: 'Snow', firstName: 'Jon', age: 35 },
        { id: 2, lastName: 'Lannister', firstName: 'Cersei', age: 42 },
        { id: 3, lastName: 'Lannister', firstName: 'Jaime', age: 45 },
        { id: 4, lastName: 'Stark', firstName: 'Arya', age: 16 },
        { id: 5, lastName: 'Targaryen', firstName: 'Daenerys', age: null },
        { id: 6, lastName: 'Melisandre', firstName: null, age: 150 },
        { id: 7, lastName: 'Clifford', firstName: 'Ferrara', age: 44 },
        { id: 8, lastName: 'Frances', firstName: 'Rossini', age: 36 },
        { id: 9, lastName: 'Roxie', firstName: 'Harvey', age: 65 },
    ];


    return (
        <ThemeProvider theme={theme}>
            <React.Fragment>
                <ScopedCssBaseline>
                    <Container maxWidth="md" direction="column">
                        <Grid container spacing={1} className={classes.title} >
                            <Grid container item xs={4} justifyContent="flex-start">
                                <Fab color="primary" aria-label="add" size="small">
                                    <AddIcon />
                                </Fab>
                            </Grid>
                            <Grid item xs={4} >
                                <Typography variant="h6" align="center">
                                    Usuários
                                </Typography>
                            </Grid>
                            <Grid container item xs={4} justifyContent="flex-end">
                                <Fab color="secondary" aria-label="add" size="small">
                                    <FilterIcon />
                                </Fab>
                            </Grid>
                        </Grid>

                        <Grid container item xs={12} direction="column" >
                            <UserTableHeader />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                            <UserTableRow />
                        </Grid>

                    </Container>
                </ScopedCssBaseline>
            </React.Fragment>
        </ThemeProvider>
    );
}