/*
REGOLE
- Tutte le risposte devono essere scritte in JavaScript
- Se sei in difficoltà puoi chiedere aiuto a un Teaching Assistant
- Puoi usare Google / StackOverflow ma solo quanto ritieni di aver bisogno di qualcosa che non è stato spiegato a lezione
- Puoi testare il tuo codice in un file separato, o de-commentando un esercizio alla volta
- Per farlo puoi utilizzare il terminale Bash, quello di VSCode o quello del tuo sistema operativo (se utilizzi macOS o Linux)
*/

// JS Basics

/* ESERCIZIO A
  Crea una variabile chiamata "sum" e assegnaci il risultato della somma tra i valori 10 e 20.
*/

var num1=10;
var num2=20;
var sum=num1+num2;


console.log("Esercizio A: " + sum);


/* ESERCIZIO B
  Crea una variabile chiamata "random" e assegnaci un numero casuale tra 0 e 20 (deve essere generato dinamicamente a ogni esecuzione).
*/

var random=Math.floor(Math.random()*21)


console.log("Esercizio B: " + random)


/* ESERCIZIO C
  Crea una variabile chiamata "me" e assegnaci un oggetto contenente le seguenti proprietà: name = il tuo nome, surname = il tuo cognome, age = la tua età.
*/


var me={
  name:"Nicola",
  surname:"Catenacci",
  age:29
}

console.log("Esercizio C: ")
console.log(me)


/* ESERCIZIO D
  Crea del codice per rimuovere programmaticamente la proprietà "age" dall'oggetto precedentemente creato.
*/


delete me.age;

console.log("Esercizio D: ")
console.log(me)


/* ESERCIZIO E
  Crea del codice per aggiungere programmaticamente all'oggetto precedentemente creato un array chiamato "skills", contenente i linguaggi di programmazione che conosci.
*/


me.skills=["Html","CSS","JavaScript"]

console.log("Esercizio E: ")
console.log(me)


/* ESERCIZIO F
  Crea un pezzo di codice per aggiungere un nuovo elemento all'array "skills" contenuto nell'oggetto "me".
*/


me.skills.push("Angular")

console.log("Esercizio F: ")
console.log(me)


/* ESERCIZIO G
  Crea un pezzo di codice per rimuovere programmaticamente l'ultimo elemento dall'array "skills" contenuto nell'oggetto "me".
*/


me.skills.pop()

console.log("Esercizio G: ")
console.log(me)

// Funzioni

/* ESERCIZIO 1
  Crea una funzione chiamata "dice": deve generare un numero casuale tra 1 e 6.
*/


function dice(){
  return Math.ceil(Math.random()*6)
}

console.log("Esercizio 1: " + dice())


/* ESERCIZIO 2
  Crea una funzione chiamata "whoIsBigger" che riceve due numeri come parametri e ritorna il maggiore dei due.
*/


function whoisBigger(num1,num2){
  if(num1>num2){
    return num1
  }
  else{
    return num2
  }
}

console.log("Esercizio 2: " + whoisBigger(10,8))


/* ESERCIZIO 3
  Crea una funzione chiamata "splitMe" che riceve una stringa come parametro e ritorna un'array contenente ogni parola della stringa.

  Es.: splitMe("I love coding") => ritorna ["I", "Love", "Coding"]
*/


function spitMe(stringa){
  return stringa.split(" ")
}
var stringaEs3="Questo è l'esercizio 3";

console.log("Esercizio 3: " + spitMe(stringaEs3))


/* ESERCIZIO 4
  Crea una funzione chiamata "deleteOne" che riceve una stringa e un booleano come parametri.
  Se il valore booleano è true la funzione deve ritornare la stringa senza il primo carattere, altrimenti la deve ritornare senza l'ultimo.
*/

function deleteOne(stringa,isTrue){
  if(isTrue===true){
    return stringa.slice(1)
  }
  else{
    return stringa.slice(-stringa.length,-1)
  }
}

console.log("Esercizio 4: " + deleteOne("Questo è l'esercizio 4",false))

//posso ottenere un valore booleano in molti modi, ad esempio
/*var numeroEs4= 3>4;
console.log("Esercizio 4: " + deleteOne("Questo è l'esercizio 4!",numeroEs4))
*/

/* ESERCIZIO 5
  Crea una funzione chiamata "onlyLetters" che riceve una stringa come parametro e la ritorna eliminando tutte le cifre numeriche.

  Es.: onlyLetters("I have 4 dogs") => ritorna "I have dogs"
*/

function onlyLetters(stringa){
  let nuovaStringa=stringa.replace(/[0-9]+/g,"");
  return nuovaStringa
}
let stringaEs5="Questa è 1 soluzione dell'esercizio 5"

