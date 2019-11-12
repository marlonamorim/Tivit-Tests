using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tivit.WebApi.Controllers;
using Tivit.WebApi.Models;

namespace Tivit.Tests
{
    [TestClass]
    public class DeviceTest
    {
        [TestMethod]
        public void Should_Return_Success_When_Invalid_Model()
        {
            var controller = new DeviceController();
            controller.ModelState.AddModelError("test", "Esse campo é obrigatório");

            Assert.IsTrue(!controller.ModelState.IsValid);
        }

        [TestMethod]
        public void Should_Return_Success_When_Valid_Model()
        {
            var device = new Device();
            device.Name = "João de Barro";
            device.Serial = "ANSB23928VJ3489CMU3847CN";

            var context = new ValidationContext(device, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Device), typeof(Device)), typeof(Device));

            var isModelStateValid = Validator.TryValidateObject(device, context, results, true);
            
            Assert.IsTrue(isModelStateValid);
        }
    }
}
