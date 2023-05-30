﻿using System;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Entities.Concrete
{
	public class Product : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

