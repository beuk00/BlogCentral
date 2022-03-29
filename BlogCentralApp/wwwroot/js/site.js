// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function () {
    'use strict'
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    tooltipTriggerList.forEach(function (tooltipTriggerEl) {
        new bootstrap.Tooltip(tooltipTriggerEl)
    })
})();


//Implementing RichTextEditor with tinyMCE. 
tinymce.init({
    selector: '#editable',
    plugins: ['autoresize', 'autolink', 'image'],
    content_css: 'default',
    skin: 'tinymce-5',
    autoresize_bottom_margin: 0,
    statusbar: false,
    brand: false,
    menubar: false,
    link_default_protocol: 'https',
    min_height: 400,
    toolbar: 'undo redo | h1 h2 h3 h4 h5 | lineheight  forecolor | bold italic underline strikethrough | alignleft aligncenter alignright | image | selectall|',

});

