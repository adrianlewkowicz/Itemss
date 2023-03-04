using System;
using Repository.Entity;
using Sieve.Models;

namespace Repository.RepositoryItem
{
	public interface IItemRepository
	{
        public Task<List<Item>> GetItemListAsync(SieveModel query);
        public Task<Item> GetItemByIdAsync(int Id);
        public Task<Item> AddItemAsync(Item itemDetails);
        public Task<int> UpdateItemAsync(Item itemDetails);
        public Task<int> DeleteItemAsync(int Id);
    }
}

