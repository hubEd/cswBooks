var bookApp;

$(document).ready(function () {
    bookApp = new BookApp();
    bookApp.init();
    ko.applyBindings(bookApp);
});

var BookApp = function () {
    var self = this;
    //--Obs-------------------------------------------
    //------------------------------------------------
    self.userName   = ko.observable("Batman");
    self.books      = ko.observableArray([]);
    self.categories = ko.observableArray([]);
    self.authors    = ko.observableArray([]);

    self.categoriesAdd = ko.observableArray([]);
    self.authorsAdd = ko.observableArray([]);

    self.authorFilter   = ko.observable("All");
    self.categoryFilter = ko.observable("All");

    self.authorAdd = ko.observable();
    self.categoryAdd = ko.observable();
    self.bookName = ko.observable('');

    self.quote          = ko.observable("Showing All Books");
    //-------------------------------------------------

    self.init = function () {
        self.getAuthors();
        self.getCategories();
        self.getBooks(data = {AuthorId: 0, CategoryId: 0})
    }

    self.buildQuote = function () {
        var catName = self.categoryFilter().Name;
        var autName = self.authorFilter().Name;
        if (catName == "All" && autName == 'All')
            self.quote('Showing All Books');
        else if (catName != "All" && autName != 'All')
            self.quote('Showing ' + catName + ' books written by ' + autName);
        else if (catName != 'All')
            self.quote('Showing ' + catName + ' books');
        else if (autName != 'All')
            self.quote('Showing books written by ' + autName);   
    }

    //--Exposed Methods--------------------------------
    //-------------------------------------------------
    self.showBooks = function () {
        data = {
            AuthorId: self.authorFilter().AuthorId,
            CategoryId: self.categoryFilter().CategoryId
        }
        self.getBooks(data);
    }

    self.addBook = function () {
        if (self.bookName().trim() == '')
            return;
        data = {
            Name: self.bookName,
            AuthorId: self.authorAdd().AuthorId,
            CategoryId: self.categoryAdd().CategoryId,
            Pages: Math.floor((Math.random() * 200) + 300)
        }
        self.saveBook(data);
    }

    //--Gets-------------------------------------------
    //-------------------------------------------------
    self.getAuthors = function () {
        $.ajax({
            url: '/Author/GetAuthors',
            type: 'GET',
            success: function (response) {
                self.onAuthorsFound(response);
            },
            error: function (a, b, c) {

            }
        });
    }

    self.getCategories = function () {
        $.ajax({
            url: '/Category/GetCategories',
            type: 'GET',
            success: function (response) {
                self.onCategoriesFound(response);
            },
            error: function (a, b, c) {

            }
        });
    }
     
    self.getBooks = function (data) {
        $.ajax({
            url: '/Book/GetBooks',
            type: 'POST',
            data: ko.toJSON(data),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                self.onBooksFound(response);
            },
            error: function (a, b, c) {

            }
        });
    }

    self.saveBook = function (data) {
        $.ajax({
            url: '/Book/SaveBook',
            type: 'POST',
            data: ko.toJSON(data),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                self.onBookSave(response);
            },
            error: function (a, b, c) {

            }
        });
    }



    //--Callbacks-------------------------------------------------
    //------------------------------------------------------------
    self.onBooksFound = function (data) {
        self.books.removeAll();
        for (var i = 0; i < data.length; i++) {
            self.books.push(data[i]);
        }
        self.buildQuote();
    }

    self.onCategoriesFound = function (data) {
        self.categories.removeAll();
        self.categories.push({ CategoryId: 0, Name: 'All' });
        self.categoryFilter(self.categories()[0]);
        for (var i = 0; i < data.length; i++) {
            self.categories.push(data[i]);
            self.categoriesAdd.push(data[i]);
        }   
    }

    self.onAuthorsFound = function (data) {
        self.authors.push({ AuthorId: 0, Name: 'All' });
        self.authorFilter(self.authors()[0]);
        for (var i = 0; i < data.length; i++) {
            self.authors.push(data[i]);
            self.authorsAdd.push(data[i]);
        }      
    }

    self.onBookSave = function (data) {
        if (data != "Error")
            window.location.href = "/Home";
    }
    //-------------------------------------------------------------
}