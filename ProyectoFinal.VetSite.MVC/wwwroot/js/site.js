document.addEventListener("DOMContentLoaded", () => {
    const body = document.body;
    const sidebar = document.getElementById("sidebar");
    const openButtons = document.querySelectorAll("[data-sidebar-toggle]");
    const closeButtons = document.querySelectorAll("[data-sidebar-close]");
    const sidebarGroups = document.querySelectorAll("[data-sidebar-group]");
    const sidebarStorageKey = "vetsite.sidebar.open";
    const sidebarGroupStoragePrefix = "vetsite.sidebar.group.";

    const setSidebarState = (open) => {
        if (!sidebar) {
            return;
        }

        body.classList.toggle("sidebar-open", open);
        sidebar.setAttribute("aria-hidden", open ? "false" : "true");
        localStorage.setItem(sidebarStorageKey, open ? "true" : "false");
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

    sidebarGroups.forEach((group) => {
        const groupName = group.getAttribute("data-sidebar-group");
        const toggle = group.querySelector("[data-sidebar-group-toggle]");
        const storageKey = `${sidebarGroupStoragePrefix}${groupName}`;
        const storedState = localStorage.getItem(storageKey);
        const shouldOpen = storedState === null ? true : storedState === "true";

        group.classList.toggle("collapsed", !shouldOpen);
        toggle?.setAttribute("aria-expanded", shouldOpen ? "true" : "false");

        toggle?.addEventListener("click", () => {
            const nextOpen = group.classList.contains("collapsed");
            group.classList.toggle("collapsed", !nextOpen);
            toggle.setAttribute("aria-expanded", nextOpen ? "true" : "false");
            localStorage.setItem(storageKey, nextOpen ? "true" : "false");
        });
    });

    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && body.classList.contains("sidebar-open")) {
            setSidebarState(false);
        }
    });

    setSidebarState(localStorage.getItem(sidebarStorageKey) === "true");
});
