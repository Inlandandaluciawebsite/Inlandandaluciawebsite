// Funciones para validacion de campos del formulario de contacto.

/* Emite un mensaje y enfoca en el campo en cuestion*/
function fixElement(element, message) 
{
	alert(message);
	element.focus();
}

/* Función que valida campo email*/
function emailCheck (form) 
{
/* The following pattern is used to check if the entered e-mail address
   fits the user@domain format.  It also is used to separate the username
   from the domain. */
var emailPat=/^(.+)@(.+)$/
/* The following string represents the pattern for matching all special
   characters.  We don't want to allow special characters in the address. 
   These characters include ( ) < > @ , ; : \ " . [ ]    */
var specialChars="\\(\\)<>@,;:\\\\\\\"\\.\\[\\]"
/* The following string represents the range of characters allowed in a 
   username or domainname.  It really states which chars aren't allowed. */
var validChars="\[^\\s" + specialChars + "\]"
/* The following pattern applies if the "user" is a quoted string (in
   which case, there are no rules about which characters are allowed
   and which aren't; anything goes).  E.g. "jiminy cricket"@disney.com
   is a legal e-mail address. */
var quotedUser="(\"[^\"]*\")"
/* The following pattern applies for domains that are IP addresses,
   rather than symbolic names.  E.g. joe@[123.124.233.4] is a legal
   e-mail address. NOTE: The square brackets are required. */
var ipDomainPat=/^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/
/* The following string represents an atom (basically a series of
   non-special characters.) */
var atom=validChars + '+'
/* The following string represents one word in the typical username.
   For example, in john.doe@somewhere.com, john and doe are words.
   Basically, a word is either an atom or quoted string. */
var word="(" + atom + "|" + quotedUser + ")"
// The following pattern describes the structure of the user
var userPat=new RegExp("^" + word + "(\\." + word + ")*$")
/* The following pattern describes the structure of a normal symbolic
   domain, as opposed to ipDomainPat, shown above. */
var domainPat=new RegExp("^" + atom + "(\\." + atom +")*$")

/* Finally, let's start trying to figure out if the supplied address is
   valid. */

/* Begin with the coarse pattern to simply break up user@domain into
   different pieces that are easy to analyze. */
  
var matchArray=form.email.value.match(emailPat);
if (matchArray==null) {
  /* Too many/few @'s or something; basically, this address doesn't
     even fit the general mould of a valid e-mail address. */
	fixElement(form.email,"The email doesn't seem to be valid. Please check @ and .'s");
	return false;
}
var user=matchArray[1];
var domain=matchArray[2];

// See if "user" is valid 
if (user.match(userPat)==null) {
    // user is not valid
    fixElement(form.email,"The username doesn't seem to be valid.");
    return false;
}

/* if the e-mail address is at an IP address (as opposed to a symbolic
   host name) make sure the IP address is valid. */
var IPArray=domain.match(ipDomainPat);
if (IPArray!=null) {
    // this is an IP address
	  for (var i=1;i<=4;i++) {
	    if (IPArray[i]>255) {
	        fixElement(form.email,"Destination IP address is invalid!");
		return false;
	    }
    }
    return true;
}

// Domain is symbolic name
var domainArray=domain.match(domainPat)
if (domainArray==null) {
	fixElement(form.email,"The domain name doesn't seem to be valid.");
    return false;
}

/* domain name seems valid, but now make sure that it ends in a
   three-letter word (like com, edu, gov) or a two-letter word,
   representing country (uk, nl), and that there's a hostname preceding 
   the domain or country. */

/* Now we need to break up the domain to get a count of how many atoms
   it consists of. */
var atomPat=new RegExp(atom,"g");
var domArr=domain.match(atomPat);
var len=domArr.length
if (domArr[domArr.length-1].length<2 || 
    domArr[domArr.length-1].length>3) {
   // the address must end in a two letter or three letter word.
   fixElement(form.email,"The address must end in a three-letter domain, or two letter country.");
   return false;
}

// Make sure there's a host name preceding the domain.
if (len<2) {
   var errStr="This address is missing a hostname!";
   fixElement(form.email,errStr);
   return false;
}

// If we've gotten this far, everything's valid!
return true;
}


