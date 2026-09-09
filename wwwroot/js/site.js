document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll("input").forEach(input => {
        input.addEventListener("input", () => input.classList.remove("input-error"));
    });
});
