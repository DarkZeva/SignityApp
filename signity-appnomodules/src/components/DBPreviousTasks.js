import React, {useEffect} from "react";
import { connect } from "react-redux";
import * as actions from "../actions/dbPreviousTasks";
import {Grid, Paper } from "@material-ui/core";
import DBPreviousTasksForm from "./DBPreviousTasksForm";

const DBPreviousTasks = (props) => {
    useEffect(()=>{
        props.fetchAllDBPreviousTasks()
    },[])
    return (
        <Paper elevation={10}>
            <Grid container>
                <Grid item xs={6}>
                    <DBPreviousTasksForm/>
                </Grid>
                <Grid item xs={6}>
                    <div>
                        {                           
                            props.dbPreviousTasksList.map((record, index)=>{
                                return (
                                <div class="resultTable" id="list" key={index}>
                                    
                                    <div class="resultElement">
                                        <div class="resultLabel" id="itemID">
                                            <label style={{fontSize: "20px"}}>Task number: {index + 1} </label>
                                        </div>
                                        <div class="result">
                                            <div id="item1">
                                                <label>Occurrences: </label>
                                                {record.count}
                                            </div>
                                            <div id="item2">
                                                <label>Todays date: </label>
                                                {record.todaysDate.substring(0,10)}
                                            </div>
                                            <div id="item3">
                                                <label>First occurrence: </label>
                                                {record.firstOccurrenceDate.substring(0,10)}
                                            </div>
                                            <div id="item4">
                                                <label>Previous occurrence: </label>
                                                {record.previousOccurenceDate.substring(0,10)}
                                            </div>
                                            <div id="item5">
                                                <label>Next occurrence: </label>
                                                {record.nextOccurrenceDate.substring(0,10)}
                                            </div>
                                        </div>
                                    </div>
                                    <p></p>
                                </div>
                                )
                            })
                        }
                    </div>
                </Grid>              
            </Grid>
        </Paper>
    );
}

const mapStateToProps = state => ({
    dbPreviousTasksList: state.dbPreviousTasks.list.reverse()
})

const mapActionToProps ={
    fetchAllDBPreviousTasks: actions.fetchAll
}

export default connect(mapStateToProps,mapActionToProps)(DBPreviousTasks);