/* Funcion para chequear que solo aparecen caracteres en una cadena*/
function CheckOnlyChars (input) 
{
	var s = input.value;
	filteredValues = "1234567890";     // Characters stripped out
	var i;
	for (i = 0; i < s.length; i++) 
	{  // Search through string and append to unfiltered values to returnString.
		var c = s.charAt(i);
		if (filteredValues.indexOf(c) > -1)
		{ 
			return false;
		}
	}
	return true;
}

/* Funcion principal de chequeo de campos del formulario de contacto*/
function checkDataForm(form)
{
 
	 //Chequeo de los campos mandatory
	     
	 //1: Campos obligatorios.
	 if (form.firstname.value == "") 
	 {
		fixElement(form.firstname, "Please, type your First Name.");
		return false;
	 }

	 if (form.lastname.value == "") 
	 {
		fixElement(form.lastname, "Please, type your Last Name.");
		return false;
	 }
	 
	// if (form.telephone.value == "") 
	// {
	//	fixElement(form.telephone, "Please, type your Telephone.");
	//	return false;
	// }
	 
	 if (form.comment.value == "") 
	 {
		fixElement(form.comment, "Please, type your Comment.");
		return false;
	 }
	 
	 //Validacion de campos.
	 //Nombre: Sólo letras.
	 if (!CheckOnlyChars(form.firstname))
	 {
	 	fixElement(form.firstname, "Please, type a correct Firstname.");
		return false;
	 }
	 
	 if (!CheckOnlyChars(form.lastname))
	 {
	 	fixElement(form.lastname, "Please, type a correct Lastname.");
		return false;
	 }
	 
	 //Mail.
	 if (form.email.value == "") 
	 {
		fixElement(form.email, "Please, type your Email.");
		return false;
	 }
	 
	 return emailCheck(form);
}

/* Funcion principal de chequeo de campos del formulario de enquiry*/
function checkEnquiryForm(form)
{
	 //Chequeo de los campos mandatory
	     
	 //1: Campos obligatorios.
	 if (form.Nombre.value == "") 
	 {
		fixElement(form.Nombre, "Please, type your Name.");
		return false;
	 }

	 if (form.email.value == "") 
	 {
		fixElement(form.email, "Please, type your Mail Address.");
		return false;
	 }
	 
	 //if (form.Telefono.value == "") 
	 //{
	//	fixElement(form.Telefono, "Please, type your Telephone.");
	//	return false;
	 //}
	 
	 //2: Validacion campos.
	 if (!CheckOnlyChars(form.Nombre))
	 {
	 	fixElement(form.Nombre, "Please, type a correct Name.");
		return false;
	 }
	 
	 return emailCheck(form);
	 
}

function checkRegisterForm(form)
{
	 //Chequeo de los campos mandatory
	     
	 //1: Campos obligatorios.
	 if (form.name.value == "") 
	 {
		fixElement(form.name, "Please, type your Name.");
		return false;
	 }

	 if (form.email.value == "") 
	 {
		fixElement(form.email, "Please, type your Mail Address.");
		return false;
	 }
	 
	 if (form.address.value == "") 
	 {
		fixElement(form.address, "Please, type your Address.");
		return false;
	 }
	 
	 //if (form.telephone.value == "") 
	 //{
	//	fixElement(form.telephone, "Please, type your Telephone.");
	//	return false;
	 //}
	 
	 if (form.dateavailable.value == "") 
	 {
		fixElement(form.dateavailable, "Please, type the date you are available.");
		return false;
	 }
	 
	 if (form.peoplenumber.value == "") 
	 {
		fixElement(form.peoplenumber, "Please, type the how many people will tour with you.");
		return false;
	 }
	 
	 
	 
	 //2: Validacion campos.
	 if (!CheckOnlyChars(form.name))
	 {
	 	fixElement(form.name, "Please, type a correct Name.");
		return false;
	 }
	 
	 return emailCheck(form);
	 
}

