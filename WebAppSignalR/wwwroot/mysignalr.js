setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/stamperhub")
        .build();

    connection.on("StatusUpdate", (update) => {
            const statusDiv = document.getElementById("status");
            statusDiv.innerHTML = update;
        }
    );

    connection.on("UploadFiles", function() {
            var statusDiv = document.getElementById("status");
            statusDiv.innerHTML = "Someone upload files";
        }
    );

    connection.on("finished", function() {
        connection.stop();
        const statusDiv = document.getElementById("status");
        statusDiv.innerHTML = "Proceso terminado";
        }
    );

    connection.start()
        .catch(err => console.error(err.toString())); 
};

setupConnection();

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();
    const product = document.getElementById("product").value;
    const size = document.getElementById("size").value;

    fetch("/Home",
        {
            method: "POST",
            body: JSON.stringify({ product, size }),
            headers: {
               'content-type': 'application/json'
            }
        })
        .then(response => response.text())
        .then(id => connection.invoke("GetUpdate"));

});