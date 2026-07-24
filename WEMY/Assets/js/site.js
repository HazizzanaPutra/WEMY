document.addEventListener("DOMContentLoaded", function () {
    const sidebar = document.getElementById("sidebar");
    const content = document.getElementById("pageContent");
    const menuButton = document.getElementById("btnMenu");

    // Restore Sidebar State
    let collapsed = localStorage.getItem("sidebar");

    if (collapsed === "close") {
        sidebar.classList.add("close");
        content.classList.add("expand");
    }

    // Toggle Sidebar
    menuButton.addEventListener("click", function () {

        if (window.innerWidth <= 992) {

            sidebar.classList.toggle("open");

        } else {

            sidebar.classList.toggle("close");
            content.classList.toggle("expand");

            if (sidebar.classList.contains("close")) {
                localStorage.setItem("sidebar", "close");
            } else {
                localStorage.setItem("sidebar", "open");
            }

        }

    });

    // Active Menu
    let currentPage = window.location.pathname.split("/").pop();
    let links = document.querySelectorAll(".sidebar a");

    links.forEach(function (link) {
        let href = link.getAttribute("href");
        if (href === currentPage) {
            link.classList.add("active-menu");
        }
    });

});

/* JS Login */
const btnSignIn = document.getElementById("btnSignIn");
const loginModal = document.getElementById("loginModal");
const closeLogin = document.getElementById("closeLogin");

if (btnSignIn) {

    btnSignIn.addEventListener("click", function (e) {
        e.preventDefault();
        loginModal.classList.add("show");
    });

}

if (closeLogin) {

    closeLogin.addEventListener("click", function () {
        loginModal.classList.remove("show");
    });

}

window.addEventListener("click", function (e) {

    if (e.target === loginModal) {
        loginModal.classList.remove("show");
    }

});

/* Memanggil login di halaman lain seperti membership */
function openLoginModal() {

    const loginModal = document.getElementById("loginModal");

    if (loginModal) {
        loginModal.classList.add("show");
    }

}

function closeLoginModal() {

    const loginModal = document.getElementById("loginModal");

    if (loginModal) {
        loginModal.classList.remove("show");
    }

}