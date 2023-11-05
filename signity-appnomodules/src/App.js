import React from 'react';
import './App.css';
import { store } from "./actions/store"
import { Provider } from 'react-redux';
import DBPreviousTasks from './components/DBPreviousTasks';
import { Container } from "@material-ui/core";

function App() {
  return (
    <Provider store={store}>
      <Container maxWidth="lg">       
            <DBPreviousTasks/>
      </Container>
    </Provider>
  );
}

export default App;