function checkEnquiryForm2(form)
{
	//Chequeo de los campos mandatory
	     
	 //1: Campos obligatorios.
	 if (form.firstname.value == "") 
	 {
		fixElement(form.firstname, "Please, type your First Name.");
		return false;
	 }

	 if (form.lastname.value == "") 
	 {
		fixElement(form.lastname, "Please, type your Last Name.");
		return false;
	 }
	 
	// if (form.telephone.value == "") 
	// {
	//	fixElement(form.telephone, "Please, type your Telephone.");
	//	return false;
	// }
	 
	 if (form.comment.value == "") 
	 {
		fixElement(form.comment, "Please, type your Comment.");
		return false;
	 }
	 
	 //Validacion de campos.
	 //Nombre: Sólo letras.
	 if (!CheckOnlyChars(form.firstname))
	 {
	 	fixElement(form.firstname, "Please, type a correct Firstname.");
		return false;
	 }
	 
	 if (!CheckOnlyChars(form.lastname))
	 {
	 	fixElement(form.lastname, "Please, type a correct Lastname.");
		return false;
	 }
	 
	 //Mail.
	 if (form.email.value == "") 
	 {
		fixElement(form.email, "Please, type your Email.");
		return false;
	 }
	 
	 return emailCheck(form);
	
}

function SendFormByYourEmailClient(form)
{
	eAddresses="info" + "@" + "inland" + "andalu" + "cia.com, it" + "support" + "@" + "inland" + "andalu" + "cia.com";
	szSubject="Contact from Inland Andalucia Web (through the costumer email)";
	szBody= "FIRST NAME = " + form.firstname.value + "\n";
	szBody= szBody + "LAST NAME = " + form.lastname.value + "\n";
	szBody= szBody + "ADDRESS = " + form.address.value + "\n";
	szBody= szBody + "TELEPHONE = " + form.telephone.value + "\n";
	szBody= szBody + "COMMENT = " + form.comment.value;
	location.href="mailto:" + eAddresses + "?SUBJECT=" + escape(szSubject) + "&BODY=" + escape(szBody);
}

function SendEnquiryByYourEmailClient(form)
{
	eAddresses="info" + "@" + "inland" + "andalu" + "cia.com, it" + "support" + "@" + "inland" + "andalu" + "cia.com";
	szSubject="Contact from Inland Andalucia Web - Virtual Tour(through the costumer email)";
	szBody= " PROPERTY REFERENCE = " + form.ref.value + "\n";
	szBody= szBody + "NAME = " + form.Nombre.value + "\n";
	szBody= szBody + "EMAIL = " + form.email.value + "\n";
	szBody= szBody + "TELEPHONE = " + form.Telefono.value + "\n";
	szBody= szBody + "COMMENT = " + form.Notas.value;
	location.href="mailto:" + eAddresses + "?SUBJECT=" + escape(szSubject) + "&BODY=" + escape(szBody);
}

function SendEnquiryByYourEmailClient2(form)
{
	eAddresses="info" + "@" + "inland" + "andalu" + "cia.com, it" + "support" + "@" + "inland" + "andalu" + "cia.com";
	szSubject="Contact from Inland Andalucia Web - "+ form.subject.value+" (through the costumer email)";
	szBody= " PROPERTY REFERENCE = " + form.ref.value + "\n";
	szBody= szBody + "FIRST NAME = " + form.firstname.value + "\n";
	szBody= szBody + "LAST NAME = " + form.lastname.value + "\n";
	szBody= szBody + "EMAIL = " + form.email.value + "\n";
	szBody= szBody + "TELEPHONE = " + form.telephone.value + "\n";
	szBody= szBody + "COMMENT = " + form.comment.value;
	location.href="mailto:" + eAddresses + "?SUBJECT=" + escape(szSubject) + "&BODY=" + escape(szBody);
}


