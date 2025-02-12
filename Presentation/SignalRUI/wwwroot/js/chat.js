var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44314/SignalRHub").build();

document.getElementById("btnSendMessage").disabled = true;

connection.on("ReceiveMessage", function (user, message)  {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += `: ${message} - ${currentHour}:${currentMinute} <hr />`;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("btnSendMessage").disabled = false;
}).catch(function (err) {
    return console.log(err.toString());
});

document.getElementById("btnSendMessage").addEventListener("click", function (event) {
    var user = document.getElementById("userNameInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.log(err.toString());
    });
    event.preventDefault();
});