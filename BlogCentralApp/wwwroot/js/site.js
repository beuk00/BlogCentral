// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function () {
    'use strict'
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    tooltipTriggerList.forEach(function (tooltipTriggerEl) {
        new bootstrap.Tooltip(tooltipTriggerEl)
    })
})()

tinymce.init({
    selector: '#editable',
    plugins: ['autoresize', 'autolink'],
    autoresize_bottom_margin: 0,
    brand: false,
    menubar: false,
    default_link_target: '_blank',
    link_default_protocol: 'https',
    statusbar: false,


});
