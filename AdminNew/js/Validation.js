/*
Studio Finder validations
*/
//validation used for check datetime format
function IsValidDate(DateValue, ErrorMessage) {
    var IsError = "";
    var filter = /^([Jj][Aa][Nn]|[Ff][Ee][Bb]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][Uu][Lj]|[Aa][Uu][Gg]|[Ss][Ee][Pp]|[Oo][Cc][Tt]|[Nn][Oo][Vv]|[Dd][Ee][Cc]) (0[1-9]|[1-9]|[12][0-9]|3[01]),(19|20)\d\d$/;
    var charpos = DateValue.value.search(filter);
    if (DateValue.value.length > 0 && charpos == -1) {
        IsError = ErrorMessage + "\n";
    }
    return IsError;
}

function IsValidArabicDate(DateValue, ErrorMessage) {
    var IsError = "";
    var filter = /^(19|20)\d\d,((0[1-9]|[1-9]|[12][0-9]|3[01]) [Jj][Aa][Nn]|[Ff][Ee][Bb]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][Uu][Lj]|[Aa][Uu][Gg]|[Ss][Ee][Pp]|[Oo][Cc][Tt]|[Nn][Oo][Vv]|[Dd][Ee][Cc]) $/;
    var charpos = DateValue.value.search(filter);
    if (DateValue.value.length > 0 && charpos == -1) {
        IsError = ErrorMessage + "\n";
    }
    return IsError;
}



function DateCompare(DateValueFirst, DateValueSecond, Errormesage) {
    var IsError = "";
    var date1 = new Date(DateValueFirst.value);
    var date2 = new Date(DateValueSecond.value);

    if (date1 > date2) {
        IsError = Errormesage + ".\n"
    }
    return IsError;
}

function DateCompareWithToday(DateValueSecond, Errormesage) {
    var IsError = "";
    var date1 = new Date();
    var date2 = new Date(DateValueSecond.value);

    if (date1 > date2) {
        IsError = Errormesage + ".\n"
    }
    return IsError;
}




function GetCount(txtAdd, lblCount, Max) {
    var iCount = Max - txtAdd.value.length;
    if (iCount > 0) {
        lblCount.innerHTML = iCount;
    }
    else {

        lblCount.innerHTML = 0;
        txtAdd.value = txtAdd.value.substring(0, Max);
    }
}

keyCodeReturn = function(e) {
    var key;

    if (window.event) {
        key = window.event.keyCode;     //IE
    }
    else {
        key = e.which;
    }
    return key;
}
ValidateRequiredField = function(ControlID, Errormesage) {
    var IsError = "";
    if (ControlID.value.length == 0) {
        ControlID.style.background = '#FCFAA9'; 
        if (Focus == "No")
            SetFocusOnValidateField(ControlID);
        IsError = Errormesage + ".\n"
    } else {
        ControlID.style.background = '#E3E9E9';
    }
    return IsError;
}

//Validate for checkbox is checked or not 
ValidateCheckBox = function(ControlID, Errormesage) {
    var IsError = "";

    if (ControlID.checked == 0) {
        IsError = Errormesage + ".\n"
    }
    else {
        IsError = "";
    }
    return IsError;
}

//Validate for checkboxlist is checked or not 

ValidateCheckBoxList = function(ControlID, Errormesage) {
    var IsError = '';
    var checkBoxes = ControlID.getElementsByTagName("input");
    var isvalid = false;
    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked) {
            isvalid = true;
        }
    }

    return IsError += !isvalid ? Errormesage + '.\n' : '';
}
CheckAllCheckBox = function(ControlID, ChkTypeID) {
    var checkBoxes = ControlID.getElementsByTagName("input");


    for (var i = 0; i < checkBoxes.length; i++) {
        checkBoxes[i].checked = document.getElementById(ChkTypeID).checked;
    }
}



