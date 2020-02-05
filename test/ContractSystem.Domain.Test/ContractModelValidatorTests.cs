using ContractSystem.Domain.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace ContractSystem.Domain.Test
{
    public class ContractModelValidatorTests
    {

        /// <summary>
        /// chack ContractModelValidator for end date it should be greater than start date
        /// expect: test validator return true value
        /// </summary>
        [Fact]
        public void Should_not_have_error_when_EndDate_is_GreaterThan_StartDate()
        {
            // Arrange
            ContractModelValidator validator = new ContractModelValidator();
            var contracModel = new Model.ContractModel() { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };

            // Act
            var result = validator.TestValidate(contracModel);

            //Assert
            Assert.True(result.IsValid);

        }

        /// <summary>
        /// chack ContractModelValidator for end date it should be greater than start date
        /// expect: test validator return false value and result contain error
        /// </summary>
        [Fact]
        public void Should_have_error_when_EndDate_isnot_GreaterThan_StartDate()
        {
            // Arrange
            ContractModelValidator validator = new ContractModelValidator();
            var contracModel = new Model.ContractModel() { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(-1) };

            // Act
            var result = validator.TestValidate(contracModel);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.EndDate);
            Assert.False(result.IsValid);

        }

    }
}
