using PaymentContext.Domain.Entities;
using System;
namespace PaymentContext.Tests.Entities;

public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("71783247835", EDocumentType.CPF);
        _email = new Email("batman@dc.com");
        _student = new Student(_name, _document, _email);

        _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");

        _subscription = new Subscription(null);
    }

    [Fact]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        // arrange
        var payment = new PayPalCardPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email, "12345678");

        // act
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        // assert
        Assert.False(_student.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenHadNoActiveSubscription()
    {
        // arrange
        var payment = new PayPalCardPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email, "12345678");

        // act
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        // assert
        Assert.True(_student.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        // act
        _student.AddSubscription(_subscription);

        // assert
        Assert.False(_student.IsValid);
    }
}