validateNumberWithDecemalPoient = function(objValue, ErrorMessage) {
    var IsError = '';
    var strRegExp = /^((0|[1-9]){1,3}|(0|[1-9]){1,3}|((0|[1-9]){1,3}|(0|[1-9]){1,3}\.+(\d(0|[1-9]){1}|(0|[1-9]){1,1})))$/;
    var charpos = objValue.value.search(strRegExp);

    if (objValue.value.length > 0 && charpos == -1) {
        IsError = ErrorMessage + "\n";
    } //if 

    return IsError;
}
validateNumberWithDecemalPoient3 = function(objValue, ErrorMessage) {
    var IsError = '';
    var strRegExp = "^[0-9,]+(\.\d{0,3})?$";
    var charpos = objValue.value.search(strRegExp);

    if (objValue.value.length > 0 && charpos == -1) {
        IsError = ErrorMessage + "\n";
    } //if 

    return IsError;
}
//-------------Used For numeric values ----------------
ValidateIsNumeric = function(ControlID, Errormesage) {
    var IsError = "";
    if (!/\D/.test(ControlID.value)) {
        IsError = ""; //IF NUMBER
    }
    else if (/^\d+\.\d+$/.test(ControlID.value)) {
        //ControlID.style.background = '#FCFAA9';
        SetFocusOnValidateField(ControlID);
        IsError = Errormesage + ".\n"//IF A DECIMAL NUMBER HAVING AN INTEGER ON EITHER SIDE OF THE DOT(.)
    }
    else {
        //ControlID.style.background = '#FCFAA9';
        SetFocusOnValidateField(ControlID);
        IsError = Errormesage + ".\n"
    }
    return IsError;
}
//------------------ End block-----------------------------------
//------------------ Used for Dropdownlist  ---------------------
ValidateDropdown = function(ControlID, Errormesage) {
    var IsError = "";
    if (ControlID.selectedIndex == 0) {
        SetFocusOnValidateField(ControlID);
       ControlID.style.background = '#FCFAA9';
        IsError = Errormesage + ".\n"
    }
    else {
        IsError = "";
    }
    return IsError;
}
//-------------End block-----------------------------------------