console.log("Esercizio 5: " + onlyLetters(stringaEs5))

/* ESERCIZIO 6
  Crea una funzione chiamata "isThisAnEmail" che riceve una stringa come parametro e ritorna true se la stringa è un valido indirizzo email.
*/

function isThisAnEmail(stringa){
  return stringa.includes("@",1)
}
let stringaEs6="indirizzo@email"

console.log("Esercizio 6: " + isThisAnEmail(stringaEs6))

/* ESERCIZIO 7
  Scrivi una funzione chiamata "whatDayIsIt" che ritorna il giorno della settimana corrente.
*/


var giorni = new Array();
giorni[0] = "Domenica";
giorni[1] = "Lunedì";
giorni[2] = "Martedì";
giorni[3] = "Mercoledì";
giorni[4] = "Giovedì";
giorni[5] = "Venerdì";
giorni[6] = "Sabato";

function whatDayIsIt(){
  let x=new Date();
  return giorni[x.getDay()]
}

console.log("Esercizio 8: "+ whatDayIsIt())

/* ESERCIZIO 8
  Scrivi una funzione chiamata "rollTheDices" che riceve un numero come parametro.
  Deve invocare la precedente funzione dice() il numero di volte specificato nel parametro, e deve tornare un oggetto contenente una proprietà "sum":
  il suo valore deve rappresentare il totale di tutti i valori estratti con le invocazioni di dice().
  L'oggetto ritornato deve anche contenere una proprietà "values", contenente un array con tutti i valori estratti dalle invocazioni di dice().

  Example:
  rollTheDices(3) => ritorna {
      sum: 10
      values: [3, 3, 4]
  }
*/

function rollTheDices(numeroEs8){
  let OggettoEs8= new Object;
  let ArrayEs8= new Array;
  let somma=0;
  for(i=0;i<numeroEs8;i++){
    let valore=dice();
    somma+=valore;
    ArrayEs8.push(valore)
  }
  OggettoEs8.sum=somma;
  OggettoEs8.values=ArrayEs8;
  return OggettoEs8;
}

console.log("Esercizio 8: ")
console.log(rollTheDices(5))

/* ESERCIZIO 9
  Scrivi una funzione chiamata "howManyDays" che riceve una data come parametro e ritorna il numero di giorni trascorsi da tale data.
*/

function howManyDays(data){
  let x=new Date();
  let dataInMillisecondi=data.getTime();
  let oggiInMillisecondi=x.getTime();
  let MillisecondiTrascorsi=oggiInMillisecondi-dataInMillisecondi;
  let giorniTrascorsi=Math.round(MillisecondiTrascorsi/(1000*3600*24))
  return giorniTrascorsi
}

let data=new Date(1995,2,21)
console.log("Esercizio 9: " + howManyDays(data))

/* ESERCIZIO 10
  Scrivi una funzione chiamata "isTodayMyBirthday" che deve ritornare true se oggi è il tuo compleanno, falso negli altri casi.
*/

function isTodayMyBirthday(){
  let data=new Date();
  let compleanno=new Date(data.getFullYear(),2,21)
  return data.getDate()==compleanno.getDate() && data.getMonth()==compleanno.getMonth()
}

console.log("Esercizio 10: " + isTodayMyBirthday())

// Arrays & Oggetti

// NOTA: l'array "movies" usato in alcuni esercizi è definito alla fine di questo file

/* Questo array viene usato per gli esercizi. Non modificarlo. */

