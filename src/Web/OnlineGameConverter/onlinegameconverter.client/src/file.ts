fetch('https://api.example.com/redirect', {
    method: 'GET',
    redirect: 'follow', //  'follow', 'error', 'manual'
})
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        console.log("Final URL:", response.url);  // The final redirected URL
        return response.json();
    })
    .then(data => {
        console.log(data);
    })
    .catch(error => {
        console.error('Fetch error:', error);
    });