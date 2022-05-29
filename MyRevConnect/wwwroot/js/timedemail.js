// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

console.log("HELLO FUCKER");

document.addEventListener('DOMContentLoaded', () => {
    document
        .getElementById('timedEmailForm')
        .addEventListener('submit', handleForm);
});

function handleForm(ev) {
    ev.preventDefault(); //stop the page reloading
    //console.dir(ev.target);
    let myForm = ev.target;
    let fd = new FormData(myForm);

    //add more things that were not in the form
    fd.append('api-key', 'myApiKey');

    //look at all the contents
    for (let key of fd.keys()) {
        console.log(key, fd.get(key));
    }
    let json = convertFD2JSON(fd);

    //send the request with the formdata
    let url = 'https://localhost:7145/api/timedemail';
    let h = new Headers();
    h.append('Content-type', 'application/json');

    let req = new Request(url, {
        headers: h,
        body: json,
        method: 'POST',
    });
    console.log(req);
    fetch(req)
        .then((res) => res.json())
        .then((data) => {
            console.log('Response from server');
            console.log(data);
        })
        .catch(console.warn);

}

function convertFD2JSON(formData) {
    let obj = {};
    for (let key of formData.keys()) {
        obj[key] = formData.get(key);
    }
    return JSON.stringify(obj);
}