const movies = [
  {
    Title: 'The Lord of the Rings: The Fellowship of the Ring',
    Year: '2001',
    imdbID: 'tt0120737',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SX300.jpg',
  },

  {
    Title: 'The Lord of the Rings: The Return of the King',
    Year: '2003',
    imdbID: 'tt0167260',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings: The Two Towers',
    Year: '2002',
    imdbID: 'tt0167261',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of War',
    Year: '2005',
    imdbID: 'tt0399295',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTYzZWE3MDAtZjZkMi00MzhlLTlhZDUtNmI2Zjg3OWVlZWI0XkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg',
  },
  {
    Title: 'Lords of Dogtown',
    Year: '2005',
    imdbID: 'tt0355702',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNDBhNGJlOTAtM2ExNi00NmEzLWFmZTQtYTZhYTRlNjJjODhmXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings',
    Year: '1978',
    imdbID: 'tt0077869',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOGMyNWJhZmYtNGQxYi00Y2ZjLWJmNjktNTgzZWJjOTg4YjM3L2ltYWdlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of the Flies',
    Year: '1990',
    imdbID: 'tt0100054',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOTI2NTQyODk0M15BMl5BanBnXkFtZTcwNTQ3NDk0NA@@._V1_SX300.jpg',
  },
  {
    Title: 'The Lords of Salem',
    Year: '2012',
    imdbID: 'tt1731697',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMjA2NTc5Njc4MV5BMl5BanBnXkFtZTcwNTYzMTcwOQ@@._V1_SX300.jpg',
  },
  {
    Title: 'Greystoke: The Legend of Tarzan, Lord of the Apes',
    Year: '1984',
    imdbID: 'tt0087365',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTM5MzcwOTg4MF5BMl5BanBnXkFtZTgwOTQwMzQxMDE@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of the Flies',
    Year: '1963',
    imdbID: 'tt0057261',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOGEwYTlhMTgtODBlNC00ZjgzLTk1ZmEtNmNkMTEwYTZiM2Y0XkEyXkFqcGdeQXVyMzU4Nzk4MDI@._V1_SX300.jpg',
  },
  {
    Title: 'The Avengers',
    Year: '2012',
    imdbID: 'tt0848228',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Infinity War',
    Year: '2018',
    imdbID: 'tt4154756',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Age of Ultron',
    Year: '2015',
    imdbID: 'tt2395427',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTM4OGJmNWMtOTM4Ni00NTE3LTg3MDItZmQxYjc4N2JhNmUxXkEyXkFqcGdeQXVyNTgzMDMzMTg@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Endgame',
    Year: '2019',
    imdbID: 'tt4154796',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SX300.jpg',
  },
]
/* ESERCIZIO 11
  Scrivi una funzione chiamata "deleteProp" che riceve un oggetto e una stringa come parametri; deve ritornare l'oggetto fornito dopo aver eliminato
  in esso la proprietà chiamata come la stringa passata come secondo parametro.
*/

function deleteProp(oggetto,stringaEs11){
  delete oggetto[stringaEs11]
  return oggetto
}

let oggettoEs11={
  primo:1,
  secondo:2,
  terzo:3
}
deleteProp(oggettoEs11,"secondo")
console.log("Esercizio 11: ")
console.log(oggettoEs11)

/* ESERCIZIO 12
  Scrivi una funzione chiamata "newestMovie" che trova il film più recente nell'array "movies" fornito.
*/

function newestMovie(movies){
  let PiuRecente=movies[0]
  for(let i=0;i<movies.length;i++){
    let anni=parseInt(movies[i].Year)
    let annirecente=parseInt(PiuRecente.Year)
    if(anni>annirecente){
      PiuRecente=movies[i]
    }
  }
  return PiuRecente
}
console.log("Esercizio 12: ")
console.log(newestMovie(movies))

/* ESERCIZIO 13
  Scrivi una funzione chiamata countMovies che ritorna il numero di film contenuti nell'array "movies" fornito.
*/

function countMovies(movies){
  return movies.length;
}

console.log("Esercizio 13: " + countMovies(movies))

/* ESERCIZIO 14
  Scrivi una funzione chiamata "onlyTheYears" che crea un array con solamente gli anni di uscita dei film contenuti nell'array "movies" fornito.
*/
let ArrayEs14=new Array;
function onlyTheYears(movies){
  for(let i=0;i<movies.length;i++){
    let anni=movies[i].Year
    ArrayEs14.push(parseInt(anni))
  }
  return ArrayEs14
}
onlyTheYears(movies)
console.log("Esercizio 14: " + ArrayEs14)

/* ESERCIZIO 15
  Scrivi una funzione chiamata "onlyInLastMillennium" che ritorna solamente i film prodotto nel millennio scorso contenuti nell'array "movies" fornito.
*/

function onlyInLastMillenium(movies) {
  let vecchi=movies.filter(function(film) {
    return parseInt(film.Year) > 1000 && parseInt(film.Year)<2000;
  });
  return vecchi;
}

console.log("Esercizio 15: ")
console.log(onlyInLastMillenium(movies))

/* ESERCIZIO 16
  Scrivi una funzione chiamata "sumAllTheYears" che ritorna la somma di tutti gli anni in cui sono stati prodotti i film contenuti nell'array "movies" fornito.
*/

function sumAllTheYears(total,num){
  return total+num;
}

console.log("Esercizio 16: " + ArrayEs14.reduce(sumAllTheYears))

/* ESERCIZIO 17
  Scrivi una funzione chiamata "searchByTitle" che riceve una stringa come parametro e ritorna i film nell'array "movies" fornito che la contengono nel titolo.
*/

function searchByTitle(stringa){
  return movies.filter(function(film){
    return film.Title.includes(stringa)
  })
}

