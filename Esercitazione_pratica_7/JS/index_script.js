const getCards = function (array) {
  const row = document.getElementById("principal-row");
  row.innerHTML = "";
  array.forEach((element) => {
    const newCol = document.createElement("div");
    newCol.classList.add("col-md-4");
    newCol.innerHTML = `<div class="card mb-4 shadow-sm h-100">
        
            <img src=${element.imageUrl} class="bd-placeholder-img card-img-top" alt="Copertina"/>
        
        <div class="card-body d-flex flex-column justify-content-between">

            <h5 class="card-title">${element.name}</h5>
            <div class="d-flex justify-content-between align-items-center">
                <div class="btn-group">
                    <a href="details.html?animeId=${element._id}" class="btn btn-sm btn-outline-secondary">View</a>
                    <button type="button" class="btn btn-sm btn-outline-secondary">€${element.price}</button>
                    <a
                      href="backoffice.html?animeId=${element._id}"
                      class="btn btn-sm btn-outline-secondary"
                      id="editButton"
                    >
                      Modifica
                    </a>
                </div>
                <small class="text-muted">${element.brand}</small>
            </div>
          </div>
        </div>`;
    row.appendChild(newCol);
  });
};

const getAnime = function () {
  fetch("https://striveschool-api.herokuapp.com/api/product", {
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
        if (response.status === 404) {
          throw new Error("La risorsa richiesta non è stata trovata");
        } else if (response.status === 500) {
          throw new Error("La risposta del server è stata negativa"); // creo un errore e sollevo un'eccezione
        }
      }
    })
    .then((array) => {
      console.log(array);
      getCards(array);
    })
    .catch((err) => {
      alert("ERRORE", err);
    });
};

getAnime();
