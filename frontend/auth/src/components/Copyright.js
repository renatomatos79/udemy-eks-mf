import React from 'react';
import Typography from '@material-ui/core/Typography';

export default function Copyright() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {'Copyright © '}
      <a href="https://www.linkedin.com/in/renatomatos/" target="_blank" rel="noopener noreferrer" style={{ textDecoration: 'none' }}>
        Renato Matos 
      </a>
    </Typography>
  );
}

