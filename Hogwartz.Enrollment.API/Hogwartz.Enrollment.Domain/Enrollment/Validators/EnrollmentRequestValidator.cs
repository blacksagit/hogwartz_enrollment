namespace Hogwartz.Enrollment.Domain.Enrollment.Validators
{
    using Conditions;
    using Hogwartz.Common.Domain.Common.Validators;
    using Hogwartz.Enrollment.Domain.Enrollment.Exceptions;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using System;

    public class EnrollmentRequestValidator : IValidator<EnrollmentRequest>
    {
        public void Validate(EnrollmentRequest valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.Person.Requires().IsNotNull();
                valueToValidate.Person.Name.Requires().IsNotNull();
                valueToValidate.Person.Info.Requires().IsNotNull();
                valueToValidate.Person.Name.First.Requires().IsNotNull();
                valueToValidate.Person.Name.Last.Requires().IsNotNull();
                valueToValidate.Person.Info.DateOfBirth.Requires().IsLessThan(DateTime.Now);
                valueToValidate.Person.Info.DateOfBirth.Requires().IsGreaterThan(DateTime.MinValue);
            }
            catch
            {
                throw new InvalidEnrollmentRequestException();
            }

        }
    }
}
