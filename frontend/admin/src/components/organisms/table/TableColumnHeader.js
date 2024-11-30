import React from 'react';
import { Box } from '@material-ui/core';
import { SortAlphaUpIcon, SortAlphaDownIcon } from '@/components/atoms/icons/SvgIcons';
import { makeStyles, useStyles } from '@material-ui/core';

export default function TableColumnHeader({ children, enabledSort }) {
    
    
    const [ascending, setAscending] = React.useState(true);

    function handleClick(event) {
        event.preventDefault();
        setAscending(!ascending);
    }

    return (
        <div>
            {enabledSort && <a href="#" onClick={handleClick}>
                {!ascending && <SortAlphaUpIcon />}
                {ascending && <SortAlphaDownIcon />}
            </a>}
            <Box component="span" ml={1}>
                {children}
            </Box>
        </div>
    )
}