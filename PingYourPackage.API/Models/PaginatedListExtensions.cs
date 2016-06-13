using PingYourPackage.API.Model.Dtos;
using PingYourPackage.Domain.Entities;
using System.Collections.Generic;

namespace PingYourPackage.API.Models
{
    internal static class PaginatedListExtensions
    {
        internal static PaginatedDto<TDto> ToPaginatedDto<TDto,TEntity>(this PaginatedList<TEntity> source,
            IEnumerable<TDto> items) where TDto : IDto
        {
            return new PaginatedDto<TDto>
            {
                PageIndex = source.PageIndex,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                TotalPageCount = source.TotalPageCount,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                Items = items
            };
        }
    }
}
