using System;
using Microsoft.Extensions.Options;
using Repository.Models;
using Sieve.Models;
using Sieve.Services;

namespace Repository.Configurations
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<ItemDto>(e => e.COD)
                .CanSort()
                .CanFilter();
            mapper.Property<ItemDto>(e => e.Title)
                .CanSort()
                .CanFilter();

            mapper.Property<ItemDto>(e => e.colors)
                .CanSort()
                .CanFilter();

            return mapper;
        }
    }
}

