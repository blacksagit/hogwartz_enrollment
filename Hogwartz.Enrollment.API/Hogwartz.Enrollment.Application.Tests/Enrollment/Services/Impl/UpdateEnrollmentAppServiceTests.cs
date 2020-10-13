namespace Hogwartz.Enrollment.Application.Tests.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;
    using Hogwartz.Enrollment.Application.Enrollment.Services;
    using Hogwartz.Enrollment.Application.Enrollment.Services.Impl;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class UpdateEnrollmentAppServiceTests
    {
        public IUpdateEnrollmentAppService GetSut(
            out Mock<IUpdateEnrollmentDomainService> updateEnrollmentDomainServiceMock,
            out Mock<IGetEnrollmentDomainService> getEnrollmentDomainServiceMock)
        {
            updateEnrollmentDomainServiceMock = new Mock<IUpdateEnrollmentDomainService>(MockBehavior.Strict);
            getEnrollmentDomainServiceMock = new Mock<IGetEnrollmentDomainService>(MockBehavior.Strict);

            return new UpdateEnrollmentAppService(
                updateEnrollmentDomainServiceMock.Object,
                getEnrollmentDomainServiceMock.Object);
        }

        [Test]
        public void UpdateEnrollment_ValidRequest_Ok()
        {
            var sut = GetSut(out Mock<IUpdateEnrollmentDomainService> updateEnrollmentDomainServiceMock,
                out Mock<IGetEnrollmentDomainService> getEnrollmentDomainServiceMock);

            updateEnrollmentDomainServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<EnrollmentRequest>()));
            getEnrollmentDomainServiceMock.Setup(x => x.Get()).Returns(new List<EnrollmentRequest>
            {
                new EnrollmentRequest { Id = 1 }
            });

            var command = new UpdateEnrollmentCommand
            {
                Id = 1,
                Request = SharedMethods.GetEnrollmentRequest()
            };

            Assert.DoesNotThrow(() => sut.Update(command));

            updateEnrollmentDomainServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<EnrollmentRequest>()));
            getEnrollmentDomainServiceMock.Verify(x => x.Get());
        }
    }
}
