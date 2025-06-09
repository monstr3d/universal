import React, { Component, useState }from 'react';
import DatePicker from 'react-datepicker';
import moment from 'moment';
 
import 'react-datepicker/dist/react-datepicker.css';
import 'bootstrap/dist/css/bootstrap.min.css';

class Comp3 extends Component {

    defaultShow = true;//default state of calendar pop-up
    defaultValue = new Date(); //default value

    
    constructor (props) {
    super(props)
    this.state = {
      startDate: moment()
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(date) {
    this.setState({
      startDate: date
    })
  }

  handleSubmit(x) {
    x.preventDefault();
    let main = this.state.startDate //mistake here?
    console.log(main.format('L'));
  }

  render() {
    return (
      <div className = "container">
        <h3>Datepicker</h3>
        <form onSubmit={ this.handleSubmit }>
          <div>
            <label>Select Date: </label>

            <DatePicker
              defaultValue={this.defaultValue}
              defaultShow={this.defaultShow}
              disabled={true}
              placeholderText="Select date here"
              selected={ this.state.startDate }
              onChange={ this.handleChange }
              name="startDate"
              dateFormat="MM/DD/YYYY"
              dateCaptions="Date"
              isClearable
              showYearDropdown
              scrollMonthYearDropdown
              showTimeSelect
              timeCaption="Time"
              timeFormat="HH:mm"
              timeIntervals={30}
            />

          </div>
          <div>
            <button className="btn">Add Date</button>
          </div>
        </form>
      </div>
    );
  }
}

export default Comp3