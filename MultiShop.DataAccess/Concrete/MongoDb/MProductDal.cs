using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Core.DataAccess.MongoDb.Concrete;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.DataAccess.Concrete.MongoDb
{
    public class MProductDal : MongoRepository<Product>, IProductDal
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly ICategoryDal _categoryDal;
        public MProductDal(IDatabaseSettings databaseSettings, ICategoryDal categoryDal) : base(databaseSettings)
        {
            var database = new MongoClient(databaseSettings.ConnectionString).GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Product>("products");
            _categoryDal = categoryDal;
        }

        public List<DiscountProductDTO> DiscountProducts(string langcode)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new DiscountProductDTO
            {
                Id = x.Id,
                Discount = x.Discount,
                Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcode).Name,
                PhotoUrl = x.PhotoUrl,
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = _categoryDal.GetCategoriesByLanguage(langcode, x.Categories)
            }).Where(x=>x.Discount > 0).OrderByDescending(x => x.Id).ToList();
            return result;
        }

        public ProductDetailDTO GetProductById(string langcode, string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
            var product = _collection.Find(filter).FirstOrDefault();
            ProductDetailDTO productDetail = new()
            {
                Id = product.Id,
                Name = product.ProductLanguages.FirstOrDefault(x => x.LangCode == langcode).Name,
                Description = product.ProductLanguages.FirstOrDefault(x=>x.LangCode == langcode).Description,
                PhotoUrl= product.PhotoUrl,
                Price = product.Price,
                Discount = product.Discount
            };


            return productDetail;
        }

        public List<ProductDashboardListDTO> GetProductByLanguage(string langcode)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new ProductDashboardListDTO
            {
                Id = x.Id,
                Name = x.ProductLanguages.FirstOrDefault(z=>z.LangCode == langcode).Name,
                PhotoUrl = x.PhotoUrl,
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = _categoryDal.GetCategoriesByLanguage(langcode, x.Categories)
            }).ToList();
            return result;
        }

        public List<RecentProductDTO> RecentProducts(string langcode)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new RecentProductDTO
            {
                Id = x.Id,
                Discount = x.Discount,
                Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcode).Name,
                PhotoUrl = x.PhotoUrl,
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = _categoryDal.GetCategoriesByLanguage(langcode, x.Categories)
            }).OrderByDescending(x=>x.Id).ToList();
            return result;
        }
    }
}

