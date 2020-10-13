namespace Hogwartz.Enrollment.Application.Tests.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;
    using Hogwartz.Enrollment.Application.Enrollment.Services;
    using Hogwartz.Enrollment.Application.Enrollment.Services.Impl;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class AddEnrollmentAppServiceTests
    {
        public IAddEnrollmentAppService GetSut(out Mock<IAddEnrollmentDomainService> addEnrollmentDomainServiceMock)
        {
            addEnrollmentDomainServiceMock = new Mock<IAddEnrollmentDomainService>(MockBehavior.Strict);

            return new AddEnrollmentAppService(addEnrollmentDomainServiceMock.Object);
        }

        [Test]
        public void AddEnrollment_ValidRequest_Ok()
        {
            var sut = GetSut(out Mock<IAddEnrollmentDomainService> addEnrollmentDomainServiceMock);

            addEnrollmentDomainServiceMock.Setup(x => x.Add(It.IsAny<EnrollmentRequest>()));

            var command = new AddEnrollmentCommand
            {
                Request = SharedMethods.GetEnrollmentRequest()
            };

            Assert.DoesNotThrow(() => sut.Add(command));

            addEnrollmentDomainServiceMock.Verify(x => x.Add(It.IsAny<EnrollmentRequest>()));
        }
    }
}
