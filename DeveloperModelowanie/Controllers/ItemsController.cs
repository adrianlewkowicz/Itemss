using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.Models;
using Repository.RepositoryItem;
using Sieve.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperModelowanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repository;
        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Item>> GetItemListAsync([FromBody]SieveModel query)
        {
            return await _repository.GetItemListAsync(query);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetItems(int id)
        {
            return (IActionResult)await _repository.GetItemByIdAsync(id);
        }

        [HttpPost]
        public async Task<Item> AddItemAsyn(Item item)
        {
            return await _repository.AddItemAsync(item);
        }

        [HttpDelete]
        public async Task<int> Delate(int id)
        {
            return await _repository.DeleteItemAsync(id);
        }
    }
}

