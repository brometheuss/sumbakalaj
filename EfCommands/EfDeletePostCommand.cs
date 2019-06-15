using BusinessLogic.Commands;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeletePostCommand : EfBaseCommand, IDeletePostCommand
    {
        public EfDeletePostCommand(EfContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var post = Context.Posts.Find(request);

            if (post == null)
                throw new EntityNotFoundException();

            Context.Posts.Remove(post);
            Context.SaveChanges();
        }
    }
}
