
// Create a WebSocket to Perform duplex Communication with server

const Token = document.querySelector("cnkrvb1r01ql60u34cb0cnkrvb1r01ql60u34cbg").value;
const socket = new WebSocket(`wss://ws.finnhub.io?token=${Token}`);

var stockSymbol = document.getElementById("StockSymbol").value;

// Connection opend. Subscribe to a symbol
socket.addEventListener('open', function (event) {
    socket.send(JSON.stringify({ 'type': 'subscribe', 'symbol': stockSymbol }))
});

// Listen (ready to receive ) for messages
socket.addEventListener('message', function (event) {
    // if error message is received from server 
    if (event.data.type == "error") {
        $(".price").text(event.data.msg);
        return; // exist the function 
    }

    var eventData = JSON.parse(event.data);
    if (eventData) {
        if (eventData.data) {
            // get the updated price 
            var updatedPrice = JSON.parse(event.data).data[0].p;
            var timeStamp = JSON.parse(event.data).data[0].t;
            // console.log (updatedPrice , timeStamp);
            // Console.log (new Date(timeStamp).toLocaleTimeString());

            // Update the UI
            $(".price").text(updatedPrice.toFixed(2)); // price - big display
        }
    }


});

// Unsubscribe 
var unsubscribe = function (symbol) {
    // disconnect from server 
    socket.send(JSON.stringify({ 'type': 'unsubscribe','symbol':symbol}))
}


// when the page is being closed , unsubscribe from the webSocket
window.onunload = function () {
    unsubscribe(stockSymbol);
};