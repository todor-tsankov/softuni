﻿using SOLID_Exercise.Models.Enumerations;

namespace SOLID_Exercise.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        long MessagesAppended { get; }

        void Append(IError error);
    }
}
