using System.Collections.Generic;
using System.Linq;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetAllByCategoryID(int categoryID);

        IEnumerable<Product> GetLatest(int top);

        IEnumerable<Product> GetHotProduct(int top);

        IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize,string sort, out int totalRow);

        Product GetById(int id);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, ITagRepository tagReposiroty, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagReposiroty;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            var newproduct = _productRepository.Add(product);
            if (!string.IsNullOrEmpty(product.Tag))
            {
                string[] Tags = product.Tag.Split(',');

                for(int i=0;i<Tags.Length;i++)
                {
                    var tagId = StringHelper.ToUnsignString(Tags[i]);
                    if(_tagRepository.Count(x=>x.ID==tagId)==0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = Tags[i];
                        tag.Type = commonConstanst.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;

                    _productTagRepository.Add(productTag);

                }

                _unitOfWork.Commit();
            }
            return newproduct;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryID(int categoryID)
        {
            return _productRepository.GetMulti(x => x.Status && x.CategoryID == categoryID);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _productRepository.GetMulti(x => x.Status && x.HotFlag==true).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetLatest(int top)
        {
            return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize,string sort, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status == true && x.CategoryID == categoryId);

            switch(sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;
                case "discount":
                    query = query.OrderByDescending(x => x.Promotion);
                    break;
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);

            if (!string.IsNullOrEmpty(product.Tag))
            {
                string[] Tags = product.Tag.Split(',');

                for (int i = 0; i < Tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(Tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = Tags[i];
                        tag.Type = commonConstanst.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;

                    _productTagRepository.Add(productTag);

                }

                _unitOfWork.Commit();
            }            
        }
    }
}