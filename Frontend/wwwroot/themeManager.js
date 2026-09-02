window.themeManager = {
    get: function () {
        return localStorage.getItem('theme') || 'system';
    },
    set: function (theme) {
        localStorage.setItem('theme', theme);
        window.themeManager.apply(theme);
    },
    apply: function (theme) {
        const resolved = theme === 'system'
            ? (window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light')
            : theme;
        document.documentElement.setAttribute('data-bs-theme', resolved);
    }
};

window.themeManager.apply(window.themeManager.get());
