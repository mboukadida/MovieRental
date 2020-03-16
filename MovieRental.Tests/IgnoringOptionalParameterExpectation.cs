using System;
using AutoFixture.Idioms;

namespace MovieRental.Tests
{
    public class IgnoringOptionalParameterExpectation : IBehaviorExpectation
    {
        private readonly IBehaviorExpectation _origin;
        public IgnoringOptionalParameterExpectation(IBehaviorExpectation origin)
        {
            _origin = origin;
        }
        public void Verify(IGuardClauseCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            var reflectionExceptionUnwrappingCommand = command as ReflectionExceptionUnwrappingCommand;
            if (reflectionExceptionUnwrappingCommand?.Command is MethodInvokeCommand methodInvokeCommand &&
                methodInvokeCommand.ParameterInfo.IsOptional)
                return;
            _origin.Verify(command);
        }
    }
}