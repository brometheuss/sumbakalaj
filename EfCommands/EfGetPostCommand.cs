using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetPostCommand : EfBaseCommand, IGetPostCommand
    {
        public EfGetPostCommand(EfContext context) : base(context)
        {
        }

        public GetPostDto Execute(int request)
        {
            var post = Context.Posts.Find(request);

            if (post == null)
                throw new EntityNotFoundException();

            return new GetPostDto
            {
                UserId = post.UserId,
                ModelId = post.ModelId,
                FuelId = post.FuelId
            };
        }
    }
}
