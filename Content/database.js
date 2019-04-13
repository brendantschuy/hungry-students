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
    $.get("/Database/ConnectToDatabase",
        function (data)
        {
            $("#db").html(data);
        });
}

//Sends SQL query to database
function Search()
{
    var query = document.getElementById("searchbox").value;
    $.get("/Database/SendQuery", { query },
        function (response)
        {
            $("#db").html(response);
        });
}