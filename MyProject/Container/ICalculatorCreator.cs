﻿using MyProject.Operations;
using System.Collections.Generic;

namespace MyProject.Container
{
    interface ICalculatorCreator
    {
        IEnumerable<IOperation> GetOperations();
        IMyCalculator CreateCalculator();
    }
}
