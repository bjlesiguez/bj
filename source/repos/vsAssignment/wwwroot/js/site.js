// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

// Add simple animation to the h1 element
const heading = document.querySelector("h1");
heading.addEventListener("mouseover", () => {
    heading.style.color = "red";
});
heading.addEventListener("mouseout", () => {
    heading.style.color = "#333";
});