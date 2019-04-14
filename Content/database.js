/*jQuery.ajax({
    url: 'DatabaseController.cs',
    type: "POST",
    data: 
})*/


//Grabs message from controller
function GetMessage()
{
    $.get("/Database/GetMessage",
        function (data)
        {
            $("#asdf").html(data);
        });
}

//Connects to database
function ConnectToDatabase()
{
    $.get("/Home/ConnectToDatabase",
        function (data)
        {
            $("#db").html(data);
        });
}

//Sends SQL query to database
function SearchDatabase()
{
    var query = document.getElementById("searchbox").value;
    $.get("/Database/Search", { query },
        function (response)
        {
            $("#db").html(response);
        });
}

function AddToDatabase()
{
    var event_name = $("#event_name").val();
    var event_date = $("#date").val();
    var event_start = $("#start_time").val();
    var event_end = $("#end_time").val();
    var event_info = $("#description").val();
    var event_address = $("#adress").val();


    $.post("/Home/AddToDatabase",
        {event_date = eventdate, event_name = eventname, event_start = start, event_end = end, event_address = address, descript = event_info, food_type = categories});
}