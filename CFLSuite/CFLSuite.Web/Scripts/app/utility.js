function onGridError(e){
    if (e.errors) {
        var content = $("<div>");
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    content.append($("<div>").html(this));
                });
            }
        });

        kendo.alert(content.html());
    }
}