//--------Validate User Name and  allow letters, numbers, and underscores"
ValidateUsername = function(ControlID) {
    var IsError = "";
    var illegalChars = /\W/;

    if (ControlID.value == "") {
        //ControlID.style.background = '#FCFAA9';
        SetFocusOnValidateField(ControlID);
        IsError = "Please enter YN username.\n";
    } else if ((ControlID.value.length < 5) || (ControlID.value.length > 15)) {
        //ControlID.style.background = '#FCFAA9'; 
        SetFocusOnValidateField(ControlID);
        IsError = "The username is the wrong length.\n";
    } else if (illegalChars.test(ControlID.value)) {
        //ControlID.style.background = '#FCFAA9'; 
        SetFocusOnValidateField(ControlID);
        IsError = "The username contains illegal characters.\n";
    } else {
        //ControlID.style.background = '#E3E9E9';
        ControlID.value = "";
    }
    return IsError;
}
//-------------End block-----------------------------------------
ValidateconfirmPassword = function(ControlID, fld1) {
    if (ControlID.value == fld1.value) {
        IsError = "";
    }
    else {
        SetFocusOnValidateField(ControlID);
        IsError = "Confirm password does not match. \n";
    }
    return IsError;
}
//-------------End block-----------------------------------------
ValidatePassword = function(ControlID) {
    var IsError = "";
    var illegalChars = /[\W_]/; // allow only letters and numbers 

    if (ControlID.value == "") {
        //ControlID.style.background = '#FCFAA9';
        SetFocusOnValidateField(ControlID);
        IsError = "Please enter YN password.\n";
    } else if ((ControlID.value.length < 7) || (ControlID.value.length > 15)) {
        //ControlID.style.background = '#FCFAA9';
        SetFocusOnValidateField(ControlID);
        IsError = "The password is the wrong length. \n";
    }
    else if (!((ControlID.value.search(/(YN-z)+/)) && (ControlID.value.search(/(0-9)+/)))) {
        //ControlID.style.background = '#FCFAA9';
        SetFocusOnValidateField(ControlID);
        IsError = "The password must contain at least one numeral.\n";

    } else {
        //ControlID.style.background = '#E3E9E9';
    }
    return IsError;
}
//-------------End block-----------------------------------------
trim = function(TargetControlID) {
    return TargetControlID.replace(/^\TargetControlID+|\TargetControlID+$/, '');
}
//-------------End block-----------------------------------------
validateEmailWithMsg = function(ControlID, Errormesage) {
    var IsError = "";
    var tfld = trim(ControlID.value);                        // value of field with #E3E9E9space trimmed off
    var emailFilter = /^[^@]+@[^@.]+\.[^@]*\w\w$/;
    var illegalChars = /[\(\)\<\>\,\;\:\\\"\[\]]/;

    if (ControlID.value == "") {

        SetFocusOnValidateField(ControlID);
        ControlID.style.background = '#FCFAA9';
        IsError = Errormesage + ".\n"

    } else if (!emailFilter.test(tfld)) {              //test email for illegal characters

        SetFocusOnValidateField(ControlID);
        ControlID.style.background = '#FCFAA9';
        IsError = Errormesage + ".\n"

    } else if (ControlID.value.match(illegalChars)) {

        SetFocusOnValidateField(ControlID);
        ControlID.style.background = '#FCFAA9';
        IsError = Errormesage + ".\n"
    } else {
        ControlID.style.background = '#E3E9E9';

    }
    return IsError;
}
validateEmail = function(ControlID) {
    var IsError = "";
    var tfld = trim(ControlID.value);                        // value of field with #E3E9E9space trimmed off
    var emailFilter = /^[^@]+@[^@.]+\.[^@]*\w\w$/;
    var illegalChars = /[\(\)\<\>\,\;\:\\\"\[\]]/;

    if (ControlID.value == "") {

        SetFocusOnValidateField(ControlID);
        //ControlID.style.background = '#FCFAA9';
        IsError = "Please enter email address!\n";

    } else if (!emailFilter.test(tfld)) {              //test email for illegal characters

        SetFocusOnValidateField(ControlID);
        //ControlID.style.background = '#FCFAA9';
        IsError = "Please enter valid email address! e.g tpss@gmail.com\n";

    } else if (ControlID.value.match(illegalChars)) {

        SetFocusOnValidateField(ControlID);
        //ControlID.style.background = '#FCFAA9';
        IsError = "The email address contains illegal characters!\n";
    } else {
        //ControlID.style.background = '#E3E9E9';

    }
    return IsError;
}


//-------------End block-----------------------------------------
validatePhoneWithMsg = function(ControlID, Errormesage) {
    var IsError = "";
    var stripped = ControlID.value.replace(/[\(\)\.\-\ ]/g, '');

    if (ControlID.value == "") {
        SetFocusOnValidateField(ControlID);
        IsError = Errormesage + ".\n"
        //ControlID.style.background = '#FCFAA9';
    } else if (isNaN(parseInt(stripped))) {
        SetFocusOnValidateField(ControlID);
        IsError = Errormesage + ".\n"
        //ControlID.style.background = '#FCFAA9';
    } else if (!(stripped.length == 11)) {
        SetFocusOnValidateField(ControlID);
        IsError = Errormesage + ".\n"
        //ControlID.style.background = '#FCFAA9';
    }
    return IsError;
}
validatePhone = function(ControlID) {
    var IsError = "";
    var stripped = ControlID.value.replace(/[\(\)\.\-\ ]/g, '');

    if (ControlID.value == "") {
        SetFocusOnValidateField(ControlID);
        IsError = "Please enter phone number.\n";
        ControlID.style.background = '#FCFAA9';
    } else if (isNaN(parseInt(stripped))) {
        SetFocusOnValidateField(ControlID);
        IsError = "The phone number contains illegal characters.\n";
        ControlID.style.background = '#FCFAA9';
    } else if (!(stripped.length == 10)) {
        SetFocusOnValidateField(ControlID);
        IsError = "The phone number is the wrong length. Make sure you included an area code.\n";
        ControlID.style.background = '#FCFAA9';
    }
    return IsError;
}

validateNumber = function(ControlID) {
    var IsError = "";
    var stripped = ControlID.value.replace(/[\(\)\.\-\ ]/g, '');

    if (ControlID.value == "") {
        SetFocusOnValidateField(ControlID);
        IsError = "Please enter store number.\n";
        ControlID.style.background = '#FCFAA9';
    } else if (isNaN(parseInt(stripped))) {
        SetFocusOnValidateField(ControlID);
        IsError = "The store number should have integer value.\n";
        ControlID.style.background = '#FCFAA9';
    } else if (!(stripped.length == 5)&&(!(stripped.length == 7))) {
        SetFocusOnValidateField(ControlID);
        IsError = "store number should be 5-7 digits\n";
        ControlID.style.background = '#FCFAA9';
    } 
    return IsError;
}

//-----------------------------   Only Alphabetic Characters are Allowed ------------------------------------------------------------
//function TestInputType(objValue,strRegExp,strError,strDefaultError)
TestInputType = function(objValue, ErrorMessage) {
    var IsError = '';
    var strRegExp = /^[A-Za-z\ ]+$/;
    var charpos = objValue.value.search(strRegExp);

    if (objValue.value.length > 0 && charpos == -1) {
        IsError = ErrorMessage + "\n";
    } //if 

    return IsError;
}
//-------------------------------- Atlest One CheckBox true ------------------------------------------------------------
checkbox_checker = function() {
    var IsError = '';
    for (counter = 0; counter < checkbox_checker.checkbox.length; counter++) {
        if (checkbox_form.checkbox[counter].checked) {
            return true;
            IsError = '';
        }
        else {
            IsError = "Please Check atleast one CheckBox";
            return false;
        }
    }

}
//-------------------------------- Validation For RadioButton ---------------------------------------------------------------
//ValiRadio=function(ControlID1,ControlID2,ErrorMessage)
//{
//    var IsError='';
//    if(ControlID1.checked || ControlID2.checked)
//    {
//        return true;
//        IsError='';
//    }
//    else
//    {
//        IsError="Please Check atleast one Radiobutton";
//        return false;
//    }
//}

//-------------------------------- Regular Expression For Date ---------------------------------------------------------------
ValidateDate = function(ControlID, ErrorMessage) {
    var IsError = '';
    var strRegExp = /^([Jj][Aa][Nn]|[Ff][Ee][Bb]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][Uu][Lj]|[Aa][Uu][Gg]|[Ss][Ee][Pp]|[Oo][Cc][Tt]|[Nn][Oo][Vv]|[Dd][Ee][Cc]) (0[1-9]|[1-9]|[12][0-9]|3[01]),(19|20)\d\d$/;
    var charpos = ControlID.value.search(strRegExp);
    if (ControlID.value.length > 0 && charpos == -1) {
        IsError = ErrorMessage + "\n";
    } //if 


    return IsError;
}

//-------------------------------- Length of TextBox --------------------------------------------------------------------------
Length = function(ControlID, len, ErrorMessage) {
    var IsError = '';
    if (ControlID.value.length > len) {
        IsError = ErrorMessage + "\n";
    }
    else {
        IsError = '';
    }
    return IsError;
}

//-------------End block-----------------------------------------
checkallCheckBoxes = function(gridview, chk, cl) {
    var grid = document.getElementById(gridview);
    var ceklist = document.getElementById(chk);
    var CheckedOrNot = ceklist.checked;
    var cell;

    if (grid.rows.length > 0) {
        for (var x = 1; x < grid.rows.length + 1; x++) {
            grid.rows[x].style.background = CheckedOrNot == true ? '#DDFDCE' : '';
            cell = grid.rows[x].cells[cl];
            //loop according to the number of childNodes in the cell
            for (j = 0; j < cell.childNodes.length; j++) {
                //if childNode type is CheckBox                 
                if (cell.childNodes[j].type == "checkbox") {
                    //assign the status of the Select All checkbox to the cell checkbox within the grid
                    cell.childNodes[j].checked = CheckedOrNot;
                }
            }
        }
    }

}

checkSingleCheckBoxes = function(gridview, chk, cl, rowIndex) {
    var grid = document.getElementById(gridview);
    var ceklist = document.getElementById(chk);
    var CheckedOrNot = ceklist.checked;
    var cell;
    grid.rows[Number(rowIndex) + 1].style.background = CheckedOrNot == true ? '#DDFDCE' : '';

}





//-------------End block-----------------------------------------

var Focus = "No";
M_nofocus = function(YN) {
    Focus = YN;
}
SetFocusOnValidateField = function(ControlID) {
    if (Focus == "No") {
        Focus = "Yes"
        ControlID.focus();
    }

}


//--- Form Validation -----//

function Required() {

    var PostCode = document.getElementById('txtPostCode');
    if (PostCode.value == '' || PostCode.value == 'Postcode') {
        alert('Please enter postcode');
        return false;
    }
    else {
        return true;
    }

}