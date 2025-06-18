import React, { useState } from 'react';

function MyComponent() {
    const [inputValue, setInputValue] = useState('');
    const [responseMessage, setResponseMessage] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();

        const data = { Value: inputValue }; // Create the data object to send
        //The Content-Type header is set to application/json, which is important because the API expects data in JSON format
        try {
            const response = await fetch('http://localhost:5218/api/Data', { //  Replace with your API's URL
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json', // Very important!
                },
                body: JSON.stringify(data), // Convert the JavaScript object to a JSON string
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const responseData = await response.json(); // Parse the JSON response
            setResponseMessage(responseData.Message);
            console.log(responseData); // Log the entire response object

        } catch (error) {
            console.error('Error:', error);
            setResponseMessage(`Error: ${error.message}`);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>
                    Enter Value:
                    <input
                        type="text"
                        value={inputValue}
                        onChange={(e) => setInputValue(e.target.value)}
                    />
                </label>
                <button type="submit">Submit</button>
            </form>
            {responseMessage && <p>Response: {responseMessage}</p>}
        </div>
    );
}

export default MyComponent;