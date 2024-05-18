// Get form elements
const form = document.querySelector('form');
const firstNameInput = document.getElementById('firstName');
const lastNameInput = document.getElementById('lastName');
const dobMonthInput = document.getElementById('dobMonth');
const dobDayInput = document.getElementById('dobDay');
const dobYearInput = document.getElementById('dobYear');

// Populate date dropdowns
populateDateDropdowns();
var isSubmitted = false;

form.addEventListener('reset', function (event) {
    document.getElementById('lastName') = "";
    document.getElementById('dobMonth') = "";
    document.getElementById('dobDay') = "";
   document.getElementById('dobYear') = "";
}),

// Add event listener to form submission
form.addEventListener('submit', function (event) {
   
    event.preventDefault(); // Prevent form submission

    // Validate form fields
    const isValid = validateFormFields();

    if (isValid) {
        
       
        $("#payplan").fadeOut(100);
        $("#submissionCard").fadeIn(1000)
        // Form is valid, you can submit the data
        submitFormData();

        
        
    }
});

// Function to validate form fields
function validateFormFields() {
    let isValid = true;

    // Validate first name
    if (firstNameInput.value.trim() === '') {
        isValid = false;
        firstNameInput.classList.add('invalid');
    } else {
        firstNameInput.classList.remove('invalid');
    }

    // Validate last name
    if (lastNameInput.value.trim() === '') {
        isValid = false;
        lastNameInput.classList.add('invalid');
    } else {
        lastNameInput.classList.remove('invalid');
    }

    // Validate date of birth
    const selectedDate = new Date(dobYearInput.value, dobMonthInput.value - 1, dobDayInput.value);
    const today = new Date();
    if (selectedDate > today) {
        isValid = false;
        dobMonthInput.classList.add('invalid');
        dobDayInput.classList.add('invalid');
        dobYearInput.classList.add('invalid');
    } else {
        dobMonthInput.classList.remove('invalid');
        dobDayInput.classList.remove('invalid');
        dobYearInput.classList.remove('invalid');
    }

    return isValid;
}

// Function to populate date dropdowns
function populateDateDropdowns() {
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    const currentYear = new Date().getFullYear();

    // Populate month dropdown
    for (let i = 0; i < months.length; i++) {
        const option = document.createElement('option');
        option.value = i + 1;
        option.text = months[i];
        dobMonthInput.add(option);
    }

    // Populate day dropdown
    populateDayDropdown(dobDayInput, dobMonthInput.value, dobYearInput.value);

    // Populate year dropdown
    for (let i = currentYear - 100; i <= currentYear; i++) {
        const option = document.createElement('option');
        option.value = i;
        option.text = i;
        if (option.value == 2000) {
            option.selected = true;
        }
        dobYearInput.add(option);
    }

    // Add event listeners to month and year dropdowns
    dobMonthInput.addEventListener('change', function () {
        populateDayDropdown(dobDayInput, this.value, dobYearInput.value);
    });

    dobYearInput.addEventListener('change', function () {
        populateDayDropdown(dobDayInput, dobMonthInput.value, this.value);
    });
}

function populateDayDropdown(dayDropdown, month, year) {
    // Clear existing options
    dayDropdown.innerHTML = '';

    const daysInMonth = new Date(year, month, 0).getDate();

    // Populate day dropdown
    for (let i = 1; i <= daysInMonth; i++) {
        const option = document.createElement('option');
        option.value = i;
        option.text = i;
        dayDropdown.add(option);
    }
}

function submitFormData() {
   
    const formData = {
        firstName: firstNameInput.value,
        lastName: lastNameInput.value,
        dob: `${dobMonthInput.value}/${dobDayInput.value}/${dobYearInput.value}`
    };
    console.log(formData);
}
window.addEventListener('resize', function () {
    const sidebars = document.querySelectorAll('.sidebar');
    const windowHeight = window.innerHeight;
    const windowWidth = window.innerWidth;

    sidebars.forEach(function (sidebar) {
        if (windowHeight <= 630 || windowWidth <= 1004) {
            sidebar.style.display = 'none';
        } else {
            sidebar.style.display = 'block';
        }
    });
});