/*

https://striveschool-api.herokuapp.com/api/product/

headers: {
"Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZjZjMzgxODQ0MjAwMTUzNzU5NzkiLCJpYXQiOjE3MTUzMzY4OTksImV4cCI6MTcxNjU0NjQ5OX0.wCi9iACGByDWkUPxIZPESrpehsVcPeuEmXz1efkg--M"
}

*/

const addressBarContent = new URLSearchParams(location.search);
console.log(addressBarContent);
const animeId = addressBarContent.get("animeId");
console.log(animeId);

const getAnimeData = function () {
  fetch("https://striveschool-api.herokuapp.com/api/product/" + animeId, {
    method: "GET",
    headers: {
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZjZjMzgxODQ0MjAwMTUzNzU5NzkiLCJpYXQiOjE3MTUzMzY4OTksImV4cCI6MTcxNjU0NjQ5OX0.wCi9iACGByDWkUPxIZPESrpehsVcPeuEmXz1efkg--M",
    },
  })
    .then((response) => {
      if (response.ok) {
        console.log("RESPONSE", response);
        return response.json();
      } else {
        throw new Error("Errore nel recupero dati");
      }
    })
    .then((event) => {
      console.log(event);

      document.getElementById("loading").classList.add("d-none");
      document.getElementById("name").innerText = event.name;
      document.getElementById("description").innerText = event.description;
      document.getElementById("author").innerText = event.brand;
      document.getElementById("image").setAttribute("src", event.imageUrl);
      document.getElementById("price").innerText = event.price;
    })
    .catch((err) => {
      alert("ERRORE", err);
    });
};

const editButton = document.getElementById("editButton");
editButton.addEventListener("click", function () {
  location.assign(`backoffice.html?animeId=${animeId}`);
});

getAnimeData();
