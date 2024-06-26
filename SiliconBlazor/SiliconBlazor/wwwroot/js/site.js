//skript som hanterar uppladdning av en profilbild



// Detta k�rs n�r hela webbsidan har laddats.
//En h�ndelse registreras som k�rs n�r hela webbsidan har laddats(DOMContentLoaded).
//N�r detta event intr�ffar, kommer funktionen d�ri k�ras.
document.addEventListener('DOMContentLoaded', function () {
    console.log("DOM fully loaded and parsed");
    //anropar funktion
    handleProfileImageUpload()
})

function handleProfileImageUpload() {
    console.log("handleProfileImageUpload function called");
    try {
        // letar efter ett element i _ProfileInfo med id 'fileUploader'.
        let fileUploader = document.querySelector('#fileUploader')
        //kontroll om elementet hittas
        if (fileUploader != undefined) {

            //om hittas, l�gger vi till en eventListener p� elementet,
            //vilken lyssnar efter en f�r�ndring i elementet.
            //i Detta fall  n�r anv�ndaren v�ljer att laddda upp en fil
            fileUploader.addEventListener('change', function () {
                // Denna kod k�rs n�r anv�ndaren v�ljer en fil att ladda upp.
                //kontroll om anv valt en fil
                if (this.files.length > 0) {
                    //om true, skickas formul�ret med uppladdningsknappen.
                    this.form.submit()
                }
            })
        }
    }
    catch { }
}





/**************VALIDERING AV FORMUL�R******************/



//formul�ret har id regform

//G� till documentet och h�mta ut id f�r den html-sektionen som ska hanteras. L�gger till en eventlistener och anger vilken typ, samt adderar en anonym funktion
function register(event) {
    event.preventDefault()

    const user = {
        firstName: event.target[0].value,
        lastName: event.target[1].value,
        email: event.target[2].value,
        phone: event.target[3].value,
        password: event.target[4].value,
        confirmPassword: event.target[5].value,
        TermsAndConditions: event.target[6].checked,

    }
    console.log(1)
    let allFieldsValid = true;

    //for (let element of event.target) {
    //    if (element.required) {
    //        let isValid = validateFormField(element);
    //        if (!isValid) {
    //            allFieldsValid = false;
    //        }
    //    }
    //}
    console.log(2)

    if (allFieldsValid) {
        event.target.submit();
    }
    console.log(3)
}

function validateFormField(element) {
    console.log("Validating field: ", element.id);
    const errorMessages = {
        firstName_valid: "Du m�ste ange ett f�rnamn",
        firstName_invalid: "Du m�ste ange ett giltigt f�rnamn",
        lastName_valid: "Du m�ste ange ett efternamn",
        lastName_invalid: "Du m�ste ange ett giltigt efternamn",
        email_valid: "Du m�ste ange en e-postadress",
        email_invalid: "Du m�ste ange en giltig E-postadress",
        password_valid: "Du m�ste ange ett l�senord",
        password_invalid: "Du m�ste ange ett giltigt och starkt l�senord",
        passwordSignin_valid: "Du m�ste ange ditt l�senord",
        passwordSignin_invalid: "Du m�ste ange minst 8 tecken",
        confirmPassword_valid: "Du m�ste bekr�fta l�senordet",
        confirmPassword_invalid: "L�senorden matchar inte",
        terms_valid: "Du m�ste acceptera villkoren",
        terms_invalid: "Du har inte accepterat villkoren",
        phoneNumber_valid: "Ange ett telefonnummer",
        phoneNumber_invalid: "Numret f�r endast inneh�lla siffror",

    }


    if (!validateLength(element.value, 1)) {
        document.getElementById(`${element.id}`).classList.add('error')
        document.getElementById(`${element.id}-error`).innerHTML = errorMessages[element.id + "_valid"]

    } else {
        var result = false;

        switch (element.type) {
            case 'text':
                result = validateLength(element.value)
                break;
            case 'email':
                result = validateEmail(element.value)
                break;
            case 'password':
                result = validatePassword(element) //skickar in hela objektet med ALLA properties
                break;
            case 'number':
                result = validatePostalCode(element.value)
                break;
            case 'tel':
                result = validatePhoneNumber(element.value)
                break;
            case 'checkbox':
                result = validateCheckBox(element.checked)
                break;

        }

        if (!result) {
            document.getElementById(`${element.id}`).classList.add('error')
            document.getElementById(`${element.id}-error`).innerHTML = errorMessages[element.id + "_invalid"]
        }
        else {
            document.getElementById(`${element.id}`).classList.remove('error')
            document.getElementById(`${element.id}-error`).innerHTML = "";
        }

    }

}

function validateCheckBox(element) {
    console.log("Validate checkbox called");
    if (element.checked) {
        return true
    }
    return false;
}
function validatePhoneNumber(element) {
    if (element.value.match(/^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/)) {
        return true
    }
    return false
}

function validateLength(value, minLength = 2) {
    if (value.length >= minLength)
        return true

    return false
}

function validateEmail(value) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(value)) {

        return true
    }

    return false

}

function validatePostalCode(value) {
    if (/^[0-9]{5}$/.test(value)) {
        return true;
    }
    return false;

}


function validatePassword(element) {
    //kontroll om vi ens har ett s�dant element
    if (element.getAttribute('data-comparewith') !== null)
        return compareValues(element)


    if (/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/.test(element.value)) {
        return true;
    }
    return false;
}






function compareValues(element) {
    let compareElement = document.getElementById(`${element.getAttribute('data-comparewith')}`)

    if (element.value === compareElement.value)
        return true;

    return false;
}





/*MOBILE MENU*/

//function toggleMobileMenu() {
//    let menu = document.getElementById('mobileMenu');
//    console.log("toggleMobileMenu called");
//    if (menu.style.display === 'none' || menu.style.display === '') {
//        menu.style.display = 'block';
//    } else {
//        menu.style.display = 'none';
//    }
//}