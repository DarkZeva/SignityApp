import React from "react";
import axios from "axios";

const date = new Date();

let day = String(date.getDate()-1).padStart(2,'0');
let month = String(date.getMonth() + 1).padStart(2,'0');
let year = date.getFullYear();
let currentDate = `${year}-${month}-${day}`;

function postData(){
    let startingDate = document.getElementById("task-start").value
    let day = document.getElementById("day").value
    let interval = document.getElementById("interval").value
    debugger
    
    let data={
        startingDate: startingDate,
        day: day,
        interval: interval
    }
    
    axios.post("http://localhost:5189/api/DBPreviousTasks",data)
    .then((response) => {
        console.log("sukces"  + response)
    })
    .catch((error) => {
        console.log(error)
    })
    
}

const DBPreviousTasksForm = (props) => {
    return (
        <form action="">
            <div>
                <label>Starting date:</label>
                <div>
                    <input type="date" id="task-start" name="task-start" min="1000-01-01" max={currentDate}/>
                </div>
                <label>Day of week:</label>
                <div>
                    <select id="day" name="day">
                        <option value="mon">Monday</option>
                        <option value="tue">Tuesday</option>
                        <option value="wed">Wednesday</option>
                        <option value="thu">Thursday</option>
                        <option value="fri">Friday</option>
                        <option value="sat">Saturday</option>
                        <option value="sun">Sunday</option>
                    </select>
                </div>
                <label>Interval:</label>
                <div >
                    <input type="number" id="interval" name="interval" min="1"/>
                </div>
                <div>
                    <button class="button" onClick={postData}>Submit</button>
                </div>
            </div>
        </form>     
    )
}

export default DBPreviousTasksForm;