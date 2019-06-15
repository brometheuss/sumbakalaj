using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfEditPostCommand : EfBaseCommand, IEditPostCommand
    {
        public EfEditPostCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddPostDto request)
        {
            var post = Context.Posts.Find(request.Id);

            if (post == null)
                throw new EntityNotFoundException();

            post.UserId = request.UserId;
            post.ModelId = request.ModelId;
            post.FuelId = request.FuelId;
            Context.SaveChanges();
        }
    }
}
