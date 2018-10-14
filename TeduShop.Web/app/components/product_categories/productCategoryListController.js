(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];

        $scope.getProductCategories = getProductCagories;

        function getProductCagories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("load Productcategory failed");
            });
        }

        $scope.getProductCategories();
    }
})(angular.module('tedushop.product_categories'));