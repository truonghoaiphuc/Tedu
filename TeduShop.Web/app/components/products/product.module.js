(function () {
    angular.module("tedushop.products", ['tedushop.common']).config(config);

    config.$inject = ["$stateProvider", '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateurl: "/app/components/products/productListView.html",
            controller: "producListController"
        }).state('product_add', {
            url: "/product_add",
            templateurl: "/app/components/products/productAddView.html",
            controller: "producAddController"
        });
    }
})();