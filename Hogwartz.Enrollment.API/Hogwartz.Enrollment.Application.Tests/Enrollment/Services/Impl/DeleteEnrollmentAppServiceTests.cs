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
    public class DeleteEnrollmentAppServiceTests
    {
        public IDeleteEnrollmentAppService GetSut(
            out Mock<IDeleteEnrollmentDomainService> deleteEnrollmentDomainServiceMock,
            out Mock<IGetEnrollmentDomainService> getEnrollmentDomainServiceMock)
        {
            deleteEnrollmentDomainServiceMock = new Mock<IDeleteEnrollmentDomainService>(MockBehavior.Strict);
            getEnrollmentDomainServiceMock = new Mock<IGetEnrollmentDomainService>(MockBehavior.Strict);

            return new DeleteEnrollmentAppService(
                deleteEnrollmentDomainServiceMock.Object,
                getEnrollmentDomainServiceMock.Object);
        }

        [Test]
        public void DeleteEnrollment_ValidRequest_Ok()
        {
            var sut = GetSut(out Mock<IDeleteEnrollmentDomainService> deleteEnrollmentDomainServiceMock,
                out Mock<IGetEnrollmentDomainService> getEnrollmentDomainServiceMock);

            deleteEnrollmentDomainServiceMock.Setup(x => x.Delete(It.IsAny<int>()));
            getEnrollmentDomainServiceMock.Setup(x => x.Get()).Returns(new List<EnrollmentRequest>
            {
                new EnrollmentRequest { Id = 1 }
            });

            var command = new DeleteEnrollmentCommand
            {
                Id = 1
            };

            Assert.DoesNotThrow(() => sut.Delete(command));

            deleteEnrollmentDomainServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
            getEnrollmentDomainServiceMock.Verify(x => x.Get());
        }
    }
}
