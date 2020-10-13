namespace Hogwartz.Enrollment.Application.Tests.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Services;
    using Hogwartz.Enrollment.Application.Enrollment.Services.Impl;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GetEnrollmentAppServiceTests
    {
        public IGetEnrollmentAppService GetSut(out Mock<IGetEnrollmentDomainService> getEnrollmentDomainServiceMock)
        {
            getEnrollmentDomainServiceMock = new Mock<IGetEnrollmentDomainService>(MockBehavior.Strict);

            return new GetEnrollmentAppService(getEnrollmentDomainServiceMock.Object);
        }

        [Test]
        public void GetEnrollments_Ok()
        {
            var sut = GetSut(out Mock<IGetEnrollmentDomainService> getEnrollmentDomainServiceMock);

            getEnrollmentDomainServiceMock.Setup(x => x.Get()).Returns(new List<EnrollmentRequest>());

            var results = sut.Get();

            getEnrollmentDomainServiceMock.Verify(x => x.Get());
        }
    }
}
