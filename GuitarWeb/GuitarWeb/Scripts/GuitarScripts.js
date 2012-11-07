function GetGuitars() {
    $.post("GetGuitars", function(guitars) {

        alert(guitars[0].RegNumber);

        var remainingGuitars = "";

        for (var i = 0; i < guitars.LENGTH; i++) {
            //remainingGuitars = remainingGuitars + guitars[i].RegNumber + " ";
            alert(guitars[i].RegNumber);
        }

        alert(remainingGuitars);
    });
}



function DeleteGuitar(guitarId) {

    $.post("Delete", { guitarId: guitarId }, function (guitars) {
        alert("Guitar with id " + guitarId + " is deleted");
        
        var remainingGuitars = "";

        for (var i = 0; i < guitars.LENGTH; i++) {
            remainingGuitars += guitars[i].RegNumber + " ";
        }

        alert("Remaining guitars: " + remainingGuitars);
        
    });

    


    $.post("GuitarList");
}
