using System;

using SOLID_Exercise.Models.Enumerations;

namespace SOLID_Exercise.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }
    }
}
