﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IEmailSender
    {
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        void Send();
    }
}
