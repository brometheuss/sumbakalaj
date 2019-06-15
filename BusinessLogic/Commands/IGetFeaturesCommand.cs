﻿using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Queries;
using BusinessLogic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Commands
{
    public interface IGetFeaturesCommand : ICommand<FeatureQuery, Pagination<GetFeatureDto>>
    {
    }
}
