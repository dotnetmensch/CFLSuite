function onThrowDropDownData() {
    return {
        playerID: $("#PlayerID").data("kendoDropDownList").value(),
        betID: $('#BetID').val()
    }
}

function onRedemptionPlayerDropDownData() {
    return {
        betID: $('#BetID').val()
    }
}

function onRedemptionPlayeDropDownDatabound(e) {
    if (e.sender.value()) {
        var dropDown = $('#ThrowID').data('kendoDropDownList');
        dropDown.enable(true);
        dropDown.dataSource.read();
    } 
}

function onRedemptionPlayerDropDownChange(e) {
    var dropDown = $('#ThrowID').data('kendoDropDownList');
    if (e.sender.value()) {
        dropDown.enable(true);
        dropDown.dataSource.read();
    } else {
        dropDown.value('');
        dropDown.enable(false);
    }
}