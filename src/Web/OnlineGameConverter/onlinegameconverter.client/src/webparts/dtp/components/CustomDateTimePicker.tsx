import DatePicker from "react-datepicker";
import TimePicker from 'react-time-picker'
import 'bootstrap/dist/css/bootstrap.min.css';  
import "react-datepicker/dist/react-datepicker.css";  
import * as React from "react";
import { useState } from "react";

interface DatePickerProps
{
    dateTimePicker:boolean;
    timePicker:boolean;
    className:string;
}


export default class CustomDateTimePicker extends React.Component<DatePickerProps, {}> 
{   
  defaultShow = true;
  defaultValue = new Date();
    public render()
    {
      
      const [selectedDate,setSelectedDate]= useState(null)
      const [selectedTime,setSelectedTime]= useState(null)
        
        return ( //3 condition ternary operator used
                 (this.props.timePicker) ? ((this.props.dateTimePicker)?
                 <DatePicker disabled={true} placeholderText="Your date and time"
                                  dateFormat="dd/MM/yyyy"
                                  showTimeSelect
                                  timeCaption="Time"
                                  dateCaption="Date"
                                  selected={selectedDate}
                                  onChange={(date: any) => {
                                    return setSelectedDate(date);
                                  }}
                                  defaultShow={this.defaultShow}
                                  defaultValue={this.defaultValue} /> :
                 <TimePicker  disabled={true} placeholderText="Your time"
                              timeFormat="h:MM TT"
                              selected={selectedTime}
                              onChange={(time: any) => 
                                {
                                return setSelectedTime(time);
                                }}
                              timeIntervals={30}
                              defaultShow={this.defaultShow} />)

                  : ((this.props.dateTimePicker)? 
                  <DatePicker disabled={true} placeholderText="Your date and time"
                                  dateFormat="dd/MM/yyyy"
                                  timeFormat="h:MM TT"
                                  showTimeSelect
                                  timeCaption="Time"
                                  dateCaption="Date"
                                  selected={selectedDate}
                                  onChange={(date: any) => {
                                    return setSelectedDate(date);
                                  }}
                                  defaultShow={this.defaultShow}
                                  defaultValue={this.defaultValue} />:
                  <DatePicker disabled={true} placeholderText="Your date"
                              dateFormat="dd/MM/yyyy"
                              isClearable
                              showYearDropdown
                              scrollableMonthYearDropdown
                              selected={selectedDate}
                              onChange={(date: any) => {
                                return setSelectedDate(date);
                              }}
                              defaultShow={this.defaultShow} 
                              defaultValue={this.defaultValue}/>)
                );
    }
  }
  
