var requrl = 'https://www.eventbriteapi.com/v3/events/';
//requrl = requrl + "" + eventId + "/";
//requrl = requrl + "?expand=venue,organizer";
requrl = requrl.concat(eventId, "/?expand=venue,organizer");
console.log(eventId);
console.log(requrl);
var request = new XMLHttpRequest();

request.open('GET', requrl);
console.log(requrl);
request.setRequestHeader('Authorization', 'Bearer BJLQFJ7HBQI2GFXJDEKX');
//request.setRequestHeader('Content-Type', 'application/json');

request.onreadystatechange = function () {
    if (this.readyState === 4) {
        console.log('Status:', this.status);
        console.log('Headers:', this.getAllResponseHeaders());
        console.log('Body:', this.responseText);
        var obj = JSON.parse(this.responseText);
        var month = new Array();
        month[0] = "January";
        month[1] = "February";
        month[2] = "March";
        month[3] = "April";
        month[4] = "May";
        month[5] = "June";
        month[6] = "July";
        month[7] = "August";
        month[8] = "September";
        month[9] = "October";
        month[10] = "November";
        month[11] = "December";
        var date = new Date(obj.start.local);
        var date1 = month[date.getMonth()] + " " + date.getDate();
        //var hour = date.getHours();
        //var min = date.getMinutes();
        var hrmin = moment(date).format('hh:mm a');
        date1 = date1 + "&nbsp &nbsp" + hrmin;
        var element = document.getElementById("desc");
        element.innerHTML = obj.description.html;
        document.getElementById("image").src = obj.logo.original.url;
        document.getElementById("date").innerHTML = date1;
        document.getElementById("address").innerHTML = obj.venue.address.localized_multi_line_address_display;
        document.getElementById("organiser").innerHTML = obj.organizer.name;
        document.getElementById("name").innerHTML = obj.name.html;
        //var address = document.createElement("p");
        //var organiser = document.createElement("p");
        //address.innerHTML = obj.venue.address.localized_multi_line_address_display;
        //organiser.innerHTML = obj.organizer.name;
        
    }
};

request.send();
