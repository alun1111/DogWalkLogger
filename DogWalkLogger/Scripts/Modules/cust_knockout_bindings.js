ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datepickerOptions || {},
            $el = $(element);

        //initialize datepicker with some optional options
        $el.datepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($el.datepicker("getDate"));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $el.datepicker("destroy");
        });

    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor()),
            $el = $(element),
            current = $el.datepicker("getDate");

        if (value - current !== 0) {
            $el.datepicker("setDate", value);
        }
    }
};

ko.bindingHandlers.hoverToggle = {
    update: function (element, valueAccessor) {
        var css = valueAccessor();

        ko.utils.registerEventHandler(element, "mouseover", function () {
            ko.utils.toggleDomNodeCssClass(element, ko.utils.unwrapObservable(css), true);
        });

        ko.utils.registerEventHandler(element, "mouseout", function () {
            ko.utils.toggleDomNodeCssClass(element, ko.utils.unwrapObservable(css), false);
        });
    }
};

ko.bindingHandlers.date = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor();
        var allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);

        // Date formats: http://momentjs.com/docs/#/displaying/format/
        var pattern = allBindings.format || 'DD/MM/YYYY';

        var output = "-";
        if (valueUnwrapped !== null && valueUnwrapped !== undefined && valueUnwrapped.length > 0) {
            output = moment(valueUnwrapped).format(pattern);
        }

        if ($(element).is("input") === true) {
            $(element).val(output);
        } else {
            $(element).text(output);
        }
    }
};

//Docs - http://xdsoft.net/jqplugins/datetimepicker/
ko.bindingHandlers.datetimepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datetimepickerOptions || {},
            $el = $(element);

        //initialize datetimepicker with some optional options
        $el.datetimepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($el.val());
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $el.datetimepicker("destroy");
        });

    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor()),
            $el = $(element),
            current = $el.val();

        if (value - current !== 0) {
            //$el.val(value);
            $el.val(moment(value).format("YYYY-MM-DD HH:mm"));
        }
    }
};

ko.bindingHandlers.money = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var output = "";

        if (valueUnwrapped !== "") {
            var decValue = valueUnwrapped / 100.00;
            output = "£" + decValue;
        }

        if ($(element).is("input") === true) {
            $(element).val(output);
        } else {
            $(element).text(output);
        }
    }
};
