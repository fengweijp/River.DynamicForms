function readURL(input) {
    var filenameElement = $('#' + input.name +'-filename');
    var previewElement = $('#' + input.name +'-preview');

    previewElement.hide();

    if (input.files && input.files[0]) {

        var reader = new FileReader();
        reader.onload = function (e) {
            filenameElement.hide();
            previewElement.attr('src', e.target.result).show();
        }
        reader.readAsDataURL(input.files[0]);
    }
    else {
        var filename = $(this).val();
        filenameElement.html(filename.replace(/^.*[\\\/]/, '')).show();
    }
}

$(function () {
    $(".ImageFileFieldElement").change(function () {
        readURL(this);
    });
});


function uploadPhoto(ImageFileFieldName) {
    $("[name=" + ImageFileFieldName + "]").click();
}