﻿using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IDetailService : IGenericService<Detail, DetailAddDto, DetailUpdateDto, DetailDetailDto, DetailListDto>
    {
    }
}