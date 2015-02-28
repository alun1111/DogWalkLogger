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

ko.bindingHandlers.datetimepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize timepicker with some optional options
        var options = allBindingsAccessor().timepickerOptions || {};
        $(element).datetimepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($(element).datetimepicker("getDate"));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).timepicker("destroy");
        });

    },
    //update the control when the view model changes
    update: function (element, valueAccessor) {

        var value = ko.utils.unwrapObservable(valueAccessor()),
            current = $(element).datetimepicker("getDate");

        if (value - current !== 0) {
            $(element).datetimepicker("setDate", value);
        }
    }
};