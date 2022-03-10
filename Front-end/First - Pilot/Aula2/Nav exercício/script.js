document.addEventListener("click", (e) => {
  const isDropdownButton = e.target.matches("[data-dropdown-button]");
  if (!isDropdownButton && e.target.closest("[data-dropdown]") != null) return;

  let currentDopdown;
  if (isDropdownButton) {
    currentDopdown = e.target.closest("[data-dropdown]");
    currentDopdown.classList.toggle("active");
  }

  document.querySelectorAll("[data-dropdown].active").forEach((dropdown) => {
    if (dropdown === currentDopdown) return;
    dropdown.classList.remove("active");
  });
});