let stringaEs17="the"
console.log("Esercizio 17: ")
console.log(searchByTitle(stringaEs17))

/* ESERCIZIO 18
  Scrivi una funzione chiamata "searchAndDivide" che riceve una stringa come parametro e ritorna un oggetto contenente due array: "match" e "unmatch".
  "match" deve includere tutti i film dell'array "movies" fornito che contengono la stringa fornita all'interno del proprio titolo, mentre "unmatch" deve includere tutti i rimanenti.
*/

function searchAndDivide(stringa){
  let match=[];
  let unmatch=[];
  movies.filter(function(film){
    if(film.Title.includes(stringa)){
      match.push(film)
    }
    else{
      unmatch.push(film)
    }
   
  })
  return {match:match,unmatch:unmatch};
}

let stringaEs18="the"
console.log("Esercizio 18: ")
console.log(searchAndDivide(stringaEs18))

/* ESERCIZIO 19
  Scrivi una funzione chiamata "removeIndex" che riceve un numero come parametro e ritorna l'array "movies" fornito privo dell'elemento nella posizione ricevuta come parametro.
*/

function removeIndex(numero){
  movies.splice(numero,1)
  return movies;
}
console.log("Esercizio 19: ")
console.log(removeIndex(3))

// DOM (nota: gli elementi che selezionerai non si trovano realmente nella pagina)

/* ESERCIZIO 20
  Scrivi una funzione per selezionare l'elemento dotato di id "container" all'interno della pagina.
*/

function Es20(){
  return document.getElementById("container")
}

// let elementEs20=document.querySelector("#container")
Es20()

/* ESERCIZIO 21
  Scrivi una funzione per selezionare ogni tag <td> all'interno della pagina.
*/

function Es21(){
  return document.querySelectorAll("td")
}

//let elementEs20=document.getElementsByTagName("td")
Es21()

/* ESERCIZIO 22
  Scrivi una funzione che, tramite un ciclo, stampa in console il testo contenuto in ogni tag <td> all'interno della pagina.
*/

function Es22(){
  let elementEs22=document.querySelectorAll("td")
  for(let i=0;i<elementEs22.length;i++){
    console.log(elementEs22[i].textContent)
  }
}

console.log("Esercizio 22: ")
Es22()

/* ESERCIZIO 23
  Scrivi una funzione per aggiungere un background di colore rosso a ogni link all'interno della pagina.
*/

function Es23(){
  let elementEs23=document.querySelectorAll("a")
  for(let i=0;i<elementEs23.length;i++){
    elementEs23[i].style.backgroundColor="red"
  }
}

Es23()

/* ESERCIZIO 24
  Scrivi una funzione per aggiungere un nuovo elemento alla lista non ordinata con id "myList".
*/

function Es24(){
  let elementEs24=document.createElement("li")
  let lista=document.getElementById("myList")
  elementEs24.innerText="3"
  lista.appendChild(elementEs24)
}

Es24()

/* ESERCIZIO 25
  Scrivi una funzione per svuotare la lista non ordinata con id "myList".
*/

function Es25(){
  let lista=document.getElementById("myList")
  let elementEs25=document.querySelectorAll("#myList li")
  for(let i=0;i<elementEs25.length;i++){
    lista.removeChild(elementEs25[i])
  }
}

Es25()

/* ESERCIZIO 26
  Scrivi una funzione per aggiungere ad ogni tag <tr> la classe CSS "test"
*/

function Es26(){
  let elementEs26=document.querySelectorAll("tr")
  for(let i=0;i<elementEs26.length;i++){
    elementEs26[i].classList.add("test")
  }
}

Es26()

// [EXTRA] JS Avanzato

/* ESERCIZIO 27
  Crea una funzione chiamata "halfTree" che riceve un numero come parametro e costruisce un mezzo albero di "*" (asterischi) dell'altezza fornita.

  Esempio:
  halfTree(3)

  *
  **
  ***

*/

console.log("Esercizio 27: ")
function halfTree(numero){
 
  for(let i=1;i<=numero;i++){
    let numeroDiAsterischi="";
    for (let x=0;x<i;x++){
      numeroDiAsterischi+="*"
    }
    console.log(numeroDiAsterischi)
  }
  
}

halfTree(5)



/* ESERCIZIO 28
  Crea una funzione chiamata "tree" che riceve un numero come parametro e costruisce un albero di "*" (asterischi) dell'altezza fornita.

  Esempio:
  tree(3)

    *
   ***
  *****

*/



/* ESERCIZIO 29
  Crea una funzione chiamata "isItPrime" che riceve un numero come parametro e ritorna true se il numero fornito è un numero primo.
*/

