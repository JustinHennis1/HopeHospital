window.addEventListener('load', function () {
    const animatedText = document.getElementById('animatedText');
    let textContent = "you find healing.";
    let index = 0;
    let cursor;
    let i = 0;

    function typeWriter() {
        if (index < textContent.length) {
            animatedText.textContent = textContent.slice(0, index);
            animatedText.textContent += textContent.charAt(index);
            index++;
            setTimeout(typeWriter, 300);
        } else {
            addCursor();
            setTimeout(deleteText, 2000); // Delay before deleting the text (2 seconds)
        }
    }

    function deleteText() {
        if (index >= 0) {
            animatedText.textContent = textContent.slice(0, index);
            index--;
            setTimeout(deleteText, 50); // Adjust the speed of deletion
        } else {
            animatedText.textContent = ''; // Clear the text
            removeCursor();
            i++;
            setTimeout(writeNewText, 1000); // Delay before writing new text (1 second)
        }
    }
    
    function writeNewText() {
        
        let messages = ["you feel welcome.", "you feel safe.", "you are heard.", "people recover."];
        if (i == messages.length) {
            i = 0;
        }
        textContent = messages[i]; // New text to write
        index = 0;
        typeWriter();
        
    }

    function addCursor() {
        removeCursor();
        cursor = document.createElement('span');
        cursor.classList.add('blinkingCursor');
        cursor.textContent = '|';
        animatedText.insertAdjacentElement('afterend', cursor);
    }

    function removeCursor() {
        if (cursor) {
            cursor.remove();
            cursor = null;
        }
    }

    typeWriter();
});