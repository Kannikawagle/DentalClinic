function onAddHouseHoldClick() {
 //   alert("hi kannika");
}


function dobValidate(event) {

  //  alert("hi");
    var today = new Date();
    var nowyear = today.getFullYear();
    var nowmonth = today.getMonth();
    var nowday = today.getDate();
    var b = event.target.value;
    var validationElement = event.target.nextElementSibling;
   // alert(event.target.value);


    var birth = new Date(b);

    var birthyear = birth.getFullYear();
    var birthmonth = birth.getMonth();
    var birthday = birth.getDate();

    var age = nowyear - birthyear;
    var age_month = nowmonth - birthmonth;
    var age_day = nowday - birthday;


    if (age > 100) {
        validationElement.innerText = "Age cannot be more than 100 Years";
        event.target.value = null;
      //  alert("Age cannot be more than 100 Years.Please enter correct age")
        return false;
    }
    if (age_month < 0 || (age_month == 0 && age_day < 0)) {
        age = parseInt(age) - 1;


    }
    if ((age == 18 && age_month <= 0 && age_day <= 0) || age < 18) {
        //  alert("Age should be more than 18 years.Please enter a valid Date of Birth");
        validationElement.innerText = "Age should be more than 18 years";
        event.target.value = null;
        return false;
    }
    validationElement.innerText = "";
}
