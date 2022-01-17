function GuardarReserva_en(){
	var msgerror='';
	if (document.getElementById('Nombre').value==""){ msgerror = 'Name\n'; }
	if (document.getElementById('email').value==""){ msgerror = msgerror +'Email\n'; }
	if (msgerror!=''){
		alert('Mandatory fields:\n\n'+msgerror);
		return false;
	} else {
		return true;
	}
	
}

