using BusinessLogic.Commands;
using BusinessLogic.DTO;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfAddPostCommand : EfBaseCommand, IAddPostCommand
    {
        public EfAddPostCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddPostDto request)
        {
            Context.Posts.Add(new Post
            {
                UserId = request.UserId,
                ModelId = request.ModelId,
                FuelId = request.FuelId
            });
        }
    }
}
