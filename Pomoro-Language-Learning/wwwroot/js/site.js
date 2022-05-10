// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// card flip effect
.flipCard {
    transform: rotateY(180deg);
}

const card = document.getElementById("card")

function flipcard() {
    card.classList.toggle("flipcard");
}