using System;
using System.Collections.Generic;
using System.Text;
using EFDataAccess;

namespace EFCommands
{
    public class BaseEFCommand
    {
        protected AIContext AiContext { get; }
        protected BaseEFCommand(AIContext context)
        {
            AiContext = context;
        }
		
    }
}
