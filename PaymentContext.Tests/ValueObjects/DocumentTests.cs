using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PaymentContext.Tests.ValueObjects;

public class DocumentTests
{
    [Theory]
    [InlineData("12345678912")]
    [InlineData("1234567891234")]
    [InlineData("12.345.678/0001-12")]
    [InlineData("12.345.678/0001-1234")]
    public void ShouldReturnErrorWhenCNPJIsInvalid(string CNPJ)
    {
        var document = new Document(CNPJ, EDocumentType.CNPJ);
        Assert.False(document.IsValid);
    }

    [Theory]
    [InlineData("13.078.411/0001-41")]
    [InlineData("04.811.378/0001-26")]
    [InlineData("50.654.201/0001-80")]
    [InlineData("13078411000141")]
    [InlineData("50654201000180")]
    public void ShouldReturnSuccessWhenCNPJIsValid(string CNPJ)
    {
        var document = new Document(CNPJ, EDocumentType.CNPJ);
        Assert.True(document.IsValid);
    }

    [Theory]
    [InlineData("12345678912")]
    [InlineData("1234567891234")]
    [InlineData("123.456.789-12")]
    [InlineData("123.456.789-1234")]
    [InlineData("50.654.201/0001-80")]
    public void ShouldReturnErrorWhenCPFIsInvalid(string CPF)
    {
        var document = new Document(CPF, EDocumentType.CPF);
        Assert.False(document.IsValid);
    }

    [Theory]
    [InlineData("788.442.320-06")]
    [InlineData("148.866.550-84")]
    [InlineData("900.903.870-07")]
    [InlineData("842.190.780-88")]
    [InlineData("54756176860")]
    [InlineData("75493529840")]
    public void ShouldReturnSuccessWhenCPFIsValid(string CPF)
    {
        var document = new Document(CPF, EDocumentType.CPF);
        Assert.True(document.IsValid);
    }
}