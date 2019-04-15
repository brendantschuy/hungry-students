//AJAX/JSON template if needed later:
/*jQuery.ajax({
    url: 'DatabaseController.cs',
    type: "POST",
    data: 
})*/

/*Function that tests database connection for debugging
purposes.*/
function ConnectToDatabase() {
    $.get("/Home/ConnectToDatabase", function (data) {
        //$("p").html(data);
    });
}

/*Sends search query to server. Server handles with SQL request
and returns list of DatabaseEntry model objects. Function loops
through JSON object and prints names.*/
function SearchDatabase()
{
    var query = document.getElementById("search-description").value;
    $.get("/Home/Search", { query },
        function (response)
        {
            var length = response.data.length;
            for(i = 0; i < length; i++)
            {
                $('#db').append(response.data[i].eventName + "<br/>");
            }
        });
}

/*Function not implemented yet. This will send an AJAX request 
to server using an object created from user input.*/
function AddToDatabase()
{
    /*var eventname = $("#event_name").val();
    var eventdate = $("#date").val();
    var start = $("#start_time").val();
    var end = $("#end_time").val();
    var event_info = $("#description").val();
    var address = $("#adress").val();


    $.post("/Home/AddToDatabase",
        {event_date = eventdate, 
        event_name = eventname,
        event_start = start,
        event_end = end,
        event_address = address,
        descript = event_info,
        food_type = categories});*/
}