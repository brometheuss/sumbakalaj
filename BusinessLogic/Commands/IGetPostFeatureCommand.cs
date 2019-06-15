﻿using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Commands
{
    public interface IGetPostFeatureCommand : ICommand<PostQuery, IEnumerable<GetPostFeatureDto>>
    {
    }
}
