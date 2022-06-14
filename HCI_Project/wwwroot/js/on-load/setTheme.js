var theme = localStorage.getItem('theme');
if (theme != null && theme != undefined & theme != '') {
    var light_mode = document.getElementById('light-mode');
    light_mode.href = light_mode.href.replace('light', theme);
    var light_mode_spec = document.getElementById('light-mode-specific');
    if (light_mode_spec != undefined)
        light_mode_spec.href = light_mode_spec.href.replace('light', theme);
    document.getElementById("cart-icon").src = "/Images/Icons/cart_m.svg".replace('_m.svg', `_${theme[0]}.svg`);

    if (theme == 'dark')
        document.getElementById('light-mode-toggle').style.marginLeft = '18px';
}