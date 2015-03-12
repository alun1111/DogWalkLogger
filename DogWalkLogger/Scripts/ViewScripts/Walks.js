function WalksIndex(jQuery) {
    window.mod_walks = new WalksIndexModel();
    ko.applyBindings(mod_walks);
    mod_walks.getAllDogWalks();
}

function WalksIndexModel() {
    var self = this;

    self.dogWalks = ko.observableArray('');

    self.dogWalked = ko.observable('');
    self.walk = ko.observable('');
    self.walker = ko.observable('');
    self.start = ko.observable('');
    self.comment = ko.observable('');
    self.rating = ko.observable('');
    
    self.getAllDogWalks = function () {
        //Load initial state from server and populate viewmodel
        $.getJSON("/api/dogwalk/", function (data) {
            self.dogWalks(data);
        });
    }

    self.saveWalk = function () {
        // Save row
        
        var jsonData = JSON.stringify({
            "dogWalked": self.dogWalked()
            ,"walk": self.walk()
            ,"walker": self.walker()
            ,"start": self.start()
            ,"comment": self.comment()
            ,"rating": self.rating()
        });

        $.ajax({
            url: '/api/dogwalk/',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: jsonData,
            success: function (data) {
                self.getAllDogWalks();
            }
        });
    }
}