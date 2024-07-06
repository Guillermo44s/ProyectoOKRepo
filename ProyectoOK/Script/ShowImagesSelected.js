document.addEventListener("DOMContentLoaded", function () {
    const fileInput = document.getElementById('fileInputProductImages');
    const imagePreview = document.getElementById('imagePreview');

    fileInput.addEventListener('change', function () {
        imagePreview.innerHTML = '';
        const files = fileInput.files;

        for (let i = 0; i < files.length; i++) {
            const file = files[i];
            if (file.type.startsWith('image/')) {
                const reader = new FileReader();

                reader.onload = function (event) {
                    const img = document.createElement('img');
                    img.src = event.target.result;
                    imagePreview.appendChild(img);
                }

                reader.readAsDataURL(file);
            }
        }
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const fileInput = document.getElementById('fileInputImageCover');
    const imagePreview = document.getElementById('imagePreviewCover');

    fileInput.addEventListener('change', function () {
        imagePreview.innerHTML = '';
        const files = fileInput.files;

        for (let i = 0; i < files.length; i++) {
            const file = files[i];
            if (file.type.startsWith('image/')) {
                const reader = new FileReader();

                reader.onload = function (event) {
                    const img = document.createElement('img');
                    img.src = event.target.result;
                    imagePreview.appendChild(img);
                }

                reader.readAsDataURL(file);
            }
        }
    });
});