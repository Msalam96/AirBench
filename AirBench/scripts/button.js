function toggleButton() {
    const form = document.getElementById('CreateBenchForm');
    const description = document.getElementById('Description');
    const latitude = document.getElementById('Latitude');
    const longitude = document.getElementById('Longitude');
    const seat = document.getElementById('Seats');
    let submitButton = document.getElementById('createButton');
    form.addEventListener('keyup', () => {
        if (description.value === '' || latitude.value === ''
        || longitude.value === '' || seat === '') {
            submitButton.disabled = true;
        }
        else {
            submitButton.disabled = false;
        }
    });
};

toggleButton();