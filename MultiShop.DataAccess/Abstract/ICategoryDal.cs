using System;
using MultiShop.Core.DataAccess.MongoDb;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;

namespace MultiShop.DataAccess.Abstract
{
	public interface ICategoryDal: IMongoRepository<Category>
	{
		List<string> GetCategoriesByLanguage(string langcode, List<string> categoryId);
	}
}

