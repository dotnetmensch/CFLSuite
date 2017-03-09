function onCancelBet(e) {
    $('#addBetWindow').data('kendoWindow').close();
}

function onAddParticipantsClick(e) {
    var url = $(e.target).data("url");
    var grid = $(e.target).closest(".k-grid").data('kendoGrid');
    var row = $(e.target).closest("tr");
    var betID = grid.dataItem(row).BetID;
    window.location.href = url + "/" + betID;
}

