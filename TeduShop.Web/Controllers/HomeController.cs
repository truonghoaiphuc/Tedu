using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productSevice;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService, ICommonService commonService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productSevice = productService;
            _commonService = commonService;
        }


        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var latestProduct = _productSevice.GetLatest(3);
            var hotProduct = _productSevice.GetHotProduct(3);
            var latestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(latestProduct);
            var hotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProduct);

            homeViewModel.LatestProducts = latestProductViewModel;
            homeViewModel.TopSales = hotProductViewModel;

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map< IEnumerable < ProductCategory > ,IEnumerable <ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}