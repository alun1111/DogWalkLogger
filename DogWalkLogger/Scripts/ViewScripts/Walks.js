function WalksIndex(jQuery) {

    window.mod_walks = new WalksIndexModel();
    ko.applyBindings(mod_walks);
    mod_walks.getAllDogWalks();
}

function WalksIndexModel() {
    var self = this;

    self.dogWalks = ko.observableArray('');

    self.getAllDogWalks = function () {
        //Load initial state from server and populate viewmodel
        $.getJSON("/api/dogwalk/", function (data) {
            self.dogWalks(data);
        });
    }
}