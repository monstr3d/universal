// DateTimeControl.tsx

import React, { useState, useEffect } from 'react';
import DatePicker from 'react-datepicker';  // You'll need to install: npm install react-datepicker date-fns
import 'react-datepicker/dist/react-datepicker.css';

import TimePicker from 'react-time-picker';   // You'll need to install: npm install react-time-picker

import 'react-time-picker/dist/TimePicker.css';

import { format, parseISO } from 'date-fns';  // Optional, for formatting

interface DateTimeControlProps {
    label: string;
    value?: Date | string | null; // Allow Date object, ISO string, or null
    onChange: (newDateTime: Date | null) => void;
    dateFormat?: string; // Optional date format, defaults to yyyy-MM-dd
    timeFormat?: string; // Optional time format, defaults to HH:mm
    placeholderText?: string;
    disabled?: boolean;
    required?: boolean;
    className?: string; // For custom styling
    id?: string;
    name?: string;
}

const DateTimeControl: React.FC<DateTimeControlProps> = ({
    label,
    value,
    onChange,
    dateFormat = 'yyyy-MM-dd',
    timeFormat = 'HH:mm',
    placeholderText = 'Select Date and Time',
    disabled = false,
    required = false,
    className = '',
    id = '',
    name = '',
}) => {
    const [selectedDate, setSelectedDate] = useState<Date | null>(null);
    const [selectedTime, setSelectedTime] = useState<string | null>(null); // Time as string (HH:mm)


    // Handle initial value population if it's provided
    useEffect(() => {
        if (value) {
            let initialDate: Date | null = null;

            if (typeof value === 'string') {
                try {
                    initialDate = parseISO(value); // Attempt to parse as ISO string
                } catch (error) {
                    console.error("Invalid date string:", value, error);
                    initialDate = null; // Handle invalid date string
                }
            } else if (value instanceof Date) {
                initialDate = value;
            }

            if (initialDate) {
                setSelectedDate(initialDate);
                setSelectedTime(format(initialDate, timeFormat));
            }
        } else {
            setSelectedDate(null);
            setSelectedTime(null);
        }
    }, [value, timeFormat]);  // Dependency on value and timeFormat so it updates when those change.



    const handleDateChange = (date: Date | null) => {
        setSelectedDate(date);
        combineDateTime(date, selectedTime);
    };


    const handleTimeChange = (time: string | null) => {
        setSelectedTime(time);
        combineDateTime(selectedDate, time);
    };


    const combineDateTime = (date: Date | null, time: string | null) => {
        if (date && time) {
            try {
                const [hours, minutes] = time.split(':').map(Number);
                const newDateTime = new Date(date);
                newDateTime.setHours(hours);
                newDateTime.setMinutes(minutes);
                newDateTime.setSeconds(0);
                newDateTime.setMilliseconds(0);
                onChange(newDateTime);
            } catch (error) {
                console.error("Error combining date and time:", error);
                onChange(null);  // Or handle the error appropriately.
            }
        } else {
            onChange(null); // Clear value if either date or time is cleared
        }
    };




    return (
        <div className={`date-time-control ${className}`}>
            <label htmlFor={id} className="date-time-label">{label}{required && ' *'}</label>
            <div className="date-time-inputs">
                <DatePicker
                    id={id}
                    name={`${name}-date`}
                    selected={selectedDate}
                    onChange={handleDateChange}
                    dateFormat={dateFormat}
                    placeholderText={placeholderText}
                    disabled={disabled}
                    required={required}
                    className="date-picker"
                    isClearable
                />
                <TimePicker
                    name={`${name}-time`}
                    value={selectedTime}
                    onChange={handleTimeChange}
                    format={timeFormat}
                    disabled={disabled}
                    className="time-picker"
                    clearIcon={null} // Optional:  Remove the default clear icon
                />
            </div>
        </div>
    );
};

export default DateTimeControl;