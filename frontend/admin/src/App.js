import React from 'react';
import { Switch, Route, Router } from 'react-router-dom';
import {
  StylesProvider,
  createGenerateClassName,
} from '@material-ui/core/styles';

import Landing from './components/Landing';
import Pricing from './components/Pricing';
import UserList from './components/pages/users/UserList';
import Home from './components/pages/home/Home';

const generateClassName = createGenerateClassName({
  productionPrefix: 'ma',
});

export default ({ history }) => {
  return (
    <div>
      <StylesProvider generateClassName={generateClassName}>
        <Router history={history}>
          <Switch>
            <Route exact path="/pricing" component={Pricing} />
            <Route path="/landing" component={Landing} />
            <Route path="/users" component={UserList} />
            <Route path="/home" component={Home} />
          </Switch>
        </Router>
      </StylesProvider>
    </div>
  );
};
