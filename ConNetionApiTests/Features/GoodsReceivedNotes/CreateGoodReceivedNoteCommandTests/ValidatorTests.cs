using System;
using AutoFixture;
using Domain.Http.GoodsReceivedNotes;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;
using Validator = Application.Features.GoodReceivedNotes.Commands.CreateGoodsReceivedNoteCommand.Validator;
namespace ConNetion.Application.Tests.Features.GoodsReceivedNotes.CreateGoodReceivedNoteCommandTests;

public class ValidatorTests
{
    private readonly Validator _validator;

    public ValidatorTests()
    {
        _validator = new Validator();
    }

    [Fact]
    public void ValidateRequest_WhenGrnNumberIsEmpty_RequestIsInvalid()
    {
        var request = new Fixture().Create<CreateGoodsReceivedNoteRequest>();
        request.GrnNumber = string.Empty;
        var failures = _validator.TestValidate(request);
        failures.ShouldHaveValidationErrorFor(x => x.GrnNumber);
    }

    [Fact]
    public void ValidateRequest_WhenGrnDateIsEmpty_RequestIsInvalid()
    {
        var request = new Fixture().Create<CreateGoodsReceivedNoteRequest>();
        request.GrnDate = DateTimeOffset.MinValue;
        var failures = _validator.TestValidate(request);
        failures.ShouldHaveValidationErrorFor(x => x.GrnDate);
    }

    [Fact]
    public void ValidateRequest_WhenDocumentDateIsEmpty_RequestIsInvalid()
    {
        var request = new Fixture().Create<CreateGoodsReceivedNoteRequest>();
        request.DocumentDate = DateTimeOffset.MinValue;
        var failures = _validator.TestValidate(request);
        failures.ShouldHaveValidationErrorFor(x => x.DocumentDate);
    }

    [Fact]
    public void ValidateRequest_WhenEmailAddressIsInvalid_RequestIsInvalid()
    {
        var request = new Fixture().Create<CreateGoodsReceivedNoteRequest>();
        request.Address.Email = "WrongEmail";
        var failures = _validator.TestValidate(request);
        failures.ShouldHaveValidationErrorFor(x => x.Address.Email);
    }

    [Fact]
    public void ValidateRequest_WhenZipCodeIsInvalid_RequestIsInvalid()
    {
        var request = new Fixture().Create<CreateGoodsReceivedNoteRequest>();
        request.Address.ZipCode = "asds";
        var failures = _validator.TestValidate(request);
        failures.ShouldHaveValidationErrorFor(x => x.Address.ZipCode);
    }
}