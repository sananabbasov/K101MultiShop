using System;
using MultiShop.Core.DataAccess.EntityFramework;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;

namespace MultiShop.DataAccess.Concrete.EntityFramework
{
	public class EfOrderDal : EfRepositoryBase<Order, AppDbContext>, IOrderDal
	{
		
	}
}

