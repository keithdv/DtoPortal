using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using Autofac;

namespace Example.Test
{

    public interface ILogger
    {
        void Log(string message);
        void Log(Exception ex);
    }

    public interface IEmail
    {
        void SendEmail(string to, string subject, string body);
    }

    public interface IBusinessObject
    {
        void Submit(string emailAddress);
    }

    public class BusinessObject : IBusinessObject
    {

        ILogger logger;
        IEmail email;

        public BusinessObject(ILogger logger, IEmail email)
        {
            this.logger = logger;
            this.email = email;
        }

        public void Submit(string emailAddress)
        {
            try
            {
                email.SendEmail(emailAddress, "Business Object Email", "Demo");
            }
            catch (Exception ex)
            {
                logger.Log(ex);
            }
        }

    }


    [TestClass]
    public class BusinessObjectTests
    {
        public void Submit()
        {

            // Arrange
            var loggerMock = new Mock<ILogger>(MockBehavior.Strict);
            var emailMock = new Mock<IEmail>(MockBehavior.Strict);
            string emailAddress = @"test@fake.com";

            var bo = new BusinessObject(loggerMock.Object, emailMock.Object);

            // Setup emailMock







            // Setup LoggerMock









            // Act

            bo.Submit(emailAddress);

            // Assert











        }


        public void Submit_Autofac()
        {
            // Arrange
            var logger = new Mock<ILogger>(MockBehavior.Strict);
            var email = new Mock<IEmail>(MockBehavior.Strict);

            var builder = new ContainerBuilder();

            // register...

            var container = builder.Build();

            var bo = container.Resolve<IBusinessObject>();

            // Act

            bo.Submit();

            // Assert
        }
    }
}
