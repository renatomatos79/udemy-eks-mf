import React from 'react';
import ScopedCssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import FilterIcon from '@material-ui/icons/Search';
import { Grid } from '@material-ui/core';
import { makeStyles, useTheme, ThemeProvider } from '@material-ui/core/styles';
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

    const [rows, setRows] = React.useState([]);

    // Function to fetch data from the API
    const fetchUsers = async () => {
        try {
            const response = await fetch("http://localhost:5055/api/users");
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            setRows(data); // Update rows with fetched data
        } catch (error) {
            console.error("Error fetching users:", error);
        }
    };

    // Fetch users on component mount
    React.useEffect(() => {
        fetchUsers();
    }, []);

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
                            {rows.map((row) => (
                                <UserTableRow
                                    key={row.id} // Use unique key for each row
                                    id={row.id}
                                    name={row.name}
                                    email={row.email}
                                    roles={row.roles}
                                    isBlocked={row.isBlocked}
                                    isActive={row.isActive}
                                    imageUrl={row.imageUrl}
                                />
                            ))}
                        </Grid>

                    </Container>
                </ScopedCssBaseline>
            </React.Fragment>
        </ThemeProvider>
    );
}