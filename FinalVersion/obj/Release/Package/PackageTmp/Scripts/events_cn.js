

var request = new XMLHttpRequest();
//modalcategories = sessionStorage['modalstuff'];
var modalcategories;
if (sessionStorage.getItem('modalstuff') === null) { modalcategories = "115,104,120,108,109"; }
else { modalcategories = sessionStorage.getItem('modalstuff');}
modalcategories = "&categories=" + modalcategories;
requrl = 'https://www.eventbriteapi.com/v3/events/search/?expand=category&sort_by=best&location.address=Melbourne%2CVIC&location.within=2km';
requrl = requrl.concat(modalcategories);
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
        for (var i = 1; i<= 9; i++)
        {
            var date = new Date(obj.events[i].start.local);
            var date1 = month[date.getMonth()] + " " + date.getDate();
            //var name = "name-" + i;
            //var category = "category-" + i;
            //var imageid = "imageid-" + i;
            //var imageurl = "url('" + obj.events[i].logo.url + "')";
            var outerdiv = document.createElement("div");
            var innerdiv = document.createElement("div");
            var imglink = document.createElement("a");
            var contentholder = document.createElement("div");
            var spana = document.createElement("span");
            var namelink = document.createElement("a");
            var heading = document.createElement("h3");
            var category = document.createElement("span");
            var spandiv = document.createElement("div");
            //var element = document.getElementById(name);
            //element.innerHTML = obj.events[i].name.text;
            //document.getElementById(imageid).style.backgroundImage = "url('" + obj.events[i].logo.url + "')";
            //document.getElementById(category).innerHTML = date1;
            //document.getElementById(imageid).href = "EventDesc" + "?eventid=" + obj.events[i].id;
            //element.href = "EventDesc" + "?eventid=" + obj.events[i].id;
            /////
            outerdiv.className = "col-lg-4 bigger";
            innerdiv.className = "d-block d-md-flex listing vertical";
            imglink.className = "img d-block";
            contentholder.className = "lh-content";
            spana.className = "category col-3";
            category.className = "category col-5 offset-4";
            spandiv.className = "row";
            /////
            if (obj.events[i].name.text === null) { continue; }
            if (obj.events[i].id === null) { continue; }
            if (obj.events[i].logo === null) { continue; }
            else { if (obj.events[i].logo.url === null) { continue; } }
            if (obj.events[i].summary === null) { continue; }
            if (obj.events[i].description.html === null) { continue; }
            namelink.innerHTML = obj.events[i].name.text;
            var linka = "EventDesc_CN" + "?eventid=" + obj.events[i].id;
            namelink.setAttribute('href', linka);
            spana.innerHTML = date1;
            category.innerHTML = obj.events[i].category.short_name;
            imglink.style.backgroundImage = "url('" + obj.events[i].logo.url + "')";
            imglink.href = "EventDesc_CN" + "?eventid=" + obj.events[i].id;
            spandiv.appendChild(spana);
            spandiv.appendChild(category);
            var div = document.getElementById("test2");
            contentholder.appendChild(spandiv);
            heading.appendChild(namelink);
            contentholder.appendChild(heading);
            innerdiv.appendChild(imglink);
            innerdiv.appendChild(contentholder);
            outerdiv.appendChild(innerdiv);
            div.appendChild(outerdiv);
        }
        document.getElementById("myview1").scrollIntoView();
    }
};

request.send();
