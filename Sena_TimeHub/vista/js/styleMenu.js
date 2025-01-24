document.addEventListener('DOMContentLoaded', () => {
    // Seleccionamos todos los elementos con submenús
    const navItems = document.querySelectorAll('.nav-item > span');

    navItems.forEach((item) => {
        item.addEventListener('click', (e) => {
            e.stopPropagation(); // Prevenir que el evento se propague a otros elementos
            const currentDropdown = item.nextElementSibling; // Seleccionar el submenú correspondiente

            // Ocultar todos los demás submenús
            document.querySelectorAll('.dropdown-menu').forEach((menu) => {
                if (menu !== currentDropdown) {
                    menu.style.display = 'none';
                }
            });

            // Alternar la visibilidad del submenú actual
            if (currentDropdown) {
                currentDropdown.style.display =
                    currentDropdown.style.display === 'block' ? 'none' : 'block';
            }
        });
    });

    // Cerrar los submenús si se hace clic fuera del menú
    document.addEventListener('click', () => {
        document.querySelectorAll('.dropdown-menu').forEach((menu) => {
            menu.style.display = 'none';
        });
    });
});