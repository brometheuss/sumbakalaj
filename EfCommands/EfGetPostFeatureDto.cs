using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Queries;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetPostFeatureDto : EfBaseCommand, IGetPostFeatureCommand
    {
        public EfGetPostFeatureDto(EfContext context) : base(context)
        {
        }

        public IEnumerable<GetPostFeatureDto> Execute(PostQuery request)
        {
            var query = Context.Posts.AsQueryable();


            return null;  
        }
    }
}
