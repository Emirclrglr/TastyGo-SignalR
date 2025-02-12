$(document).ready(() => {
	var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44314/SignalRHub").build();

	$("#connstatus").text(connection.state);


	connection.start().then(() => {

		$("#connstatus").text(connection.state);

		setInterval(() => {
			connection.invoke("SendStatistics");
		}, 1000);


	}).catch((err) => {
		console.log(err);
	})

	connection.on("ReceiveCategoryCount", (value) => {
		$("#categoryCount").text(value);
	});

	connection.on("ReceiveProductCount", (productCountValue) => {
		$("#productCount").text(productCountValue);
	})

	connection.on("ReceiveActiveCategoryCount", (activeCategoryCountValue) => {
		$("#activeCategoryCount").text(activeCategoryCountValue);
	})

	connection.on("ReceivePassiveCategoryCount", (passiveCategoryCountValue) => {
		$("#passiveCategoryCount").text(passiveCategoryCountValue);
	})

});