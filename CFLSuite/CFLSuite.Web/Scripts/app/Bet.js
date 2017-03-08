function onBetGridDataBound(e) {
    $('#addBet').on('click', onAddBetDialog);
}

function onAddBetDialog(e) {
    e.preventDefault();
    var url = $(e.target).data("url");

    var dialog = $("<div id='addBetWindow' />").kendoWindow({
        content: {
            url: url,
            type: 'post'
        },
        title: "Add Bet",
        modal: true,
        visible: false,
        refresh: function (e) {
            dialog.open().center();
        },
        close: function (e) {
            dialog.destroy();
        }
    }).data('kendoWindow');
}

function onCancelBet(e) {
    $('#addBetWindow').data('kendoWindow').close();
}

function onAddThrowsClick(e) {
    var url = $(e.target).data("url");
    var grid = $(e.target).closest(".k-grid").data('kendoGrid');
    var row = $(e.target).closest("tr");
    var betID = grid.dataItem(row).BetID;
    window.location.href = url + "/" + betID;
}

function onPlayerEdit() {

}