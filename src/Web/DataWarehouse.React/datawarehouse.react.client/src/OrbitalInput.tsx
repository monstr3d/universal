// Example usage in a parent component:
//import React, { useState } from 'react';
import { useState } from 'react';
import DateTimeControl from './DateTimeControl';

function ObritalInput() {

    const [selectedDateTime, setDateTime] = useState<Date | null>(null);

    const handleDateTimeChange = (newDateTime: Date | null) => {
        setDateTime(newDateTime);
        console.log('Selected DateTime:', newDateTime);
    };

    return (
        <div>
            <DateTimeControl
                label="Appointment Date and Time"
                value={selectedDateTime}
                onChange={handleDateTimeChange}
                dateFormat="MM/dd/yyyy" // Customize date format
                timeFormat="HH:mm"      // Customize time format
                placeholderText="Choose an appointment"
                required
            />
            {selectedDateTime && (
                <p>Selected Date and Time: {selectedDateTime.toLocaleString()}</p>
            )}
        </div>
    );
}

export default ObritalInput;

