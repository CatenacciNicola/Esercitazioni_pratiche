/*

https://striveschool-api.herokuapp.com/api/product/

headers: {
"Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZjZjMzgxODQ0MjAwMTUzNzU5NzkiLCJpYXQiOjE3MTUzMzY4OTksImV4cCI6MTcxNjU0NjQ5OX0.wCi9iACGByDWkUPxIZPESrpehsVcPeuEmXz1efkg--M"
}

*/

class Anime {
  constructor(_name, _description, _author, _url, _price) {
    this.name = _name;
    this.description = _description;
    this.brand = _author;
    this.imageUrl = _url;
    this.price = _price;
  }
}

const nameInput = document.getElementById("name");
const descriptionInput = document.getElementById("description");
const authorInput = document.getElementById("author");
const imageInput = document.getElementById("image");
const priceInput = document.getElementById("price");

const addressBarContent = new URLSearchParams(location.search);
console.log(addressBarContent);
const animeId = addressBarContent.get("animeId");
console.log(animeId);

let animeToModify;

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
      document.getElementById("name").value = event.name;
      document.getElementById("description").value = event.description;
      document.getElementById("author").value = event.brand;
      document.getElementById("image").value = event.imageUrl;
      document.getElementById("price").value = event.price;
      animeToModify = event;
    })
    .catch((err) => {
      alert("ERRORE", err);
    });
};

if (animeId) {
  getAnimeData();
  document.getElementById("modifiedButton").innerText = "Modifica!";
  const deleteButton = document.getElementById("deleteButton");
  deleteButton.classList.remove("d-none");
}

const submitAnime = function (e) {
  e.preventDefault();

  const animeFromForm = new Anime(
    nameInput.value,
    descriptionInput.value,
    authorInput.value,
    imageInput.value,
    priceInput.value
  );

  console.log("Anime da inviare", animeFromForm);

  let URL = "https://striveschool-api.herokuapp.com/api/product";
  let newMethod = "POST";

  if (animeId) {
    URL = `https://striveschool-api.herokuapp.com/api/product/${animeToModify._id}`;
    newMethod = "PUT";
  }

  fetch(URL, {
    method: newMethod,
    body: JSON.stringify(animeFromForm),
    headers: {
      "Content-type": "application/json",
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZjZjMzgxODQ0MjAwMTUzNzU5NzkiLCJpYXQiOjE3MTUzMzY4OTksImV4cCI6MTcxNjU0NjQ5OX0.wCi9iACGByDWkUPxIZPESrpehsVcPeuEmXz1efkg--M",
    },
  })
    .then((response) => {
      if (response.ok) {
        console.log("RESPONSE", response);
        if (animeId) {
          alert("Anime modificato");
        } else {
          alert("Anime Salvato");
        }
        return response.json();
      } else {
        if (response.status === 404) {
          throw new Error("La risorsa richiesta non è stata trovata");
        } else if (response.status === 500) {
          throw new Error("La risposta del server è stata negativa"); // creo un errore e sollevo un'eccezione
        }
      }
    })
    .then((array) => {
      console.log(array);
    })
    .catch((err) => {
      alert.log("ERRORE", err);
    });
};

const resetForm = function () {
  nameInput.value = "";
  descriptionInput.value = "";
  authorInput.value = "";
  imageInput.value = "";
  priceInput.value = "";
};

const deleteAnime = function () {
  fetch("https://striveschool-api.herokuapp.com/api/product/" + animeId, {
    method: "DELETE",
    headers: {
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZjZjMzgxODQ0MjAwMTUzNzU5NzkiLCJpYXQiOjE3MTUzMzY4OTksImV4cCI6MTcxNjU0NjQ5OX0.wCi9iACGByDWkUPxIZPESrpehsVcPeuEmXz1efkg--M",
    },
  })
    .then((response) => {
      if (response.ok) {
        alert("Risorsa Eliminata");
        location.assign("index.html");
      } else {
        alert("Risorsa non eliminata");
      }
    })
    .catch((err) => {
      alert("ERRORE", err);
    });
};

const animeForm = document.getElementById("animeForm");
animeForm.addEventListener("submit", submitAnime);
