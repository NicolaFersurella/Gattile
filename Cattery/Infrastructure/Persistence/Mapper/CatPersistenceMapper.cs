using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Infrastructure.Persistence.Dto;

namespace Infrastructure.Persistence.Mapper
{
    public static class CatPersistenceMapper
    {
        public static CatPersistenceDto ToDto(this Cat cat)
        {
            throw new NotImplementedException("Mapping from CatPersistenceDto to Cat is not implemented yet.");
        }
        public static Cat ToEntity(this CatPersistenceDto dto)
        {
            throw new NotImplementedException("Mapping from CatPersistenceDto to Cat is not implemented yet.");
        }
    }
}
