var ViewModel = function () {
    var self = this;
    self.tarefas = ko.observableArray();
    self.tags = ko.observableArray();
    self.tagSeleted = {
        Tag: ko.observable()
    }
    self.error = ko.observable();

    var baseUri = 'http://localhost:63445';
    var tarefasPorTagUri = baseUri + '/api/TarefasPorTag/';
    var tagsUri = baseUri + '/api/Tags/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }
    function getAllTags() {
        ajaxHelper(tagsUri, 'GET').done(function (data) {
            self.tags(data);
        });
    }

    getAllTags();

    self.obterTarefasPorTag = function (formElement) {
        var id = self.tagSeleted.Tag().TagId;

        ajaxHelper(tarefasPorTagUri + id, 'GET').done(function (data) {
            self.tarefas(data);
        });
    }
};

ko.applyBindings(new ViewModel());
