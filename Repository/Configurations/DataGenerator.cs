using System;
using Bogus;
using Repository.Entity;

namespace Repository.Configurations
{
	public class DataGenerator
	{
		public static void Seed(DataContext context)
		{
			var local = "pl";

			Randomizer.Seed = new Random(911);

			var itemsGenerator = new Faker<Item>(local)
				.RuleFor(a => a.COD, f => f.Lorem.Text())
				.RuleFor(a => a.Title, f => f.Lorem.Text())
				.RuleFor(a => a.Title, f => f.Lorem.Text());

			Item items = itemsGenerator.Generate();

			context.Add(items);
			context.SaveChanges();
		}
	}
}

