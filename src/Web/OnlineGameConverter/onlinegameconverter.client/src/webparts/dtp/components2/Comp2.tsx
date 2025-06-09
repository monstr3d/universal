import React, { Component, useState }from 'react';
import TimePicker from 'react-time-picker'
import moment from 'moment';
import ReactDOM from "react-dom"
import 'react-datepicker/dist/react-datepicker.css';
import 'bootstrap/dist/css/bootstrap.min.css';

class Comp2 extends React.Component
{

    defaultShow = true;//default state of calendar pop-up
    defaultValue= true;

    state={
        time:'00:00',
    }

    onChange=(time: any) => this.setState({ time })
    
    handleSubmit(x) {
        x.preventDefault();
        let main = this.state.time
        console.log(main.format('L'));
      }
    
    render()
    {
        return (
            <div className="container">
                <h3>Timepicker</h3>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label>Select Date: </label>
          
                        <TimePicker
                            defaultValue={this.defaultValue}
                            defaultShow={this.defaultShow}
                            disabled={true}
                            placeholderText="Select time here"
                            onChange={this.onChange}
                            value={this.state.time}
                        />
          </div>
          <div>
            <button className="btn">Add Time</button>
          </div>
        </form>
      </div>
       );
      }
}

export default Comp2