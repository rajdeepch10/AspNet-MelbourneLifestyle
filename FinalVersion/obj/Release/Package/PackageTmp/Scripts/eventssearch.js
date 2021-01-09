//var location = $("#locationa").data("myValue");
/*console.log(date);
date = date.replace("&amp;", "&");
category = category.replace("&amp;", "&");
location = location.replace("&amp;", "&");
var url = 'https://www.eventbriteapi.com/v3/events/search/?sort_by=best';
console.log(location);
console.log(date);
console.log(category);
if (date !== null) { url = url + "" + date;}
if (location !== null) { url = url + "" + location;}
if (category !== null) { url = url + "" + category;}*/
//date = date.replace("&amp;", "&");
//category = category.replace("&amp;", "&");
//location = location.replace("&amp;", "&");
//var location = $("#locationa").data("myValue");
//var category = $("#category").data("myValue");
//var date = $("#date").data("myValue");
//console.log(location);
//var date = document.getElementById("date").data("myValue");
//var category = '<%= Session["category"] %>';
//console.log(date);
console.log(category);
console.log(date);
console.log(lochope);
lochope = lochope + "%2CVIC";
var categorytemp = parseInt(category.replace("categories=", ""));
console.log(categorytemp);
var locationtemp = lochope.replace("location.address=", "");
locationtemp = locationtemp.replace("%2CVIC", "");
locationtemp = locationtemp.replace("+", " ");
console.log(locationtemp);
var datetemp = date.replace("start_date.range_start=", "");
datetemp = datetemp.replace("T00%3A00%3A01Z", "");
console.log(datetemp+"test");
var catname = "";
var catindex;
switch (categorytemp) {
    case 115: catname = "Family & Education"; catindex = 0; break;
    case 104: catname = "Film & Media"; catindex = 1; break;
    case 120: catname = "School Activities"; catindex = 2; break;
    case 108: catname = "Sports & Fitness"; catindex = 3; break;
    case 109: catname = "Travel & Outdoor"; catindex = 4; break;
    default: catindex = null; catname = null; break;
}
if (locationtemp !== null) {
    document.getElementById("locinput").value = locationtemp;
    //document.getElementById("text-2").innerText = locationtemp;

}
if (catindex !== null) {
    document.getElementById("categories").options[catindex].selected = true;
    console.log(catindex);
    //document.getElementById("text-3").innerText = catname;

}
if (datetemp !== null) {
    var datearray = datetemp.split("-");
    var datetemp1 = new Date(parseInt(datearray[0]), parseInt(datearray[1]) - 1, parseInt(datearray[2]));
    //document.getElementById("text-1").innerText = datetemp1.getDate();
    //document.getElementById("datepicker-1").setDate(datetemp1);
    console.log(datetemp);
}
var requrl = "https://www.eventbriteapi.com/v3/events/search/?expand=category&sort_by=date" + "&" + category + "&" + date + "&" + lochope +"&location.within=5km";
//requrl = requrl + "&" + location;
//requrl = requrl + "&" + category;
console.log(requrl);
var temp = 'https://www.eventbriteapi.com/v3/events/search/?sort_by=best&location.address=Melbourne&categories=115&start_date.range_start=2019-04-22T00%3A00%3A01Z';
var request = new XMLHttpRequest();

request.open('GET', requrl);

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
        if (obj.pagination.object_count > 1) {
            var loopindex;
            if (obj.pagination.object_count < 7) { loopindex = obj.pagination.object_count - 1; }
            else { loopindex = 7; }
            for (var i = 1; i <= loopindex; i++) {
                var date = new Date(obj.events[i].start.local);
                var date1 = month[date.getMonth()] + " " + date.getDate();
                //var name = "name-" + i;
                //var category = "category-" + i;
                //var imageid = "imageid-" + i;
                //var desc = "desc-" + i;
                //var element = document.getElementById(name);
                //element.innerHTML = obj.events[i].name.text;
                //document.getElementById(imageid).style.backgroundImage = "url('" + obj.events[i].logo.url + "')";
                //document.getElementById(category).innerHTML = date1;
                //document.getElementById(desc).innerHTML = obj.events[i].summary;
                //document.getElementById(imageid).href = "EventDesc" + "?eventid=" + obj.events[i].id;
                //element.href = "EventDesc" + "?eventid=" + obj.events[i].id;
                var outerdiv = document.createElement("div");
                var innerdiv = document.createElement("div");
                var imglink = document.createElement("a");
                var contentholder = document.createElement("div");
                var spana = document.createElement("span");
                var namelink = document.createElement("a");
                var desc = document.createElement("address");
                var heading = document.createElement("h3");
                var category = document.createElement("span");
                var spandiv = document.createElement("div");
                /////
                outerdiv.className = "col-lg-12";
                innerdiv.className = "d-block d-md-flex listing";
                imglink.className = "img d-block";
                contentholder.className = "lh-content";
                spana.className = "category col-3";
                category.className = "category col-5 offset-4";
                spandiv.className = "row";
                /////
                if (obj.events[i].name.text === null) { continue; }
                if (obj.events[i].id === null) { continue; }
                if (obj.events[i].logo === null) { continue; }
                else { if (obj.events[i].logo.url === null) { continue;}}
                if (obj.events[i].summary === null) { continue; }
                if (obj.events[i].description.html === null) { continue; }
                namelink.innerHTML = obj.events[i].name.text;
                var linka = "EventDesc" + "?eventid=" + obj.events[i].id;
                namelink.setAttribute('href', linka);
                spana.innerHTML = date1;
                desc.innerHTML = obj.events[i].summary;
                imglink.style.backgroundImage = "url('" + obj.events[i].logo.url + "')";
                imglink.href = "EventDesc" + "?eventid=" + obj.events[i].id;
                category.innerHTML = obj.events[i].category.short_name;
                var div = document.getElementById("test2");
                spandiv.appendChild(spana);
                spandiv.appendChild(category);
                heading.appendChild(namelink);
                contentholder.appendChild(spandiv);
                contentholder.appendChild(heading);
                contentholder.appendChild(desc);
                innerdiv.appendChild(imglink);
                innerdiv.appendChild(contentholder);
                outerdiv.appendChild(innerdiv);
                div.appendChild(outerdiv);
            }
        }
        else {
            var outerdiv1 = document.createElement("div");
            var innerdiv1 = document.createElement("div");
            var desc1 = document.createElement("address");
            outerdiv1.className = "col-lg-12";
            innerdiv1.className = "d-block d-md-flex listing";
            desc1.innerHTML = "No Events found. Please search again using different options.";
            desc1.style = "align-content:center;font-weight:bold";
            var div1 = document.getElementById("test2");
            innerdiv1.appendChild(desc1);
            outerdiv1.appendChild(innerdiv1);
            div1.appendChild(outerdiv1);
            
        }
    }
};

request.send();
