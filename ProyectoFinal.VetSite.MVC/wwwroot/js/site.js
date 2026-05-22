document.addEventListener("DOMContentLoaded", () => {
    const body = document.body;
    const sidebar = document.getElementById("sidebar");
    const openButtons = document.querySelectorAll("[data-sidebar-toggle]");
    const closeButtons = document.querySelectorAll("[data-sidebar-close]");

    const setSidebarState = (open) => {
        if (!sidebar) {
            return;
        }

        body.classList.toggle("sidebar-open", open);
        sidebar.setAttribute("aria-hidden", open ? "false" : "true");
    };

    openButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const shouldOpen = !body.classList.contains("sidebar-open");
            setSidebarState(shouldOpen);
        });
    });

    closeButtons.forEach((button) => {
        button.addEventListener("click", () => setSidebarState(false));
    });

    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && body.classList.contains("sidebar-open")) {
            setSidebarState(false);
        }
    });

    if (window.innerWidth >= 1200) {
        setSidebarState(false);
    }
});
