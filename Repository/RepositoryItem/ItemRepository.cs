using System;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Models;
using Sieve.Models;
using Sieve.Services;

namespace Repository.RepositoryItem
{
	public class ItemRepository : IItemRepository
	{
        private readonly DataContext _dataContext;
        private readonly ISieveProcessor _sieveProcessor;
		public ItemRepository(DataContext dataContext, ISieveProcessor sieveProcessor)
		{
            _dataContext = dataContext;
            _sieveProcessor = sieveProcessor;
		}

        public async Task<List<Item>> GetItems()
        {
            return await _dataContext.GetItems.ToListAsync();
        }

        public async Task<List<Item>> GetItemListAsync(SieveModel query)
        {
            var itemDto = _dataContext.GetItems.AsQueryable();

           var dtos = await _sieveProcessor
                .Apply(query, itemDto)
                .Select(e => new ItemDto()
                {
                    Id = e.Id,
                    COD = e.COD,
                    Title = e.Title,
                })
                .ToListAsync();

            var totalCount = await _sieveProcessor
                .Apply(query, itemDto, applyPagination: false, applySorting: false)
                .CountAsync();

            var result = new PagedResult<ItemDto>(dtos, totalCount, query.Page.Value, query.PageSize.Value);

            return itemDto.ToList();
        }

        public async Task<Item> GetItemByIdAsync(int Id)
        {
            return await _dataContext.GetItems.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<Item> AddItemAsync(Item itemDetails)
        {          
            var result = await _dataContext.GetItems.AddAsync(itemDetails);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateItemAsync(Item itemDetails)
        {
            _dataContext.GetItems.Update(itemDetails);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(int Id)
        {
            var filteredData = _dataContext.GetItems.Where(x => x.Id == Id).FirstOrDefault();
            _dataContext.GetItems.Remove(filteredData);
            return await _dataContext.SaveChangesAsync();
        }


    }
}

