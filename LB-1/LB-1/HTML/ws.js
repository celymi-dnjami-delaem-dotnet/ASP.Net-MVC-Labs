var ws;

function openWs() {
    if (!ws) {
        ws = new WebSocket("wss://localhost:44300/ws.ws");

        ws.onopen = () => {
            ws.send("Opened connection");

            document.getElementById("open-button").disabled = true;
            document.getElementById("close-button").disabled = false;
        }

        ws.onmessage = event => {
            var data = event.data;
            createSpan(data);
        }
    }
}

function closeWs() {
    createSpan("Closed connection");
    ws.close();
    ws = null;

    document.getElementById("open-button").disabled = false;
    document.getElementById("close-button").disabled = true;
}

function createSpan(message) {
    var textElement = document.createElement("span");
    textElement.innerHTML = message;

    document.getElementById("message-container").appendChild(textElement);
}