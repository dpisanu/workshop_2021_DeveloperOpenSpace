using System;

namespace Common.CommonFramework.Commands
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}