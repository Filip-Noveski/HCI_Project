function toggleMode() {
    var light_mode = document.getElementById('light-mode');
    var light_mode_spec = document.getElementById('light-mode-specific');
    if (light_mode.href.includes('/css/site_light.css') || light_mode.href == undefined) {
        light_mode.href = '/css/site_dark.css';
        if (light_mode_spec != undefined)
            light_mode_spec.href = light_mode_spec.href.replace('light', 'dark');
        document.getElementById('light-mode-toggle').style.marginLeft = '18px';
        document.getElementById("cart-icon").src = "/Images/Icons/cart_d.svg";
        localStorage.setItem('theme', 'dark');
        return;
    }

    light_mode.href = '/css/site_light.css';
    if (light_mode_spec != undefined)
        light_mode_spec.href = light_mode_spec.href.replace('dark', 'light');
    document.getElementById('light-mode-toggle').style.marginLeft = '3px';
    document.getElementById("cart-icon").src = "/Images/Icons/cart_l.svg";
    localStorage.setItem('theme', 'light');
}