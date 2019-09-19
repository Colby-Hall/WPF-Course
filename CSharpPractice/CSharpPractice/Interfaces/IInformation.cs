using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Interfaces
{
    interface IInformation
    {
        // only defining methods, not implementing
        // may want multiple classes to have a method, but want each to implement a different way
        string GetInformation();
    }
}
