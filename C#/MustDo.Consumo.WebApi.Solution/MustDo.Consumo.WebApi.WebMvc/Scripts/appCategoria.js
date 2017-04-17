var ViewModel = function () {
    var self = this;
    self.tarefas = ko.observableArray();
    self.categorias = ko.observableArray();
    self.categoriaSeleted = {
        Categoria: ko.observable()
    }
    self.error = ko.observable();

    var baseUri = 'http://mustdo-webapi.azurewebsites.net';
    var tarefasPorCategoriaUri = baseUri + '/api/TarefasPorCategoria/';
    var categoriasUri = baseUri + '/api/Categorias/';

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
    function getAllCategorias() {
        ajaxHelper(categoriasUri, 'GET').done(function (data) {
            self.categorias(data);
        });
    }

    getAllCategorias();

    self.obterTarefasPorCategoria = function (formElement) {
        var id = self.categoriaSeleted.Categoria().CategoriaId;
        
        ajaxHelper(tarefasPorCategoriaUri + id, 'GET').done(function (data) {
            self.tarefas(data);
        });
    }
};
ko.applyBindings(new ViewModel());
