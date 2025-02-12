var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44314/SignalRHub/").build();

connection.start().then(() => {
    setInterval(() => {
        connection.invoke("SendBasket");
    });




}).catch((err) => {
    console.log(err);
});

connection.on("ReceiveBasketProductCount", (basketCountValue) => {
    if (basketCountValue != 0) {
        $("#basketCount").text(basketCountValue);
    }
});