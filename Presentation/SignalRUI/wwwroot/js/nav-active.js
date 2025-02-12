document.addEventListener("DOMContentLoaded", function () {
    const currentPath = window.location.pathname; 
    const navItems = document.querySelectorAll(".nav-item a"); 

    navItems.forEach(link => {
        if (link.getAttribute("href") === currentPath) {
            link.parentElement.classList.add("active"); 
        }
    });
});