/*global Taggle*/
function pageLoad() {


        //var el = $('.example1.textarea').find('ul').eq(0).find('li').find('.close');
        //$('.close').click(function () {
        //    var tag = $(this).next('input').text();
        //    confirm('You really wanna remove ' + tag + '?')
        //});

    // The example code uses the real id so i'm selecting these elements
    // via jquery so we dont screw with the examples
    new Taggle($('.example1.textarea')[0]);
//    $('.example1.textarea ul::gt(1)').remove();
    //var example4 = new Taggle($('.example1.textarea')[0], {
    //    duplicateTagClass: 'bounce'
    //});

    //var container = example4.getContainer();
    //var input = example4.getInput();

  

    //$(input).autocomplete({
    //    source: faux,
    //    appendTo: container,
    //    position: { at: 'left bottom', of: container },
    //    select: function (e, v) {
    //        e.preventDefault();
    //        //Add the tag if user clicks
    //        //if (e.which === 1) {
    //        //    example4.add(v.item.value);
    //        //}

      
    //    },
    //});


  
    validateEmail = function (ControlID) {
        var IsError = "";
        var tfld = ControlID;                        // value of field with #E3E9E9space trimmed off
        var emailFilter = /^[^@]+@[^@.]+\.[^@]*\w\w$/;
        var illegalChars = /[\(\)\<\>\,\;\:\\\"\[\]]/;

        if (!emailFilter.test(tfld)) {              //test email for illegal characters

            IsError = "Please enter valid email address! e.g tpss@gmail.com\n";

        } else if (ControlID.match(illegalChars)) {

            IsError = "The email address contains illegal characters!\n";
        } else {


        }
        return IsError;
    }
    new Taggle($('.example1.textarea')[0], {
        onBeforeTagAdd: function (event, tag) {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError = validateEmail(tag);
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            else {
                if (confirm('You really wanna add ' + tag + '?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
        },
        onTagAdd: function (event, tag) {
           
                var valuesemail = "";
                $('.example1.textarea').find('ul').eq(1).find('li').each(function () {
                    if ($(this).find('span').is(':visible'))
                   
                        valuesemail += $(this).find('span').html() + ',';

                });
                valuesemail = valuesemail.substring(0, valuesemail.length - 1)
                $('#hdnEmailList').val(valuesemail + ';');
        
             //   window.PageMethods.RefillTextBox1(valuesalert);
               document.getElementById('btnAddEmailList').click();
            
        },
        onBeforeTagRemove: function (event, tag){
            //if (confirm('You really wanna remove ' + tag + '?')) {
            //    return true;
            //}
            //else {
            //    return false;
            //}
        },
        onTagRemove: function (event, tag) {
         
                //var valuesemail = "";
                //$('.example1.textarea').find('ul').eq(1).find('li').each(function () {
                //    if ($(this).find('span').is(':visible'))
                //        valuesemail += $(this).find('span').html() + ',';

                //});
                //valuesemail = valuesemail.substring(0, valuesemail.length - 1)
                //$('#hdnEmailList').val(valuesemail + ';');
                //   document.getElementById('btnRemoveEmailList').click();
            }
         
   
        
    });




    new Taggle($('.example2.textarea')[0]);
    //$('.example2.textarea ul::gt(1)').remove();
    //var example5 = new Taggle($('.example2.textarea')[0], {
    //    duplicateTagClass: 'bounce'
    //});
    //var container1 = example5.getContainer();
    //var input1 = example5.getInput();
    //$(input1).autocomplete({
    //    source: faux,
    //    appendTo: container1,
    //    position: { at: 'left bottom', of: container },
    //    select: function (e, v) {
    //        e.preventDefault();
    //        //Add the tag if user clicks
    //        //if (e.which === 1) {
    //        //    example4.add(v.item.value);
    //        //}


    //    },
    //});

    new Taggle($('.example2.textarea')[0], {
        onBeforeTagAdd: function (event, tag) {
            if (confirm('You really wanna add ' + tag + '?')) {
                return true;
            }
            else {
                return false;
            }
        },
        onTagAdd: function (event, tag) {
         
                var valuesalert = "";
                $('.example2.textarea').find('ul').eq(1).find('li').each(function () {
                    if ($(this).find('span').is(':visible')) {
                        valuesalert += $(this).find('span').html() + ',';
                    }
                });
                valuesalert = valuesalert.substring(0, valuesalert.length - 1)
                $('#hdnAlertList').val(valuesalert + ';');
            //    window.PageMethods.RefillTextBox(valuesalert);
                document.getElementById('btnAddAlertList').click();
        },
        onBeforeTagRemove: function (event, tag) {
            //if (confirm('You really wanna remove ' + tag + '?')) {
            //    return true;
            //}
            //else {
            //    return false;
            //}
        },
        onTagRemove: function (event, tag) {

                //var valuesalert = "";
                //$('.example2.textarea').find('ul').eq(1).find('li').each(function () {
                //    if ($(this).find('span').is(':visible'))
                //        valuesalert += $(this).find('span').html() + ',';

                //});
                //valuesalert = valuesalert.substring(0, valuesalert.length - 1)
                //$('#hdnAlertList').val(valuesalert + ';');

                //document.getElementById('btnRemoveAlertList').click();
        }
    });
}
